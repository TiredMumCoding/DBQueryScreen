Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Web
Imports HelperLibrary.DataAccess

Partial Class ProfileLogin
    Inherits System.Web.UI.Page


    Dim LoginSQL As String = "select userid, firstname from UserDetails where password = @password and email = @email"
    Dim CheckPasswordSQL As String = "SELECT * FROM UserDetails where password = @passw and email = @usr"
    Dim ProfileSQL As String = "insert into UserDetails values (@LastName, @FirstName, @Age, @Gender, @Hours, @Pass, @Email)"
    Dim SetUsrSQL As String = "SELECT r.userid, r.firstname FROM UserDetails r inner join (select max(userid) as userid from UserDetails )u on r.userid = u.userid"
    Dim ProfList As New List(Of TextBox)

    Public Sub PageLoad(sender As Object, e As EventArgs) Handles Me.Load
        StartPage()
    End Sub


    Public Sub StartPage()
        LoginProfileBtns.Style.Add("display", "block")
        LoginSection.Style.Add("display", "none")
        CreateSection.Style.Add("display", "none")
        ErrorSection.Style.Add("display", "none")
    End Sub


    Public Sub LoginForm()
        LoginProfileBtns.Style.Add("display", "none")
        LoginSection.Style.Add("display", "block")
        CreateSection.Style.Add("display", "none")
        ErrorSection.Style.Add("display", "none")
    End Sub


    Public Sub CreateForm()
        LoginProfileBtns.Style.Add("display", "none")
        LoginSection.Style.Add("display", "none")
        CreateSection.Style.Add("display", "block")
        ErrorSection.Style.Add("display", "none")
    End Sub


    Public Sub SetUser(DS As DataSet)
        Session("UserName") = DS.Tables(0).Rows(0)("firstname").ToString
        Session("User") = DS.Tables(0).Rows(0)("userid")
        Dim link As LinkButton = Master.FindControl("Welcome")
        link.Text = link.Text + " " + Session("UserName")
    End Sub


    Public Sub LoginSub(sender As Object, e As EventArgs)
        Dim log As LinkButton = Master.FindControl("login")
        If log.Text = "Login" Then

            ErrorLabel.Text = ""

            ProfList.Clear()
            ProfList.Add(PasswordTextBox)
            ProfList.Add(EmailTextBox)
            If ValidateList(ProfList) Then

                Dim PassParam As New SqlParameter("@password", SqlDbType.VarChar)
                PassParam.Value = PasswordTextBox.Text
                Dim EParam As New SqlParameter("@email", SqlDbType.VarChar)
                EParam.Value = EmailTextBox.Text
                Dim Params() = New SqlParameter() {PassParam, EParam}

                Dim TheResults As New DataSet
                TheResults = FetchResults(LoginSQL, Params)
                If TheResults.Tables.Count > 0 Then
                    If TheResults.Tables(0).Rows.Count > 0 Then
                        SetUser(TheResults)
                        Response.Redirect("default.aspx")
                    Else
                        PasswordTextBox.Text = ""
                        EmailTextBox.Text = ""
                        StartPage()
                        ErrorSection.Style.Add("display", "block")
                        ErrorLabel.Text = "Password and UserName do not exist"
                    End If
                End If
            Else
                StartPage()
                ErrorLabel.Text = "Please Fill in the Required Fields."
                LoginSection.Style.Add("display", "block")
                ErrorSection.Style.Add("display", "block")
                LoginProfileBtns.Style.Add("display", "none")
            End If
        End If
    End Sub


    Public Sub CreateSub(Sender As Object, e As EventArgs)

        Dim CheckFlag As Boolean = True
        ErrorLabel.Text = ""

        ProfList.Clear()
        ProfList.Add(FirstNameTextBox)
        ProfList.Add(LastNameTextBox)
        ProfList.Add(AgeTextBox)
        ProfList.Add(HoursTextBox)
        ProfList.Add(CreatePasswordTextBox)
        ProfList.Add(CreateEmailTextBox)

        If Not ValidateList(ProfList) Then
            ErrorLabel.Text = "Please Fill in the Required Fields."
            CheckFlag = False
        End If

        If Not Int32.TryParse(AgeTextBox.Text, 0) Then
            If CheckFlag = False Then
                ErrorLabel.Text = ErrorLabel.Text + " Please Provide a numeric value for age."
            Else
                ErrorLabel.Text = "Please Provide a numeric value for age."
                CheckFlag = False
            End If
        End If

        If Not Int32.TryParse(HoursTextBox.Text, 0) Then
            If CheckFlag = False Then
                ErrorLabel.Text = ErrorLabel.Text + " Please Provide a numeric value for hours per week."
            Else
                ErrorLabel.Text = "Please Provide a numeric value for hours per week."
                CheckFlag = False
            End If
        End If

        Dim CheckPassParam As New SqlParameter("@passw", SqlDbType.VarChar)
        CheckPassParam.Value = CreatePasswordTextBox.Text
        Dim CheckUsrParam As New SqlParameter("@usr", SqlDbType.VarChar)
        CheckUsrParam.Value = CreateEmailTextBox.Text
        Dim CheckParam() = New SqlParameter() {CheckPassParam, CheckUsrParam}
        Dim Check As New DataSet
        Check = FetchResults(CheckPasswordSQL, CheckParam)
        If Check.Tables.Count > 0 Then
            If Check.Tables(0).Rows().Count > 0 Then
                CheckFlag = False
                ErrorLabel.Text = "This Email and Password Combination already exists."
            End If
        End If

        If CheckFlag Then

            Dim FirstNameParam As New SqlParameter("@FirstName", SqlDbType.VarChar)
            FirstNameParam.Value = FirstNameTextBox.Text
            Dim LastNameParam As New SqlParameter("@LastName", SqlDbType.VarChar)
            LastNameParam.Value = LastNameTextBox.Text
            Dim AgeParam As New SqlParameter("@Age", SqlDbType.Int)
            AgeParam.Value = AgeTextBox.Text
            Dim GenderParam As New SqlParameter("@Gender", SqlDbType.VarChar)
            GenderParam.Value = GenderList.SelectedItem.Text
            Dim HoursParam As New SqlParameter("@Hours", SqlDbType.VarChar)
            HoursParam.Value = HoursTextBox.Text
            Dim PasswordParam As New SqlParameter("@Pass", SqlDbType.VarChar)
            PasswordParam.Value = CreatePasswordTextBox.Text
            Dim EmailParam As New SqlParameter("@Email", SqlDbType.VarChar)
            EmailParam.Value = CreateEmailTextBox.Text
            Dim Params = New SqlParameter() {FirstNameParam, LastNameParam, AgeParam, GenderParam, HoursParam, PasswordParam, EmailParam}

            UpdateDBRet(ProfileSQL, Params)
            Dim TheResults As New DataSet
            Dim UserParam = New SqlParameter() {}
            TheResults = FetchResults(SetUsrSQL, UserParam)
            SetUser(TheResults)
            Response.Redirect("default.aspx")

        Else

            StartPage()
                CreateSection.Style.Add("display", "block")
                ErrorSection.Style.Add("display", "block")
            LoginProfileBtns.Style.Add("display", "none")
        End If


    End Sub


    Public Sub BackBtn(sender As Object, e As EventArgs)
        StartPage()
    End Sub

End Class
