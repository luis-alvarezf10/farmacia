Imports MySql.Data.MySqlClient
Imports Mysqlx.Crud
Public Class Form1
    Public comand As New MySqlConnection
    Public selection As MySqlCommand = New MySqlCommand
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Conectar()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (TextBox1.Text = "") Then
            MsgBox("Dato vacio")
        Else
            'Dim comando = New MySqlCommand("SELECT * FROM usuarios Where user_id = " + TextBox1.Text + ";", Conex)
            Dim comando = New MySqlCommand("SELECT * FROM usuarios Where username = '" + TextBox1.Text + "';", Conex)
            Dim resultado = comando.ExecuteReader
            resultado.Read()
            If (resultado.HasRows) Then
                MsgBox("Nombre: " + resultado("fullname"))
            Else
                MsgBox("ERROR, usuario no encontrado ")
            End If
            resultado.Close()
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "") Then
            MsgBox("Faltan datos")
        Else
            Try
                Dim comand = New MySqlCommand("INSERT INTO usuarios(username,password,fullname) VALUES('" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "');", Conex)
                Dim resultado = comand.ExecuteNonQuery
                MsgBox("Registro exitoso")
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
            Catch ex As Exception
                MsgBox("ERROR: " + ex.Message)
            End Try
        End If
    End Sub
End Class
