<%@ Page Title="Login" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true"  Async="true" CodeBehind="Autenticacao.aspx.cs" Inherits="FW.UI.Autenticacao" %>
<%@ MasterType VirtualPath="~/Default.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    
    <script src="Scripts/google_autenticacao.js"></script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div class="px-sm-2 p-4 my-5 modal modal-signin position-static d-block       ">
        <div class="modal-dialog m-0 m-sm-auto   " role="document">
            <div class="modal-content   p-3 mb-2 bg-body rounded-3 border  ">
             
                <asp:Panel runat="server" ID="PnLogin" DefaultButton="BtnEntrar">
                    <div class="modal-header py-1 px-1">
                        <div class="d-flex align-items-center">
                            <svg class="bi  figure-img" width="30" height="30" fill="currentColor">
                                <use href="../imagens/icones/bootstrap-icons.svg#person"></use></svg>
                            <div class=" fs-6 text-uppercase  p-2 fw-bold">entrar</div>
                        </div>
                    </div>
                    <div class="modal-body ">
                        <div class="col-12 mb-3 form-floating">
                                <asp:TextBox runat="server" class="form-control rounded-1" ID="txtEmail" placeholder="Email" MaxLength="50" TabIndex="1" />
                                <label for="txtEmail" class="text-secondary small">E-mail</label>
                            <asp:RegularExpressionValidator ID="gevEmailValido" runat="server" CssClass="mx-auto ms-3 small" Display="Dynamic" ControlToValidate="txtEmail" ErrorMessage="O E-mail é inválido!" ForeColor="red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="mx-auto  ms-2 small" Display="Dynamic" ControlToValidate="txtEmail" ErrorMessage="Campo Email é obrigatório" ForeColor="red" />
                        </div>
                        <div class="col-12 mb-3 form-floating ">
                                <asp:TextBox runat="server" type="password" class="form-control rounded-1" ID="txtSenha" placeholder="Senha" TabIndex="2" />
                                <label for="txtSenha" class="text-secondary small">Senha</label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass=" mx-auto  ms-2 small " Display="Dynamic" ControlToValidate="txtSenha" ErrorMessage="Campo senha é obrigatório" ForeColor="red" />
                        </div>
                        <asp:Button runat="server" CssClass="w-100 mb-2 btn btn-lg  border-dark rounded-2 my-2" CausesValidation="true" Style="background-color: var(--laranja)" type="submit" OnClick="BtnEntrar_Click" TabIndex="4" ID="BtnEntrar" Text="Entrar" />
                        <asp:LinkButton runat="server" ID="linksenha" OnClick="Linksenha_Click" TabIndex="5" CausesValidation="false" CssClass="text-muted small">Esqueceu a senha?</asp:LinkButton>
                        <hr class="my-3" />
                        <div class="col-12   mx-auto text-center" > 
                       <h2 class=" fw-bold mb-3 col-12 fs-6 text-uppercase ">Faça login com o Google</h2>
                         <asp:LinkButton  ID="GoogleLoginButton" runat="server" class="d-inline-flex"  CausesValidation="false" Text="Login com Google" OnClick="BtnGoogleLogin_Click" >
                             <svg class="bi  figure-img" width="30" height="30" fill="currentColor"><use href="../imagens/icones/bootstrap-icons.svg#google"></use></svg> </asp:LinkButton>    
        
                        </div>
                        <asp:LinkButton TabIndex="8" runat="server" ID="LinkButton1" CausesValidation="false" OnClick="Btncadastrase_Click" CssClass="   link-secondary   float-end rounded-2" Text="Cadastre-se"/>               

                    </div>
                </asp:Panel>


                <asp:Panel runat="server" ID="PnRecuperacaoSennha" Visible="false" DefaultButton="btnAutenticacaoSenha">
                    <div class="modal-header py-1 px-1">
                        <div class="d-flex align-items-center">
                            <svg class="bi  figure-img" width="30" height="30" fill="currentColor"><use href="../imagens/icones/bootstrap-icons.svg#shield-lock"></use></svg>
                            <div class=" fs-6 text-uppercase  p-2 fw-bold">Recuperação de senha </div>
                        </div>
                    </div>
                    <div class="modal-body p-3 pt-0">
                        <asp:Panel runat="server" ID="PnTextBoxEmail" Visible="false">
                            <img src="../imagens/undraw/undraw_email_campaign_re_m6k5 (1).svg" width="300" height="300" class="img-fluid mx-auto my-4" />
                            <label class="text-black  fs-4 font-monospace">Enviaremos um codigo de autenticação em seu E-mail</label>

                            <div class="col-lg-12 mx-auto mb-2">
                                <div class="form-floating mb-1 mt-1">
                                    <asp:TextBox runat="server" type="email" CssClass="form-control rounded-1" ID="txtEmailRecuperacao" TabIndex="1" MaxLength="50" placeholder="Email" />
                                    <label for="txtEmailRecuperacao" class="text-secondary small">E-mail</label>
                                </div>

                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" CssClass="  ms-3 small" ControlToValidate="txtEmailRecuperacao" ErrorMessage="O E-mail é inválido!" ForeColor="red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="  ms-3 small " Display="Dynamic" ControlToValidate="txtEmailRecuperacao" ErrorMessage="Campo Email é obrigatório" ForeColor="red" />

                            </div>
                            <div class="modal-body  px-4  mt-3 py-1">
                                <asp:Button runat="server" ID="btnVoltar" OnClick="BtnVoltar_Click" CssClass="btn btn-sm rounded-1 mb-2  btn-secondary" CausesValidation="false" TabIndex="3" Text="Voltar" />
                                <asp:Button ID="btnAutenticacaoSenha" OnClick="BtnAutenticacaoSenha_Click" runat="server" class="  mb-2 btn btn-md float-end rounded-1 btn-outline-customer" CausesValidation="true" TabIndex="2" Text="Enviar E-mail" />
                            
                            </div>

                        </asp:Panel>


                        <asp:Panel runat="server" ID="PnFinalizacao" Visible="false" DefaultButton="BtnFinalização">
                            <img src="../imagens/undraw/undraw_mailbox_re_dvds.svg" width="300" height="300" class="img-fluid mx-auto my-4" />

                            <div class="input-group mb-3">
                                <asp:TextBox runat="server" type="text" ID="txtCodigo" CssClass="form-control codigoEmail" placeholder="confirme seu email..." MaxLength="7" aria-label="Btnrenviar" TabIndex="1" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" CssClass=" small ms-3 " Display="Dynamic" ControlToValidate="txtCodigo" ErrorMessage="O campo é obrigatório" ForeColor="red" />

                                <asp:Button runat="server" class="btn btn-outline-secondary" ID="Btnrenviar" OnClick="Btnrenviar_Click" data-bs-toggle="Btnrenviar" CausesValidation="false" TabIndex="3" Text="Reenviar" />

                            </div>
                            <div class="modal-body  px-4 py-1">
                                <asp:Button runat="server" ID="BtnVoltar2" CssClass="btn btn-sm rounded-3 mb-2  btn-secondary" OnClick="BtnVoltar2_Click" TabIndex="4" CausesValidation="false" Text="Voltar" />

                                <asp:Button runat="server" ID="BtnFinalização" OnClick="BtnVerificandoCodigoEmail_Click" CssClass=" mb-2 btn btn-md float-end rounded-3 btn-outline-customer" TabIndex="2" Text="Confirmar" />

                            </div>
                        </asp:Panel>

                        <asp:Panel runat="server" ID="PnConfSenha" Visible="false" DefaultButton="BtnFinalizacao">
                            <img src="../imagens/Undraw/undraw_mail_sent_re_0ofv.svg" width="200" height="200" class="img-fluid mx-auto my-4" />
                            <div class="form-floating mb-3 mt-2">
                                <asp:TextBox runat="server" CssClass="form-control rounded-2" TextMode="Password" ID="Senha1" TabIndex="1" MaxLength="15" placeholder="senha" />
                                <label for="txtEmailRecuperacao" class="text-secondary small">Nova senha:</label>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass=" small ms-3 " Display="Dynamic" ControlToValidate="Senha2" ErrorMessage="O campo é obrigatório" ForeColor="red" />

                                <asp:RegularExpressionValidator ID="valPassword" runat="server" CssClass="mb-2 ms-3" ControlToValidate="Senha1" Display="Dynamic" ErrorMessage="Senha muito fraca" ForeColor="red" ValidationExpression=".{5}.*" />
                            </div>
                            <div class="form-floating mb-3 mt-2">
                                <asp:TextBox runat="server" TextMode="Password" CssClass="form-control rounded-2" ID="Senha2" TabIndex="1" placeholder="senha" />
                                <label for="txtEmailRecuperacao" class="text-secondary small">Confirme a nova senha:</label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass=" small " Display="Dynamic" ControlToValidate="Senha2" ErrorMessage="O campo é obrigatório" ForeColor="red" />
                                <asp:CompareValidator ID="CompareValidator1" runat="server" CssClass="mb-2" ForeColor="Red" ControlToCompare="Senha1" Display="Dynamic"
                                    ControlToValidate="Senha2" ErrorMessage="Senhas não conferem"></asp:CompareValidator>
                            </div>
                            <div class="modal-body  px-4 py-1 d-grid">
                                <asp:Button runat="server" ID="BtnFinalizacao" OnClick="BtnFinalizacao_Click" CssClass=" mb-2 btn btn-md    rounded-1 btn-outline-customer" TabIndex="2" Text="Confirmar" />

                            </div>

                        </asp:Panel>
                        <asp:Panel runat="server" ID="PnConfirmado" Visible="false" DefaultButton="btnLogin">
                            <img src="../imagens/Undraw/undraw_confirmed_re_sef7.svg" width="300" height="300" class="img-fluid mx-auto my-4" />
                            <label class="text-black mb-3 fs-4 font-monospace">Tudo Certo! Senha Alterada.</label>
                            <div class="modal-body  px-4 py-1 d-grid">
                                <asp:Button runat="server" ID="BtnLogin" OnClick="BtnLogin_Click" CssClass=" mb-2 btn btn-md    rounded-1    border-dark" Style="background-color: var(--laranja)" TabIndex="2" Text="Faça o Login" />
                            </div>
                        </asp:Panel>

                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>



</asp:Content>
