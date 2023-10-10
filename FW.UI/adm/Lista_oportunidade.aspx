<%@ Page Title="" Language="C#" MasterPageFile="~/adm/DefultADM.Master" AutoEventWireup="true" CodeBehind="Lista_oportunidade.aspx.cs" Inherits="FW.UI.adm.Lista_oportunidade" %>
<%@ MasterType VirtualPath="~/adm/DefultADM.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div  class=" row " >
   <div  class=" mt-2 mb-2 col-12 float-start text-start " >
      <svg class="bi me-2 " width="30" height="30"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#columns-gap"></use></svg>
        <label class="fs-6 font-monospace  fw-bold pt-1">Oportunidades</label>
     </div>
    <div class="container-xl p-1">
          
        <asp:Repeater ID="rptVaga1" runat="server">
            <itemtemplate>
                <div class="card my-3  ">
                    <div class="card-header">
                      <%# DataBinder.Eval(Container.DataItem, "Nome_Vaga") %>
                    </div>
                    <div class="card-body">
                      
                        <p class="card-text"><%# DataBinder.Eval(Container.DataItem, "Descricao") %></p>
                        
                    </div>
                    <div class="card-footer text-muted">Publicado :  <%# DataBinder.Eval(Container.DataItem, "Data_Publicacao").ToString() %>
                     <label class="menu ms-2 float-end" >
                         <a class=""  href="VagaProfissional.aspx?id=<%# DataBinder.Eval(Container.DataItem, "ID_Vaga ") %>" style="font-size:10pt;">Ver detalhes</a></label> 
                       
                    </div>
                </div>
            </itemtemplate>
        </asp:Repeater>
        
    </div>
    </div>
    
    <div class="my-3 p-3 bg-body rounded shadow-sm">
    <h6 class="border-bottom pb-2 mb-0">Profissionais Verificado</h6>
   
          
        <asp:Repeater ID="rptPro2"  runat="server">
            <ItemTemplate>
        <div class="d-flex text-muted pt-3">
      <img src="<%# DataBinder.Eval(Container.DataItem, "Url_Foto").ToString().Replace("~", ".") %>"  class="bd-placeholder-img flex-shrink-0 me-2 rounded" width="70" height="70" alt="...">

      <div class="pb-3 mb-0 small lh-sm border-bottom w-100">
        <div class="d-flex justify-content-between">
          <strong class="text-gray-dark"><%# DataBinder.Eval(Container.DataItem, "Nome") %></strong>
          <a href="PerfilPro.aspx?ID_Cliente_Profissional=<%# DataBinder.Eval(Container.DataItem, "idProfissional") %>">Ver Perfil</a>
        </div>
        <span class="d-block"><%# DataBinder.Eval(Container.DataItem, "FormacaoEscolar") %></span>
      </div>
    </div>
                </ItemTemplate>
        </asp:Repeater> 
    <small class="d-block text-end mt-3">
      <a href="#">Ver Tudo</a>
    </small>
  </div>
</asp:Content>
