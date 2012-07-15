<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="atomicf1.Default" %>
<%@ Register Src="~/controls/RacerRatio.ascx" TagName="RR" TagPrefix="af1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="Stylesheet" href="res/css/atomicf1.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <af1:RR runat="server" />        
    </div>
    </form>
</body>
</html>
