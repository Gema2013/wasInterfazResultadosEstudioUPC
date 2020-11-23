Imports System.Data.SqlClient
Imports System.Text

Public Class Conexiones

    Public Shared Property ID As String
    Public Shared Property Pwd As String
    Public Shared Property Catalog As String
    Public Shared Property Source As String
    Public Shared Property App As String


    Public Sub New()
        MyBase.New()
    End Sub

    Public Shared Function Conexion() As SqlClient.SqlConnection
        Dim conecta As New StringBuilder("Data Source={2};Initial Catalog={3};Integrated Security=False;User ID={0};Pwd={1};App={4}")

        conecta.Replace("{0}", ID)
        conecta.Replace("{1}", Pwd)
        conecta.Replace("{2}", Source)
        conecta.Replace("{3}", Catalog)
        conecta.Replace("{4}", App)

        Dim sqlconConexion As New SqlConnection(conecta.ToString)
        Return sqlconConexion
    End Function


    Public Shared Function EjecutaSql(ByVal strQry) As DataTable
        Dim myConexion As SqlConnection
        myConexion = Conexion()
        myConexion.Open()

        Dim myTransaction As SqlTransaction
        myTransaction = myConexion.BeginTransaction(IsolationLevel.ReadUncommitted)


        Return EjecutaSQL(strQry, myConexion, myTransaction)
    End Function

    Public Shared Function EjecutaSQL(ByVal strQry As String, ByRef myConexion As SqlConnection, ByRef myTransaction As SqlTransaction) As DataTable
        Dim dtRespuesta As New DataTable
        Dim sqlDataAdapterConsulta As New SqlDataAdapter
        Dim sqlCommandConsulta As New SqlClient.SqlCommand(strQry, myConexion, myTransaction)
        sqlDataAdapterConsulta.SelectCommand = sqlCommandConsulta
        sqlDataAdapterConsulta.Fill(dtRespuesta)

        Return dtRespuesta
    End Function

    Public Shared Function EjecutaTSQL(ByVal strQry As String, ByRef myConexion As SqlConnection, ByRef myTransaction As SqlTransaction) As Integer
        Dim cmd As New SqlCommand(strQry, myConexion, myTransaction)
        Return cmd.ExecuteNonQuery()
    End Function

End Class
