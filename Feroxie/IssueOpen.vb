Imports System.Text
Imports System.Net.Mail
Imports System.Threading
Public Class IssueOpen
    Dim thread As System.Threading.Thread
    Private Sub IssueOpen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        TextBox2.Text = Form1.TextBox1.Text
    End Sub
    Private Sub SendMail()
        Dim Mail As New MailMessage
        Dim SMTP As New SmtpClient("smtp.gmail.com")

        Mail.Subject = "Feroxie Report"
        Mail.From = New MailAddress("ferddodsfxiessufpportxpzx@gmail.com")
        SMTP.Credentials = New System.Net.NetworkCredential("ferddodsfxiessufpportxpzx@gmail.com", "Configuration1@")

        Mail.To.Add("ferddodsfxiessufpportxpzx@gmail.com")

        Mail.Body = TextBox1.Text = " " + TextBox2.Text + " " + TextBox3.Text

        SMTP.EnableSsl = True
        SMTP.Port = "587"
        SMTP.Send(Mail)

    End Sub

    Private Sub XylosButton2_Click(sender As Object, e As EventArgs) Handles XylosButton2.Click
        Me.Close()
    End Sub

    Private Sub XylosButton1_Click(sender As Object, e As EventArgs) Handles XylosButton1.Click
        XylosButton1.Enabled = False
        XylosButton1.Text = "Sent"
        thread = New System.Threading.Thread(AddressOf SendMail)
        thread.Start()
    End Sub
End Class