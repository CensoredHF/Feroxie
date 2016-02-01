Imports System.Threading
Imports System.Net

Public Class About
    Dim thread As System.Threading.Thread
    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        thread = New System.Threading.Thread(AddressOf GetVersion)
        thread.Start()
    End Sub
    Private Sub GetVersion()
        Try
            If My.Computer.Network.IsAvailable = False Then
                PictureBox2.Image = My.Resources._1449865974_Cancel
                Label3.Text = "No Internet connection."
            ElseIf My.Computer.Network.IsAvailable = True Then
                Dim client As WebClient = New WebClient()
                Dim reply As String = client.DownloadString("https://www.dropbox.com/s/kuxjnibv6btifmh/VersionNumber.txt?dl=1")
                Label3.Text = reply
                PictureBox2.BackgroundImageLayout = ImageLayout.Zoom
                PictureBox2.Image = My.Resources._1449865922_tick_blue
            End If
        Catch ex As Exception
            Label3.Text = "Error()"
        End Try
    End Sub

    Private Sub XylosButton1_Click(sender As Object, e As EventArgs) Handles XylosButton1.Click
        IssueOpen.Show()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("https://en.wikipedia.org/wiki/DuckDuckGo")
    End Sub
End Class