<%@ Page Title="" Language="C#" MasterPageFile="../Default.Master" AutoEventWireup="false" CodeBehind="Formulario_Publicacao.aspx.cs" Inherits="FW.UI.pages.Formulario_Publicacao" %>

<%@ MasterType VirtualPath="../Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ValidateRequestMode="Enabled">

    <div class=" mt-3  mb-2 col-12  d-inline-flex   ">
    <div class="  col-7 d-inline-flex float-start text-start ">
        <svg class="bi me-2 " width="30" height="30" fill="currentColor">
            <use href="../Imagens/icones/bootstrap-icons.svg#folder"></use></svg>
        <label class="fs-6 font-monospace  fw-bold pt-1">PUBLICAÇÃO</label>
    </div>
    
        <div class="  text-danger    col float-end text-end d-none BtnPublicar_foto">
            <asp:LinkButton runat="server" ID="BtnPublicar_foto" OnClick="BtnPublicar_foto_Click" type="button" class=" ms-2 btn-sm btn-outline-customer   font-monospace fw-semibold text-decoration-none    "> Publicar
        <svg class="bi mx-2 my-1  " width="15" height="15" fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#patch-plus-fill"></use></svg>
        </asp:LinkButton>

    </div>
    </div>
    <asp:Panel runat="server" ID="form_publi" CssClass=" g-1  row Panel_form  Panel_form_publi ">
 
            <div class="modal-footer my-3 float-end g-2 modal_btnImg">
            </div>

        <div class="mb-3 col-md-12 form-floating">
            <asp:TextBox runat="server" spellcheck="true" class="form-control txtMenssagem" placeholder="biografia" ID="txtMenssagem" Style="min-height: 50px; max-height: 100px" Height="100" TextMode="MultiLine" TabIndex="6" Width="100%" MaxLength="400" />
            <label for="txtMenssagem" class="text-secondary small">Menssagem</label>
        </div>

        <div class="row fw-bold font-monospace  text-uppercase  fs-3 text-center">
            <button type="button" onclick="Imagens_abrindo()" id="ButtonImagen" class="col-2 mx-auto  btn btnImagem">
                <svg class="bi img-fluid   text-dark  " width="32" height="32" fill="currentColor">
                    <use href="../Imagens/icones/bootstrap-icons.svg#images" />
                </svg>
            </button>
            <button onclick="Videos_Abrindo()" type="button" id="ButtonVideo" class="col-2 mx-auto btnVideo btn text-dark">
                <svg class="bi img-fluid   text-dark  " width="32" height="32" fill="currentColor">
                    <use href="../Imagens/icones/bootstrap-icons.svg#youtube" />
                </svg>
            </button>

        </div>

        <asp:Panel runat="server" ID="PnMenuFileUpload" class="row  d-none  g-1  PnMenuFileUpload">
            <div class="col-12 align-content-between     ">

                <button type="button" onclick="Abrindo_files()" class=" Button_Gerador_File_Click btn  float-start small  btn-sm btnImagem">

                    <div class="my-auto text-center  flex-column  col">
                        <svg class="bi img-fluid   text-darck  " width="15" height="15" fill="currentColor">
                            <use href="../Imagens/icones/bootstrap-icons.svg#plus-square-fill" />
                        </svg>
                    </div>
                </button>

                <button type="button" onclick="Fechando_File()" class=" btn Btn_Excluir_File_Click  d-none float-end small  btn-sm  ">
                    <svg class="bi img-fluid   text-darck  " width="15" height="15" fill="currentColor">
                        <use href="../Imagens/icones/bootstrap-icons.svg#dash-square-fill" />
                    </svg>
                </button>
            </div>

            <asp:Panel runat="server" ID="Panel_1" CssClass="col-12 col-form-label-sm File_Up_1">
                <asp:Label runat="server" CssClass="form-label fw-bold  small" Text="Imagem 1" for="formFileSm" ID="Label" />
                <asp:FileUpload ID="File_1" CssClass="form-control  form-control-sm  d-none file-input file File_1" accept=".png,.webp,.jpg" type="File" AllowMultiple="false" runat="server" />
                <button id="btn_file1" class="btn btn-outline-customer btn_file1 float-end " type="button">Buscar Imagem</button>
                <button id="btn_file1_remove" onclick="Removendo_img_file_publicacao('1');" class="btn  btn-secondary btn-sm btn_file1_remove float-end d-none" type="button">remover Imagem</button>
            </asp:Panel>
            <asp:Panel runat="server" ID="Panel_2" CssClass="col-12 col-form-label-sm File_Up_2 d-none">
                <asp:Label runat="server" CssClass="form-label fw-bold  small" Text="Imagem 2" for="formFileSm" ID="Label1" />
                <asp:FileUpload ID="File_2" CssClass="form-control  form-control-sm d-none file-input file File_2 " accept=".png,.webp,.jpg" type="File" AllowMultiple="false" runat="server" />
                <button id="btn_file2" class="btn btn-outline-customer btn_file2 float-end" type="button">Buscar Imagem</button>
                <button id="btn_file2_remove" onclick="Removendo_img_file_publicacao('2');" class="btn  btn-secondary btn-sm btn_file2_remove float-end d-none" type="button">remover Imagem</button>


            </asp:Panel>
            <asp:Panel runat="server" ID="Panel_3" CssClass="col-12 col-form-label-sm File_Up_3 d-none">
                <asp:Label runat="server" CssClass="form-label fw-bold  small" Text="Imagem 3" for="formFileSm" ID="Label2" />
                <asp:FileUpload ID="File_3" CssClass="form-control  d-none form-control-sm  file-input file File_3" accept=".png,.webp,.jpg" type="File" AllowMultiple="false" runat="server" />
                <button id="btn_file3" class="btn btn-outline-customer btn_file3 float-end" type="button">Buscar Imagem</button>
                <button id="btn_file3_remove" onclick="Removendo_img_file_publicacao('3');" class="btn  btn-secondary btn-sm btn_file3_remove float-end d-none" type="button">remover Imagem</button>


            </asp:Panel>
              <div class="Pn_slide_publi Pn_item_publi gap-3 col-12 px-auto d-inline-flex mx-auto g-2  ">
       
    </div>
 
 

        </asp:Panel>

        <asp:Panel runat="server" ID="PnMenuLink" class="row d-none  PnMenuLinkYoutube g-1 my-2 ">
       <%--     <div class="col-12 align-content-between     ">

                <button type="button" onclick="Abrindo_Text()" class=" Btn_Gerador_Text btn  float-start small  btn-sm ">

                    <div class="my-auto text-center  flex-column  col">
                        <svg class="bi img-fluid   text-darck  " width="15" height="15" fill="currentColor">
                            <use href="../Imagens/icones/bootstrap-icons.svg#plus-square-fill" />
                        </svg>
                    </div>
                </button>
                <button type="button" onclick="Fechando_Text()" class=" btn Btn_Excluir_Text float-end small d-none  btn-sm  ">
                    <svg class="bi img-fluid   text-darck  " width="15" height="15" fill="currentColor">
                        <use href="../Imagens/icones/bootstrap-icons.svg#dash-square-fill" />
                    </svg>
                </button>
            </div>--%>
            <div class=" pn_text_youtube_1 row my-1 g-1">
                <div class="my-auto text-center col-1">
                    <svg class="bi img-fluid   text-danger  " width="32" height="32" fill="currentColor">
                        <use href="../Imagens/icones/bootstrap-icons.svg#youtube" />
                    </svg>
                </div>
                <div class=" col-11 form-floating">
                    <asp:TextBox runat="server" CssClass="form-control form-control-sm UrlYoutube1 " TextMode="SingleLine" placeholder="Link" ID="UrlYoutube1" />
                    <label for="Urlyoutube" class="text-secondary font-monospace small">Link</label>
                </div>
            </div>

            <div class="my-1 pn_text_youtube_2 d-none row g-1 ">
                <div class="my-auto text-center col-1">
                    <svg class="bi img-fluid   text-danger  " width="32" height="32" fill="currentColor">
                        <use href="../Imagens/icones/bootstrap-icons.svg#youtube" />
                    </svg>
                </div>
                <div class=" col-11 form-floating">
                    <asp:TextBox runat="server" CssClass="form-control form-control-sm UrlYoutube2" TextMode="SingleLine" placeholder="Link" ID="UrlYoutube2" />
                    <label for="Urlyoutube" class="text-secondary font-monospace small">Link</label>
                </div>
            </div>

            <div class="modal-footer my-3 g-2 modal_btnVideo">
    <button type="button" class="btn ms-3 btn-sm btn-outline-customer " onclick="VerificarLinkYoutube()" id="btn_verificar_imagem">Verificar Videos</button>

            </div>

        </asp:Panel>

        <div class="modal-footer my-3 g-2 btn_publicar_text">
            <asp:LinkButton runat="server" OnClick="BtnCadastrar_texto_Click" ID="btnCadastrar_texto" type="button" class="btn ms-3 btn-sm btn-outline-customer">Publicar Texto</asp:LinkButton>
        </div>
    </asp:Panel>
   

    <div class="col-md-3 my-2  mx-auto  order-1 preview d-none" id="preview">
    </div>
    <button type="button" class="btn btn-sm py-2 mb-2  w-100 btn-lg btn-outline-secondary rounded-3 disabled d-none " id="btn_cortar_imagem">Cortar</button>



    <asp:Panel runat="server" ID="Pn_Video" data-slide="slide" CssClass=" iframe_publicacao_Video d-none  m-0   " Style="max-width: 100%; box-shadow: none;">
        <iframe id="iframe_youtube_1" runat="server" src="null" height="315" class="  iframe_youtube_1 container-fluid  " target="_parent" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen="true"></iframe>
        <iframe id="iframe_youtube_2" runat="server" height="315" class="d-none iframe_youtube_2 container-fluid  "  target="_parent" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen="true"></iframe>
   
         <div class="col-12  my-3     ">

                <button type="button" onclick="Voltar_VerificacaoLink()" class=" btn_voltar_url  btn-outline-secondary  btn border-0 my-auto text-start  flex-column  col   float-start small  btn-sm">
                    <svg class="bi me-1 my-1  " width="15" height="15" fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#backspace"></use></svg>   voltar
                </button>
                <asp:LinkButton runat="server" OnClick="Btn_PublicarVideo_Click" ID="Btn_PublicarVideo" type="button"
                    class=" ms-2 btn-sm btn-danger float-end  btn font-monospace fw-semibold text-decoration-none    "> Confirmar
                    <svg class="bi mx-2 my-1  " width="15" height="15" fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#check-lg"></use></svg> </asp:LinkButton>



            </div>
    </asp:Panel>
     
    <script>
        //abrindo e fechando painel imagens   >> fechando Painel video e painel btn_publicar Text
        function Imagens_abrindo() {
            const PnMenuFileUpload = document.querySelector('.PnMenuFileUpload');
            const PnMenuLinkYoutube = document.querySelector('.PnMenuLinkYoutube');
            const btn_publicar_text = document.querySelector('.btn_publicar_text');

            const PnMenuFileUpload_status = PnMenuFileUpload.getAttributeNode("class").nodeValue.includes("d-none");

            if (PnMenuFileUpload_status == true) {
                PnMenuLinkYoutube.classList.add("d-none");
                PnMenuFileUpload.classList.remove("d-none");
                btn_publicar_text.classList.add("d-none");

            }
            else if (PnMenuFileUpload_status == false) {

                PnMenuFileUpload.classList.add("d-none");
                btn_publicar_text.classList.remove("d-none");

            }

        }
        ///Alterando visibilidade Fileup das imagens On
        function Abrindo_files() {
            var Btn_Fechar = document.querySelector('.Btn_Excluir_File_Click');
            var Btn_Abrir = document.querySelector('.Button_Gerador_File_Click');
            const File_1 = document.querySelector('.File_Up_1');
            const File_2 = document.querySelector('.File_Up_2');
            const File_3 = document.querySelector('.File_Up_3');
            const File_1_Status = File_1.getAttributeNode("class").nodeValue.includes("d-none");
            const File_2_Status = File_2.getAttributeNode("class").nodeValue.includes("d-none");
            const File_3_Status = File_3.getAttributeNode("class").nodeValue.includes("d-none");

            if (File_2_Status == true && File_1_Status == false) {
                Btn_Fechar.classList.remove("d-none");
                File_2.classList.remove("d-none");

            } else if (File_3_Status == true && File_2_Status == false) {
                File_3.classList.remove("d-none");
                Btn_Abrir.classList.add("d-none");

            }

        }
        //off
        function Fechando_File() {
            var Btn_Fechar = document.querySelector('.Btn_Excluir_File_Click');
            var Btn_Abrir = document.querySelector('.Button_Gerador_File_Click');
            const File_1 = document.querySelector('.File_Up_1');
            const File_2 = document.querySelector('.File_Up_2');
            const File_3 = document.querySelector('.File_Up_3');
            const File_1_Status = File_1.getAttributeNode("class").nodeValue.includes("d-none");
            const File_2_Status = File_2.getAttributeNode("class").nodeValue.includes("d-none");
            const File_3_Status = File_3.getAttributeNode("class").nodeValue.includes("d-none");

            if (File_1_Status == false && File_2_Status == false && File_3_Status == true) {
                File_2.classList.add("d-none");
                Btn_Fechar.classList.add("d-none");
                Removendo_img_file_publicacao("2");


            } else if (File_2_Status == false && File_3_Status == false) {
                Btn_Abrir.classList.remove("d-none");
                File_3.classList.add("d-none");
                Removendo_img_file_publicacao("3");


            }

        }
        //alterando visibilidade do Textbox youtube On
        function Abrindo_Text() {

            const Btn_Abrir = document.querySelector('.Btn_Gerador_Text');
            const Btn_Fechar = document.querySelector('.Btn_Excluir_Text');
            const Pn_Text_2 = document.querySelector('.pn_text_youtube_2');

            const Pn_Text_2_Status = Pn_Text_2.getAttributeNode("class").nodeValue.includes("d-none");
            if (Pn_Text_2_Status == true) {
                Pn_Text_2.classList.remove("d-none");
                Btn_Abrir.classList.add("d-none");
                Btn_Fechar.classList.remove("d-none");


            }
        }
        //Off  textbox youtube
        function Fechando_Text() {

            const Btn_Abrir = document.querySelector('.Btn_Gerador_Text');
            const Btn_Fechar = document.querySelector('.Btn_Excluir_Text');
            const Pn_Text_2 = document.querySelector('.pn_text_youtube_2');

            const Pn_Text_2_Status = Pn_Text_2.getAttributeNode("class").nodeValue.includes("d-none");
            if (Pn_Text_2_Status == false) {
                Pn_Text_2.classList.add("d-none");
                Btn_Fechar.classList.add("d-none")
                Btn_Abrir.classList.remove("d-none");


            }
        }
        //pn videos abrindo & fechando
        function Videos_Abrindo() {
            const btn_publicar_text = document.querySelector('.btn_publicar_text');
            const PnMenuLinkYoutube = document.querySelector('.PnMenuLinkYoutube');
            const PnMenuFileUpload = document.querySelector('.PnMenuFileUpload');
            const PnMenuLinkYoutube_status = PnMenuLinkYoutube.getAttributeNode("class").nodeValue.includes("d-none");

            if (PnMenuLinkYoutube_status == true) {

                PnMenuFileUpload.classList.add("d-none");
                PnMenuLinkYoutube.classList.remove("d-none");
                btn_publicar_text.classList.add("d-none");
            }
            else if (PnMenuLinkYoutube_status == false) {
                PnMenuLinkYoutube.classList.add("d-none");
                btn_publicar_text.classList.remove("d-none");


            }
        }
        function Voltar_VerificacaoLink(){
            const Panel_form_publi = document.querySelector('.Panel_form_publi');
            const iframe_publicacao_Video = document.querySelector('.iframe_publicacao_Video');
             


            Panel_form_publi.classList.remove("d-none");
            iframe_publicacao_Video.classList.add("d-none");
        }
       






    </script>
</asp:Content>
