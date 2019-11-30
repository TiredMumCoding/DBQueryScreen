Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Web.UI.WebControls
Imports System.Drawing

Public Class DataAccess

    Public Shared Function GetConnectionString()
        Return ConfigurationManager.ConnectionStrings("TiredMumRowConnectionString").ConnectionString
    End Function


    Public Shared Function FetchResults(sql As String, params As SqlParameter())
        Dim Results = New DataSet
        Dim cnn As New SqlConnection(GetConnectionString)
        cnn.Open()
        Dim cmd As New SqlCommand(sql, cnn)
        cmd.Parameters.AddRange(params)
        Dim MyDataAdapter As SqlDataAdapter = New SqlDataAdapter(cmd)
        MyDataAdapter.Fill(Results)
        cnn.Close()
        Return Results
    End Function


    Public Shared Function UpdateDBRet(sql As String, params As SqlParameter())
        Dim cnn As New SqlConnection(GetConnectionString)
        cnn.Open()
        Dim cmd As New SqlCommand(sql, cnn)
        cmd.Parameters.AddRange(params)
        Dim ret As Integer = cmd.ExecuteNonQuery()
        cmd.Parameters.Clear()
        cnn.Close()
        Return ret
    End Function


    Public Shared Function ValidateList(list As List(Of TextBox))
        Dim SubmitFlag As Boolean = True
        For Each item In list
            item.BackColor = ColorTranslator.FromHtml("#FFFFFF")
            item.Text = item.Text.Trim()
            If item.Text = "" Then
                SubmitFlag = False
                item.BackColor = ColorTranslator.FromHtml("#c39EA0")
            End If
        Next
        Return SubmitFlag
    End Function

End Class
