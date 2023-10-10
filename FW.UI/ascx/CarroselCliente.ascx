<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CarroselCliente.ascx.cs" Inherits="FW.UI.ascx.CarroselCliente" %>

  <div  class=" mt-4 mb-4 col-12 mx-auto  container   " >
        <svg class="bi me-2 " width="30" height="30"  fill="currentColor"><use href="../imagens/icones/bootstrap-icons.svg#people"></use></svg>
          <label class="fs-6 font-monospace  fw-bold pt-1">Clientes</label>
       </div>
          
    <div class="container-xl  px-3 card-body  ">
   <div class="d-flex justify-content-between loop-profissionais">
    <div class="my-auto btnAnterior d-none d-inline-flex"  >
      <svg class="bi img-fluid" width="20" height="20" fill="currentColor">
        <use href="../imagens/icones/bootstrap-icons.svg#arrow-left-circle"></use>
      </svg>
    </div>
    <div class="row col  mx-auto container  flex-nowrap itemContainer justify-content-center align-items-center "  >
    
   <asp:Repeater ID="rptCliente" runat="server">
    <ItemTemplate>
        <asp:LinkButton CssClass="border rounded-3 text-decoration-none px-auto mx-2     col-profissional col-6 col-md-4 col-lg-3"
            runat="server" OnClick="Btn_sessao_Click" class="btn btn-secondary"
            CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdCliente") %>'>

            <img src="<%# DataBinder.Eval(Container.DataItem, "CaminhoFotoCl").ToString() %>"
                onerror="this.onerror=null; this.src='../Cliente/Foto_Cliente/undraw_resume_folder_re_e0bi.svg'"
                class="bd-placeholder-img mx-auto flex-shrink-0  rounded" width="75" height="75" alt="...">

        
    <strong class="d-block text-gray-dark">
                  <%# Convert.ToInt32(DataBinder.Eval(Container.DataItem, "codigoTU")) == 2 
                    ? DataBinder.Eval(Container.DataItem, "PrimeiroNomeCl")
                    : DataBinder.Eval(Container.DataItem, "NomeFantasiaEp") %>
            </strong>

            <p class="pb-3 mb-0 small lh-sm cont-text-70 text-center">
                <%# DataBinder.Eval(Container.DataItem, "BiografiaCl") %>
            </p>
        </asp:LinkButton>     </ItemTemplate>
</asp:Repeater>

     </div>
    <div class="btnProximo my-auto d-inline-flex"  >
      <svg class="bi img-fluid" width="20" height="20" fill="currentColor">
        <use href="../imagens/icones/bootstrap-icons.svg#arrow-right-circle"></use>
      </svg>
    </div>
  </div>
</div> 