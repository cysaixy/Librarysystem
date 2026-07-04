Public Class AEBooks
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
    ' FORM LOAD
    '────────────────────────────────────────────────────────────
    Private Sub AEBooks_Load(sender As Object,
        e As EventArgs) Handles MyBase.Load
        Connect.PopulateComboBox(
            "SELECT ID, Classification FROM Classification", cboClass)
        Connect.PopulateComboBox(
            "SELECT ID, AuthorName FROM Authors", cboAuthor)
        Connect.PopulateComboBox(
            "SELECT ID, PubName FROM Publishers", cboPub)
    End Sub

    '────────────────────────────────────────────────────────────
    ' KEY TRAPPING — copyright: digits only
    '────────────────────────────────────────────────────────────
    Private Sub txtCopyright_KeyPress(sender As Object,
        e As KeyPressEventArgs) Handles txtCopyright.KeyPress
        Dim allowed As String = "1234567890"
        If allowed.IndexOf(e.KeyChar) = -1 Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 8 Then e.Handled = False
    End Sub

    '────────────────────────────────────────────────────────────
    ' SAVE BUTTON
    ' NOTE: INSERT and UPDATE use [Books.] with square brackets
    '────────────────────────────────────────────────────────────
    Private Sub btnSave_Click(sender As Object,
        e As EventArgs)

        If Trim(txtISBN.Text) = "" Or Trim(txtTitle.Text) = "" Or
           Trim(txtCopyright.Text) = "" Or Trim(cboClass.Text) = "" Or
           Trim(cboAuthor.Text) = "" Or Trim(cboPub.Text) = "" Then
            MsgBox("Cannot save empty field/s.",
                   MsgBoxStyle.Exclamation + MsgBoxStyle.RetryCancel,
                   "Error")
            Exit Sub
        End If

        ' Get IDs from selected combo text
        Dim classID As Integer =
            Connect.SQLPull(
                "SELECT ID FROM Classification WHERE " &
                "Classification = '" & cboClass.Text & "'").Rows(0)(0)

        Dim authorID As Integer =
            Connect.SQLPull(
                "SELECT ID FROM Authors WHERE " &
                "AuthorName = '" & cboAuthor.Text & "'").Rows(0)(0)

        Dim pubID As Integer =
            Connect.SQLPull(
                "SELECT ID FROM Publishers WHERE " &
                "PubName = '" & cboPub.Text & "'").Rows(0)(0)

        If Trim(Me.Text) = "Add Book" Then
            Connect.SQLPush(
                "INSERT INTO [Books.] " &
                "(ISBN, BookTitle, ClassID, AuthorID, PublisherID, Copyright) " &
                "VALUES ('" & txtISBN.Text & "', '" &
                txtTitle.Text & "', " & classID & ", " &
                authorID & ", " & pubID & ", " &
                txtCopyright.Text & ")")
            MsgBox("New record added!",
                   MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Add")
        Else
            Connect.SQLPush(
                "UPDATE [Books.] SET " &
                "ISBN = '" & txtISBN.Text & "', " &
                "BookTitle = '" & txtTitle.Text & "', " &
                "ClassID = " & classID & ", " &
                "AuthorID = " & authorID & ", " &
                "PublisherID = " & pubID & ", " &
                "Copyright = " & txtCopyright.Text &
                " WHERE ID = " & PK)
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
