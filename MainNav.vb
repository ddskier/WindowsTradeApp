Public Class MainNav

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GlobalSettings.LoggedIn = False


    End Sub
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Form1.Show()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        If GlobalSettings.LoggedIn Then
            MsgBox("You are now Logged Out!")
            GlobalSettings.LoggedIn = False
            Login.PasswordTextBox.Text = ""
            Login.UserIDTextBox.Text = ""
        Else
            Login.Show()

        End If

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        If GlobalSettings.LoggedIn Then
            Dim holdingsForm As New Holdings()
            holdingsForm.Show()
        Else
            MsgBox("You Must Login First!")
        End If


    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        If GlobalSettings.LoggedIn Then
            Dim accountForm As New AccountForm()
            accountForm.Show()
        Else
            MsgBox("You Must Login First!")
        End If
    End Sub
End Class