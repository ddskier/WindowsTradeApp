Imports System.Data.SqlClient

'This Form Uses ADO.NET Entity Framework, a more "factored" approach toi database access with auto-built model classes 
Public Class Holdings

    Public Sub LoadGrid()
        ' Initialize the DbContext
        Using holdingContext As New ACCOUNTDBEntities
            ' Query the database for all holdings

            ' Assuming "userid" is a variable containing the user's ID you're interested in
            Dim parameter = New SqlParameter("@userId", GlobalSettings.theLoginAccount.UserID)

            ' Correct the DbSet if necessary. Here, it's assumed to be HOLDINGs
            ' Execute the SQL query using a parameterized query for safety
            Dim query = holdingContext.HOLDINGs.SqlQuery("SELECT * FROM dbo.HOLDING WHERE USERID = @userId", parameter)

            ' Materialize the results into a List (or another suitable collection)
            Dim result As List(Of HOLDING) = query.ToList()

            DataGridView1.DataSource = result


            ' Set the DataGridView's data source to the DbSet of Employees
            'DataGridView1.DataSource = (holdingContext.ACCOUNTPROFILEs.SqlQuery("SELECT * FROM dbo.HOLDING WHERE USERID = @userId", parameter).ToList())
            'DataGridView1.Columns("Symbol").DisplayIndex = 0
            ' DataGridView1.Columns("CompanyName").DisplayIndex = 1
        End Using

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If GlobalSettings.LoggedIn Then

            LoadGrid()

            Me.Label1.Text = "Hello " + GlobalSettings.theLoginAccount.Name + "! These are Your Current Holdings, Select one to Sell."



        Else
            MsgBox("You Must Login First, to see your Holdings and Sell Stock!")

        End If
    End Sub

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddHandler Me.FormClosing, AddressOf Form1_FormClosing
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        If GlobalSettings.LoggedIn Then




            ' Check if the click is on a row, not the column header
            If e.RowIndex >= 0 Then
                ' Access the clicked row
                Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
                SellForm.Show()
                SellForm.SellForm_Sell(Me, row, e)

            End If
        Else
            MsgBox("You Must Login Before Selecting a Stock to Buy")

        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs)
        ' Check your condition here. This is just an example condition.
        Dim allowClose As Boolean = GlobalSettings.LoggedIn ' Assume this is your condition

        If allowClose Then
            MessageBox.Show("Condition not met, form will not close.")
            e.Cancel = True ' Prevent the form from closing
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()

    End Sub
End Class