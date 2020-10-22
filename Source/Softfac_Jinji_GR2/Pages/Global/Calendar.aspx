<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Calendar.aspx.vb" Inherits="Pages_Global_Calendar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Global : Calendar Page</title>
    <link href="../../App_Themes/hcrmStyles1.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="Calendar" runat="server">
<div>
    <asp:Panel ID="pnlCalendar" runat="server">
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr height="30px" valign="top">
                <td align="left">
                    <asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td align="right">
                    <asp:DropDownList ID="ddlMonth" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                    <%--<asp:Calendar id="calCalendar" runat="server"
                            Width="176px" Height="136px" ShowTitle="true" DayNameFormat="FirstTwoLetters" SelectionMode="Day"
                            BackColor="#ffffff" CssClass="wordstyle" BorderColor="#3333ff" FirstDayOfWeek="Monday" TodayDayStyle-BackColor="#66ccff">
                            <TitleStyle BackColor="#66ccff"></TitleStyle>
                            <NextPrevStyle BackColor="#66ccff"></NextPrevStyle>
                            <DayStyle ForeColor="#0000cc"></DayStyle>
                            <OtherMonthDayStyle ForeColor="#33cccc"></OtherMonthDayStyle>
                            <WeekendDayStyle ForeColor="#ff00cc"></WeekendDayStyle>
                        </asp:Calendar>--%>
                     <asp:Calendar id="calCalendar" runat="server" Width="100%" Height="136px" ShowTitle="true" DayNameFormat="FirstTwoLetters" SelectionMode="Day"
                        CssClass="wordstyle" BorderColor="#3333ff" FirstDayOfWeek="Monday" BackColor="#EFD5FF">
                        <TitleStyle BackColor="#004A95" ForeColor="#FFFFFF" />
                        <NextPrevStyle BackColor="#004A95" ForeColor="#FFFFFF" />
                        <TodayDayStyle BackColor="#FFD8D7" ForeColor="#00009D" />
                        <DayStyle BackColor="#E6FAFF" ForeColor="#0000cc" HorizontalAlign="Right" />
                        <WeekendDayStyle BackColor="#E6FAFF" ForeColor="#0000cc" />
                        <OtherMonthDayStyle BackColor="#EEEEEE" ForeColor="#33cccc" />
                        <SelectorStyle BackColor="#FFD8D7" ForeColor="#FFD8D7" />
                    </asp:Calendar>
                </td>
            </tr>
         </table>
    </asp:Panel>
	<asp:Literal id="ltrDate" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
