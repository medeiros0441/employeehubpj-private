<%@ Page Title="Google Cadastro" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Users_google.aspx.cs" Inherits="FW.UI.Users_google" %>
<%@ MasterType VirtualPath="~/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="px-sm-2 p-0 modal modal-signin position-static d-block   panel_cadastro     ">
        <div class="modal-dialog m-0 m-sm-auto   " role="document">
            <div class="modal-content   p-3 mb-2 bg-body rounded-3 border  ">

                <asp:Panel runat="server" ID="pn_cadastro_user_google">
                    <div class="modal-header py-1 px-1">
                        <div class="d-flex align-items-center">
                            <svg class="bi  figure-img" width="30" height="30" fill="currentColor">
                                <use href="../imagens/icones/bootstrap-icons.svg#google"></use></svg>
                            <div class=" fs-6 text-uppercase  p-2 fw-bold">Cadastro</div>
                        </div>
                    </div>
                    <div class="modal-body p-2 p-sm-3 ">

                        <div id="pn_cadastro_user_google_2">
                            <div class="col-12">
                                <div class="form-floating mb-3">


                                    <asp:DropDownList ID="DDLSexo" runat="server" CssClass="form-select DDLSexo " TabIndex="4">
                                        <asp:ListItem Text="Selecione uma opção" Value="0" />
                                        <asp:ListItem Value="Masculino" Text="Masculino" />
                                        <asp:ListItem Value="Feminino" Text="Feminino" />
                                    </asp:DropDownList>
                                    <label for="DDLSexo">Sexo</label>

                                     <asp:RequiredFieldValidator InitialValue="0" Display="Dynamic" CssClass="mx-2 tex-t small   text-truncate" ForeColor="Red" runat="server" ID="RequiredFieldValidator1"
                        ErrorMessage="Campo é obrigatório"  ControlToValidate="DDLSexo" />
                                </div>
                            </div>
                            <div class="col-12 my-1">
                                <div class="form-floating mb-1">
                                    <asp:DropDownList ID="DLLTipoUSer" runat="server" CssClass="DLLTipoUSer form-select" TabIndex="4">
                                        <asp:ListItem Text="Selecione uma opção" value="0" />
                                        <asp:ListItem Value="3" Text="Empresa" />
                                        <asp:ListItem Value="2" Text="Profissional" />
                                    </asp:DropDownList>
                                    <label for="DLLTipoUSer">Tipo de Usuario</label>
                                </div>
                                     <asp:RequiredFieldValidator InitialValue="0" Display="Dynamic" CssClass="mx-2 small  text-truncate" runat="server" ID="rfvddl_tipouser"
                        ErrorMessage="Campo é obrigatório"  ControlToValidate="DLLTipoUSer"  ForeColor="Red" />

                            </div>
                            <hr class="my-3" />

                            <div class="col-12 mb-4 p-0">
                                <div class="form-check form-switch">
                                  <input class="form-check-input " type="checkbox" role="switch" id="flexSwitchCheckCheckedDisabled" checked  disabled  >
                                  <label class=" small text-uppercase" for="">Ao continuar você concorda com os <a href="Informacoes.aspx" class="link">  Termos de uso e política  de privacidade</a> </label>
                                </div>
                            </div>

                            <asp:Button   type="button"  ID="Btn_confirmar" OnClick="Btn_confirmar_Click" OnClientClick="this.disabled = true; this.value = 'Enviando...';" UseSubmitBehavior="false"  runat="server"   class="btn col-12 btn-sm mx-auto  btn-lg btn-outline-customer"  Text="Confirmar" />
                        </div>
                       
            </div>
            </asp:Panel>

 
        </div>
    </div>
    </div>
   <script  type="text/javascript"  >

       const Pn_Cadastro_google = document.querySelector('.panel_cadastro');

       function prox_pn() {


          
           var DDLSexo = document.querySelector(".DDLSexo");

           const DDLSexo_valor = DDLSexo.options[DDLSexo.selectedIndex].value;
           var DLLTipoUSer = document.querySelector(".DLLTipoUSer");
           const DLLTipoUSer_valor = DLLTipoUSer.options[DLLTipoUSer.selectedIndex].value;

           if (DDLSexo_valor != 0 && DLLTipoUSer_valor != 0) {
               loading(Pn_Cadastro_google,   true);
               PageMethods.Cadastrando_usuario_google(DLLTipoUSer_valor, DDLSexo_valor, OnGetMessageSuccess, OnGetMessageFailure);
           }
           else {
               alerta("Alerta", "é preciso Selecionar as opções")
           }
                
       }

       function OnGetMessageSuccess(result, userContext, methodName) {

          // loading(Pn_Cadastro_google,   false);
 
           if (result == "Cliente é Profissional") {
               window.location.href = "pro/mainpro.aspx";
           }
           else if (result == "Cliente é Empresa") {
               window.location.href = "empr/mainEmpresa.aspx";
           }
           else {
               window.location.href = "users_google.aspx";
               alerta("Alerta", result);
           }
       }

       function OnGetMessageFailure (error, userContext, methodName) {
           alerta("Erro", "Não conseguimos conectar com o servidor.")
           loading(Pn_Cadastro_google,  false);
       }


   </script>
</asp:Content>
