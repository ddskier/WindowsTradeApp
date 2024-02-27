Imports System.Data.SqlClient

Public Class Stock

    ' Constructor for the Stock class
    Public Sub New()
        ' Initialization code can go here
    End Sub

    ' Method to buy stock
    Public Sub Buy(row As DataGridViewRow, stockSymbol As String, quantity As Integer)

        Dim orderdate As DateTime = DateAndTime.Now

        Try
            'First, lets lookup the account via the combined primary key
            Using accountcontext As New ACCOUNTDBEntities()

                Dim theAccount As New ACCOUNT()
                theAccount.PROFILE_USERID = GlobalSettings.theLoginAccount.UserID
                theAccount.ACCOUNTID = GlobalSettings.theLoginAccount.AccountID
                theAccount = accountcontext.ACCOUNTs.Find(theAccount.ACCOUNTID, theAccount.PROFILE_USERID)
                'Console.WriteLine("Account is " + theAccount.CREATIONDATE.ToString)

                ' Now let's create a new Order object for the Orders table to insert as new row
                Dim newOrder As New ORDER() With {
                     .ACCOUNT_ACCOUNTID = theAccount.ACCOUNTID,
                    .COMPLETIONDATE = orderdate,
                    .HOLDING_HOLDINGID = Guid.NewGuid(),
                     .OPENDATE = orderdate,
                    .ORDERFEE = 1.0,
                    .ORDERSTATUS = "open",
                    .ORDERTYPE = "buy",
                     .QUOTE_SYMBOL = row.Cells("Symbol").Value,
                     .PRICE = row.Cells("Price").Value,
                     .QUANTITY = quantity,
                     .USERID = theAccount.PROFILE_USERID,
                     .ORDERID = Guid.NewGuid()}

                'Insert and Commit!

                ' This will be a  transaction, must also insert into Holdings Table

                Dim newHolding As New HOLDING() With {
            .ACCOUNT_ACCOUNTID = theAccount.ACCOUNTID,
            .PURCHASEDATE = orderdate,
            .PURCHASEPRICE = newOrder.PRICE,
            .QUANTITY = quantity,
            .QUOTE_SYMBOL = newOrder.QUOTE_SYMBOL,
            .USERID = newOrder.USERID,
            .HOLDINGID = newOrder.HOLDING_HOLDINGID}

                accountcontext.ORDERS.Add(newOrder)
                accountcontext.HOLDINGs.Add(newHolding)


                'Commit!
                accountcontext.SaveChanges()

                'Now close the order
                newOrder = accountcontext.ORDERS.Find(newOrder.ORDERID, newOrder.ACCOUNT_ACCOUNTID)
                newOrder.ORDERSTATUS = "closed"

                'Commit
                accountcontext.SaveChanges()


                MessageBox.Show("You Just Bought " + quantity.ToString() + " shares of " + row.Cells("Symbol").Value)

                ' Set other properties as needed
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

    End Sub

    Public Sub Sell(row As DataGridViewRow, stockSymbol As String, quantity As Integer)

        Dim orderdate As DateTime = DateAndTime.Now
        Dim holdingID As Guid
        holdingID = row.Cells("HOLDINGID").Value
        Dim theStock As New QUOTE
        Try

            Using quoteContext As New QUOTEDBEntities()

                Dim parameter = New SqlParameter("@quotesymbol", stockSymbol)
                Dim query = quoteContext.QUOTEs.SqlQuery("SELECT * FROM dbo.QUOTE WHERE SYMBOL = @quotesymbol", parameter)

                ' Materialize the results into a List (or another suitable collection)
                Dim result As List(Of QUOTE) = query.ToList()


                theStock = result(0)
            End Using


            'First, lets lookup the account via the combined primary key
            Using accountcontext As New ACCOUNTDBEntities()

                Dim theAccount As New ACCOUNT()
                theAccount.PROFILE_USERID = GlobalSettings.theLoginAccount.UserID
                theAccount.ACCOUNTID = GlobalSettings.theLoginAccount.AccountID
                theAccount = accountcontext.ACCOUNTs.Find(theAccount.ACCOUNTID, theAccount.PROFILE_USERID)
                'Console.WriteLine("Account is " + theAccount.CREATIONDATE.ToString)

                ' Now let's create a new Order object for the Orders table to insert as new row
                Dim newOrder As New ORDER() With {
                     .ACCOUNT_ACCOUNTID = theAccount.ACCOUNTID,
                    .COMPLETIONDATE = orderdate,
                    .HOLDING_HOLDINGID = Guid.NewGuid(),
                     .OPENDATE = orderdate,
                    .ORDERFEE = 1.0,
                    .ORDERSTATUS = "open",
                    .ORDERTYPE = "sell",
                     .QUOTE_SYMBOL = row.Cells("Quote_Symbol").Value,
                     .PRICE = theStock.PRICE,
                     .QUANTITY = quantity,
                     .USERID = theAccount.PROFILE_USERID,
                     .ORDERID = Guid.NewGuid()}

                'Insert and Commit!

                ' This will be a  transaction, must also update the Holdings Table
                Dim theHolding As New HOLDING()
                theHolding = accountcontext.HOLDINGs.Find(holdingID, theAccount.ACCOUNTID)

                'Update Holding Quantity 
                theHolding.QUANTITY = theHolding.QUANTITY - quantity

                'If new quantity is zero, delete the holding from the DB
                If theHolding.QUANTITY = 0 Then
                    accountcontext.HOLDINGs.Remove(theHolding)
                End If

                'Add the Order to the Orders Table
                accountcontext.ORDERS.Add(newOrder)



                'Commit!
                accountcontext.SaveChanges()

                'Now close the order
                newOrder = accountcontext.ORDERS.Find(newOrder.ORDERID, newOrder.ACCOUNT_ACCOUNTID)
                newOrder.ORDERSTATUS = "closed"

                'Commit
                accountcontext.SaveChanges()


                MessageBox.Show("You Just Sold " + quantity.ToString() + " shares of " + row.Cells("Quote_Symbol").Value)

                ' Set other properties as needed
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

    End Sub

End Class

