<%@ Page Title="" Language="C#" MasterPageFile="~/empr/Default.Master" AutoEventWireup="true" CodeBehind="EditarEndereco.aspx.cs" Inherits="FW.UI.empr.EditarEndereco" %>
<%@ MasterType VirtualPath="~/empr/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row ">
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
          ENDEREÇO
                            </button>
                        </h2>
                       <div id="collapseOne" class="accordion-collapse collapse show" aria-labelledby="headingOne" data-bs-parent="#accordion">
                            <div class="accordion-body">
                                <asp:Panel runat="server" DefaultButton="btnSalvarEndereco">
                                    <div class="row g-2">

                                         <div class=" col-sm-5 col-md-12 form-floating">
                                            <asp:TextBox runat="server" CssClass="form-control txtCEP cep" ID="txtCEP" placeholder="CEP" MaxLength="10" TabIndex="3" />
                                            <label for="txtCEP" class="text-secondary small">CEP</label>
                                            <asp:RequiredFieldValidator ID="rfvCep" runat="server" CssClass="mx-auto small" Display="Dynamic" ValidationGroup="Validacaoendereco" ControlToValidate="txtCEP" ErrorMessage="Campo é obrigatório" ForeColor="red" />
                                        </div>
                                        
                                        <div class="col-sm-9 form-floating ">
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtEndereco" MaxLength="100" placeholder="rua" TabIndex="1" />
                                            <label for="txtEndereco" class="text-secondary small">Logradouro </label>
                                            <asp:RequiredFieldValidator ID="rfvEndereco" runat="server" CssClass="mx-auto small text-truncate" ValidationGroup="Validacaoendereco" Display="Dynamic" ControlToValidate="txtEndereco" ErrorMessage="Campo é obrigatório" ForeColor="red" />
                                        </div>


                                        <div class="col-sm-3 col-md-3 form-floating text-truncate">
                                            <asp:TextBox runat="server" CssClass="form-control " ID="txtNumero" placeholder="num" MaxLength="5"   TabIndex="2" />
                                            <label for="txtNumero" class="text-secondary small">Número</label>
                                            <asp:RequiredFieldValidator ID="rfvNum" runat="server" CssClass="mx-auto small  " ValidationGroup="Validacaoendereco" Display="Dynamic" ControlToValidate="txtNumero" ErrorMessage="Campo é obrigatório" ForeColor="red" />
                                        </div>
                                          <div class=" col-sm-5 col-md-8 form-floating">
                                            <asp:TextBox runat="server" CssClass="form-control " ID="txtcomplemento" placeholder="complemento" MaxLength="10" TabIndex="3" />
                                            <label for="txtcomplemento" class="text-secondary small">Complemento</label>
                                        </div>

                                        
                                        <div class="col-sm-5 col-md-4 form-floating">
                                            <asp:TextBox runat="server" CssClass="form-control txtUF "   ID="txtUF"  placeholder="UF"      TabIndex="3" /> 
                                            <label for="txtUF" class="text-secondary small">Estado</label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="mx-auto small"  ValidationGroup="Validacaoendereco" Display="Dynamic" ControlToValidate="txtUF" ErrorMessage="Campo é obrigatório" ForeColor="red" />
                                        </div>

                                        <div class="col-sm-6 form-floating">
                                            <asp:TextBox runat="server" CssClass="form-control txtBairro   " TabIndex="5" placeholder="Bairro" ID="txtBairro" />
                                            <label for="txtBairro" class="text-secondary small">Bairro</label>
                                            <asp:RequiredFieldValidator ID="rfvBairro" runat="server" CssClass="mx-auto small"  ValidationGroup="Validacaoendereco" Display="Dynamic" ControlToValidate="txtBairro" ErrorMessage="Campo é obrigatório" ForeColor="red" />
                                        </div>
                                        <div class="col-sm-6 form-floating">
                                            <asp:TextBox runat="server" CssClass="form-control    "      ID="txtCidade" placeholder="Cidade" TabIndex="6" />
                                            <label for="txtCidade" class="text-secondary small">Cidade</label>
                                        </div>
                                        <asp:Button runat="server" CssClass=" btn btn-lg w-100 py-2 mb-2 btn  btn-outline-customer rounded-3"  TabIndex="8" ValidationGroup="Validacaoendereco" ID="btnSalvarEndereco" OnClick="BtnSalvarEndereco_Click" CausesValidation="true" Text="Salvar" EnableViewState="False"  ></asp:Button>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
        </div>
        </div>
    </div>
    </div>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
        <script>
            function buscarEndereco(cep) {
                $.ajax({
                    url: `https://viacep.com.br/ws/${cep}/json/`,
                    type: 'GET',
                    dataType: 'json',
                    success: function (data) {
                        if (!data.erro) {
                            var uf = data.uf;
                            var cidade = data.localidade;
                            var bairro = data.bairro;
                            var logradouro = data.logradouro;

                            // Obter as referências aos campos txtUF e txtCidade
                            var txtEndereco = document.getElementById('<%= txtEndereco.ClientID %>');
                            var txtUF = document.getElementById('<%= txtUF.ClientID %>');
                            var txtBairro = document.getElementById('<%= txtBairro.ClientID %>');
                            var txtCidade = document.getElementById('<%= txtCidade.ClientID %>');

                            // Definir o valor dos campos txtUF e txtCidade
                            txtEndereco.value = logradouro;
                            txtUF.value = uf;
                            txtBairro.value = bairro;
                            txtCidade.value = cidade;
                        } else {
                         alerta("Alerta","CEP não encontrado");
                        }
                    } 
                });
            }

            // Função para executar a busca do endereço ao inserir um valor no campo txtCEP
            function executarBuscaAutomatica() {
                var cep = document.getElementById('<%= txtCEP.ClientID %>');
                buscarEndereco(cep.value);
            }

            $(document).ready(function () {
                // Associar o evento input do campo txtCEP à função executarBuscaAutomatica()
                $(".txtCEP").on("input", executarBuscaAutomatica);
            });
        </script>
</asp:Content>
