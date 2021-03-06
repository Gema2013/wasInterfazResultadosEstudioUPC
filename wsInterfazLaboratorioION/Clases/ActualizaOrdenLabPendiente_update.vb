Imports System.Data
Imports System.Data.SqlClient

Namespace SP_BBDD

    Public Class ActualizaOrdenLabPendiente_update

        Public Sub New()
            MyBase.New()
        End Sub

        Public Overridable Function ActualizaOrdenLabPendiente_update(ByVal connection As System.Data.SqlClient.SqlConnection, ByVal transaccion As System.Data.SqlClient.SqlTransaction, ByVal table As System.Data.DataTable,
                                                        ByVal NoOrden As Long)
            Dim RETURN_VALUE As Integer = 0
            Dim cmd As System.Data.SqlClient.SqlCommand = Nothing
            Dim reader As System.Data.SqlClient.SqlDataReader = Nothing
            If (connection Is Nothing) Then
                Throw New System.ArgumentException("El objeto conection no puede ser null")
            Else
                'Comentario
                If (transaccion Is Nothing) Then
                    If (connection.State = System.Data.ConnectionState.Closed) Then
                        connection.Open()
                        'Abrir Conexion
                    End If
                    cmd = New System.Data.SqlClient.SqlCommand("ActualizaOrdenLabPendiente_update", connection)
                    cmd.CommandType = System.Data.CommandType.StoredProcedure
                Else
                    cmd = New System.Data.SqlClient.SqlCommand("ActualizaOrdenLabPendiente_update", connection, transaccion)
                    cmd.CommandType = System.Data.CommandType.StoredProcedure
                End If
                cmd.Parameters.Add("@RETURN_VALUE", System.Data.SqlDbType.Int, 0)
                cmd.Parameters("@RETURN_VALUE").Direction = System.Data.ParameterDirection.ReturnValue
                cmd.Parameters("@RETURN_VALUE").Value = RETURN_VALUE


                cmd.Parameters.Add("@NoOrden", System.Data.SqlDbType.BigInt)
                cmd.Parameters("@NoOrden").Direction = System.Data.ParameterDirection.Input
                cmd.Parameters("@NoOrden").Value = NoOrden



                If (Not (table) Is Nothing) Then
                    reader = cmd.ExecuteReader
                Else
                    cmd.ExecuteNonQuery()
                End If
                If ((Not (table) Is Nothing) _
                            AndAlso (Not (reader) Is Nothing)) Then
                    table.Clear()
                    table.Columns.Clear()
                    Dim i As Integer = 0
                    Do While (i < reader.FieldCount)
                        Dim __type As System.Type
                        Dim __name As String
                        __type = reader.GetFieldType(i)
                        __name = reader.GetName(i)
                        table.Columns.Add(__name, __type)
                        i = (i + 1)
                    Loop

                    Do While reader.Read
                        Dim row As System.Data.DataRow = table.NewRow
                        Dim rowdata((reader.FieldCount) - 1) As Object
                        reader.GetValues(rowdata)
                        row.ItemArray = rowdata
                        table.Rows.Add(row)

                    Loop
                    reader.Close()
                End If
                If (transaccion Is Nothing) Then
                    connection.Close()
                End If
                RETURN_VALUE = CType(cmd.Parameters("@RETURN_VALUE").Value, Integer)
                Return RETURN_VALUE
            End If
        End Function
    End Class
End Namespace
