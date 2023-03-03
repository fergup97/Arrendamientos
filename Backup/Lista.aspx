<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="Arrendamientos.Lista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card">
        <div class="card-header">
            <h4 class="card-title">
                Arrendamientos</h4>
        </div>
        <div class="card-body">
        <table width="100%" class="table">
                <tr>
                    <td>
                        Número de arrendamiento
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNumero" CssClass="form-control"></asp:TextBox>
                    </td>
                    <td>
                        Empresa solicitante
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtEmpresa" CssClass="form-control"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        Arrendadora
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtArrendadora" CssClass="form-control"></asp:TextBox>
                        
                    </td>
                
                    <td>
                        Equipo
                    </td>
                    <td>
                        <asp:TextBox runat="server" TextMode="MultiLine" ID="txtEquipo" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Provedor
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtProveedor" CssClass="form-control"></asp:TextBox>
                        
                    </td>
                
                    <td>
                        Condiciones de pago
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtCondiciones" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Estatus
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlEstatus" CssClass="form-control">
                        </asp:DropDownList>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <asp:Button runat="server" ID="BtnVer" CssClass="btn btn-info" Text="Ver Registros" onclick="btnVer_Click" />
                    </td>
                </tr>
                
                </table>
            <asp:Panel ID="panela" Width="100%" Height="400px" ScrollBars="Horizontal" runat="server">
                <asp:GridView ID="Grida" CssClass="table table-bordered" OnRowCommand="Comandos" AutoGenerateColumns="False" DataKeyNames="Id,Usuario" runat="server" CellPadding="4" GridLines="None" Width="97%">
                    <HeaderStyle BackColor="#d4fadb" CssClass="text-center" VerticalAlign="Bottom" />
                    <Columns>
                        <asp:ButtonField Text="Detalles" CommandName="Select" ButtonType="Button" ControlStyle-CssClass="btn btn-success btn-xs">
                            <ControlStyle CssClass="btn btn-primary btn-xs"></ControlStyle>
                        </asp:ButtonField>
                        <asp:BoundField HeaderText="Numero de arrendamiento" DataField="Numero" />
                        <asp:BoundField HeaderText="Empresa solicitante" DataField="Empresa" />
                        <asp:BoundField HeaderText="Arrendadora" DataField="Arrendadora" />
                        <asp:BoundField HeaderText="Equipo" DataField="Equipo" />
                        <asp:BoundField HeaderText="Provedor" DataField="Proveedor" />
                        <asp:BoundField HeaderText="Condiciones de pago" DataField="CondicionesDePago" />
                        <asp:BoundField HeaderText="Estatus" DataField="Estatus" />
                        <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
