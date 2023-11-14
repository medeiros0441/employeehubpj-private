<%@ Page Title="" Language="C#" MasterPageFile="../Default.Master" AutoEventWireup="true" CodeBehind="CandidaturaPro.aspx.cs" Inherits="FW.UI.CandidaturaPro" %>
<%@ MasterType VirtualPath="../Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row    mx-auto container p-2 p-sm-4   ">
        <div class=" mt-3  mb-2 col-12 float-start text-start ">
      <svg class="bi me-2 " width="30" height="30"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#file-earmark-check"></use></svg>
        <label class="fs-6 font-monospace  fw-bold pt-1">Candidatura</label>
     </div>
         <asp:Panel runat="server" ID="PnList" CssClass="p-0 m-0">
        <table class="table row p-0 m-0 container table-responsive table-sm  table-hover table-borderless  font-monospace">
          <thead>
            <tr class="d-flex row">
              <th scope="col" class="col  text-start" >Oportunidade</th>
              <th scope="col" class="col text-truncate text-end">Empresa</th>
              <th scope="col" class="col-2 text-end">Status</th>
              <th scope="col" class="col-2 text-end">Info</th>
            </tr>
          </thead>
          <tbody>
        <asp:Repeater ID="rptVagaTable"  runat="server">
            <ItemTemplate>
            <tr class="d-flex row">
              <td class="col  text-truncate  text-start">  <%# DataBinder.Eval(Container.DataItem, "NomeVg") %>  </td>
              <td class="col  text-truncate text-end "> <asp:LinkButton  runat="server" ID="Add_sessao"   OnCommand="Add_sessao_Command" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "FkClienteTu") %>'>  <%# DataBinder.Eval(Container.DataItem, "NomeFantasiaEp") %></asp:LinkButton></td>
              <td class="col-2 text-end  text-secondary"> <%# ((bool)DataBinder.Eval(Container.DataItem, "StatusVg")) ? "Ativo" : "Desativado" %>  </td>
              <td class="col-2 text-end   "> <a class=" " href="View_oportunidade.aspx?id_oportunidade=<%# DataBinder.Eval(Container.DataItem, "FkVagaCt") %>"> <svg class="bi me-2 " width="15" height="15"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#eye"></use></svg> </a></td>
            </tr>
            </ItemTemplate>
        </asp:Repeater>
          </tbody>
        </table>
                 </asp:Panel>
      </div>
</asp:Content>
