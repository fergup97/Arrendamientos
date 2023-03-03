<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Graficas.aspx.cs" Inherits="Arrendamientos.Graficas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="/js/jquery-1.10.2.js"></script>
    <script src="/js/canvasjs.min.js" type="text/javascript"></script>
    <script src="/js/jquery.canvasjs.min.js" type="text/javascript"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card mb-3">
        <div class="card-header">
            <div class="row flex-between-end">
                <div class="col-auto align-self-center">
                    <h5 class="mb-0" data-anchor="data-anchor">Reportes</h5>
                </div>

            </div>
        </div>
        <div class="card-body pt-0 px-0">
            <table class="table">
                <tr>
                    <td>Tipo de grafica</td>
                    <td>
                        <asp:DropDownList ID="DDLTipo" AutoPostBack="true" OnSelectedIndexChanged="Graficar" CssClass="form-control" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Dato a Graficar</td>
                    <td>
                        <asp:DropDownList ID="ddlAgraficar" AutoPostBack="true" OnSelectedIndexChanged="Graficar" CssClass="form-control" runat="server">
                            <asp:ListItem Text="Estatus" Value="Estatus"></asp:ListItem>
                            <asp:ListItem Text="Empresa" Value="Empresa"></asp:ListItem>
                            <asp:ListItem Text="Moneda" Value="Moneda"></asp:ListItem>
                            <asp:ListItem Text="Estado" Value="Estado"></asp:ListItem>
                            <asp:ListItem Text="Arrendadora" Value="Arrendadora"></asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
            </table>
            <div id="chartContainer" style="height: 400px; width: 100%;">
            </div>
        </div>
    </div>
    <div id="cargarCanvas" runat="server">
    </div>
</asp:Content>
