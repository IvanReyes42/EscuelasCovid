<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlSintomas.aspx.cs" Inherits="ControlEscuela.ControlSintomas" %>

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
                    <asp:Button ID="btnSintomas" runat="server" Text="Registro Diarios" OnClick="btnSintomas_Click"  Width="235px" />
                </td>
            </tr>
        </table>
        <div class="auto-style1">
            Control Sintomas</div>
        <table class="auto-style2">
            <tr>
                <td>
                    <table class="auto-style2">
                        <tr>
                            <td class="auto-style1">Fecha</td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
                            </td>
                            <td class="auto-style1">&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td class="auto-style1">&nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td class="auto-style1">Matricula</td>
                            <td>
                                <asp:TextBox ID="txtMatricula" runat="server"></asp:TextBox>
                            </td>
                            <td class="auto-style1">
                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table align="center" class="auto-style2">
                        <tr>
                            <td>
                                <asp:GridView ID="dvgSintomas" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                                <div class="auto-style1">
                                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                                    <br />
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
