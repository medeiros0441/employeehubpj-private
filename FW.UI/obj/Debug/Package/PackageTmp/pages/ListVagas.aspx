<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ListVagas.aspx.cs" Inherits="FW.UI.ListVagasDefult" %>
<%@ Register TagName="RptVagas" TagPrefix="uc" Src="../ascx/RptVagas.ascx" %>
<%@ MasterType VirtualPath="~/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <!-- Caso naõ tenha result -->
   
    <div class="container-xl p-1">
  
                            <div class="  container mx-lg-auto  container-lg mx-auto  collapse-horizontal col-12 my-2   row g-1  " tabindex="-1" id="pn_oportunidade_2">
                                <div  class=" mt-2 mb-3 col-12 mx-auto  container   " >
        <svg class="bi me-2 " width="30" height="30"  fill="currentColor"><use href="../imagens/icones/bootstrap-icons.svg#search"></use></svg>
          <label class="fs-6 font-monospace  fw-bold pt-1">Procurar Oportunidades</label>
       </div>
                                <div class="col-12 col-sm-8 col-md-12 form-floating mb-2  " id="campo_NomeVaga">
                                    <asp:TextBox CssClass="form-control" ID="txtTitulo_buscar" runat="server" TabIndex="1" placeholder="e" MaxLength="100" />
                                    <label id="lblTitulo_buscar" for="txtTitulo_buscar" class="small text-secondary font-monospace">Título</label>
                                </div>
                                <div class="   col-sm-4 col-md-4 form-floating  mb-2" id="campo_TipoRegistro">
                                    <asp:DropDownList ID="dllRegistro_pesquisa" runat="server" CssClass=" form-select-sm form-select text-secondary small" TabIndex="2">
                                        <asp:ListItem Value="0" Text="Selecione" />
                                          <asp:ListItem  Value="Estágio" Text="Estágio" />
                                        <asp:ListItem  Value="CLT"  Text="CLT" />
                                        <asp:ListItem Value="Freelancer"  Text="Freelancer" />
                                        <asp:ListItem   Value="Temporário"  Text="Temporário" />
                                        <asp:ListItem  Value="PJ" Text="PJ" />
                                        <asp:ListItem  Value="Outro" Text="Outro" />
                                    </asp:DropDownList>
                                    <label for="dllRegistro" class="small text-secondary font-monospace ">Tipo de Registro</label>
                                </div>
                                <div class="col-sm-6 col-md-4 form-floating  mb-2  " id="campo_Experiencia">
                                    <asp:DropDownList ID="ddlExperiencia" runat="server" CssClass=" form-select-sm form-select text-secondary small" placeholder="e" TabIndex="3">
                                        <asp:ListItem Value="0" Text="Selecione" />
                                          <asp:ListItem Value="Assistente"  Text="Assistente" />
                                            <asp:ListItem Value="Júnior" Text="Júnior" />
                                            <asp:ListItem  Value="Pleno-sênior" Text="Pleno-sênior" />
                                            <asp:ListItem   Value="Diretor" Text="Diretor" />
                                            <asp:ListItem  Value="Executivo" Text="Executivo" />
                                    </asp:DropDownList>
                                    <label for="ddlExperiencia" class="small text-secondary font-monospace">Nível de Experiência</label>
                                </div>
                                <div class="col-sm-6 col-md-4 form-floating  mb-2 ">
                    <asp:DropDownList ID="DDLTipoVaga" runat="server" placeholder="Tipo de Vaga Presencial/remota" CssClass=" form-select-sm form-select text-secondary small"   TabIndex="2">
                        <asp:ListItem Value="0" Text="Selecione" />
                        <asp:ListItem Text="Presencial" />
                        <asp:ListItem   Text="Remoto" />
                        <asp:ListItem   Text="Híbrido" />
                    </asp:DropDownList>
                    <label for="DDLTipoVaga" class="small text-secondary font-monospace">Tipo de Vaga Presencial/remota</label>

                </div>

                                 
                                        <div class="col-sm-6 form-floating">
                                            <asp:TextBox runat="server" CssClass="form-control   form-control-sm  "   ID="txtUF"  placeholder="UF"     TabIndex="3" /> 
                                            <label for="txtUF" class="text-secondary small">UF</label>
                                        </div>

                                        <div class="col-sm-6   form-floating">
                                            <asp:TextBox runat="server" CssClass="form-control   form-control-sm   "      ID="txtCidade" placeholder="Cidade" TabIndex="6" />
                                            <label for="txtCidade" class="text-secondary small">Cidade</label>
                                        </div>
                                <asp:Button runat="server" UseSubmitBehavior="false"  OnClick="BtnProcurarOportunidade_Click" ID="btnProcurarOportunidade" TabIndex="4" type="button" CausesValidation="false" Text="Buscar" CssClass="btn btn-sm mx-auto col-sm-7 col-10   btn-outline-customer"  />
                            </div>
          
        
      
            <uc:RptVagas runat="server" ID="RptVagasControl" />

          
      </div> 
    
</asp:Content>
