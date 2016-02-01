Public Class Settings
    Dim newbrowser As String = String.Empty
    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            newbrowser = ComboBox1.Text
            ComboBox1.Items.Add(ComboBox1.Text)
            ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
            If ComboBox1.Items.Contains(newbrowser) Then
                ComboBox1.Text = newbrowser
                My.Settings.DefaultStart = ComboBox1.Text
                My.Settings.Save()
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Other" Then
            ComboBox1.DropDownStyle = ComboBoxStyle.DropDown
        Else
            My.Settings.DefaultStart = ComboBox1.Text
            My.Settings.Save()
        End If
    End Sub

    Private Sub Settings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.Save()
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If ComboBox1.Items.Contains("duckduckgo.com") Then
            ComboBox1.Text = "duckduckgo.com"
        End If
        If ComboBox2.Items.Contains("") Then
            ComboBox2.Text = "Default "
        End If
        If ComboBox3.Items.Contains("Remember History") Then
            ComboBox3.Text = "Remember History"
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "Firefox" Then   
            My.Settings.One = "1"
            My.Settings.Save()
            Label3.Text = "Restart to apply"
        ElseIf ComboBox2.Text = "Chrome" Then
            My.Settings.One = "2"
            My.Settings.Save()
            Label3.Text = "Restart to apply"
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            My.Settings.Two = "1"
            My.Settings.Save()
        ElseIf CheckBox1.Checked = False Then
            My.Settings.Two = "0"
            My.Settings.Save()
        End If
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.Text = "Remember History" Then
            My.Settings.Boom = "1"
            My.Settings.Save()
        ElseIf ComboBox3.Text = "Never remember history" Then
            My.Settings.Boom = "0"
            My.Settings.Save()
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            My.Settings.Status = "1"
            My.Settings.Save()
        ElseIf CheckBox2.Checked = False Then
            My.Settings.Status = "0"
            My.Settings.Save()
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            My.Settings.Secure = "1"
            My.Settings.Save()
        ElseIf CheckBox3.Checked = False Then
            My.Settings.Secure = "0"
            My.Settings.Save()
        End If
    End Sub
End Class