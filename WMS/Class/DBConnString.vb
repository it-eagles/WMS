Option Explicit On
Option Strict On
Public NotInheritable Class DBConnString
    Public Shared tmpServerName As String = "192.168.3.240"
    'Public Shared tmpServerName As String = "E01-NB-024\SQLEXPRESS2008R2"
    Public Shared tmpDBDatabaseName As String = "LKBWarehouse"
    'Public Shared tmpDBUserName As String = "sa"
    'Public Shared tmpDBPassword As String = "7tFCca6pzt"
    Public Shared tmpDBUserName As String = "LKBWarehouse"
    Public Shared tmpDBPassword As String = "7tFCca6pzt"
    'Public Shared tmpServerName As String = "192.168.2.81\mssqlserver1"
    'Public Shared tmpDBDatabaseName As String = "LKBWarehouse-LKB"
    Public Shared strConn As String = "Data Source=" & tmpServerName & ";Initial Catalog=" & tmpDBDatabaseName & ";User ID=" & tmpDBUserName & ";Password=" & tmpDBPassword & ""
    'Public Shared strConnMySql As String = "server=192.168.2.246;database=freight_eagles;user id=root;password=36133HNVek;"
    Public Shared UserName As String = ""
    Public Shared GroupUser As String = ""
    Public Shared Department As String = ""
    Public Shared StatusDelete As String = ""
    Public Shared StatusSA As String = ""
    'Public Shared directory As String = "\\dsname1\WMS-UpdatePath\Report\"
    Public Shared directory As String = "\\192.168.3.240\WMS-UpdatePath\Report\"
End Class