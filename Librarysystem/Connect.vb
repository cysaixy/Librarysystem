
Imports System.Data.SqlClient

Module Connect
    Public ConnectionString As String = "Data Source=LAPTOP-QGO39152\SQLEXPRESS;" &
          "Initial Catalog=LibrarySystem;" &
           "Integrated Security=True"
    Public Function SQLPull(ByVal SQLStatement As String) As DataTable
        Dim ret As Object = Nothing
        Dim SQLConn As New SqlConnection(ConnectionString)
        Dim SQLDataAdapter As New SqlDataAdapter
        Dim myDataSet As New DataSet
        SQLConn.Open()
        Try
            SQLDataAdapter.SelectCommand = New SqlCommand(SQLStatement, SQLConn)
            SQLDataAdapter.Fill(myDataSet)
        Catch ex As Exception
            If ex.Message <> "Cannot find table 0." Then
                MsgBox(ex.Message)
            End If
        End Try
        Return myDataSet.Tables(0)
        SQLConn.Close()
        SQLDataAdapter.Dispose()
        myDataSet.Dispose()
    End Function

    Public Sub SQLPush(ByVal SQLStatement As String)
        Dim SQLConn As SqlConnection = New SqlConnection(ConnectionString)
        Dim cmd As SqlCommand = New SqlCommand()
        cmd.CommandType = CommandType.Text
        cmd.CommandText = SQLStatement
        cmd.Connection = SQLConn
        SQLConn.Open()
        cmd.ExecuteNonQuery()
        SQLConn.Close()
    End Sub

    Public Sub PopulateComboBox(ByVal SQLStatement As String, ByVal comboBox As ComboBox)
        Dim dataTable As DataTable = SQLPull(SQLStatement)
        comboBox.Items.Clear()
        If dataTable IsNot Nothing Then
            For Each row As DataRow In dataTable.Rows
                comboBox.Items.Add(row(1).ToString())
            Next
        End If
    End Sub
End Module