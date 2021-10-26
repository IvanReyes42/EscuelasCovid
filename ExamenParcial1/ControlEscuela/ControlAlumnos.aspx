<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlAlumnos.aspx.cs" Inherits="ControlEscuela.ControlAlumnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <table class="auto-style2">
                <tr>
                    <td>
                        <h1>Control de Sistemas Covid Escuelas</h1>
                    </td>
                    <td>
                        <asp:Button ID="btnVolver" runat="server" Text="Volver" OnClick="btnVolver_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <table align="center" class="auto-style2">
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="btnAlumnos" runat="server" Text="Alumnos"  Width="235px" OnClick="btnAlumnos_Click" />
                </td>
                <td class="auto-style1">
                    <asp:Button ID="BtnPadres" runat="server" Text="Padres de Familia" OnClick="BtnPadres_Click"  Width="235px" />
                </td>
                <td class="auto-style1">
                    <asp:Button ID="btnSintomas" runat="server" Text="Registro Diarios" OnClick="btnSintomas_Click" Width="235px" />
                </td>
            </tr>
        </table>
        <div class="auto-style1">
            Control de Alumnos</div>
        <table class="auto-style2">
            <tr>
                <td>
                    <table class="auto-style2">
                        <tr>
                            <td>Matricula</td>
                            <td>
                                <asp:TextBox ID="txtMatricula" runat="server" Width="389px"></asp:TextBox>
&nbsp;
                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="134px" OnClick="btnBuscar_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="auto-style1" >
                    <div class="auto-style1"  >
                    <asp:GridView ID="dvgAlumnos" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" HorizontalAlign="Center">
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />
                    </asp:GridView>
                    </div>
                    <br />
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
