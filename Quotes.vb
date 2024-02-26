Imports System.Data.Entity ' Import Entity Framework namespace
'This Form Uses ADO.NET Entity Framework, a more "factored" approach toi database access with auto-built model classes 
'It uses a DatagridView VB.NET Control
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If GlobalSettings.LoggedIn Then
            Label2.Text = "You Are Logged in as " + GlobalSettings.theLoginAccount.UserID
            Label2.Visible = True
            Label1.Text = "Click a Row to Buy a Stock"

        Else
            Label1.Text = "You are Not Logged In, So Cannot Buy"
            Label2.Text = "Not Logged In, Please Login to Be Able to Place a Trade"
        End If

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If GlobalSettings.LoggedIn Then




            ' Check if the click is on a row, not the column header
            If e.RowIndex >= 0 Then
                ' Access the clicked row
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                BuyForm.Show()
                BuyForm.Form2_Buy(row, e)




                ' Example: Display the value of the first cell in the row
                ' MessageBox.Show("Buy Stock: " & row.Cells("Symbol").Value.ToString())
            End If
        Else
            MsgBox("You Must Login Before Selecting a Stock to Buy")

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        ' Initialize the DbContext
        Using context As New QUOTEDBEntities()
            ' Query the database for all employees
            context.QUOTEs.Load()

            ' Set the DataGridView's data source to the DbSet of Employees
            DataGridView1.DataSource = context.QUOTEs.Local.ToBindingList()
            DataGridView1.Columns("Symbol").DisplayIndex = 0
            DataGridView1.Columns("CompanyName").DisplayIndex = 1
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub
End Class