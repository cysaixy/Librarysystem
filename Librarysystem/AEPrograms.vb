Public Class AEPrograms


    Private iPK As Integer
    Public Property PK() As Integer
        Get
            Return iPK
        End Get
        Set(value As Integer)
            iPK = value
        End Set
    End Property

   
    Private Sub txtProgramCode_KeyPress(sender As Object,
        e As KeyPressEventArgs) Handles txtProgramCode.KeyPress
        Dim allowed As String =
            "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm" &
            "1234567890"
        If allowed.IndexOf(e.KeyChar) = -1 Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 8 Then e.Handled = False
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs)

        If Trim(txtProgramCode.Text) = "" Or
           Trim(txtProgramName.Text) = "" Then
            MsgBox("Cannot save empty field/s.",
                   MsgBoxStyle.Exclamation + MsgBoxStyle.RetryCancel,
                   "Error")
            Exit Sub
        End If

        If Trim(Me.Text) = "Add Program" Then
            Connect.SQLPush(
                "INSERT INTO Programs (ProgramCode, ProgramName) " &
                "VALUES ('" & txtProgramCode.Text & "', '" &
                txtProgramName.Text & "')")
            MsgBox("New record added!",
                   MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Add")
        Else
            Connect.SQLPush(
                "UPDATE Programs SET ProgramCode = '" &
                txtProgramCode.Text &
                "', ProgramName = '" & txtProgramName.Text &
                "' WHERE ID = " & PK)
            MsgBox("Record updated!",
                   MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Edit")
        End If
        Me.Dispose()
    End Sub





    Private Sub btnCancel_Click_1(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub
End Class
