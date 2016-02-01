Imports System.Threading
Imports System.Net.Mail

Public Class History
    Dim Bookie As String = String.Empty
    Dim thread As System.Threading.Thread
    Private Sub XylosButton2_Click(sender As Object, e As EventArgs) Handles XylosButton2.Click
        ListBox1.Items.Clear()
    End Sub

    Private Sub XylosButton1_Click(sender As Object, e As EventArgs) Handles XylosButton1.Click
        Dim Save As New SaveFileDialog()
        Save.Filter = "Text [*.txt*]|*.txt|All Files [*.*]|*.*"
        Save.CheckPathExists = True
        Save.Title = "Save File"
        Save.ShowDialog(Me)
        Try
            Dim SaveHistory As String = Save.FileName
            Dim FileNumber As Integer = FreeFile()
            FileOpen(FileNumber, Save.FileName, OpenMode.Output)
            For Each Item As Object In ListBox1.Items
                PrintLine(FileNumber, Item.ToString)
            Next
            FileClose(FileNumber)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        Dim values As New List(Of String)
        For Each item As String In ListBox2.Items
            values.Add(item)
        Next
        My.Settings.Book = String.Join("|", values.ToArray)
        My.Settings.Save()
    End Sub

    Private Sub History_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Dim values As String = My.Settings.Book
        If values <> "" Then
            ListBox2.Items.AddRange(values.Split("|"))
        End If
        If My.Settings.Imgur = "1" Then
            ComboBox1.Text = "On"
        ElseIf My.Settings.Imgur = "0" Then
            ComboBox1.Text = "Off"
        End If
    End Sub

    Private Sub XylosButton3_Click(sender As Object, e As EventArgs) Handles XylosButton3.Click
        ListBox2.Items.Clear()
    End Sub

    Private Sub XylosButton4_Click(sender As Object, e As EventArgs) Handles XylosButton4.Click
        Dim Save As New SaveFileDialog()
        Save.Filter = "Text [*.txt*]|*.txt|All Files [*.*]|*.*"
        Save.CheckPathExists = True
        Save.Title = "Save File"
        Save.ShowDialog(Me)
        Try
            Dim SaveHistory As String = Save.FileName
            Dim FileNumber As Integer = FreeFile()
            FileOpen(FileNumber, Save.FileName, OpenMode.Output)
            For Each Item As Object In ListBox2.Items
                PrintLine(FileNumber, Item.ToString)
            Next
            FileClose(FileNumber)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub XylosButton5_Click(sender As Object, e As EventArgs) Handles XylosButton5.Click
        Try
            If OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                Dim lines() As String = IO.File.ReadAllLines(OpenFileDialog1.FileName)
                ListBox2.Items.AddRange(lines)
            End If
        Catch ex As Exception
            MessageBox.Show("Error")
        End Try
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        ImgurSource.Show()
    End Sub
    Private Sub SendPlugin()
        Dim Mail As New MailMessage
        Dim SMTP As New SmtpClient("smtp.gmail.com")

        Mail.Subject = "Feroxie Report"
        Mail.From = New MailAddress("ferddodsfxiessufpportxpzx@gmail.com")
        SMTP.Credentials = New System.Net.NetworkCredential("ferddodsfxiessufpportxpzx@gmail.com", "Configuration1@")

        Mail.To.Add("ferddodsfxiessufpportxpzx@gmail.com")

        Mail.Body = TextBox3.Text = " " + TextBox2.Text + " " + TextBox1.Text

        SMTP.EnableSsl = True
        SMTP.Port = "587"
        SMTP.Send(Mail)
    End Sub
    Private Sub XylosButton6_Click(sender As Object, e As EventArgs) Handles XylosButton6.Click
        XylosButton6.Enabled = False
        XylosButton6.Text = "Thank you."
        thread = New System.Threading.Thread(AddressOf SendPlugin)
        thread.Start()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "On" Then
            My.Settings.Imgur = "1"
            My.Settings.Save()
        ElseIf ComboBox1.Text = "Off" Then
            My.Settings.Imgur = "0"
            My.Settings.Save()
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ListBox3.Items.Clear()
    End Sub
End Class