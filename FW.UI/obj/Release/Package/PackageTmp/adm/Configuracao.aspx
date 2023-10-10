<%@ Page Title="" Language="C#" MasterPageFile="~/adm/DefultADM.Master" AutoEventWireup="true" CodeBehind="Configuracao.aspx.cs" Inherits="FW.UI.adm.Configuracao" %>
<%@ MasterType VirtualPath="~/adm/DefultADM.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
  <div class=" my-3 row justify-content-between"  > 
     <div class="   col-10">
          <svg class="bi me-2" width="30" height="30"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#gear"></use></svg>
                <asp:Label runat="server" CssClass="fs-4  font-monospace   fw-bold ">configurações</asp:Label>
 </div>
     <div class="   text-end   col-2">
         <asp:LinkButton runat="server"    OnClick="Sair_Click"  ID="btnSair" class="sidebar-heading    link-danger      ">
               <svg class="bi me-2" width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#person-x"></use></svg>
        </asp:LinkButton>
 </div>

 </div>
    
    <div class="list-group w-auto my-2 fs-6 ">
  <asp:LinkButton runat="server" PostBackUrl="~/pro/EditarPerfil.aspx"  CssClass="list-group-item list-group-item-action d-flex gap-3 py-3 d-block "  aria-current="true">
   <svg class="bi   " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#person-lines-fill"></use></svg>
    <div class="d-flex gap-2 w-100 justify-content-between">
      <div>
        <h6 class="mb-0   font-monospace fs-6 my-auto">Editar Perfil</h6>
      </div>
        <svg class="bi my-auto " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#caret-right"></use></svg>
    </div>
  </asp:LinkButton>

        <asp:LinkButton runat="server" PostBackUrl="~/pro/EditarEndereco.aspx"  CssClass="list-group-item list-group-item-action d-flex gap-3 py-3 d-block "  aria-current="true">
   <svg class="bi   " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#geo-alt"></use></svg>
    <div class="d-flex gap-2 w-100 justify-content-between">
      <div>
        <h6 class="mb-0   font-monospace fs-6 my-auto  ">Editar Endereço</h6>
      </div>
        <svg class="bi my-auto " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#caret-right"></use></svg>
    </div>
  </asp:LinkButton>

        <asp:LinkButton runat="server" PostBackUrl="~/pro/EditarRedeSociais.aspx"  CssClass="list-group-item list-group-item-action d-flex gap-3 py-3 d-block "  aria-current="true">
   <svg class="bi   " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#bezier"></use></svg>
    <div class="d-flex gap-2 w-100 justify-content-between">
      <div>
        <h6 class="mb-0  font-monospace fs-6 my-auto  ">Editar Rede Sociais</h6>
      </div>
        <svg class="bi my-auto " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#caret-right"></use></svg>
    </div>
  </asp:LinkButton>
        <asp:LinkButton runat="server" PostBackUrl="~/pro/EditarFoto.aspx"  CssClass="list-group-item list-group-item-action d-flex gap-3 py-3 d-block "  aria-current="true">
   <svg class="bi   " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#camera"></use></svg>
    <div class="d-flex gap-2 w-100 justify-content-between">
      <div>
        <h6 class="mb-0 font-monospace fs-6 my-auto ">Editar Foto</h6>
      </div>
        <svg class="bi my-auto " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#caret-right"></use></svg>
    </div>
  </asp:LinkButton>
        <asp:LinkButton runat="server" PostBackUrl="~/pro/EditarCurriculo.aspx"  CssClass="list-group-item list-group-item-action d-flex gap-3 py-3 d-block "  aria-current="true">
   <svg class="bi   " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#cloud-upload"></use></svg>
    <div class="d-flex gap-2 w-100 justify-content-between">
      <div>
        <h6 class="mb-0 font-monospace fs-6 my-auto">Upload Currículo</h6>
      </div>
        <svg class="bi my-auto " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#caret-right"></use></svg>
    </div>
  </asp:LinkButton>
 
</div>
      <div class="row">
          <div class="col-12  text-center text-sm-end">
                                <label class="menu  fs-5 text-uppercase font-monospace"><a>Comunidade</a> </label>
                                <ul class="list-group     mb-1">
                                    <li class=" list-inline ">
                                        <label class="mnA"><a class="mnA text-secondary text-uppercase font-monospace" href="../listprofissionais.aspx">Profissionais</a></label></li>
                                    <li class=" list-inline  ">
                                        <label class="mnA"><a class="mnA text-secondary  text-uppercase font-monospace" href="../listvagas.aspx">Oportunidades</a></label></li>
                                    <li class=" list-inline  ">
                                        <label class="mnA"><a class="mnA text-secondary text-uppercase font-monospace" href="../listaprojetos.aspx">Projetos</a></label></li>
                                    <li class=" list-inline  ">
                                        <label class="mnA"><a class="mnA text-secondary text-uppercase font-monospace" href="../listempresas.aspx">Visualizar Empresas</a></label></li>
                                    <li class=" list-inline  ">
                                        <label class="mnA"><a class="mnA text-secondary text-uppercase font-monospace" href="../Informacoes.aspx">Política & Termos</a></label></li>
                                </ul>
                            </div>
      </div>

</asp:Content>
