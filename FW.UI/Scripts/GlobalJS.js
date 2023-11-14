
$(function Onload() {
    const exist = document.body.contains(document.getElementById("form1"));
    if (exist == true) {
        Panel_Slide();
        Alterando_Data();
    }
});
//mascara_ textbox
$(document).ready(function () {
    $('.USER').mask('@AAAAAAAAAAAAAA');
    $('.mes').mask('00/0000');
    $('.cnpj').mask('00.000.000/0000-00');
    $('.date').mask('00/00/0000');
    $('.time').mask('00:00:00');
    $('.cep').mask('00000-000');
    $('.phone').mask('(00) 00000-0000');
    $('.cpf').mask('000.000.000-00');
    $('.money').mask('00,00');
    $('.codigoEmail').mask('000-000');
});
//corretor de texto 
$(".corretor").on("input", function () {
var input = $(this);
var val = input.val();
if (input.is("[spellcheck]") && !input.is(":invalid")) {
    var result = "";
    if (window.spellcheck) {
        result = window.spellcheck.check(val);
    }
    if (result) {
        // Exibe sugestões
    }
}
});


 

function Video_Function() {
    const Btn_Abrir = document.querySelector('.Btn_Gerador_Text');
    const Btn_Fechar = document.querySelector('.Btn_Excluir_Text');
    const Pn_Text_2 = document.querySelector('.pn_text_youtube_2');

    Btn_Abrir.addEventListener('click', function (e) {
        const Pn_Text_2_Status = Pn_Text_2.getAttributeNode("class").nodeValue.includes("d-none");
        if (Pn_Text_2_Status == true) {
            Pn_Text_2.classList.remove("d-none");

        }
    });
    Btn_Fechar.addEventListener('click', function (e) {
        const Pn_Text_2_Status = Pn_Text_2.getAttributeNode("class").nodeValue.includes("d-none");
        if (Pn_Text_2_Status == true) {
            Pn_Text_2.classList.add("d-none");

        }
    });


}
//Slide
function Panel_Slide() {

    var Painel = document.querySelectorAll('.Pn_slide');
    //verificando se img exist && painel 
    const exist_panel = document.body.contains(document.querySelector('.Img_slide'));
    const exist_img = document.body.contains(document.querySelector('.Pn_slide'));
    if (exist_panel == true && exist_img == true) {
         

        Painel.forEach(item => {
            //adicionando number aleatorio em data slide
            const nume = Math.floor(1000000 * Math.random()).toString();
            item.setAttribute("data-slide", `slide_${nume}`);
            var data_slide = item.getAttributeNode("data-slide").nodeValue;
            const exist = document.body.contains(item);
            if (exist == true) {
                new SlideStories(data_slide);
                item.classList.remove('d-none');
            }
            else if (exist == true) {
                item.classList.add('d-none');
            }
        });
    }



    const exist2 = document.body.contains(document.querySelector('.slide_publicacao_repeter_imagens'));
    if (exist2 == true) {
        var Painel2 = document.querySelectorAll('.slide_publicacao_repeter_imagens');

        Painel2.forEach(item => {

            const nume = Math.floor(1000000 * Math.random()).toString();
            item.setAttribute("data-slide", `slide_${nume}`);
            const exist3 = document.body.contains(item);

            var Imagens = item.querySelectorAll('.Img_Publicacao');
            Imagens.forEach(img => {
                img.id = img.id + nume;
                const campo_img = img.getAttributeNode("src").nodeValue;
                if (campo_img != "") {
                    img.classList.remove('d-none');

                } else {
                    img.classList.add('d-none');
                    document.getElementById(`${img.id}`).remove()

                }

            });
            var Quantidade = item.querySelectorAll('.Img_Publicacao').length;
            var data_slide = item.getAttributeNode("data-slide").nodeValue;

            if (exist3 == true && Quantidade > 0) {
                new SlideStories(data_slide);
                item.classList.remove('d-none');
            }
            else if (Quantidade == 0) {
                item.classList.add('d-none');
            }
        });
    }

    const existVideo = document.body.contains(document.querySelector('.slide_publicacao_repeter_Video'));
    if (existVideo == true) {
        var PnVideo = document.querySelectorAll('.slide_publicacao_repeter_Video');
        PnVideo.forEach(item => {

            var iframe = item.querySelectorAll('.iframe_youtube');
            iframe.forEach(item_iframe => {
                const src = item_iframe.getAttributeNode("src").nodeValue;

                if ( src != "") {
                    const verificar = src.includes("/watch?v=");
                    const verificar_2 = src.includes(".be/");
                    if (verificar != false) {
                        Alterado = src.replace('watch?v=', 'embed/');

                        item_iframe.setAttribute("src", Alterado)
                    }
                    else if (verificar_2 != false) {
                        Alterado = src.replace('.be/', 'be.com/embed/');
                        item_iframe.setAttribute("src", Alterado)
                    }
                    else {
                        Alterado =  item_iframe.src.replace('.com/ ', '.com/embed/');
                        item_iframe.setAttribute("src", Alterado)
                    }
                     

                        item_iframe.classList.remove('d-none');

                }
            });
        });
    }
}  

class SlideStories {
    constructor(id) {
        this.slide = document.querySelector(`[data-slide="${id}"]`);
        this.active = 0;
        this.init();
    }
    activeSlide(index) {
        this.active = index;
        this.items.forEach((item) => item.classList.remove('active'));
        this.items[index].classList.add('active');
        this.thumbItems.forEach((item) => item.classList.remove('active'));
        this.thumbItems[index].classList.add('active');
        this.autoSlide();
    }
    prev() {
        if (this.active > 0) {
            this.activeSlide(this.active - 1);
        } else {
            this.activeSlide(this.items.length - 1);
        }
    }
    next() {
        if (this.active < this.items.length - 1) {
            this.activeSlide(this.active + 1);
        } else {
            this.activeSlide(0);
        }
    }
    addNavigation() {
        const nextBtn = this.slide.querySelector('.slide-next');
        const prevBtn = this.slide.querySelector('.slide-prev');
        nextBtn.addEventListener('click', this.next);
        prevBtn.addEventListener('click', this.prev);
    }
    addThumbItems() {
        this.items.forEach(() => (this.thumb.innerHTML += `<span></span>`));
        this.thumbItems = Array.from(this.thumb.children);
    }
    autoSlide() {
        clearTimeout(this.timeout);
        this.timeout = setTimeout(this.next, 5000);
    }
    init() {
        this.next = this.next.bind(this);
        this.prev = this.prev.bind(this);
        this.items = this.slide.querySelectorAll('.slide-items > *');
        this.thumb = this.slide.querySelector('.slide-thumb');
        this.addThumbItems();
        this.activeSlide(0);
        this.addNavigation();
    }
} 

// Função para alterar a data impressa no formato dia/mês/ano
function Alterando_Data() {
    // Verifica se existe elemento com a classe 'Date_Alter_DiaMesAno'
    const exist1 = document.body.contains(document.querySelector('.Date_Alter_DiaMesAno'));
    if (exist1 == true) {
        // Seleciona todos os elementos com a classe 'Date_Alter'
        var Date_Label = document.querySelectorAll('.Date_Alter');
        // Itera sobre cada elemento
        Date_Label.forEach(item => {
            // Obtém a data como string do conteúdo do elemento
            let data_string = item.textContent;
            // Formata a data usando a biblioteca 'moment' para "DD/MM/YYYY" e define o local para 'pt-br'
            item.innerHTML = moment(data_string).format("DD/MM/YYYY").locale('pt-br');
        });
    }

    // Verifica se existe elemento com a classe 'Date_Alter_TempoPublicado'
    const exist2 = document.body.contains(document.querySelector('.Date_Alter_TempoPublicado'));
    if (exist2 == true) {
        // Seleciona todos os elementos com a classe 'Date_Alter_TempoPublicado'
        var Date_Label = document.querySelectorAll('.Date_Alter_TempoPublicado');
        // Itera sobre cada elemento
        Date_Label.forEach(item => {
            // Obtém a data como string do conteúdo do elemento
            data_alter = moment(item.textContent, ["DD/MM/YYYY h:mm:ss ", "MM/DD/YYYY h:mm:ss A"]).locale('pt-br').fromNow();
            // Define o conteúdo do elemento como "Publicado : " seguido da data formatada
            item.innerHTML = "Publicado : " + data_alter;
        });
    }

    // Verifica se existe elemento com a classe 'Date_Calcule_tempo'
    const exist6 = document.body.contains(document.querySelector('.Date_Calcule_tempo'));
    if (exist6 == true) {
        // Seleciona todos os elementos com a classe 'Date_Calcule_tempo'
        var Date_Label = document.querySelectorAll('.Date_Calcule_tempo');
        // Itera sobre cada elemento
        Date_Label.forEach(item => {
            // Obtém a data como string do conteúdo do elemento
            data_alter = moment(item.textContent, ["DD/MM/YYYY h:mm:ss ", "MM/DD/YYYY h:mm:ss A", "YYYY/MM/DD h:mm:ss A"]).locale('pt-br').fromNow();
            // Define o conteúdo do elemento como a data formatada
            item.innerHTML = data_alter;
        });
    }

    // Verifica se existe elemento com a classe 'Date_Alter_Tempo'
    const exist3 = document.body.contains(document.querySelector('.Date_Alter_Tempo'));
    if (exist3 == true) {
        // Seleciona todos os elementos com a classe 'Date_Alter_Tempo'
        var Date_Label = document.querySelectorAll('.Date_Alter_Tempo');
        // Itera sobre cada elemento
        Date_Label.forEach(item => {
            // Obtém a data como string do conteúdo do elemento
            let data_string = item.textContent;
            // Formata a data usando a biblioteca 'moment' para "DD/MM" e define o local para 'pt-br'
            data_alter = moment(data_string, "DD/MM/YYYY h:mm:ss a").locale('pt-br').format("DD/MM");
            // Define o conteúdo do elemento como a data formatada
            item.innerHTML = data_alter;
        });

    }

    // Verifica se existe elementocom a classe 'Date_dia_mes'
    const exist4 = document.body.contains(document.querySelector('.Date_dia_mes'));
    if (exist4 == true) {
        // Seleciona todos os elementos com a classe 'Date_dia_mes'
        var Date_Label = document.querySelectorAll('.Date_dia_mes');
        // Itera sobre cada elemento
        Date_Label.forEach(item => {
            // Obtém a data como string do conteúdo do elemento
            let data_string = item.textContent;
            // Formata a data usando a biblioteca 'moment' para "DD/MM" e define o local para 'pt-br'
            data_alter = moment(data_string, "DD/MM/YYYY h:mm:ss A").locale('pt-br').format("DD/MM");
            // Define o conteúdo do elemento como a data formatada
            item.innerHTML = data_alter;
        });
    }
}


function Fechando_Oportunidades() {
    document.getElementById("pn_oportunidade_2").setAttribute("class", "collapse multi-collapse multi-collapse_Filtro collapse-horizontal col-12 my-2   row g-1 pn_oportunidade_2");
    document.getElementById("pn_cliente_2").setAttribute("class", "collapse multi-collapse collapse-horizontal col-12 my-2  row g-1 pn_cliente_2");

}
function Fechando_cliente() {
    document.getElementById("pn_cliente_2").setAttribute("class", "collapse multi-collapse collapse-horizontal col-12 my-2  row g-1 pn_cliente_2");
    document.getElementById("pn_oportunidade_2").setAttribute("class", "collapse multi-collapse multi-collapse_Filtro collapse-horizontal col-12 my-2   row g-1 pn_oportunidade_2");

}

function display_objetos(id_open, id_close) {

    const obj_close = document.getElementById(id_close);
    const obj_open = document.getElementById(id_open);
    obj_open.style.display = 'block';
    obj_close.style.display = 'none';

}
function open_filtro() {
    const container = document.getElementById("Filtro_container");
    const btn = document.getElementById("BtnFiltro");


    // Exiba o container
    container.style.display = 'block';


        btn.style.display = 'none';
  
}

function close_filtro() {
    const container = document.getElementById("Filtro_container");
    const btns = document.getElementById("BtnFiltro");

    // Remova a classe "custom-transition" para encerrar o efeito de transição personalizado

    // Oculte o container
    container.style.display = 'none';

    // Iterar sobre a lista de botões e definir o estilo para cada um
    for (const btn of btns) {
        btn.style.display = 'block';
    }
}


 
function FecharMenu(){ 
    document.getElementById("BtnFecharMenu").classList.add("d-none");
    document.getElementById("BtnAbrirMenu").classList.remove("d-none");
    document.getElementById("MenuClient").classList.add("d-none");
}

function  AbrirMenu(){
    document.getElementById("BtnFecharMenu").classList.remove("d-none");
    document.getElementById("BtnAbrirMenu").classList.add("d-none");
    document.getElementById("MenuClient").classList.remove("d-none");
}

function alerta(Tipo, menssage) {
    const IconeErro = 'exclamation-triangle-fill';
    const IconeSucesso = 'check-circle-fill';
    const IconeAlerta = 'info-circle-fill';
    if (Tipo == "Erro") {
        alert(menssage, 'danger', IconeErro)
    }

    if (Tipo == "Sucesso") {
        alert(menssage, 'success', IconeSucesso)
    }
    if (Tipo == "Alerta") {

        alert(menssage, 'primary', IconeAlerta)
    }

    function alert(message, type, Icone) {
        const wrapper = document.createElement('div')
        wrapper.innerHTML = [
            `   <div class="col-lg-12 mx-auto ">
                        <div class="alert alert-${type} alert_Remove alert-dismissible fade show col-12  my-2 mb-1  d-inline-flex" role="alert">
                            <svg class="bi me-3 " width="25" height="25" fill="currentColor">
                                <use href="../Imagens/icones/bootstrap-icons.svg#${Icone}" onerror="this.setAttribute('href','../Imagens/icones/bootstrap-icons.svg#${Icone}');" ></use></svg>
                            <Label runat="server" ID="lblMensagemErro" CssClass="alert p-1 text-uppercase  mx-2 col-12" Visible="false" >${message}</label>
                            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                        </div>
                    </div>`
        ].join('')
        document.getElementById("AlertaJS").append(wrapper);
        
    }


    $(function close_Alerta() {
        const exist = document.body.contains(document.querySelector('.alert_Remove'));
        if (exist == true) {
            $(document).ready(function () {
                setTimeout(function () {
                    $(".alert_Remove").fadeOut("slow", function () {
                        $(this).alert('close');
                    });
                }, 10000);
            });
        }
    });
} function loading(status) {
    const content = document.getElementById("container_loading");
    const loading = document.getElementById("loading");

    if (status == true) {
        loading.classList.remove("d-none");
        content.classList.add("d-none");
    } else {
        content.classList.remove("d-none");
        setTimeout(() => {
            loading.classList.add("d-none");
        }, 500);
    }
}

 

 //fomulario publicacao verificacao

$(function btn_ações_formularioPubli() {
        const exist = document.body.contains(document.querySelector('.Panel_form_publi'));
    if (exist == true) {
        var objBtn_cortar = document.querySelector('#btn_cortar_imagem');
        var Btn_Publicar_foto = document.querySelector('.BtnPublicar_foto');
        var Panel_form_publi = document.querySelector('.Panel_form_publi'); 
        var preview = document.querySelector('.preview');
        var Pn_slide_publi = document.querySelector('.Pn_slide_publi'); 
        var Imagem_Publi_1 = 'Imagem_Publi_1';
        var Imagem_Publi_2 = 'Imagem_Publi_2';
        var Imagem_Publi_3 = 'Imagem_Publi_3';  
        const File_1 = document.querySelector('.File_1');
        var btn_file1 = document.querySelector('.btn_file1');
        var btn_file1_remove = document.querySelector('.btn_file1_remove');

        var btn_file2 = document.querySelector('.btn_file2');
        const File_2 = document.querySelector('.File_2');
        var btn_file2_remove = document.querySelector('.btn_file2_remove');

        var btn_file3 = document.querySelector('.btn_file3');
        const File_3 = document.querySelector('.File_3');
        var btn_file3_remove = document.querySelector('.btn_file3_remove');


        var redimensionar = $('.preview').croppie({
            enableExif: true,
            enableOrientation: true,
            viewport: { width: 200, height: 200, type: 'square' },
            boundary: { width: 300, height: 300 },
        });

       

        ///btn 1
        btn_file1.addEventListener('click', () => {
            File_1.click(); 
            Btn_Publicar_foto.classList.add("d-none");
            File_1.addEventListener('change', function (algoNoFile) {
                const file = algoNoFile.target.files[0];
                if (file != null) {
                    objBtn_cortar.classList.add(`${Imagem_Publi_1}`);

                    var fileExtension = ['jpeg', 'jpg', 'png'];
                    if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
                        alerta("Erro", "erro Ao analizar o arquivo, use JPG ou PNG");
                        removeFileFromFileList();
                        function removeFileFromFileList(index) {
                            const dt = new DataTransfer()
                            const input = File_1
                            const { files } = input

                            for (let i = 0; i < files.length; i++) {
                                const file = files[i]
                                if (index !== i)
                                    dt.items.remove(file) // here you exclude the file. thus removing it.
                            }

                            input.files = dt.files // Assign the updates list
                        };

                    }

                    if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) > 0) {
                        OnSuccess(file, File_1, Imagem_Publi_1, btn_file1);
                        btn_file1_remove.classList.remove("d-none");
                        btn_file1.classList.add("d-none");

                    }
                }

                else {
                    btn_file1_remove.classList.add("d-none");
                    btn_file1.classList.remove("d-none");

                }

            });

 
        });

         /// btn 2 
        btn_file2.addEventListener('click', () => {
            File_2.click();
            File_2.addEventListener('change', function (algoNoFile) {

                const file = algoNoFile.target.files[0];
                if (file != null) {
                    objBtn_cortar.classList.add(`${Imagem_Publi_2}`);
                    var fileExtension = ['jpeg', 'jpg', 'png'];
                    //caso de erro ao analizar o arquivo
                    if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
                        alerta("Erro", "erro Ao analizar o arquivo, use JPG ou PNG");
                        removeFileFromFileList();
                        function removeFileFromFileList(index) {
                            const dt = new DataTransfer()
                            const input = File_2
                            const { files } = input

                            for (let i = 0; i < files.length; i++) {
                                const file = files[i]
                                if (index !== i)
                                    dt.items.remove(file) // here you exclude the file. thus removing it.
                            }

                            input.files = dt.files // Assign the updates list
                        };

                    }
                    // caso de sucesso ao analizar o arquivo
                    if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) > 0) {
                        OnSuccess(file, File_2, Imagem_Publi_2, btn_file2);
                        btn_file2_remove.classList.remove("d-none");
                        btn_file2.classList.add("d-none");

                    }
                } else {
                    btn_file2_remove.classList.add("d-none");
                    btn_file2.classList.remove("d-none");
                }


            });

        });
        
        ///btn 3 
        btn_file3.addEventListener('click', () => {
            File_3.click();
            File_3.addEventListener('change', function (algoNoFile) {
                const file = algoNoFile.target.files[0];
                if (file != null) {

                    objBtn_cortar.classList.add(`${Imagem_Publi_3}`);

                    var fileExtension = ['jpeg', 'jpg', 'png'];
                    if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) == -1) {
                        alerta("Erro", "erro Ao analizar o arquivo, use JPG ou PNG");
                        removeFileFromFileList();
                        function removeFileFromFileList(index) {
                            const dt = new DataTransfer()
                            const input = File_3
                            const { files } = input

                            for (let i = 0; i < files.length; i++) {
                                const file = files[i]
                                if (index !== i)
                                    dt.items.remove(file) // here you exclude the file. thus removing it.
                            }

                            input.files = dt.files // Assign the updates list
                        };

                    }

                    if ($.inArray($(this).val().split('.').pop().toLowerCase(), fileExtension) > 0) {
                        OnSuccess(file, File_3, Imagem_Publi_3, btn_file3);
                        btn_file3_remove.classList.remove("d-none");
                        btn_file3.classList.add("d-none");
                    }
                }
                else {
                    btn_file3_remove.classList.add("d-none");
                    btn_file3.classList.remove("d-none");
                }

            });
        });

       
        function OnSuccess (file, FileUP, CampoImg, btn_file) {

            // btn imagen off 
            const reader = new FileReader();
            preview.classList.remove("d-none");
            reader.onload = function (e) {
                redimensionar.croppie('bind', {
                    url: e.target.result
                });
                objBtn_cortar.classList.remove("disabled");
                objBtn_cortar.classList.remove("d-none");
                Panel_form_publi.classList.add("d-none");

            }
            $(`.${CampoImg}`).on('click', function () {
                redimensionar.croppie('result', {
                    type: 'canvas',// yipo de arquivos permitidos 
                    size: 'viewport',//o tamanho da imagem cortada
                    quality: 0, format: 'png',

                }).then(function (img) {
                    if (CampoImg != null) {
                        function dataURLtoFile() {
                            dataurl = img;
                            filename = `imag_cortada_${nume}_${nume}.png`;
                            var arr = dataurl.split(','), mime = arr[0].match(/:(.*?);/)[1],
                                bstr = atob(arr[1]), n = bstr.length, u8arr = new Uint8Array(n);
                            while (n--) {
                                u8arr[n] = bstr.charCodeAt(n);
                            }
                            return Imagem_cortada = new File([u8arr], filename, { type: mime });

                        }
                        const nume = Math.floor(1000000 * Math.random()).toString();
                        var Arquivo_cortado = dataURLtoFile();
                        const url_Img = URL.createObjectURL(Arquivo_cortado);
                        // CampoImg.src = img;
                        removeFileFromFileList(btn_file)
                        function removeFileFromFileList(index) {
                            const dt = new DataTransfer()
                            const input = FileUP
                            const { files } = input

                            for (let i = 0; i < files.length; i++) {
                                const file = files[i]
                                if (index !== i)
                                    dt.items.add(Arquivo_cortado) // here you exclude the file. thus removing it.
                            }

                            input.files = dt.files // Assign the updates list
                        };
                        preview.classList.add("d-none");
                        Panel_form_publi.classList.remove("d-none");
                        Pn_slide_publi.classList.remove("d-none");
                        objBtn_cortar.classList.add("d-none");
                        objBtn_cortar.classList.remove(`${CampoImg}`);
                        const Item_painel = document.querySelector(".Pn_item_publi");
                        const id_cod = img_valor(CampoImg);
                        
                        var img_campo = document.querySelector(`.${id_cod.id_imagem}`);
                        const exist_img = document.body.contains(img_campo);
                        //caso o campo exista a url é alterada, caso nao exista é gerado um novo campo div com a img
                        if (exist_img == true) {
                            img_campo.src = url_Img;
                        } else {
                            const wrapper = document.createElement('div')
                            wrapper.innerHTML = [
                                `   <img class="${id_cod.id_imagem} img_fluid " src=${url_Img} />`
                            ].join('')
                            wrapper.classList.add(`col-3`);
                            wrapper.classList.add(`${id_cod.id_campo}`);
                            Item_painel.append(wrapper);
                        }
                        //aqui identificamos qual campo está sendo iserido o avalor, para inserir os id no campo e na img, para remover ou alterar a url da img
                        function img_valor(Campo_img) {
                            if (Campo_img == 'Imagem_Publi_1') { let  id_campo = 'id_campo_1', id_imagem = 'id_img_1'; return { id_campo, id_imagem }; }
                            else if (Campo_img == 'Imagem_Publi_2') { let id_campo = 'id_campo_2', id_imagem = 'id_img_2'; return { id_campo, id_imagem }; }
                            else if (Campo_img == 'Imagem_Publi_3') { let id_campo = 'id_campo_3', id_imagem = 'id_img_3'; return { id_campo, id_imagem }; }
                        }
                        
                    }
                    Btn_Publicar_foto.classList.remove("d-none");

                    CampoImg = null;
                });
            });
            reader.readAsDataURL(file);

        }
    }

});
function Removendo_img_file_publicacao(btn) {

    


    if (btn == 1) {
        const File_1 = document.querySelector('.File_1');

        removendo_doFile(File_1);
        const campo_img_select = document.querySelector(`.id_campo_1`);
        if (campo_img_select != null) {
            campo_img_select.parentNode.removeChild(campo_img_select);
            //alterando btn (remove escondendo) (buscar visivel)
            document.querySelector('.btn_file1_remove').classList.add("d-none");
            document.querySelector('.btn_file1').classList.remove("d-none");
            document.querySelector('.BtnPublicar_foto').classList.add("d-none");


        }
    } else
    if (btn == 2) {
        const File_2 = document.querySelector('.File_2');
        removendo_doFile(File_2);
        const campo_img_select = document.querySelector(`.id_campo_2`);
        if (campo_img_select != null) {
            campo_img_select.parentNode.removeChild(campo_img_select)
            //alterando btn (remove escondendo) (buscar visivel)
            document.querySelector('.btn_file2_remove').classList.add("d-none");
            document.querySelector('.btn_file2').classList.remove("d-none");
        }
    }else if (btn == 3) {
        const File_3 = document.querySelector('.File_3');

        removendo_doFile(File_3);
        const campo_img_select = document.querySelector(`.id_campo_3`);
        if (campo_img_select != null) {
            campo_img_select.parentNode.removeChild(campo_img_select);
            //alterando btn (remove escondendo) (buscar visivel)
            document.querySelector('.btn_file3_remove').classList.add("d-none");
            document.querySelector('.btn_file3').classList.remove("d-none");
        }
    }
    function removendo_doFile(File_obj,index) {
        const dt = new DataTransfer()
        const input = File_obj
        const { files } = input

        for (let i = 0; i < files.length; i++) {
            const file = files[i]
            if (index !== i)
                dt.items.remove(file) // here you exclude the file. thus removing it.
        }

        input.files = dt.files // Assign the updates list
    }
}
function VerificarLinkYoutube() {

    const Panel_form_publi = document.querySelector('.Panel_form_publi');
    const iframe_publicacao_Video = document.querySelector('.iframe_publicacao_Video');
    const UrlYoutube1 = document.querySelector('.UrlYoutube1');
    const txtMenssagem = document.querySelector('.txtMenssagem');
    const iframe_youtube_1 = document.querySelector('.iframe_youtube_1');
    const iframe_youtube_2 = document.querySelector('.iframe_youtube_2');
    if (txtMenssagem.value != "") {
        iframe_youtube_1.setAttribute("src", `${UrlYoutube1.value}`)

        if (UrlYoutube1.value != "") {
            const src = iframe_youtube_1.getAttributeNode("src").nodeValue;

            let algoAmais = src.split("&");
            const verificar = src.includes("/watch?v=");
            const verificar_2 = src.includes(".be/");
            if (algoAmais.length <= 1) {
                Alterado = src.replace('watch?v=', 'embed/');
                iframe_youtube_1.setAttribute("src", Alterado);
                UrlYoutube1.value = Alterado;

            } else if (verificar != false) {

                Alterado = algoAmais[0].replace('watch?v=', 'embed/');
                UrlYoutube1.value = Alterado;

                iframe_youtube_1.setAttribute("src", Alterado);
            }
            else if (verificar_2 != false) {
                Alterado = algoAmais[0].replace('.be/', 'be.com/embed/');
                UrlYoutube1.value = Alterado;

                iframe_youtube_1.setAttribute("src", Alterado);
            }
            else {
                Alterado = algoAmais[0].replace('.com/ ', '.com/embed/');
                iframe_youtube_1.setAttribute("src", Alterado);
                UrlYoutube1.value = Alterado;

            }

            Panel_form_publi.classList.add("d-none");
            iframe_publicacao_Video.classList.remove("d-none");
            UrlYoutube1.classList.remove('d-none');
            alerta("Alerta", "Verificamos seu link, nos confirme se o video está Funcionando corretamente.");

        }
    else {
        alerta("Erro", "Ops, Não encontramos algo no campo Link");
    }

    } else {
        alerta("Alerta", "Ops, é necessario adicionar uma breve descrição sobre sua Publi");
    }
 

}  


$(function MinimizarTextos() {
    // Seleciona todos os elementos que possuem a classe "cont-text" ou uma classe que começa com "cont-text-"
    const elements = document.querySelectorAll('[class*="cont-text-"]');

    elements.forEach(element => {
        const className = element.className;

        // Verifica se a classe corresponde ao padrão "cont-text-{valor}" ou "cont-text-{valor}-click"
        const match = className.match(/cont-text-(\d+)(?:-click)?/);
        if (match) {
            const limite = parseInt(match[1]);
            const texto = element.innerText;
            const quebrasDeLinha = texto.split('\n').length - 1;

            if (texto.length > limite || quebrasDeLinha > 3) {
                const textoCurto = texto.substring(0, limite) + "...";

                // Verifica se a classe contém a palavra "-click"
                if (className.includes("-click")) {
                    // Adiciona um evento de clique ao elemento
                    $(element).click(function () {
                        if ($(this).hasClass("expandido")) {
                            // Se o texto estiver expandido, minimiza novamente
                            $(this).removeClass("expandido");
                            $(this).html(textoCurto);
                        } else {
                            // Se o texto estiver minimizado, expande
                            $(this).addClass("expandido");
                            $(this).html(texto);
                        }
                    });
                }  
                    // Define o texto curto no elemento
                    $(element).html(textoCurto);
            } else {
                // O texto não excede o limite, então exibe-o normalmente
                $(element).html(texto);
            }
        } else {
            // Caso a classe não corresponda ao padrão, é possível que haja um erro de formatação
            console.error(`Erro de formatação na classe: ${className}`);
        }
    });
}); 

$(function CarrocelProfissinais() {

    var loopProfissionais = document.querySelectorAll(".loop-profissionais");

    // Percorra a lista de componentes
    loopProfissionais.forEach(function (loopProfissional) {
        // Encontre os elementos dentro de cada componente
        var itemContainer = loopProfissional.querySelector(".itemContainer");
        var btnAnterior = loopProfissional.querySelector(".btnAnterior");
        var btnProximo = loopProfissional.querySelector(".btnProximo");

        var currentIndex = 0;
    var itemsPerPage = getItemsPerPage();

function getItemsPerPage() {
    var tamanho_tela = window.innerWidth;

    if (tamanho_tela <= 768) {
        return 2; // Tela de celulares (de 577px até 768px)
    } else if (tamanho_tela <= 992) {
        return 3; // Telas de tablets (acima de 768px)
    } else {
        return 4; // Telas de monitores (acima de 992px)
    }
}

        // Exiba os itens iniciais
        displayItems(currentIndex, itemContainer, itemsPerPage);
        updateButtonVisibility(btnAnterior, btnProximo, itemContainer, itemsPerPage, currentIndex);

        // Adicione o evento de clique no botão "Anterior"
        btnAnterior.addEventListener("click", function () {
            if (currentIndex > 0) {
                currentIndex -= itemsPerPage;
                displayItems(currentIndex, itemContainer, itemsPerPage);
                updateButtonVisibility(btnAnterior, btnProximo, itemContainer, itemsPerPage, currentIndex);
                scrollItemsIntoView(itemContainer, currentIndex, itemsPerPage);
            }
        });

        // Adicione o evento de clique no botão "Próximo"
        btnProximo.addEventListener("click", function () {
            var colProfissional = itemContainer.getElementsByClassName("col-profissional");
            if (currentIndex + itemsPerPage < colProfissional.length) {
                currentIndex += itemsPerPage;
                displayItems(currentIndex, itemContainer, itemsPerPage);
                updateButtonVisibility(btnAnterior, btnProximo, itemContainer, itemsPerPage, currentIndex);
                scrollItemsIntoView(itemContainer, currentIndex, itemsPerPage);
            }
        });
    });
    // Função para exibir os itens com base no índice atual
    function displayItems(index, itemContainer, itemsPerPage) {
        var colProfissional = itemContainer.getElementsByClassName("col-profissional");
        for (var i = 0; i < colProfissional.length; i++) {
            if (i >= index && i < index + itemsPerPage) {
                colProfissional[i].style.display = "block";
            } else {
                colProfissional[i].style.display = "none";
            }
        }
    }

    // Função para atualizar a visibilidade dos botões
    function updateButtonVisibility(btnAnterior, btnProximo, itemContainer, itemsPerPage, currentIndex) {
        if (currentIndex === 0) {
            btnAnterior.classList.add("d-none");
        } else {
            btnAnterior.classList.remove("d-none");
        }

        var colProfissional = itemContainer.getElementsByClassName("col-profissional");
        if (currentIndex + itemsPerPage >= colProfissional.length) {
            btnProximo.classList.add("d-none");
        } else {
            btnProximo.classList.remove("d-none");
        }
    }
    // Função para rolar os itens para a exibição atual
    function scrollItemsIntoView(itemContainer, currentIndex, itemsPerPage) {
        var colProfissional = itemContainer.getElementsByClassName("col-profissional");
        var firstVisibleItemIndex = currentIndex;
        var lastVisibleItemIndex = currentIndex + itemsPerPage - 1;

        colProfissional[firstVisibleItemIndex].scrollIntoView({
            behavior: "smooth",
            block: "nearest",
        });

        setTimeout(function () {
            for (var i = 0; i < colProfissional.length; i++) {
                if (i < firstVisibleItemIndex || i > lastVisibleItemIndex) {
                    colProfissional[i].style.display = "none";
                }
            }
        }, 500);
    }
});
  
function getCookie(name) {
    var cookies = document.cookie.split(';');
    for (var i = 0; i < cookies.length; i++) {
        var cookie = cookies[i].trim();
        if (cookie.startsWith(name + '=')) {
            return decodeURIComponent(cookie.substring(name.length + 1));
        }
    }
    return null;
}
 function callServerMethod(methodName, params, successCallback, errorCallback) {
    $.ajax({
        type: "POST",
        url: "../GlobalServices.asmx/" + methodName,
        data: JSON.stringify(params),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            if (response.hasOwnProperty("d")) {
                successCallback(response.d);
            } else {
                errorCallback("Resposta inválida do servidor.");
            }
        },
     error: function (xhr, status, error) {
    console.log("Erro na chamada AJAX: " + status + " - " + error);
    console.log("Resposta completa do servidor: " + xhr.responseText);
}
    });
}


