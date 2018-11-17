@echo off
REM ***************************************************************************************************************
REM * MAKE_SETUP_ORIONBANQUE                                                                                      *
REM * Creation de l'installeur pour OrionBanque                                                                   *
REM * VERSION 0.01                                                                                                *
REM * 20181106 0.01 GG : Premiere Version                                                                         *
REM * Dependances : NSIS 3.03                                                                                     *
REM * En argument : Version (a.b.c.d, par exemple : 1.0.1.7)                                                      *
REM * ORION_DIRECTORY : Repertoire contenant les ressources OrionBanque qui doivent �tre int�gr�es                *
REM * NSIS_DIRECTORY : Repertoire dans lequel est install� NSIS                                                   *
REM * SETUP_BMP : Fichier image utilis� pour enrichir la proc�dure d'installation (ici ressource NSIS par defaut) *
REM * ICO_UNINSTALL : Fichier ic�ne de d�sinstallation (ici ressource NSIS par defaut)                            *
REM * ORION_ICONE : Ic�ne de l'application, ici la touche de clavier.                                             *
REM ***************************************************************************************************************


set release=%1
if %release%a==a goto usage

REM *******************************************************************************
REM * r�pertoire dans lequel les ressources OrionBanque � packager sont pr�sentes *
REM *******************************************************************************

set orion_directory=C:\\projet\\VS\\Publish\\orionbanque\\publish

REM *******************************************************************************
REM * r�pertoire dans lequel est install� NSIS                                    *
REM *******************************************************************************

set nsis_directory=C:\\projet\\VS\\orionbanque\\Make_Setup_OrionBanque\\nsis

REM *******************************************************************************
REM * r�pertoire dans lequel l'image utilis�e pour l'installeur est install�e     *
REM *******************************************************************************

set setup_bmp=%nsis_directory%\\Contrib\\Graphics\\Wizard\\orange.bmp

REM *******************************************************************************
REM * r�pertoire dans lequel l'icone de d�sinstallation est pr�sente              *
REM *******************************************************************************

set ico_uninstall=%nsis_directory%\\Contrib\\Graphics\\icons\\orange-uninstall.ico

REM *******************************************************************************
REM * r�pertoire dans lequel l'icone de OrionBanque est pr�sente                  *
REM *******************************************************************************

set orion_icone=%orion_directory%\\_.ico

echo Make_Setup_OrionBanque 0.1 Gaetan
if %orion_directory%a==a echo la variable d'environnement orion_directory n'est pas d�finie && goto fin
if %nsis_directory%a==a echo la variable d'environnement nsis_directory n'est pas d�finie && goto fin
if %setup_bmp%a==a echo la variable d'environnement setup_bmp n'est pas d�finie && goto fin
if %ico_uninstall%a==a echo la variable d'environnement ico_uninstall n'est pas d�finie && goto fin
if %orion_icone%a==a echo la variable d'environnement orion_icone n'est pas d�finie && goto fin

echo o|del tmp\*.nsi
bin\sed "s/orion_version/%release%/g" nsi\OrionBanque.nsi > tmp\tmp1.nsi
bin\sed "s/orion_directory/%orion_directory%/g" tmp\tmp1.nsi > tmp\tmp2.nsi
bin\sed "s/setup_bmp/%setup_bmp%/g" tmp\tmp2.nsi > tmp\tmp3.nsi
bin\sed "s/ico_uninstall/%ico_uninstall%/g" tmp\tmp3.nsi > tmp\tmp4.nsi
bin\sed "s/orion_icone/%orion_icone%/g" tmp\tmp4.nsi > tmp\tmp5.nsi
nsis\makensis /p5 tmp\tmp5.nsi
echo.
echo Si tout s'est bien passe, binaire genere dans le repertoire out : 
echo.
dir out
goto fin
:usage
echo specifier la version : make_setup_OrionBanque.bat 2.3.4.5
:fin