<%@ Page Language="C#" Title="Index" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Cecam.Web.SiteForms.Index" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<form runat="server">
    <h1>Teste Cecam - Registro de clientes</h1>
    <asp:GridView ID="CompanyGridView" CssClass="table table-striped" 
            Font-Size="Medium" ClientIDMode="Static" Visible="True" GridLines="None" 
            AutoGenerateColumns="False" DataKeyNames="Id" runat="server" OnRowCommand="CompanyGridView_RowCommand">
        <EmptyDataTemplate>
            <p>Nenhum registro encontrado!</p>
        </EmptyDataTemplate>
        <Columns>
            <asp:TemplateField HeaderText="Cód. Cliente">
                <ItemTemplate><%#Eval("Id")%></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Razão Social">
                <ItemTemplate><%#Eval("CompanyName")%></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Telefone">
                <ItemTemplate><%#Eval("PhoneNumber")%></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CNPJ">
                <ItemTemplate><%#Eval("DocumentNumber")%></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ativo">
                <ItemTemplate><%#Convert.ToBoolean(Eval("Active")) ? "Sim" : "Não"%></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Criado em:">
                <ItemTemplate><%#Eval("Created")%></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Alterado em:">
                <ItemTemplate><%#Eval("Modified")%></ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFormatString="/Registro.aspx?id={0}" DataNavigateUrlFields="Id" Text="Alterar cliente" ControlStyle-CssClass="btn btn-sm btn-info" />
            <asp:ButtonField CommandName="DeleteCustomer" ButtonType="Button" Text="Excluir" ControlStyle-CssClass="btn btn-sm btn-danger" />
        </Columns>
    </asp:GridView>
    <asp:HyperLink runat="server" NavigateUrl="/Registro.aspx"><button runat="server" type="button" class="btn btn-primary">Cadastrar novo usuário</button></asp:HyperLink>
</form>
</asp:Content>

