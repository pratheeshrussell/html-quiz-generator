Imports System
Imports System.IO
Public Class Form1
    Dim n As Integer
    Dim curques = 0
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        GroupBox1.Show()
        Button1.Enabled = False
        NumericUpDown1.Enabled = False
        Label8.Text = "Question no 1 outof" & NumericUpDown1.Value
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        generate()
        ref("2")
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Directory.Exists("output") Then
            Directory.CreateDirectory("output")
        End If

        ComboBox1.Items.Add("option1")
        ComboBox1.Items.Add("option2")
        ComboBox1.Items.Add("option3")
        ComboBox1.Items.Add("option4")
    End Sub
    Function ref(ByVal option1 As String)
        ComboBox1.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""

        If option1 = "1" Then
            TextBox6.Text = ""
            TextBox7.Text = ""
            TextBox8.Text = ""
            TextBox9.Text = ""
        End If
       
    End Function
    Function generate()
        n = NumericUpDown1.Value
        curques += 1
        Label8.Text = "Question no" & curques & "outof" & n
        Dim op = Nothing
        If ComboBox1.Text = "option1" Then
            op = "o1"
            TextBox9.Text += "<p>" & curques & ".A" & "</p>" & vbNewLine
        ElseIf ComboBox1.Text = "option2" Then
            op = "o2"
            TextBox9.Text += "<p>" & curques & ".B" & "</p>" & vbNewLine
        ElseIf ComboBox1.Text = "option3" Then
            op = "o3"
            TextBox9.Text += "<p>" & curques & ".C" & "</p>" & vbNewLine
        ElseIf ComboBox1.Text = "option4" Then
            op = "o4"
            TextBox9.Text += "<p>" & curques & ".D" & "</p>" & vbNewLine
        Else
            MsgBox("enter correct option")
            curques -= 1
            Exit Function
        End If
        Dim qovalue = "q" & curques & op
        Dim picvalue = "qi" & curques

        'script generating
        TextBox6.Text += "if(document.getElementById('" & qovalue & "').checked) {" & vbNewLine
        TextBox6.Text += "x += 1;" & vbNewLine
        TextBox6.Text += " document.getElementById(""" & picvalue & """).src=""accept.png"";" & vbNewLine
        TextBox6.Text += "}" & vbNewLine
        TextBox6.Text += "else" & vbNewLine
        TextBox6.Text += "{" & vbNewLine
        TextBox6.Text += " document.getElementById(""" & picvalue & """).src=""wrong.png"";" & vbNewLine
        TextBox6.Text += "}" & vbNewLine

        'html generate
        TextBox7.Text += "<p>&nbsp;</p>" & vbNewLine
        TextBox7.Text += "<p>" & TextBox1.Text & "<img id=""" & picvalue & """ src=""white.png"" width=""13"" height=""14"" alt=""white"" /></p>" & vbNewLine
        TextBox7.Text += "<form id=""form1"" name=""form1"" method=""post"" action="""">" & vbNewLine
        TextBox7.Text += "<p>" & vbNewLine
        TextBox7.Text += "<label>" & vbNewLine
        TextBox7.Text += "<input type=""radio"" name=""RadioGroup1"" value=""radio"" id=""q" & curques & "o1"" />" & TextBox2.Text & "</label>" & vbNewLine
        TextBox7.Text += "<label><br>" & vbNewLine
        TextBox7.Text += "<input type=""radio"" name=""RadioGroup1"" value=""radio"" id=""q" & curques & "o2"" />" & TextBox3.Text & "</label>" & vbNewLine
        TextBox7.Text += "<label><br>" & vbNewLine
        TextBox7.Text += "<input type=""radio"" name=""RadioGroup1"" value=""radio"" id=""q" & curques & "o3"" />" & TextBox4.Text & "</label>" & vbNewLine
        TextBox7.Text += "<label><br>" & vbNewLine
        TextBox7.Text += "<input type=""radio"" name=""RadioGroup1"" value=""radio"" id=""q" & curques & "o4"" />" & TextBox5.Text & "</label>" & vbNewLine
        TextBox7.Text += "</p> </form>" & vbNewLine

        If curques = n Then
            generatehtml()
        End If

    End Function
    Function generatehtml()
        TextBox8.Text += "<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN""" & vbNewLine
        TextBox8.Text += """http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">" & vbNewLine
        TextBox8.Text += "<html xmlns=""http://www.w3.org/1999/xhtml"">" & vbNewLine
        TextBox8.Text += "<head>" & vbNewLine
        TextBox8.Text += "<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />" & vbNewLine
        TextBox8.Text += "<title>HTML Quiz Generator</title>" & vbNewLine
        TextBox8.Text += "</head>" & vbNewLine
        TextBox8.Text += "<body>" & vbNewLine
        TextBox8.Text += "<link href=""css/style.css"" rel=""stylesheet"" type=""text/css"" media=""screen"" />" & vbNewLine
        TextBox8.Text += "<div id=""wrapper"">" & vbNewLine
        TextBox8.Text += "<script type=text/javascript>" & vbNewLine
        TextBox8.Text += "function validate(e){" & vbNewLine
        TextBox8.Text += "var x=0;" & vbNewLine
        TextBox8.Text += TextBox6.Text
        TextBox8.Text += "alert('Your answered:' + x + ' out of " & n & " correctly') ;" & vbNewLine
        TextBox8.Text += "e.preventDefault();" & vbNewLine
        TextBox8.Text += "}" & vbNewLine
        TextBox8.Text += "function PopupCenter(pageURL, title,w,h) {" & vbNewLine
        TextBox8.Text += "var left = (screen.width/2)-(w/2);" & vbNewLine
        TextBox8.Text += "var top = (screen.height/2)-(h/2);" & vbNewLine
        TextBox8.Text += "var targetWin = window.open (pageURL, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, "
        TextBox8.Text += "scrollbars=no, resizable=no, copyhistory=no, width='+w+', height='+h+', top='+top+', left='+left);" & vbNewLine
        TextBox8.Text += "}" & vbNewLine
        TextBox8.Text += "</script>" & vbNewLine
        TextBox8.Text += TextBox7.Text
        TextBox8.Text += "<form id=""buttoncheck"" name=""buttoncheck"" method=""post"" action="""">" & vbNewLine
        TextBox8.Text += "<input type=""submit"" name=""check"" id=""check"" value=""check"" onclick=""validate(event)"" />" & vbNewLine
        TextBox8.Text += "<a href=""javascript:void(0);"" onclick=""PopupCenter('answers.html', 'answers',400,400);"">View Answers</a>" & vbNewLine
        TextBox8.Text += "</form>" & vbNewLine
        TextBox8.Text += "</div>" & vbnewline
        TextBox8.Text += "</body>" & vbNewLine
        TextBox8.Text += "</html>" & vbNewLine
        generatefile()
        generatecomplete()
        MsgBox("The HTML files can be found in the output folder")
    End Function
    Function generatefile()

        'generate question
        Dim TextFile As New StreamWriter("output\Questions.html")
        TextFile.WriteLine(TextBox8.Text)
        TextFile.Close()

        'generate answers
        Dim TextFile1 As New StreamWriter("output\answers.html")
        TextFile1.WriteLine(TextBox9.Text)
        TextFile1.Close()

        'copy pics
        System.IO.File.Copy("pics\white.png", "output\white.png")
        System.IO.File.Copy("pics\accept.png", "output\accept.png")
        System.IO.File.Copy("pics\wrong.png", "output\wrong.png")

    End Function
    Function generatecomplete()
        ref("1")
        Button1.Enabled = True
        GroupBox1.Hide()
        NumericUpDown1.Enabled = True
    End Function
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        generatecomplete()
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        MsgBox("Created By Pratheesh Russell.S", 0, "About:")
    End Sub
End Class
