Public Class AEClassifications
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
    ' KEY TRAPPING — letters and spaces only for classification
    '────────────────────────────────────────────────────────────
    Private Sub txtClassification_KeyPress(sender As Object,
        e As KeyPressEventArgs) Handles txtClassification.KeyPress
        Dim allowed As String =
            "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm"
        If allowed.IndexOf(e.KeyChar) = -1 Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 32 Then
            e.Handled = False
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs)

        If Trim(txtClassNo.Text) = "" Or
           Trim(txtClassification.Text) = "" Then
            MsgBox("Cannot save empty field/s.",
                   MsgBoxStyle.Exclamation + MsgBoxStyle.RetryCancel,
                   "Error")
            Exit Sub
        End If

        If Trim(Me.Text) = "Add Classification" Then
            Connect.SQLPush(
                "INSERT INTO Classification (ClassNo, Classification) " &
                "VALUES ('" & txtClassNo.Text & "', '" &
                txtClassification.Text & "')")
            MsgBox("New record added!",
                   MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Add")
        Else
            Connect.SQLPush(
                "UPDATE Classification SET " &
                "ClassNo = '" & txtClassNo.Text & "', " &
                "Classification = '" & txtClassification.Text & "' " &
                "WHERE ID = " & PK)
            MsgBox("Record updated!",
                   MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Edit")
        End If
        Me.Dispose()
    End Sub



    Private Sub btnCancel_Click_1(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

End Class