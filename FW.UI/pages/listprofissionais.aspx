<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ListProfissionais.aspx.cs" Inherits="FW.UI.ListProfissionais" %>
<%@ MasterType VirtualPath="~/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container-xxl  mx-auto container  ">

            <div class="  container mx-auto  collapse-horizontal col-12 my-2   row g-1  " tabindex="-1" id="pn_oportunidade_2">
                                <div  class=" mt-2 mb-3 col-12 mx-auto  container   " >
        <svg class="bi me-2 " width="30" height="30"  fill="currentColor"><use href="../imagens/icones/bootstrap-icons.svg#search"></use></svg>
          <label class="fs-6 font-monospace  fw-bold pt-1">Procurar pessoas</label>
       </div>

                                <div class="mb-2 col-lg-6 form-floating    " id="campo_nome">
                                    <asp:TextBox placeholder="nome" CssClass="form-control" ID="txtNome_pesquisa" runat="server" TabIndex="1" MaxLength="100" />
                                    <label id="lblNome" class="text-secondary small" for="txtNome">Nome</label>
                                </div>

                                <div class="mb-2 col-lg-6 form-floating " id="campo_usuario">
                                    <asp:TextBox runat="server" CssClass="form-control " placeholder="user" ID="txtUsuario_pesuisa" TabIndex="2" />
                                    <label class="text-secondary small" for="txtUser">Usuario</label>
                                </div>
                                <div class="mb-2 form-floating col-sm-6    " id="campo_Formacao">
                                    <asp:DropDownList runat="server" ID="DdlFormacaoAcademica_pesquisa" TabIndex="3" DataTextField="SE" CssClass=" form-select-sm form-select text-dark small">
                                        <asp:ListItem Value="0" Text="Selecione" />
                                        <asp:ListItem Text="Ensino Médio" Value="Ensino Médio" />
                                        <asp:ListItem Text="Técnico" Value="Técnico" />
                                        <asp:ListItem Text="Graduação" Value="Graduação" />
                                        <asp:ListItem Text="Mestrado" Value="Mestrado" />
                                        <asp:ListItem Text="Doutorado" Value="Doutorado" />
                                        <asp:ListItem Text="Pós Doutorado" Value="Pós Doutorado" />
                                        <asp:ListItem Text="Livre Dôcencia" Value="Livre Dôcencia" />
                                    </asp:DropDownList>
                                    <label for="DdlFormacaoAcademica_pesquisa" class="">Formação Acadêmica</label>
                                </div>
                                <div class="mb-2 form-floating col-sm-6   " id="campo_Sexo">
                                    <asp:DropDownList ID="ddlSexo_pesquisa" runat="server" CssClass=" form-select-sm form-select text-dark small" placeholder="Sexo" TabIndex="4">
                                        <asp:ListItem Value="0" Text="indiferente" />
                                        <asp:ListItem Value="Masculino" Text="Masculino" />
                                        <asp:ListItem Value="Feminino" Text="Feminino" />
                                    </asp:DropDownList>
                                    <label for="DDLSexo" class="text-secondary small">Sexo</label>
                                </div>
                 <div class="col-sm-6 form-floating">
                                            <asp:TextBox runat="server" CssClass="form-control   form-control-sm  "   ID="txtUF"  placeholder="UF"     TabIndex="3" /> 
                                            <label for="txtUF" class="text-secondary small">UF</label>
                                        </div>

                                        <div class="col-sm-6   form-floating">
                                            <asp:TextBox runat="server" CssClass="form-control   form-control-sm   "      ID="txtCidade" placeholder="Cidade" TabIndex="6" />
                                            <label for="txtCidade" class="text-secondary small">Cidade</label>
                                        </div>
                                <asp:Button runat="server" UseSubmitBehavior="false"  type="button" ID="Btn_buscarCliente"  CausesValidation="false" Text="Buscar" CssClass="btn btn-sm mx-auto col-sm-7 col-10   btn-outline-customer" TabIndex="5" OnClick="Btn_buscarCliente_Click" />


    </div>


 
               
<div  class="    card-body row  " >
      
             <asp:Repeater ID="rpt_cliente" runat="server">
            <itemtemplate>
                <asp:LinkButton CssClass="border  rounded-3 mx-sm-3 mx-auto  shadow  col-11   text-decoration-none my-2        col-md-6 col-lg-4 " runat="server"   ID="Btn_sessao" class="btn btn-secondary" 
                    OnClick="Btn_viewCliente_Command" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "IdCliente") %>' >
        <asp:Image  runat="server" class="bd-placeholder-img mx-auto rounded-circle" onerror="this.onerror=null; this.src='../Cliente/Foto_Cliente/undraw_resume_folder_re_e0bi.svg'"  width="140" height="140"   ImageUrl='<%# DataBinder.Eval(Container.DataItem, "CaminhoFotoCl").ToString() %>'   role="img"      />
        <h2 class=" font-monospace mx-auto "><%# DataBinder.Eval(Container.DataItem, "PrimeironomeCl") %></h2>
        <p class="cont-text-150 font-monospace mx-auto"> <%# DataBinder.Eval(Container.DataItem, "BiografiaCl") %></p>
    </asp:LinkButton> 

            </itemtemplate>
        </asp:Repeater>
    </div>  
 
           <div class="d-flex justify-content-between loop-profissionais">
    <div class="my-auto btnAnterior d-none d-inline-flex"  >
      <svg class="bi img-fluid" width="32" height="15" fill="currentColor">
        <use href="../imagens/icones/bootstrap-icons.svg#arrow-left-circle"></use>
      </svg>
    </div>
    <div class="row col flex-nowrap itemContainer"  >
    
     <asp:Repeater ID="rptPro1" visible="false" runat="server">
      <ItemTemplate>
        <div class="mx-3 col-3 text-truncate  col-profissional">
            <img src="<%# DataBinder.Eval(Container.DataItem, "CaminhoFotoCl").ToString() %>"  class="bd-placeholder-img mx-auto  flex-shrink-0 me-3 rounded" width="75" height="75" alt="...">
        <strong class="d-block text-gray-dark  "><%# DataBinder.Eval(Container.DataItem, "PrimeironomeCl") %></strong>
    <p class="pb-3 mb-0 small lh-sm count-text-300  ">
      <%# DataBinder.Eval(Container.DataItem, "BiografiaCl") %>
      </p>
        </div> 
          
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
</asp:Content>
