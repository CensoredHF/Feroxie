Public Class Find

    Private Sub XylosButton1_Click(sender As Object, e As EventArgs) Handles XylosButton1.Click
        If Form1.WebBrowser1.DocumentText.ToLower.Contains(TextBox1.Text.ToLower) Then
            MessageBox.Show("Found")
            Form1.Browsermenu.Visible = False
        Else
            MessageBox.Show("Not found")
            Form1.Browsermenu.Visible = False
        End If
    End Sub
End Class