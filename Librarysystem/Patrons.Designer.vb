<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Patrons
    Inherits System.Windows.Forms.Form

     
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    
    Private components As System.ComponentModel.IContainer

   
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtLN = New System.Windows.Forms.TextBox()
        Me.txtFN = New System.Windows.Forms.TextBox()
        Me.txtMN = New System.Windows.Forms.TextBox()
        Me.txtProgID = New System.Windows.Forms.TextBox()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.txtSection = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(71, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "LastName"
        
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(71, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "FirstName"
        
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(71, 156)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "MiddleName"
        
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(71, 205)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "ProgramID"
        
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(71, 256)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "YearLevel"
        
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(71, 307)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Section"
        
        Me.txtLN.Location = New System.Drawing.Point(74, 88)
        Me.txtLN.Name = "txtLN"
        Me.txtLN.Size = New System.Drawing.Size(464, 22)
        Me.txtLN.TabIndex = 6
         
        Me.txtFN.Location = New System.Drawing.Point(74, 131)
        Me.txtFN.Name = "txtFN"
        Me.txtFN.Size = New System.Drawing.Size(464, 22)
        Me.txtFN.TabIndex = 7
         
        Me.txtMN.Location = New System.Drawing.Point(74, 175)
        Me.txtMN.Name = "txtMN"
        Me.txtMN.Size = New System.Drawing.Size(464, 22)
        Me.txtMN.TabIndex = 8
      
        Me.txtProgID.Location = New System.Drawing.Point(74, 231)
        Me.txtProgID.Name = "txtProgID"
        Me.txtProgID.Size = New System.Drawing.Size(464, 22)
        Me.txtProgID.TabIndex = 9
         
        Me.txtYear.Location = New System.Drawing.Point(74, 282)
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(464, 22)
        Me.txtYear.TabIndex = 10
         
        Me.txtSection.Location = New System.Drawing.Point(74, 326)
        Me.txtSection.Name = "txtSection"
        Me.txtSection.Size = New System.Drawing.Size(464, 22)
        Me.txtSection.TabIndex = 11
        
        Me.btnCancel.Location = New System.Drawing.Point(184, 381)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 21
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
         
        Me.btnSave.Location = New System.Drawing.Point(85, 381)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 20
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = True
        
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 560)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtSection)
        Me.Controls.Add(Me.txtYear)
        Me.Controls.Add(Me.txtProgID)
        Me.Controls.Add(Me.txtMN)
        Me.Controls.Add(Me.txtFN)
        Me.Controls.Add(Me.txtLN)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Patrons"
        Me.Text = "Patrons"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtLN As TextBox
    Friend WithEvents txtFN As TextBox
    Friend WithEvents txtMN As TextBox
    Friend WithEvents txtProgID As TextBox
    Friend WithEvents txtYear As TextBox
    Friend WithEvents txtSection As TextBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
End Class
