Public Class Main
    Private Sub Main_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        TextBox6.Text = Application.StartupPath
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Text = "Текстовый файл"
        TextBox2.Text = "txt"
        TextBox3.Text = "1"
        TextBox4.Text = "1"
        TextBox5.Text = "Текст "
        TextBox6.Text = Application.StartupPath
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = "1"
        TextBox4.Text = "1"
        TextBox5.Text = ""
        TextBox6.Text = ""
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim out_data(0) As String
        Dim text As String = "", mode(1) As Short, progress As Short = 0
        Array.Resize(out_data, TextBox4.Text)
        If out_data.Length < 100 Then
            mode(0) = Math.Floor(100 / out_data.Length)
            mode(1) = 1
        Else
            mode(0) = Math.Floor(out_data.Length / 100)
            mode(1) = 2
        End If
        For i As Integer = 0 To TextBox3.Text - 1
            text &= TextBox5.Text
        Next
        For i As Integer = 0 To TextBox4.Text - 1
            out_data(i) = text
            If mode(1) = 1 Then
                If progress + mode(0) <= 99 Then
                    progress += mode(0)
                Else
                    progress = 99
                End If
            Else
                If Math.IEEERemainder(i, mode(0)) = 0 Then
                    If progress + mode(0) <= 99 Then
                        progress += mode(0)
                    Else
                        progress = 99
                    End If
                End If
            End If
            Label7.Text = "Создание:" & progress
        Next
        Try
            IO.File.WriteAllLines(TextBox6.Text & "\" & TextBox1.Text & "." & TextBox2.Text, out_data)
            Label7.Text = "Создание: 100%"
            MsgBox("Создание завершено успешно!")
            progress = 0
            Label7.Text = "Создание: 0%"
        Catch
            MsgBox("Неверно указан путь файла!")
        End Try
    End Sub
    Private Sub TextBox4_LostFocus(sender As Object, e As EventArgs) Handles TextBox4.LostFocus
        Try
            Dim time_dat As Integer = TextBox4.Text
            If time_dat <= 0 Or time_dat > 1000 Then
                TextBox4.Text = "1"
                MsgBox("Значение должно быть больше нуля и не превышать 1000!")
            End If
        Catch
            TextBox4.Text = "1"
            MsgBox("Недопустимый символ!")
        End Try
    End Sub
    Private Sub TextBox3_LostFocus(sender As Object, e As EventArgs) Handles TextBox3.LostFocus
        Try
            Dim time_dat As Integer = TextBox3.Text
            If time_dat <= 0 Or time_dat > 10000 Then
                TextBox3.Text = "1"
                MsgBox("Значение должно быть больше нуля и не превышать 1000!")
            End If
        Catch
            TextBox3.Text = "1"
            MsgBox("Недопустимый символ!")
        End Try
    End Sub
End Class
