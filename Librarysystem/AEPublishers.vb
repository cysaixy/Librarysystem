Public Class AEPublishers
    Private iPK As Integer
    Public Property PK() As Integer
        Get
            Return iPK
        End Get
        Set(value As Integer)
            iPK = value
        End Set
    End Property

    '────────────────────────────────────────────────────────────
    ' KEY TRAPPING — contact: digits, dash, parentheses only
    '────────────────────────────────────────────────────────────
    Private Sub txtPubContact_KeyPress(sender As Object,
        e As KeyPressEventArgs) Handles txtPubContact.KeyPress
        Dim allowed As String = "1234567890()-+ "
        If allowed.IndexOf(e.KeyChar) = -1 Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 8 Then e.Handled = False
    End Sub

    '────────────────────────────────────────────────────────────
    ' SAVE BUTTON
    '────────────────────────────────────────────────────────────
    Private Sub btnSave_Click(sender As Object,
        e As EventArgs)

        If Trim(txtPubName.Text) = "" Or
           Trim(txtPubAddress.Text) = "" Or
           Trim(txtPubContact.Text) = "" Then
            MsgBox("Cannot save empty field/s.",
                   MsgBoxStyle.Exclamation + MsgBoxStyle.RetryCancel,
                   "Error")
            Exit Sub
        End If

        If Trim(Me.Text) = "Add Publisher" Then
            Connect.SQLPush(
                "INSERT INTO Publishers " &
                "(PubName, PubAddress, PubContact) " &
                "VALUES ('" & txtPubName.Text & "', '" &
                txtPubAddress.Text & "', '" &
                txtPubContact.Text & "')")
            MsgBox("New record added!",
                   MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Add")
        Else
            Connect.SQLPush(
                "UPDATE Publishers SET " &
                "PubName = '" & txtPubName.Text & "', " &
                "PubAddress = '" & txtPubAddress.Text & "', " &
                "PubContact = '" & txtPubContact.Text & "' " &
                "WHERE ID = " & PK)
            MsgBox("Record updated!",
                   MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Edit")
        End If
        Me.Dispose()
    End Sub

    '────────────────────────────────────────────────────────────
    ' CANCEL BUTTON
    '────────────────────────────────────────────────────────────


    Private Sub btnCancel_Click_1(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub
End Class