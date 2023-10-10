<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Pesquisa_Lista.aspx.cs" Inherits="FW.UI.Pesquisa_Lista" %>
<%@ Register TagName="RptVagas" TagPrefix="uc" Src="../ascx/RptVagas.ascx" %>
<%@ MasterType VirtualPath="~/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script>

            window.onload = function () {
                open_filtro();
            };

        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
            <uc:RptVagas runat="server" ID="RptVagasControl" />

    <!-- Carrosel Profissionais -->
    <div class="container-xl  card-body  ">
   <div class="d-flex justify-content-between loop-profissionais">
    <div class="my-auto btnAnterior d-none d-inline-flex"  >
      <svg class="bi img-fluid" width="32" height="15" fill="currentColor">
        <use href="../imagens/icones/bootstrap-icons.svg#arrow-left-circle"></use>
      </svg>
    </div>
    <div class="row col flex-nowrap itemContainer"  >
    
     <asp:Repeater ID="rptPro3" runat="server">

      <ItemTemplate>
                  <asp:LinkButton CssClass="border  rounded-3    text-decoration-none  mx-3 col-3   mx-3 text-truncate  col-profissional" runat="server" OnClick="Btn_sessao_Click" ID="Btn_sessao" class="btn btn-secondary"  CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdCliente") %>' >
            <img src="<%# DataBinder.Eval(Container.DataItem, "CaminhoFotoCl").ToString() %>" onerror="this.onerror=null; this.src='Cliente/Foto_Cliente/undraw_resume_folder_re_e0bi.svg'" class="bd-placeholder-img mx-auto  flex-shrink-0 me-3 rounded" width="75" height="75" alt="...">
        <strong class="d-block text-gray-dark  "><%# DataBinder.Eval(Container.DataItem, "PrimeironomeCl") %></strong>
    <p class="pb-3 mb-0 small lh-sm count-text-70  ">
      <%# DataBinder.Eval(Container.DataItem, "BiografiaCl") %>
      </p>
    </asp:LinkButton> 
          
      </ItemTemplate>
    </asp:Repeater>
     </div>
    <div class="btnProximo my-auto d-inline-flex"  >
      <svg class="bi img-fluid" width="15" height="15" fill="currentColor">
        <use href="../imagens/icones/bootstrap-icons.svg#arrow-right-circle"></use>
      </svg>
    </div>
  </div>
</div> 

         <asp:Panel runat="server" ID="pn_result_clientes" Visible="false" class="p-0  container-fluid   px-sm-3    ">
    <div class="  text-dark  my-2 mb-3" >  
        <div class="card-header p-3 ">
            <svg class="bi  me-2  text-dark" width="20" height="20" role="img" fill="currentColor"><use href="../imagens/icones/bootstrap-icons.svg#people"></use></svg>
            <asp:Label runat="server" Text="Clientes" CssClass="text-dark font-monospace  fw-bold" >Clientes</asp:Label>   
      <asp:Label runat="server" ID="lbl_qunt_Clientes" CssClass="  text-dark font-monospace  float-end   fw-bold" >Quant:  </asp:Label> </div>

               
<div  class="    card-body row  p-3 container" >
      
             <asp:Repeater ID="rpt_cliente" runat="server">
            <itemtemplate>
                <asp:LinkButton CssClass="border  rounded-3 mx-sm-3 mx-auto  shadow  col-11   text-decoration-none my-2        col-md-6 col-lg-4 " runat="server" OnClick="Btn_sessao_Click" ID="LinkButton1" class="btn btn-secondary"  CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdCliente") %>' >
        <asp:Image  runat="server" class="bd-placeholder-img mx-auto rounded-circle" onerror="this.onerror=null; this.src='Cliente/Foto_Cliente/undraw_resume_folder_re_e0bi.svg'" width="140" height="140"   ImageUrl='<%# DataBinder.Eval(Container.DataItem, "CaminhoFotoCl").ToString() %>'   role="img"      />
        <h2 class=" font-monospace mx-auto "><%# DataBinder.Eval(Container.DataItem, "PrimeironomeCl") %></h2>
        <p class="cont-text-150 font-monospace mx-auto"> <%# DataBinder.Eval(Container.DataItem, "BiografiaCl") %></p>
    </asp:LinkButton> 

            </itemtemplate>
        </asp:Repeater>
    </div>  


</div>
</asp:Panel>
           

    <!-- Caso naõ tenha result -->
    <asp:Panel runat="server" ID="pn_nenhum_result" Visible="false" class="col-5 mx-auto my-5 ">
            <img src="../imagens/Undraw/undraw_the_world_is_mine_re_j5cr.svg" class="bi  img-fluid me-2 " width="200" height="200" role="img" />
            <label runat="server"  class="text-dark font-monospace  my-5 font-monospace fw-bold" >Nenhum Resultado ao Buscar!</label>    
    </asp:Panel>
  
</asp:Content>
