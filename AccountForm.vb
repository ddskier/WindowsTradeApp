Imports System.Data.Entity.Core
Imports System.Data.SqlClient
Imports System.Configuration

' This VB Form Is Built Using Pure ADO.NET, with No Model Classes for Database or use of the Entity Framework, or Business Logic Classes 
' It illustrates a more manual/spagetti approach in a Win Forms App, to test migration via ChatGPT to Blazor/Razor and C#


Public Class AccountForm
    Dim connectionString As String

    Private Sub AccountForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        connectionString = "Data Source=GREG-SURFACE4\SQLEXPRESS;Initial Catalog=ACCOUNTDB;Integrated Security=True;TrustServerCertificate=True;"

        Using connection As New SqlConnection(connectionString)
            ' Open the connection
            connection.Open()

            ' Create a SqlCommand to execute the query
            Using command As New SqlCommand("Select FULLNAME, ADDRESS, EMAIL, CREDITCARD from dbo.ACCOUNTPROFILE where USERID = '" + GlobalSettings.theLoginAccount.UserID + "'", connection)
                ' Execute the command and process the results
                Using reader As SqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        ' Process each row. For example, print the first column value
                        TextBoxFullName.Text = reader(0).ToString()
                        TextBoxAddress.Text = reader(1).ToString()
                        TextBoxEmail.Text = reader(2).ToString()
                        TextBoxCreditCard.Text = reader(3).ToString()


                    End While
                End Using
            End Using
        End Using

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            Using connection As New SqlConnection(connectionString)
                ' Open the connection
                connection.Open()

                Dim updateSql As String = "UPDATE ACCOUNTPROFILE SET ADDRESS =@Address, FULLNAME = @FullName, EMAIL = @Email, CREDITCARD = @CreditCard WHERE USERID = @Id"



                Using command As New SqlCommand(updateSql, connection)
                    ' Add parameter to the command to prevent SQL injection
                    command.Parameters.AddWithValue("@Id", GlobalSettings.theLoginAccount.UserID)
                    command.Parameters.AddWithValue("@Address", TextBoxAddress.Text)
                    command.Parameters.AddWithValue("@FullName", TextBoxFullName.Text)
                    command.Parameters.AddWithValue("@CreditCard", TextBoxCreditCard.Text)
                    command.Parameters.AddWithValue("@Email", TextBoxEmail.Text)

                    Dim affectedRows As Integer = command.ExecuteNonQuery()

                    MsgBox("Your Information Has Been Updated!")

                End Using

            End Using

        Catch ex As DataException
            ' Handle database-related exceptions
            MessageBox.Show("Database error: " & ex.Message)
        Catch ex As ApplicationException
            ' Handle application-specific exceptions
            MessageBox.Show("Application error: " & ex.Message)
        Catch ex As Exception
            ' Handle unexpected exceptions
            MessageBox.Show("An unexpected error occurred: " & ex.Message)
        End Try

        Me.Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
    End Sub
End Class