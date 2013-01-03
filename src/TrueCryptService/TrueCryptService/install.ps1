$currentDir = Split-Path $MyInvocation.MyCommand.Definition -Parent
$serviceDir = (join-path $env:ProgramFiles "TrueCrypt.Service") 
$serviceFileName = "TrueCrypt.Service.exe"
$originFile = (join-path $currentDir $serviceFileName) 
$destinationFile = (join-path $serviceDir $serviceFileName) 
$uninstallFileName = "uninstall.ps1"
$uninstallOriginFile = (join-path $currentDir $uninstallFileName) 
$uninstallDestinationFile = (join-path $serviceDir $uninstallFileName) 

# echo $currentDir 
# echo $serviceDir 
# echo $serviceFileName 
# echo $originFile 
# echo $destinationFile 

mkdir $serviceDir
copy -Force $originFile $destinationFile 
copy -Force $uninstallOriginFile $uninstallDestinationFile 
installutil  $destinationFile