namespace Hemy.Sample;


public class Program
{
    public static void Main()
    {
        // // Déclaration du thread

        // // Instanciation du thread, on spécifie dans le 
        // // délégué ThreadStart le nom de la méthode qui sera exécutée lorsque l'on appelle la méthode Start() de notre thread.
        // Thread myThread = new(new ThreadStart(Root))
        // {
        //     Priority = ThreadPriority.Lowest
        // };
        // // // Lancement du thread
        // myThread.UnsafeStart();


    }

    public static void TestLog()
    {

        Hemy.Lib.Core.Log.Info("Bonjour");
    }
}
