<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="Arrendamientos.Detalles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="card">
        <div class="card-header">
            <h4 class="card-title">
                Agregar Arrendamiento</h4>
        </div>
        <div class="card-body">
            <table width="100%" class="table">
                <tr>
                    <td>
                        Número de arrendamiento o Número de equipo
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNumero" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
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
                </tr>
                <tr>
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
                </tr>
                <tr>
                    <td>
                        Condiciones de pago
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtCondiciones" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Monto sin iva
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtMonto" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Moneda
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtMoneda" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Estado Contractual
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtEstado" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Responsable
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtResponsable" CssClass="form-control"></asp:TextBox>
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
                </tr>
                <tr>
                    <td>
                        Ordén de compra
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtOrden" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Fecha de Ordén de Compra
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFechaOrden" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Número de requesición
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtRequisicion" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Fecha de Requisición
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFechaRequisicion" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Fecha de colocación
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFechaColocacion" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Plazo de entrega
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPlazo" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Comentarios y observaciones
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtComentarios" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td colspan="2">
                        <asp:Panel ID="panela" Width="100%" Height="400px" ScrollBars="Horizontal" runat="server">
                            <asp:GridView ID="GridaDocumetos" CssClass="table table-bordered" AutoGenerateColumns="False" DataKeyNames="Url,Detalles" runat="server" CellPadding="4" GridLines="None" Width="97%">
                                <HeaderStyle BackColor="#d4fadb" CssClass="text-center" VerticalAlign="Bottom"/>
                                <Columns>
                                    <asp:TemplateField HeaderText="Documentos">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("Url") %>' Text='<%# Eval("Detalles") %>'>
                                            </asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <asp:Button runat="server" ID="BtnAgregar" CssClass="btn btn-info" Text="Regresar" onclick="btnAgregar_Click" />
        </div>
    </div>

</asp:Content>
