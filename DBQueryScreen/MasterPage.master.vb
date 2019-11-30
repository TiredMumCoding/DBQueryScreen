
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Public Sub PageLoad(sender As Object, e As EventArgs) Handles Me.Load
        Dim o As Object = Session("User")
        Dim p As Object = Session("UserName")
        If Not o Is Nothing Then
            login.Text = "Log Out"
        End If
        If Not p Is Nothing Then
            If Welcome.Text = "Welcome" Then
                Welcome.Text = Welcome.Text + " " + p
            End If
        End If
    End Sub

    Public Sub loginbtn(Sender As Object, e As EventArgs)
        If Sender.text = "Login" Then
            Response.Redirect("ProfileLogin.aspx")
        Else
            Session("UserName") = Nothing
            Session("User") = Nothing
            Welcome.Text = "Welcome"
            Response.Redirect("default.aspx")
        End If

    End Sub

End Class

