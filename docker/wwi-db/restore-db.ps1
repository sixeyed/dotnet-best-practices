echo 'Starting SQL Server'
Start-Service MSSQL`$SQLEXPRESS

$restoreCmd = "RESTORE DATABASE WideWorldImporters FROM DISK=N'c:\WideWorldImporters.bak'
WITH MOVE 'WWI_Primary' TO 'C:\data\WWI_Primary.mdf',
MOVE 'WWI_UserData' TO 'C:\data\WWI_UserData.ndf',
MOVE 'WWI_Log' TO 'C:\logs\WideWorldImporters.ldf',
RECOVERY, RESTRICTED_USER;"

echo 'Restoring database'
md /logs
md /data
Invoke-SqlCmd -ServerInstance '.\SQLEXPRESS' -Query $restoreCmd -Verbose

echo 'Done'