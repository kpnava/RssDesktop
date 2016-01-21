Public Class RssLinks
    Private _link As String
    Public Property Link() As String
        Get
            Return _link
        End Get
        Set(ByVal value As String)
            _link = value
        End Set
    End Property

End Class
