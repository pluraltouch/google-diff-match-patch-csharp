if not exist "C:\Microsoft\" mkdir C:\Microsoft
if not exist "C:\Microsoft\Xamarin\" mkdir C:\Microsoft\Xamarin
if not exist "C:\Microsoft\Xamarin\NuGet\" mkdir C:\Microsoft\Xamarin\NuGet

..\nuget\nuget.exe restore ..\..\DiffMatchPatch.sln

