<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuBooks = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuAuthors = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPublishers = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuClassification = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPatrons = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrograms = New System.Windows.Forms.ToolStripMenuItem()
        Me.Mnu = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuLogout = New System.Windows.Forms.ToolStripMenuItem()
        Me.statusstrip = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.statusstrip.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBooks, Me.mnuAuthors, Me.mnuPublishers, Me.mnuClassification, Me.mnuPatrons, Me.mnuPrograms, Me.Mnu, Me.mnuLogout})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.Size = New System.Drawing.Size(1272, 28)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuBooks
        '
        Me.mnuBooks.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mnuBooks.ForeColor = System.Drawing.Color.White
        Me.mnuBooks.Name = "mnuBooks"
        Me.mnuBooks.Size = New System.Drawing.Size(63, 24)
        Me.mnuBooks.Text = "Books"
        '
        'mnuAuthors
        '
        Me.mnuAuthors.ForeColor = System.Drawing.Color.White
        Me.mnuAuthors.Name = "mnuAuthors"
        Me.mnuAuthors.Size = New System.Drawing.Size(74, 24)
        Me.mnuAuthors.Text = "Authors"
        '
        'mnuPublishers
        '
        Me.mnuPublishers.ForeColor = System.Drawing.Color.White
        Me.mnuPublishers.Name = "mnuPublishers"
        Me.mnuPublishers.Size = New System.Drawing.Size(89, 24)
        Me.mnuPublishers.Text = "Publishers"
        '
        'mnuClassification
        '
        Me.mnuClassification.ForeColor = System.Drawing.Color.White
        Me.mnuClassification.Name = "mnuClassification"
        Me.mnuClassification.Size = New System.Drawing.Size(116, 24)
        Me.mnuClassification.Text = "Classifications"
        '
        'mnuPatrons
        '
        Me.mnuPatrons.ForeColor = System.Drawing.Color.White
        Me.mnuPatrons.Name = "mnuPatrons"
        Me.mnuPatrons.Size = New System.Drawing.Size(71, 24)
        Me.mnuPatrons.Text = "Patrons"
        '
        'mnuPrograms
        '
        Me.mnuPrograms.ForeColor = System.Drawing.Color.White
        Me.mnuPrograms.Name = "mnuPrograms"
        Me.mnuPrograms.Size = New System.Drawing.Size(86, 24)
        Me.mnuPrograms.Text = "Programs"
        '
        'Mnu
        '
        Me.Mnu.Name = "Mnu"
        Me.Mnu.Size = New System.Drawing.Size(14, 24)
        '
        'mnuLogout
        '
        Me.mnuLogout.Name = "mnuLogout"
        Me.mnuLogout.Size = New System.Drawing.Size(70, 24)
        Me.mnuLogout.Text = "Logout"
        '
        'statusstrip
        '
        Me.statusstrip.BackColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.statusstrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.statusstrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.statusstrip.Location = New System.Drawing.Point(0, 593)
        Me.statusstrip.Name = "statusstrip"
        Me.statusstrip.Size = New System.Drawing.Size(1272, 26)
        Me.statusstrip.SizingGrip = False
        Me.statusstrip.TabIndex = 2
        Me.statusstrip.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.ForeColor = System.Drawing.Color.LightCyan
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(1257, 20)
        Me.lblStatus.Spring = True
        Me.lblStatus.Text = "ToolStripStatusLabel1"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(16, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1272, 122)
        Me.Panel1.TabIndex = 3
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Georgia", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(199, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(20, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(12, 22)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(419, 32)
        Me.lblTitle.TabIndex = 5
        Me.lblTitle.Text = "Library Information System"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1272, 619)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.statusstrip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MainForm"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.statusstrip.ResumeLayout(False)
        Me.statusstrip.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents mnuBooks As ToolStripMenuItem
    Friend WithEvents mnuAuthors As ToolStripMenuItem
    Friend WithEvents mnuPublishers As ToolStripMenuItem
    Friend WithEvents mnuClassification As ToolStripMenuItem
    Friend WithEvents statusstrip As StatusStrip
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents mnuPatrons As ToolStripMenuItem
    Friend WithEvents mnuPrograms As ToolStripMenuItem
    Friend WithEvents Mnu As ToolStripMenuItem
    Friend WithEvents mnuLogout As ToolStripMenuItem
End Class
