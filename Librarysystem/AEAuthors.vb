Public Class AEAuthors
    Private iPK As Integer
    Public Property PK() As Integer
        Get
            Return iPK
        End Get
        Set(value As Integer)
            iPK = value
        End Set
    End Property

    
    Private Sub txtAuthorName_KeyPress(sender As Object,
        e As KeyPressEventArgs) Handles txtAuthorName.KeyPress
        Dim allowed As String =
            "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm"
        If allowed.IndexOf(e.KeyChar) = -1 Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 32 Then
            e.Handled = False
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtAuthorName.Text) = "" Then
            MsgBox("Cannot save empty field/s.",
                   MsgBoxStyle.Exclamation + MsgBoxStyle.RetryCancel,
                   "Error")
            Exit Sub
        End If

        If Trim(Me.Text) = "Add Author" Then
            Connect.SQLPush(
                "INSERT INTO Authors (AuthorName) " &
                "VALUES ('" & txtAuthorName.Text & "')")
            MsgBox("New record added!",
                   MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Add")
        Else
            Connect.SQLPush(
                "UPDATE Authors SET AuthorName = '" &
                txtAuthorName.Text & "' WHERE ID = " & PK)
            MsgBox("Record updated!",
                   MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Edit")
        End If
        Me.Dispose()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub AEAuthors_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
