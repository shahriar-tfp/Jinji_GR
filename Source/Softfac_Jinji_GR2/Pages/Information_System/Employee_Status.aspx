<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Employee_Status.aspx.vb" Inherits="Pages_InformationSystem_Employee_Status" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>JINJI : Info - Employee Status Page</title>
    <link href="../../App_Themes/hcrmStyles1.css" type="text/css" rel="stylesheet" />
</head>
<body id="body" runat="server">
    <form id="Employee_Status" runat="server">
    <div>
    <asp:Panel ID="pnlEdit" runat="server">
  <!--// 1 //-->
    <asp:imagebutton id="imgKeyCOMPANY_PROFILE_CODE" runat="server" Width="21px" Height="21px" ></asp:imagebutton>
    <asp:label id="lblCOMPANY_PROFILE_CODE" runat="server" Width="140px"></asp:label>
    <asp:textbox id="txtCOMPANY_PROFILE_CODE" runat="server" Width="150px"></asp:textbox>
    <asp:imagebutton id="imgbtnCOMPANY_PROFILE_CODE" runat="server" Height="21px" ></asp:imagebutton>
    <!--// 2 //-->
    <asp:imagebutton id="imgKeyEMPLOYEE_PROFILE_ID" runat="server" Width="21px" Height="21px" ></asp:imagebutton>
    <asp:label id="lblEMPLOYEE_PROFILE_ID" runat="server" Width="140px"></asp:label>
    <asp:textbox id="txtEMPLOYEE_PROFILE_ID" runat="server" Width="150px"></asp:textbox>
    <asp:imagebutton id="imgbtnEMPLOYEE_PROFILE_ID" runat="server" Height="21px" ></asp:imagebutton>
    <!--// 3 //-->
    <asp:imagebutton id="imgKeyOCP_ID_DIVISION" runat="server" Width="21px" Height="21px" ></asp:imagebutton>
    <asp:label id="lblOCP_ID_DIVISION" runat="server" Width="140px"></asp:label>
    <asp:dropdownlist id="ddlOCP_ID_DIVISION" runat="server" Width="157px" AutoPostBack="true"></asp:dropdownlist>
    <asp:imagebutton id="imgbtnOCP_ID_DIVISION" runat="server" Height="21px" ></asp:imagebutton>
    <!--// 4 //-->
    <asp:imagebutton id="imgKeyOCP_ID_DEPARTMENT" runat="server" Width="21px" Height="21px" ></asp:imagebutton>
    <asp:label id="lblOCP_ID_DEPARTMENT" runat="server" Width="140px"></asp:label>
    <asp:dropdownlist id="ddlOCP_ID_DEPARTMENT" runat="server" Width="157px" AutoPostBack="true"></asp:dropdownlist>
    <asp:imagebutton id="imgbtnOCP_ID_DEPARTMENT" runat="server" Height="21px" ></asp:imagebutton>
    <!--// 5 //-->
    <asp:imagebutton id="imgKeyOCP_ID_SECTION" runat="server" Width="21px" Height="21px" ></asp:imagebutton>
    <asp:label id="lblOCP_ID_SECTION" runat="server" Width="140px"></asp:label>
    <asp:dropdownlist id="ddlOCP_ID_SECTION" runat="server" Width="157px" AutoPostBack="true"></asp:dropdownlist>
    <asp:imagebutton id="imgbtnOCP_ID_SECTION" runat="server" Height="21px" ></asp:imagebutton>
    <!--// 6 //-->
    <asp:imagebutton id="imgKeyOCP_ID_LINE" runat="server" Width="21px" Height="21px" ></asp:imagebutton>
    <asp:label id="lblOCP_ID_LINE" runat="server" Width="140px"></asp:label>
    <asp:dropdownlist id="ddlOCP_ID_LINE" runat="server" Width="157px" AutoPostBack="true"></asp:dropdownlist>
    <asp:imagebutton id="imgbtnOCP_ID_LINE" runat="server" Height="21px" ></asp:imagebutton>
    <!--// 7 //-->
    <asp:imagebutton id="imgKeyOCP_ID_GROUP" runat="server" Width="21px" Height="21px" ></asp:imagebutton>
    <asp:label id="lblOCP_ID_GROUP" runat="server" Width="140px"></asp:label>
    <asp:dropdownlist id="ddlOCP_ID_GROUP" runat="server" Width="157px" AutoPostBack="true"></asp:dropdownlist>
    <asp:imagebutton id="imgbtnOCP_ID_GROUP" runat="server" Height="21px" ></asp:imagebutton>
    <!--// 8 //-->
    <asp:imagebutton id="imgKeyOCP_ID_PROCESS" runat="server" Width="21px" Height="21px" ></asp:imagebutton>
    <asp:label id="lblOCP_ID_PROCESS" runat="server" Width="140px"></asp:label>
    <asp:dropdownlist id="ddlOCP_ID_PROCESS" runat="server" Width="157px" AutoPostBack="true"></asp:dropdownlist>
    <asp:imagebutton id="imgbtnOCP_ID_PROCESS" runat="server" Height="21px" ></asp:imagebutton>
    <!--// 9 //-->
    <asp:imagebutton id="imgKeyOCP_ID_FINANCE" runat="server" Width="21px" Height="21px" ></asp:imagebutton>
    <asp:label id="lblOCP_ID_FINANCE" runat="server" Width="140px"></asp:label>
    <asp:textbox id="txtOCP_ID_FINANCE" runat="server" Width="150px"></asp:textbox>
    <asp:imagebutton id="imgbtnOCP_ID_FINANCE" runat="server" Height="21px" ></asp:imagebutton>
    <!--// 10 //-->
    <asp:imagebutton id="imgKeyOCP_ID_TMS" runat="server" Width="21px" Height="21px" ></asp:imagebutton>
    <asp:label id="lblOCP_ID_TMS" runat="server" Width="140px"></asp:label>
    <asp:textbox id="txtOCP_ID_TMS" runat="server" Width="150px"></asp:textbox>
    <asp:imagebutton id="imgbtnOCP_ID_TMS" runat="server" Height="21px" ></asp:imagebutton>
    <!--// 11 //-->
    <asp:imagebutton id="imgKeyOCP_ID_JOB_GRADE" runat="server" Width="21px" Height="21px" ></asp:imagebutton>
    <asp:label id="lblOCP_ID_JOB_GRADE" runat="server" Width="140px"></asp:label>
    <asp:dropdownlist id="ddlOCP_ID_JOB_GRADE" runat="server" Width="157px" AutoPostBack="true"></asp:dropdownlist>
    <asp:imagebutton id="imgbtnOCP_ID_JOB_GRADE" runat="server" Height="21px" ></asp:imagebutton>
    <!--// 12 //-->
    <asp:imagebutton id="imgKeyOCP_ID_JOB_TITLE" runat="server" Width="21px" Height="21px" ></asp:imagebutton>
    <asp:label id="lblOCP_ID_JOB_TITLE" runat="server" Width="140px"></asp:label>
    <asp:dropdownlist id="ddlOCP_ID_JOB_TITLE" runat="server" Width="157px" AutoPostBack="true"></asp:dropdownlist>
    <asp:imagebutton id="imgbtnOCP_ID_JOB_TITLE" runat="server" Height="21px" ></asp:imagebutton>
    <!--// 13 //-->
    <asp:imagebutton id="imgKeyOCP_ID_APPRAISAL" runat="server" Width="21px" Height="21px" ></asp:imagebutton>
    <asp:label id="lblOCP_ID_APPRAISAL" runat="server" Width="140px"></asp:label>
    <asp:textbox id="txtOCP_ID_APPRAISAL" runat="server" Width="150px"></asp:textbox>
    <asp:imagebutton id="imgbtnOCP_ID_APPRAISAL" runat="server" Height="21px" ></asp:imagebutton>
    <%--<!--// 14 //-->
    <asp:imagebutton id="imgKeyOCP_ID_EMPLOYEE_GROUP" runat="server" Width="21px" Height="21px" ></asp:imagebutton>
    <asp:label id="lblOCP_ID_EMPLOYEE_GROUP" runat="server" Width="140px"></asp:label>
    <asp:textbox id="txtOCP_ID_EMPLOYEE_GROUP" runat="server" Width="150px"></asp:textbox>
    <asp:imagebutton id="imgbtnOCP_ID_EMPLOYEE_GROUP" runat="server" Height="21px" ></asp:imagebutton>--%>
    <!--// 14 //-->
    <asp:imagebutton id="imgKeyOPTION_EMPLOYEE_GROUP" runat="server" Width="21px" Height="21px" ></asp:imagebutton>
    <asp:label id="lblOPTION_EMPLOYEE_GROUP" runat="server" Width="140px"></asp:label>
    <asp:dropdownlist id="ddlOPTION_EMPLOYEE_GROUP" runat="server" Width="157px"></asp:dropdownlist>
    <asp:imagebutton id="imgbtnOPTION_EMPLOYEE_GROUP" runat="server" Height="21px" ></asp:imagebutton>
    <!--// 15 //-->
    <asp:imagebutton id="imgKeyOPTION_EMPLOYMENT_TYPE" runat="server" Width="21px" Height="21px" ></asp:imagebutton>
    <asp:label id="lblOPTION_EMPLOYMENT_TYPE" runat="server" Width="140px"></asp:label>
    <asp:dropdownlist id="ddlOPTION_EMPLOYMENT_TYPE" runat="server" Width="157px"></asp:dropdownlist>
    <asp:imagebutton id="imgbtnOPTION_EMPLOYMENT_TYPE" runat="server" Height="21px" ></asp:imagebutton>
     <!--// 16 //-->
    <asp:imagebutton id="imgKeyDATETIME_CREATE" runat="server" Width="21px" Height="21px" ></asp:imagebutton>
    <asp:label id="lblDATETIME_CREATE" runat="server" Width="140px"></asp:label>
    <asp:textbox id="txtDATETIME_CREATE" runat="server" Width="150px"></asp:textbox>
    <asp:imagebutton id="imgbtnDATETIME_CREATE" runat="server" Height="21px" ></asp:imagebutton>
     <!--// 17 //-->
    <asp:imagebutton id="imgKeyUSER_PROFILE_CODE_CREATE" runat="server" Width="21px" Height="21px" ></asp:imagebutton>
    <asp:label id="lblUSER_PROFILE_CODE_CREATE" runat="server" Width="140px"></asp:label>
    <asp:textbox id="txtUSER_PROFILE_CODE_CREATE" runat="server" Width="150px"></asp:textbox>
    <asp:imagebutton id="imgbtnUSER_PROFILE_CODE_CREATE" runat="server" Height="21px" ></asp:imagebutton>
     <!--// 18 //-->
    <asp:imagebutton id="imgKeyDATETIME_MODIFY" runat="server" Width="21px" Height="21px" ></asp:imagebutton>
    <asp:label id="lblDATETIME_MODIFY" runat="server" Width="140px"></asp:label>
    <asp:textbox id="txtDATETIME_MODIFY" runat="server" Width="150px"></asp:textbox>
    <asp:imagebutton id="imgbtnDATETIME_MODIFY" runat="server" Height="21px" ></asp:imagebutton>
     <!--// 19 //-->
    <asp:imagebutton id="imgKeyUSER_PROFILE_CODE_MODIFY" runat="server" Width="21px" Height="21px" ></asp:imagebutton>
    <asp:label id="lblUSER_PROFILE_CODE_MODIFY" runat="server" Width="140px"></asp:label>
    <asp:textbox id="txtUSER_PROFILE_CODE_MODIFY" runat="server" Width="150px"></asp:textbox>
    <asp:imagebutton id="imgbtnUSER_PROFILE_CODE_MODIFY" runat="server" Height="21px" ></asp:imagebutton>
    
    <!--// Panel //-->
    <div id="divtop" style="height: 30px; width: 100%">
       <table id="Table3" cellspacing="0" cellpadding="0" border="0" runat="server">
        <tr>
            <td>
                <asp:Image ID="imgtop" Height="30px" runat="server" />
            </td>
        </tr>
       </table>
    </div>
    <div id="divbottom" style="height: 30px; width: 100%">
       <table id="Table4" cellspacing="0" cellpadding="0" border="0" runat="server">
        <tr>
            <td>
                <asp:Image ID="imgbottom" Height="30px" Visible="false" runat="server" />
            </td>
        </tr>
       </table>
    </div>
    <!--// Button //-->  
    <asp:imagebutton id="imgBtnSubmit" runat="server" Width="74" Height="21" OnClientClick="return confirm('Are you sure you want to submit?')"></asp:imagebutton>
    <asp:imagebutton id="imgBtnSearch" runat="server" Width="74" Height="21"></asp:imagebutton>
    <asp:imagebutton id="imgBtnUpdate" runat="server" Width="74" Height="21" OnClientClick="return confirm('Are you sure you want to update?')"></asp:imagebutton>
    <asp:imagebutton id="imgBtnClear" runat="server" Width="74" Height="21"></asp:imagebutton>
    <asp:imagebutton id="imgBtnCancel" runat="server" Width="74" Height="21"></asp:imagebutton>
	<asp:label id="lblresult2" runat="server" Height="22" Visible="False"></asp:label>
	<asp:placeholder id="MyPH" Runat="server"></asp:placeholder></asp:Panel>
	<asp:panel id="pnldescription" runat="server" visible="False">
	<table id="Table7" style="left: 15px; position: absolute; top: 10px" cellspacing="0" cellpadding="0" border="0" runat="server">
        <tr>
            <td style="background-image:url(../../Images/Company/Default/gif/org_title_bar20.gif); width :5px"></td>
            <td style="background-image:url(../../Images/Company/Default/gif/org_title_bar20.gif); vertical-align:bottom"><asp:Label ID="lblTitle2" runat="server"></asp:Label></td>
        </tr>
    </table>
    </asp:panel>
	<asp:panel id="pnlMain" runat="server" >
	<table id="tblUserCategoryGroup" style="Z-INDEX: 115; LEFT: 10px; POSITION: absolute; TOP: 10px" 
					cellspacing="0" cellpadding="0" border="0" runat="server">
					<tr>
						<td>
						<table id="Table6" cellspacing="0" cellpadding="0" width="100%" border="0" runat="server">
                                <tr>
                                    <td style="background-image:url(../../Images/Company/Default/gif/org_title_bar20.gif); width :5px"></td>
                                    <td style="background-image:url(../../Images/Company/Default/gif/org_title_bar20.gif); vertical-align:bottom"><asp:Label ID="lblTitle" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                            <table id="Table9" cellspacing="0" cellpadding="0" border="0" runat="server">
					            <tr>
					                <td style ="height:15px"></td>
					            </tr>
					        </table> 
							<table id="tblGridView" cellspacing="0" cellpadding="0" width="100%" border="0" runat="server">
								<tr>
									<td>
										<asp:panel id="pnlGridview" runat="server" visible="true" ScrollBars="auto">
											
												<asp:gridview id="myGridView" Width="100%" runat="server" AutoGenerateColumns="true"
													cellspacing="0" cellpadding="1" EmptyDataText="No data found!">
													<AlternatingRowStyle BackColor="#F2F4FF" />
													<EditRowStyle BackColor="#FFC7C6" Font-Size="Smaller" Height="20"/>
													<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
													<Rowstyle BackColor="#FFFFFF" CssClass="dgstyle_i" />
													<pagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                    <HeaderStyle BackColor="#988675" Height="21" CssClass="dgstyle_h" />
    <Columns>
            <asp:TemplateField HeaderText="Select" ItemStyle-Width="35">
                <ItemTemplate>
                    <center>
                    <asp:CheckBox ID="chkSelect" runat="server" />
                    </center>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:gridview>
                <asp:Panel ID="pnlHistory" runat="server" Visible="false">
        <asp:gridview id="gvHistory" Width="100%" runat="server" AutoGenerateColumns="true"
													cellspacing="0" cellpadding="1" EmptyDataText="No data found!" >
													<AlternatingRowStyle BackColor="#F2F4FF" />
													<EditRowStyle BackColor="#FFC7C6" Font-Size="Smaller" Height="20"/>
													<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
													<Rowstyle BackColor="#FFFFFF" CssClass="dgstyle_i" />
													<pagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                    <HeaderStyle BackColor="#988675" Height="21" CssClass="dgstyle_h" />
    <Columns>
            <asp:TemplateField HeaderText="Select" ItemStyle-Width="35">
                <ItemTemplate>
                    <center>
                    <asp:CheckBox ID="chkSelect" runat="server" />
                    </center>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:gridview></asp:Panel>
        <asp:SqlDataSource ID="myDSR" runat="server"></asp:SqlDataSource>
	</asp:panel></td>
								</tr>
								<tr>
									<td>
										<asp:panel id="pnlprevnext" runat="server" visible="true">
											<table cellspacing="0" cellpadding="0" width="100%" border="0">
										        <tr>
											        <td align="left">
												        <p class="wordstyle">&nbsp;Page&nbsp;
													        <asp:Label id="CurrentPage" runat="server" CssClass="wordstyle"></asp:Label>&nbsp;of&nbsp;
													        <asp:Label id="TotalPages" runat="server" CssClass="wordstyle"></asp:Label>
													        <asp:Label id="lbltotal" runat="server" CssClass="wordstyle"></asp:Label></p>
											        </td>
											        <td align="center">
												        <asp:LinkButton id="lnkbtnFirstPage" runat="server" CssClass="wordstyle" Text="[First]" ></asp:LinkButton>
												        <asp:LinkButton id="lnkbtnPrevPage" runat="server" CssClass="wordstyle" Text="[Previous]" ></asp:LinkButton>
													    <asp:LinkButton id="lnkbtnNextPage" runat="server" CssClass="wordstyle" Text="[Next]" ></asp:LinkButton>
													    <asp:LinkButton id="lnkbtnLastPage" runat="server" CssClass="wordstyle" Text="[Last]" ></asp:LinkButton>
													</td>
											        <td align="right">
												        <asp:Label id="lblGoToPage" runat="server" Text="Go To Page" CssClass="wordstyle1"></asp:Label>
												        <asp:TextBox id="txtGoToPage" runat="server" Width="35px" CssClass="toppos"></asp:TextBox>
												        <asp:ImageButton id="imgBtnGoToPage" Height="21px" ImageAlign="AbsBottom" Runat="server"></asp:ImageButton></td>
												    <td style="width:5px">&nbsp;</td>
										        </tr>
									        </table>
										</asp:panel>
									</td>
								</tr>
								<tr>
									<td>
										<asp:panel id="pnlaction" runat="server" visible="true">
											<table cellspacing="0" cellpadding="0" border="0">
												<tr>
													<td>&nbsp;</td>
													<td>&nbsp;</td>
													<td>&nbsp;</td>
												</tr>
												<tr>
												    <td style="width:2px">&nbsp;</td>
												    <td align="left">
														<asp:imagebutton id="imgBtnAdd" runat="server" Height="21px" Width="74px"></asp:imagebutton>
														<asp:imagebutton id="imgBtnEdit" runat="server" Height="21px" Width="74px"></asp:imagebutton>
														<asp:imagebutton id="imgBtnDelete" runat="server" Height="21px" Width="74px" OnClientClick="return confirm('Confirmation! Delete Data(s) ?')"></asp:imagebutton>
														<asp:imagebutton id="imgBtnFilter" runat="server" Height="21px" Width="74px"></asp:imagebutton>
														<asp:imagebutton id="imgBtnPrint" runat="server" Height="21px" Width="74px"></asp:imagebutton>
													</td>
													<td align="left">
													    <asp:panel id="pnlresult" runat="server" visible="true">
									                        <table cellspacing="0" cellpadding="0" border="0">
										                        <tr>
										                            <td><asp:Image ID="Image1" ImageUrl="../../../images/company/default/gif/px1.gif" Width="5px" runat="server" /></td>
											                        <td align="left"><asp:Label id="lblresult" runat="server" CssClass="wordstyle2"></asp:Label></td>
										                        </tr>
									                        </table>
								                        </asp:panel> 
													</td>
												</tr>
											</table>
										</asp:panel></td>
								</tr>
							</table>
							<div id="link" align="right">
    <asp:HyperLink ID="HyplnkReport9" runat="server" Text="Wizard" NavigateUrl="../AdHoc_Reports/Wizards.aspx"></asp:HyperLink>
    <br />
    <asp:HyperLink ID="HyplnkReport1" runat="server" Text="Add New Employee" NavigateUrl="../Information_System/Employee_Personal.aspx"></asp:HyperLink>
    <asp:HyperLink ID="HyplnkReport2" runat="server" Text="Grouping New Employee" NavigateUrl="../Organisation/Employee_group.aspx"></asp:HyperLink>
    <asp:HyperLink ID="HyplnkReport3" runat="server" Text="Salary" NavigateUrl="../Information_System/Employee_Salary.aspx"></asp:HyperLink>
    <asp:HyperLink ID="HyplnkReport4" runat="server" Text="Status" NavigateUrl="../Information_System/Employee_Status.aspx"></asp:HyperLink>
    <asp:HyperLink ID="HyplnkReport5" runat="server" Text="Statutory" NavigateUrl="../Information_System/Employee_Statutory.aspx"></asp:HyperLink>
    <asp:HyperLink ID="HyplnkReport6" runat="server" Text="Resignation" NavigateUrl="../Information_System/Employee_Resign.aspx"></asp:HyperLink>
    <asp:HyperLink ID="HyplnkReport7" runat="server" Text="Payment Bank info" NavigateUrl="../Information_System/Employee_Bank_split.aspx"></asp:HyperLink>
    <asp:HyperLink ID="HyplnkReport8" runat="server" Text="No Of Child Info" NavigateUrl="../Information_System/Employee_No_Of_Child.aspx"></asp:HyperLink>
</div>
						</td>
						
					</tr>
				</table>
	</asp:panel> 
    </div>
    </form>
</body>
</html>
