<%@ Page Title="" Language="C#" MasterPageFile="~/pro/Default.Master" AutoEventWireup="true" CodeBehind="EditarEmail.aspx.cs" Inherits="FW.UI.pro.EditarEmail" %>

<%@ MasterType VirtualPath="~/pro/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row ">
        <div class="col-sm-12 ">
            <asp:Panel runat="server" ID="PlMensagemErro" Visible="false">
                <div class="alert alert-danger alert-dismissible fade show  my-2 mb-1" role="alert">

                    <svg class="bi " width="25" height="25" fill="currentColor">
                        <use href="../Imagens/icones/bootstrap-icons.svg#exclamation-triangle-fill"></use></svg>
                    <asp:Label runat="server" ID="lblMensagemErro" CssClass="alert p-1 text-uppercase  col-12" Visible="false" />
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>
            </asp:Panel>
            <asp:Panel runat="server" ID="PlMensagemSucesso" Visible="false">

                <div class="alert alert-success alert-dismissible fade show col-12   my-2 mb-1" role="alert">

                    <svg class="bi  " width="25" height="25" fill="currentColor">
                        <use href="../Imagens/icones/bootstrap-icons.svg#check-circle-fill "></use></svg>
                    <asp:Label runat="server" ID="lblMensagemSucesso" CssClass="alert p-1 text-uppercase small  col-12" Visible="false" />
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>
            </asp:Panel>
        </div>

        <div class="mb-2 col-11 form-floating">
            <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" Enabled="false" TabIndex="8" placeholder="Email" MaxLength="100" TextMode="Email" />
            <label for="txtEmail" class="text-secondary small">Email</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="mx-auto small text-truncate" ValidationGroup="dadosperfil" Display="Dynamic" ControlToValidate="txtEmail" ErrorMessage="Campo é obrigatório" ForeColor="red" />
        </div>
        <div class="my-auto text-center col-1">
            <asp:LinkButton runat="server" ID="btn_EditarEmail" CausesValidation="false" OnClick="Btn_EditarEmail_Click">
                <svg class="bi img-fluid   " width="32" height="32" fill="currentColor">
                    <use runat="server" id="icon_email" href="../Imagens/icones/bootstrap-icons.svg#pencil-square" />
                </svg>
            </asp:LinkButton>
        </div>
    </div>
</asp:Content>
