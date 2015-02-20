new-item -path C:\source -itemtype Directory
$storageDir = "C:\source"
$webclient = New-Object System.Net.WebClient
$url = "http://go.microsoft.com/fwlink/?LinkId=255386"
$file = "$storageDir\WebPiInstaller.exe"
$webclient.DownloadFile($url,$file)
Start-process -filepath C:\source\WebPiInstaller.exe