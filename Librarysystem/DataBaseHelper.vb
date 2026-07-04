Imports System.Data.SqlClient

Public Class DataBaseHelper

    Private Shared ReadOnly connString As String =
        "Server=localhost\SQLEXPRESS;Database=LibrarySystem;Integrated Security=True;"

    Public Shared Function GetConnection() As SqlConnection
        Return New SqlConnection(connString)
    End Function

    Public Shared Function GetDataTable(query As String,
                                        Optional params As Dictionary(Of String, Object) = Nothing) As DataTable
        Dim dt As New DataTable
        Using conn = GetConnection()
            conn.Open()
            Using cmd As New SqlCommand(query, conn)
                If params IsNot Nothing Then
                    For Each kv In params
                        cmd.Parameters.AddWithValue(kv.Key, kv.Value)
                    Next
                End If
                Using adapter As New SqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    Public Shared Function ExecuteNonQuery(query As String,
                                           params As Dictionary(Of String, Object)) As Integer
        Using conn = GetConnection()
            conn.Open()
            Using cmd As New SqlCommand(query, conn)
                For Each kv In params
                    cmd.Parameters.AddWithValue(kv.Key, kv.Value)
                Next
                Return cmd.ExecuteNonQuery()
            End Using
        End Using
    End Function

    Public Shared Function GetScalar(query As String,
                                     Optional params As Dictionary(Of String, Object) = Nothing) As Object
        Using conn = GetConnection()
            conn.Open()
            Using cmd As New SqlCommand(query, conn)
                If params IsNot Nothing Then
                    For Each kv In params
                        cmd.Parameters.AddWithValue(kv.Key, kv.Value)
                    Next
                End If
                Return cmd.ExecuteScalar()
            End Using
        End Using
    End Function

End Class