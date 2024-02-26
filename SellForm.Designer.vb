<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SellForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SharesSell = New System.Windows.Forms.TextBox()
        Me.SellButton = New System.Windows.Forms.Button()
        Me.CancelButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(86, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        '
        'SharesSell
        '
        Me.SharesSell.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SharesSell.Location = New System.Drawing.Point(251, 128)
        Me.SharesSell.Name = "SharesSell"
        Me.SharesSell.Size = New System.Drawing.Size(213, 35)
        Me.SharesSell.TabIndex = 1
        '
        'SellButton
        '
        Me.SellButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SellButton.Location = New System.Drawing.Point(85, 116)
        Me.SellButton.Name = "SellButton"
        Me.SellButton.Size = New System.Drawing.Size(130, 59)
        Me.SellButton.TabIndex = 2
        Me.SellButton.Text = "Sell"
        Me.SellButton.UseVisualStyleBackColor = True
        '
        'CancelButton
        '
        Me.CancelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CancelButton.Location = New System.Drawing.Point(85, 210)
        Me.CancelButton.Name = "CancelButton"
        Me.CancelButton.Size = New System.Drawing.Size(130, 52)
        Me.CancelButton.TabIndex = 3
        Me.CancelButton.Text = "Cancel"
        Me.CancelButton.UseVisualStyleBackColor = True
        '
        'SellForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSlateGray
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.CancelButton)
        Me.Controls.Add(Me.SellButton)
        Me.Controls.Add(Me.SharesSell)
        Me.Controls.Add(Me.Label1)
        Me.Name = "SellForm"
        Me.Text = "SellForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents SharesSell As TextBox
    Friend WithEvents SellButton As Button
    Friend WithEvents CancelButton As Button
End Class
