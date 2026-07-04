Public Class AEPatrons
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
    ' FORM LOAD — populate program combo box
    '────────────────────────────────────────────────────────────
    Private Sub AEPatrons_Load(sender As Object,
        e As EventArgs) Handles MyBase.Load
        Connect.PopulateComboBox(
            "SELECT ID, ProgCode FROM Programs", cboProgram)
    End Sub

    '────────────────────────────────────────────────────────────
    ' KEY TRAPPING
    '────────────────────────────────────────────────────────────
    ' Name fields — letters and spaces only
    Private Sub NameField_KeyPress(sender As Object,
        e As KeyPressEventArgs) _
        Handles txtLastName.KeyPress,
                txtFirstName.KeyPress,
                txtMiddleName.KeyPress
        Dim allowed As String =
            "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm"
        If allowed.IndexOf(e.KeyChar) = -1 Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 8 Or Asc(e.KeyChar) = 32 Then
            e.Handled = False
        End If
    End Sub

    ' Year level — digits only
    Private Sub txtYearLevel_KeyPress(sender As Object,
        e As KeyPressEventArgs) Handles txtYearLevel.KeyPress
        Dim allowed As String = "1234567890"
        If allowed.IndexOf(e.KeyChar) = -1 Then
            e.Handled = True
        End If
        If Asc(e.KeyChar) = 8 Then e.Handled = False
    End Sub

    '────────────────────────────────────────────────────────────
    ' SAVE BUTTON
    '────────────────────────────────────────────────────────────
    Private Sub btnSave_Click(sender As Object, e As EventArgs)

        If Trim(txtLastName.Text) = "" Or
           Trim(txtFirstName.Text) = "" Or
           Trim(cboProgram.Text) = "" Or
           Trim(txtYearLevel.Text) = "" Or
           Trim(txtSection.Text) = "" Then
            MsgBox("Cannot save empty field/s.",
                   MsgBoxStyle.Exclamation + MsgBoxStyle.RetryCancel,
                   "Error")
            Exit Sub
        End If

        ' Get ProgramID from selected program code
        Dim progID As Integer =
            Connect.SQLPull(
                "SELECT ID FROM Programs WHERE " &
                "ProgCode = '" & cboProgram.Text & "'").Rows(0)(0)

        If Trim(Me.Text) = "Add Patron" Then
            Connect.SQLPush(
                "INSERT INTO Patrons " &
                "(LastName, FirstName, MiddleName, " &
                "ProgramID, YearLevel, Section) " &
                "VALUES ('" & txtLastName.Text & "', '" &
                txtFirstName.Text & "', '" &
                txtMiddleName.Text & "', " & progID & ", " &
                txtYearLevel.Text & ", '" &
                txtSection.Text & "')")
            MsgBox("New record added!",
                   MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Add")
        Else
            Connect.SQLPush(
                "UPDATE Patrons SET " &
                "LastName = '" & txtLastName.Text & "', " &
                "FirstName = '" & txtFirstName.Text & "', " &
                "MiddleName = '" & txtMiddleName.Text & "', " &
                "ProgramID = " & progID & ", " &
                "YearLevel = " & txtYearLevel.Text & ", " &
                "Section = '" & txtSection.Text & "' " &
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