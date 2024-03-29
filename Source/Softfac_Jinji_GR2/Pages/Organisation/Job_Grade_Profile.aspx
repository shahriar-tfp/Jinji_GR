<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Job_Grade_Profile.aspx.vb" Inherits="Pages_Organisation_Job_Grade_Profile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>JINJI : Organisation - Job Grade Profile Page</title>
    <link href="../../App_Themes/hcrmStyles1.css" type="text/css" rel="stylesheet" />
</head>
<body id="body" runat="server">
    <form id="Job_Grade_Profile" runat="server">
    <div>
    <asp:Panel ID="pnledit" runat="server" visible="true">
    <!--// 1 //-->
	<asp:image id="imgOCP_ID_JOB_GRADE" runat="server" Height="21px" Width="21px"></asp:image>
	<asp:label id="lblOCP_ID_JOB_GRADE" runat="server" Width="140px"></asp:label>
	<asp:textbox id="txtOCP_ID_JOB_GRADE" runat="server" Width="150px"></asp:textbox>
	<asp:imagebutton id="imgBtnOCP_ID_JOB_GRADE" runat="server" Height="21px"></asp:imagebutton>
	<!--// 2 //-->
	<asp:image id="imgEFFECTIVE_DATE" runat="server" Height="21px" Width="21px"></asp:image>
	<asp:label id="lblEFFECTIVE_DATE" runat="server" Width="140px"></asp:label>
	<asp:textbox id="txtEFFECTIVE_DATE" runat="server" Width="150px"></asp:textbox>
	<asp:imagebutton id="imgBtnEFFECTIVE_DATE" runat="server" Height="21px"></asp:imagebutton>
	<!--// 3 //-->
	<asp:image id="imgMIN_SALARY" runat="server" Height="21px" Width="21px"></asp:image>
	<asp:label id="lblMIN_SALARY" runat="server" Width="140px"></asp:label>
	<asp:textbox id="txtMIN_SALARY" runat="server" Width="150px"></asp:textbox>
	<asp:imagebutton id="imgBtnMIN_SALARY" runat="server" Height="21px"></asp:imagebutton>
	<!--// 4 //-->
	<asp:image id="imgMAX_SALARY" runat="server" Height="21px" Width="21px"></asp:image>
	<asp:label id="lblMAX_SALARY" runat="server" Width="140px"></asp:label>
	<asp:textbox id="txtMAX_SALARY" runat="server" Width="150px"></asp:textbox>
	<asp:imagebutton id="imgBtnMAX_SALARY" runat="server" Height="21px"></asp:imagebutton>
	<!--// 5 //-->
	<asp:image id="imgOPTION_NOTICE_PERIOD_TYPE_CONFIRM" runat="server" Height="21px" Width="21px"></asp:image>
	<asp:label id="lblOPTION_NOTICE_PERIOD_TYPE_CONFIRM" runat="server" Width="140px"></asp:label>
	<asp:dropdownlist id="ddlOPTION_NOTICE_PERIOD_TYPE_CONFIRM" runat="server" Width="157"></asp:dropdownlist>
	<asp:imagebutton id="imgBtnOPTION_NOTICE_PERIOD_TYPE_CONFIRM" runat="server" Height="21px"></asp:imagebutton>
	<!--// 6 //-->
	<asp:image id="imgNOTICE_PERIOD_CONFIRM" runat="server" Height="21px" Width="21px"></asp:image>
	<asp:label id="lblNOTICE_PERIOD_CONFIRM" runat="server" Width="140px"></asp:label>
	<asp:textbox id="txtNOTICE_PERIOD_CONFIRM" runat="server" Width="150px"></asp:textbox>
	<asp:imagebutton id="imgBtnNOTICE_PERIOD_CONFIRM" runat="server" Height="21px"></asp:imagebutton>
	<!--// 7 //-->
	<asp:image id="imgOPTION_NOTICE_PERIOD_TYPE_NON_CONFIRM" runat="server" Height="21px" Width="21px"></asp:image>
	<asp:label id="lblOPTION_NOTICE_PERIOD_TYPE_NON_CONFIRM" runat="server" Width="140px"></asp:label>
	<asp:dropdownlist id="ddlOPTION_NOTICE_PERIOD_TYPE_NON_CONFIRM" runat="server" Width="157"></asp:dropdownlist>
	<asp:imagebutton id="imgBtnOPTION_NOTICE_PERIOD_TYPE_NON_CONFIRM" runat="server" Height="21px"></asp:imagebutton>
	<!--// 8 //-->
	<asp:image id="imgNOTICE_PERIOD_NON_CONFIRM" runat="server" Height="21px" Width="21px"></asp:image>
	<asp:label id="lblNOTICE_PERIOD_NON_CONFIRM" runat="server" Width="140px"></asp:label>
	<asp:textbox id="txtNOTICE_PERIOD_NON_CONFIRM" runat="server" Width="150px"></asp:textbox>
	<asp:imagebutton id="imgBtnNOTICE_PERIOD_NON_CONFIRM" runat="server" Height="21px"></asp:imagebutton>
	<!--// 9 //-->
	<asp:image id="imgOPTION_PROBATIONARY_PERIOD_TYPE" runat="server" Height="21px" Width="21px"></asp:image>
	<asp:label id="lblOPTION_PROBATIONARY_PERIOD_TYPE" runat="server" Width="140px"></asp:label>
	<asp:dropdownlist id="ddlOPTION_PROBATIONARY_PERIOD_TYPE" runat="server" Width="157"></asp:dropdownlist>
	<asp:imagebutton id="imgBtnOPTION_PROBATIONARY_PERIOD_TYPE" runat="server" Height="21px"></asp:imagebutton>
	<!--// 10 //-->
	<asp:image id="imgPROBATIONARY_PERIOD" runat="server" Height="21px" Width="21px"></asp:image>
	<asp:label id="lblPROBATIONARY_PERIOD" runat="server" Width="140px"></asp:label>
	<asp:textbox id="txtPROBATIONARY_PERIOD" runat="server" Width="150px"></asp:textbox>
	<asp:imagebutton id="imgBtnPROBATIONARY_PERIOD" runat="server" Height="21px"></asp:imagebutton>
	<!--// 11 //-->
	<asp:image id="imgOPTION_EXECUTIVE" runat="server" Height="21px" Width="21px"></asp:image>
	<asp:label id="lblOPTION_EXECUTIVE" runat="server" Width="140px"></asp:label>
	<asp:dropdownlist id="ddlOPTION_EXECUTIVE" runat="server" Width="157"></asp:dropdownlist>
	<asp:imagebutton id="imgBtnOPTION_EXECUTIVE" runat="server" Height="21px"></asp:imagebutton>
	<!--// 12 //-->
	<asp:image id="imgOPTION_ATTENDANCE" runat="server" Height="21px" Width="21px"></asp:image>
	<asp:label id="lblOPTION_ATTENDANCE" runat="server" Width="140px"></asp:label>
	<asp:dropdownlist id="ddlOPTION_ATTENDANCE" runat="server" Width="157"></asp:dropdownlist>
	<asp:imagebutton id="imgBtnOPTION_ATTENDANCE" runat="server" Height="21px"></asp:imagebutton>
	<!--// 13 //-->
	<asp:image id="imgOPTION_ACTIVE" runat="server" Height="21px" Width="21px"></asp:image>
	<asp:label id="lblOPTION_ACTIVE" runat="server" Width="140px"></asp:label>
	<asp:dropdownlist id="ddlOPTION_ACTIVE" runat="server" Width="157"></asp:dropdownlist>
	<asp:imagebutton id="imgBtnOPTION_ACTIVE" runat="server" Height="21px"></asp:imagebutton>
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
    <asp:imagebutton id="imgBtnSubmit" runat="server" Width="74" Height="21" OnClientClick="return confirm('Confirmation! Submit Data ?')"></asp:imagebutton>
    <asp:imagebutton id="imgBtnSearch" runat="server" Width="74" Height="21"></asp:imagebutton>
    <asp:imagebutton id="imgBtnUpdate" runat="server" Width="74" Height="21" OnClientClick="return confirm('Confirmation! Revise Data ?')"></asp:imagebutton>
    <asp:imagebutton id="imgBtnClear" runat="server" Width="74" Height="21"></asp:imagebutton>
    <asp:imagebutton id="imgBtnCancel" runat="server" Width="74" Height="21"></asp:imagebutton>
	<asp:label id="lblresult2" runat="server" Height="22" Visible="False"></asp:label>
	</asp:Panel>
	<asp:placeholder id="MyPH" Runat="server"></asp:placeholder>
	<asp:panel id="pnldescription" runat="server" visible="False">
	<table id="Table7" style="left: 10px; position: absolute; top: 10px" cellspacing="0" cellpadding="0" border="0" runat="server">
        <tr>
            <td style="background-image:url(../../Images/Company/Default/gif/org_title_bar20.gif);width :5px"></td>
            <td style="background-image:url(../../Images/Company/Default/gif/org_title_bar20.gif); vertical-align:bottom"><asp:Label ID="lblTitle2" runat="server"></asp:Label></td>
        </tr>
    </table>
    </asp:panel> 
	<asp:panel id="pnlmain" runat="server" visible="true">
	<table id="Table1" style="LEFT: 10px; POSITION: absolute; TOP: 10px" cellspacing="0" cellpadding="0" border="0" runat="server">
					<tr>
						<td>
						    <table id="Table6" cellspacing="0" cellpadding="0" width="100%" border="0" runat="server">
                                <tr>
                                    <td style="background-image:url(../../Images/Company/Default/gif/org_title_bar20.gif);width :5px"></td>
                                    <td style="background-image:url(../../Images/Company/Default/gif/org_title_bar20.gif); vertical-align:bottom"><asp:Label ID="lblTitle" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                            <table id="Table5" cellspacing="0" cellpadding="0" border="0" runat="server">
					            <tr>
					                <td style ="height:15px"></td>
					            </tr>
					        </table> 
							<table id="TABLE2" cellspacing="0" cellpadding="0" width="100%" border="0" runat="server">
								<tr>
									<td>
										<asp:panel id="pnlgridview" ScrollBars="Auto" runat="server" visible="true">
											<%--<div style="border-top-style: double; border-right-style: double; border-left-style: double; border-bottom-style: double;border-color :#F2F4FF;">--%>
												<asp:gridview id="myGridView" Width="100%" runat="server" AutoGenerateColumns="true" AutoGenerateEditButton="false" AutoGenerateDeleteButton="false" AutoGenerateSelectButton="false" 
													cellspacing="0" cellpadding="1" EmptyDataText="No data found!">
                                                    <AlternatingRowStyle BackColor="#F2F4FF" />
													<EditRowStyle BackColor="#FFC7C6" CssClass="dgstyle_i" />
													<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
													<Rowstyle BackColor="#FFFFFF" CssClass="dgstyle_i" />
													<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                    <HeaderStyle BackColor="#988675" Height="21" CssClass="dgstyle_h" />
													<columns>
													    <%--<asp:TemplateField HeaderText="Control" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" ItemStyle-Width="80px">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="btnGridEdit" runat="server" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                                                <asp:LinkButton ID="btnGridDelete" runat="server" CommandName="Delete" Text="Delete" OnClientClick="return confirm('Confirmation! Delete Data ?')"></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:LinkButton ID="btnGridUpdate" runat="server" CommandName="Update" Text="Update" OnClientClick="return confirm('Confirmation! Revise Data ?')" />
                                                                <asp:LinkButton ID="btnGridCancel" runat="server" CommandName="Cancel" Text="Cancel" />
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>--%>
														<asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center">
															<HeaderStyle HorizontalAlign="Center" Width="2%"></HeaderStyle>
															<ItemTemplate>
																<asp:CheckBox ID="chkDelete" BorderStyle="None" Runat="server" />
															</ItemTemplate>
														</asp:TemplateField>
													</columns>
												</asp:gridview>
												<asp:SqlDataSource ID="myDSR" runat="server"></asp:SqlDataSource>
											<%--</div>--%>
										</asp:panel>
									    <asp:panel id="pnlCompare" ScrollBars="Auto" runat="server" visible="false">
											<%--<div style="border-top-style: double; border-right-style: double; border-left-style: double; border-bottom-style: double;border-color :#F2F4FF;">--%>
												<asp:gridview id="myGridView1" Width="100%" runat="server" AutoGenerateColumns="true" AutoGenerateEditButton="false" AutoGenerateDeleteButton="false" AutoGenerateSelectButton="false" 
													cellspacing="0" cellpadding="1" EmptyDataText="No data found!">
                                                    <AlternatingRowStyle BackColor="#F2F4FF" />
													<EditRowStyle BackColor="#FFC7C6" CssClass="dgstyle_i" />
													<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
													<Rowstyle BackColor="#FFFFFF" CssClass="dgstyle_i" />
													<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                    <HeaderStyle BackColor="#988675" Height="21" CssClass="dgstyle_h" />
													<columns>
														<asp:TemplateField HeaderText="Select" ItemStyle-HorizontalAlign="Center">
															<HeaderStyle HorizontalAlign="Center" Width="2%"></HeaderStyle>
															<ItemTemplate>
																<asp:CheckBox ID="chkDelete1" BorderStyle="None" Runat="server" />
															</ItemTemplate>
														</asp:TemplateField>
													</columns>
												</asp:gridview>
											<%--</div>--%>
										</asp:panel>	
									</td>
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
												        <asp:LinkButton id="FirstPage" runat="server" CssClass="wordstyle" CommandName="First" OnCommand="NavigationLink_Click"
													        Text="[ First ]"></asp:LinkButton>
												        <asp:LinkButton id="PrevPage" runat="server" CssClass="wordstyle" CommandName="Prev" OnCommand="NavigationLink_Click"
													        Text="[ Prev ]"></asp:LinkButton>
												        <asp:LinkButton id="NextPage" runat="server" CssClass="wordstyle" CommandName="Next" OnCommand="NavigationLink_Click"
													        Text="[ Next ]"></asp:LinkButton>
												        <asp:LinkButton id="LastPage" runat="server" CssClass="wordstyle" CommandName="Last" OnCommand="NavigationLink_Click"
													        Text="[ Last ]"></asp:LinkButton></td>
											        <td align="right">
												        <asp:Label id="lblGoToPage" runat="server" Text="Go To Page" CssClass="wordstyle1"></asp:Label>
												        <asp:TextBox id="txtGoToPage" runat="server" Width="35px" CssClass="toppos"></asp:TextBox>
												        <asp:ImageButton id="imgBtnGoToPage" Height="21px" ImageAlign="AbsBottom" Runat="server"></asp:ImageButton></td>
												    <td style="width:5px">&nbsp;</td>
										        </tr>
									        </table>
										</asp:panel></td>
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
						</td>
					</tr>
				</table>
	</asp:panel> 
    </div>
    </form>
</body>
</html>
