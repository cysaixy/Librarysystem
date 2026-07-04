Public Class RecordList
    
    Private Sub RecordList_Load(sender As Object,
        e As EventArgs) Handles MyBase.Load
        ApplyStyle()
        txtTitle.Text = Me.Text
    End Sub

     
    Private Sub RecordList_Activated(sender As Object,
        e As EventArgs) Handles Me.Activated
        ReloadRecords()
    End Sub

     
    Sub ReloadRecords()
        Select Case Trim(Me.Text)
            Case "Books."
                dgv.DataSource =
                    Connect.SQLPull("SELECT * FROM vBook")
            Case "Authors"
                dgv.DataSource =
                    Connect.SQLPull("SELECT * FROM Authors ORDER BY ID")
            Case "Publishers"
                dgv.DataSource =
                    Connect.SQLPull("SELECT * FROM Publishers ORDER BY ID")
            Case "Classification"
                dgv.DataSource =
                    Connect.SQLPull("SELECT * FROM Classification ORDER BY ID")
            Case "Patrons"
                dgv.DataSource =
                    Connect.SQLPull("SELECT * FROM vPatrons")
            Case "Programs"
                dgv.DataSource =
                    Connect.SQLPull("SELECT * FROM Programs ORDER BY ID")
        End Select
        FormatGrid()
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Count.Text = dgv.Rows.Count & " records"
    End Sub

     
    Sub FormatGrid()
        Select Case Trim(Me.Text)

            Case "Books."
                dgv.Columns(0).Visible = False    
                dgv.Columns(7).Visible = False    
                dgv.Columns(8).Visible = False   
                dgv.Columns(9).Visible = False    
                dgv.Columns(1).Width = 140 : dgv.Columns(1).HeaderText = "ISBN"
                dgv.Columns(2).Width = 180 : dgv.Columns(2).HeaderText = "Book Title"
                dgv.Columns(3).Width = 140 : dgv.Columns(3).HeaderText = "Class "
                dgv.Columns(4).Width = 120 : dgv.Columns(4).HeaderText = "Author"
                dgv.Columns(5).Width = 120 : dgv.Columns(5).HeaderText = "Publisher"
                dgv.Columns(6).Width = 60 : dgv.Columns(6).HeaderText = "Copyright"

            Case "Authors"
                dgv.Columns(0).Visible = False
                dgv.Columns(1).Width = 400
                dgv.Columns(1).HeaderText = "AuthorName"

            Case "Publishers"
                dgv.Columns(0).Visible = False
                dgv.Columns(1).Width = 180 : dgv.Columns(1).HeaderText = "Publisher Name"
                dgv.Columns(2).Width = 260 : dgv.Columns(2).HeaderText = "Publisher Address"
                dgv.Columns(3).Width = 130 : dgv.Columns(3).HeaderText = "PubContact"

            Case "Classification"
                dgv.Columns(0).Visible = False
                dgv.Columns(1).Width = 180 : dgv.Columns(1).HeaderText = "Class No."
                dgv.Columns(2).Width = 300 : dgv.Columns(2).HeaderText = "Classification"

            Case "Patrons"
                dgv.Columns(0).Visible = False
                dgv.Columns(4).Visible = False    
                dgv.Columns(1).Width = 130 : dgv.Columns(1).HeaderText = "Last Name"
                dgv.Columns(2).Width = 120 : dgv.Columns(2).HeaderText = "First Name"
                dgv.Columns(3).Width = 130 : dgv.Columns(3).HeaderText = "Middle Name"
                dgv.Columns(5).Width = 100 : dgv.Columns(5).HeaderText = "Program"
                dgv.Columns(6).Width = 60 : dgv.Columns(6).HeaderText = "Year Level"
                dgv.Columns(7).Width = 70 : dgv.Columns(7).HeaderText = "Section"

            Case "Programs"
                dgv.Columns(0).Visible = False
                dgv.Columns(1).Width = 160 : dgv.Columns(1).HeaderText = "Program Code"
                dgv.Columns(2).Width = 380 : dgv.Columns(2).HeaderText = "Program Name"

        End Select
    End Sub

    
    Sub AddRecord()
        Select Case Trim(Me.Text)
            Case "Books."
                AEBooks.Text = "Add Book"
                AEBooks.ShowDialog()
            Case "Authors"
                AEAuthors.Text = "Add Author"
                AEAuthors.ShowDialog()
            Case "Publishers"
                AEPublishers.Text = "Add Publisher"
                AEPublishers.ShowDialog()
            Case "Classification"
                AEClassifications.Text = "Add Classification"
                AEClassifications.ShowDialog()
            Case "Patrons"
                AEPatrons.Text = "Add Patron"
                AEPatrons.ShowDialog()
            Case "Programs"
                AEPrograms.Text = "Add Program"
                AEPrograms.ShowDialog()
        End Select
    End Sub

    Private Sub btnAdd_Click(sender As Object,
        e As EventArgs) Handles btnAdd.Click
        AddRecord()
    End Sub

   
    Sub EditRecord()
        If dgv.CurrentRow Is Nothing Then
            MsgBox("Please select a record to edit.",
                   MsgBoxStyle.Exclamation, "Edit")
            Exit Sub
        End If

        Select Case Trim(Me.Text)
            Case "Books."
                AEBooks.Text = "Edit Book"
                AEBooks.PK = dgv.CurrentRow.Cells(0).Value
                AEBooks.txtISBN.Text = dgv.CurrentRow.Cells(1).Value
                AEBooks.txtTitle.Text = dgv.CurrentRow.Cells(2).Value
                AEBooks.cboClass.Text = dgv.CurrentRow.Cells(3).Value
                AEBooks.cboAuthor.Text = dgv.CurrentRow.Cells(4).Value
                AEBooks.cboPub.Text = dgv.CurrentRow.Cells(5).Value
                AEBooks.txtCopyright.Text = dgv.CurrentRow.Cells(6).Value
                AEBooks.ShowDialog()

            Case "Authors"
                AEAuthors.Text = "Edit Author"
                AEAuthors.PK = dgv.CurrentRow.Cells(0).Value
                AEAuthors.txtAuthorName.Text = dgv.CurrentRow.Cells(1).Value
                AEAuthors.ShowDialog()

            Case "Publishers"
                AEPublishers.Text = "Edit Publisher"
                AEPublishers.PK = dgv.CurrentRow.Cells(0).Value
                AEPublishers.txtPubName.Text = dgv.CurrentRow.Cells(1).Value
                AEPublishers.txtPubAddress.Text = dgv.CurrentRow.Cells(2).Value
                AEPublishers.txtPubContact.Text = dgv.CurrentRow.Cells(3).Value
                AEPublishers.ShowDialog()

            Case "Classification"
                AEClassifications.Text = "Edit Classification"
                AEClassifications.PK = dgv.CurrentRow.Cells(0).Value
                AEClassifications.txtClassNo.Text = dgv.CurrentRow.Cells(1).Value
                AEClassifications.txtClassification.Text = dgv.CurrentRow.Cells(2).Value
                AEClassifications.ShowDialog()

            Case "Patrons"
                AEPatrons.Text = "Edit Patron"
                AEPatrons.PK = dgv.CurrentRow.Cells(0).Value
                AEPatrons.txtLastName.Text = dgv.CurrentRow.Cells(1).Value
                AEPatrons.txtFirstName.Text = dgv.CurrentRow.Cells(2).Value
                AEPatrons.txtMiddleName.Text = dgv.CurrentRow.Cells(3).Value
                AEPatrons.cboProgram.Text = dgv.CurrentRow.Cells(5).Value
                AEPatrons.txtYearLevel.Text = dgv.CurrentRow.Cells(6).Value
                AEPatrons.txtSection.Text = dgv.CurrentRow.Cells(7).Value
                AEPatrons.ShowDialog()

            Case "Programs"
                AEPrograms.Text = "Edit Program"
                AEPrograms.PK = dgv.CurrentRow.Cells(0).Value
                AEPrograms.txtProgramCode.Text = dgv.CurrentRow.Cells(1).Value
                AEPrograms.txtProgramName.Text = dgv.CurrentRow.Cells(2).Value
                AEPrograms.ShowDialog()
        End Select
    End Sub

    Private Sub btnEdit_Click(sender As Object,
        e As EventArgs) Handles btnEdit.Click
        EditRecord()
    End Sub

   
    Sub DeleteRecord()
        If dgv.CurrentRow Is Nothing Then
            MsgBox("Please select a record to delete.",
                   MsgBoxStyle.Exclamation, "Delete")
            Exit Sub
        End If

        Dim icol As Integer = dgv.CurrentRow.Cells(0).Value

        If MsgBox("Do you really want to delete this record?",
                  MsgBoxStyle.YesNo + MsgBoxStyle.Question,
                  "Delete") = MsgBoxResult.Yes Then
            Select Case Trim(Me.Text)
                Case "Books."
                    Connect.SQLPush(
                        "DELETE FROM [Books.] WHERE ID = " & icol)
                Case "Authors"
                    Connect.SQLPush(
                        "DELETE FROM Authors WHERE ID = " & icol)
                Case "Publishers"
                    Connect.SQLPush(
                        "DELETE FROM Publishers WHERE ID = " & icol)
                Case "Classification"
                    Connect.SQLPush(
                        "DELETE FROM Classification WHERE ID = " & icol)
                Case "Patrons"
                    Connect.SQLPush(
                        "DELETE FROM Patrons WHERE ID = " & icol)
                Case "Programs"
                    Connect.SQLPush(
                        "DELETE FROM Programs WHERE ID = " & icol)
            End Select
            MsgBox("Record deleted.",
                   MsgBoxStyle.Information + MsgBoxStyle.OkOnly,
                   "Delete")
        End If
        ReloadRecords()
    End Sub

    Private Sub btnDelete_Click(sender As Object,
        e As EventArgs) Handles btnDelete.Click
        DeleteRecord()
    End Sub

    
    Private Sub btnSearch_Click(sender As Object,
        e As EventArgs) Handles btnSearch.Click
        grp.Visible = True
        txtSearch.Focus()
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object,
        e As KeyEventArgs) Handles txtSearch.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                Select Case Trim(Me.Text)
                    Case "Books."
                        dgv.DataSource = Connect.SQLPull(
                            "SELECT * FROM vBook WHERE " &
                            "BookTitle LIKE '%" & txtSearch.Text & "%' OR " &
                            "AuthorName LIKE '%" & txtSearch.Text & "%' OR " &
                            "ISBN LIKE '%" & txtSearch.Text & "%'")
                    Case "Authors"
                        dgv.DataSource = Connect.SQLPull(
                            "SELECT * FROM Authors WHERE " &
                            "AuthorName LIKE '%" & txtSearch.Text & "%'")
                    Case "Publishers"
                        dgv.DataSource = Connect.SQLPull(
                            "SELECT * FROM Publishers WHERE " &
                            "PubName LIKE '%" & txtSearch.Text & "%' OR " &
                            "PubAddress LIKE '%" & txtSearch.Text & "%'")
                    Case "Classification"
                        dgv.DataSource = Connect.SQLPull(
                            "SELECT * FROM Classification WHERE " &
                            "ClassNo LIKE '%" & txtSearch.Text & "%' OR " &
                            "Classification LIKE '%" & txtSearch.Text & "%'")
                    Case "Patrons"
                        dgv.DataSource = Connect.SQLPull(
                            "SELECT * FROM vPatrons WHERE " &
                            "LastName LIKE '%" & txtSearch.Text & "%' OR " &
                            "FirstName LIKE '%" & txtSearch.Text & "%' OR " &
                            "ProgramCode LIKE '%" & txtSearch.Text & "%'")
                    Case "Programs"
                        dgv.DataSource = Connect.SQLPull(
                            "SELECT * FROM Programs WHERE " &
                            "ProgramCode LIKE '%" & txtSearch.Text & "%' OR " &
                            "ProgramName LIKE '%" & txtSearch.Text & "%'")
                End Select
                FormatGrid()
                grp.Visible = False
                Count.Text = dgv.Rows.Count & " records"

            Case Keys.Escape
                grp.Visible = False
        End Select
    End Sub

   
    Private Sub btnReload_Click(sender As Object,
        e As EventArgs) Handles btnReload.Click
        txtSearch.Clear()
        ReloadRecords()
    End Sub

 
    Sub CloseForm()
        Select Case Trim(Me.Text)
            Case "Books."
                MainForm.mnuBooks.Enabled = True
            Case "Authors"
                MainForm.mnuAuthors.Enabled = True
            Case "Publishers"
                MainForm.mnuPublishers.Enabled = True
            Case "Classification"
                MainForm.mnuClassification.Enabled = True
            Case "Patrons"
                MainForm.mnuPatrons.Enabled = True
            Case "Programs"
                MainForm.mnuPrograms.Enabled = True
        End Select
        MainForm.LoadRecordCounts()
        Me.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object,
        e As EventArgs) Handles btnClose.Click
        CloseForm()
    End Sub

    
    Private Sub ApplyStyle()
        pnlHeader.BackColor = Color.FromArgb(26, 26, 46)

        txtTitle.ForeColor = Color.FromArgb(201, 168, 76)
        txtTitle.Font = New Font("Georgia, 12pt, style=Bold", 13, FontStyle.Bold)
        txtTitle.AutoSize = True
        txtTitle.Location = New Point(14, 10)

        Count.ForeColor = Color.FromArgb(29, 106, 106)
        Count.Font = New Font("Georgia, 9pt, style=Bold", 9)
        Count.AutoSize = True
        Count.Location = New Point(14, 30)

        pnlToolbar.BackColor = Color.FromArgb(245, 240, 232)

        btnAdd.BackColor = Color.FromArgb(29, 106, 106)
        btnAdd.ForeColor = Color.White
        btnEdit.BackColor = Color.FromArgb(201, 168, 76)
        btnEdit.ForeColor = Color.FromArgb(26, 26, 46)
        btnDelete.BackColor = Color.FromArgb(139, 58, 42)
        btnDelete.ForeColor = Color.White
        btnSearch.BackColor = Color.FromArgb(245, 240, 232)
        btnSearch.ForeColor = Color.FromArgb(100, 90, 80)
        btnReload.BackColor = Color.FromArgb(245, 240, 232)
        btnReload.ForeColor = Color.FromArgb(100, 90, 80)
        btnClose.BackColor = Color.FromArgb(26, 26, 46)
        btnClose.ForeColor = Color.FromArgb(232, 213, 163)

        For Each btn As Button In pnlToolbar.Controls.OfType(Of Button)()
            btn.FlatStyle = FlatStyle.Flat
            btn.FlatAppearance.BorderSize = 0
            btn.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            btn.Cursor = Cursors.Hand
            btn.Height = 28
        Next

        With dgv
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.None
            .RowHeadersVisible = False
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .Font = New Font("Segoe UI", 9.5)
            .RowTemplate.Height = 30
            .GridColor = Color.FromArgb(214, 205, 184)
            .ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(26, 26, 46)
            .ColumnHeadersDefaultCellStyle.ForeColor =
                Color.FromArgb(232, 213, 163)
            .ColumnHeadersDefaultCellStyle.Font =
                New Font("Segoe UI", 9.5, FontStyle.Bold)
            .ColumnHeadersHeight = 34
            .EnableHeadersVisualStyles = False
            .AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(240, 235, 220)
            .DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(29, 106, 106)
            .DefaultCellStyle.SelectionForeColor = Color.White
            .DefaultCellStyle.Padding = New Padding(4, 0, 0, 0)
        End With
    End Sub


End Class
