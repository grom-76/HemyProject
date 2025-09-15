# HEMY CLI 

useful command line interface , simplify for dotnet
how to build your project for multi target 

## Comment l'installer 

Pour creer une ligne de command 

dans le ficheir csproj il faut jaouter les lignes suivantes dans la section "PropertyGroup":
~~~~
    <PackAsTool>true</PackAsTool>
    <ToolCommandName>hemy</ToolCommandName>
    <PackageOutputPath>./nupkg</PackageOutputPath>
~~~~
- pour compiler :
    dotnet pack 
- pour installer
    dotnet tool install --global --add-source ./nupkg MCJ
- pour supprimer 
    dotnet tool uninstall hemy --global

## Comment l'utiliser

