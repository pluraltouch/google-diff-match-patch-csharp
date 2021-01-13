@ECHO OFF

:: Deleting packages


CALL :NORMALIZEPATH "..\..\
SET REPOPATH=%RETVAL%


ECHO [101;93m*** The following folder will be cleaned: ***[0m
ECHO %REPOPATH%
ECHO [101;93m*********************************************[0m

CHOICE /C YC /M "Press Y for Yes or C for Cancel."
if NOT %errorlevel% == 1 EXIT /B

taskkill /F /IM VBCSCompiler.exe 

FOR /F "tokens=*" %%G IN ('DIR /B /AD /S "%REPOPATH%bin"') DO RMDIR /S /Q "%%G"
FOR /F "tokens=*" %%G IN ('DIR /B /AD /S "%REPOPATH%obj"') DO RMDIR /S /Q "%%G"
#RMDIR "%REPOPATH%build" /S /Q
#MD "%REPOPATH%build"
#copy /b NUL "%REPOPATH%build\.keep"

pause
  EXIT /B

:NORMALIZEPATH
  SET RETVAL=%~dpfn1
  EXIT /B