Imports System.Xml
Imports System.IO
Imports System.Text

Public Class XmlConverter

    Public Sub convertCsvToXml(ByVal csvFilePath As String)
        Dim settings As XmlWriterSettings = New XmlWriterSettings()
        settings.Indent = True
        settings.Encoding = Encoding.UTF8

        Dim writer As XmlWriter = XmlWriter.Create("C:\Users\Flori\Documents\test.xml", settings)
        Dim reader As StreamReader = New StreamReader(csvFilePath, Encoding.UTF7)

        Dim header As String = reader.ReadLine()
        Dim titel As String() = header.Split(";")
        writer.WriteStartDocument()
        writer.WriteStartElement("Namensliste")
        writer.WriteElementString("test", titel(0))
        Dim line As String = reader.ReadLine()
        While Not line = Nothing
            Dim lineContent As String() = line.Split(";")
            writer.WriteStartElement("Person")
            For index As Integer = 0 To lineContent.Length - 1
                writer.WriteElementString(titel(index), lineContent(index))
            Next
            writer.WriteEndElement()
            line = reader.ReadLine()
        End While
        writer.WriteEndElement()
        writer.WriteEndDocument()
        writer.Flush()
        writer.Close()
    End Sub

End Class
