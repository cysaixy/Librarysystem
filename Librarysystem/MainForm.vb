Imports System.Data.SqlClient
Imports Org.BouncyCastle.Asn1.X500

Public Class MainForm

    Private Sub frmMain_Load(sender As Object,
        e As EventArgs) Handles MyBase.Load
        ApplyMenuStyle()
        ApplyHeaderStyle()
        ApplyStatusStyle()
        SetMdiBackground()
        LoadRecordCounts()
    End Sub

   
    Private Sub ApplyMenuStyle()
        MenuStrip1.BackColor = Color.FromArgb(26, 26, 46)
        MenuStrip1.ForeColor = Color.White
        MenuStrip1.RenderMode = ToolStripRenderMode.Professional

        For Each item As ToolStripMenuItem In MenuStrip1.Items
            item.ForeColor = Color.White
            item.Font = New Font("Segoe UI", 9.5, FontStyle.Regular)
            item.Padding = New Padding(6, 0, 6, 0)
        Next

        mnuLogout.Alignment = ToolStripItemAlignment.Right
        mnuLogout.ForeColor = Color.FromArgb(255, 180, 180)
        mnuLogout.BackColor = Color.FromArgb(139, 58, 42)
        mnuLogout.Font = New Font("Segoe UI", 9.5, FontStyle.Bold)
    End Sub

    
    Private Sub ApplyHeaderStyle()


        lblTitle.Text = "Library Information System"
        lblTitle.ForeColor = Color.FromArgb(201, 168, 76)
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(14, 30)


    End Sub

    
    Private Sub ApplyStatusStyle()
        statusstrip.BackColor = Color.FromArgb(26, 26, 46)
        statusstrip.SizingGrip = False
        lblStatus.ForeColor = Color.FromArgb(201, 168, 76)
        lblStatus.Font = New Font("Georgia, 12pt, style=Bold", 9)
        lblStatus.Spring = True
        lblStatus.TextAlign = ContentAlignment.MiddleLeft
    End Sub

    
    Private Sub SetMdiBackground()
        For Each ctrl As Control In Me.Controls
            If ctrl.GetType().Name = "MdiClient" Then
                ctrl.BackColor = Color.FromArgb(220, 230, 240)
            End If
        Next
    End Sub

     
    Public Sub LoadRecordCounts()
        Try
            Dim sb As New System.Text.StringBuilder("  Records — ")

             
            Dim dtBooks As DataTable =
                Connect.SQLPull("SELECT COUNT(*) AS Total FROM vBook")
            sb.Append("Books: " & dtBooks.Rows(0)(0).ToString() & "   ")

             
            Dim others() = {"Authors", "Publishers",
                            "Classification", "Patrons", "Programs"}
            For Each t In others
                Dim dt As DataTable =
                    Connect.SQLPull("SELECT COUNT(*) AS Total FROM " & t)
                sb.Append(t & ": " & dt.Rows(0)(0).ToString() & "   ")
            Next

            lblStatus.Text = sb.ToString()
        Catch ex As Exception
            lblStatus.Text = "  Could not load record counts."
        End Try
    End Sub

    
    Private Sub OpenRecordList(title As String,
                               menuItem As ToolStripMenuItem)
        Dim frm As New RecordList
        frm.Text = title
        frm.MdiParent = Me
        frm.WindowState = FormWindowState.Maximized

        frm.Show()
    End Sub

     
    Private Sub mnuBooks_Click(sender As Object,
        e As EventArgs) Handles mnuBooks.Click
        OpenRecordList("Books.", mnuBooks)    
    End Sub

    Private Sub mnuAuthors_Click(sender As Object,
        e As EventArgs) Handles mnuAuthors.Click
        OpenRecordList("Authors", mnuAuthors)
    End Sub

    Private Sub mnuPublishers_Click(sender As Object,
        e As EventArgs) Handles mnuPublishers.Click
        OpenRecordList("Publishers", mnuPublishers)
    End Sub

    Private Sub mnuClassifications_Click(sender As Object,
        e As EventArgs) Handles mnuClassification.Click
        OpenRecordList("Classification", mnuClassification)
    End Sub

    Private Sub mnuPatrons_Click(sender As Object,
        e As EventArgs) Handles mnuPatrons.Click
        OpenRecordList("Patrons", mnuPatrons)
    End Sub

    Private Sub mnuPrograms_Click(sender As Object,
        e As EventArgs) Handles mnuPrograms.Click
        OpenRecordList("Programs", mnuPrograms)
    End Sub

   
    Private Sub mnuLogout_Click(sender As Object,
        e As EventArgs) Handles mnuLogout.Click
        If MsgBox("Do you really want to log-out?",
                  MsgBoxStyle.Question + MsgBoxStyle.YesNo,
                  "Log-out?") = MsgBoxResult.Yes Then
            Me.Dispose()
            Form1.txtUsername.Clear()
            Form1.txtPassword.Clear()
            Form1.Show()
        End If
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Dim borderColor As New Pen(ColorTranslator.FromHtml("#FDF5E6"), 8)
        e.Graphics.DrawRectangle(borderColor, 0, 0, Panel1.Width - 1, Panel1.Height - 1)
        borderColor.Dispose()
    End Sub
End Class
