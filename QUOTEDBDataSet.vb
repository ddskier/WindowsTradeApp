Partial Class QUOTEDBDataSet
    Partial Public Class QUOTEDataTable
        Private Sub QUOTEDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.SYMBOLColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class
End Class
