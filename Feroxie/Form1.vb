Imports System.Runtime.InteropServices
Imports System.Net
Imports System.Threading
Public Class Form1
    

    Dim browser As String = String.Empty
    Dim firefox As String = String.Empty
    Dim thread As System.Threading.Thread
    Public Declare Function GetAsyncKeyState Lib "user32.dll" (ByVal key As Integer) As Integer
    <DllImport("urlmon.dll", CharSet:=CharSet.Ansi)> _
    Private Shared Function UrlMkSetSessionOption(ByVal dwOption As Integer, ByVal pBuffer As String, ByVal dwBufferLength As Integer, ByVal dwReserved As Integer) As Integer
    End Function
    Const URLMON_OPTION_USERAGENT As Integer = &H10000001

    Public Function ChangeUserAgent(ByVal Agent As String)
        UrlMkSetSessionOption(URLMON_OPTION_USERAGENT, Agent, Agent.Length, 0)
        #End Function

    Private Sub TabControl1_Selected(sender As Object, e As TabControlEventArgs) _
     Handles TabControl1.Selected

        Dim messageBoxVB As New System.Text.StringBuilder()
        messageBoxVB.AppendFormat("{0} = {1}", "TabPage", e.TabPage)
        messageBoxVB.AppendLine()
        messageBoxVB.AppendFormat("{0} = {1}", "TabPageIndex", e.TabPageIndex)
        messageBoxVB.AppendLine()
        messageBoxVB.AppendFormat("{0} = {1}", "Action", e.Action)
        messageBoxVB.AppendLine()
        If TabControl1.SelectedTab.Text = "New Tab" Then
            ' MsgBox("XD")
            TabControl1.SelectedTab.Text = "about:blank"
        End If

    End Sub
   
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            ProceedRequest()
        End If
    End Sub
    Private Sub WebBrowser1_EncryptionLevelChanged(sender As Object, e As EventArgs) _
     Handles WebBrowser1.EncryptionLevelChanged

        Label2.Text = (WebBrowser1.EncryptionLevel.ToString)

    End Sub
    Private Sub XylosButton4_Click(sender As Object, e As EventArgs) Handles XylosButton4.Click
        ProceedRequest()
    End Sub
    Private Sub ProceedRequest()
        '"_self", Nothing, "User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64; rv:43.0) Gecko/20100101 Firefox/43.0"
        If TextBox1.Text.Contains(".") Then
            If My.Settings.Secure = "1" Then
                WebBrowser1.Navigate(TextBox1.Text + ".prx2.unblocksit.es")
            ElseIf My.Settings.Secure = "0" Then
                WebBrowser1.Navigate(TextBox1.Text)
            End If
            If Settings.ComboBox2.Text = "Default " Then
                WebBrowser1.Navigate(TextBox1.Text)
            ElseIf Settings.ComboBox3.Text = "" Then
                WebBrowser1.Navigate(TextBox1.Text)
            ElseIf My.Settings.One = "1" Then '// If It's one 1 that means firefox is set to the useragent.
                WebBrowser1.Navigate(TextBox1.Text, "_self", Nothing, "User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64; rv:43.0) Gecko/20100101 Firefox/43.0")
            ElseIf My.Settings.One = "2" Then
                WebBrowser1.Navigate(TextBox1.Text, "_self", Nothing, "User-Agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.86 Safari/537.36")
            End If
        Else
            WebBrowser1.Navigate("https://duckduckgo.com/?q=" + TextBox1.Text)
        End If
    End Sub


    Private Sub XylosButton3_Click(sender As Object, e As EventArgs) Handles XylosButton3.Click
        WebBrowser1.Refresh()
    End Sub

    Private Sub XylosButton2_Click(sender As Object, e As EventArgs) Handles XylosButton2.Click
        WebBrowser1.GoForward()
    End Sub

    Private Sub XylosButton1_Click(sender As Object, e As EventArgs) Handles XylosButton1.Click
        WebBrowser1.GoBack()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        PageEncryption.Visible = True
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Label3.ForeColor = Color.DeepPink
        PageEncryption.Visible = False
    End Sub
    Private Sub Label3_MouseEnter(sender As Object, e As EventArgs) Handles Label3.MouseEnter
        Label3.ForeColor = Color.Crimson
    End Sub

    Private Sub Label3_MouseLeave(sender As Object, e As EventArgs) Handles Label3.MouseLeave
        Label3.ForeColor = Color.Red
    End Sub

    Private Sub CheckEncryption_Tick(sender As Object, e As EventArgs) Handles CheckEncryption.Tick
        If Label2.Text = "Insecure" Then
            PictureBox2.BackColor = Color.Red
        ElseIf Label2.Text = "Mixed" Then
            PictureBox2.BackColor = Color.Gray
        ElseIf Label2.Text = "Unknown" Then
            PictureBox2.BackColor = Color.SaddleBrown
        ElseIf Label2.Text = "Bit128" Then
            PictureBox2.BackColor = Color.Lime
        ElseIf Label2.Text = "Bit40" Then
            PictureBox2.BackColor = Color.Lime
        ElseIf Label2.Text = "Bit56" Then
            PictureBox2.BackColor = Color.Lime
        ElseIf Label2.Text = "Fortezza" Then
            PictureBox2.BackColor = Color.Lime
        End If

    End Sub

    Private Sub TextBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseClick
        If TextBox1.Text = "Enter Url Or Search" Then
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If Browsermenu.Visible = True Then
            Browsermenu.Visible = False
            DownloadTab.Visible = True
        ElseIf Browsermenu.Visible = False Then
            DownloadTab.Visible = True
        End If
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Label4.ForeColor = Color.DeepPink
        DownloadTab.Visible = False
    End Sub
    Private Sub Label4_MouseEnter(sender As Object, e As EventArgs) Handles Label4.MouseEnter
        Label4.ForeColor = Color.Crimson
    End Sub

    Private Sub Label4_MouseLeave(sender As Object, e As EventArgs) Handles Label4.MouseLeave
        Label4.ForeColor = Color.Red
    End Sub
    Private Sub WebBrowser1_FileDownload(sender As Object, e As EventArgs) _
     Handles WebBrowser1.FileDownload

        '  MessageBox.Show("You are in the WebBrowser.FileDownload event.")

    End Sub
    Private Sub Window_Error(ByVal sender As Object, _
    ByVal e As HtmlElementErrorEventArgs)

        e.Handled = True

    End Sub
    Private Sub WebBrowser1_DocumentCompleted(sender As Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        AddHandler CType(sender, WebBrowser).Document.Window.Error, _
     AddressOf Window_Error
        Label5.Text = WebBrowser1.Url.Authority
        Label7.Text = WebBrowser1.Url.HostNameType.ToString
        If My.Settings.Boom = "1" Then
            History.ListBox1.Items.Add(DateTime.Now + " : " + Label5.Text)
        Else
        End If
      

        thread = New System.Threading.Thread(AddressOf GetWebpage)
        thread.Start()

    End Sub
    Private Sub GetWebpage()
        Dim client As WebClient = New WebClient()
        Dim reply As String = client.DownloadString("http://api.predator.wtf/host2ip/?arguments=" + Label5.Text)
        Label10.Text = reply
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If GetAsyncKeyState(Keys.F5) <> 0 Then
            WebBrowser1.Refresh()
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        If DownloadTab.Visible = True Then
            DownloadTab.Visible = False
            Browsermenu.Visible = True
        ElseIf DownloadTab.Visible = False Then
            Browsermenu.Visible = True
        End If
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Label9.ForeColor = Color.DeepPink
        Browsermenu.Visible = False
    End Sub
    Private Sub Label9_MouseEnter(sender As Object, e As EventArgs) Handles Label9.MouseEnter
        Label9.ForeColor = Color.Crimson
    End Sub

    Private Sub Label9_MouseLeave(sender As Object, e As EventArgs) Handles Label9.MouseLeave
        Label9.ForeColor = Color.Red
    End Sub
    Private Sub WebBrowser1_NewWindow(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles WebBrowser1.NewWindow
        ' Prevent opening a new windows
        e.Cancel = True
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Settings.CheckBox1.Checked = True Then
            e.Cancel = True
            Dim result As Integer = MessageBox.Show("Would you like the exit Feroxie?", "Exit", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.No Then

            ElseIf result = DialogResult.Yes Then
                End
            End If
        End If
    End Sub
    Private Sub webBrowser1_StatusTextChanged( _
    ByVal sender As Object, ByVal e As EventArgs) _
    Handles WebBrowser1.StatusTextChanged

        If Settings.CheckBox2.Checked = True Then
            Me.Text = "Feroxie - Status : " + (WebBrowser1.StatusText)
        ElseIf Settings.CheckBox2.Checked = False Then

        End If
    End Sub
    Private Sub WebBrowser1_ProgressChanged(sender As Object, e As WebBrowserProgressChangedEventArgs) _
     Handles WebBrowser1.ProgressChanged

        PictureBox5.Visible = True
        If e.CurrentProgress = e.MaximumProgress = True Then
            PictureBox5.Visible = False
        End If


    End Sub
    Private Sub checkimgur()
        '// Check's If Imgur plugin Is on/off
        If My.Settings.Imgur = "1" Then ' On
            PictureBox7.Visible = True
        ElseIf My.Settings.Imgur = "0" Then ' Off
            PictureBox7.Visible = False
        End If
    End Sub
    Private Sub checkstatus()
        If My.Settings.Status = "1" Then
            Settings.CheckBox2.Checked = True
        ElseIf My.Settings.Status = "0" Then
            Settings.CheckBox2.Checked = False
        End If
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        checkimgur()
        checkstatus()
        If My.Settings.One = "1" Then
            Settings.ComboBox2.Text = "Firefox"
        End If
        Control.CheckForIllegalCrossThreadCalls = False
        If Settings.ComboBox1.Text = "" Then
            WebBrowser1.Navigate("duckduckgo.com")
        Else
            '// needs to be fixed
            My.Settings.DefaultStart = browser
            WebBrowser1.Navigate(browser)
        End If
        If My.Settings.Two = "1" Then
            Settings.CheckBox1.Checked = True
        ElseIf My.Settings.Two = "0" Then
            Settings.CheckBox1.Checked = False
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedItem = "New tab" Then
            Dim tab As New TabPage
            Dim brws As New WebBrowser
            brws.Dock = DockStyle.Fill
            tab.Text = " New Tab"
            tab.Controls.Add(brws)
            Me.TabControl1.TabPages.Add(tab)
            Me.TabControl1.SelectedTab = tab
            brws.Navigate("http://duckduckgo.com")
            Browsermenu.Visible = False
        ElseIf ListBox1.SelectedItem = "New window" Then
            Dim exePath As String = Application.ExecutablePath()
            Process.Start(exePath)
            Browsermenu.Visible = False
        ElseIf ListBox1.SelectedItem = "New incognito window" Then
            Settings.ComboBox3.Text = "Never remember history"
            Browsermenu.Visible = False
            Me.Text = "Feroxie - Incognito Mode"
            Me.Icon = (My.Resources.BLACK_90491)
        ElseIf ListBox1.SelectedItem = "History and recent tabs" Then
            History.Show()
            Browsermenu.Visible = False
        ElseIf ListBox1.SelectedItem = "Downloads" Then
            History.Show()
            History.XylosTabControl1.SelectTab(2)
            Browsermenu.Visible = False
        ElseIf ListBox1.SelectedItem = "Bookmarks" Then
            History.XylosTabControl1.SelectTab(1)
            History.Show()
            Browsermenu.Visible = False
        ElseIf ListBox1.SelectedItem = "Find" Then
            Find.Show()
            Browsermenu.Visible = False
        ElseIf ListBox1.SelectedItem = "Settings" Then
            Settings.Show()
            Browsermenu.Visible = False
        ElseIf ListBox1.SelectedItem = "About" Then
            About.Show()
        ElseIf ListBox1.SelectedItem = "Exit" Then
            End
        End If

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        If History.ListBox2.Items.Contains(TextBox1.Text) = True Then ' It's already there so we don't bookmark it again.

        ElseIf History.ListBox2.Items.Contains(TextBox1.Text) = False Then
            PictureBox6.Image = My.Resources._1453754479_icon_18_bookmark___Copy
            History.ListBox2.Items.Add(TextBox1.Text)
        End If
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Imgur.Show()
    End Sub

    Private Sub XylosButton5_Click(sender As Object, e As EventArgs) Handles XylosButton5.Click
        DownloadTab.Visible = False
        History.Show()
        History.XylosTabControl1.SelectTab(2)
    End Sub
End Class
