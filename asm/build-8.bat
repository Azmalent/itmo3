C:\masm32\bin\ml /c /Zd /coff 8.asm
C:\masm32\bin\Link /SUBSYSTEM:WINDOWS 8.obj
if exist 8.obj del 8.obj
pause