<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Thank.aspx.vb" Inherits="Thank" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>JINJI : Recover Page</title>
    <link id="pageCss1" runat="server" rel="stylesheet" type="text/css" />
    <link id="pageCss2" runat="server" type="text/css" rel="stylesheet" />

    <style type="text/css">
    body, img, div, table, td {
	    background: url(images/theme1/iepngfix.htc);
    }
    </style>

    <script language="javascript" type="text/javascript">
    <!-- hide from older browser
    function MM_swapImgRestore() { //v3.0
      var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
    }

    function MM_preloadImages() { //v3.0
      var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
        var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
        if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
    }

    function MM_findObj(n, d) { //v4.01
      var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
        d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
      if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
      for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
      if(!x && d.getElementById) x=d.getElementById(n); return x;
    }

    function MM_swapImage() { //v3.0
      var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
       if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
    }

    function RefreshPage(){
    document.location=document.location;
    }

    //-->
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="divThank" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" width="510">
	        <tr style="height:5px">
		        <td align="right" valign="top" style="width:5px">
		            <img ID="imgLayout01" runat="server" border="0" width="5" height="5" vspace="0" hspace="0" alt="" /><br />
		        </td>
		        <td align="right" valign="top" style="width:9px">
		            <img ID="imgLayout02" runat="server" border="0" width="9" height="5" vspace="0" hspace="0" alt="" /><br />
		        </td>
		        <td id="tdLayout01" runat="server">
		            <img ID="imgLayout03" runat="server" border="0" vspace="0" hspace="0" height="5" width="500" alt="" /><br />
		        </td>
		        <td align="left" valign="top" style="width:9px">
		            <img ID="imgLayout04" runat="server" border="0" width="9" height="5" vspace="0" hspace="0" alt="" /><br />
		        </td>
		        <td align="left" valign="top" style="width:5px">
		            <img ID="imgLayout05" runat="server" border="0" width="5" height="5" vspace="0" hspace="0" alt="" /><br />
		        </td>
	        </tr>

	        <tr>
		        <td align="right" valign="top" style="width:5px">
		            <img ID="imgLayout06" runat="server" border="0" width="5" height="9" vspace="0" hspace="0" alt="" /><br />
		        </td>
		        <td width="100%" rowspan="3" colspan="3" valign="top">
		        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="general_background">
			        <tr style="height:9px">
				        <td align="left" valign="top" style="width:9px">
				            <img ID="imgLayout07" runat="server" border="0" width="9" height="9" vspace="0" hspace="0" alt="" /><br />
				        </td>
				        <td id="tdLayout02" runat="server" align="left" valign="top" >
				            <img ID="imgLayout08" runat="server" border="0" width="482" height="9" vspace="0" hspace="0" alt="" /><br />
				        </td>
				        <td align="right" valign="top" style="width:9px">
				            <img ID="imgLayout09" runat="server" border="0" width="9" height="9" vspace="0" hspace="0" alt="" /><br />
				        </td>
			        </tr>

			        <tr style="height:330px">
				        <td id="tdLayout03" runat="server" align="left" valign="top" >
				            <img ID="imgLayout10" runat="server" border="0" width="9" height="330" vspace="0" hspace="0" alt="" /><br />
				        </td>
				        <td align="left" valign="top" width="100%">
				        <table border="0" cellpadding="0" cellspacing="0" width="100%">
					        <tr>
						        <td colspan="2" align="left" valign="top" width="100%">
						            <br /><h1>&nbsp; PASSWORD RECOVERY</h1>
						        </td>
					        </tr>
					        <tr>
						        <td align="left" valign="top" width="10%">
						            <img ID="imgLayout12" runat="server" width="50" height="200" vspace="0" hspace="0" alt="" /><br />
						        </td>
						        <td align="left" valign="middle" width="70%">
						            <asp:label id="lblTitle" runat="server" CssClass="wordstyle11"></asp:label><br /><br />
						            <asp:label id="lblTitle2" runat="server" CssClass="wordstyle"></asp:label><br />
						            <asp:label id="lblTitle3" runat="server" CssClass="wordstyle"></asp:label><br /><br />
						            <asp:label id="lblTitle4" Font-Bold="true" Font-Underline="true"  runat="server" CssClass="wordstyle"></asp:label><br />
						            <asp:label id="lblTitle5" runat="server" CssClass="wordstyle"></asp:label><br /><br />
						            Return to <a href="Login.aspx">Login</a> page.<br />
						            <%--<table border="0" cellpadding="0" cellspacing="0" width="95%">
						                <tr>
								            <td align="left" valign="middle" width="30%">
								            <b>Employee Code</b><br />
								            </td>
								            <td align="left" valign="middle" width="70%">
								            <input type="text" name="empcode" value="" maxlength="100" size="23"> <a href="Thank.aspx"><img id="imgSubmit" runat="server" src="" width="74" height="21" style="vertical-align:top; border-style:none" alt="Submit" /></a><br />
								            </td>
							            </tr>

							            <tr>
								            <td colspan="2" width="100%" align="left">
								            <br /><b>OR</b><br /><br />
								            <b>Forgot your Employee Code?</b><br />
								            Enter your email to start the password recovery process<br />
								            </td>
							            </tr>

							            <tr>
								            <td align="left" valign="middle" width="30%">
								            <b>Email</b><br />
								            </td>
								            <td align="left" valign="middle" width="70%">
								            <input type="text" name="email" value="" maxlength="100" size="23"> <a href="Thank.aspx"><img id="imgSubmit2" runat="server" src="" width="74" height="21" style="vertical-align:top;  border-style:none" alt="Submit" /></a><br />
								            </td>
							            </tr>
							            <tr>
								            <td align="left" valign="middle" width="30%">
								            <b>&nbsp;</b><br />
								            </td>
								            <td align="left" valign="middle" width="70%">
								            <br />[ <a href="login.aspx">Login Here</a> ]<br />
								            </td>
							            </tr>
						            </table>	--%>
						        </td>
					        </tr>
					        <tr>
						        <td colspan="2" align="center" valign="top" width="100%" class="copyright">
						            <div id="footer">
						                <asp:Label ID="lblCopyRight" CssClass="wordstyle9" runat="server">Copyright &copy; 2008 SoftFac Technology Sdn Bhd. <i>All Rights Reserved</i> Powered by <img ID="imgLayout14" runat="server" border="0" width="23" height="13" alt="Softfac" style="vertical-align:middle;" /><br /></asp:Label>
                                    </div>
						        </td>
					        </tr>

				        </table>
				        </td>
				        <td id="tdLayout04" runat="server" align="right" valign="top" >
				            <img ID="imgLayout15" runat="server" border="0" width="9" height="330" vspace="0" hspace="0" alt="" /><br />
				        </td>
			        </tr>

			        <tr style="height:9px">
				        <td align="left" valign="bottom" width="9">
				            <img ID="imgLayout16" runat="server" border="0" width="9" height="9" vspace="0" hspace="0" alt="" /><br />
				        </td>
				        <td id="tdLayout05" runat="server" align="left" valign="bottom">
				            <img ID="imgLayout17" runat="server" border="0" width="482" height="9" vspace="0" hspace="0" alt="" /><br />
				        </td>
				        <td align="right" valign="bottom" width="9">
				            <img ID="imgLayout18" runat="server" border="0" width="9" height="9" vspace="0" hspace="0" alt="" /><br />
				        </td>
			        </tr>
		        </table>
		        </td>
		        <td align="left" valign="top" width="5">
		            <img ID="imgLayout19" runat="server" border="0" width="5" height="9" vspace="0" hspace="0" alt=""/><br />
		        </td>
	        </tr>

	        <tr style="height:330px">
		        <td id="tdLayout06" runat="server" align="right" valign="top" >
		            <img ID="imgLayout20" runat="server" border="0" width="5" height="330" vspace="0" hspace="0" alt="" /><br />
		        </td>
		        <td id="tdLayout07" runat="server" align="left" valign="top" >
		            <img ID="imgLayout21" runat="server" border="0" width="5" height="330" vspace="0" hspace="0" alt="" /><br />
		        </td>
	        </tr>

	        <tr>
		        <td align="right" valign="top" width="5">
		            <img ID="imgLayout22" runat="server" border="0" width="5" height="9" vspace="0" hspace="0" alt="" /><br />
		        </td>
		        <td align="left" valign="top" width="5">
		            <img ID="imgLayout23" runat="server" border="0" width="5" height="9" vspace="0" hspace="0" alt="" /><br />
		        </td>
	        </tr>

	        <tr style="height:5px">
		        <td align="right" valign="top" width="5">
		            <img ID="imgLayout24" runat="server" border="0" width="5" height="5" vspace="0" hspace="0" alt="" /><br />
		        </td>
		        <td align="right" valign="top" width="9">
		            <img ID="imgLayout25" runat="server" border="0" width="9" height="5" vspace="0" hspace="0" alt="" /><br />
		        </td>
		        <td id="tdLayout08" runat="server">
		            <img ID="imgLayout26" runat="server" border="0" vspace="0" hspace="0" height="5" width="500" alt="" /><br />
		        </td>
		        <td align="left" valign="top" width="9">
		            <img ID="imgLayout27" runat="server" border="0" width="9" height="5" vspace="0" hspace="0" alt="" /><br />
		        </td>
		        <td align="left" valign="top" width="5">
		            <img ID="imgLayout28" runat="server" border="0" width="5" height="5" vspace="0" hspace="0" alt="" /><br />
		        </td>
	        </tr>
        </table>
    </div>
    </form>
</body>
</html>
