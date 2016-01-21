Imports Chilkat
Imports Parse
Imports System.IO


Public Class FetchForm
    Dim rssLinks As New List(Of RssLinks)
    Private Sub FetchForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Async Sub fetchBtn_Click(sender As Object, e As EventArgs) Handles fetchBtn.Click
        fetchBtn.Enabled = False
        For Each item In rssLinks


            Dim rss As New Rss

            Dim success = rss.DownloadRss(item.Link)
            If success <> True Then
                MsgBox(rss.LastErrorText)
                Return
            End If

            Dim rssChannel = rss.GetChannel(0)


            'Parse

            If rssChannel Is Nothing Then
                MsgBox("No Channel Found in RSS")
                Return
            End If

            consoleBox.Text += vbNewLine & "Now fetching ... " & vbNewLine
            consoleBox.Text += "Title: " & rssChannel.GetString("title") & vbNewLine
            consoleBox.Text += "Link: " & rssChannel.GetString("link") & vbNewLine
            consoleBox.Text += "Description: " & rssChannel.GetString("description") & vbNewLine

            Dim numItems = rssChannel.NumItems

            For i = 0 To numItems - 1
                Dim rssItem = rssChannel.GetItem(i)
                Dim rssTitle = rssItem.GetString("title")
                Dim rssLink = rssItem.GetString("link")
                Dim rssDescription = rssItem.GetString("description")
                Dim rssPubDate = rss.GetDate("pubDate")
                Dim rssCategory = ""
                Dim numCategories = rssItem.GetCount("category")

                If numCategories > 0 Then
                    For j = 0 To numCategories - 1
                        rssCategory += "" & rssItem.MGetString("category", j) & ", "
                    Next
                End If

                Dim res As String = Await parseRss(rssTitle, rssLink, rssDescription, rssPubDate, rssCategory)

                consoleBox.Text += res & vbNewLine
                consoleBox.SelectionStart = consoleBox.Text.Length
                consoleBox.ScrollToCaret()
            Next


            consoleBox.Text += vbNewLine & vbNewLine & vbNewLine
        Next

        consoleBox.Text += vbNewLine & vbNewLine & "Process Complete!"
        consoleBox.Text += vbNewLine & "View uploaded data at Parse.com" & vbNewLine
        consoleBox.Text += vbNewLine & "Account Email: kpnava.dev@gmail.com" & vbNewLine
        consoleBox.Text += vbNewLine & "Account Password: kpnavadev" & vbNewLine
        consoleBox.SelectionStart = consoleBox.Text.Length
        consoleBox.ScrollToCaret()
        readBtn.Enabled = True
    End Sub

    Public Async Function parseRss(rssTitle As String, rssLink As String, rssDescription As String, rssPubDate As Date, rssCategory As String) As Task(Of String)

        ParseClient.Initialize("0Sds8IJ2Uvg3CNiCGcAi72N4zHv7D83cBbwGNWTK", "CD0yLLTa4Rgxfu8EPiVmJZZXPhb1Lb1rgD9h1Dmn")

        Dim rssParseObject = New ParseObject("Rss")

        rssParseObject("title") = rssTitle
        rssParseObject("link") = rssLink
        rssParseObject("description") = rssDescription
        rssParseObject("pubDate") = rssPubDate
        rssParseObject("category") = rssCategory

        Await rssParseObject.SaveAsync()


        Return rssTitle
    End Function

    Private Sub csvFileBox_Click(sender As Object, e As EventArgs) Handles csvFileBox.Click
        OpenFileDialog1.ShowDialog()
        Dim file As String = OpenFileDialog1.FileName
        csvFileBox.Text = file
    End Sub

    Private Sub readBtn_Click(sender As Object, e As EventArgs) Handles readBtn.Click
        If Not csvFileBox.Text = "" And File.Exists(csvFileBox.Text) Then

            rssLinks = New List(Of RssLinks)
            fetchBtn.Enabled = True
            readBtn.Enabled = False

            Dim afile As FileIO.TextFieldParser = New FileIO.TextFieldParser(csvFileBox.Text)
            'Dim CurrentRecord As String() ' this array will hold each line of data
            afile.TextFieldType = FileIO.FieldType.Delimited
            afile.Delimiters = New String() {","}
            afile.HasFieldsEnclosedInQuotes = True

            ' parse the actual file
            Do While Not afile.EndOfData
                Try
                    Dim rss As New RssLinks With {
                        .Link = afile.ReadLine}
                    rssLinks.Add(rss)
                Catch ex As FileIO.MalformedLineException
                    Stop
                End Try
            Loop

            consoleBox.Text += vbNewLine & "CSV loaded ..." & vbNewLine
            consoleBox.Text += vbNewLine & rssLinks.Count & " rss link/s detected ... " & vbNewLine
            consoleBox.Text += vbNewLine & "Click 'Fetch' to start process ..." & vbNewLine

        Else

            consoleBox.Text += vbNewLine & "File does not exists!. Please load another file..." & vbNewLine

        End If
    End Sub
End Class
