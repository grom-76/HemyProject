namespace Hemy.Lib.Core.Sys;

#if WINDOWS
using Hemy.Lib.Core.Platform.Windows.Sys;
#endif

public unsafe static class LibraryLoader
{
    
    private const int FALSE = 0;
    private const int TRUE =  1 ;
    public static bool IsDataDll(void* handle) => ((ulong)(handle) & (ulong)1) == TRUE;
//     #define LDR_IS_DATAFILE(handle)      (((ULONG_PTR)(handle)) &  (ULONG_PTR)1)
    public static bool IsImage( void* handle) => ((ulong)(handle) &  (ulong)1) == TRUE;
// #define LDR_IS_IMAGEMAPPING(handle)  (((ULONG_PTR)(handle)) & (ULONG_PTR)2)
    public static bool IsResource( void* handle) => (IsImage(handle)) || IsDataDll(handle) ;
// #define LDR_IS_RESOURCE(handle)      (LDR_IS_IMAGEMAPPING(handle) || LDR_IS_DATAFILE(handle))
    /// <summary>
    ///  Fournit une API simple pour le chargement d’une bibliothèque native qui encapsule le chargeur du système d’exploitation et utilise des indicateurs par défaut.
    /// </summary>
    /// <param name="libraryName">dll name </param>
    /// <returns></returns>
    public static nint Load(string libraryName)
#if WINDOWS    
     => LibraryLoaderImpl.Load(libraryName);
#endif
    /// <summary>
    ///  Libère une bibliothèque chargée avec le descripteur de système d’exploitation spécifié, ou n’effectue aucune action si le descripteur d’entrée est Zero.
    /// </summary>
    /// <param name="module">Le descripteur de système d’exploitation de la bibliothèque native doit être libéré.</param>
    public static void Unload(nint module)
#if WINDOWS 
    => LibraryLoaderImpl.Unload(module);
#endif
    /// <summary>
    /// Obtient l’adresse d’un symbole exporté. 
    /// </summary>
    /// <param name="module">Descripteur de système d’exploitation de la bibliothèque native.</param>
    /// <param name="symbolName">Nom du symbole exporté.</param>
    /// <returns>Adresse du symbole. MAnaged</returns>
    public static nint GetSymbol(nint module, string symbolName)
#if WINDOWS 
    => LibraryLoaderImpl.GetSymbol(module, symbolName);
#endif

}
