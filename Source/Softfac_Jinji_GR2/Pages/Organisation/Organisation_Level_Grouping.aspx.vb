Imports System
Imports System.Data
Imports System.Data.SqlClient

Partial Class Pages_Organisation_Organisation_Level_Grouping
    Inherits System.Web.UI.Page

#Region "Public Declaration"
    Private WithEvents mySQL As New clsSQL, myDS, myDS1, myDS2, myDS3, myDS4, myDS5 As New DataSet, mySetting As New clsGlobalSetting, myMsg As New clsMessage
    Private WithEvents myFileReader As New clsReadFile(System.AppDomain.CurrentDomain.BaseDirectory & "App_GlobalResources\Setup\Setup.ini")
    Public ssql As String, i As Integer, j As Integer, SearchByPage As Boolean, RecFound As Boolean, CountRecord As Integer
    Public AllowView, AllowInsert, AllowUpdate, AllowDelete, AllowPrint As Boolean
    Public _currentPageNumber As Integer, _totalPage As Double = 1, _totalRecords As Integer
    Public myDE As New DictionaryEntry, myHT As Hashtable
    Public myDataType As New clsGlobalSetting.DataType
#End Region

#Region "Private Declaration"
    Private WithEvents myDT1 As New DataTable, myDT2 As New DataTable
    Dim myDR1 As DataRow, myDR2 As DataRow, rcPerPage As Integer, autonum As Integer
    Dim ssql1, ssql2, ssql3, ssql4, ssql5, ssql6, ssql7 As String
    Dim rowPosition As String = "R_", rowPositionM As String = "RM_", panelPosition As String = "Display_"
    Dim buttonPosition1 As String = "B1_", buttonPosition2 As String = "B2_", buttonPosition3 As String = "B3_", labelPosition1 As String = "L1_"
    Dim logic As Boolean
    Dim strPath As String = "../../Images"
    Dim btnColourDef, btnColourAlt As String
#End Region

#Region "Page Setting"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Session.IsNewSession Then
            Response.Redirect("../Global/SessionTimeOut.aspx")
        End If

        If Not Page.IsPostBack Then
            Response.CacheControl = "no-cache"
            Response.AddHeader("Pragma", "no-cache")
            Response.Expires = -1

            If Session("ScreenWidth") = 0 Then
                Session("ScreenWidth") = "1024"
                Session("GVwidth") = Session("ScreenWidth") - 360
            End If
            If Session("ScreenHeight") = 0 Then
                Session("ScreenHeight") = "768"
                Session("GVheight") = (Session("ScreenHeight") / 2) - 50
            End If
            If Not Request.Browser.IsMobileDevice Then
                pnlgridview.Width = CInt(Session("GVwidth"))
                pnlgridview.Height = CInt(Session("GVheight"))
            End If
            PagePreload()
            BindGrid()
            'disable setting
            imgBtnDelete.Visible = False
            imgBtnFilter.Visible = False
        Else
            If IsNumeric(CurrentPage.Text) Then
                _currentPageNumber = CInt(CurrentPage.Text)
            Else
                _currentPageNumber = 1
            End If
        End If

    End Sub

    Sub PagePreload()
        btnColourDef = Session("strTheme")
        btnColourAlt = Session("strThemeAlt")
        Session("Module") = "Organisation"
        Session("action") = ""
        pnledit.Visible = False
        SearchByPage = False
        _currentPageNumber = 1
        Session("currentpage") = _currentPageNumber
        Session("flowNumber") = 0
        Session("runNumber") = 0
        FirstPage.Enabled = False
        PrevPage.Enabled = False
        NextPage.Enabled = False
        LastPage.Enabled = False

        'get Page Title
        ssql = "exec sp_sa_GetPageTitle '" & Form.ID & "'"
        myDS = mySQL.ExecuteSQL(ssql, Session("Company").ToString, Session("EmpID").ToString)
        If myDS.Tables(0).Rows.Count > 0 Then
            lblTitle.Text = myDS.Tables(0).Rows(0).Item(0)
            lblTitle.CssClass = "wordstyle4"
            lblTitle2.Text = myDS.Tables(0).Rows(0).Item(0)
            lblTitle2.CssClass = "wordstyle4"
        End If
        myDS = Nothing

        'label for list box
        lbllstleft.Text = "Available List"
        lbllstright.Text = "Selected List"
        lbllstleft.CssClass = "wordstyle5"
        lbllstright.CssClass = "wordstyle6"

        'get image 
        mySetting.GetImgUrl(imgCompany_Profile_Code, clsGlobalSetting.ImageType._KEY, Session("Company").ToString)
        mySetting.GetImgUrl(imgOCP_Code_Sector, clsGlobalSetting.ImageType._KEY, Session("Company").ToString)
        mySetting.GetImgUrl(imgOCP_Code_Division, clsGlobalSetting.ImageType._KEY, Session("Company").ToString)
        mySetting.GetImgUrl(imgOCP_Code_Department, clsGlobalSetting.ImageType._KEY, Session("Company").ToString)
        mySetting.GetImgUrl(imgOCP_Code_Section, clsGlobalSetting.ImageType._KEY, Session("Company").ToString)
        mySetting.GetImgUrl(imgOCP_Code_Line, clsGlobalSetting.ImageType._KEY, Session("Company").ToString)
        mySetting.GetImgUrl(imgOCP_Code_Group, clsGlobalSetting.ImageType._KEY, Session("Company").ToString)
        mySetting.GetImgUrl(imgOCP_Code_Process, clsGlobalSetting.ImageType._KEY, Session("Company").ToString)

        'get image button
        mySetting.GetImgBtnUrl(imgBtnCompany_Profile_Code, clsGlobalSetting.ImageType._LOOKUP, Session("Company").ToString)
        mySetting.GetImgBtnUrl(imgBtnOCP_Code_Sector, clsGlobalSetting.ImageType._LOOKUP, Session("Company").ToString)
        mySetting.GetImgBtnUrl(imgBtnOCP_Code_Division, clsGlobalSetting.ImageType._LOOKUP, Session("Company").ToString)
        mySetting.GetImgBtnUrl(imgBtnOCP_Code_Division2, clsGlobalSetting.ImageType._LOOKUP, Session("Company").ToString)
        mySetting.GetImgBtnUrl(imgBtnOCP_Code_Department, clsGlobalSetting.ImageType._LOOKUP, Session("Company").ToString)
        mySetting.GetImgBtnUrl(imgBtnOCP_Code_Department2, clsGlobalSetting.ImageType._LOOKUP, Session("Company").ToString)
        mySetting.GetImgBtnUrl(imgBtnOCP_Code_Section, clsGlobalSetting.ImageType._LOOKUP, Session("Company").ToString)
        mySetting.GetImgBtnUrl(imgBtnOCP_Code_Section2, clsGlobalSetting.ImageType._LOOKUP, Session("Company").ToString)
        mySetting.GetImgBtnUrl(imgBtnOCP_Code_Line, clsGlobalSetting.ImageType._LOOKUP, Session("Company").ToString)
        mySetting.GetImgBtnUrl(imgBtnOCP_Code_Line2, clsGlobalSetting.ImageType._LOOKUP, Session("Company").ToString)
        mySetting.GetImgBtnUrl(imgBtnOCP_Code_Group, clsGlobalSetting.ImageType._LOOKUP, Session("Company").ToString)
        mySetting.GetImgBtnUrl(imgBtnOCP_Code_Group2, clsGlobalSetting.ImageType._LOOKUP, Session("Company").ToString)
        mySetting.GetImgBtnUrl(imgBtnOCP_Code_Process, clsGlobalSetting.ImageType._LOOKUP, Session("Company").ToString)
        mySetting.GetImgBtnUrl(imgBtnOCP_Code_Process2, clsGlobalSetting.ImageType._LOOKUP, Session("Company").ToString)

        mySetting.GetBtnImgUrl(imgBtnSubmit, Session("Company").ToString, btnColourDef, "btnSubmit.png")
        mySetting.GetBtnImgUrl(imgBtnSearch, Session("Company").ToString, btnColourDef, "btnSearch.png")
        mySetting.GetBtnImgUrl(imgBtnClear, Session("Company").ToString, btnColourDef, "btnClear.png")
        mySetting.GetBtnImgUrl(imgBtnCancel, Session("Company").ToString, btnColourDef, "btnCancel.png")
        'mySetting.GetBtnImgUrl(imgBtnAdd, Session("Company").ToString, btnColourDef, "btnAdd.png")
        mySetting.GetBtnImgUrl(imgBtnFilter, Session("Company").ToString, btnColourDef, "btnFilter.png")
        mySetting.GetBtnImgUrl(imgBtnDelete, Session("Company").ToString, btnColourDef, "btnDelete.png")
        mySetting.GetBtnImgUrl(imgBtnPrint, Session("Company").ToString, btnColourDef, "btnPrint.png")
        'mySetting.GetBtnImgUrl(imgBtnUpdate, Session("Company").ToString, btnColourDef, "btnUpdate.png")
        'mySetting.GetBtnImgUrl(imgBtnEdit, Session("Company").ToString, btnColourDef, "btnEdit.png")
        mySetting.GetBtnImgUrl(imgBtnGoToPage, Session("Company").ToString, btnColourDef, "btngo.png")

        mySetting.GetBtnImgUrl(imgBtnAddAll, Session("Company").ToString, btnColourDef, "addall.png")
        mySetting.GetBtnImgUrl(imgBtnAddItem, Session("Company").ToString, btnColourDef, "additem.png")
        mySetting.GetBtnImgUrl(imgBtnRemoveAll, Session("Company").ToString, btnColourDef, "removeall.png")
        mySetting.GetBtnImgUrl(imgBtnRemoveItem, Session("Company").ToString, btnColourDef, "removeitem.png")

        body.Style("background-image") = strPath & "/" & Session("strTheme") & "/background2.jpg"

        'lookup field setting 
        'ssql = "Exec sp_sa_getLookupValue " & """" & "lkAonly" & """" & "," & """" & " " & """" & "," & """" & " " & """" & "," & """" & " " & """" & "," & """" & "Company_Profile" & """" & "," & """" & " " & """" & "," & """" & " " & """"
        'mySetting.GetLookupValue_ImageButton(imgBtnCompany_Profile_Code, Form.ID, "txtCompany_Profile_Code", "Code", ssql)
        'ssql = "Exec sp_sa_getLookupValue " & """" & "lkAwithB" & """" & "," & """" & "Option_Type" & """" & "," & """" & "Sector" & """" & "," & """" & " " & """" & "," & """" & "Organisation_Code_Profile" & """" & "," & """" & " " & """" & "," & """" & Session("Company") & """"
        'mySetting.GetLookupValue_ImageButton(imgBtnOCP_Code_Sector, Form.ID, "txtOCP_Code_Sector", "Code", ssql)

        'go button setting
        mySetting.SetTextBoxPressEnterGoToImageButton(txtGoToPage, imgBtnGoToPage)

        myDS = mySetting.GetLabelDescription_(Form.ID)
        If myDS.Tables.Count > 1 Then
            myDT1 = myDS.Tables(0)
            myDT2 = myDS.Tables(1)

            If myDT1.Rows.Count > 0 Then
                myDR1 = myDT1.Rows(0)

                Page.Title = myDR1(1)
                If myDR1(3) = "YES" Then
                    AllowView = True
                Else
                    AllowView = False
                    pnlaction.Visible = False
                    pnledit.Visible = False
                    pnlgridview.Visible = False
                    pnlmain.Visible = False
                    pnlprevnext.Visible = False
                    pnlresult.Visible = False
                    ShowMessage("You are not allow to view this page!")
                    Exit Sub
                End If

                If myDR1(4) = "YES" Then AllowInsert = True Else AllowInsert = False
                If myDR1(5) = "YES" Then AllowUpdate = True Else AllowUpdate = False
                If myDR1(6) = "YES" Then AllowDelete = True Else AllowDelete = False
                If myDR1(7) = "YES" Then AllowPrint = True Else AllowPrint = False

                Session("AllowView") = AllowView
                Session("AllowInsert") = AllowInsert
                Session("AllowUpdate") = AllowUpdate
                Session("AllowDelete") = AllowDelete
                Session("AllowPrint") = AllowPrint

                'imgBtnAdd.Visible = AllowInsert
                imgBtnSubmit.Visible = AllowInsert
                'imgBtnEdit.Visible = AllowUpdate
                imgBtnDelete.Visible = AllowDelete
                imgBtnSearch.Visible = AllowView
                imgBtnFilter.Visible = AllowView
                imgBtnClear.Visible = AllowView
                imgBtnCancel.Visible = AllowView
                imgBtnPrint.Visible = AllowPrint

                'Get GV page per record
                If myDR1(8) <= 0 Then
                    ssql = "exec sp_sa_organisation_default 'SetDG', '" & Session("Company") & "', '" & Session("Module") & "'"
                    myDS2 = mySQL.ExecuteSQL(ssql, Session("Company").ToString, Session("EmpID").ToString)
                    If myDS2.Tables(0).Rows.Count > 0 Then
                        Session("rcPerPage") = myDS2.Tables(0).Rows(0).Item(0)
                    End If
                    myDS2 = Nothing
                Else
                    Session("rcPerPage") = myDR1(8)
                End If
                myGridView.PageSize = Session("rcPerPage")
            Else
                lblresult.Text = "[Page Setting Error]: No setting found for this page!"
                Exit Sub
            End If

            If myDT2.Rows.Count > 0 Then
                lblCompany_Profile_Code.Text = myDT2.Rows(0).Item(3).ToString
                lblOCP_Code_Sector.Text = myDT2.Rows(1).Item(3).ToString
                lblOCP_Code_Division.Text = myDT2.Rows(2).Item(3).ToString
                lblOCP_Code_Department.Text = myDT2.Rows(3).Item(3).ToString
                lblOCP_Code_Section.Text = myDT2.Rows(4).Item(3).ToString
                lblOCP_Code_Line.Text = myDT2.Rows(5).Item(3).ToString
                lblOCP_Code_Group.Text = myDT2.Rows(6).Item(3).ToString
                lblOCP_Code_Process.Text = myDT2.Rows(7).Item(3).ToString

                'UCase Setting
                If myDT2.Rows(0).Item(4) = "YES" Then
                    mySetting.ConvertUppercase(txtCompany_Profile_Code)
                End If
                If myDT2.Rows(1).Item(4) = "YES" Then
                    mySetting.ConvertUppercase(txtOCP_Code_Sector)
                End If
                If myDT2.Rows(2).Item(4) = "YES" Then
                    mySetting.ConvertUppercase(txtOCP_Code_Division)
                End If
                If myDT2.Rows(3).Item(4) = "YES" Then
                    mySetting.ConvertUppercase(txtOCP_Code_Department)
                End If
                If myDT2.Rows(4).Item(4) = "YES" Then
                    mySetting.ConvertUppercase(txtOCP_Code_Section)
                End If
                If myDT2.Rows(5).Item(4) = "YES" Then
                    mySetting.ConvertUppercase(txtOCP_Code_Line)
                End If
                If myDT2.Rows(6).Item(4) = "YES" Then
                    mySetting.ConvertUppercase(txtOCP_Code_Group)
                End If
                If myDT2.Rows(7).Item(4) = "YES" Then
                    mySetting.ConvertUppercase(txtOCP_Code_Process)
                End If

                'Page Editable Setting
                Dim priNumCount As String = ""
                Dim edtNumCount As String = ""
                Dim compareNum1 As String = ""
                Dim compareNum0 As String = ""
                For Me.i = 0 To myDT2.Rows.Count - 1
                    If myDT2.Rows(i).Item(4) = "YES" Then
                        priNumCount = priNumCount & 1
                    Else
                        priNumCount = priNumCount & 0
                    End If
                    If myDT2.Rows(i).Item(11) = "YES" Then
                        edtNumCount = edtNumCount & 1
                    Else
                        edtNumCount = edtNumCount & 0
                    End If
                Next
                For Me.i = 1 To Len(priNumCount)
                    compareNum1 = compareNum1 & 1
                Next
                For Me.i = 1 To Len(edtNumCount)
                    compareNum0 = compareNum0 & 0
                Next
                If priNumCount = compareNum1 Or edtNumCount = compareNum0 Then
                    Session("pageNotEditable") = "YES"
                Else
                    Session("pageNotEditable") = "NO"
                End If

                'Page Filterable Setting
                priNumCount = ""
                Dim compareNum As String = ""
                For Me.i = 0 To myDT2.Rows.Count - 1
                    If myDT2.Rows(i).Item(13) = "NO" Then
                        priNumCount = priNumCount & 1
                    Else
                        priNumCount = priNumCount & 0
                    End If
                Next
                For Me.i = 1 To Len(priNumCount)
                    compareNum = compareNum & 1
                Next
                If priNumCount = compareNum Then
                    Session("pageNotFilterable") = "YES"
                Else
                    Session("pageNotFilterable") = "NO"
                End If
            End If

            myDS = Nothing
            myDT1 = Nothing
            myDT2 = Nothing
        Else
            lblresult.Text = "[Field Setting Error]: No setting found for this page!"
            Exit Sub
        End If

    End Sub

    Sub BindGrid()

        Try
            If Session("action") = "search" Then
                ssql = "exec sp_Generate_Query_Filter_WithSecurity '" & Session("Company").ToString & "','" & Session("EmpID").ToString & "','" & Session("Module") & "','" & Session("ssql1") & "', '" & Session("ssql2") & "' ,'" & Session("ssql3") & "','" & myGridView.PageSize & "','" & Session("currentpage") & "'"
            Else
                ssql = "exec sp_sa_organisation_grouping '" & Session("Company") & "','" & Session("Module") & "','" & myGridView.PageSize & "','" & Session("currentpage") & "'"
            End If

            myDS = mySQL.ExecuteSQL(ssql, Session("Company").ToString, Session("EmpID").ToString)
            pnldescription.Visible = False
            pnllstleft.Visible = False
            pnllstright.Visible = False
            btnColourDef = Session("strTheme")
            btnColourAlt = Session("strThemeAlt")

            If myDS.Tables(1).Rows.Count = 0 Then
                If Session("action") = "search" Then
                    pnledit.Visible = True
                    pnlmain.Visible = False
                    pnldescription.Visible = True
                    lblresult2.Visible = True
                    lblresult2.Text = "No Data Found..."
                Else
                    pnledit.Visible = False
                    pnlmain.Visible = True
                    pnldescription.Visible = False
                    imgBtnDelete.Enabled = False
                    imgBtnFilter.Enabled = False
                    imgBtnPrint.Enabled = False
                    imgBtnGoToPage.Enabled = False
                    'imgBtnEdit.Visible = False
                    'mySetting.GetBtnImgUrl(imgBtnEdit, Session("Company").ToString, btnColourAlt, "btnEdit.png")
                    mySetting.GetBtnImgUrl(imgBtnDelete, Session("Company").ToString, btnColourAlt, "btnDelete.png")
                    mySetting.GetBtnImgUrl(imgBtnFilter, Session("Company").ToString, btnColourAlt, "btnFilter.png")
                    mySetting.GetBtnImgUrl(imgBtnPrint, Session("Company").ToString, btnColourAlt, "btnPrint.png")
                    mySetting.GetBtnImgUrl(imgBtnGoToPage, Session("Company").ToString, btnColourAlt, "btnGo.png")
                    CurrentPage.Text = myDS.Tables(0).Rows(0).Item(0)
                    TotalPages.Text = myDS.Tables(0).Rows(0).Item(0)
                    lbltotal.Text = " ( " & myDS.Tables(0).Rows(0).Item(0) & " record(s) ) "
                    Session("currentPage") = "0"
                    myGridView.DataSource = myDS.Tables(1)
                    myGridView.DataBind()
                End If
                Exit Sub
            Else
                pnledit.Visible = False
                pnlmain.Visible = True
                pnldescription.Visible = False
                'imgBtnAdd.Enabled = True
                imgBtnDelete.Enabled = True
                imgBtnFilter.Enabled = True
                imgBtnPrint.Enabled = True
                imgBtnGoToPage.Enabled = True
                'imgBtnEdit.Enabled = True
                'mySetting.GetBtnImgUrl(imgBtnAdd, Session("Company").ToString, btnColourDef, "btnAdd.png")
                'mySetting.GetBtnImgUrl(imgBtnEdit, Session("Company").ToString, btnColourDef, "btnEdit.png")
                mySetting.GetBtnImgUrl(imgBtnDelete, Session("Company").ToString, btnColourDef, "btnDelete.png")
                mySetting.GetBtnImgUrl(imgBtnFilter, Session("Company").ToString, btnColourDef, "btnFilter.png")
                mySetting.GetBtnImgUrl(imgBtnPrint, Session("Company").ToString, btnColourDef, "btnPrint.png")
                mySetting.GetBtnImgUrl(imgBtnGoToPage, Session("Company").ToString, btnColourDef, "btnGo.png")
            End If

            If myDS.Tables.Count > 1 And CInt(myDS.Tables(0).Rows(0).Item(0)) > 0 Then
                myGridView.DataSource = myDS.Tables(1)
                myGridView.DataBind()

                'GridView Column Width Setting
                logic = False
                myDS1 = mySetting.GetGridViewWidth(Form.ID)
                myDT1 = myDS1.Tables(0)
                myDT2 = myDS1.Tables(1)
                Dim value As Decimal
                If myDT2.Rows.Count > 0 Then

                    If CInt(myDT1.Rows(0).Item(1).ToString) < CInt(Session("GVwidth")) Then
                        If CInt(myDT1.Rows(0).Item(1).ToString) = 0 Then
                            logic = True
                        Else
                            value = CInt(Session("GVwidth")) / CInt(myDT1.Rows(0).Item(1).ToString)
                        End If
                    Else
                        value = 1
                        myGridView.Width = CInt(myDT1.Rows(0).Item(1).ToString)
                    End If
                    If logic = False Then
                        For Me.i = 0 To myDT2.Rows.Count - 1
                            j = CInt(myDT2.Rows(i).Item(0).ToString) - 1  '+1 if hv item b4 data
                            If CInt(myDT2.Rows(i).Item(2).ToString) = 0 Then
                                myGridView.Rows(0).Cells(j).Width = 50 * value
                            Else
                                myGridView.Rows(0).Cells(j).Width = CInt(myDT2.Rows(i).Item(2).ToString) * value
                            End If
                        Next
                    End If
                End If
                myDS1 = Nothing
                myDT1 = Nothing
                myDT2 = Nothing

                lbltotal.Text = " ( " & myDS.Tables(0).Rows(0).Item(0) & " record(s) ) "
                CurrentPage.Text = Session("currentPage")

                If Not Page.IsPostBack Then
                    _totalRecords = myDS.Tables(0).Rows(0).Item(0)
                    _totalPage = _totalRecords / myGridView.PageSize
                    TotalPages.Text = (System.Math.Ceiling(_totalPage)).ToString()
                    Session("TotalPages") = TotalPages.Text
                Else
                    _totalRecords = myDS.Tables(0).Rows(0).Item(0)
                    _totalPage = _totalRecords / myGridView.PageSize
                    TotalPages.Text = (System.Math.Ceiling(_totalPage)).ToString()
                    _totalPage = Double.Parse(TotalPages.Text)
                    Session("TotalPages") = TotalPages.Text
                End If

                If Session("currentpage") = 1 Then
                    FirstPage.Enabled = False
                    PrevPage.Enabled = False
                    If _totalRecords > myGridView.PageSize Then
                        NextPage.Enabled = True
                        LastPage.Enabled = True
                    Else
                        NextPage.Enabled = False
                        LastPage.Enabled = False
                    End If
                ElseIf Session("currentpage") > 1 Then
                    FirstPage.Enabled = True
                    PrevPage.Enabled = True
                    If Session("currentpage") = Session("TotalPages") Then
                        NextPage.Enabled = False
                        LastPage.Enabled = False
                    Else
                        NextPage.Enabled = True
                        LastPage.Enabled = True
                    End If
                End If
                'If Session("currentpage") + 1 = Session("TotalPages") Then
                '    NextPage.Enabled = False
                'End If
                'If Session("currentpage") - 1 = 1 Then
                '    PrevPage.Enabled = False
                'End If
            End If
        Catch ex As Exception
            pnlresult.Visible = True
            lblresult.Text = "[BindGrid]Error: " & ex.Message
            pnlgridview.Visible = False
            pnlprevnext.Visible = False
            pnlaction.Visible = False
            Exit Sub
        End Try
    End Sub

#End Region

#Region "Panel Edit"

    Protected Sub imgBtnSubmit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnSubmit.Click

        If ValidateInsertUpdate() = True Then
            lblresult2.Text = "Data add/edit successfully..."
            Session("currentpage") = "1"
            'get position
            'Try
            '    ssql = "exec sp_sa_getPostInsert '" & Session("Company") & "','" & Session("Module") & "','" & Form.ID & "','" & Session("insertArgument") & "'"
            '    myDS = mySQL.ExecuteSQL(ssql)
            '    Dim z As Integer = myDS.Tables(0).Rows.Count

            '    If z > 0 Then
            '        Dim npos As String
            '        myGridView.PageSize = Session("rcPerPage")
            '        npos = myDS.Tables(0).Rows(0).Item(0) / Session("rcPerPage")
            '        Dim nposArray() As String = Split(npos, ".", 2)
            '        Session("currentpage") = CInt(nposArray(0)) + 1
            '    Else
            '        Session("currentpage") = "1"
            '    End If
            '    myDS = Nothing

            'Catch ex As Exception
            '    Session("currentpage") = "1"
            'End Try
            'BindGrid()
        End If

    End Sub

    Protected Sub imgBtnSearch_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnSearch.Click

        Dim ssql1 As String = ""
        Dim ssql2 As String = ""
        Dim ssql3 As String = ""
        Dim switch As Boolean = False
        Try
            myDS = mySQL.ExecuteSQL("Select Code,Option_Data_Type From Table_Field Where Table_Profile_Code='" & Form.ID & "' And Option_View='YES' Order By Table_Profile_Code,Sequence_No", Session("Company").ToString, Session("EmpID").ToString)
            If myDS.Tables(0).Rows.Count > 0 Then
                For Me.i = 0 To myDS.Tables(0).Rows.Count - 1
                    Select Case myDS.Tables(0).Rows(i).Item(1).ToString
                        Case "OPTION"
                            Dim myDropdownlist As DropDownList = Page.FindControl("ddl" & Trim(myDS.Tables(0).Rows(i).Item(0)))
                            If myDropdownlist.Visible = True And myDropdownlist.SelectedValue <> "" Then
                                If switch = False Then
                                    ssql1 = ssql1 & Form.ID
                                    ssql2 = ssql2 & myDS.Tables(0).Rows(i).Item(0)
                                    ssql3 = ssql3 & Trim(myDropdownlist.SelectedValue)
                                    switch = True
                                Else
                                    ssql1 = ssql1 & "@@" & Form.ID
                                    ssql2 = ssql2 & "@@" & myDS.Tables(0).Rows(i).Item(0)
                                    ssql3 = ssql3 & "@@" & Trim(myDropdownlist.SelectedValue)
                                End If
                            End If

                        Case "CHARACTER", "LOOKUP"
                            Dim myTextBox As TextBox = Page.FindControl("txt" & Trim(myDS.Tables(0).Rows(i).Item(0)))
                            If myTextBox.Visible = True And Trim(myTextBox.Text) <> "" Then
                                ssql4 = "Select Distinct Function_Name From User_Define_Function Where Module_Profile_Code = '" & Session("Module") & "' And Table_Profile_Code = '" & Form.ID & "' And Table_Field_Code = '" & Trim(myDS.Tables(0).Rows(i).Item(0)) & "' And Query_Action In ('INSERT','UPDATE','DELETE')"
                                myDS1 = mySQL.ExecuteSQL(ssql4, Session("Company").ToString, Session("EmpID").ToString)
                                If myDS1.Tables(0).Rows.Count > 0 Then
                                    ssql5 = "Select " & Trim(myDS1.Tables(0).Rows(0).Item(0).ToString) & "('" & Trim(myTextBox.Text) & "')"
                                    myDS2 = mySQL.ExecuteSQL(ssql5, Session("Company").ToString, Session("EmpID").ToString)
                                    If Trim(myDS2.Tables(0).Rows(0).Item(0).ToString) <> "" Then
                                        If switch = False Then
                                            ssql1 = ssql1 & Form.ID
                                            ssql2 = ssql2 & myDS.Tables(0).Rows(i).Item(0)
                                            ssql3 = ssql3 & Trim(myDS2.Tables(0).Rows(0).Item(0).ToString)
                                            switch = True
                                        Else
                                            ssql1 = ssql1 & "@@" & Form.ID
                                            ssql2 = ssql2 & "@@" & myDS.Tables(0).Rows(i).Item(0)
                                            ssql3 = ssql3 & "@@" & Trim(myDS2.Tables(0).Rows(0).Item(0).ToString)
                                        End If
                                    Else
                                        'Fail to retrieve option code
                                    End If
                                Else
                                    If switch = False Then
                                        ssql1 = ssql1 & Form.ID
                                        ssql2 = ssql2 & myDS.Tables(0).Rows(i).Item(0)
                                        ssql3 = ssql3 & Trim(myTextBox.Text)
                                        switch = True
                                    Else
                                        ssql1 = ssql1 & "@@" & Form.ID
                                        ssql2 = ssql2 & "@@" & myDS.Tables(0).Rows(i).Item(0)
                                        ssql3 = ssql3 & "@@" & Trim(myTextBox.Text)
                                    End If
                                End If
                            End If

                        Case "DECIMAL", "INTEGER"
                            Dim myTextBox As TextBox = Page.FindControl("txt" & Trim(myDS.Tables(0).Rows(i).Item(0)))
                            If myTextBox.Visible = True And Trim(myTextBox.Text) <> "" Then
                                If switch = False Then
                                    ssql1 = ssql1 & Form.ID
                                    ssql2 = ssql2 & myDS.Tables(0).Rows(i).Item(0)
                                    ssql3 = ssql3 & Trim(myTextBox.Text)
                                    switch = True
                                Else
                                    ssql1 = ssql1 & "@@" & Form.ID
                                    ssql2 = ssql2 & "@@" & myDS.Tables(0).Rows(i).Item(0)
                                    ssql3 = ssql3 & "@@" & Trim(myTextBox.Text)
                                End If
                            End If

                        Case "DATE", "DATETIME"
                            Dim myTextBox As TextBox = Page.FindControl("txt" & Trim(myDS.Tables(0).Rows(i).Item(0)))
                            If myTextBox.Visible = True And Trim(myTextBox.Text) <> "" Then
                                If switch = False Then
                                    ssql1 = ssql1 & Form.ID
                                    ssql2 = ssql2 & myDS.Tables(0).Rows(i).Item(0)
                                    ssql3 = ssql3 & mySetting.ConvertDateToDecimal(Trim(myTextBox.Text), Session("Company"), Session("Module"))
                                    switch = True
                                Else
                                    ssql1 = ssql1 & "@@" & Form.ID
                                    ssql2 = ssql2 & "@@" & myDS.Tables(0).Rows(i).Item(0)
                                    ssql3 = ssql3 & "@@" & mySetting.ConvertDateToDecimal(Trim(myTextBox.Text), Session("Company"), Session("Module"))
                                End If
                            End If
                    End Select
                Next

                If ssql1 <> "" And ssql2 <> "" And ssql3 <> "" Then
                    Session("ssql1") = ssql1
                    Session("ssql2") = ssql2
                    Session("ssql3") = ssql3
                    Session("action") = "search"
                Else
                    Session("action") = "any"
                End If
                Session("currentpage") = "1"
                lblresult.Text = ""
                myDS = Nothing
                BindGrid()
            End If
        Catch ex As Exception
            pnledit.Visible = False
            pnlmain.Visible = True
            lblresult.Text = "[imgBtnSearch_Click]Error: " & ex.Message
        End Try

    End Sub

    Protected Sub imgBtnClear_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnClear.Click

        Try
            Dim code As Integer = 2
            Dim dt As Integer = 6
            Session("action") = "clear"
            lblresult2.Text = ""
            lstleft.Items.Clear()
            lstright.Items.Clear()

            myDS = mySetting.GetLabelDescription_(Form.ID)
            If CInt(myDS.Tables.Count) > 1 Then
                If CInt(myDS.Tables(1).Rows.Count) > 0 Then
                    For Me.i = 0 To myDS.Tables(1).Rows.Count - 1
                        Dim myLabel As Label = Page.FindControl("lbl" & Trim(myDS.Tables(1).Rows(i).Item(code).ToString))
                        Select Case UCase(Trim(myDS.Tables(1).Rows(i).Item(dt).ToString))
                            Case "OPTION"
                                Dim myDropdownlist As DropDownList = Page.FindControl("ddl" & Trim(myDS.Tables(1).Rows(i).Item(code).ToString))
                                If myLabel.Enabled = True Then
                                    myDropdownlist.SelectedIndex = 0
                                End If
                            Case Else
                                Dim myTextBox As TextBox = Page.FindControl("txt" & Trim(myDS.Tables(1).Rows(i).Item(code).ToString))
                                If myLabel.Enabled = True Then
                                    myTextBox.Text = ""
                                End If
                        End Select
                    Next
                End If
            End If
            myDS = Nothing
        Catch ex As Exception
            lblresult.Text = "[imgBtnClear_Click]Error: " & ex.Message
            SetFieldToFalse()
        End Try

    End Sub

    Protected Sub imgBtnCancel_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnCancel.Click
        Session("action") = "cancel"
        Session("action_edit") = ""
        BindGrid()
    End Sub

    Protected Sub imgBtnCompany_Profile_Code_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnCompany_Profile_Code.Click
        disableLst()
        disableTxt()
        txtCompany_Profile_Code.Enabled = True
        lstleft.Items.Clear()
        lstright.Items.Clear()
        lblresult2.Text = ""
        Session("flowNumber") = 1
        Session("runNumber") = 1
    End Sub

    Protected Sub imgBtnOCP_Code_Sector_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnOCP_Code_Sector.Click
        disableLst()
        disableTxt()
        txtOCP_Code_Sector.Enabled = True
        lstleft.Items.Clear()
        lstright.Items.Clear()
        lblresult2.Text = ""
        Session("flowNumber") = 2
        Session("runNumber") = 2
    End Sub

    Protected Sub imgBtnOCP_Code_Division_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnOCP_Code_Division.Click

        Session("flowNumber") = 3
        Session("runNumber") = 3
        visibleLst()
        lstleft.Items.Clear()
        lstright.Items.Clear()
        txtOCP_Code_Division.Text = ""
        Session("action_edit") = "division"
        AutoAdjustPosition("2")
        imgBtnCancel.CssClass = buttonPosition3
        imgBtnClear.CssClass = buttonPosition2
        imgBtnSubmit.CssClass = buttonPosition1
        'imgtop.ImageUrl = "../../Images/Default/gif/imgtop_add.gif"
        'imgbottom.ImageUrl = "../../Images/Default/gif/imgbottom.gif"
        disableLst()
        disableTxt()
        'lstleft.Enabled = True
        lstright.Enabled = True
        lblresult2.Text = ""

    End Sub

    Protected Sub imgBtnOCP_Code_Division2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnOCP_Code_Division2.Click

        If ActionValidateFieldCompany() = False Then
            lblresult2.Text = lblCompany_Profile_Code.Text & " field is required..."
            Exit Sub
        End If
        If ActionValidateFieldSector() = False Then
            lblresult2.Text = lblOCP_Code_Sector.Text & " field is required..."
            Exit Sub
        End If
        ssql = "Exec sp_sa_getListBoxValue 'Sector_Division','" & txtCompany_Profile_Code.Text & "','" & txtOCP_Code_Sector.Text & "','','','','',''"
        myDS = mySQL.ExecuteSQL(ssql, Session("Company").ToString, Session("EmpID").ToString)
        If myDS.Tables(0).Rows.Count > 0 Then
            lstleft.DataSource = myDS.Tables(0)
            lstleft.DataTextField = "Name"
            lstleft.DataValueField = "Code"
            lstleft.DataBind()
        End If
        If myDS.Tables(1).Rows.Count > 0 Then
            lstright.DataSource = myDS.Tables(1)
            lstright.DataTextField = "Name"
            lstright.DataValueField = "Code"
            lstright.DataBind()
        End If
        disableTxt()
        lstright.Enabled = True
        lblresult2.Text = ""

    End Sub

    Protected Sub imgBtnOCP_Code_Department_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnOCP_Code_Department.Click

        Session("flowNumber") = 4
        logic = False
        If CInt(Session("runNumber")) > CInt(Session("flowNumber")) Then
            logic = True
        End If
        Dim numcount As Integer = 0
        If CInt(Session("runNumber")) < CInt(Session("flowNumber")) Then
            For Me.i = 0 To lstright.Items.Count - 1
                If lstright.Items(i).Selected Then
                    numcount = numcount + 1
                    If numcount > 1 Then
                        lblresult2.Text = "Only one value can be seleted..."
                        'Exit Sub
                    Else
                        txtOCP_Code_Division.Text = lstright.Items(i).Value.ToString
                        logic = True
                    End If
                End If
            Next
            If numcount = 0 Then
                lblresult2.Text = lblOCP_Code_Division.Text & " is a required field..."
                'Exit Sub
            End If
        End If

        If logic = True Then
            Session("runNumber") = 4
            visibleLst()
            lstleft.Items.Clear()
            lstright.Items.Clear()
            txtOCP_Code_Department.Text = ""
            Session("action_edit") = "department"
            AutoAdjustPosition("2")
            imgBtnCancel.CssClass = buttonPosition3
            imgBtnClear.CssClass = buttonPosition2
            imgBtnSubmit.CssClass = buttonPosition1
            'imgtop.ImageUrl = "../../Images/Default/gif/imgtop_add.gif"
            'imgbottom.ImageUrl = "../../Images/Default/gif/imgbottom.gif"
            disableLst()
            disableTxt()
            'lstleft.Enabled = True
            lstright.Enabled = True
            lblresult2.Text = ""
        End If

    End Sub

    Protected Sub imgBtnOCP_Code_Department2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnOCP_Code_Department2.Click

        ssql = "Exec sp_sa_getListBoxValue 'Division_Department','" & txtCompany_Profile_Code.Text & "','" & txtOCP_Code_Sector.Text & "','" & txtOCP_Code_Division.Text & "','','','',''"
        myDS = mySQL.ExecuteSQL(ssql, Session("Company").ToString, Session("EmpID").ToString)
        If myDS.Tables(0).Rows.Count > 0 Then
            lstleft.DataSource = myDS.Tables(0)
            lstleft.DataTextField = "Name"
            lstleft.DataValueField = "Code"
            lstleft.DataBind()
        End If
        If myDS.Tables(1).Rows.Count > 0 Then
            lstright.DataSource = myDS.Tables(1)
            lstright.DataTextField = "Name"
            lstright.DataValueField = "Code"
            lstright.DataBind()
        End If
        disableTxt()
        lstright.Enabled = True
        lblresult2.Text = ""

    End Sub

    Protected Sub imgBtnOCP_Code_Section_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnOCP_Code_Section.Click

        Session("flowNumber") = 5
        logic = False
        If CInt(Session("runNumber")) > CInt(Session("flowNumber")) Then
            logic = True
        End If
        Dim numcount As Integer = 0
        If CInt(Session("runNumber")) < CInt(Session("flowNumber")) Then
            For Me.i = 0 To lstright.Items.Count - 1
                If lstright.Items(i).Selected Then
                    numcount = numcount + 1
                    If numcount > 1 Then
                        lblresult2.Text = "Only one value can be seleted..."
                        'Exit Sub
                    Else
                        txtOCP_Code_Department.Text = lstright.Items(i).Value.ToString
                        logic = True
                    End If
                End If
            Next
            If numcount = 0 Then
                lblresult2.Text = lblOCP_Code_Department.Text & " is a required field..."
                'Exit Sub
            End If
        End If

        If logic = True Then
            Session("runNumber") = 5
            visibleLst()
            lstleft.Items.Clear()
            lstright.Items.Clear()
            txtOCP_Code_Section.Text = ""
            Session("action_edit") = "section"
            AutoAdjustPosition("2")
            imgBtnCancel.CssClass = buttonPosition3
            imgBtnClear.CssClass = buttonPosition2
            imgBtnSubmit.CssClass = buttonPosition1
            'imgtop.ImageUrl = "../../Images/Default/gif/imgtop_add.gif"
            'imgbottom.ImageUrl = "../../Images/Default/gif/imgbottom.gif"
            disableLst()
            disableTxt()
            'lstleft.Enabled = True
            lstright.Enabled = True
            lblresult2.Text = ""
        End If

    End Sub

    Protected Sub imgBtnOCP_Code_Section2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnOCP_Code_Section2.Click

        ssql = "Exec sp_sa_getListBoxValue 'Department_Section','" & txtCompany_Profile_Code.Text & "','" & txtOCP_Code_Sector.Text & "','" & txtOCP_Code_Division.Text & "','" & txtOCP_Code_Department.Text & "','','',''"
        myDS = mySQL.ExecuteSQL(ssql, Session("Company").ToString, Session("EmpID").ToString)
        If myDS.Tables(0).Rows.Count > 0 Then
            lstleft.DataSource = myDS.Tables(0)
            lstleft.DataTextField = "Name"
            lstleft.DataValueField = "Code"
            lstleft.DataBind()
        End If
        If myDS.Tables(1).Rows.Count > 0 Then
            lstright.DataSource = myDS.Tables(1)
            lstright.DataTextField = "Name"
            lstright.DataValueField = "Code"
            lstright.DataBind()
        End If
        disableTxt()
        lstright.Enabled = True
        lblresult2.Text = ""

    End Sub

    Protected Sub imgBtnOCP_Code_Line_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnOCP_Code_Line.Click

        Session("flowNumber") = 6
        logic = False
        If CInt(Session("runNumber")) > CInt(Session("flowNumber")) Then
            logic = True
        End If
        Dim numcount As Integer = 0
        If CInt(Session("runNumber")) < CInt(Session("flowNumber")) Then
            For Me.i = 0 To lstright.Items.Count - 1
                If lstright.Items(i).Selected Then
                    numcount = numcount + 1
                    If numcount > 1 Then
                        lblresult2.Text = "Only one value can be seleted..."
                        'Exit Sub
                    Else
                        txtOCP_Code_Section.Text = lstright.Items(i).Value.ToString
                        logic = True
                    End If
                End If
            Next
            If numcount = 0 Then
                lblresult2.Text = lblOCP_Code_Section.Text & " is a required field..."
                'Exit Sub
            End If
        End If

        If logic = True Then
            Session("runNumber") = 6
            visibleLst()
            lstleft.Items.Clear()
            lstright.Items.Clear()
            txtOCP_Code_Line.Text = ""
            Session("action_edit") = "line"
            AutoAdjustPosition("2")
            imgBtnCancel.CssClass = buttonPosition3
            imgBtnClear.CssClass = buttonPosition2
            imgBtnSubmit.CssClass = buttonPosition1
            'imgtop.ImageUrl = "../../Images/Default/gif/imgtop_add.gif"
            'imgbottom.ImageUrl = "../../Images/Default/gif/imgbottom.gif"
            disableLst()
            disableTxt()
            'lstleft.Enabled = True
            lstright.Enabled = True
            lblresult2.Text = ""
        End If

    End Sub

    Protected Sub imgBtnOCP_Code_Line2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnOCP_Code_Line2.Click

        ssql = "Exec sp_sa_getListBoxValue 'Section_Line','" & txtCompany_Profile_Code.Text & "','" & txtOCP_Code_Sector.Text & "','" & txtOCP_Code_Division.Text & "','" & txtOCP_Code_Department.Text & "','" & txtOCP_Code_Section.Text & "','',''"
        myDS = mySQL.ExecuteSQL(ssql, Session("Company").ToString, Session("EmpID").ToString)
        If myDS.Tables(0).Rows.Count > 0 Then
            lstleft.DataSource = myDS.Tables(0)
            lstleft.DataTextField = "Name"
            lstleft.DataValueField = "Code"
            lstleft.DataBind()
        End If
        If myDS.Tables(1).Rows.Count > 0 Then
            lstright.DataSource = myDS.Tables(1)
            lstright.DataTextField = "Name"
            lstright.DataValueField = "Code"
            lstright.DataBind()
        End If
        disableTxt()
        lstright.Enabled = True
        lblresult2.Text = ""

    End Sub

    Protected Sub imgBtnOCP_Code_Group_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnOCP_Code_Group.Click

        Session("flowNumber") = 7
        logic = False
        If CInt(Session("runNumber")) > CInt(Session("flowNumber")) Then
            logic = True
        End If
        Dim numcount As Integer = 0
        If CInt(Session("runNumber")) < CInt(Session("flowNumber")) Then
            For Me.i = 0 To lstright.Items.Count - 1
                If lstright.Items(i).Selected Then
                    numcount = numcount + 1
                    If numcount > 1 Then
                        lblresult2.Text = "Only one value can be seleted..."
                        'Exit Sub
                    Else
                        txtOCP_Code_Line.Text = lstright.Items(i).Value.ToString
                        logic = True
                    End If
                End If
            Next
            If numcount = 0 Then
                lblresult2.Text = lblOCP_Code_Line.Text & " is a required field..."
                'Exit Sub
            End If
        End If

        If logic = True Then
            Session("runNumber") = 7
            visibleLst()
            lstleft.Items.Clear()
            lstright.Items.Clear()
            txtOCP_Code_Group.Text = ""
            Session("action_edit") = "group"
            AutoAdjustPosition("2")
            imgBtnCancel.CssClass = buttonPosition3
            imgBtnClear.CssClass = buttonPosition2
            imgBtnSubmit.CssClass = buttonPosition1
            'imgtop.ImageUrl = "../../Images/Default/gif/imgtop_add.gif"
            'imgbottom.ImageUrl = "../../Images/Default/gif/imgbottom.gif"
            disableLst()
            disableTxt()
            'lstleft.Enabled = True
            lstright.Enabled = True
            lblresult2.Text = ""
        End If

    End Sub

    Protected Sub imgBtnOCP_Code_Group2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnOCP_Code_Group2.Click
        ssql = "Exec sp_sa_getListBoxValue 'Line_Group','" & txtCompany_Profile_Code.Text & "','" & txtOCP_Code_Sector.Text & "','" & txtOCP_Code_Division.Text & "','" & txtOCP_Code_Department.Text & "','" & txtOCP_Code_Section.Text & "','" & txtOCP_Code_Line.Text & "',''"
        myDS = mySQL.ExecuteSQL(ssql, Session("Company").ToString, Session("EmpID").ToString)
        If myDS.Tables(0).Rows.Count > 0 Then
            lstleft.DataSource = myDS.Tables(0)
            lstleft.DataTextField = "Name"
            lstleft.DataValueField = "Code"
            lstleft.DataBind()
        End If
        If myDS.Tables(1).Rows.Count > 0 Then
            lstright.DataSource = myDS.Tables(1)
            lstright.DataTextField = "Name"
            lstright.DataValueField = "Code"
            lstright.DataBind()
        End If
        disableTxt()
        lstright.Enabled = True
        lblresult2.Text = ""
    End Sub

    Protected Sub imgBtnOCP_Code_Process_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnOCP_Code_Process.Click

        Session("flowNumber") = 8
        logic = False
        If CInt(Session("runNumber")) > CInt(Session("flowNumber")) Then
            logic = True
        End If
        Dim numcount As Integer = 0
        If CInt(Session("runNumber")) < CInt(Session("flowNumber")) Then
            For Me.i = 0 To lstright.Items.Count - 1
                If lstright.Items(i).Selected Then
                    numcount = numcount + 1
                    If numcount > 1 Then
                        lblresult2.Text = "Only one value can be seleted..."
                        'Exit Sub
                    Else
                        txtOCP_Code_Group.Text = lstright.Items(i).Value.ToString
                        logic = True
                    End If
                End If
            Next
            If numcount = 0 Then
                lblresult2.Text = lblOCP_Code_Group.Text & " is a required field..."
                'Exit Sub
            End If
        End If

        If logic = True Then
            Session("runNumber") = 8
            visibleLst()
            lstleft.Items.Clear()
            lstright.Items.Clear()
            txtOCP_Code_Process.Text = ""
            Session("action_edit") = "process"
            AutoAdjustPosition("2")
            imgBtnCancel.CssClass = buttonPosition3
            imgBtnClear.CssClass = buttonPosition2
            imgBtnSubmit.CssClass = buttonPosition1
            'imgtop.ImageUrl = "../../Images/Default/gif/imgtop_add.gif"
            'imgbottom.ImageUrl = "../../Images/Default/gif/imgbottom.gif"
            disableLst()
            disableTxt()
            lstleft.Enabled = True
            lstright.Enabled = True
            lblresult2.Text = ""
        End If

    End Sub

    Protected Sub imgBtnOCP_Code_Process2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnOCP_Code_Process2.Click
        ssql = "Exec sp_sa_getListBoxValue 'Group_Process','" & txtCompany_Profile_Code.Text & "','" & txtOCP_Code_Sector.Text & "','" & txtOCP_Code_Division.Text & "','" & txtOCP_Code_Department.Text & "','" & txtOCP_Code_Section.Text & "','" & txtOCP_Code_Line.Text & "','" & txtOCP_Code_Group.Text & "'"
        myDS = mySQL.ExecuteSQL(ssql, Session("Company").ToString, Session("EmpID").ToString)
        If myDS.Tables(0).Rows.Count > 0 Then
            lstleft.DataSource = myDS.Tables(0)
            lstleft.DataTextField = "Name"
            lstleft.DataValueField = "Code"
            lstleft.DataBind()
        End If
        If myDS.Tables(1).Rows.Count > 0 Then
            lstright.DataSource = myDS.Tables(1)
            lstright.DataTextField = "Name"
            lstright.DataValueField = "Code"
            lstright.DataBind()
        End If
        disableTxt()
        enableLst()
        lblresult2.Text = ""
    End Sub

    Protected Sub imgBtnAddAll_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnAddAll.Click
        If ActionValidateFieldCompany() = False Then
            lblresult2.Text = lblCompany_Profile_Code.Text & " is a required field..."
            Exit Sub
        End If
        If ActionValidateFieldSector() = False Then
            lblresult2.Text = lblOCP_Code_Sector.Text & " is a required field..."
            Exit Sub
        End If
        AddRemoveAll(lstleft, lstright)
        lblresult2.Text = ""
    End Sub

    Protected Sub imgBtnAddItem_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnAddItem.Click
        If ActionValidateFieldCompany() = False Then
            lblresult2.Text = lblCompany_Profile_Code.Text & " is a required field..."
            Exit Sub
        End If
        If ActionValidateFieldSector() = False Then
            lblresult2.Text = lblOCP_Code_Sector.Text & " is a required field..."
            Exit Sub
        End If
        AddRemoveItem(lstleft, lstright)
        lblresult2.Text = ""
    End Sub

    Protected Sub imgBtnRemoveItem_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnRemoveItem.Click
        If ActionValidateFieldCompany() = False Then
            lblresult2.Text = lblCompany_Profile_Code.Text & " is a required field..."
            Exit Sub
        End If
        If ActionValidateFieldSector() = False Then
            lblresult2.Text = lblOCP_Code_Sector.Text & " is a required field..."
            Exit Sub
        End If
        AddRemoveItem(lstright, lstleft)
        lblresult2.Text = ""
    End Sub

    Protected Sub imgBtnRemoveAll_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnRemoveAll.Click
        If ActionValidateFieldCompany() = False Then
            lblresult2.Text = lblCompany_Profile_Code.Text & " is a required field..."
            Exit Sub
        End If
        If ActionValidateFieldSector() = False Then
            lblresult2.Text = lblOCP_Code_Sector.Text & " is a required field..."
            Exit Sub
        End If
        AddRemoveAll(lstright, lstleft)
        lblresult2.Text = ""
    End Sub

    Sub disableLst()
        lstleft.Enabled = False
        lstright.Enabled = False
        imgBtnAddAll.Enabled = False
        imgBtnAddItem.Enabled = False
        imgBtnRemoveAll.Enabled = False
        imgBtnRemoveItem.Enabled = False
    End Sub

    Sub enableLst()
        lstleft.Enabled = True
        lstright.Enabled = True
        imgBtnAddAll.Enabled = True
        imgBtnAddItem.Enabled = True
        imgBtnRemoveAll.Enabled = True
        imgBtnRemoveItem.Enabled = True
    End Sub

    Sub visibleLst()
        lstleft.Visible = True
        lstright.Visible = True
        imgBtnAddAll.Visible = True
        imgBtnAddItem.Visible = True
        imgBtnRemoveAll.Visible = True
        imgBtnRemoveItem.Visible = True
    End Sub

    Sub invisibleLst()
        lstleft.Visible = False
        lstright.Visible = False
        imgBtnAddAll.Visible = False
        imgBtnAddItem.Visible = False
        imgBtnRemoveAll.Visible = False
        imgBtnRemoveItem.Visible = False
    End Sub

    Sub disableTxt()
        txtCompany_Profile_Code.Enabled = False
        txtOCP_Code_Sector.Enabled = False
        txtOCP_Code_Division.Enabled = False
        txtOCP_Code_Department.Enabled = False
        txtOCP_Code_Section.Enabled = False
        txtOCP_Code_Line.Enabled = False
        txtOCP_Code_Group.Enabled = False
        txtOCP_Code_Process.Enabled = False
    End Sub

#End Region

#Region "Panel GridView"

    Protected Sub myGridView_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles myGridView.RowDataBound

        e.Row.Attributes.Add("onmouseover", "this.originalcolor=this.style.backgroundColor; this.style.backgroundColor='silver';")
        e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalcolor;")

    End Sub

#End Region

#Region "Panel Action"

    Public Sub NavigationLink_Click(ByVal sender As Object, ByVal e As CommandEventArgs)

        Select Case e.CommandName
            Case "First"
                Session("currentpage") = 1
            Case "Prev"
                Session("currentpage") = Integer.Parse(CurrentPage.Text) - 1
            Case "Next"
                Session("currentpage") = Integer.Parse(CurrentPage.Text) + 1
            Case "Last"
                Session("currentpage") = Integer.Parse(TotalPages.Text)
        End Select
        lblresult.Text = ""
        BindGrid()

    End Sub

    Protected Sub imgBtnGoToPage_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnGoToPage.Click

        If txtGoToPage.Text = "" Then
            lblresult.Text = "Request failed! Value required..."
            txtGoToPage.Focus()
            Exit Sub
        End If

        Try
            Dim pagestr As String = Trim(txtGoToPage.Text)
            Dim pagenum As Integer = CInt(pagestr)
            Dim firstnum As Integer = 0
            Dim lastnum As Integer = 0

            If pagenum <= CInt(Session("TotalPages")) And pagenum > 0 Then
                If pagenum = CInt(Session("currentPage")) Then
                    lblresult.Text = "Request failed! You are looking for the same page..."
                    txtGoToPage.Focus()
                Else
                    lblresult.Text = ""
                    Session("currentpage") = pagenum
                    BindGrid()
                End If
                txtGoToPage.Text = ""
            Else
                If pagenum = 1 Or pagenum > CInt(Session("TotalPages")) And CInt(Session("TotalPages")) = 1 Then
                    lblresult.Text = "Request failed! Only one page available..."
                Else
                    If CInt(Session("currentPage")) = 1 Then
                        firstnum = 1
                    Else
                        firstnum = 0
                    End If
                    If CInt(Session("currentPage")) = CInt(Session("TotalPages")) Then
                        lastnum = CInt(Session("TotalPages"))
                    Else
                        lastnum = CInt(Session("TotalPages")) + 1
                    End If
                    lblresult.Text = "Request failed! Page number must between " & firstnum & " and " & lastnum & "..."
                End If
                txtGoToPage.Text = ""
                txtGoToPage.Focus()
            End If

        Catch ex As Exception
            lblresult.Text = "Request failed! Invalid value enter..."
            txtGoToPage.Text = ""
            txtGoToPage.Focus()
            Exit Sub
        End Try

    End Sub

    Protected Sub imgBtnFilter_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnFilter.Click

        If Session("pageNotFilterable") = "YES" Then
            lblresult.Text = "Field(s) not filterable..."
            Exit Sub
        End If

        Session("action") = "filter"
        Session("action_edit") = ""
        ClearText()
        SetFieldToTrue()
        SetVisible()
        imgBtnSearch.Visible = True
        imgBtnSubmit.Visible = False
        invisibleLst()
        pnldescription.Visible = True
        AutoAdjustPosition("2")

        'check for addable field
        If autonum = 0 Then
            pnledit.Visible = False
            pnlmain.Visible = True
            ShowMessage("No addable item found for this page...")
            Exit Sub
        End If

        imgBtnCancel.CssClass = buttonPosition3
        imgBtnClear.CssClass = buttonPosition2
        imgBtnSearch.CssClass = buttonPosition1
        mySetting.GetImgTypeUrl(imgtop, Session("Company"), Session("strTheme"), "backgroundTitleTop_Filter.png")
        mySetting.GetImgTypeUrl(imgbottom, Session("Company"), Session("strTheme"), "backgroundTitleBottom.png")

    End Sub

#End Region

#Region "Sub & Function"

    Private Sub ShowMessage(ByVal message As String)

        Dim scriptString As String = "<script language=JavaScript>"
        scriptString += "alert('" + message + "');"
        scriptString += "<" & "/script>"
        Page.ClientScript.RegisterClientScriptBlock(GetType(Page), "ShowMessage", scriptString)

    End Sub

    Private Function ActionValidateFieldCompany() As Boolean

        If txtCompany_Profile_Code.Text <> "" Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Function ActionValidateFieldSector() As Boolean

        If txtOCP_Code_Sector.Text <> "" Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Function ActionValidateEdit() As Boolean
        RecFound = False
        CountRecord = 0
        lblresult.Text = ""
        For Me.i = 0 To myGridView.Rows.Count - 1
            Dim chkEdit As CheckBox = myGridView.Rows(i).Cells(0).Controls(1)
            If chkEdit.Checked Then
                RecFound = True
                CountRecord = CountRecord + 1
            End If
        Next
        If RecFound = True Then
            If CountRecord > 1 Then
                lblresult.Text = "Invalid action: Only 1 row can be selected for editing..."
                Return False
            Else
                Return True
            End If
        Else
            lblresult.Text = "Invalid action: No row selected for editing..."
            Return False
        End If
    End Function

    Sub SetVisible()

        Try 'ModifyOn051106
            myDS = mySetting.GetPageFieldSetting(Session("Company"), Form.ID, Session("EmpID"))
            If CInt(myDS.Tables.Count) > 1 Then
                If CInt(myDS.Tables(1).Rows.Count) > 0 Then

                    Dim en, vv, vw, dt, md, pr, et, fl, ps, code, name, maxlength As Integer

                    For Me.i = 0 To myDS.Tables(1).Columns.Count - 1
                        If UCase(myDS.Tables(1).Columns(i).ToString) = "CODE" Then
                            code = i
                        ElseIf UCase(myDS.Tables(1).Columns(i).ToString) = "NAME" Then
                            name = i
                        ElseIf UCase(myDS.Tables(1).Columns(i).ToString) = "OPTION_PRIMARY_KEY" Then
                            pr = i
                        ElseIf UCase(myDS.Tables(1).Columns(i).ToString) = "OPTION_DATA_TYPE" Then
                            dt = i
                        ElseIf UCase(myDS.Tables(1).Columns(i).ToString) = "LENGTH" Then
                            maxlength = i
                        ElseIf UCase(myDS.Tables(1).Columns(i).ToString) = "OPTION_MANDATORY" Then
                            md = i
                        ElseIf UCase(myDS.Tables(1).Columns(i).ToString) = "OPTION_PASSWORD" Then
                            ps = i
                        ElseIf UCase(myDS.Tables(1).Columns(i).ToString) = "OPTION_EDITABLE" Then
                            et = i
                        ElseIf UCase(myDS.Tables(1).Columns(i).ToString) = "OPTION_SET_FILTER" Then
                            fl = i
                        ElseIf UCase(myDS.Tables(1).Columns(i).ToString) = "OPTION_VIEW_LIST" Then
                            vv = i
                        ElseIf UCase(myDS.Tables(1).Columns(i).ToString) = "OPTION_VIEW_CARD" Then
                            vw = i
                        ElseIf UCase(myDS.Tables(1).Columns(i).ToString) = "OPTION_ENABLED" Then
                            en = i
                        End If
                    Next

                    For Me.i = 0 To myDS.Tables(1).Rows.Count - 1
                        Dim myImage As Image = Page.FindControl("img" & Trim(myDS.Tables(1).Rows(i).Item(code)))
                        Dim myLabel As Label = Page.FindControl("lbl" & Trim(myDS.Tables(1).Rows(i).Item(code)))
                        Dim myImageButton As ImageButton = Page.FindControl("imgBtn" & Trim(myDS.Tables(1).Rows(i).Item(code)))
                        'labelling
                        myLabel.Text = myDS.Tables(1).Rows(i).Item(name).ToString
                        Select Case UCase(Trim(myDS.Tables(1).Rows(i).Item(dt).ToString))

                            Case "OPTION"
                                Dim myDropdownlist As DropDownList = Page.FindControl("ddl" & Trim(myDS.Tables(1).Rows(i).Item(code)))
                                logic = False
                                If UCase(Trim(myDS.Tables(1).Rows(i).Item(vw).ToString)) = "YES" Then
                                    If UCase(Trim(myDS.Tables(1).Rows(i).Item(dt).ToString)) <> "LOOKUP" And UCase(Trim(myDS.Tables(1).Rows(i).Item(dt).ToString)) <> "DATETIME" Then
                                        myImageButton.Visible = False
                                    End If
                                    If Session("action") = "add" Or Session("action") = "edit" Then
                                        If UCase(Trim(myDS.Tables(1).Rows(i).Item(md).ToString)) = "NO" Then
                                            myImage.Visible = False
                                        End If
                                        If UCase(Trim(myDS.Tables(1).Rows(i).Item(en).ToString)) = "NO" Then
                                            myLabel.Enabled = False
                                            myDropdownlist.Enabled = False
                                            myImageButton.Enabled = False
                                        End If
                                    End If
                                    If Session("action") = "edit" Then
                                        If UCase(Trim(myDS.Tables(1).Rows(i).Item(pr).ToString)) = "YES" Or UCase(Trim(myDS.Tables(1).Rows(i).Item(et).ToString)) = "NO" Then
                                            myLabel.Enabled = False
                                            myDropdownlist.Enabled = False
                                            myImageButton.Enabled = False
                                        End If
                                    End If
                                    If Session("action") = "filter" Then
                                        If UCase(Trim(myDS.Tables(1).Rows(i).Item(fl).ToString)) = "NO" Then
                                            logic = True
                                        End If
                                        myImage.Visible = False
                                    End If
                                Else
                                    logic = True
                                End If
                                If logic = True Then
                                    myImage.Visible = False
                                    myLabel.Visible = False
                                    myDropdownlist.Visible = False
                                    myImageButton.Visible = False
                                End If

                            Case Else
                                Dim myTextBox As TextBox = Page.FindControl("txt" & Trim(myDS.Tables(1).Rows(i).Item(code)))
                                logic = False
                                If UCase(Trim(myDS.Tables(1).Rows(i).Item(vw).ToString)) = "YES" Then
                                    If UCase(Trim(myDS.Tables(1).Rows(i).Item(dt).ToString)) <> "LOOKUP" And UCase(Trim(myDS.Tables(1).Rows(i).Item(dt).ToString)) <> "DATETIME" And UCase(Trim(myDS.Tables(1).Rows(i).Item(dt).ToString)) <> "DATE" And UCase(Trim(myDS.Tables(1).Rows(i).Item(dt).ToString)) <> "TIME" Then
                                        myImageButton.Visible = False
                                    End If
                                    If Session("action") = "add" Or Session("action") = "edit" Then
                                        If UCase(Trim(myDS.Tables(1).Rows(i).Item(md).ToString)) = "NO" Then
                                            myImage.Visible = False
                                        End If
                                        If UCase(Trim(myDS.Tables(1).Rows(i).Item(en).ToString)) = "NO" Then
                                            myLabel.Enabled = False
                                            myTextBox.Enabled = False
                                            myImageButton.Enabled = False
                                        End If
                                    End If
                                    If Session("action") = "edit" Then
                                        If UCase(Trim(myDS.Tables(1).Rows(i).Item(pr).ToString)) = "YES" Or UCase(Trim(myDS.Tables(1).Rows(i).Item(et).ToString)) = "NO" Then
                                            myLabel.Enabled = False
                                            myTextBox.Enabled = False
                                            myImageButton.Enabled = False
                                        End If
                                    End If
                                    If Session("action") = "filter" Then
                                        If UCase(Trim(myDS.Tables(1).Rows(i).Item(fl).ToString)) = "NO" Then
                                            logic = True
                                        End If
                                        myImage.Visible = False
                                    End If
                                Else
                                    logic = True
                                End If
                                If logic = True Then
                                    myImage.Visible = False
                                    myLabel.Visible = False
                                    myTextBox.Visible = False
                                    myImageButton.Visible = False
                                End If
                                'maxlength setting
                                myTextBox.MaxLength = CInt(myDS.Tables(1).Rows(i).Item(maxlength).ToString)
                                If Session("action") = "filter" Then
                                    mySetting.ResetUppercase(myTextBox)
                                Else
                                    'upper case setting
                                    If UCase(Trim(myDS.Tables(1).Rows(i).Item(pr).ToString)) = "YES" Then
                                        mySetting.ConvertUppercase(myTextBox)
                                    End If
                                End If
                                'password setting
                                If UCase(Trim(myDS.Tables(1).Rows(i).Item(ps).ToString)) = "YES" Then
                                    myTextBox.TextMode = TextBoxMode.Password
                                End If

                        End Select
                    Next

                End If
            End If
            myDS = Nothing
        Catch ex As Exception
            lblresult.Text = "[SetVisible]Error: " & ex.Message
            SetFieldToFalse()
        End Try

    End Sub

    Sub AutoAdjustPosition(ByVal strSelect As String)

        Try
            Dim myPosition As String
            Select Case strSelect
                Case "1"
                    myPosition = rowPositionM
                Case "2"
                    myPosition = rowPosition
                Case Else
                    myPosition = rowPosition
            End Select

            'get field position
            Dim code As Integer = 1
            Dim dt As Integer = 3
            Dim posType As Integer = 4
            Dim autonum2 As Integer = 0
            Dim txtnum As Integer = 0
            ssql = "exec sp_sa_get_fields_position '" & Form.ID & "'"
            myDS = mySQL.ExecuteSQL(ssql, Session("Company").ToString, Session("EmpID").ToString)
            autonum = 0
            If myDS.Tables(0).Rows.Count > 0 Then
                For Me.i = 0 To myDS.Tables(0).Rows.Count - 1
                    Dim myImage As Image = Page.FindControl("img" & Trim(myDS.Tables(0).Rows(i).Item(code)))
                    Dim myLabel As Label = Page.FindControl("lbl" & Trim(myDS.Tables(0).Rows(i).Item(code)))
                    Dim myImageButton As ImageButton = Page.FindControl("imgBtn" & Trim(myDS.Tables(0).Rows(i).Item(code)))
                    Select Case UCase(Trim(myDS.Tables(0).Rows(i).Item(dt).ToString))

                        Case "OPTION"
                            Dim myDropdownlist As DropDownList = Page.FindControl("ddl" & Trim(myDS.Tables(0).Rows(i).Item(code)))
                            Select Case UCase(Trim(myDS.Tables(0).Rows(i).Item(posType).ToString))
                                Case "0"
                                    If myLabel.Visible = True And myDropdownlist.Visible = True Then
                                        autonum = autonum + 1
                                        myImage.CssClass = myPosition & autonum
                                        autonum = autonum + 1
                                        myLabel.CssClass = myPosition & autonum
                                        autonum = autonum + 1
                                        myDropdownlist.CssClass = myPosition & autonum
                                        autonum = autonum + 1
                                        myImageButton.CssClass = myPosition & autonum
                                    End If
                                Case "1"
                                    If myLabel.Visible = True And myDropdownlist.Visible = True Then
                                        autonum2 = autonum
                                        autonum2 = autonum2 / 4
                                        If autonum2 Mod 2 <> 0 Then
                                            autonum2 = (autonum2 + 3) / 2
                                            autonum = autonum + 5
                                        Else
                                            autonum2 = (autonum2 + 2) / 2
                                            autonum = autonum + 1
                                        End If
                                        myImage.CssClass = myPosition & autonum
                                        autonum = autonum + 1
                                        myLabel.CssClass = myPosition & autonum
                                        autonum = autonum + 1
                                        myDropdownlist.CssClass = myPosition & autonum
                                        autonum = autonum + 1
                                        myImageButton.CssClass = myPosition & autonum
                                    End If
                                Case "2", "3", "4", "5", "6", "7", "8", "9", "10"
                                    txtnum = CInt(Trim(myDS.Tables(0).Rows(i).Item(posType).ToString))
                                    txtnum = txtnum * 4 'number increase in 4x (per item)
                                    If myLabel.Visible = True And myDropdownlist.Visible = True Then
                                        autonum2 = autonum
                                        autonum2 = autonum2 / 4
                                        If autonum2 Mod 2 <> 0 Then
                                            autonum2 = (autonum2 + 3) / 2
                                            autonum = autonum + 5
                                        Else
                                            autonum2 = (autonum2 + 2) / 2
                                            autonum = autonum + 1
                                        End If
                                        myImage.CssClass = myPosition & autonum
                                        autonum = autonum + 1
                                        myLabel.CssClass = myPosition & autonum
                                        autonum = autonum + 1
                                        myDropdownlist.CssClass = myPosition & autonum
                                        autonum = autonum + 1
                                        myImageButton.CssClass = myPosition & autonum
                                        autonum = autonum + txtnum
                                    End If
                                Case "MIXED"
                                    If myLabel.Visible = True And myDropdownlist.Visible = True Then
                                        autonum = autonum - 3
                                        myImage.CssClass = myPosition & autonum
                                        autonum = autonum + 3
                                        myLabel.Visible = False
                                        myImageButton.CssClass = myPosition & autonum
                                        myDropdownlist.CssClass = myPosition & autonum
                                        autonum = autonum + 4
                                    End If
                                Case Else
                                    If myLabel.Visible = True And myDropdownlist.Visible = True Then
                                        autonum = autonum + 1
                                        myImage.CssClass = myPosition & autonum
                                        autonum = autonum + 1
                                        myLabel.CssClass = myPosition & autonum
                                        autonum = autonum + 1
                                        myDropdownlist.CssClass = myPosition & autonum
                                        autonum = autonum + 1
                                        myImageButton.CssClass = myPosition & autonum
                                    End If
                            End Select

                        Case Else
                            Dim myTextBox As TextBox = Page.FindControl("txt" & Trim(myDS.Tables(0).Rows(i).Item(code)))
                            Select Case UCase(Trim(myDS.Tables(0).Rows(i).Item(posType).ToString))
                                Case "0"
                                    If myLabel.Visible = True And myTextBox.Visible = True Then
                                        autonum = autonum + 1
                                        myImage.CssClass = myPosition & autonum
                                        autonum = autonum + 1
                                        myLabel.CssClass = myPosition & autonum
                                        autonum = autonum + 1
                                        myTextBox.CssClass = myPosition & autonum
                                        autonum = autonum + 1
                                        myImageButton.CssClass = myPosition & autonum
                                    End If
                                Case "1"
                                    If myLabel.Visible = True And myTextBox.Visible = True Then
                                        autonum2 = autonum
                                        autonum2 = autonum2 / 4
                                        If autonum2 Mod 2 <> 0 Then
                                            autonum2 = (autonum2 + 3) / 2
                                            autonum = autonum + 5
                                        Else
                                            autonum2 = (autonum2 + 2) / 2
                                            autonum = autonum + 1
                                        End If
                                        myImage.CssClass = myPosition & autonum
                                        autonum = autonum + 1
                                        myLabel.CssClass = myPosition & autonum
                                        autonum = autonum + 1
                                        myTextBox.CssClass = myPosition & autonum
                                        autonum = autonum + 1
                                        myImageButton.CssClass = myPosition & autonum
                                    End If
                                Case "2", "3", "4", "5", "6", "7", "8", "9", "10"
                                    txtnum = CInt(Trim(myDS.Tables(0).Rows(i).Item(posType).ToString))
                                    txtnum = txtnum * 4 'number increase in 4x (per item)
                                    If myLabel.Visible = True And myTextBox.Visible = True Then
                                        autonum2 = autonum
                                        autonum2 = autonum2 / 4
                                        If autonum2 Mod 2 <> 0 Then
                                            autonum2 = (autonum2 + 3) / 2
                                            autonum = autonum + 5
                                        Else
                                            autonum2 = (autonum2 + 2) / 2
                                            autonum = autonum + 1
                                        End If
                                        myImage.CssClass = myPosition & autonum
                                        autonum = autonum + 1
                                        myLabel.CssClass = myPosition & autonum
                                        autonum = autonum + 1
                                        myTextBox.CssClass = myPosition & autonum
                                        autonum = autonum + 1
                                        myImageButton.CssClass = myPosition & autonum
                                        autonum = autonum + txtnum
                                    End If
                                    'Case "3"
                                    '    Dim myImageButton2 As ImageButton = Page.FindControl("imgBtn" & Trim(myDS.Tables(0).Rows(i).Item(code)) & "2")
                                    '    Dim myImageButtonAddAll As ImageButton = Page.FindControl("imgBtnAddAll")
                                    '    Dim myImageButtonAddItem As ImageButton = Page.FindControl("imgBtnAddItem")
                                    '    Dim myImageButtonRemoveItem As ImageButton = Page.FindControl("imgBtnRemoveItem")
                                    '    Dim myImageButtonRemoveAll As ImageButton = Page.FindControl("imgBtnRemoveAll")
                                    '    Dim myPanelLeft As Panel = Page.FindControl("pnllstleft")
                                    '    Dim myPanelRight As Panel = Page.FindControl("pnllstright")
                                    '    ' set lst pnl 
                                    '    LstSetting()
                                    '    autonum2 = autonum
                                    '    autonum2 = autonum2 / 4
                                    '    If autonum2 Mod 2 <> 0 Then
                                    '        autonum2 = (autonum2 + 3) / 2
                                    '        autonum = autonum + 5
                                    '    Else
                                    '        autonum2 = (autonum2 + 2) / 2
                                    '        autonum = autonum + 1
                                    '    End If
                                    '    myImage.CssClass = myPosition & autonum
                                    '    autonum = autonum + 1
                                    '    myLabel.CssClass = myPosition & autonum
                                    '    autonum = autonum + 1
                                    '    myTextBox.Visible = False
                                    '    myPanelLeft.CssClass = myPosition & autonum
                                    '    autonum = autonum + 1
                                    '    myImageButtonAddAll.CssClass = "RL" & autonum2 & "_1"
                                    '    myImageButtonAddItem.CssClass = "RL" & autonum2 & "_2"
                                    '    myImageButtonRemoveItem.CssClass = "RL" & autonum2 & "_3"
                                    '    myImageButtonRemoveAll.CssClass = "RL" & autonum2 & "_4"
                                    '    myPanelRight.CssClass = "RL" & autonum2 & "_5"
                                    '    myImageButton2.Visible = True
                                    '    myImageButton.Visible = False
                                    '    myImageButton2.CssClass = "RL" & autonum2 & "_6"
                                    '    autonum = autonum + 44
                                Case "MIXED"
                                    If myLabel.Visible = True And myTextBox.Visible = True Then
                                        autonum = autonum - 3
                                        myImage.CssClass = myPosition & autonum
                                        autonum = autonum + 3
                                        myLabel.Visible = False
                                        myImageButton.CssClass = myPosition & autonum
                                        myTextBox.CssClass = myPosition & autonum
                                        autonum = autonum + 4
                                    End If
                                Case Else
                                    If myLabel.Visible = True And myTextBox.Visible = True Then
                                        autonum = autonum + 1
                                        myImage.CssClass = myPosition & autonum
                                        autonum = autonum + 1
                                        myLabel.CssClass = myPosition & autonum
                                        autonum = autonum + 1
                                        myTextBox.CssClass = myPosition & autonum
                                        autonum = autonum + 1
                                        myImageButton.CssClass = myPosition & autonum
                                    End If
                            End Select
                    End Select
                Next
            End If

            autonum = autonum / 4
            If autonum Mod 2 <> 0 Then
                autonum = autonum + 1
            End If
            autonum = autonum / 2

            buttonPosition1 = buttonPosition1 & autonum - 1
            buttonPosition2 = buttonPosition2 & autonum - 1
            buttonPosition3 = buttonPosition3 & autonum - 1

            labelPosition1 = labelPosition1 & autonum - 1
            lblresult2.CssClass = labelPosition1
            lblresult2.Text = "Click on Cancel Button to return..."
            imgtop.CssClass = "Display_0"
            imgbottom.CssClass = panelPosition & autonum
        Catch ex As Exception
            lblresult.Text = "[AutoAdjustPosition]Error: " & ex.Message
            SetFieldToFalse()
        End Try

    End Sub

    Sub ClearText()

        Try
            Dim code As Integer = 2
            Dim dt As Integer = 6
            lblresult.Text = ""

            myDS = mySetting.GetLabelDescription_(Form.ID)
            If CInt(myDS.Tables.Count) > 1 Then
                If CInt(myDS.Tables(1).Rows.Count) > 0 Then
                    For Me.i = 0 To myDS.Tables(1).Rows.Count - 1
                        Select Case UCase(Trim(myDS.Tables(1).Rows(i).Item(dt).ToString))
                            Case "OPTION"
                                Dim myDropdownlist As DropDownList = Page.FindControl("ddl" & Trim(myDS.Tables(1).Rows(i).Item(code).ToString))
                                myDropdownlist.SelectedIndex = 0
                            Case Else
                                Dim myTextBox As TextBox = Page.FindControl("txt" & Trim(myDS.Tables(1).Rows(i).Item(code).ToString))
                                myTextBox.Text = ""
                        End Select
                    Next
                End If
            End If
            myDS = Nothing
        Catch ex As Exception
            lblresult.Text = "[ClearText]Error: " & ex.Message
            SetFieldToFalse()
        End Try

    End Sub

    Sub SetFieldToTrue()

        Try
            Dim code As Integer = 2
            Dim dt As Integer = 6
            pnledit.Visible = True
            pnlmain.Visible = False
            lblresult2.Visible = True

            myDS = mySetting.GetLabelDescription_(Form.ID)
            If CInt(myDS.Tables.Count) > 1 Then
                If CInt(myDS.Tables(1).Rows.Count) > 0 Then
                    For Me.i = 0 To myDS.Tables(1).Rows.Count - 1
                        Dim myImage As Image = Page.FindControl("img" & Trim(myDS.Tables(1).Rows(i).Item(code).ToString))
                        Dim myLabel As Label = Page.FindControl("lbl" & Trim(myDS.Tables(1).Rows(i).Item(code).ToString))
                        Dim myImageButton As ImageButton = Page.FindControl("imgBtn" & Trim(myDS.Tables(1).Rows(i).Item(code).ToString))
                        Select Case UCase(Trim(myDS.Tables(1).Rows(i).Item(dt).ToString))
                            Case "OPTION"
                                Dim myDropdownlist As DropDownList = Page.FindControl("ddl" & Trim(myDS.Tables(1).Rows(i).Item(code).ToString))
                                myDropdownlist.Visible = True
                                myDropdownlist.Enabled = True
                            Case Else
                                Dim myTextBox As TextBox = Page.FindControl("txt" & Trim(myDS.Tables(1).Rows(i).Item(code).ToString))
                                myTextBox.Visible = True
                                myTextBox.Enabled = True
                        End Select
                        myImage.Visible = True
                        myLabel.Visible = True
                        myImageButton.Visible = True
                        myLabel.Enabled = True
                        myLabel.Enabled = True
                        myImageButton.Enabled = True
                    Next
                End If
            End If
            myDS = Nothing
        Catch ex As Exception
            lblresult.Text = "[SetFieldToTrue]Error: " & ex.Message
            SetFieldToFalse()
        End Try

    End Sub

    Sub SetFieldToFalse()
        pnledit.Visible = False
        pnlmain.Visible = True
    End Sub

    Private Function ValidateInsertUpdate() As Boolean

        Try
            myDS = mySQL.ExecuteSQL("Select Code,Option_Data_Type,Option_Primary_Key,[Name] From Table_Field Where Table_Profile_Code='" & Form.ID & "' And Option_View='YES' Order By Table_Profile_Code,Sequence_No", Session("Company").ToString, Session("EmpID").ToString)
            ssql1 = "Insert Into " & Form.ID & "("
            ssql2 = ") Values("
            ssql6 = "Delete From " & Form.ID & " Where "
            ssql3 = ""
            ssql4 = ""
            If myDS.Tables(0).Rows.Count > 0 Then
                For Me.i = 0 To myDS.Tables(0).Rows.Count - 1
                    Select Case myDS.Tables(0).Rows(i).Item(1).ToString
                        Case "OPTION"
                            logic = False
                            Dim myDropdownlist As DropDownList = Page.FindControl("ddl" & Trim(myDS.Tables(0).Rows(i).Item(0)))
                            Dim myImg As Image = Page.FindControl("img" & Trim(myDS.Tables(0).Rows(i).Item(0)))
                            If myImg.Visible = True Then
                                If mySetting.CheckTextNull(myDropdownlist.SelectedValue) = True Then
                                    logic = True
                                Else
                                    lblresult2.Text = Trim(myDS.Tables(0).Rows(i).Item(3)) & " field is required..."
                                    myDropdownlist.Focus()
                                    Return False
                                End If
                            Else
                                logic = True
                            End If
                            If logic = True Then
                                If mySetting.ValidateInput(myDropdownlist, myDS.Tables(0).Rows(i).Item(1).ToString) = True Then
                                    ssql1 = ssql1 & myDS.Tables(0).Rows(i).Item(0) & ","
                                    ssql2 = ssql2 & "'" & Trim(myDropdownlist.SelectedValue) & "',"
                                    ssql3 = ssql3 & myDS.Tables(0).Rows(i).Item(0) & "='" & Trim(myDropdownlist.SelectedValue) & "' And "
                                    ssql4 = ssql4 & myDS.Tables(0).Rows(i).Item(0) & "=" & Trim(myDropdownlist.SelectedValue) & ","
                                Else
                                    lblresult2.Text = "Invalid selection for " & Trim(myDS.Tables(0).Rows(i).Item(3)) & " !"
                                    myDropdownlist.Focus()
                                    Return False
                                End If
                            End If
                        Case "CHARACTER", "LOOKUP", "DECIMAL", "INTEGER"
                            logic = False
                            If i = myDS.Tables(0).Rows.Count - 1 Then
                                'add or update selected items
                                If lstright.Items.Count <> 0 Then
                                    ssql1 = ssql1 & myDS.Tables(0).Rows(i).Item(0)
                                    ssql7 = ssql7 & Left(ssql3, Len(ssql3) - 5)
                                    ssql3 = ssql6 & Left(ssql3, Len(ssql3) - 5)
                                    mySQL.ExecuteSQL(ssql3, Session("Company").ToString, Session("EmpID").ToString)
                                    ssql4 = ssql4 & myDS.Tables(0).Rows(i).Item(0) & "="
                                    For Me.j = 0 To lstright.Items.Count - 1
                                        ssql = ssql2 & "'" & Trim(lstright.Items(j).Value) & "'"
                                        ssql = ssql1 & ssql & ")"
                                        mySQL.ExecuteSQL(ssql, Session("Company").ToString, Session("EmpID").ToString)
                                        ssql5 = ssql4 & Trim(lstright.Items(j).Value)
                                        If j = lstright.Items.Count - 1 Then
                                            ssql4 = ssql5
                                        End If
                                    Next
                                Else
                                    ssql3 = ssql6 & Left(ssql3, Len(ssql3) - 5)
                                    mySQL.ExecuteSQL(ssql3, Session("Company").ToString, Session("EmpID").ToString)
                                End If
                                'lblresult.Text = "Data edit successfully..."
                                Exit Select
                            End If

                            'for non last field
                            Dim myTextBox As TextBox = Page.FindControl("txt" & Trim(myDS.Tables(0).Rows(i).Item(0)))
                            Dim myImg As Image = Page.FindControl("img" & Trim(myDS.Tables(0).Rows(i).Item(0)))
                            If myImg.Visible = True Then
                                If mySetting.CheckTextNull(myTextBox.Text) = True Then
                                    logic = True
                                Else
                                    lblresult2.Text = Trim(myDS.Tables(0).Rows(i).Item(3)) & " field is required..."
                                    myTextBox.Focus()
                                    Return False
                                End If
                            Else
                                logic = True
                            End If
                            If logic = True Then
                                If mySetting.ValidateInput(myTextBox, myDS.Tables(0).Rows(i).Item(1).ToString) = True Then
                                    ssql1 = ssql1 & myDS.Tables(0).Rows(i).Item(0) & ","
                                    ssql2 = ssql2 & "'" & Trim(myTextBox.Text) & "',"
                                    ssql3 = ssql3 & myDS.Tables(0).Rows(i).Item(0) & "='" & Trim(myTextBox.Text) & "' And "
                                    ssql4 = ssql4 & myDS.Tables(0).Rows(i).Item(0) & "=" & Trim(myTextBox.Text) & ","
                                Else
                                    lblresult2.Text = "Invalid input format for " & Trim(myDS.Tables(0).Rows(i).Item(3)) & " !"
                                    myTextBox.Focus()
                                    Return False
                                End If
                            End If
                        Case "DATETIME", "DATE"
                            logic = False
                            Dim myTextBox As TextBox = Page.FindControl("txt" & Trim(myDS.Tables(0).Rows(i).Item(0)))
                            Dim myImg As Image = Page.FindControl("img" & Trim(myDS.Tables(0).Rows(i).Item(0)))
                            If myImg.Visible = True Then
                                If mySetting.CheckTextNull(myTextBox.Text) = True Then
                                    logic = True
                                Else
                                    lblresult2.Text = Trim(myDS.Tables(0).Rows(i).Item(3)) & " field is required..."
                                    myTextBox.Focus()
                                    Return False
                                End If
                            Else
                                logic = True
                            End If
                            If logic = True Then
                                Dim strDate As String = Trim(myTextBox.Text)
                                strDate = mySetting.ConvertDateToDecimal(myTextBox.Text, Session("Company"), Session("Module"))
                                If Len(strDate) = 14 Then
                                    ssql1 = ssql1 & myDS.Tables(0).Rows(i).Item(0) & ","
                                    ssql2 = ssql2 & "'" & strDate & "',"
                                    If myDS.Tables(0).Rows(i).Item(2).ToString = "YES" Then
                                        ssql3 = ssql3 & myDS.Tables(0).Rows(i).Item(0) & "='" & strDate & "' And "
                                        ssql4 = ssql4 & myDS.Tables(0).Rows(i).Item(0) & "=" & strDate & ","
                                    End If
                                Else
                                    lblresult2.Text = "Invalid input format for " & Trim(myDS.Tables(0).Rows(i).Item(3)) & " !"
                                    myTextBox.Focus()
                                    Return False
                                End If
                            End If
                    End Select
                Next
                myDS = Nothing
                Session("insertArgument") = ssql4
            End If
            Return True
        Catch ex As Exception
            lblresult2.Text = "[ValidateInsertUpdate]Error: " & ex.Message
        End Try

    End Function

    Private Sub AddRemoveAll(ByVal aSource As ListBox, ByVal aTarget As ListBox)

        Try
            For Me.i = 0 To aSource.Items.Count - 1
                aTarget.Items.Add(aSource.Items(i))
            Next
            aSource.Items.Clear()
        Catch ex As Exception
            lblresult2.Text = "Error: " + ex.Message
        End Try


    End Sub

    Private Sub AddRemoveItem(ByVal aSource As ListBox, ByVal aTarget As ListBox)

        Try
            For Me.i = 0 To aSource.Items.Count - 1
                If aSource.Items(i).Selected Then
                    aTarget.Items.Add(aSource.Items(i))
                End If
            Next
            For Me.i = aSource.Items.Count - 1 To 0 Step -1
                If aSource.Items(i).Selected = True Then
                    aSource.Items.Remove(aSource.Items(i))
                End If
            Next

        Catch ex As Exception
            lblresult2.Text = "Error: " + ex.Message
        End Try

    End Sub

#End Region

    Protected Sub imgBtnPrint_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnPrint.Click
        Dim clsRpt As New clsReportServices, myTargetURL As String = ""
        myTargetURL = clsRpt.GetReportURL(Session("Company").ToString, Session("EmpID").ToString, _
                    Session("Module").ToString, Form.ID.ToString, Session("Language").ToString, _
                     Session("FilterField").ToString, Session("FilterCriteria").ToString, _
                      myGridView.PageSize, 1)
        'Page.ClientScript.RegisterStartupScript(GetType(Page), "ShowReport", myTargetURL)
        Response.Write("<script>window.open('" & myTargetURL & "');</script>")
    End Sub
    Private Function ValidateSearch() As Boolean
        Dim tmpssql As String = "", strSplit As String = ""
        lblresult2.Visible = True
        ssql = ""
        ssql2 = ""
        ssql3 = ""
        myDS = New DataSet
        myDS = mySQL.ExecuteSQL("Select Code,Name,Option_Data_Type From Table_Field Where Table_Profile_Code='" & Form.ID & "' And Option_View_Card='YES' Order By Table_Profile_Code,Sequence_No", Session("Company").ToString, Session("EmpID").ToString)
        If Not myDS Is Nothing Then
            If myDS.Tables.Count > 0 Then
                For Me.i = 0 To myDS.Tables(0).Rows.Count - 1
                    Dim myDR As DataRow = myDS.Tables(0).Rows(i)
                    Select Case myDR(2).ToString
                        Case "OPTION"
                            Dim myDDL As DropDownList = Page.FindControl("ddl" & myDR(0).ToString)
                            If myDDL.Visible = True And myDDL.SelectedValue <> "" Then
                                ssql = ssql & Form.ID & "_Card_Vw" & "@@"
                                ssql2 = ssql2 & myDR(0).ToString & "@@"
                                ssql3 = ssql3 & Trim(myDDL.SelectedValue) & "@@"
                            End If
                            myDDL = Nothing
                        Case "DATE"
                            Dim myTxt As TextBox = Page.FindControl("txt" & myDR(0).ToString)
                            If myTxt.Visible = True Then
                                If Trim(myTxt.Text.ToString) <> "" Then
                                    If mySetting.ValidateQuerySyntax(myTxt.Text.ToString) = True Then
                                        strSplit = mySetting.ProcessQuerySyntax(myTxt.Text.ToString)
                                        Dim intPos As Integer, arr As New ArrayList, intLeftMidRight As Integer
                                        intPos = InStr(myTxt.Text.ToString, strSplit)
                                        If intPos = 1 Then
                                            intLeftMidRight = -1
                                        ElseIf intPos > 1 And intPos < Len(myTxt.Text.ToString) Then
                                            intLeftMidRight = 0
                                        ElseIf intPos = Len(myTxt.Text.ToString) Then
                                            intLeftMidRight = 1
                                        End If
                                        mySetting.AddQuerySyntax(arr, myTxt.Text.ToString)
                                        If arr.Count = 0 Then
                                            arr.Add(myTxt.Text.ToString.Trim)
                                        End If

                                        For Me.j = 0 To arr.Count - 1
                                            If Trim(arr(j).ToString) <> "" Then
                                                If Not IsNumeric(mySetting.ConvertDateToDecimal(arr(j).ToString, Session("Company").ToString, Session("Module").ToString)) = True Then
                                                    lblresult2.Text = "Invalid Input [Date] Format For [" & myDR(1).ToString & "] With Value [" & arr(j).ToString & "]"
                                                    myTxt.Focus()
                                                    Return False
                                                Else
                                                    Select Case intLeftMidRight
                                                        Case -1
                                                            tmpssql = tmpssql & strSplit & mySetting.ConvertDateToDecimal(arr(j).ToString, Session("Company").ToString, Session("Module").ToString)
                                                        Case 0
                                                            tmpssql = tmpssql & mySetting.ConvertDateToDecimal(arr(j).ToString, Session("Company").ToString, Session("Module").ToString) & strSplit
                                                        Case 1
                                                            tmpssql = tmpssql & mySetting.ConvertDateToDecimal(arr(j).ToString, Session("Company").ToString, Session("Module").ToString) & strSplit
                                                    End Select
                                                End If
                                            End If
                                        Next
                                        Select Case intLeftMidRight
                                            Case -1
                                                'Do nothing
                                            Case 0
                                                If Right(tmpssql, Len(strSplit)) = strSplit Then
                                                    tmpssql = Left(tmpssql, Len(tmpssql) - Len(strSplit))
                                                End If
                                            Case 1
                                                'Do nothing
                                        End Select
                                        ssql = ssql & Form.ID & "_Card_Vw" & "@@"
                                        ssql2 = ssql2 & myDR(0).ToString & "@@"
                                        ssql3 = ssql3 & tmpssql & "@@"
                                    Else
                                        lblresult2.Text = "More than 1 syntax found in the [" & myDR(1).ToString & "]"
                                        myTxt.Focus()
                                        Return False
                                    End If
                                End If
                            End If
                            myTxt = Nothing
                            tmpssql = ""
                        Case "DATETIME"
                            Dim myTxt As TextBox = Page.FindControl("txt" & myDR(0).ToString)
                            If myTxt.Visible = True Then
                                If Trim(myTxt.Text.ToString) <> "" Then
                                    If mySetting.ValidateQuerySyntax(myTxt.Text.ToString) = True Then
                                        strSplit = mySetting.ProcessQuerySyntax(myTxt.Text.ToString)
                                        Dim intPos As Integer, arr As New ArrayList, intLeftMidRight As Integer
                                        intPos = InStr(myTxt.Text.ToString, strSplit)
                                        If intPos = 1 Then
                                            intLeftMidRight = -1
                                        ElseIf intPos > 1 And intPos < Len(myTxt.Text.ToString) Then
                                            intLeftMidRight = 0
                                        ElseIf intPos = Len(myTxt.Text.ToString) Then
                                            intLeftMidRight = 1
                                        End If
                                        mySetting.AddQuerySyntax(arr, myTxt.Text.ToString)
                                        If arr.Count = 0 Then
                                            arr.Add(myTxt.Text.ToString.Trim)
                                        End If

                                        For Me.j = 0 To arr.Count - 1
                                            If Trim(arr(j).ToString) <> "" Then
                                                If Not IsNumeric(mySetting.UnDisplayDateTime(arr(j).ToString, Session("Company").ToString, Session("Module").ToString)) = True Then
                                                    lblresult2.Text = "Invalid Input [Date] Format For [" & myDR(1).ToString & "] With Value [" & arr(j).ToString & "]"
                                                    myTxt.Focus()
                                                    Return False
                                                Else
                                                    Select Case intLeftMidRight
                                                        Case -1
                                                            tmpssql = tmpssql & strSplit & mySetting.UnDisplayDateTime(arr(j).ToString, Session("Company").ToString, Session("Module").ToString)
                                                        Case 0
                                                            tmpssql = tmpssql & mySetting.UnDisplayDateTime(arr(j).ToString, Session("Company").ToString, Session("Module").ToString) & strSplit
                                                        Case 1
                                                            tmpssql = tmpssql & mySetting.UnDisplayDateTime(arr(j).ToString, Session("Company").ToString, Session("Module").ToString) & strSplit
                                                    End Select
                                                End If
                                            End If
                                        Next
                                        Select Case intLeftMidRight
                                            Case -1
                                                'Do nothing
                                            Case 0
                                                If Right(tmpssql, Len(strSplit)) = strSplit Then
                                                    tmpssql = Left(tmpssql, Len(tmpssql) - Len(strSplit))
                                                End If
                                            Case 1
                                                'Do nothing
                                        End Select
                                        ssql = ssql & Form.ID & "_Card_Vw" & "@@"
                                        ssql2 = ssql2 & myDR(0).ToString & "@@"
                                        ssql3 = ssql3 & tmpssql & "@@"
                                    Else
                                        lblresult2.Text = "More than 1 syntax found in the [" & myDR(1).ToString & "]"
                                        myTxt.Focus()
                                        Return False
                                    End If
                                End If
                            End If
                            myTxt = Nothing
                            tmpssql = ""
                        Case "TIME"
                            Dim myTxt As TextBox = Page.FindControl("txt" & myDR(0).ToString)
                            If myTxt.Visible = True Then
                                If Trim(myTxt.Text.ToString) <> "" Then
                                    If mySetting.ValidateQuerySyntax(myTxt.Text.ToString) = True Then
                                        strSplit = mySetting.ProcessQuerySyntax(myTxt.Text.ToString)
                                        Dim intPos As Integer, arr As New ArrayList, intLeftMidRight As Integer
                                        intPos = InStr(myTxt.Text.ToString, strSplit)
                                        If intPos = 1 Then
                                            intLeftMidRight = -1
                                        ElseIf intPos > 1 And intPos < Len(myTxt.Text.ToString) Then
                                            intLeftMidRight = 0
                                        ElseIf intPos = Len(myTxt.Text.ToString) Then
                                            intLeftMidRight = 1
                                        End If
                                        mySetting.AddQuerySyntax(arr, myTxt.Text.ToString)
                                        If arr.Count = 0 Then
                                            arr.Add(myTxt.Text.ToString.Trim)
                                        End If

                                        For Me.j = 0 To arr.Count - 1
                                            If Trim(arr(j).ToString) <> "" Then
                                                If Not IsNumeric(mySetting.UnDisplayTime(arr(j).ToString, Session("Company").ToString, Session("Module").ToString)) = True Then
                                                    lblresult2.Text = "Invalid Input [Date] Format For [" & myDR(1).ToString & "] With Value [" & arr(j).ToString & "]"
                                                    myTxt.Focus()
                                                    Return False
                                                Else
                                                    Select Case intLeftMidRight
                                                        Case -1
                                                            tmpssql = tmpssql & strSplit & mySetting.UnDisplayTime(arr(j).ToString, Session("Company").ToString, Session("Module").ToString)
                                                        Case 0
                                                            tmpssql = tmpssql & mySetting.UnDisplayTime(arr(j).ToString, Session("Company").ToString, Session("Module").ToString) & strSplit
                                                        Case 1
                                                            tmpssql = tmpssql & mySetting.UnDisplayTime(arr(j).ToString, Session("Company").ToString, Session("Module").ToString) & strSplit
                                                    End Select
                                                End If
                                            End If
                                        Next
                                        Select Case intLeftMidRight
                                            Case -1
                                                'Do nothing
                                            Case 0
                                                If Right(tmpssql, Len(strSplit)) = strSplit Then
                                                    tmpssql = Left(tmpssql, Len(tmpssql) - Len(strSplit))
                                                End If
                                            Case 1
                                                'Do nothing
                                        End Select
                                        ssql = ssql & Form.ID & "_Card_Vw" & "@@"
                                        ssql2 = ssql2 & myDR(0).ToString & "@@"
                                        ssql3 = ssql3 & tmpssql & "@@"
                                    Else
                                        lblresult2.Text = "More than 1 syntax found in the [" & myDR(1).ToString & "]"
                                        myTxt.Focus()
                                        Return False
                                    End If
                                End If
                            End If
                            myTxt = Nothing
                            tmpssql = ""
                        Case "INTEGER", "DECIMAL"
                            Dim myTxt As TextBox = Page.FindControl("txt" & myDR(0).ToString)
                            If myTxt.Visible = True And Trim(myTxt.Text) <> "" Then
                                'Change Search Numeric Start
                                'Dim arr() As String = myTxt.Text.ToString.Split("~")
                                'For Me.j = 0 To arr.Length - 1
                                'If Trim(arr(j).ToString) <> "" Then
                                '    If Not IsNumeric(Trim(myTxt.Text.ToString)) Then
                                If mySetting.ValidateQuerySyntax(myTxt.Text) = True Then
                                    strSplit = mySetting.ProcessQuerySyntax(myTxt.Text.ToString)
                                    Dim intPos As Integer, arr As New ArrayList, intLeftMidRight As Integer
                                    intPos = InStr(myTxt.Text.ToString, strSplit)
                                    If intPos = 1 Then
                                        intLeftMidRight = -1
                                    ElseIf intPos > 1 And intPos < Len(myTxt.Text.ToString) Then
                                        intLeftMidRight = 0
                                    ElseIf intPos = Len(myTxt.Text.ToString) Then
                                        intLeftMidRight = 1
                                    End If
                                    mySetting.AddQuerySyntax(arr, myTxt.Text.ToString)
                                    If arr.Count = 0 Then
                                        arr.Add(myTxt.Text.ToString.Trim)
                                    End If

                                    For Me.j = 0 To arr.Count - 1
                                        If Trim(arr(j).ToString) <> "" Then
                                            If Not IsNumeric(Trim(arr(j).ToString)) Then
                                                'Change Search Numeric End
                                                lblresult2.Text = "Invalid Input [Numeric] Format For " & myDR(1).ToString & " With Value " & arr(j).ToString
                                                myTxt.Focus()
                                                Return False
                                            Else
                                                tmpssql = tmpssql & arr(j).ToString & "~"
                                            End If
                                        End If
                                    Next
                                    If Right(tmpssql, 1) = "~" Then
                                        tmpssql = Left(tmpssql, Len(tmpssql) - 1)
                                    End If
                                End If
                                ssql = ssql & Form.ID & "_Card_Vw" & "@@"
                                ssql2 = ssql2 & myDR(0).ToString & "@@"
                                ssql3 = ssql3 & Trim(myTxt.Text.ToString) & "@@"
                            End If
                            tmpssql = ""
                            myTxt = Nothing
                        Case "LOOKUP", "CHARACTER"
                            Dim myTxt As TextBox = Page.FindControl("txt" & myDR(0).ToString)
                            If myTxt.Visible = True And Trim(myTxt.Text) <> "" Then
                                ssql = ssql & Form.ID & "_Card_Vw" & "@@"
                                ssql2 = ssql2 & myDR(0).ToString & "@@"
                                ssql3 = ssql3 & Trim(myTxt.Text.ToString) & "@@"
                            End If
                    End Select
                    myDR = Nothing
                Next
                If Len(ssql) > 2 Then
                    If Right(ssql, 2) = "@@" Then
                        ssql = Left(ssql, Len(ssql) - 2)
                    End If
                End If
                If Len(ssql2) > 2 Then
                    If Right(ssql2, 2) = "@@" Then
                        ssql2 = Left(ssql2, Len(ssql2) - 2)
                    End If
                End If
                If Len(ssql3) > 2 Then
                    If Right(ssql3, 2) = "@@" Then
                        ssql3 = Left(ssql3, Len(ssql3) - 2)
                    End If
                End If

                If ssql <> "" And ssql2 <> "" And ssql3 <> "" Then
                    Session("ssql1") = ssql
                    Session("ssql2") = ssql2
                    Session("ssql3") = ssql3
                    Session("action") = "search"
                Else
                    Session("action") = "any"
                End If

            End If
        End If
        myDS = Nothing
        Return True
    End Function
End Class
