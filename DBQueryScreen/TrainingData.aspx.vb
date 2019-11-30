Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Data.Common
Imports System.Web
Imports HelperLibrary.DataAccess

Partial Class TrainingData
    Inherits System.Web.UI.Page

    Dim Table1 As New DataTable
    Dim MainDetailsSQL As String = "Insert into TrainingDetails values(@profile ,@type ,@distance ,convert(time, @totaltime) ,convert(time, @avper)  ,convert(time, @fastest) ,convert(time, @slowest) ,@thedate )"
    Dim MaxID As String = "Select max(sessionid) as ID From TrainingDetails"
    Dim VarID As Int32
    Dim IntervalSQL As String = "Insert into  IntervalDetails values(@SessionID, @IntervalDistance ,convert(time, @IntervalTime))"

    Public Sub PageLoad(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Table1.Columns.Add("Interval Number")
            Table1.Columns.Add("Distance", GetType(System.Int32))
            Table1.Columns.Add("Split", GetType(System.String))
            Table1.Columns.Add("Delete", GetType(String))
            Table1.Columns(0).AutoIncrement = True
            Session("Intervals") = Table1
            StartPage()
        End If
    End Sub


    Public Sub StartPage()
        ' CustomDistanceLabel.Style.Add("display", "none")
        ' CustomDistanceTextBox.Style.Add("display", "none")
        Intervals.Style.Add("display", "none")
    End Sub


    Public Sub MainDistance(sender As Object, e As EventArgs)
        Dim ClearTable As New DataTable
        ClearTable.Columns.Add("Interval Number")
        ClearTable.Columns.Add("Distance", GetType(System.Int32))
        ClearTable.Columns.Add("Split", GetType(String))
        ClearTable.Columns.Add("Delete", GetType(String))
        ClearTable.Columns(0).AutoIncrement = True
        Dim distance As String = sender.selecteditem.Text
        If distance = "Custom Distance" Then
            Intervals.Style.Add("display", "none")
            Session("Intervals") = ClearTable
            intervalrep.DataBind()
            ' CustomDistanceTextBox.Text = ""
            'CustomDistanceLabel.Style.Add("display", "inline-block")
            ' CustomDistanceTextBox.Style.Add("display", "inline-block")
        Else
            If distance = "Intervals" Then
                ' CustomDistanceLabel.Style.Add("display", "none")
                '  CustomDistanceTextBox.Style.Add("display", "none")
                'DistanceTextBox.Text = ""
                SplitTextBox.Text = ""
                Intervals.Style.Add("Display", "block")
            Else
                'CustomDistanceLabel.Style.Add("display", "none")
                ' CustomDistanceTextBox.Style.Add("display", "none")
                Intervals.Style.Add("display", "none")
                Session("Intervals") = ClearTable
                intervalrep.DataBind()
            End If
        End If
    End Sub


    Public Sub IntervalSub(sender As Object, e As EventArgs)
        Dim RowIn As DataRow = Session("Intervals").NewRow
        RowIn("Distance") = DistanceTextBox.Text
        RowIn("Split") = SplitTextBox.Text
        RowIn("Delete") = "Delete"
        Session("Intervals").Rows.Add(RowIn)
        intervalrep.DataSource = Session("Intervals")
        intervalrep.DataBind()
        DistanceTextBox.Text = ""
        SplitTextBox.Text = ""
    End Sub


    Public Sub DeleteInterval(Sender As Object, E As EventArgs)
        Dim test As Int32 = Sender.commandargument
        Dim ROut As DataRow
        For Each dr As DataRow In Session("Intervals").Rows
            If dr("Interval Number") = test Then
                ROut = dr
            End If
        Next
        Session("Intervals").Rows.Remove(ROut)
        intervalrep.DataSource = Session("Intervals")
        intervalrep.DataBind()
    End Sub




    Public Function ValidateTime(hr As Int32, min As Int32, sec As Int32) As String
        Dim Checkflag As Boolean = True
        Dim ErrorMsg As String
        Dim Hour As String
        Dim Minute As String
        Dim Second As String
        If min > 60 Then
            Checkflag = False
            ErrorMsg = "Please enter a minute value of less than sixty"
        End If
        If sec > 60 Then
            If Checkflag = False Then
                ErrorMsg = ErrorMsg + "Please enter a seconds value of less than sixty"
            Else
                Checkflag = False
                ErrorMsg = "Please enter a seconds value of less than sixty"
            End If
        End If
        If Checkflag = False Then
            Return ErrorMsg
        Else
            If hr.ToString.Length < 2 Then
                Hour = "0" + hr.ToString
            Else Hour = hr.ToString()
            End If
            If min.ToString.Length < 2 Then
                Minute = "0" + min.ToString
            Else Minute = min.ToString()
            End If
            If sec.ToString.Length < 2 Then
                Second = "0" + sec.ToString
            Else Second = sec.ToString()
            End If
            Return Hour + ":" + Minute + ":" + Second
        End If
    End Function




    Public Sub EnterTrainingSub()


        Dim Distance As String
        If typelist.SelectedItem.Text = "Time Trial: 500m" Then
            Distance = "500"
        End If
        If typelist.SelectedItem.Text = "Time Trial: 2500m" Then
            Distance = "2500"
        End If
        If typelist.SelectedItem.Text = "Time Trial: 5000m" Then
            Distance = "5000"
        End If
        If typelist.SelectedItem.Text = "Custom Distance" Then
            Distance = CustomDistanceTextBoxHr.Text
        End If

        Dim ProfileID As New SqlParameter("@profile", SqlDbType.Int)
        ProfileID.Value = Session("User")
        Dim Type As New SqlParameter("@type", SqlDbType.VarChar)
        Type.Value = typelist.SelectedItem.Text
        Dim TotalDistance As New SqlParameter("@distance", SqlDbType.VarChar)
        If Not Distance Is Nothing Then
            TotalDistance.Value = Distance
        Else TotalDistance.Value = 0
        End If
        Dim TotalTime As New SqlParameter("@totaltime", SqlDbType.VarChar)
        TotalTime.Value = TotalTimeTextbox.Text
        Dim AvTime As New SqlParameter("@avper", SqlDbType.VarChar)
        AvTime.Value = Av500TextBox.Text
        Dim LowTime As New SqlParameter("@slowest", SqlDbType.VarChar)
        LowTime.Value = Slow500TextBox.Text
        Dim FastTime As New SqlParameter("@fastest", SqlDbType.VarChar)
        FastTime.Value = Fast500TextBox.Text
        Dim TrainingDate As New SqlParameter("@thedate", SqlDbType.DateTime)
        TrainingDate.Value = DateTime.Now

        Dim Params = New SqlParameter() {ProfileID, Type, TotalDistance, TotalTime, AvTime, LowTime, FastTime, TrainingDate}
        UpdateDBRet(MainDetailsSQL, Params)

        Dim Param = New SqlParameter() {}
        Dim ID As New DataSet
        ID = FetchResults(MaxID, Param)
        VarID = ID.Tables(0).Rows(0)("ID").ToString

        Dim SessionID As New SqlParameter("@SessionID", SqlDbType.Int)
        SessionID.Value = VarID
        Dim IntervalDistance As New SqlParameter("@IntervalDistance", SqlDbType.Int)
        Dim IntervalTime As New SqlParameter("@IntervalTime", SqlDbType.VarChar)

        Dim i As Int32 = 0
        Dim Len As Int16 = Session("Intervals").Rows.Count
        While i < Len
            IntervalDistance.Value = Session("Intervals").Rows(i)("Distance")
            IntervalTime.Value = Session("Intervals").Rows(i)("Split")
            Dim IntervalParams() = New SqlParameter() {SessionID, IntervalDistance, IntervalTime}
            UpdateDBRet(IntervalSQL, IntervalParams)
            i = i + 1
        End While




    End Sub

End Class
