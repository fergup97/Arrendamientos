<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminMonedas.aspx.cs" Inherits="Arrendamientos.AdminMonedas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <div class="card-header">
            <h4 class="card-title">
                Monedas</h4>
        </div>
        <div class="card-body">
            <table width="100%" class="table">
                <tr>
                    <td>
                        Moneda
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNumero" CssClass="form-control"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button runat="server" ID="BtnAgregar" CssClass="btn btn-info" Text="Agregar empresa" OnClick="btnAgregar_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:Panel ID="panela" Width="100%" Height="400px" ScrollBars="Horizontal" runat="server">
            <asp:GridView ID="Grida" CssClass="table table-bordered" OnRowCommand="Comandos" AutoGenerateColumns="False" DataKeyNames="Id" runat="server" CellPadding="4" GridLines="None" Width="97%">
                <HeaderStyle BackColor="#d4fadb" CssClass="text-center" VerticalAlign="Bottom" />
                <Columns>
                    <asp:BoundField HeaderText="Moneda" DataField="Valor" />
                    <asp:ButtonField Text="Borrar" CommandName="Select" ButtonType="Button" ControlStyle-CssClass="btn btn-danger btn-xs">
                        <ControlStyle CssClass="btn btn-danger btn-xs"></ControlStyle>
                    </asp:ButtonField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </div>
</asp:Content>
