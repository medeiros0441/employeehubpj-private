<%@ Page Title="" Language="C#" MasterPageFile="../Default.Master" AutoEventWireup="true" CodeBehind="Lista_Oportunidades.aspx.cs" Inherits="FW.UI.pages.Lista_Oportunidades" %>
<%@ MasterType VirtualPath="../Default.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="row">
  <div  class=" mt-2 mb-2 col-12 float-start text-start " >
      <svg class="bi me-2 " width="30" height="30"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#file-earmark-plus"></use></svg>
        <label class="fs-6 font-monospace  fw-bold pt-1">Oportunidades Lista</label>
     </div>
      <div class="table-responsive">
        <table class="table font-monospace  table-sm">
          <thead>
            <tr>
              <th scope="col">Nome</th>
              <th scope="col">Tipo</th>
              <th scope="col">Empresa</th>
              <th scope="col">Ver mais</th>
            </tr>
          </thead>
          <tbody>
              
        <asp:Repeater ID="rptVaga"  runat="server">
            <ItemTemplate>
            <tr>
              <td class="text-start">  <%# DataBinder.Eval(Container.DataItem, "NomeVg") %>  </td>
              <td  class="text-center">  <%# DataBinder.Eval(Container.DataItem, "TipoRegistroVg") %>  </td>
              <td class="text-center"> <asp:LinkButton runat="server" ID="Btn_AddSessao" class="fs-6  text-center   link" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FkClienteTu") %>' OnCommand="Btn_AddSessao_Command"> <svg class="bi me-2 " width="15" height="15"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#eye-fill"></use></svg></asp:LinkButton></td>
              <td  class="text-center"> <a class="fs-6  text-end  link" href="view_oportunidade.aspx?id_oportunidade=<%# DataBinder.Eval(Container.DataItem, "IdVaga") %>"> <svg class="bi me-2 " width="15" height="15"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#eye-fill"></use></svg></a></td>
            </tr>
              
            </ItemTemplate> 
        </asp:Repeater>
          </tbody>
        </table>
      </div>
      </div>
</asp:Content>
