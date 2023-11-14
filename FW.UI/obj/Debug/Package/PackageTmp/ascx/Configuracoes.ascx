<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Configuracoes.ascx.cs" Inherits="FW.UI.ascx.Configuracoes" %>




  <div class=" container mx-auto my-3 row justify-content-between"  > 
     <div class="   col-10">
          <svg class="bi me-2" width="30" height="30"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#gear"></use></svg>
                <asp:Label runat="server" CssClass="fs-4  font-monospace   fw-bold ">configurações</asp:Label>
 </div>
     <div class="   text-end   col-2">
         <asp:LinkButton runat="server"    OnClick="Sair_Click"  ID="btnSair" class="sidebar-heading    link-danger " data-bs-toggle="tooltip" data-bs-placement="top" title="Excluir Foto">
               <svg class="bi me-2" width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#person-x"></use></svg>
        </asp:LinkButton>
 </div>
 </div>
        <div class="p-3 list-group w-auto my-4 font-monospace  container mx-auto ">

              <asp:LinkButton runat="server" ID="BtnEditarProfissional"  Visible="false" PostBackUrl="../pages/EditarPerfil.aspx"  CssClass="list-group-item list-group-item-action d-flex gap-3 py-3 d-block "  aria-current="true">
   <svg class="bi   " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#person-lines-fill"></use></svg>
    <div class="d-flex gap-2 w-100 justify-content-between">
      <div>
        <h6 class="mb-0   font-monospace fs-6 my-auto">Editar Perfil</h6>
      </div>
        <svg class="bi my-auto " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#caret-right"></use></svg>
    </div>
  </asp:LinkButton>
  <asp:LinkButton runat="server" ID="BtnEditarRecrutador"   Visible="false" PostBackUrl="../pages/EditarRecrutador.aspx"  CssClass="list-group-item list-group-item-action d-flex gap-3 py-3 d-block "  aria-current="true">
   <svg class="bi   " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#person-lines-fill"></use></svg>
    <div class="d-flex gap-2 w-100 justify-content-between">
      <div>
        <h6 class="mb-0 font-monospace fs-6 my-auto">Editar Recrutador</h6>
      </div>
        <svg class="bi my-auto " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#caret-right"></use></svg>
    </div>
  </asp:LinkButton>

        <asp:LinkButton runat="server" PostBackUrl="../pages/EditarEndereco.aspx"  CssClass="list-group-item list-group-item-action d-flex gap-3 py-3 d-block "  aria-current="true">
   <svg class="bi   " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#geo-alt"></use></svg>
    <div class="d-flex gap-2 w-100 justify-content-between">
      <div>
        <h6 class="mb-0 font-monospace fs-6 my-auto">Editar Endereço</h6>
      </div>
        <svg class="bi my-auto " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#caret-right"></use></svg>
    </div>
  </asp:LinkButton>
        <asp:LinkButton runat="server" PostBackUrl="../pages/EditarRedeSociais.aspx"  CssClass="list-group-item list-group-item-action d-flex gap-3 py-3 d-block "  aria-current="true">
   <svg class="bi   " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#bezier"></use></svg>
    <div class="d-flex gap-2 w-100 justify-content-between">
      <div>
        <h6 class="mb-0 font-monospace fs-6 my-auto">Editar Rede Sociais</h6>
      </div>
        <svg class="bi my-auto " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#caret-right"></use></svg>
    </div>
  </asp:LinkButton>
        <asp:LinkButton runat="server" PostBackUrl="../pages/EditarFoto.aspx"  CssClass="list-group-item list-group-item-action d-flex gap-3 py-3 d-block "  aria-current="true">
   <svg class="bi   " width="25" height="25" fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#camera"></use></svg>
    <div class="d-flex gap-2 w-100 justify-content-between">
      <div>
        <h6 class="mb-0 font-monospace fs-6 my-auto">Editar Foto</h6>
      </div>
        <svg class="bi my-auto " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#caret-right"></use></svg>
    </div>
  </asp:LinkButton>
                  <asp:LinkButton runat="server"  ID="BtnSelectCurriculo" Visible="false"  PostBackUrl="../pages/SelectCurriculoPro.aspx" CssClass="list-group-item list-group-item-action d-flex gap-3 py-3 d-block "  aria-current="true">
 <svg class="bi   " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#download"></use></svg>
  <div class="d-flex gap-2 w-100 justify-content-between">
    <div>
      <h6 class="mb-0 font-monospace fs-6 my-auto">Selecionar Currículo</h6>
    </div>
      <svg class="bi my-auto " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#caret-right"></use></svg>
  </div>
</asp:LinkButton>
        <asp:LinkButton runat="server" ID="BtnEditarEmpresa"   Visible="false" PostBackUrl="../pages/EditarEmpresa.aspx"  CssClass="list-group-item list-group-item-action d-flex gap-3 py-3 d-block "  aria-current="true">
   <svg class="bi   " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#cloud-upload"></use></svg>
    <div class="d-flex gap-2 w-100 justify-content-between">
      <div>
        <h6 class="mb-0 font-monospace fs-6 my-auto">Editar Empresa</h6>
      </div>
        <svg class="bi my-auto " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#caret-right"></use></svg>
    </div>
  </asp:LinkButton>
 
</div>