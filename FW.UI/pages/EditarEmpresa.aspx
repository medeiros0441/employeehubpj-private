<%@ Page Title="" Language="C#" MasterPageFile="../Default.Master" AutoEventWireup="true" CodeBehind="EditarEmpresa.aspx.cs" Inherits="FW.UI.EditarEmpresa" %>

<%@ MasterType VirtualPath="../Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row ">
        <div class=" mt-2 mb-4 col-10 float-start text-start ">
            <svg class="bi me-2 " width="30" height="30" fill="currentColor">
                <use href="../Imagens/icones/bootstrap-icons.svg#folder-plus"></use></svg>
            <label class="fs-6   text-uppercase font-monospace pt-1  fw-bold">Editar Foto</label>
        </div>



        <div class="container-fluid">
            <div class="container-xxl">

                <div class="accordion" id="accordion">

                    <div class="accordion-item">
                        <h2 class="accordion-header m-0" id="headingOne">
                            <button class="accordion-button text-uppercase font-monospace" type="button" data-bs-toggle="collapse" aria-expanded="true" aria-controls="collapseOne">
                                Dados da empresa
                            </button>
                        </h2>

                        <div id="collapseOne" class="accordion-collapse collapse show" aria-labelledby="headingOne" data-bs-parent="#accordion">
                            <div class="accordion-body  ">
                                  <asp:Panel runat="server" DefaultButton="btnSalvarDadosEmpresa" CssClass=" row "  >

                                    <div class="row  g-2">
                                <div class="mb-3 col-md-6 form-floating ">
                                    <asp:TextBox ID="txtCnpj" CssClass=" cnpj form-control" placeholder="date" MaxLength="15"  TabIndex="2"  runat="server" />
                                    <label  for="txtCnpj" class="text-secondary small">CNPJ </label>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="mx-auto small text-truncate" ValidationGroup="dadosempresa" Display="Dynamic" ControlToValidate="txtCnpj" ErrorMessage="Campo é obrigatório" ForeColor="red" />

                                </div>
                                        
                                   <div class="mb-3 col-md-6  form-floating">
                                    <asp:TextBox ID="txtDataAbertura" MaxLength="10" placeholder="date" CssClass=" date form-control" TabIndex="4" runat="server" />
                                    <label for="txtDataAbertura" class="text-secondary small">Data de Abertura</label>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="mx-auto small text-truncate" ValidationGroup="dadosempresa" Display="Dynamic" ControlToValidate="txtDataAbertura" ErrorMessage="Campo é obrigatório" ForeColor="red" />

                                </div>      <div class="mb-3 col-md-6 form-floating">
                                    <asp:TextBox runat="server" CssClass="form-control    " ID="txtRazaoSocial" placeholder="date"  MaxLength="50" TabIndex="1" />
                                    <label for="txtRazaoSocial" class="text-secondary small">Razão Social</label>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="mx-auto small text-truncate" ValidationGroup="dadosempresa" Display="Dynamic" ControlToValidate="txtRazaoSocial" ErrorMessage="Campo é obrigatório" ForeColor="red" />

                                </div>
                                
                                <div class="mb-3 col-md-6 form-floating">
                                    <asp:TextBox runat="server" CssClass="form-control  " ID="txtNomeFantasia" placeholder="date" MaxLength="50" TabIndex="3" />
                                    <label for="txtNomeFantasia" class="text-secondary small">Nome Fantasia</label>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="mx-auto small text-truncate" ValidationGroup="dadosempresa" Display="Dynamic" ControlToValidate="txtNomeFantasia" ErrorMessage="Campo é obrigatório" ForeColor="red" />

                                </div>
                                
                                </div>
                                      <asp:Button runat="server" CssClass=" btn btn-sm col-10  mx-auto  btn-outline-customer rounded-3" TabIndex="5" Text="Salvar"
                                              ValidationGroup="dadosempresa"    OnClick="SalvarDadosEmpresa_Click" ID="btnSalvarDadosEmpresa"></asp:Button>
                                </asp:Panel>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
        
</asp:Content>
