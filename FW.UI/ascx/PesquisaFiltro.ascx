<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PesquisaFiltro.ascx.cs" Inherits="FW.UI.ascx.PesquisaFiltro" %>

                <div class="col my-4 container mx-auto " id="Filtro_container" style="display: none" tabindex="-1">
                    <div class="card text-dark  mb-3">
                        <div class="card-header  ">
                            <svg class="bi  me-2  text-dark" width="20" height="20" role="img" fill="currentColor">
                                <use href="../Imagens/icones/bootstrap-icons.svg#sliders"></use></svg>
                            <asp:Label runat="server" Text="Filtro" CssClass="text-dark font-monospace  fw-bold"></asp:Label>
                            <button tabindex="1" id="btn_close_filtro" onclick="display_objetos('BtnFiltro','Filtro_container')" type="button" class=" p-0 btn float-end text-dark    ">
                                <svg class="bi   text-dark" width="20" height="20" role="img" fill="currentColor">
                                    <use href="../imagens/icones/bootstrap-icons.svg#x-lg"></use></svg>
                            </button>
                        </div>

                        <div class="card-body     ">
                        <div class="d-flex justify-content-between align-items-center font-monospace text-uppercase p-0 col-12">
    <button runat="server" type="button" onclick="Fechando_cliente()" id="Button_Abrir_campoOportunidade"
        class="col-md-4 border-0 col-lg-5 text-truncate btn   text-center"
        data-bs-toggle="collapse" data-bs-target="#pn_oportunidade_2" aria-expanded="false" tabindex="2">
        <svg class="bi img-fluid me-2 text-dark" width="20" height="20" fill="currentColor">
            <use href="../Imagens/icones/bootstrap-icons.svg#columns-gap" />
        </svg>
        Oportunidades
    </button>
    <button runat="server" type="button" onclick="Fechando_Oportunidades()" id="btn_Buscar_Vagas"
        class="col-md-4 col-lg-5 text-truncate btn  border-0 text-center"
        data-bs-toggle="collapse" data-bs-target="#pn_cliente_2" aria-expanded="false" tabindex="3">
        <svg class="bi img-fluid me-2 text-dark" width="20" height="20" fill="currentColor">
            <use href="../Imagens/icones/bootstrap-icons.svg#people" />
        </svg>
        Clientes
    </button>
</div>

  <div class="collapse multi-collapse multi-collapse_Filtro collapse-horizontal col-12 my-2   row g-1 pn_oportunidade_2" tabindex="-1" id="pn_oportunidade_2">

                                <div class="col-12 col-sm-8 col-md-12 form-floating mb-2  " id="campo_NomeVaga">
                           
         <asp:TextBox CssClass="form-control SugestaoText" ID="txtTitulo_buscar"  data-tipo="NomeVaga" runat="server" TabIndex="1" placeholder="e" MaxLength="100"/>
            <label id="lblTitulo_buscar" for="txtTitulo_buscar" class="small text-secondary font-monospace">Título</label>
 
 
                                </div>
  
                                <div class="   col-sm-4 col-md-4 form-floating  mb-2" id="campo_TipoRegistro">
                                    <asp:DropDownList ID="dllRegistro_pesquisa" runat="server" CssClass=" form-select-sm form-select text-secondary small" TabIndex="2">
                                        <asp:ListItem Value="0" Text="Selecione" />
                                        <asp:ListItem Value="Estágio" Text="Estágio" />
                                        <asp:ListItem Value="CLT" Text="CLT" />
                                        <asp:ListItem Value="Freelancer" Text="Freelancer" />
                                        <asp:ListItem Value="Temporário" Text="Temporário" />
                                        <asp:ListItem Value="PJ" Text="PJ" />
                                        <asp:ListItem Value="Outro" Text="Outro" />
                                    </asp:DropDownList>
                                    <label for="dllRegistro" class="small text-secondary font-monospace ">Tipo de Registro</label>
                                </div>
                                <div class="col-sm-6 col-md-4 form-floating  mb-2  " id="campo_Experiencia">
                                    <asp:DropDownList ID="ddlExperiencia" runat="server" CssClass=" form-select-sm form-select text-secondary small" placeholder="e" TabIndex="3">
                                        <asp:ListItem Value="0" Text="Selecione" />
                                        <asp:ListItem Value="Assistente" Text="Assistente" />
                                        <asp:ListItem Value="Júnior" Text="Júnior" />
                                        <asp:ListItem Value="Pleno-sênior" Text="Pleno-sênior" />
                                        <asp:ListItem Value="Diretor" Text="Diretor" />
                                        <asp:ListItem Value="Executivo" Text="Executivo" />
                                    </asp:DropDownList>
                                    <label for="ddlExperiencia" class="small text-secondary font-monospace">Nível de Experiência</label>
                                </div>
                                <div class="col-sm-6 col-md-4 form-floating  mb-2 ">
                                    <asp:DropDownList ID="DDLTipoVaga" runat="server" placeholder="Tipo de Vaga Presencial/remota" CssClass=" form-select-sm form-select text-secondary small" TabIndex="2">
                                        <asp:ListItem Value="0" Text="Selecione" />
                                        <asp:ListItem Text="Presencial" />
                                        <asp:ListItem Text="Remoto" />
                                        <asp:ListItem Text="Híbrido" />
                                    </asp:DropDownList>
                                    <label for="DDLTipoVaga" class="small text-secondary font-monospace">Tipo de Vaga Presencial/remota</label>

                                </div>



                                <div class="col-sm-6 form-floating">
                                    <asp:TextBox runat="server" CssClass="form-control   form-control-sm  " ID="txtUF" placeholder="UF" TabIndex="3" />
                                    <label for="txtUF" class="text-secondary small">UF</label>
                                </div>

                                <div class="col-sm-6   form-floating">
                                    <asp:TextBox runat="server" CssClass="form-control   form-control-sm   " ID="txtCidade" placeholder="Cidade" TabIndex="6" />
                                    <label for="txtCidade" class="text-secondary small">Cidade</label>
                                </div>
                                <div class="col  mt-3 d-flex">

                                    <asp:Button runat="server" UseSubmitBehavior="false" OnClick="Btn_BuscaOportunidade_Click" ID="btnProcurarOportunidade" TabIndex="4" type="button" CausesValidation="false" Text="Buscar" CssClass="btn btn-sm mx-auto    btn-outline-customer2 col-5 " />
                                </div>
                            </div>
                            <div class="collapse multi-collapse collapse-horizontal col-12 my-2  row g-1 pn_cliente_2" tabindex="-1" id="pn_cliente_2">
                                <h1 class=" fw-bold font-monospace ms-1 fs-6 small">Procurar pessoas</h1>

                                
                                 <div class="mb-2 col-lg-6 form-floating " >
                                  <asp:TextBox CssClass="form-control SugestaoText" data-tipo="NomeCliente" ID="txtNome_pesquisa" runat="server" TabIndex="1" placeholder="" MaxLength="100" /> 
 <label id="lblNome"  class="text-secondary small" for="txtNome_pesquisa"   >Nome</label>
                                </div>

                                <div class="mb-2 col-lg-6 form-floating " id="campo_usuario">
                                    <asp:TextBox runat="server" CssClass="form-control SugestaoText" data-tipo="usuario" placeholder="user" ID="txtUsuario_pesuisa" TabIndex="2" />
                                    <label class="text-secondary small" for="txtUser">Usuario</label>
                                </div>
                                <div class="mb-2 form-floating col-sm-6    " id="campo_Formacao">
                                    <asp:DropDownList runat="server" ID="DdlFormacaoAcademica_pesquisa" TabIndex="3" DataTextField="SE" CssClass=" form-select-sm form-select text-dark small">
                                        <asp:ListItem Value="0" Text="Selecione" />
                                        <asp:ListItem Text="Ensino Médio" Value="Ensino Médio" />
                                        <asp:ListItem Text="Técnico" Value="Técnico" />
                                        <asp:ListItem Text="Graduação" Value="Graduação" />
                                        <asp:ListItem Text="Mestrado" Value="Mestrado" />
                                        <asp:ListItem Text="Doutorado" Value="Doutorado" />
                                        <asp:ListItem Text="Pós Doutorado" Value="Pós Doutorado" />
                                        <asp:ListItem Text="Livre Dôcencia" Value="Livre Dôcencia" />
                                    </asp:DropDownList>
                                    <label for="DdlFormacaoAcademica_pesquisa" class="">Formação Acadêmica</label>
                                </div>
                                <div class="mb-2 form-floating col-sm-6   " id="campo_Sexo">
                                    <asp:DropDownList ID="ddlSexo_pesquisa" runat="server" CssClass=" form-select-sm form-select text-dark small" placeholder="Sexo" TabIndex="4">
                                        <asp:ListItem Value="0" Text="indiferente" />
                                        <asp:ListItem Value="Masculino" Text="Masculino" />
                                        <asp:ListItem Value="Feminino" Text="Feminino" />
                                    </asp:DropDownList>
                                    <label for="DDLSexo" class="text-secondary small">Sexo</label>
                                </div>
                                <div class="col-sm-6 form-floating">
                                    <asp:TextBox runat="server" CssClass="form-control   form-control-sm  " ID="TextBox3" placeholder="UF" TabIndex="3" />
                                    <label for="txtUF" class="text-secondary small  SugestaoText" data-tipo="Uf" >UF</label>
                                </div>

                                <div class="col-sm-6   form-floating">
     <asp:TextBox runat="server" CssClass="form-control   form-control-sm   SugestaoText" data-tipo="Cidade" ID="TextBox4" placeholder="Cidade" TabIndex="6" />
                                    <label for="txtCidade" class="text-secondary small">Cidade</label>
                                </div>
                                <div class="col  mt-3 d-flex">
                                    <asp:Button runat="server" type="button" ID="btn_buscarCliente" CausesValidation="false" Text="Buscar" CssClass="btn btn-sm btn-lg col-5 mx-auto   btn-outline-customer" TabIndex="5" OnClick="Btn_BuscaClientes_Click" />

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

<script>
$(function () {
    $(".SugestaoText").each(function () {
        var txtCampo = $(this);
	var tipo = txtCampo.data("tipo").toString();
        var suggestionsDiv = $("<div class='suggestionsDiv dropdown-menu w-100' style='display: none; position: absolute;'></div>");
        txtCampo.after(suggestionsDiv);

        txtCampo.keyup(function () {
            var prefix = txtCampo.val();
            var methodName = "GetSugestoes"; // Nome do método a ser chamado no servidor
            var params = { prefixo: prefix, tipo:tipo  }; // Parâmetros a serem enviados para o servidor

            callServerMethod(methodName, params, function (data) {
                handleSuccess(data, suggestionsDiv, txtCampo);
            }, function (result) {
                handleError(result);
            });
        });
// Adicione um manipulador de eventos de clique no documento inteiro
    $(document).on('click', function (e) {
        var clickedElement = $(e.target);
        
        // Verifique se o elemento clicado não é uma parte do suggestionsDiv ou do txtCampo
        if (!clickedElement.closest('.suggestionsDiv').length && !clickedElement.closest('.SugestaoText').length) {
            suggestionsDiv.hide();
        }
    });
    });

   
});


function handleSuccess(data, suggestionsDiv, txtCampo) {
    suggestionsDiv.empty();

    if (data.length > 0) {
        data.forEach(function (item) {
            var suggestion = $("<div class='suggestion px-2'>" + item + "</div>");
            suggestionsDiv.append(suggestion);

            suggestion.click(function () {
                txtCampo.val($(this).text());
                suggestionsDiv.hide();
            });

            suggestion.hover(
                function () {
                    $(this).css("background-color", "#e0e0e0");
                },
                function () {
                    $(this).css("background-color", "");
                }
            );
        });
        suggestionsDiv.show();
    } else {
        suggestionsDiv.hide();
    }
}

function handleError(result) {
    if (result.status === 404) {
        console.log("Erro 404: Recurso não encontrado.");
    } else if (result.status === 500) {
        console.log("Erro 500: Erro interno do servidor.");
    } else {
        console.log("Erro desconhecido: " + result.statusText);
    }
}
</script>

