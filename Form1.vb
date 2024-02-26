Imports System.Data.Entity ' Import Entity Framework namespace

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.Columns("Symbol").DisplayIndex = 0


    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Initialize the DbContext
        Using context As New QUOTEDBEntities()
            ' Query the database for all employees
            context.QUOTEs.Load()

            ' Set the DataGridView's data source to the DbSet of Employees
            DataGridView1.DataSource = context.QUOTEs.Local.ToBindingList()
        End Using
    End Sub
End Class