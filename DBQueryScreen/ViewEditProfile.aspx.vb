Imports System.Data
Imports System.Data.SqlClient
Imports HelperLibrary.DataAccess
Imports System.Web

Partial Class ViewEditProfile
    Inherits System.Web.UI.Page


    Dim ViewProfileSQL As String = "select * from userdetails where userid = @uid"
    Dim EditSQL As String = "update UserDetails Set [Surname] = @surname, [firstname] = @firstname, [age] = @age, [Gender] = @gender, [HoursPerWeek] = @hours, [email] = @email where userid = @uid"
    Dim List As New List(Of TextBox)

    Public Sub Pageload(sender As Object, e As EventArgs) Handles Me.Load
        Startpage()
    End Sub

    Public Sub Startpage()
        ViewEditProfileBtns.Style.Add("display", "block")
        ViewProfileMarkup.Style.Add("display", "none")
        EditProfileMarkup.Style.Add("display", "none")
        EditErrorLabel.Style.Add("display", "none")
    End Sub

    Public Sub ViewProfile(Sender As Object, e As EventArgs)
        ViewEditProfileBtns.Style.Add("display", "none")
        ViewProfileMarkup.Style.Add("display", "block")
        EditProfileMarkup.Style.Add("display", "none")
        EditErrorLabel.Style.Add("display", "none")

        Dim UserID = New SqlParameter("@uid", SqlDbType.Int)
        UserID.Value = Session("User")
        Dim Param() = New SqlParameter() {UserID}
        Dim Profile As New DataSet
        Profile = FetchResults(ViewProfileSQL, Param)

        VPFirstNameDisplay.Text = Profile.Tables(0).Rows(0)("FirstName").ToString()
        VPLastNameDisplay.Text = Profile.Tables(0).Rows(0)("SurName").ToString()
        VPEmailDisplay.Text = Profile.Tables(0).Rows(0)("email").ToString()
        VPAgeDisplay.Text = Profile.Tables(0).Rows(0)("age").ToString()
        VPGenderDisplay.Text = Profile.Tables(0).Rows(0)("Gender").ToString()
        VPHoursDisplay.Text = Profile.Tables(0).Rows(0)("HoursPerWeek").ToString()

    End Sub

    Public Sub EditProfile(Sender As Object, E As EventArgs)
        ViewEditProfileBtns.Style.Add("display", "none")
        ViewProfileMarkup.Style.Add("display", "none")
        EditProfileMarkup.Style.Add("display", "block")
        EditErrorLabel.Style.Add("display", "none")

        Dim UserID = New SqlParameter("@uid", SqlDbType.Int)
        UserID.Value = Session("User")
        Dim Param() = New SqlParameter() {UserID}
        Dim Profile As New DataSet
        Profile = FetchResults(ViewProfileSQL, Param)

        EPFirstNameTextBox.Text = Profile.Tables(0).Rows(0)("FirstName").ToString()
        EPLastNameTextBox.Text = Profile.Tables(0).Rows(0)("SurName").ToString()
        EPEmailTextBox.Text = Profile.Tables(0).Rows(0)("email").ToString()
        EPAgeTextBox.Text = Profile.Tables(0).Rows(0)("age").ToString()
        EPGenderList.SelectedValue = Profile.Tables(0).Rows(0)("Gender").ToString()
        EPHoursTextBox.Text = Profile.Tables(0).Rows(0)("HoursPerWeek").ToString()
    End Sub

    Public Sub EditSub(sender As Object, E As EventArgs)
        Dim Checkflag As Boolean = True
        EditErrorLabel.Text = ""

        List.Add(EPFirstNameTextBox)
        List.Add(EPLastNameTextBox)
        List.Add(EPEmailTextBox)
        List.Add(EPAgeTextBox)
        List.Add(EPHoursTextBox)

        If Not ValidateList(List) Then
            EditErrorLabel.Text = "Please Fill in the Required Fields."
            Checkflag = False
        End If

        If Not Int32.TryParse(EPAgeTextBox.Text, 0) Then
            If Checkflag = False Then
                EditErrorLabel.Text = EditErrorLabel.Text + " Please enter a numberic value for age"
            Else
                EditErrorLabel.Text = " Please enter a numberic value for age"
                Checkflag = False
            End If
        End If

        If Not Int32.TryParse(EPHoursTextBox.Text, 0) Then
            If Checkflag = False Then
                EditErrorLabel.Text = EditErrorLabel.Text + " Please enter a numberic value for hours per week"
            Else
                EditErrorLabel.Text = " Please enter a numberic value for hours per week"
                Checkflag = False
            End If
        End If

        If Checkflag Then

            Dim FirstNameParam As New SqlParameter("@firstname", SqlDbType.VarChar)
            FirstNameParam.Value = EPFirstNameTextBox.Text
            Dim LastNameParam As New SqlParameter("@surname", SqlDbType.VarChar)
            LastNameParam.Value = EPLastNameTextBox.Text
            Dim AgeParam As New SqlParameter("@age", SqlDbType.Int)
            AgeParam.Value = EPAgeTextBox.Text
            Dim GenderParam As New SqlParameter("@gender", SqlDbType.VarChar)
            GenderParam.Value = EPGenderList.SelectedItem.Text
            Dim HoursParam As New SqlParameter("@hours", SqlDbType.VarChar)
            HoursParam.Value = EPHoursTextBox.Text
            Dim EmailParam As New SqlParameter("@email", SqlDbType.VarChar)
            EmailParam.Value = EPEmailTextBox.Text
            Dim UserParam As New SqlParameter("@uid", SqlDbType.Int)
            UserParam.Value = Session("User")
            Dim Params = New SqlParameter() {FirstNameParam, LastNameParam, AgeParam, GenderParam, HoursParam, EmailParam, UserParam}

            UpdateDBRet(EditSQL, Params)

            Startpage()
            EditProfileMarkup.Style.Add("display", "none")
            EditErrorLabel.Style.Add("display", "none")
            ViewEditProfileBtns.Style.Add("display", "block")
            ViewProfileMarkup.Style.Add("display", "none")

        Else

            Startpage()
            EditProfileMarkup.Style.Add("display", "block")
            EditErrorLabel.Style.Add("display", "block")
            ViewEditProfileBtns.Style.Add("display", "none")
            ViewProfileMarkup.Style.Add("display", "none")

        End If
    End Sub

    Public Sub EditBackBtn(sender As Object, e As EventArgs)
        Startpage()
    End Sub

End Class
