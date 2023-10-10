<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="FW.UI.ascx.Header" %>
<div class=" container-fluid mx-auto  " style="background: var(--bs-dark);">


    <header class="row container mx-auto flex-nowrap justify-content-between align-items-center   mb-2 " style="background: var(--bs-dark);">
        <div class="col pt-1">
            <img class="d-block  my-2 " src="../imagens/objetos-empresa/logo-whiter.png" alt="" width="72" height="72" />
        </div>
        <div class="col text-center ">
            <a class="blog-header-logo customer-link text-light nome-empresa" href="default.aspx"></a>
        </div>
        <div class="col d-flex justify-content-end align-items-center p-0">
            <a class="text-muted  border-0   p-1     " onclick="open_filtro()" id="BtnFiltro">
                <svg class="bi text-light " width="15" height="20" viewBox="0 0 24 24" fill="currentColor">
                    <use href="../Imagens/icones/bootstrap-icons.svg#search"></use></svg>
            </a>
            <asp:LinkButton runat="server" class="  border-0   btn  p-1    " CausesValidation="false" OnClick="Btn_login_Click" ID="btn_login">
                                    <svg class="bi color-laranja " width="20" height="25" viewBox="0 0 24 24"   fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#person"></use></svg>
            </asp:LinkButton>
            <asp:Panel runat="server" Visible="false" ID="MenuClienteBtns" class=" justify-content-end p-0 m-0  text-end col-auto d-inline-flex float-end order-3    ">
                <a id="BtnFecharMenu" onclick="FecharMenu()" clientidmode="Static" causesvalidation="false" class="BtnFecharMenu d-none d-md-block btn  border-0  p-1  ">
                    <svg class="bi text-light " width="20" height="20" viewBox="0 0 24 24" fill="currentColor">
                        <use href="../Imagens/icones/bootstrap-icons.svg#box-arrow-in-up"></use></svg>
                </a>
                <a onclick="AbrirMenu()" clientidmode="Static" class="   btn d-block d-md-none border-0 p-1  " causesvalidation="false" id="BtnAbrirMenu">
                    <svg class="bi text-light   " width="20" height="20" viewBox="0 0 24 24" fill="currentColor">
                        <use href="../Imagens/icones/bootstrap-icons.svg#box-arrow-down"></use></svg>
                </a>
            </asp:Panel>
        </div>
    </header>

</div>
