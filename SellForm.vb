Imports System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder
Imports System.Reflection.Emit
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
'This Form Uses ADO.NET Entity Framework, a more "factored" approach toi database access with auto-built model classes 
Public Class SellForm
    Dim quantityHeld As Double
    Dim symbol As String
    Dim row As DataGridViewRow
    Dim theHoldingForm As Holdings
    Private Sub SellForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Visible = False


    End Sub

    Public Sub SellForm_Sell(thisHoldingForm As Holdings, theRow As DataGridViewRow, e As EventArgs)
        Me.Show()
        Me.BringToFront()
        row = theRow

        symbol = row.Cells("Quote_Symbol").Value
        quantityHeld = row.Cells("Quantity").Value

        Label1.Text = "Select the Number of Shares to Sell for Symbol " + symbol
        theHoldingForm = thisHoldingForm



    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        Me.Hide()
    End Sub

    Private Sub SharesSell_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SharesSell.Validating
        Dim input As String = SharesSell.Text ' Get the input from the text box
        Dim number As Integer ' Declare a variable to store the parsed integer
        If Not Integer.TryParse(input, number) Then ' Try to parse the input as an integer
            e.Cancel = True ' Cancel the validation if the input is not an integer
            SharesSell.BackColor = Color.Red ' Change the background color of the text box to red
            MessageBox.Show("Please enter a valid integer.") ' Show an error message
        Else
            If number > quantityHeld Then
                e.Cancel = True ' Cancel the validation if the input is not an integer
                SharesSell.BackColor = Color.Red ' Change the background color of the text box to red
                MessageBox.Show("You only Hold " + quantityHeld.ToString())
            Else
                SharesSell.BackColor = SystemColors.Window ' Restore the default background color of the text box
            End If

        End If
    End Sub

    Private Sub SellButton_Click(sender As Object, e As EventArgs) Handles SellButton.Click
        Dim stock As New Stock
        Dim sharestosell As String = SharesSell.Text
        stock.Sell(row, symbol, Integer.Parse(sharestosell))
        Me.SharesSell.Text = ""
        Me.Hide()
        theHoldingForm.LoadGrid()





    End Sub
End Class