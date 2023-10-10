<%@ Page Title="" Language="C#" MasterPageFile="../Default.Master" AutoEventWireup="true" CodeBehind="EditarVagas.aspx.cs" Inherits="FW.UI.pages.EditarVagas" %>

<%@ MasterType VirtualPath="../Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     
    <div class="row conatiner mx-auto p-md-4  p-2">

        <div class=" mt-2 mb-4 col-10 float-start text-start ">
            <svg class="bi me-2 " width="30" height="30" fill="currentColor">
                <use href="../Imagens/icones/bootstrap-icons.svg#columns-gap"></use></svg>
            <label class="fs-6 font-monospace  fw-bold pt-1">Oportunidade</label>
        </div>
        
        <div class=" mt-2 mb-4 col-2  float-end text-end ">
            <asp:LinkButton runat="server" ID="AbriForm" OnClick="AbriForm_Click" Visible="true"> 
      <svg class="bi me-2 " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#node-plus"></use></svg>
            </asp:LinkButton>
            <asp:LinkButton runat="server" ID="AbrirList" OnClick="AbrirList_Click" Visible="false"> 
      <svg class="bi me-2 " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#node-minus"></use></svg>
            </asp:LinkButton>
        </div>




        <asp:Panel runat="server" ID="PnList">
            <table class="table  table-responsive   table-sm table-hover table-borderless  font-monospace ">
                <thead>
                    <tr class="d-flex row">
                        <th scope="col" class=" col   text-start  text-truncate  ">Oportunidade</th>
                        <th scope="col" class="col-auto text-center  ">Inscritos</th>
                        <th scope="col" class="col-auto text-center  ">Status</th>
                        <th scope="col" class="col-auto  text-end">Editar</th>
                    </tr>
                </thead>
                <tbody>

                    <asp:Repeater ID="RptListaVaga" runat="server">
                        <ItemTemplate>
                            <tr class="d-flex row">
                                <td class="text-start col  text-truncate"><asp:Label runat="server" ID="Label1"><%# DataBinder.Eval(Container.DataItem, "NomeVg") %></asp:Label></td>
                                <td class="  col-auto mx-1  text-center"><asp:LinkButton runat="server" id="LkViewCandidato"  CommandArgument='<%# Eval( "IdVaga") %>'  OnClick="LkViewCandidato_Click"><svg class="bi me-2 " width="15" height="15" fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#eye"></use></svg></asp:LinkButton></td>
                                <td class="  text-secondary col-auto mx-2  text-center"><asp:Label runat="server" ID="lblvalidade"  Text='<%# Convert.ToBoolean(Eval("StatusVg")) ? "Ativo" : "Desativado" %>'></asp:Label></td>
                                <td class="text-end col-auto mx-1"><asp:LinkButton runat="server"  OnClick="LkEditar_Click" CommandArgument='<%# Eval( "IdVaga") %>' id="LkEditar"  ><svg class="bi me-2 " width="15" height="15" fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#pencil-square"></use></svg></asp:LinkButton></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </asp:Panel>

        <asp:Panel runat="server" ID="pn_Editar_Vagas" Visible="false">
            <div class="row col-12 g-1 " tabindex="-1">
                <div class="col-md-12 form-floating mb-2">

                    <asp:TextBox CssClass="form-control" ID="txtTitulo" runat="server" TabIndex="1" placeholder="e" MaxLength="100" />
                    <label id="lblTitulo" for="txtTitulo" class="small text-secondary font-monospace">Título</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="mx-2 w3-text-red small text-truncate" ValidationGroup="pn_Editar_Vagas" Display="Dynamic" ControlToValidate="txtTitulo" ErrorMessage="Campo é obrigatório" ForeColor="red" />

                </div>
                <div class="col-md-3 form-floating  mb-2 ">
                    <asp:DropDownList ID="DDLTipoContrato" runat="server" CssClass="form-select" placeholder="Tipo de contrato" TabIndex="2">
                        <asp:ListItem Value="0" Text="Selecione" />
                        <asp:ListItem  Value="Estágio" Text="Estágio" />
                        <asp:ListItem  Value="CLT"  Text="CLT" />
                        <asp:ListItem Value="Freelancer"  Text="Freelancer" />
                        <asp:ListItem   Value="Temporário"  Text="Temporário" />
                        <asp:ListItem  Value="PJ" Text="PJ" />
                        <asp:ListItem  Value="Outro" Text="Outro" />
                    </asp:DropDownList>
                    <label for="DDLTipoContrato" class="small text-secondary font-monospace">Tipo de contrato</label>

                    <asp:RequiredFieldValidator InitialValue="0" Display="Dynamic" CssClass="mx-2 small w3-text-red text-truncate" runat="server" ID="RequiredFieldValidator7"
                        ErrorMessage="Campo é obrigatório" ValidationGroup="pn_Editar_Vagas" ControlToValidate="DDLTipoVaga" />
                </div>

                   <div class="col-md-3 form-floating  mb-2 ">
                    <asp:DropDownList ID="DDLTipoVaga" runat="server" placeholder="Tipo de Vaga Presencial/remota" CssClass="form-select"   TabIndex="2">
                        <asp:ListItem Value="0" Text="Selecione" />
                        <asp:ListItem Text="Presencial" />
                        <asp:ListItem   Text="Remoto" />
                        <asp:ListItem   Text="Híbrido" />
                    </asp:DropDownList>
                    <label for="DDLTipoVaga" class="small text-secondary font-monospace">Tipo de Vaga Presencial/remota</label>

                    <asp:RequiredFieldValidator InitialValue="0" Display="Dynamic" CssClass="mx-2 small w3-text-red text-truncate" runat="server" ID="RequiredFieldValidator6"
                        ErrorMessage="Campo é obrigatório" ValidationGroup="pn_Editar_Vagas" ControlToValidate="DDLTipoVaga" />
                </div>
                
                <div class="col-md-3 form-floating  mb-2 ">
                    <asp:DropDownList ID="DDLExperiencia" runat="server"   CssClass="form-select"   TabIndex="2">
                        <asp:ListItem Value="0" Text="Selecione" />
                        <asp:ListItem Value="Assistente"  Text="Assistente" />
                        <asp:ListItem Value="Júnior" Text="Júnior" />
                        <asp:ListItem  Value="Júnior-Pleno" Text="Júnior-Pleno" />
                        <asp:ListItem  Value="Pleno" Text="Pleno" />
                        <asp:ListItem  Value="Sênior" Text="Sênior" />
                        <asp:ListItem  Value="Pleno-sênior" Text="Pleno-sênior" />
                        <asp:ListItem   Value="Diretor" Text="Diretor" />
                        <asp:ListItem  Value="Executivo" Text="Executivo" />
                    </asp:DropDownList>
                    <label for="DDLExperiencia" class="small text-secondary font-monospace">Nível de experiência</label>

                    <asp:RequiredFieldValidator  InitialValue="0" Display="Dynamic" CssClass="mx-2 small w3-text-red text-truncate" runat="server" ID="rfvDLLExperiencia"
                        ErrorMessage="Campo é obrigatório" ValidationGroup="pn_Editar_Vagas" ControlToValidate="DDLExperiencia" />
                </div>
                <div class="col-md-3 form-floating  mb-2 ">
                    <asp:DropDownList ID="DDLStatus" runat="server" CssClass="form-select" placeholder="status" TabIndex="2">
                        <asp:ListItem Value="Ativo" Text="Ativo" />
                        <asp:ListItem Value="Desativado" Text="Desativado" />
                    </asp:DropDownList>
                    <label for="DDLStatus" class="small text-secondary font-monospace">Status de Inscrição</label>

                </div>
                
                <div class=" col-md-4 form-floating  mb-2 ">

                    <asp:DropDownList ID="DDLSexo" runat="server" CssClass="form-select" TabIndex="4">
                        <asp:ListItem Value="0" Text="Selecione" />
                        <asp:ListItem Value="Indiferente" Text="Indiferente" />
                        <asp:ListItem Value="Masculino" Text="Masculino" />
                        <asp:ListItem Value="Feminino" Text="Feminino" />
                    </asp:DropDownList>
                    <label for="DDLSexo" class="small text-secondary font-monospace ">Sexo</label>

                    <asp:RequiredFieldValidator InitialValue="0" Display="Dynamic" CssClass="mx-2 w3-text-red   small text-truncate" runat="server" ID="RequiredFieldValidator3"
                        ErrorMessage="Campo é obrigatório" ValidationGroup="pn_Editar_Vagas" ControlToValidate="DDLSexo" />
                </div>
                <div class="form-floating  mb-2 col-md-4">
                    <asp:DropDownList ID="DDLValidade" runat="server" CssClass="form-select" TabIndex="5">
                        <asp:ListItem Value="0" Text="Selecione" />
                        <asp:ListItem Value="7 Dias" Text="7 Dias" />
                        <asp:ListItem Value="15 Dias" Text="15 Dias" />
                        <asp:ListItem Value="30 Dias" Text="30 Dias" />
                    </asp:DropDownList>
                    <label for="DDLValidade" class="small text-secondary font-monospace ">Válidade</label>

                    <asp:RequiredFieldValidator InitialValue="0" Display="Dynamic" CssClass="mx-2 w3-text-red   small text-truncate" runat="server" ID="RequiredFieldValidator4"
                        ErrorMessage="Campo é obrigatório" ValidationGroup="pn_Editar_Vagas" ControlToValidate="DDLValidade" />
                </div>

                <div class="col-md-12 form-floating  mb-2">
                    <asp:TextBox runat="server" placeholder="e" CssClass=" form-control corretor"   spellcheck="true" ID="txtDescricao" MaxLength="3000" TextMode="MultiLine" TabIndex="6" Height="300" />

                    <label for="txtDescricao" class="small text-secondary font-monospace ">Descrição</label>
                    <asp:RequiredFieldValidator Display="Dynamic" CssClass="mx-2 w3-text-red   small text-truncate" runat="server" ID="RequiredFieldValidator5"
                        ErrorMessage="Campo é obrigatório" ValidationGroup="pn_Editar_Vagas" ControlToValidate="txtDescricao" />
                </div>

            </div>




            <asp:Panel runat="server" ID="PlEditar" Visible="false">
                <div class=" col-lg-12    ">

                    <asp:Button runat="server" CssClass="btn  btn-sm float-start   btn-secondary order-1 ms-auto" OnClick="BtnExcluir_Click" TabIndex="8" ID="btnExcluir" Text="Excluir" />
                    <asp:Button runat="server" CssClass="btn  btm-md float-end  btn-outline-customer  order-1 ms-auto   " ValidationGroup="pn_Editar_Vagas" OnClick="BtnEditar_Click" TabIndex="7" ID="btnSalvar" Text="Salvar" />
                </div>
            </asp:Panel>
            <asp:Panel runat="server" ID="PlCadastrar" Visible="false">
                <div class=" col-lg-12    ">
                    <asp:Button runat="server" CssClass="btn  btn-sm float-start    btn-secondary   order-1 ms-auto " OnClick="BtnCancelar_Click" TabIndex="8" ID="btnCancelar" Text="Cancelar" />
                    <asp:Button runat="server" CssClass="btn btn-outline-customer ms-auto    order-2 btm-md float-end  btn-outline-customer" ValidationGroup="pn_Editar_Vagas" ID="Cadastrar" Text="Cadastrar" TabIndex="7" OnClick="Cadastrar_Click" />
                </div>
            </asp:Panel>

        </asp:Panel>

    </div>




</asp:Content>
