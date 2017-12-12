<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sample01.aspx.cs" Inherits="DemoChart.Sample01" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table style="width: 99%">
        <tr>
            <td style="width: 150px; text-align: right">
                Loại biểu đồ:
            </td>
            <td>
                <asp:DropDownList ID="drTypeChart" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drTypeChart_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Chart ID="Chart1" runat="server"  Width="800" Height="400" Palette="SeaGreen">
                    <Series>
                        <asp:Series Name="Category" ChartArea="ChartArea1"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                            <Area3DStyle Enable3D="true" />
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </td>
        </tr>
    </table>
    <table style="width: 99%">
        <tr>
            <td style="width: 150px; text-align: right">
                Loại biểu đồ:
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Chart ID="Chart2" runat="server"  Width="800" Height="400" Palette="SeaGreen">
                    <Series>
                        <asp:Series Name="aspnet" ChartArea="ChartArea2"></asp:Series>
                        <asp:Series Name="php" ChartArea="ChartArea2"></asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea2">
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </td>
        </tr>
    </table>    
    </form>
</body>
</html>
