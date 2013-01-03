$serviceDir = (join-path $env:ProgramFiles "Truecrypt.Service") 
$serviceFileName = "TrueCrypt.Service.exe"
$destinationFile = (join-path $serviceDir $serviceFileName) 

# echo $serviceDir 
# echo $serviceFileName 
# echo $destinationFile 

installutil -u  $destinationFile