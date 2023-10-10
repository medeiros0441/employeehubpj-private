<%@ Page Title="" Language="C#" Async="true" MasterPageFile="../Default.Master" AutoEventWireup="true" CodeBehind="SaldoEmpresa.aspx.cs" Inherits="FW.UI.pages.SaldoEmpresa" %>

<%@ MasterType VirtualPath="../Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-3 row justify-content-between">

        <div class="   col-auto">
            <svg class="bi me-2" width="35" height="35" fill="currentColor">
                <use href="../Imagens/icones/bootstrap-icons.svg#cash-coin"></use></svg>
        <asp:Label runat="server" CssClass="fs-4  font-monospace   fw-bold ">QR-CODE PIX</asp:Label>
        </div>
        <div class="   text-end  col     ">
            <asp:LinkButton runat="server"  ID="LB_Cancelar" OnClick="LB_Cancelar_Click" class="sidebar-heading  float-end font-monospace text-decoration-none btn-outline-customer  p-1 btn-sm   border-0  col d-flex ">
                <svg class="bi me-2" width="30" height="30" fill="currentColor">
                    <use href="../Imagens/icones/bootstrap-icons.svg#patch-minus"></use></svg>
                <small class=" my-2 ">Cancelar</small>
            </asp:LinkButton>
        </div>
    </div>
    <asp:Panel runat="server" ID="Panel1" CssClass=" mx-auto ">


        <div class="card mx-auto" style="width: 18rem;">

             <div class="card-header fw-bold">
   <span class="nome-empresa"></span>
  </div>

            <asp:Image ID="imgQRCode" runat="server" CssClass="card-img-top img-fluid" />
            <div class="card-body p-3 fw-bold">
                <asp:LinkButton runat="server" ID="lbl_ValorCopiar" CssClass="icon-link text-decoration-none  small col lbl_ValorCopiar icon-link-hover">
                     <svg class="bi" aria-hidden="true"  width="20" height="20" fill="currentColor">
                 <use   href="../Imagens/icones/bootstrap-icons.svg#clipboard"></use></svg>
                 COPIAR CHAVE PIX
                </asp:LinkButton>
            </div>
              <ul class="list-group list-group-flush">
    <li class="list-group-item"><asp:Label runat="server"  class="fw-bold font-monospace " >PRODUTO: </asp:Label> <asp:Label runat="server" ID="lbl_Produto"  CssClass="small font-monospace "></asp:Label></li>
    <li class="list-group-item"><asp:Label runat="server" class="fw-bold font-monospace " >VALOR: </asp:Label> <asp:Label runat="server" ID="lbl_valor"></asp:Label></li>
    <li class="list-group-item"><asp:Label runat="server" class="fw-bold font-monospace "  >Data: </asp:Label> <asp:Label runat="server" ID="lbl_Data"></asp:Label></li>
    <li class="list-group-item"><asp:Label runat="server" class="fw-bold font-monospace "  >HORA: </asp:Label> <asp:Label  runat="server" ID="lbl_Hora"></asp:Label></li>
    <li class="list-group-item"><asp:Label runat="server" class="fw-bold font-monospace "    >Status: </asp:Label> <asp:Label runat="server" ID="lbl_Status"></asp:Label></li>
  </ul>
        </div>


    </asp:Panel>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/clipboard.js/2.0.8/clipboard.min.js"></script>

    <script>
        // seleciona o botão pelo ID
        var btnCopiar = document.querySelector('.lbl_ValorCopiar');
        var clipboard = new ClipboardJS(btnCopiar);

        clipboard.on('success', function (e) {
            console.log('Texto copiado: ' + e.text);
        });

        clipboard.on('error', function (e) {
            console.log('Erro ao copiar texto: ' + e.text);
        });

    </script>
</asp:Content>
