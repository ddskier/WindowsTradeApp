Imports System.Security.Cryptography
Imports System.Text

Public NotInheritable Class SaltedHash
    Private ReadOnly _salt As String
    Private ReadOnly _hash As String
    Private Const saltLength As Integer = 12

    Public ReadOnly Property Salt As String
        Get
            Return _salt
        End Get
    End Property

    Public ReadOnly Property Hash As String
        Get
            Return _hash
        End Get
    End Property

    Private Sub New(s As String, h As String)
        _salt = s
        _hash = h
    End Sub

    Public Sub New()

    End Sub

    Public Shared Function Create(password As String) As SaltedHash
        Dim salt As String = _createSalt()
        Dim hash As String = _calculateHash(salt, password)
        Return New SaltedHash(salt, hash)
    End Function

    Public Shared Function Create(salt As String, hash As String) As SaltedHash
        Return New SaltedHash(salt, hash)
    End Function

    Public Function Verify(password As String) As Boolean
        Dim h As String = _calculateHash(_salt, password)
        Return _hash.Equals(h)
    End Function

    Private Shared Function _createSalt() As String
        Dim r As Byte() = _createRandomBytes(saltLength)
        Return Convert.ToBase64String(r)
    End Function

    Private Shared Function _createRandomBytes(len As Integer) As Byte()
        Dim r As Byte() = New Byte(len - 1) {}
        Using rng As New RNGCryptoServiceProvider()
            rng.GetBytes(r)
        End Using
        Return r
    End Function

    Private Shared Function _calculateHash(salt As String, password As String) As String
        Dim data As Byte() = _toByteArray(salt & password)
        Dim hash As Byte() = _calculateHash(data)
        Return Convert.ToBase64String(hash)
    End Function

    Private Shared Function _calculateHash(data As Byte()) As Byte()
        Using sha1 As New SHA1CryptoServiceProvider()
            Return sha1.ComputeHash(data)
        End Using
    End Function

    Private Shared Function _toByteArray(s As String) As Byte()
        Return Encoding.UTF8.GetBytes(s)
    End Function
End Class
