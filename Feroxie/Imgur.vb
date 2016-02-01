Imports System.Threading
Imports System.Text
Imports System.IO
Imports System.Net

Public Class Imgur
    Dim thread As System.Threading.Thread
    Private Sub XylosButton1_Click(sender As Object, e As EventArgs) Handles XylosButton1.Click
        Try
            If OpenFileDialog1.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                TextBox1.Text = OpenFileDialog1.FileName
                    PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
            End If
        Catch ex As Exception
            MessageBox.Show("Error")
        End Try
    End Sub
    Dim ClientId As String = "18931b2a8a62667"
    Public Function UploadImage(ByVal image As String)
        Dim w As New WebClient()
        w.Headers.Add("Authorization", "Client-ID " & ClientId)
        Dim Keys As New System.Collections.Specialized.NameValueCollection
        Try
            Keys.Add("image", Convert.ToBase64String(File.ReadAllBytes(image)))
            Dim WhoSoup As Byte() = w.UploadValues("https://api.imgur.com/3/image", Keys)
            Dim QQ = Encoding.ASCII.GetString(WhoSoup)
            Dim reg As New System.Text.RegularExpressions.Regex("link"":""(.*?)""")
            Dim match As RegularExpressions.Match = reg.Match(QQ)
            Dim url As String = match.ToString.Replace("link"":""", "").Replace("""", "").Replace("\/", "/")
            Return url
        Catch Erro As Exception
            MessageBox.Show("Something went wrong. " & Erro.Message)
            Return "Failed!"
        End Try
    End Function
    Private Sub uploadimagex()
        Try
            Dim url As String = UploadImage(TextBox1.Text)
            LinkLabel1.Text = (url)
            Process.Start(LinkLabel1.Text)
            XylosButton2.Text = "Upload"
            XylosButton2.Enabled = True
        Catch ex As Exception

        End Try
    End Sub
    Private Sub XylosButton2_Click(sender As Object, e As EventArgs) Handles XylosButton2.Click
        XylosButton2.Text = "Uploading"
        XylosButton2.Enabled = False
        thread = New System.Threading.Thread(AddressOf uploadimagex)
        thread.Start()
    End Sub

    Private Sub Imgur_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            Process.Start(LinkLabel1.Text)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If PictureBox1.Image Is Nothing Then
            XylosButton2.Visible = False
        Else
            XylosButton2.Visible = True
        End If
    End Sub
End Class