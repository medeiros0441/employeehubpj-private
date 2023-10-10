<%@ Page Title="" Language="C#" MasterPageFile="../Default.Master" AutoEventWireup="true" CodeBehind="AddCertificados.aspx.cs" Inherits="FW.UI.pages.AddCertificados" %>
<%@ MasterType VirtualPath="../Default.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                         <div class="row container mx-auto  "  >      
    <div  class=" mt-2 mb-4 col-10 float-start text-start " >
      <svg class="bi me-2 " width="30" height="30"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#mortarboard"></use></svg>
        <label class="fs-6 font-monospace  fw-bold  pt-1">Formação Profissional</label>
     </div>
    
    <div  class=" mt-2 mb-4 col-2  float-end text-end " >
        <asp:LinkButton  runat="server" ID="AbriForm" OnClick="AbriForm_Click" Visible="true" > 
      <svg class="bi me-2 " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#node-plus"></use></svg>
     </asp:LinkButton> 
        <asp:LinkButton  runat="server" ID="AbrirList" OnClick="AbrirList_Click" Visible="false" > 
      <svg class="bi me-2 " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#node-minus"></use></svg>
     </asp:LinkButton></div>
      
 

    <asp:Panel runat="server" ID="PnList">
    <table class="table">
  <thead>
    <tr>
      <th scope="col" class="col-10 ">Nome do curso</th>
      <th scope="col" class="col-2 text-end">Editar</th>
    </tr>
  </thead>
  <tbody>
      
         <asp:Repeater ID="RptListaCertificado"  runat="server">
            <ItemTemplate>  
    <tr> 
      <td class="text-start"><asp:Label runat="server"   ID="txtNomeCertificado"><%# DataBinder.Eval(Container.DataItem, "NomeCursoCf") %></asp:Label></td>
      <td class="text-end" ><asp:LinkButton runat="server"  OnClick="LkEditar_Click"   CommandArgument='<%# Eval("idcertificado") %>'  ID="LkEditar"  >   <svg class="bi me-2 " width="15" height="15"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#pencil-square"></use></svg>    </asp:LinkButton></td>
        </tr>
       
            </ItemTemplate>
        </asp:Repeater>  
  </tbody>
</table>

       
    </asp:Panel>

    <asp:Panel  runat="server" ID="PnFormulario"   Visible="false" >
                         <div class="row col-12 g-1 " tabindex="-4">
            <div class="col-sm-6  form-floating mb-2">
                 
                <asp:TextBox runat="server" Class="form-control" ID="txtCurso" placeholder="namecurso"    TabIndex="1" />
                <label  for="txtCurso" class="small text-secondary text-uppercase font-monospace">Nome do Curso</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="mx-auto small text-truncate" ValidationGroup="PnFormulario" Display="Dynamic" ControlToValidate="txtCurso" ErrorMessage="Campo é obrigatório" ForeColor="red" />

            </div>

            <div class="col-sm-6 form-floating mb-2">
               
                <asp:TextBox runat="server" CssClass="form-control" TabIndex="2" ID="txtInstituiçao" placeholder="nameinstituicao"  MaxLength="50" />
                  <label  for="txtInstituiçao" class="small text-secondary text-uppercase font-monospace">Nome da Instituição</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="mx-auto small text-truncate" ValidationGroup="PnFormulario" Display="Dynamic" ControlToValidate="txtInstituiçao" ErrorMessage="Campo é obrigatório" ForeColor="red" />

 
            </div>
          <div class=" form-floating col-sm-6 mb-2">
                                <asp:TextBox runat="server" CssClass="form-control  mes" MaxLength="7"  ID="txtDataInicio" placeholder="namecurso"  TabIndex="3" />
               <label for="txtDataInicio" class="small text-secondary text-uppercase font-monospace" >Iniciou Mes/Ano</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="mx-auto small text-truncate" ValidationGroup="PnFormulario" Display="Dynamic" ControlToValidate="txtDataInicio" ErrorMessage="Campo é obrigatório" ForeColor="red" />

          </div>
          <div class=" col-sm-6 form-floating mb-2">
                
                <asp:TextBox runat="server" CssClass="form-control mes" ID="txtDataFinal" placeholder="txtDataFinal"   MaxLength="7" TabIndex="4" />
               <label for="txtDataFinal" class="small text-secondary text-uppercase font-monospace">Finalizou Mes/Ano</label>  
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="mx-auto small text-truncate" ValidationGroup="PnFormulario" Display="Dynamic" ControlToValidate="txtDataFinal" ErrorMessage="Campo é obrigatório" ForeColor="red" />

          </div>
            <div class="col-sm-12 form-floating mb-2">
 
                <asp:TextBox runat="server" Class="form-control"  placeholder="txtDescricaoCurso" ID="txtDescricaoCurso" MaxLength="300"   Height="200"  TabIndex="5" TextMode="MultiLine" />
                <label id="lblDescricao" for="txtDescricaoCurso"  class=" small text-secondary text-uppercase font-monospace">Descrição</label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="mx-auto small text-truncate" ValidationGroup="PnFormulario" Display="Dynamic" ControlToValidate="txtDescricaoCurso" ErrorMessage="Campo é obrigatório" ForeColor="red" />

            </div>
        </div>
        </asp:Panel>


    
    
    <div class=" col-lg-12    ">  
        <asp:Panel  runat="server" ID="PlEditar"  Visible="false" >
          <asp:Button runat="server"  CssClass="btn  btn-sm float-start   btn-secondary order-1 ms-auto"  OnClick="BtnExcluir_Click" TabIndex="8"  ID="btnExcluir"  Text="Excluir" />
         <asp:Button runat="server"  CssClass="btn  btm-md float-end  btn-outline-customer  order-1 ms-auto   " ValidationGroup="PnFormulario"  OnClick="BtnEditar_Click" TabIndex="7" ID="btnSalvar"  Text="Salvar" />
        </asp:Panel>
        <asp:Panel  runat="server" ID="PlCadastrar" Visible="false" >
         <asp:Button runat="server"  CssClass="btn  btn-sm float-start    btn-secondary   order-1 ms-auto "  OnClick="BtnCancelar_Click" TabIndex="8"  ID="btnCancelar"  Text="Cancelar" />
         <asp:Button runat="server"  CssClass="btn btn-outline-customer ms-auto    order-2 btm-md float-end  btn-outline-customer" ValidationGroup="PnFormulario" ID="Cadastrar" Text="Cadastrar" TabIndex="7" OnClick="Cadastrar_Click" />
        </asp:Panel>
 
            </div>
    
            </div>

     
    
</asp:Content>
