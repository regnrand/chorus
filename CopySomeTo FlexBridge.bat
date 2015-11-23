echo off
IF "%1"=="" (
	set BUILD_CONFIG="Debug"
) ELSE (
	set BUILD_CONFIG=%1
)

set flexBridgeDir=..\flexbridge

echo on
echo Copying some %BUILD_CONFIG% files to FLEx Bridge

copy /Y output\%BUILD_CONFIG%\Autofac.dll %flexBridgeDir%\lib\%BUILD_CONFIG%

copy /Y output\%BUILD_CONFIG%\Chorus.exe %flexBridgeDir%\lib\%BUILD_CONFIG%
copy /Y output\%BUILD_CONFIG%\Chorus.pdb %flexBridgeDir%\lib\%BUILD_CONFIG%

copy /Y output\%BUILD_CONFIG%\ChorusMerge.exe %flexBridgeDir%\lib\%BUILD_CONFIG%
copy /Y output\%BUILD_CONFIG%\ChorusMerge.pdb %flexBridgeDir%\lib\%BUILD_CONFIG%

copy /Y output\%BUILD_CONFIG%\LibChorus.dll %flexBridgeDir%\lib\%BUILD_CONFIG%
copy /Y output\%BUILD_CONFIG%\LibChorus.pdb %flexBridgeDir%\lib\%BUILD_CONFIG%

pause