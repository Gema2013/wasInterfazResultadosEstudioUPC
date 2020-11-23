Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim strRespuestas As String = ConsultaResultados(txtCodigoUPC.Text, txtPsw.Text, txtPacienteID.Text)
        ' MessageBox.Show(strRespuestas)
        txtRespuesta.Text = strRespuestas
    End Sub

    Public Function ConsultaResultados(ByVal ClaveUPC As Integer, ByVal psw As String, ByVal NoOrden As Integer) As String
        Dim ConsumoServicio As New waConexionInterfaz.ISucursalservice
        Dim DatosSalida As String
        DatosSalida = ConsumoServicio.fncSoliResuEmpr(ClaveUPC, psw, NoOrden)


        Return DatosSalida
    End Function
End Class