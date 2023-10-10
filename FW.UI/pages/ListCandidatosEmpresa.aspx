<%@ Page Title="" Language="C#" MasterPageFile="../Default.Master" AutoEventWireup="true" CodeBehind="ListCandidatosEmpresa.aspx.cs" Inherits="FW.UI.pages.ListCandidatosEmpresa" %>
<%@ MasterType VirtualPath="../Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row container mx-auto" > 
           
    <div  class=" mt-2 mb-4 col-10 float-start text-start " >
      <svg class="bi me-2 " width="30" height="30"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#columns-gap"></use></svg>
        <label class="fs-6 font-monospace  fw-bold pt-1">Profissonais</label>
     </div>
        <table class="table  table-responsive     table-sm table-hover table-borderless  font-monospace">
         
            <thead>
            <tr class="row d-flex">
              <th scope="col" class=" col text-start  text-truncate" >Oportunidade</th>
              <th scope="col" class=" col text-start  text-truncate" >Nome Profissional</th>
              <th scope="col" class="col-auto  text-center">Currículo</th>
            </tr>
          </thead>
          <tbody>
              
        <asp:Repeater ID="rptViewCandidatos"   runat="server">
            <ItemTemplate>
            <tr class="row d-flex">
              <td class=" col   text-start  text-truncate"> <a  href="View_oportunidade.aspx?id_oportunidade=<%# DataBinder.Eval(Container.DataItem, "FkVagaCt") %>"><%# DataBinder.Eval(Container.DataItem, "NomeVg") %></a></td>
              <td class=" col text-start  text-truncate"> <asp:LinkButton    runat="server" CommandArgument='<%# Eval("IdCliente") %> '  OnClick="Btn_Add_Valores_Click"><%# DataBinder.Eval(Container.DataItem, "PrimeiroNomeCl") %> </asp:LinkButton></td>
             <td class="  col-auto    text-center" ><asp:LinkButton  runat="server"  CommandArgument='<%# Eval("IdCliente")  + ";" + Eval("FkProfissionalCt") %>'   OnClick="Btn_viewCurriculo_Click" >   <svg class="bi me-2 " width="15" height="15"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#file-pdf"></use></svg>    </asp:LinkButton></td>
            </tr>
              
            </ItemTemplate>
        </asp:Repeater>

            
          </tbody>
        </table>
        </div> 
</asp:Content> 