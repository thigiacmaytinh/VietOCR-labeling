rmdir release /Q /S

mkdir release
mkdir release\VietOCRLabeling
xcopy bin\* release\VietOCRLabeling /E

cd release\VietOCRLabeling
rmdir images /Q /S
rmdir output /Q /S
del *.pdb /F /Q
del *.ilk /F /Q
del *.iobj /F /Q
del *.ipdb /F /Q
del *.lib /F /Q
del *.exp /F /Q
del *.key /F /Q
del *.config /F /Q
del *.metagen /F /Q
del *.bat /F /Q
del *.txt /F /Q
del *.manifest /F /Q
del *.vshost.exe /F /Q
del System.Windows.Forms.Ribbon.xml /F /Q

cd ..
del VietOCRLabeling.zip /F /Q


"C:\Program Files\7-Zip\7z.exe" a VietOCRLabeling.zip VietOCRLabeling\

pause