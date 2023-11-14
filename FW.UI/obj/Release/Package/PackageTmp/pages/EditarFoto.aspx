<%@ Page Title="" Language="C#" MasterPageFile="../Default.Master" AutoEventWireup="true" CodeBehind="EditarFoto.aspx.cs" Inherits="FW.UI.pages.EditarFoto" %>
<%@ MasterType VirtualPath="../Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"><div class="row container mx-auto">
    <div class="my-3 row justify-content-between">
        <div class="col-10">
            <!-- Ícone e rótulo para "Editar Foto" -->
            <svg class="bi me-2" width="30" height="30" fill="currentColor">
                <use href="../Imagens/icones/bootstrap-icons.svg#person-bounding-box"></use>
            </svg>
            <asp:Label runat="server" CssClass="fs-4 font-monospace fw-bold">Editar Foto</asp:Label>
        </div>
        <div class="text-end col-2">
            <!-- Botão "Excluir" -->
            <asp:LinkButton runat="server" OnClick="BtnExcluir_Click" ID="BtnExcluir" class="sidebar-heading text-secondary">
                <svg class="bi me-2" width="25" height="25" fill="currentColor">
                    <use href="../Imagens/icones/bootstrap-icons.svg#person-x"></use>
                </asp:LinkButton>
            </div>
        </div>

        <div class="container-fluid">
            <div class="container-xxl">
                <div class="accordion" id="accordion">
                    <div class="accordion-item">
                        <h2 class="accordion-header m-0" id="headingOne">
                            <button class="accordion-button text-uppercase font-monospace" type="button" data-bs-toggle="collapse" aria-expanded="true" aria-controls="collapseOne">
                                Foto
                            </button>
                        </h2>
                        <div id="collapseOne" class="accordion-collapse collapse show Campo_imagem" aria-labelledby="headingOne" data-bs-parent="#accordion">
                            <div class="accordion-body">
                                <div class="col-md-3 my-2 mx-auto order-1">
                                    <!-- Imagem exibida -->
                                    <asp:Image runat="server" ID="imagePro" CssClass="bd-placeholder-img Foto_URL bd-placeholder-img-lg featurette-image img-fluid mx-auto rounded img_caminho" style="max-width: 200px; max-height: 200px" onerror="this.onerror=null; this.src='../Cliente/Foto_Cliente/undraw_resume_folder_re_e0bi.svg'" />
                                </div>
                                <div class="col-md-3 my-2 mx-auto order-1 preview d-none" id="preview"></div>
                                <div class="mb-2 mx-auto col-md-6" id="btn_buscar_imagem">
                                    <label class="form-label font-monospace">Selecione uma imagem</label>
                                    <asp:FileUpload runat="server" class="File_Foto d-none" type="file" ID="File_Foto" TabIndex="2" accept=".png,.webp,.jpg" />
                                    <button type="button" class="btn btn-sm py-2 mb-2 w-100 btn-lg btn-outline-customer rounded-3">Buscar</button>
                                </div>
                                <div class="mb-2 col-md-6 mx-auto id_campo_varificacao">
                                    <!-- Botão "Enviar" -->
                                    <asp:Button OnClientClick="this.disabled = true; this.value = 'Enviando...';" UseSubmitBehavior="false" id="btn_enviar" runat="server" CssClass="btn btn-lg w-100 py-2 mb-2 btn btn-outline-customer rounded-3 Btn_foto_upload d-none disabled" Text="Enviar" OnClick="Btn_foto_upload_Click"></asp:Button>
                                    <button type="button" class="btn btn-sm py-2 mb-2 w-100 btn-lg btn-outline-secondary rounded-3 disabled d-none" id="btn_cortar_imagem">Cortar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/croppie/2.6.5/croppie.min.css">
<script src="https://cdnjs.cloudflare.com/ajax/libs/croppie/2.6.5/croppie.min.js"></script>

<script>
$(function () {
    // Verifica se a classe "Campo_imagem" está presente no documento
    const exist = document.body.contains(document.querySelector('.Campo_imagem'));

    if (exist == true) {
        // Se a classe "Campo_imagem" existe, faz o seguinte:
        var objImg = document.querySelector('.img_caminho');
        var objBtn_Enviar = document.querySelector('.Btn_foto_upload');
        var objBtn_cortar = document.querySelector('#btn_cortar_imagem');
        const objFile = document.querySelector('.File_Foto');
        var preview = document.querySelector('.preview');
        var objBtn_buscar_img = document.querySelector('#btn_buscar_imagem');
        var redimensionar = $('.preview').croppie({
            enableExif: true,
            enableOrientation: true,
            viewport: { width: 200, height: 200, type: 'square' },
            boundary: { width: 300, height: 300 },
        });

        // Ação de click no botão para buscar imagem
        objBtn_buscar_img.addEventListener('click', () => {
            objFile.click();
        });

        // Executa ao identificar algo no arquivo selecionado
        objFile.addEventListener('change', function (algoNoFile) {
            const file = algoNoFile.target.files[0];

            if (file != null) {
                var fileExtension = ['jpeg', 'jpg', 'png'];

                if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
                    // Exibe um alerta se o formato do arquivo não é suportado
                    alert("Erro", "Erro ao analisar o arquivo, use JPG ou PNG");
                    removeFileFromFileList(objBtn_buscar_img);

                    function removeFileFromFileList(index) {
                        // Remove o arquivo da lista de seleção
                        const dt = new DataTransfer();
                        const input = objFile;
                        const { files } = input;

                        for (let i = 0; i < files.length; i++) {
                            const file = files[i];
                            if (index !== i)
                                dt.items.remove(file);
                        }

                        input.files = dt.files;
                    }
                }

                if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) > 0) {
                    OnSuccess();
                }

                function OnSuccess() {
                    objBtn_buscar_img.classList.add("d-none");
                    const reader = new FileReader();
                    objImg.classList.add("d-none");
                    preview.classList.remove("d-none");
                    objBtn_cortar.classList.remove("d-none");
                    objBtn_Enviar.classList.add("d-none");
                    reader.onload = function (e) {
                        redimensionar.croppie('bind', {
                            url: e.target.result
                        });
                        objBtn_cortar.classList.remove('disabled');
                    }
                    reader.readAsDataURL(file);

                    $('#btn_cortar_imagem').on('click', function () {
                        redimensionar.croppie('result', {
                            type: 'canvas',
                            size: 'viewport',
                            quality: 1,
                            format: 'png',
                        }).then(function (img) {
                            preview.classList.add("d-none");
                            objImg.classList.remove("d-none");

                            // Converte dados em arquivo de imagem
                            function dataURLtoFile() {
                                dataurl = img;
                                filename = `imag_cortada_${nume}.png`;
                                var arr = dataurl.split(',');
                                mime = arr[0].match(/:(.*?);/)[1];
                                bstr = atob(arr[1]);
                                n = bstr.length;
                                u8arr = new Uint8Array(n);

                                while (n--) {
                                    u8arr[n] = bstr.charCodeAt(n);
                                }

                                return Imagem_cortada = new File([u8arr], filename, { type: mime });
                            }

                            const nume = Math.floor(1000000 * Math.random()).toString();
                            var Arquivo_cortado = dataURLtoFile();
                            const url_Img = URL.createObjectURL(Arquivo_cortado);
                            objImg.src = url_Img;

                            removeFileFromFileList(objBtn_buscar_img);

                            function removeFileFromFileList(index) {
                                const dt = new DataTransfer();
                                const input = objFile;
                                const { files } = input;

                                for (let i = 0; i < files.length; i++) {
                                    const file = files[i];
                                    if (index !== i)
                                        dt.items.add(Arquivo_cortado);
                                }

                                input.files = dt.files;
                            }

                            objBtn_Enviar.classList.remove("d-none");
                            objBtn_Enviar.classList.remove("disabled");
                            objBtn_cortar.classList.add("d-none");
                        });
                    });
                }
            }
        });
    }
});
</script>


</asp:Content>
