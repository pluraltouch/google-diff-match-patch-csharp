dotnet pack ../../DiffMatchPatch.sln --output d:\nuget --configuration Debug -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg
for /D %%x in ("%userprofile%\.nuget\packages\DiffMatchPatch*") do (rmdir %%x /s /q)
