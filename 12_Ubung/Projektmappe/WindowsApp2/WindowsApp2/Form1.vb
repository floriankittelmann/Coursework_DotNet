Public Class Form1
    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Dim files As String() = OpenFileDialog1.FileNames
        Dim filepath As String = files(0)
        Dim myConverter As XmlConverter = New XmlConverter()
        myConverter.convertCsvToXml(filepath)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.Filter = "CSV-Files (*.csv)|*.csv"
        OpenFileDialog1.ShowDialog()
    End Sub
End Class
