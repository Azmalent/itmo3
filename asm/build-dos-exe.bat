@echo off

if exist %1.obj del %1.obj
if exist %1.exe del %1.exe

\masm32\bin\ml /c %1.asm
if errorlevel 1 goto errasm

\masm32\bin\Link16 %1.obj
if errorlevel 1 goto errlink

del %1.obj

goto TheEnd

:errlink
echo _
echo Link error
goto TheEnd

:errasm
echo _
echo Assembly Error
goto TheEnd

:TheEnd
pause
