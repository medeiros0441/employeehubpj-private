<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Curriculo_Profissional.aspx.cs" Inherits="FW.UI.Cliente.curriculo.Curriculo_Profissional" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="~/Imagens/objetos-empresa/logo-black.png" rel="icon" type="../image/png" sizes="16x16" />
    <title>Employee Hub PJ: Curriculo</title>
    <link href="~/Imagens/icones/bootstrap-icons.css" rel="stylesheet" />

    <link href="~/Scripts/css/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Scripts/GlobalCSS.css" rel="stylesheet" />
     
    
</head>
<body class="  font-monospace  container-fluid "  >
    <form class=" container mx-auto  " runat="server" id="form">
        <asp:Panel runat="server" ID="Pn_Erro" Visible="false">
                            <div class=" alert-success alert-dismissible fade show col-12   my-2 mb-4" role="alert">
                                    
                       <svg class="bi  " width="25" height="25" fill="currentColor"><use href="Imagens/icones/bootstrap-icons.svg#exclamation-triangle-fill"></use></svg>
                                    <asp:Label      runat="server"  ID="lblMensagem" CssClass=" p-1 font-monospace col-12" Visible="true"  Text="Erro Ao buscar Cliente, Tente Novamente" />
                                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                                </div>
                         <img src="../../Imagens/Undraw/undraw_server_down_s-4-lk.svg"  width="500" height="500" class="img-fluid mx-auto my-4"  /> 
                        </asp:Panel>
    </form>
     
<script src="https://cdnjs.cloudflare.com/ajax/libs/html2pdf.js/0.9.2/html2pdf.bundle.js"></script>
    <script src="../../../node_modules/jspdf/dist/jspdf.umd.js"></script>
     
    <script src="../../Scripts/jquery-3.6.0.min.js"></script>
    <script src="../../Scripts/GlobalJS.js"></script>
    <script src="../../Scripts/js/bootstrap.min.js"></script>
    <script src="../../Scripts/jquery.mask.min.js"></script>

</body>
</html>
