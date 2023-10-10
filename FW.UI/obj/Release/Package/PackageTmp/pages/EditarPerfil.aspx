<%@ Page Title="" Language="C#" MasterPageFile="../Default.Master" AutoEventWireup="true" CodeBehind="EditarPerfil.aspx.cs" Inherits="FW.UI.pages.EditarPerfil" %>
<%@ MasterType VirtualPath="../Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row container mx-auto p-md-4 p-2 ">
     
        <div class=" mt-2 mb-4 col-10 float-start text-start ">
            <svg class="bi me-2 " width="30" height="30" fill="currentColor">
                <use href="../Imagens/icones/bootstrap-icons.svg#folder-plus"></use></svg>
            <label class="fs-6   text-uppercase font-monospace pt-1">Editar Perfil</label>
        </div>

        <div class="container-fluid">
            <div class="container-xxl">

                <div class="accordion" id="accordion">
                    <div class="accordion-item">
                        <h2 class="accordion-header m-0" id="headingOne">
                            <button class="accordion-button text-uppercase font-monospace" type="button" data-bs-toggle="collapse"   aria-expanded="true" aria-controls="collapseOne">
                                DADOS DO PERFIL
                            </button>
                        </h2>
                        <div id="collapseOne" class="accordion-collapse collapse show" aria-labelledby="headingOne" data-bs-parent="#accordion">
                            <div class="accordion-body">
                                <asp:Panel runat="server" DefaultButton="btnSalvarDadosPerfil">
                                    <div class="row  g-2">
                                        <div class="mb-2 col-lg-6 form-floating">
                                            <asp:TextBox placeholder="nome" CssClass="form-control" ID="txtNome" runat="server" TabIndex="1" MaxLength="100" />
                                            <label id="lblNome" class="text-secondary small" for="txtNome">Nome</label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="mx-auto small text-truncate" ValidationGroup="dadosperfil" Display="Dynamic" ControlToValidate="txtNome" ErrorMessage="Campo é obrigatório" ForeColor="red" />
                                        </div> <div class="mb-2 col-lg-6 form-floating">
                                            <asp:TextBox placeholder="SobreNome" CssClass="form-control" ID="txtSobrenome" runat="server" TabIndex="2" MaxLength="100" />
                                            <label id="lblSobrenome" class="text-secondary small" for="txtSobrenome">Sobrenome</label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="mx-auto small text-truncate" ValidationGroup="dadosperfil" Display="Dynamic" ControlToValidate="txtSobrenome" ErrorMessage="Campo é obrigatório" ForeColor="red" />
                                        </div>
                                        <div class="mb-2 col-lg-4 form-floating">
                                            <asp:TextBox runat="server"   CssClass="form-control " placeholder="user"  TabIndex="3" ID="txtUser" />
                                            <label class="text-secondary small" for="txtUser">Usuario</label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="mx-auto small text-truncate" ValidationGroup="dadosperfil" Display="Dynamic" ControlToValidate="txtUser" ErrorMessage="Campo é obrigatório" ForeColor="red" />
                                        </div>
                                       
                                        <div class="mb-2 col-lg-4  form-floating">
                                            <asp:TextBox runat="server" CssClass="form-control cpf " placeholder="cpf"  TabIndex="4" ID="txtCPF" MaxLength="15"   />
                                            <label class="text-secondary small" for="txtCPF">CPF</label>

                                        </div>
                                        
                                        <div class="mb-2 form-floating col-sm-6 col-lg-4"   >
                                            <asp:DropDownList runat="server" ID="ddlFormacao" TabIndex="5"    CssClass="form-select">
                                                <asp:ListItem Text="Selecione"  Value="0" />
                                                <asp:ListItem Text="Ensino Médio" Value="Ensino Médio" />
                                                <asp:ListItem Text="Técnico" Value="Técnico" />
                                                <asp:ListItem Text="Graduação" Value="Graduação" />
                                                <asp:ListItem Text="Mestrado" Value="Mestrado" />
                                                <asp:ListItem Text="Doutorado" Value="Doutorado" />
                                                <asp:ListItem Text="Pós Doutorado" Value="Pós Doutorado" />
                                                <asp:ListItem Text="Livre Dôcencia" Value="Livre Dôcencia" />
                                            </asp:DropDownList>
                                            <label for="ddlFormacao" class="">Formação Acadêmica</label>
                                        </div>
                                        <div class="mb-2 form-floating col-sm-6 col-lg-4" >
                                            <asp:TextBox runat="server" CssClass="form-control  phone" ID="txtTelefone" TextMode="Phone" placeholder="telefone" TabIndex="6" MaxLength="15" />
                                            <label for="txtTelefone" class="text-secondary small">Telefone</label>
                                        </div>
                                        <div class="mb-2 form-floating col-sm-6 col-lg-4">
                                            <asp:TextBox runat="server" CssClass="form-control date" ID="txtData" placeholder="date" TabIndex="7" />
                                            <label class="text-secondary small" for="txtData">Data de Nascimento </label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="mx-auto small text-truncate" ValidationGroup="dadosperfil" Display="Dynamic" ControlToValidate="txtData" ErrorMessage="Campo é obrigatório" ForeColor="red" />
                                        </div>
                                        <div class="mb-2 form-floating col-sm-6 col-lg-4">
                                            <asp:DropDownList ID="DDLSexo" runat="server" CssClass="form-select" placeholder="Sexo" TabIndex="8">
                                                <asp:ListItem Value="Masculino" Text="Masculino" />
                                                <asp:ListItem Value="Feminino" Text="Feminino" />
                                            </asp:DropDownList>
                                            <label for="DDLSexo" class="text-secondary small">Sexo</label>
                                        </div>
                                        <div class="mb-3 col-md-12 form-floating">
                                            <asp:TextBox runat="server" CssClass="form-control" placeholder="biografia" ID="txtBiografia" Style="min-height: 50px; max-height: 100px" Height="100" TextMode="MultiLine" TabIndex="8" Width="100%" MaxLength="400" />
                                            <label for="txtBiografia" class="text-secondary small">Biografia Academica </label>
                                        </div>
                                        <asp:Button runat="server"  TabIndex="9" CssClass="  btn mx-auto px-auto col-auto py-2 w-50    btn-outline-customer rounded-2" Text="Salvar"
                                            OnClick="BtnSalvarDadosPerfil_Click" ValidationGroup="dadosperfil" ID="btnSalvarDadosPerfil"></asp:Button>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
