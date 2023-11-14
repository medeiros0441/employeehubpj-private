<%@ Page Title="" Language="C#" MasterPageFile="../Default.Master" AutoEventWireup="true" CodeBehind="EditarRecrutador.aspx.cs" Inherits="FW.UI.pages.EditarRecrutador" %>

<%@ MasterType VirtualPath="../Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row ">
    <div class=" mt-2 mb-4 col-10 float-start text-start ">
            <svg class="bi me-2 " width="30" height="30" fill="currentColor">
                <use href="../Imagens/icones/bootstrap-icons.svg#person"></use></svg>
            <label class="fs-6   text-uppercase font-monospace pt-1 fw-bold">Editar Perfil</label>
        </div>
    <div class="container-fluid">
         <div class="container-xxl">

                <div class="accordion" id="accordion">
             <div class="accordion-item">
    <h2 class="accordion-header m-0" id="headingOne">
      <button class="accordion-button" type="button" data-bs-toggle="collapse" aria-expanded="true" >
         DADOS DO PERFIL
      </button>
    </h2>
    <div id="collapseOne" class="accordion-collapse collapse show" aria-labelledby="headingOne" data-bs-parent="#accordion">
        <div class="accordion-body">
                                <asp:Panel runat="server" DefaultButton="btnSalvarDadosPerfil">
                                    <div class="row  g-2">

                                              <div class="mb-2 col-lg-6 form-floating">
                                            <asp:TextBox placeholder="nome" CssClass="form-control"   ID="txtNome" runat="server" TabIndex="3" MaxLength="100" />
                                            <label id="lblNome" class="text-secondary small" for="txtNome">Nome</label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="mx-auto small text-truncate" ValidationGroup="dadosperfil" Display="Dynamic" ControlToValidate="txtNome" ErrorMessage="Campo é obrigatório" ForeColor="red" />

                                        </div>
                                         <div class="mb-2 col-lg-6 form-floating">
                                            <asp:TextBox placeholder="SobreNome" CssClass="form-control" ID="txtSobrenome" runat="server" TabIndex="2" MaxLength="100" />
                                            <label id="lblSobrenome" class="text-secondary small" for="txtSobrenome">Sobrenome</label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="mx-auto small text-truncate" ValidationGroup="dadosperfil" Display="Dynamic" ControlToValidate="txtSobrenome" ErrorMessage="Campo é obrigatório" ForeColor="red" />
                                        </div>
                                        <div class="mb-2 col-lg-4 col-md-6 form-floating">
                                            <asp:TextBox runat="server"   CssClass="form-control USER" placeholder="user" ID="txtUser" />
                                            <label class="text-secondary small" for="txtUser">Usuario</label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="mx-auto small text-truncate" ValidationGroup="dadosperfil" Display="Dynamic" ControlToValidate="txtUser" ErrorMessage="Campo é obrigatório" ForeColor="red" />
                                        </div>
                                       
                                        <div class="mb-2 col-lg-4 col-sm-6 form-floating">
                                            <asp:TextBox runat="server" CssClass="form-control cpf " placeholder="cpf" ID="txtCPF" MaxLength="15"   />
                                            <label class="text-secondary small" for="txtCPF">CPF</label>

                                        </div>
                                         
                                        <div class="mb-2 form-floating col-sm-6 col-lg-4">
                                            <asp:TextBox runat="server" CssClass="form-control  phone" ID="txtTelefone" TextMode="Phone" placeholder="telefone" TabIndex="6" MaxLength="15" />
                                            <label for="txtTelefone" class="text-secondary small">Telefone</label>
                                        </div>
                                        <div class="mb-2 form-floating col-sm-6 col-lg-4">
                                            <asp:TextBox runat="server" CssClass="form-control date" ID="txtData" placeholder="date" TabIndex="4" />
                                            <label class="text-secondary small" for="txtData">Data de Nascimento </label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="mx-auto small text-truncate" ValidationGroup="dadosperfil" Display="Dynamic" ControlToValidate="txtData" ErrorMessage="Campo é obrigatório" ForeColor="red" />
                                        </div>
                                        <div class="mb-2 form-floating col-sm-6 col-lg-4">
                                            <asp:DropDownList ID="DDLSexo" runat="server" CssClass="form-select" placeholder="Sexo" TabIndex="7">
                                                <asp:ListItem Value="Masculino" Text="Masculino" />
                                                <asp:ListItem Value="Feminino" Text="Feminino" />
                                            </asp:DropDownList>
                                            <label for="DDLSexo" class="text-secondary small">Sexo</label>
                                        </div>

                                        <div class="mb-3 col-md-12 form-floating">
                                            <asp:TextBox runat="server" CssClass="form-control" placeholder="biografia" ID="txtBiografia" spellcheck="true" Style="min-height: 50px; max-height: 100px" Height="100" TextMode="MultiLine" TabIndex="6" Width="100%" MaxLength="5000" />
                                            <label for="txtBiografia" class="text-secondary small">Biografia</label>
                                        </div>

                                        <asp:Button runat="server" CssClass=" btn btn-lg w-100 py-2 mb-2 btn  btn-outline-customer rounded-3" Text="Salvar"
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
