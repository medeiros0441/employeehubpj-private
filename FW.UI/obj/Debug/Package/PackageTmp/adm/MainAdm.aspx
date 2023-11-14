<%@ Page Title="" Language="C#" MasterPageFile="~/adm/DefultADM.Master" AutoEventWireup="true" CodeBehind="MainAdm.aspx.cs" Inherits="FW.UI.MainAdm" %>
<%@ MasterType VirtualPath="~/adm/DefultADM.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
 
<div class="row">
  <div class="col">
    <div class="card text-dark  mb-3" style="max-width: 18rem;"    >  
        <div class="card-header  "> <svg class="bi  me-2  text-dark" width="20" height="20" role="img" fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#people"></use></svg><asp:Label runat="server" Text="Clientes" CssClass="text-dark font-monospace  fw-bold" ></asp:Label>   </div>

  <div class="card-body mx-auto "> 
      <asp:Label runat="server" ID="lbl_qunt_Clientes" CssClass="  text-dark font-monospace  fs-1   fw-bold" >  </asp:Label>
  </div>
</div>
</div>
  <div class="col">
    <div class="card text-dark  mb-3" style="max-width: 18rem;"    >
        <div class="card-header "> <svg class="bi me-2 text-dark " width="20" height="20" role="img" fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#building"></use></svg><asp:Label runat="server" Text="Empresas" CssClass="text-dark font-monospace  fw-bold" ></asp:Label>   </div>

  <div class="card-body mx-auto "> 
      <asp:Label runat="server" ID="lbl_qunt_Empresa" CssClass="  text-dark font-monospace  fs-1   fw-bold" >  </asp:Label>
  </div>
</div>
</div>
  <div class="col">
    <div class="card    mb-3" style="max-width: 18rem;"    >
  <div class="card-header  "><svg class="bi text-dark me-2" width="20" height="20" role="img" fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#mortarboard"></use></svg><asp:Label runat="server" Text="Profissionais" CssClass="text-dark font-monospace  fw-bold" ></asp:Label>   </div>
  <div class="card-body mx-auto "> 
      <asp:Label runat="server" ID="lbl_qunt_Profissionais" CssClass="  text-dark font-monospace  fs-1   fw-bold" >  </asp:Label>
  </div>
</div>
</div>
</div>
  
     
     
</asp:Content>


