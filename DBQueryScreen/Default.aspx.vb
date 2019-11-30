
Partial Class _Default
    Inherits System.Web.UI.Page

    Public Sub ViewProfilePage(sender As Object, e As EventArgs)
        Dim link As LinkButton = Master.FindControl("login")
        If link.Text = "Login" Then
            Response.Redirect("profilelogin.aspx")
        Else Response.Redirect("ViewEditProfile.aspx")
        End If
    End Sub

    Public Sub ViewEnterTrainingPage(sender As Object, e As EventArgs)
        Dim link As LinkButton = Master.FindControl("login")
        If link.Text = "Login" Then
            Response.Redirect("profilelogin.aspx")
        Else Response.Redirect("TrainingData.aspx")
        End If
    End Sub

End Class
