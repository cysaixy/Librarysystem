
Imports System.Data.SqlClient

Public Class Form1
    '══════════════════════════════════════════════════════════
    ' CONSTANTS & STATE
    '══════════════════════════════════════════════════════════
    Private Const MAX_ATTEMPTS As Integer = 3
    Private Const LOCK_SECONDS As Integer = 60

    Private _attempts As Integer = 0
    Private _lockCountdown As Integer = 0

    '══════════════════════════════════════════════════════════
    ' FORM LOAD
    '══════════════════════════════════════════════════════════
    Private Sub frmLogin_Load(sender As Object, e As EventArgs) _
        Handles MyBase.Load
        ResetUI()
        txtUsername.Focus()
    End Sub

    '══════════════════════════════════════════════════════════
    ' KEY TRAPPING
    '══════════════════════════════════════════════════════════

    ''' <summary>
    ''' Username: allow letters, digits, underscore only.
    ''' Enter moves focus to password field.
    ''' </summary>
    Private Sub txtUsername_KeyPress(sender As Object,
        e As KeyPressEventArgs) Handles txtUsername.KeyPress

        Select Case e.KeyChar
            Case Chr(13)    ' Enter → jump to password
                txtPassword.Focus()
                e.Handled = True

            Case Chr(8)     ' Backspace — always allow
                ' let it through

            Case Else
                If Not (Char.IsLetterOrDigit(e.KeyChar) OrElse
                        e.KeyChar = "_"c) Then
                    e.Handled = True
                End If
        End Select
    End Sub

    ''' <summary>
    ''' Password: Enter triggers login attempt.
    ''' </summary>
    Private Sub txtPassword_KeyPress(sender As Object,
        e As KeyPressEventArgs) Handles txtPassword.KeyPress

        If e.KeyChar = Chr(13) Then
            DoLogin()
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' Block Ctrl+V paste on username to avoid injecting
    ''' special characters.
    ''' </summary>
    Private Sub txtUsername_KeyDown(sender As Object,
        e As KeyEventArgs) Handles txtUsername.KeyDown

        If e.Control AndAlso e.KeyCode = Keys.V Then
            e.SuppressKeyPress = True
        End If
    End Sub

    '══════════════════════════════════════════════════════════
    ' LOGIN BUTTON
    '══════════════════════════════════════════════════════════
    Private Sub btnLogin_Click(sender As Object,
        e As EventArgs) Handles btnLogIn.Click
        DoLogin()
    End Sub

    '══════════════════════════════════════════════════════════
    ' CORE LOGIN LOGIC
    '══════════════════════════════════════════════════════════
    Private Sub DoLogin()
        ' Ignore while locked
        If _lockCountdown > 0 Then
            MessageBox.Show(
                "System is locked. Please wait " &
                _lockCountdown & " second(s).",
                "Locked",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
            Return
        End If

        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        ' Empty field guard
        If username = "" OrElse password = "" Then
            MessageBox.Show(
                "Please enter both username and password.",
                "Input Required",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning)
            Return
        End If

        ' Check against Accounts table
        If IsValidAccount(username, password) Then
            '── Success ──────────────────────────────
            _attempts = 0
            Me.Hide()
            Dim main As New MainForm()
            main.Show()
        Else
            '── Failed attempt ────────────────────────
            _attempts += 1
            txtPassword.Clear()
            txtPassword.Focus()

            Dim remaining As Integer = MAX_ATTEMPTS - _attempts

            If remaining > 0 Then
                lblAttempts.Text =
                    "Attempts remaining: " & remaining
                MessageBox.Show(
                    "Invalid username or password." &
                    Environment.NewLine &
                    "You have " & remaining & " attempt(s) left.",
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
            Else
                LockSystem()
            End If
        End If
    End Sub

    '══════════════════════════════════════════════════════════
    ' DATABASE CHECK — Accounts table
    '══════════════════════════════════════════════════════════
    Private Function IsValidAccount(username As String,
                                    password As String) As Boolean
        Try
            Dim query As String =
                "SELECT COUNT(*) FROM Accounts " &
                "WHERE Username = @u AND Password = @p"

            Dim result As Object = DataBaseHelper.GetScalar(
                query,
                New Dictionary(Of String, Object) From {
                    {"@u", username},
                    {"@p", password}
                })

            Return CInt(result) > 0

        Catch ex As Exception
            MessageBox.Show(
                "Database error: " & ex.Message,
                "Connection Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    '══════════════════════════════════════════════════════════
    ' LOCKDOWN — triggers after 3 failed attempts
    '══════════════════════════════════════════════════════════
    Private Sub LockSystem()
        _lockCountdown = LOCK_SECONDS

        ' Disable all inputs
        txtUsername.Enabled = False
        txtPassword.Enabled = False
        btnLogIn.Enabled = False

        ' Show lock UI
        lblAttempts.Text = "ACCOUNT LOCKED"
        lblAttempts.ForeColor = Color.Red
        lblLockMsg.Text =
            "Too many failed attempts. " &
            "Locked for " & _lockCountdown & "s."
        lblLockMsg.Visible = True

        Timer1.Start()

        MessageBox.Show(
            "Too many invalid attempts." &
            Environment.NewLine &
            "The system will be locked for 60 seconds.",
            "System Locked",
            MessageBoxButtons.OK,
            MessageBoxIcon.Stop)
    End Sub

    '══════════════════════════════════════════════════════════
    ' COUNTDOWN TIMER  (Interval = 1000ms)
    '══════════════════════════════════════════════════════════
    Private Sub Timer1_Tick(sender As Object,
        e As EventArgs) Handles Timer1.Tick

        _lockCountdown -= 1
        lblLockMsg.Text =
            "System locked. Unlocking in " &
            _lockCountdown & "s..."

        If _lockCountdown <= 0 Then
            Timer1.Stop()
            _attempts = 0
            _lockCountdown = 0
            ResetUI()

            MessageBox.Show(
                "System unlocked. You may try again.",
                "Unlocked",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information)
        End If
    End Sub

    '══════════════════════════════════════════════════════════
    ' RESET UI — used on load and after lockdown ends
    '══════════════════════════════════════════════════════════
    Private Sub ResetUI()
        txtUsername.Enabled = True
        txtPassword.Enabled = True
        btnLogIn.Enabled = True

        txtUsername.Clear()
        txtPassword.Clear()

        lblAttempts.Text = "Attempts remaining: " & MAX_ATTEMPTS
        lblAttempts.ForeColor = SystemColors.ControlText
        lblLockMsg.Visible = False

        txtUsername.Focus()
    End Sub
    Private Sub pnlHeader_Paint(sender As Object, e As PaintEventArgs) Handles pnlHeader.Paint
        Dim borderColor As New Pen(ColorTranslator.FromHtml("#FDF5E6"), 3)
        e.Graphics.DrawRectangle(borderColor, 0, 0, pnlHeader.Width - 1, pnlHeader.Height - 1)
        borderColor.Dispose()

        Dim dividerPen As New Pen(ColorTranslator.FromHtml("#C8A96E"), 1)
        e.Graphics.DrawLine(dividerPen, 15, Label6.Bottom + 8, Panel2.Width - 18, Label6.Bottom + 8)
        dividerPen.Dispose()


    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Dim borderColor As New Pen(ColorTranslator.FromHtml("#FDF5E6"), 6)
        e.Graphics.DrawRectangle(borderColor, 0, 0, Panel1.Width - 1, Panel1.Height - 1)
        borderColor.Dispose()
        Dim dividerPen As New Pen(ColorTranslator.FromHtml("#C8A96E"), 1)
        e.Graphics.DrawLine(dividerPen, 15, Label2.Bottom + 40, Panel2.Width - 30, Label2.Bottom + 40)
        dividerPen.Dispose()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        lblAttempts.Left = (Panel2.Width - lblAttempts.Width) \ 2
        lblAttempts.Top = (Panel2.Height - lblAttempts.Height) \ 2 + 20
    End Sub

End Class
