<%@ Page Title="" Language="C#" MasterPageFile="../Default.Master" AutoEventWireup="true" CodeBehind="AddExperiencia.aspx.cs" Inherits="FW.UI.pages.AddExperiência" %>
<%@ MasterType VirtualPath="../Default.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row  container mx-auto  ">

        <div class=" mt-2 mb-4 col-10 float-start text-start ">
            <svg class="bi me-2 " width="30" height="30" fill="currentColor">
                <use href="../Imagens/icones/bootstrap-icons.svg#folder-plus"></use></svg>
            <label class="fs-6 font-monospace   fw-bold pt-1">Experiência Profissional</label>
        </div>

        <div class=" mt-2 mb-4 col-2  float-end text-end ">
            <asp:LinkButton runat="server" ID="AbrirFormulario" OnClick="AbrirFormulario_Click" Visible="true"> 
      <svg class="bi me-2 " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#node-plus"></use></svg>
            </asp:LinkButton>
            <asp:LinkButton runat="server" ID="AbrirList" OnClick="AbrirList_Click" Visible="false"> 
      <svg class="bi me-2 " width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#node-minus"></use></svg>
            </asp:LinkButton>
        </div>

         

        <asp:Panel runat="server" ID="PnList">
            <table class="table">
                <thead>
                    <tr>
                        <th scope="col" class="col-10 ">Nome Experiência</th>
                        <th scope="col" class="col-2 text-end">Editar</th>
                    </tr>
                </thead>
                <tbody>

                    <asp:Repeater ID="RptListaExperiencia" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="text-start">
                                    <asp:Label runat="server" ID="txtNomeCargo"><%# DataBinder.Eval(Container.DataItem, "NomeCargoEx") %></asp:Label></td>
                                <td class="text-end"><asp:LinkButton runat="server" OnClick="LkEditar_Click"   CommandArgument='<%# Eval( "IdExperiencia") %>'  id="LkEditar" >
                                    <svg class="bi me-2 " width="15" height="15" fill="currentColor">
                                        <use href="../Imagens/icones/bootstrap-icons.svg#pencil-square"></use></svg>
                                </asp:LinkButton></td>
                            </tr>

                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>


        </asp:Panel>
        <asp:Panel runat="server" ID="PnFormulario">
            <div class="row col-12 g-1" tabindex="-1">
                <div class="col-12 row g-1">

                    <div class="col-sm-6 form-floating">
                        <asp:TextBox runat="server" Class="form-control" placeholder="txtCargo" ID="txtCargo" TabIndex="1" />
                        <label for="txtCargo" class="small text-secondary text-uppercase font-monospace">Cargo</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="mx-auto small text-truncate" ValidationGroup="PnFormulario" Display="Dynamic" ControlToValidate="txtCargo" ErrorMessage="Campo é obrigatório" ForeColor="red" />

                    </div>

                    <div class="col-sm-6 form-floating">
                        <asp:TextBox runat="server" CssClass="form-control" placeholder="txtEmpresa" TabIndex="2" ID="txtEmpresa" />
                        <label for="txtEmpresa" class="small text-secondary text-uppercase font-monospace">Nome da Empresa</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="mx-auto small text-truncate" ValidationGroup="PnFormulario" Display="Dynamic" ControlToValidate="txtEmpresa" ErrorMessage="Campo é obrigatório" ForeColor="red" />
                    </div>
                    <div class="col-md-6 form-floating ">
                        <asp:DropDownList runat="server" CssClass="  text-secondary form-select" ID="ddlTipoCa" TabIndex="3">
                            <asp:ListItem Selected="false" Value="1" Text="Selecione uma opção"></asp:ListItem>
                            <asp:ListItem Text="CLT" Value="CLT"></asp:ListItem>
                            <asp:ListItem Text="Freelancer" Value="Freelancer"></asp:ListItem>
                            <asp:ListItem Text="Temporário" Value="Temporário"></asp:ListItem>
                            <asp:ListItem Text="PJ" Value="PJ"></asp:ListItem>
                        </asp:DropDownList>
                        <label for="ddlTipoCa" class="text-secondary">Tipo de Contratação</label>
                    </div>
                     
                    <div class="col-md-3 col-sm-6 form-floating ">

                        <asp:TextBox runat="server" placeholder="txtDataInicio" CssClass="form-control mes" MaxLength="7" ID="txtDataInicio" TabIndex="4" />
                        <label class="small text-secondary text-uppercase font-monospace" for="txtDataInicio">Iniciou Mes/Ano</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="mx-auto small text-truncate" ValidationGroup="PnFormulario" Display="Dynamic" ControlToValidate="txtDataInicio" ErrorMessage="Campo é obrigatório" ForeColor="red" />

                    </div>
                    <div class=" col-sm-6 col-md-3  form-floating">
                        <asp:TextBox runat="server" placeholder="txtDataFinal" CssClass="form-control mes" ID="txtDataFinal" MaxLength="7" TabIndex="5" />
                        <label class="small text-secondary text-uppercase font-monospace" for="txtDataFinal">Finalizou Mes/Ano</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="mx-auto small text-truncate" ValidationGroup="PnFormulario" Display="Dynamic" ControlToValidate="txtDataFinal" ErrorMessage="Campo é obrigatório" ForeColor="red" />

                    </div>



                    <div class="col-sm-12 form-floating">


                        <asp:TextBox runat="server" placeholder="txtDescricao" spellcheck="true" Class="form-control corretor"  ID="txtDescricao" TabIndex="6" Height="200" TextMode="MultiLine" />

                        <label for="txtDescricao" class="small text-secondary text-uppercase font-monospace">Descrição </label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="mx-auto small text-truncate"
                            ValidationGroup="PnFormulario" Display="Dynamic" ControlToValidate="txtDescricao" ErrorMessage="Campo é obrigatório" ForeColor="red" />


                    </div>
                </div>
            </div>
        </asp:Panel>

        <div class=" col-lg-12 my-4   ">
            <asp:Panel runat="server" ID="PlEditar" Visible="false">

                <asp:Button runat="server" CssClass="btn  btn-sm float-start   btn-secondary order-1 ms-auto " OnClick="BtnExcluir_Click" TabIndex="8" ID="btnExcluir" Text="Excluir" />
                <asp:Button runat="server" CssClass="btn  btm-md float-end  btn-outline-customer  order-1 ms-auto   " ValidationGroup="PnFormulario" OnClick="BtnSalvar_Click" TabIndex="7" ID="btnSalvar" Text="Salvar" />
            </asp:Panel>
            <asp:Panel runat="server" ID="PlCadastrar" Visible="false">
                <asp:Button runat="server" CssClass="btn  btn-sm float-start    btn-secondary  order-1 ms-auto " OnClick="BtnCancelar_Click" TabIndex="8" ID="btnCancelar" Text="Cancelar" />
                <asp:Button runat="server" CssClass="btn btn-outline-customer ms-auto    order-2 btm-md float-end  btn-outline-customer" ValidationGroup="PnFormulario" ID="Cadastrar" Text="Cadastrar" TabIndex="7" OnClick="Cadastrar_Click" />
            </asp:Panel>

        </div>
    </div>





</asp:Content>
