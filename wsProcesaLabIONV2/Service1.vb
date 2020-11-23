Imports System.Threading
Imports System.Data.SqlClient
Public Class Service1
#Region "Propiedades"

    Const StrNombreAplicacion As String = "LaboratorioION"

    Dim elogLogEventos As New EventLog

    Private Property TrdProcesaActualizacion As Thread


#End Region

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
        IniciarServicio()
    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
    End Sub

#Region "Métodos"

    Private Sub IniciarServicio()

        Try
            If (Not EventLog.SourceExists(StrNombreAplicacion)) Then
                EventLog.CreateEventSource(StrNombreAplicacion, StrNombreAplicacion)
            End If
            elogLogEventos.Source = StrNombreAplicacion
            elogLogEventos.WriteEntry("Inicio del servicio ""Procesamiento órdenes de laboratorio-ION"" V1.", EventLogEntryType.Information)


            TrdProcesaActualizacion = New Thread(AddressOf ProcesarOrdenes)
            TrdProcesaActualizacion.IsBackground = True
            TrdProcesaActualizacion.Start()

            elogLogEventos.WriteEntry("Servicio iniciado correctamente", EventLogEntryType.Information)

            'Para escribir en el registro de Aplicación de windows.
            EventLog.WriteEntry("Se inicia servicio de procesamiento Laboratorio-ION", EventLogEntryType.FailureAudit)

        Catch exExcepcion As Exception
            EventLog.WriteEntry("No puedo iniciarse el servicio, " & exExcepcion.ToString, EventLogEntryType.FailureAudit)
            EventLog.WriteEntry("Cierre inesperado", EventLogEntryType.FailureAudit)
            Me.Stop()
        End Try

    End Sub

    Private Sub ProcesarOrdenes()
        While True
            ProcesaActualizaOrdenessPendiente()
            'Thread.Sleep(60000) '10 min pruebas
            Thread.Sleep(30000) '5 min 
            'Thread.Sleep(6000) ' 1 min
        End While
    End Sub

    Private Sub ProcesaActualizaOrdenessPendiente()
        'Base en SION
        'Ambiente de pruebas
        Conexiones.Catalog = "BDSION"
        Conexiones.ID = "sa"
        Conexiones.Pwd = "s4_password"
        Conexiones.Source = "70.35.194.173"

        'Ambiente producción
        'Conexiones.Catalog = "BDSIONProduccion"



        Dim blnExito As Boolean = False
        Try
            'Las nuevas claves de farmacia (Procesado=0) con sus precios se deben guardar en la base ion CALL usp_catalogo_obtenerProductosNuevos();
            'y actualizar estatus de Procesado=1
            elogLogEventos.WriteEntry("Iniciado procesamiento de órdenes pendiente de laboratorio", EventLogEntryType.Information)
            Procesar()


            elogLogEventos.WriteEntry("Procesos del servicio terminados, revise histórico ServicioLaboratorioION para resultados: " & Now.ToString, EventLogEntryType.Information)

        Catch ex As Exception
            elogLogEventos.WriteEntry("Error: " & ex.ToString, EventLogEntryType.Error)
        End Try

    End Sub

    Private Sub Procesar()
        'Obtiene órdenes de laboratorio pendientes.
        Dim MiConexion As SqlConnection = Nothing
        Dim tran As SqlTransaction = Nothing
        Dim dtOrdenesNoProcesadas As New DataTable
        Dim strordenesProcesadas As String = ""
        Try
            MiConexion = Conexiones.Conexion
            MiConexion.Open()
            tran = MiConexion.BeginTransaction(IsolationLevel.ReadUncommitted)

            'Obtener ódenes pendientes de procesar
            Dim spObtienePendientes As New SP_BBDD.ObtieneOrdenLabPendiente_select
            spObtienePendientes.ObtieneOrdenLabPendiente_select(MiConexion, tran, dtOrdenesNoProcesadas)

            'Si hay órdenes, iniciar ciclo
            If dtOrdenesNoProcesadas.Rows.Count > 0 Then

                'Dim spInserta As New SP_BBDD.TARL_ResultadoLaboratorioInterfaz_insert
                'Dim spActualizaStatus As New SP_BBDD.ActualizaOrdenLabPendiente_update
                'Dim i As Integer = 0
                'Dim strResultadoXmlClaves As String = ""
                'Dim ConsumoServicio As New waConexionInterfaz.ISucursalservice

                'For Each row In dtOrdenesNoProcesadas.Rows
                '    'Limpia variables
                '    strResultadoXmlClaves = ""

                '    'Descargar xml correspondiente a la órden
                '    strResultadoXmlClaves = ConsumoServicio.fncSoliResuEmpr(3599, "ION", row!fi_TAOL_OrdenLaboratorio_NoOrden)

                '    'Guardar xml correspondiente
                '    spInserta.TARL_ResultadoLaboratorioInterfaz_insert(MiConexion, tran, Nothing, row!fi_TAOL_OrdenLaboratorio_NoOrden, strResultadoXmlClaves)
                '    'Se llena string que permita conocer las órdenes procesadas
                '    strordenesProcesadas = strordenesProcesadas & "," & row!fi_TAOL_OrdenLaboratorio_NoOrden

                '    'Actualizar status de órden procesada
                '    spActualizaStatus.ActualizaOrdenLabPendiente_update(MiConexion, tran, Nothing, row!fi_TAOL_OrdenLaboratorio_NoOrden)

                '    'Se incrementa variable de ciclo para procesar 50 órdenes.
                '    i = i + 1
                '    If i = 50 Then
                '        Exit For
                '    End If
                'Next

            End If


            tran.Commit()
            elogLogEventos.WriteEntry("Se procesaron las órdenes " & strordenesProcesadas)
        Catch ex As Exception
            If tran IsNot Nothing Then
                tran.Rollback()
            End If
            elogLogEventos.WriteEntry("Error procesando órdenes pendientes. Error: " & strordenesProcesadas & ex.ToString, EventLogEntryType.Error)
            Throw ex
        Finally
            If MiConexion IsNot Nothing Then
                MiConexion.Close()
                MiConexion.Dispose()
            End If
        End Try
    End Sub

#End Region


End Class

