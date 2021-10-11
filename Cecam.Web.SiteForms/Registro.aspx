<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Cecam.Web.SiteForms.Registro" %>

<asp:Content ID="RegisterPage" runat="server" ContentPlaceHolderID="MainContent">
<div class="container">
    <div class="col-sm-10 col-sm-offset-3 col-md-10 col-md-offset-2 main">
    <h1>Registro de cliente</h1>
        <br />
    <asp:PlaceHolder ID="ErrorDiv" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="validateDiv" runat="server"></asp:PlaceHolder>
        <form id="RegisterCompany" runat="server" method="post" action="#">
            <asp:HiddenField runat="server" ID="Id" />
            <div class="row">
                <div class="col-md-4">
                    <asp:Label runat="server" AssociatedControlID="CompanyName" Text="Razão Social"></asp:Label>
                    <asp:TextBox runat="server" ID="CompanyName" CssClass="form-control"></asp:TextBox><br />
                </div>
                <div class="col-md-6">
                    <asp:Label runat="server" AssociatedControlID="PhoneNumber" Text="Telefone"></asp:Label>
                    <asp:TextBox runat="server" ID="PhoneNumber" CssClass="form-control"></asp:TextBox><br />
                </div>
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:Label runat="server" AssociatedControlID="DocumentNumber" Text="CNPJ"></asp:Label>
                    <asp:TextBox runat="server" ID="DocumentNumber" CssClass="form-control"></asp:TextBox><br />
                </div>
                <div class="col-md-4">
                    <asp:Label runat="server" AssociatedControlID="Active" Text="Ativo"></asp:Label>
                    <asp:CheckBox runat="server" ID="Active" />
                </div>
            </div>
            <asp:Button runat="server" CssClass="btn btn-success btn-block" ID="btnSalvar" OnClick="btnSalvar_Click" Text="Salvar"/>
        </form>
    </div>
</div>
</asp:Content>