Imports System.Data.SqlClient
Public Class AccountCurrent
    Public Property Password As String
    Public Property UserID As String

    Public Property Name As String
    Public Property AccountID As Decimal

    Public Property Salt As String

    Public Function Login(userid As String, password As String) As AccountCurrent

        Dim theAccount As New AccountCurrent
        theAccount.UserID = userid
        Using accountcontext As New ACCOUNTDBEntities()

            'Dim result = accountcontext.ACCOUNTPROFILEs.SqlQuery("Select * FROM dbo.ACCOUNTPROFILE WHERE USERID = '" + userid + "'")

            ' Assuming "userid" is a variable containing the user's ID you're interested in
            Dim parameter = New SqlParameter("@userId", userid)

            ' Execute the SQL query using a parameterized query for safety
            Dim result = accountcontext.ACCOUNTPROFILEs.SqlQuery("SELECT * FROM dbo.ACCOUNTPROFILE WHERE USERID = @userId", parameter)

            ' Iterate over the results
            For Each profile In result
                ' Access the properties/columns of each ACCOUNTPROFILE entity
                theAccount.UserID = profile.USERID
                theAccount.Password = profile.PASSWORD
                theAccount.AccountID = profile.ACCOUNTID
                theAccount.Salt = profile.SALT
                theAccount.Name = profile.FULLNAME

                ' Continue accessing other columns/properties as needed
            Next

            If theAccount.Password Is Nothing Then

                GlobalSettings.LoggedIn = False
            Else

                Dim ver = New SaltedHash().Create(theAccount.Salt, theAccount.Password)

                GlobalSettings.LoggedIn = ver.Verify(password)

            End If

        End Using

        Return theAccount



    End Function


End Class
