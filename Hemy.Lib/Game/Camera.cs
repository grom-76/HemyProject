
namespace Hemy.Lib.Game;


using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using Hemy.Lib.Core.Math;


public unsafe struct  CameraConfig() 
{
    public Vector3 position = Vector3.Zero ;
    public Vector3 target = Vector3.Zero;
    public Vector3 up = Vector3.Zero;
    public CameraProjectionType projectionType = CameraProjectionType.PerspectiveFOV ;
    public CameraType CameraType = CameraType.LookAt ;
    public float fov =0.45f; 
    public float aspectRatio =0.35f; 
    public float near =0.01f; 
    public float far = 100.0f;
}


public enum CameraProjectionType
{
    Ortho,
    Ortho2D,
    OrthoParallel,
    Perspective,
    PerspectiveFOV,
    InfinitePerspective,
}

public enum CameraType
{
    None,
    LookAt,
    FirstPerson,
    Fly,
    ThirdPerson,
    Follow,
    Scrolling,
    RotateAround,
    Orbital,
    arcball
}

[SkipLocalsInit]
[ StructLayout(LayoutKind.Sequential)]
public unsafe struct Camera() 
{
    private CameraData _data = new();
    

    public void AddCamera(Vector3 position,Vector3 target, Vector3 up  )
    {
        _data.Position = position;
        _data.Up = up;
        _data.Target = target;    
        _data.Type = CameraType.None;   
        CameraImplement.AddCamera(ref _data);
    }
    public void AddProjection(CameraProjectionType projectionType,float fov, float aspectRatio , float near , float far )
    {
        _data.ProjectionType = projectionType;
        _data.AspectRatio = aspectRatio;
        _data.ZNear = near;
        _data.ZFar = far ; 
        _data.FieldOfViewInDegree = fov;
        CameraImplement. UpdateProjection(ref _data);
    }

    /// <summary>
    /// Regarder autour généralement a la souris ne bouge pas inclinaison de la caméra vers haut/bas ou gaauche droite
    /// </summary>
    /// <param name="xpos"></param>
    /// <param name="ypos"></param>
    /// <param name="sensitivity"></param>
    public void LookAround(float xpos, float ypos , float sensitivity = 0.1f)=> CameraImplement.LookAround(ref _data, xpos,ypos, sensitivity);

    /// <summary>
    /// Poor Zoom juste change Field of View
    /// </summary>
    /// <param name="advance"></param>
    public void Zoom( float advance )
    {
        _data.FieldOfViewInDegree += advance;
        _data.FieldOfViewInDegree =  Math.Clamp( _data.FieldOfViewInDegree,0.01f,89.99f)  ;
        CameraImplement.UpdateProjection(ref _data );
    }
    
    /// <summary>
    /// // y movement UP DOWN ( for jump )
    /// </summary>
    /// <param name="distance"></param>
    public void Ascend(float distance) => CameraImplement.Ascend(ref _data , distance);   

    /// <summary>
    ///z movement FORWARD => positif distance BACKWARD => negatif distance
    /// </summary>
    /// <param name="distance"></param>
    public void Advance(float distance)=> CameraImplement.Advance(ref _data , distance);

    /// <summary>
    /// // x movement  LEFT => negatif RIGHT => positif attention ici c'est la caméra qui ce déplace 
    /// </summary>
    /// <param name="distance speed">deltaTime * MoveSpeed</param>
    public void Strafe(float distance) => CameraImplement.Strafe(ref _data , distance);

    /// <summary>
    /// Rotate around Y axis with angle in radians
    /// </summary>
    /// <param name="angle">angle in radians</param>
    public void Yaw(float angle) => CameraImplement.Yaw(ref _data, angle);

    /// <summary>
    /// Rotate around X axis
    /// </summary>
    /// <param name="angle">in radians</param>
    public void Pitch(float angle)=> CameraImplement.Pitch(ref _data, angle);
    
    /// <summary>
    /// Rotate around  Z Axis
    /// </summary>
    /// <param name="angle">angle in radians</param>
    public void Roll( float angle) => CameraImplement.Roll(ref _data, angle);

    public void Update(float deltaTime) => CameraImplement.Update(ref _data);

    /// <summary>
    /// Déplace la position de la caméra 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="z"></param>
    public void TranslateLookAt(float x,float y,float z)
        => CameraImplement.TranslateLookAt(ref _data , x,y,z);

    /// <summary>
    /// Déplace la position de la caméra 
    /// </summary>
    /// <param name="angle_x">en degre</param>
    /// <param name="angle_y">en degre</param>
    /// <param name="angle_z">en degre</param>
    public void RotateLookAt(float angle_x,float angle_y,float angle_z)
        => CameraImplement.RotateLookAt( ref _data, angle_x,angle_y,angle_z);

    /// <summary>
    /// make sure the user stays at the ground level
    /// POur les FPS  la caméra reste au niveau du sol 
    /// execute befor update
    /// </summary>
    /// <param name="groundposition">0.0f by default </param>
    public void StayAtGroundXZPlane( float groundposition=0.0f)
    {
       _data.Position.Y = groundposition  ; // <-- this one-liner keeps the user at the ground level (xz plane)
    }

    public void MoveAroundTarget( Vector3 target , float angleX , float angleY)
        => CameraImplement.MoveAroundTarget( ref _data ,target, angleX , angleY );

    public float[] ToArray => _data.ToArray();

    public void Release()
    {
        _data.Dispose();
    }

}

[SkipLocalsInit]
[SuppressUnmanagedCodeSecurity]
[ StructLayout(LayoutKind.Sequential)]
public static class CameraImplement
{

    public static void  AddCamera(ref CameraData data)
    {
        //ONly for find Yaw pitch roll
        var zAxis = Transform.Normalize(data.Position - data.Target);
        var xAxis = Transform.Normalize(Transform.Cross(ref data.Up,ref zAxis));
        var yAxis = Transform.Cross( ref zAxis, ref xAxis);

        Matrix4 rotation = new (
            xAxis.X , yAxis.X , zAxis.X ,0.0f  ,
            xAxis.Y , yAxis.Y , zAxis.Y ,0.0f  ,
            xAxis.Z , yAxis.Z , zAxis.Z ,0.0f  ,
            0.0f  , 0.0f ,  0.0f ,1.0f    );
        
        float rmYaw =   Math.IntoDegree( Math.ATan2(rotation.M13, rotation.M33) ) - (float)180.0f ;// Y
        float rmPitch =  Math.IntoDegree( Math.ACos(-rotation.M23 * data.FlipY)) -90 ; // X
        float rmRoll =  Math.IntoDegree( Math.ATan2(rotation.M21,rotation.M22)) ; // Z

        data.Rotation = new( rmPitch,rmYaw, rmRoll);

        Matrix4 translation = Matrix4.Identity;
        translation.M41 = -data.Position.X ;
        translation.M42 = -data.Position.Y; 
        translation.M43 = -data.Position.Z;

        data.View =  translation * rotation;
        data.Position = data.View.Translation;
    }

    public static void UpdateProjection(ref CameraData data )
    {
        data.Projection = data.ProjectionType switch{
            CameraProjectionType.PerspectiveFOV => Transform.CreatePerspectiveFieldOfView(Math.IntoRadian( data.FieldOfViewInDegree) ,data.AspectRatio, data.ZNear,data.ZFar),
            _ => Transform.CreatePerspectiveFieldOfView(Math.IntoRadian( data.FieldOfViewInDegree) ,data.AspectRatio, data.ZNear,data.ZFar)
        };

        data.Projection.M22 *= data.FlipY;
    }
    public static void MoveAroundTarget(ref CameraData data, Vector3 target , float leftRight , float upDown)
    {
        data.Target =  target;  /*data.Position - (data.Position + data.CamFront)*/;       
        data.Rotation.Y += leftRight ;
        data.Rotation.X += upDown ;
        data.Type = CameraType.RotateAround ;
    }

    public static void Update(ref CameraData data)
    {
        if ( data.Type == CameraType.None) return ;

        if ( data.Type == CameraType.FirstPerson)
        {
              // FOr yaw and pitch 
            Vector3 CamFront = default;
            CamFront.X = -Math.Cos( data.Rotation.X.ToRadian() ) * Math.Sin(data.Rotation.Y.ToRadian() ) ;
            CamFront.Y =  Math.Sin( data.Rotation.X.ToRadian() );
            CamFront.Z =  Math.Cos( data.Rotation.X.ToRadian() ) * Math.Cos(data.Rotation.Y.ToRadian());
            CamFront = Transform.Normalize(CamFront);
            // for ROLL
            Vector3 CamRight = Transform.Normalize(  ( Transform.Cross( ref CamFront,ref data.Up )   )  ) ;
           
            Vector3 CamUp = Transform.Normalize(  Transform.Cross( ref CamRight, ref CamFront));

            data.Position += (CamFront * data.Velocity.Z) + (CamUp * data.Velocity.Y) + (CamRight * data.Velocity.X);
        }

        // FOR UPDATE MATRIX VIEW
        // Matrix rotM = Matrix.Identity;
         Matrix4 rotM =  Transform.RotationY( Math.IntoRadian(data.Rotation.Y) )
            * Transform.RotationX(Math.IntoRadian(data.Rotation.X* data.FlipY)) 
            * Transform.RotationZ(Math.IntoRadian(data.Rotation.Z)) ;

        Vector3 translation = data.Type == CameraType.RotateAround 
            ? Transform.Normalize(data.View.Translation - data.Target) *  Transform.Distance( ref data.Position , ref data.Target)
            : data.Position ;
        
        Matrix4  transM = Transform.Translation(translation );
        transM.M42 =  data.Type == CameraType.LookAt ?  (transM.M42 * data.FlipY) : transM.M42  ;
        
        data.View  =  data.Type == CameraType.LookAt ? transM * rotM : rotM * transM   ;

        data.Type = CameraType.None;
    }

    public static void SetViewYXZ(ref CameraData data)
    {
        // FOR UPDATE MATRIX VIEW
        Matrix4 rotM = Matrix4.Identity;

        float c3 = Math.Cos(data.Rotation.Z);
        float s3 = Math.Sin(data.Rotation.Z);
        float c2 = Math.Cos(data.Rotation.X);
        float s2 = Math.Sin(data.Rotation.X);
        float c1 = Math.Cos(data.Rotation.Y);
        float s1 = Math.Sin(data.Rotation.Y);
        Vector3 u = new((c1 * c3 + s1 * s2 * s3), (c2 * s3), (c1 * s2 * s3 - c3 * s1));
        Vector3 v = new((c3 * s1 * s2 - c1 * s3), (c2 * c3), (c1 * c3 * s2 + s1 * s3));
        Vector3 w = new((c2 * s1), (-s2), (c1 * c2));
        // Matrix rotM  = new()
        rotM.M11 = u.X; rotM.M12 = v.X ;rotM.M13 = w.X ;
        rotM.M21 = u.Y; rotM.M22 = v.Y ;rotM.M23 = w.Y ;
        rotM.M31 = u.Z; rotM.M32 = v.Z ;rotM.M33 = w.Z ;

           // var cosBeta = (float)Helper.Cos(Helper.ToRadians(data.Rotation.Y));//pitch 
        // var sinBeta = (float)Helper.Sin(Helper.ToRadians(data.Rotation.Y));
        
        // var cosSigma = (float)Helper.Cos(Helper.ToRadians(data.Rotation.X* data.FlipY)); //roll
        // var sinSigma = (float)Helper.Sin(Helper.ToRadians(data.Rotation.X* data.FlipY));

        // var cosAlpha = (float)Helper.Cos(Helper.ToRadians(data.Rotation.Z)); // Yaw
        // var sinAlpha = (float)Helper.Sin(Helper.ToRadians(data.Rotation.Z));
        // var    rotM = Matrix.Identity;
        
        // rotM.M11 =  cosSigma *cosBeta;
        // rotM.M12 = (sinAlpha *sinBeta * cosSigma)  - (cosAlpha * sinSigma);
        // rotM.M13 = (cosAlpha *sinBeta * cosSigma)  + (sinAlpha * sinSigma);
        // rotM.M21 = sinSigma *cosBeta;
        // rotM.M22 =(sinAlpha *sinBeta * sinSigma)  + (cosAlpha * cosSigma);
        // rotM.M23 = (cosAlpha *sinBeta * cosSigma)  - (sinAlpha * cosSigma);
        // rotM.M31 = -sinBeta;
        // rotM.M32 = sinAlpha * cosBeta;
        // rotM.M33 = cosBeta * cosAlpha;

        // if( rotM.M11 == float.NaN || rotM.M12 == float.NaN || rotM.M13 == float.NaN 
        // || rotM.M21 == float.NaN|| rotM.M22 == float.NaN|| rotM.M23 == float.NaN
        // || rotM.M31 == float.NaN|| rotM.M32 == float.NaN|| rotM.M33 == float.NaN)
        //     Log.Warning("Error Gimbal Lock");
    }

    public static void Strafe(ref CameraData data,float distance)
    {
        data.Velocity.X  = distance;data.Velocity.Y = 0.0f; data.Velocity.Z = 0.0f;
        data.Type = CameraType.FirstPerson;
    }
        
    public static void Ascend(ref CameraData data,float distance)
    {
        data.Velocity.X  =0.0f;data.Velocity.Y =distance; data.Velocity.Z = 0.0f;
        data.Type = CameraType.FirstPerson;
    }
       
    public static void Advance(ref CameraData data,float distance)
    {
        data.Velocity.X  =0.0f;data.Velocity.Y =0.0f; data.Velocity.Z = distance;
        data.Type = CameraType.FirstPerson;
    }
    
    public static void Yaw(ref CameraData data,float angle)
    {
        data.Rotation.Y += angle ; //Helper.Clamp( angle , 0.0f,360.0f) ;
        data.Type = CameraType.FirstPerson;
    }

    public static void Roll(ref CameraData data, float angle)
    {
        data.Rotation.Z += angle ;// Helper.Clamp( angle , -90.0f,+90.0f) ;
        data.Type = CameraType.FirstPerson;
    }

    public static void Pitch(ref CameraData data,float angle)
    {
        data.Rotation.X += angle ;// Helper.Clamp( angle , -90.0f,+90.0f) ;
        data.Type = CameraType.FirstPerson;
    }

    public static void TranslateLookAt(ref CameraData data,float x,float y,float z)
    {
        data.Type = CameraType.LookAt;
        data.Position.X += x;data.Position.Y += y;data.Position.Z += z;
    }

    public static void  RotateLookAt(ref CameraData data, float angle_x,float angle_y,float angle_z)
    {
        data.Type = CameraType.LookAt;
        data.Rotation.X += angle_x;data.Rotation.Y += angle_y;data.Rotation.Z += angle_z;
    }

    static float _lastX = float.NaN ;
    static float _lastY = float.NaN ;
    static bool _firsttime = true;
    
    public static void LookAround(ref CameraData data,float xpos, float ypos , float sensitivity = 0.01f)
    {
        if ( _firsttime ) // TODO : replace xpos par MousseDeltaX
        {
            _lastX =   xpos ;
            _lastY =   ypos;
            _firsttime = false;
        }
        
        float xoffset = xpos - _lastX;
        float yoffset = _lastY - ypos; // reversed since y-coordinates go from bottom to top
        _lastX = xpos;
        _lastY = ypos;

        data.Rotation.Y +=  xoffset * sensitivity;
        data.Rotation.X += yoffset * sensitivity; 
        data.Type = CameraType.LookAt;
    }
    
    /// <summary>
    /// Center a camera to target object and backward of distance
    /// </summary>
    /// <param name="data"></param>
    /// <param name="target"></param>
    /// <param name="radius"> delta time  * smooth </param>
    public static void CenterCameraToObject(ref CameraData data, ref Vector3 target, float radius=0.0f)
    {
        radius = radius==0.0f ?  Transform.Distance(ref data.Position, ref target): radius;
        // data.Position = target - (radius * data.CamFront );
        // data.Position = Vector3.Lerp (  data.Position, target,radius);
    }

    public static void Follow( ref CameraData data, ref Vector3 target, float radius=0.0f)
    {
        /// https://stackoverflow.com/questions/10752435/how-do-i-make-a-camera-follow-an-object-in-unity3d-c
        /// // The target we are following
        // public  Transform target;
        // // The distance in the x-z plane to the target
        // public int distance = 10.0;
        // // the height we want the camera to be above the target
        // public int height = 10.0;
        // // How much we 
        // public heightDamping = 2.0;
        // public rotationDamping = 0.6;

        // void  LateUpdate (){
        // // Early out if we don't have a target
        // if (TargetScript.russ == true){
        // if (!target)
        //     return;

        // // Calculate the current rotation angles
        // wantedRotationAngle = target.eulerAngles.y;
        // wantedHeight = target.position.y + height;

        // currentRotationAngle = transform.eulerAngles.y;
        // currentHeight = transform.position.y;

        // // Damp the rotation around the y-axis
        // currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        // // Damp the height
        // currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        // // Convert the angle into a rotation
        // currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);

        // // Set the position of the camera on the x-z plane to:
        // // distance meters behind the target
        // transform.position = target.position;
        // transform.position -= currentRotation * Vector3.forward * distance;

        // // Set the height of the camera
        // transform.position.y = currentHeight;

        // // Always look at the target
        // transform.LookAt (target);
    }

}

[SkipLocalsInit]
[ StructLayout(LayoutKind.Sequential)]
public struct CameraData
{
    public Matrix4 World = Matrix4.Identity;
    public Matrix4 View=Matrix4.Identity;
    public Matrix4 Projection=Matrix4.Identity;
    public Vector3 Position =new(0.0f,-0.12f,-2.0f);
    public Vector3 Rotation = new(0.0f,00.0f, 00.0f);
    public Vector3 Target =new(0.00f,0.00f,0.00f);
    public Vector3 Velocity = new();
    public Vector3 Up =new(0.0f,1.0f,0.0f);
    public float FieldOfViewInDegree = 45.0f;
    public float AspectRatio =16.9f;
    public float ZNear =0.1f;
    public float ZFar = 100.0f;
    public float FlipY = -1.0f;
    public CameraType Type = CameraType.None;
    public CameraProjectionType ProjectionType = CameraProjectionType.PerspectiveFOV;
    
    public CameraData() { }
    public float[] ToArray()
    {
        float[] result = {
        World[0],World[1],World[2],World[3],World[4],World[5],World[6],World[7],World[8],World[9],World[10],World[11],World[12],World[13],World[14],World[15],
        View[0],View[1],View[2],View[3],View[4],View[5],View[6],View[7],View[8],View[9],View[10],View[11],View[12],View[13],View[14],View[15],
        Projection[0],Projection[1],Projection[2],Projection[3],Projection[4],Projection[5],Projection[6],Projection[7],Projection[8],Projection[9],Projection[10],Projection[11],Projection[12],Projection[13],Projection[14],Projection[15],
        };
        return result;
    }

    public void Dispose()
    { 

    }

}
