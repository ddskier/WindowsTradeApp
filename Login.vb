'This Form Uses ADO.NET Entity Framework, a more "factored" approach toi database access with auto-built model classes 

Public Class Login

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub
    Private Sub LogInButton_Click(sender As Object, e As EventArgs) Handles LogInButton.Click
        Dim thisAccount As New AccountCurrent

        thisAccount = thisAccount.Login(UserIDTextBox.Text, PasswordTextBox.Text)
        If GlobalSettings.LoggedIn = False Then
            MsgBox("Login Failed for " + UserIDTextBox.Text + ". Try Again")
            GlobalSettings.theLoginAccount = Nothing
        Else
            MsgBox("Login Success for " + UserIDTextBox.Text + ". AccountID is " + thisAccount.AccountID.ToString)
            GlobalSettings.theLoginAccount = thisAccount

        End If
        Me.Hide()

    End Sub
End Class