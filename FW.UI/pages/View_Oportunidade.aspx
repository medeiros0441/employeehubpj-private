<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="View_Oportunidade.aspx.cs" Inherits="FW.UI.View_Oportunidade" %>

<%@ MasterType VirtualPath="~/Default.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="modal fade "   id="modal_formaCandidatura" data-toggle="modal" aria-hidden="true" data-bs-backdrop="static"  aria-labelledby="lbl_modal_1" tabindex="-1">
  <div class="modal-dialog modal-dialog-centered">
    <div class="modal-content">
      <div class="modal-header">
       <svg class="bi me-2" width="30" height="30"  fill="currentColor"><use href="../imagens/icones/bootstrap-icons.svg#bezier"></use></svg>
                <asp:Label runat="server" CssClass=" fs-6   font-monospace   fw-bold "  ID="lbl_modal_1">Forma de Candidatura</asp:Label>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
         <div class="list-group w-auto my-4 font-monospace  ">
  <asp:HyperLink runat="server" Target="_blank" NavigateUrl="../pages/Autenticacao.aspx"  CssClass="list-group-item list-group-item-action d-flex gap-3 py-3 d-block "  aria-current="true">
   <svg class="bi   " width="25" height="25"  fill="currentColor"><use href="../imagens/icones/bootstrap-icons.svg#person-check"></use></svg>
    <div class="d-flex gap-2 w-100 justify-content-between">
      <div>
        <h6 class="mb-0 font-monospace fs-6 my-auto">Fazer Login</h6>
      </div>
        <svg class="bi my-auto " width="25" height="25"  fill="currentColor"><use href="../imagens/icones/bootstrap-icons.svg#caret-right"></use></svg>
    </div>
  </asp:HyperLink>
        <asp:HyperLink runat="server" Target="_blank" NavigateUrl="../pages/Cadastro.aspx"  CssClass="list-group-item list-group-item-action d-flex gap-3 py-3 d-block "  aria-current="true">
   <svg class="bi   " width="25" height="25"  fill="currentColor"><use href="../imagens/icones/bootstrap-icons.svg#person-plus"></use></svg>
    <div class="d-flex gap-2 w-100 justify-content-between">
      <div>
        <h6 class="mb-0 font-monospace fs-6 my-auto">Cadastre-se</h6>
      </div>
        <svg class="bi my-auto " width="25" height="25"  fill="currentColor"><use href="../imagens/icones/bootstrap-icons.svg#caret-right"></use></svg>
    </div>
  </asp:HyperLink>
         <asp:LinkButton runat="server"  ID="BtnOpenCandidaturaSimplificada"  data-bs-target="#ModalCandidatura" data-bs-toggle="modal" data-bs-dismiss="modal" CssClass="list-group-item list-group-item-action d-flex gap-3 py-3 d-block "  aria-current="true">
   <svg class="bi   " width="25" height="25"  fill="currentColor"><use href="../imagens/icones/bootstrap-icons.svg#filetype-pdf"></use></svg>
    <div class="d-flex gap-2 w-100 justify-content-between">
      <div>
        <h6 class="mb-0 font-monospace fs-6 my-auto">Candidatura Simplificada</h6>
      </div>
        <svg class="bi my-auto " width="25" height="25"  fill="currentColor"><use href="../imagens/icones/bootstrap-icons.svg#caret-right"></use></svg>
    </div>
  </asp:LinkButton>
    </div>
      </div>
     
    </div>
  </div>
</div>

<div class="modal fade" id="ModalCandidatura" aria-hidden="true" data-toggle="modal" data-bs-backdrop="static" aria-labelledby="modal_lbl"  tabindex="-1">
  <div class="modal-dialog modal-dialog-centered">
    <div class="modal-content">
      <div class="modal-header">
          <svg class="bi me-2" width="30" height="30"  fill="currentColor"><use href="../imagens/icones/bootstrap-icons.svg#question-octagon"></use></svg>
        <asp:Label runat="server" class=" font-monospace fw-semibold    " Font-Size="X-Small" ID="modal_lbl">Apesar de não  armazenar o doc,  retemos algumas informações,Para evitar inscricao já feita, veja mais informações nos Termos de uso. </asp:Label>

        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <asp:Panel runat="server" class="modal-body  " DefaultButton="BtnCandidaturaSimplificada" >
        

        <div class="form-floating my-2    ">
            <asp:TextBox runat="server" ID="TxtNome" CssClass="form-control form-control-sm" placeholder="Nome" />
            <label for="TxtNome" class=" fw-semibold text-secondary  small font-monospace">Nome Completo: </label>
            <asp:RequiredFieldValidator runat="server" CssClass="mx-auto  ms-2 small" Display="Dynamic" ValidationGroup="CampoCandidatura" ControlToValidate="TxtNome" ErrorMessage="Campo Nome é obrigatório" ForeColor="red" />
        </div>
        <div class=" form-floating  my-2   ">
            <asp:TextBox runat="server" ID="TxtEmail" CssClass="form-control form-control-sm" placeholder="tre" />
            <label for="TxtEmail" class=" fw-semibold text-secondary  small font-monospace">Email:  </label>
            <asp:RegularExpressionValidator ID="gevEmailValido" runat="server" CssClass="mx-auto ms-2 small" ValidationGroup="CampoCandidatura" Display="Dynamic" ControlToValidate="txtEmail" ErrorMessage="O E-mail é inválido!" ForeColor="red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
            <asp:RequiredFieldValidator runat="server" CssClass="mx-auto  ms-2  small" Display="Dynamic" ValidationGroup="CampoCandidatura" ControlToValidate="txtEmail" ErrorMessage="Campo Email é obrigatório" ForeColor="red" />

        </div>
        <div class=" form-floating   my-2     ">
            <asp:TextBox runat="server" ID="TxtTelefone" CssClass="form-control phone form-control-sm " placeholder="WhatsApp" />
            <label for="TxtTelefone" class=" fw-semibold text-secondary    small font-monospace">WhatsApp:   </label>
            <asp:RequiredFieldValidator runat="server" CssClass="mx-auto  ms-2 small" Display="Dynamic" ValidationGroup="CampoCandidatura" ControlToValidate="TxtTelefone" ErrorMessage="Campo Telefone é obrigatório" ForeColor="red" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="CampoCandidatura" CssClass="mx-auto ms-2 small" Display="Dynamic" ControlToValidate="txtTelefone" ErrorMessage="O telefone é inválido!" ForeColor="red" ValidationExpression="\(\d{2}\) \d{5}-\d{4}" />

        </div> 
        

                                <div class="mb-2 mx-auto  col-12"  >
                                            <asp:Label runat="server" ID="lblArquivo" class="form-label font-monospace">Selecione o Curriculo em PDF</asp:Label>
                                          <asp:Label runat="server" ID="name_file" class="form-label font-monospace"></asp:Label>
                              <asp:FileUpload runat="server" class="File_doc d-none" ID="File_Doc" TabIndex="2" accept=".doc,.pdf"  />
    
                                   <button type="button" class="btn btn-sm     btn-outline-customer rounded-3 btn-buscar float-end "  id="fileButton">Buscar</button>
                                                                    </div>

        <div class="col-12 mb-4 p-0">

            <div class="form-check form-switch">
                <input class="form-check-input " type="checkbox" role="checkbox" id="flexSwitchCheckCheckedDisabled" checked disabled>
                <asp:Label runat="server" Font-Size="Small" class=" small text-uppercase"  for="">Ao continuar você concorda com os <a href="Informacoes.aspx" class="link">Termos de uso e política  de privacidade</a> </asp:Label>
            </div>
        </div>
      </asp:Panel>
      <div class="modal-footer  ">
        <asp:Button runat="server" ID="BtnCandidaturaSimplificada" Text="Inscrever-se" CssClass=" d-none btn  btn-lg  float-end btn-outline-customer " ValidationGroup="CampoCandidatura" OnClick="BtnCandidaturaSimplificada_Click" />

      </div>
    </div>
  </div>
</div>
      
    <asp:Panel runat="server" ID="PnVaga" class="container my-3 mx-auto px-2 g-2 ">

        <div class="card-header p-3 rounded-top  d-flex justify-content-between " style="background-color: var(--laranja)">
            <asp:Label runat="server"   CssClass="  font-monospace  fw-bold  text-truncate   "  ID="lblVaga" />
            <div class="  d-flex float-end    ">
                <svg class="bi me-2 my-auto  " width="20" height="20" fill="currentColor">
                    <use href="../imagens/icones/bootstrap-icons.svg#geo-alt"></use></svg>
                <asp:Label runat="server" Font-Size="Medium" class="fs-6 font-monospace  fw-bold  " ID="LblTipoVaga" />
            </div>

        </div>
        <div class=" bg-light  rounded-bottom shadow">
            <div class="container   row p-3 font-monospace       ">

                <div class="col-sm-8  d-inline-flex ">
                    <asp:Label runat="server" Font-Size="Medium" class=" fw-semibold  font-monospace" Text="Nivél de Experiência:  " />
                    <asp:Label runat="server"   CssClass=" ms-2 font-monospace text-secondary" TabIndex="2" ID="lblExperiencia" />
                </div>
                <div class="col-sm-6 d-inline-flex ">
                    <asp:Label runat="server" Font-Size="Medium" class="fw-semibold font-monospace " Text="Tipo de Registro:  " />
                    <asp:Label runat="server" CssClass="ms-2 font-monospace   text-secondary" TabIndex="3" ID="lblResgistro" />
                </div>
                <div class="  d-inline-flex  col-sm-6">
                    <asp:Label runat="server" Font-Size="Medium" class=" fw-semibold     font-monospace " Text="Sexo:" />
                    <asp:Label runat="server" CssClass="  ms-2 font-monospace text-secondary" ID="lblSexo" />
                </div>
                <div class="  d-inline-flex col-sm-6 col-8">
                    <asp:Label runat="server" Font-Size="Medium" class=" fw-semibold    font-monospace " Text="Cidade:" />
                    <asp:Label runat="server" CssClass=" ms-2    font-monospace text-secondary" ID="LblCidade" />
                </div>

                <div class="d-inline-flex col-sm-6 col-4">
                    <asp:Label runat="server" Font-Size="Medium" class=" fw-semibold   font-monospace " Text="Estado:" />
                    <asp:Label runat="server" CssClass="  ms-2 font-monospace text-secondary" ID="LblEstado" />
                </div>
                <div class="col-sm-12  ">
                    <asp:Label runat="server" Font-Size="Medium" class=" fw-semibold    font-monospace " Text="Descrição:" />
                    <asp:Label runat="server" Class="    font-monospace text-secondary" ID="lblDescricao" />
                </div>

            </div>
        </div>

        <div class=" col-lg-12  my-3 mb-4  ">
            <asp:Button runat="server" CssClass="btn  ms-auto    order-2 " CausesValidation="false"    Style="background-color: var(--laranja)" ID="BtnCadastrar" TabIndex="7" OnClick="Cadastrar_Click" />
        </div>


        <div class="col-12  g-3">
            <asp:Repeater ID="rptVaga1" runat="server">
                <ItemTemplate>
                    <div class="card my-1  ">
                        <div class="card-header fw-semibold text-capitalize  ">
                            <label class=" font-monospace  fw-bold    ">
                                <%# DataBinder.Eval(Container.DataItem, "NomeVg") %>
                            </label>
                            <div class="  d-flex float-end    ">
                                <svg class="bi me-2 my-auto  " width="15" height="15" fill="currentColor">
                                    <use href="../imagens/icones/bootstrap-icons.svg#geo-alt"></use></svg>
                                <label class="fs-6 font-monospace  fw-bold  "><%# DataBinder.Eval(Container.DataItem, "TipoVagaVg").ToString() %></label>
                            </div>
                        </div>
                        <div class="card-body">
                            <p class="card-text cont-text-200 font-monospace "><%# ((string)DataBinder.Eval(Container.DataItem, "DescricaoVg")).Replace(Environment.NewLine, "<br />") %></p>

                        </div>
                        <div class="card-footer text-muted  ">
                            <asp:Label runat="server" class="small  Date_Alter_TempoPublicado float-start"><%# DataBinder.Eval(Container.DataItem, "DateTimeInsertVg").ToString() %></asp:Label>
                            <label class="menu ms-2 float-end">
                                <a class=" font-monospace fw-bolder " href="View_oportunidade.aspx?id_oportunidade=<%# DataBinder.Eval(Container.DataItem, "IdVaga ") %>" style="font-size: 10pt;">Ver detalhes</a></label>

                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </asp:Panel>

  <script>
      $(function executeFileUpload() {
          var fileInput = document.getElementById('<%= File_Doc.ClientID %>');
          var fileNameLabel = document.getElementById('<%= name_file.ClientID %>');
          var lblArquivo = document.getElementById('<%= lblArquivo.ClientID %>');
          var BtnCandidaturaSimplificada = document.getElementById('<%= BtnCandidaturaSimplificada.ClientID %>');
          var fileButton = document.getElementById('fileButton');

          // Adicionar evento de clique ao botão
          fileButton.addEventListener('click', function () {
              // Simular o clique no seletor de arquivo
              fileInput.click();
          });



          // Atualizar o nome do arquivo quando um arquivo for selecionado
          fileInput.addEventListener('change', function () {
              // Verificar se um arquivo foi selecionado
              if (fileInput.files.length > 0) {
                  var file = fileInput.files[0];

                  // Verificar se o tipo do arquivo é PDF
                  if (file.type === 'application/pdf') {
                      // Obter o nome do arquivo selecionado
                      var fileName = file.name;

                      // Atualizar o conteúdo do Label com o nome do arquivo
                      fileNameLabel.textContent = fileName;
                      lblArquivo.textContent = "Arquivo Selecionado: ";
                          BtnCandidaturaSimplificada.classList.remove('d-none'); // Substitua 'nom
                  } else {
                      // Limpar o seletor de arquivo e exibir uma mensagem de erro
                      fileInput.value = null;
                      fileNameLabel.textContent = '';
                      lblArquivo.textContent = "Selecione o Curriculo em PDF ";
                      alerta("Alerta",'Formato de arquivo inválido. Por favor, selecione um arquivo PDF.');
                  }
              }
          });
      });
      function OpenModal() {
          document.addEventListener('DOMContentLoaded', function () {
              var modalElement = document.getElementById('modal_formaCandidatura');
              var modal = new bootstrap.Modal(modalElement);
              modal.show();
          });
      }
  </script>
</asp:Content>
