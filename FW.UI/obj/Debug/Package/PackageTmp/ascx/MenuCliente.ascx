<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuCliente.ascx.cs" Inherits="FW.UI.ascx.MenuCliente" %>

<asp:Panel runat="server" ID="MenuClient" ClientIDMode="Static" Visible="true" CssClass="  bg-dark container-fluid d-none d-md-block    "       style="margin-top:-10px;">
    <div class="container row justify-content-center align-items-center  row-cols-sm-3 pb-3 gy-2   mx-auto d-flex text-light      ">
        <div class="  text-start px-2 d-flex col-sm-auto">
            <svg class="bi me-2 color-laranja  " width="25" height="25" fill="currentColor">
                <use href="../Imagens/icones/bootstrap-icons.svg#speedometer2"></use></svg>
            <a href="default.aspx" class="  customer-link ">FEED</a>
        </div>

        <div class="text-start px-2 d-flex col-sm-auto">
            <svg class="bi me-2 color-laranja" width="25" height="25" fill="currentColor">
                <use href="../Imagens/icones/bootstrap-icons.svg#person-lines-fill" />
            </svg>
            <asp:LinkButton runat="server" OnCommand="BtnViewCliente_Command" CssClass="customer-link">PERFIL</asp:LinkButton>
        </div>


        <div class="text-start px-2 d-flex col-sm-auto">
            <svg class="bi me-2 color-laranja" width="25" height="25" fill="currentColor">
                <use href="../Imagens/icones/bootstrap-icons.svg#bell" />
            </svg>
            <a href="../pages/notificacao.aspx" class="customer-link">NOTIFICAÇÔES</a>
        </div>

            <asp:Panel runat="server" ID="btnInscricao" Visible="false"  CssClass=" text-start px-2 d-flex col-sm-auto">
                <svg class="bi me-2 color-laranja" width="25" height="25" fill="currentColor">
                    <use href="../Imagens/icones/bootstrap-icons.svg#layers" />
                </svg>
                <asp:LinkButton runat="server"  CssClass="customer-link" PostBackUrl="../pages/CandidaturaPro.aspx">INSCRIÇÕES</asp:LinkButton>
            </asp:Panel>

               <asp:Panel runat="server" ID="btnExperiencia" Visible="false" CssClass=" text-start px-2 d-flex col-sm-auto">
                <svg class="bi me-2  color-laranja" width="25" height="25" fill="currentColor">
                    <use href="../Imagens/icones/bootstrap-icons.svg#folder-plus" />
                </svg>
                <asp:LinkButton runat="server"  CssClass="customer-link" PostBackUrl="../pages/addExperiencia.aspx">EXEPERIÊNCIA</asp:LinkButton>
            </asp:Panel>

            <asp:Panel runat="server" ID="btnCertificado" Visible="false"   CssClass=" text-start px-2 d-flex col-sm-auto">
                <svg class="bi me-2 color-laranja" width="25" height="25" fill="currentColor">
                    <use href="../Imagens/icones/bootstrap-icons.svg#mortarboard" />
                </svg>
                <asp:LinkButton runat="server"  CssClass="customer-link" PostBackUrl="../pages/addCertificados.aspx">CERTIFICADO</asp:LinkButton>
            </asp:Panel>


            <asp:Panel runat="server" ID="btnCriarOportunidade"  Visible="false" CssClass="text-start px-2 d-flex col-sm-auto">
                <svg class="bi me-2 color-laranja" width="25" height="25" fill="currentColor">
                    <use href="../Imagens/icones/bootstrap-icons.svg#file-earmark-plus" />
                </svg>
                <asp:LinkButton runat="server" PostBackUrl="../pages/EditarVagas.aspx" CssClass="customer-link">CRIAR OPORTUNIDADE</asp:LinkButton>
            </asp:Panel>

            <asp:Panel runat="server" ID="btnCandidatos" Visible="false" class=" text-start px-2 d-flex col-sm-auto">
                <svg class="bi me-2 color-laranja" width="25" height="25" fill="currentColor">
                    <use href="../Imagens/icones/bootstrap-icons.svg#stack" />
                </svg>
                <asp:LinkButton runat="server" OnCommand="Add_value_Command" ID="add_value" CssClass="customer-link">LISTA CANDIDATOS</asp:LinkButton>
            </asp:Panel>

            <asp:Panel runat="server" ID="btnSaldo" Visible="false"  CssClass="text-start px-2 d-flex col-sm-auto">
                <svg class="bi me-2 color-laranja" width="25" height="25" fill="currentColor">
                    <use href="../Imagens/icones/bootstrap-icons.svg#cash-coin" />
                </svg>
                <a href="View_Saldo.aspx" class="customer-link"  >VER SALDO</a>
            </asp:Panel>


        <div class=" text-start px-2 d-flex col-sm-auto">
            <svg class="bi me-2 color-laranja" width="25" height="25" fill="currentColor">
                <use href="../Imagens/icones/bootstrap-icons.svg#gear" />
            </svg>
            <asp:LinkButton runat="server" ID="Btnconf" CssClass="customer-link" PostBackUrl="../pages/Configuracao.aspx">CONFIGURAÇÃES</asp:LinkButton>
        </div>

    </div>
</asp:Panel>
