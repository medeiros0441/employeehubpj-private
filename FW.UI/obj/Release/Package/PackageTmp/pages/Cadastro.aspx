<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="FW.UI.Cadastro" %>
<%@ MasterType VirtualPath="~/Default.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <div class="px-2 modal modal-signin position-static d-block     ">
    <asp:Panel runat="server" ID="PnCadastro" Visible="true">
        <div class="modal-dialog" role="document">
              
            <div class="modal-content shadow-lg p-3 mb-2 bg-body rounded-3 border  ">
                <div class="modal-header py-1">
                    <div class="d-flex align-items-center">
                        <svg class="bi figure-img " width="30" height="30" fill="currentColor">
                            <use href="../imagens/icones/bootstrap-icons.svg#person"></use></svg>
                        <div class=" fs-6 p-2 fw-bold">Cadastro</div>
                    </div>
                </div>

                <div class="modal-body">
                    

                    <asp:Panel runat="server" ID="verificacao">
                        <div class="row" tabindex="-1">
                            <div class="col-12 my-1">
                                <div class="form-floating mb-1">
                                    <asp:TextBox CssClass="form-control" ID="txtNome" runat="server" TabIndex="1" MaxLength="100" />
                                    <label for="txtNome" class="">Nome</label>
                                </div>
                                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" runat="server" CssClass=" text-uppercase ms-3"  Font-Size="Small" ControlToValidate="txtNome" ErrorMessage="Campo Nome é obrigatório" ForeColor="red" />

                            </div>
                            <div class="col-12 my-1">
                                <div class="form-floating mb-1">
                                    <asp:TextBox runat="server" class="form-control " ID="txtSobrenome" TabIndex="2" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"   runat="server" Display="Dynamic" CssClass=" text-uppercase ms-3"  Font-Size="Small" ControlToValidate="txtNome" ErrorMessage="Campo sobre nome é obrigatório" ForeColor="red" />

                                    <label for="txtSobrenome">Sobrenome</label>
                                </div>
                            </div>
                            <div class="col-12 my-1">
                                <div class="form-floating mb-1">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" TabIndex="3" MaxLength="100" />
                                    <label for="txtEmail">Email</label>
                                </div>
                                <asp:RegularExpressionValidator ID="gevEmailValido" runat="server" Display="Dynamic" CssClass=" text-uppercase ms-3"  Font-Size="Small" ControlToValidate="txtEmail" ErrorMessage="O E-mail é inválido!" ForeColor="red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic" CssClass=" text-uppercase ms-3"  Font-Size="Small" ControlToValidate="txtEmail" ErrorMessage="Campo Email é obrigatório" ForeColor="red" />

                            </div>
                            <div class="col-12 my-1">
                                <div class="form-floating mb-1">
                                    <asp:DropDownList ID="DLLTipoUSer" runat="server" CssClass="form-select" TabIndex="4">
                                        <asp:ListItem Text="Selecione uma opção" Selected="false" Value="0" />
                                        <asp:ListItem Value="3" Text="Empresa" />
                                        <asp:ListItem Value="2" Text="Profissional" />
                                    </asp:DropDownList>
                                    <label for="DLLTipoUSer">Tipo de Usuario</label>
                                </div>
                                <asp:RequiredFieldValidator InitialValue="0" Display="Dynamic" CssClass="mx-2 ms-3 small text-uppercase text-truncate" runat="server"  ErrorMessage="Campo é obrigatório" Font-Size="Small"  ControlToValidate="DLLTipoUSer"  ForeColor="Red" />
                            </div>
                        </div>
                        <asp:Button runat="server" ID="BtnInicio" class="w-100 mb-2 btn btn-lg btn-outline-customer rounded-pil my-4" TabIndex="5" OnClick="BtnInicio_Click" Text="Proximo" />
                    </asp:Panel>


                    <asp:Panel runat="server" Visible="false" ID="verificacao2" DefaultButton="BtnMeio">
                        <div class="row">
                            <div class="col-12 my-1">
                                <div class="form-floating mb-1">
                                    <asp:TextBox runat="server" CssClass="form-control USER" ID="txtUser" MaxLength="15" TabIndex="1"   />
                                    <label for="txtUser">Usuario</label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" runat="server" ControlToValidate="txtUser"  CssClass=" text-uppercase ms-3"  Font-Size="Small" ErrorMessage="Campo Usuario é obrigatório" ForeColor="red" />
                                </div>
                            </div>
                            <div class=" col-12 my-my-1">
                                <div class="form-floating mb-1">
                                    <asp:TextBox runat="server" CssClass="form-control date" ID="txtData" TabIndex="2" MaxLength="10"    />
                                    <label for="txtData">Data de Nascimento </label>
                                
                                    <asp:RequiredFieldValidator ID="rfvDataN" runat="server" Display="Dynamic" ControlToValidate="txtData" CssClass=" text-uppercase ms-3"  Font-Size="Small" ErrorMessage="Campo Data é obrigatório" ForeColor="red" />

                                    </div>
                            </div>
                            <div class="col-12 my-1">
                                <div class="form-floating mb-1">

                                    <asp:TextBox runat="server" CssClass="form-control phone" ID="txtTelefone" TabIndex="3" MaxLength="11"  TextMode="Phone"/>
                                    <label for="txtTelefone">Telefone </label>

                                    <asp:RequiredFieldValidator ID="rfvTelefone" runat="server" ControlToValidate="txtTelefone" Display="Dynamic" CssClass=" text-uppercase ms-3"  Font-Size="Small" ErrorMessage="Campo Telefone é obrigatório" ForeColor="red" />
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="form-floating mb-3">


                                    <asp:DropDownList ID="DDLSexo" runat="server" CssClass="form-select " TabIndex="4">
                                        <asp:ListItem Text="Selecione uma opção" Value="Selecione uma opção" />
                                        <asp:ListItem Value="Masculino" Text="Masculino" />
                                        <asp:ListItem Value="Feminino" Text="Feminino" />
                                    </asp:DropDownList>
                                    <label for="DDLSexo">Sexo</label>


                                </div>
                            </div>
                            <div class="modal-body  px-4 py-1">
                                <asp:Button runat="server" ID="BtnVoltar" class="btn btn-sm rounded-1 mb-2  btn-secondary" OnClick="BtnVoltar_Click" CausesValidation="false" TabIndex="6" Text="Voltar" />
                                <asp:Button runat="server" ID="BtnMeio" class=" mb-2 btn btn-md float-end rounded-1 btn-outline-customer" OnClick="BtnMeio_Click" TabIndex="5" Text="Proximo" />
                            </div>
                        </div>

                    </asp:Panel>

                    <asp:Panel runat="server" Visible="false" ID="verificacao3" DefaultButton="BtnFim">

                        <div class="container">

                            <img src="../imagens/undraw/undraw_Security_on_re_e491.svg" width="200" height="200" class="img-fluid mx-auto py-4" />
                            <div class="form-floating mb-1 mt-2">
                                <asp:TextBox runat="server" CssClass="form-control " TextMode="Password" ID="Senha1" TabIndex="1" MaxLength="15" placeholder="senha" />
                                <label for="txtEmailRecuperacao" class="text-secondary small">Insira a senha:</label>
                            </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Senha1" Display="Dynamic" CssClass=" text-uppercase ms-3"  Font-Size="Small" ErrorMessage="Campo Senha é obrigatório" ForeColor="red" />

                            <asp:RegularExpressionValidator ID="valPassword" runat="server" CssClass=" text-uppercase ms-3"  Font-Size="Small" ControlToValidate="Senha1" Display="Dynamic"  ErrorMessage="Senha muito fraca" ForeColor="red" ValidationExpression=".{5}.*" />

                            <div class="form-floating mb-1 mt-2">
                                <asp:TextBox runat="server" TextMode="Password" CssClass="form-control " ID="Senha2" TabIndex="2" placeholder="senha" />
                                <label for="txtEmailRecuperacao" class="text-secondary small">Confirme a senha:</label>

                            </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Senha2" Display="Dynamic" CssClass=" text-uppercase ms-3"  Font-Size="Small" ErrorMessage="Campo Senha é obrigatório" ForeColor="red" />

                            <asp:CompareValidator ID="CompareValidator1" runat="server" CssClass=" text-uppercase ms-3"  Font-Size="Small" ForeColor="Red"  Display="Dynamic" ControlToCompare="Senha1"
                                ControlToValidate="Senha2" ErrorMessage="Senhas não conferem"></asp:CompareValidator>

                            <div class="col-12 mb-4 ">
                                <div class="form-check">
                                    <asp:CheckBox runat="server" ID="cbPolitica" TabIndex="3" />
                                    <label class="form-check-label my-1" id=""><a data-bs-target="#modalTermos" href="Informacoes.aspx" class="link" data-bs-toggle="modal">Aceito</a> A política de privacidade.</label>
                                    <br />
                                    <asp:CheckBox runat="server" ID="cbTermos" TabIndex="4" />
                                    <asp:Label runat="server" CssClass="form-check-label my-1" ID="txtTermos"><a href="Informacoes.aspx" class="link" data-bs-target="#modalTermos" data-bs-toggle="modal" > Aceito</a>  os termos de uso. </asp:Label>
                                </div>

                            </div>
                        </div>
                        <div class="modal-body  px-4 py-1">
                            <asp:Button runat="server" ID="BntVoltar2" CssClass=" btn btn-sm rounded-1 mb-2  btn-secondary" OnClick="BntVoltar2_Click" TabIndex="6" CausesValidation="false" Text="Voltar" />
                            <asp:Button runat="server" ID="BtnFim" CssClass=" mb-2 btn btn-md float-end rounded-1 btn-outline-customer" OnClick="BtnFim_Click" TabIndex="7" CausesValidation="true" Text="Proximo" />

                        </div>

                    </asp:Panel>


                    <asp:Panel runat="server" Visible="false" ID="AutenticacaoEmail" DefaultButton="BtnFinalização">

                        <div class=" container">

                            <img src="../imagens/undraw/undraw_email_campaign_re_m6k5 (1).svg" width="200" height="200" class="img-fluid mx-auto py-4" />

                            <div class="input-group mb-3">
                                <asp:TextBox runat="server" type="text" ID="txtCodigo" CssClass="form-control codigoEmail" placeholder="confirme seu email..." MaxLength="7" aria-label="  Btnrenviar  " />
                                <asp:Button runat="server" class="btn btn-outline-secondary  " ID="Btnrenviar" type="button" OnClick="Btnrenviar_Click" data-bs-toggle="Btnrenviar" Text="Reenviar" />

                            </div>
                        </div>
                        <div class="modal-body  px-4 py-1">
                            <asp:Button runat="server" ID="BtnVoltar3" CssClass="btn btn-sm rounded-1 mb-2  btn-secondary" OnClick="BtnVoltar3_Click" TabIndex="-1" CausesValidation="false" Text="Voltar" />

                            <asp:Button runat="server" ID="BtnFinalização" OnClick="BtnFinalização_Click" CssClass="mb-2 btn btn-md float-end rounded-1 btn-outline-customer" TabIndex="3" Text="Confirmar" />

                        </div>

                    </asp:Panel>

                    <asp:Panel runat="server" Visible="false" ID="painelcadastrado">

                        <div class="row">

                            <img class=" img-fluid" src="../imagens/undraw/undraw_welcome_cats_thqn.svg" width="100" height="100" />

                            <div class="input-group mb-3">
                                <div class="alert alert-success alert-dismissible fade show col-12   my-2 mb-4" role="alert">
                                    <svg class="bi  " width="25" height="25" fill="currentColor">
                                        <use href="../imagens/icones/bootstrap-icons.svg#check-circle-fill "></use></svg>
                                    <asp:Label runat="server" ID="lblcadastrado" CssClass="alert   col-12" Visible="false" />
                                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                                </div>
                            </div>
                        </div>


                    </asp:Panel>

                </div>


                <asp:Panel runat="server" ID="PnbuntonLogin" Visible="true">
                    <div class="modal-footer">
                        <asp:Button runat="server" CssClass="w-100 mb-2 btn btn-md  border-dark rounded-pil my-2" Style="background-color: var(--laranja)" TabIndex="-2" OnClick="BtnLogin_Click" CausesValidation="false" Text="Faça o Login" />

                    </div>
                </asp:Panel>

            </div>
        </div>
    </asp:Panel>
        </div>
</asp:Content>
