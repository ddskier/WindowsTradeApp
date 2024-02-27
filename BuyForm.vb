'This Form Uses ADO.NET Entity Framework, a more "factored" approach toi database access with auto-built model classes 

Public Class BuyForm
    Dim symbol As String
    Dim row As DataGridViewRow

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = False


    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub

    Public Sub Form2_Buy(theRow As DataGridViewRow, e As EventArgs)
        Me.Show()
        Me.BringToFront()
        row = theRow

        symbol = row.Cells("Symbol").Value

        Label1.Text = "Select the Number of Shares to Buy for Symbol " + symbol


    End Sub
    Private Sub NumShares_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles NumShares.Validating
        Dim input As String = NumShares.Text ' Get the input from the text box
        Dim number As Integer ' Declare a variable to store the parsed integer
        If Not Integer.TryParse(input, number) Then ' Try to parse the input as an integer
            e.Cancel = True ' Cancel the validation if the input is not an integer
            NumShares.BackColor = Color.Red ' Change the background color of the text box to red
            MessageBox.Show("Please enter a valid integer.") ' Show an error message
        Else
            NumShares.BackColor = SystemColors.Window ' Restore the default background color of the text box
        End If
    End Sub

    Private Sub Buy_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim stock As New Stock
        Dim sharestobuy As String = NumShares.Text ' Assume TextBox1 is your input control
        stock.Buy(row, symbol, Integer.Parse(sharestobuy))
        Me.NumShares.Text = ""
        Me.Hide()



    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class