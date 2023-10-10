<%@ Page Title="" Language="C#" MasterPageFile="../pages/Default.Master" AutoEventWireup="true" CodeBehind="View_Publicacao.aspx.cs" Inherits="FW.UI.pro.View_Publicacao" %>

<%@ MasterType VirtualPath="../pages/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="col-md-11  col-xl-11 mx-auto   order-2">
        <div class="hstack gap-3 mx-3">
            <div class=" fs-3 fw-bold text-uppercase font-monospace  ">Publicaçães</div>
            <asp:LinkButton ID="link_Editar_Publi" runat="server" class=" btn  ms-auto" typeof="button" href="Formulario_publicacao.aspx">
                        <svg class="bi   img-fluid rounded  " width="30" height="30" role="img">
                            <use href="../Imagens/icones/bootstrap-icons.svg#pencil-square"></use></svg>
            </asp:LinkButton>
        </div>
    </div>



    <div class="  col-sm-12  col-lg-8 col-xxl-6 small   mx-auto my-3   ">
        <div id="card__public" class="  card col-12 rounded-3 ">
            <div class=" card-header  p-3">
                <div class="toast-header">
                    <asp:Image runat="server" ID="Imagem_Perfil_Publi" class="bi img-fluid rounded me-2" Width="50" Height="50" role="img" onerror="this.onerror=null; this.src='../Cliente/Foto_Cliente/undraw_resume_folder_re_e0bi.svg'" />
                    <asp:Label runat="server" ID="Nome_cliente" Font-Size="Medium" CssClass=" font-monospace  me-auto strong">  </asp:Label>
                    <asp:Label runat="server" ID="Date_Publicacao" Font-Size="X-Small" CssClass="me-2 Date_Alter_Tempo " />
                    <div class="flex-shrink-0 dropdown">
                        <a href="#" id="dd_menu" class="d-block link-dark text-decoration-none  " data-bs-toggle="dropdown" aria-expanded="false">
                            <svg class="bi   img-fluid rounded  float-end  " width="20" height="20" role="img">
                                <use href="../Imagens/icones/bootstrap-icons.svg#list"></use></svg>
                        </a>
                        <ul class="dropdown-menu text-small shadow" id="ul_menu" style="">
                            <li><a class="dropdown-item" href="Formulario_Publicacao.aspx?id_publicacao=<%# Eval("id_Publicacao") %>"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Editar</font></font></a></li>
                            <li><a class="dropdown-item" href="#"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Ver Profissional</font></font></a></li>
                            <li>
                                <hr class="dropdown-divider">
                            </li>
                            <li><a class="dropdown-item" href="#"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Deletar</font></font></a></li>
                        </ul>
                    </div>
                </div>
            </div>

            <div class="Main_card  ">
                <div class="toast-body  bg-white p-3">
                    <asp:Label runat="server" ID="Descricao_Publicacao" Font-Size="Larger" CssClass="me-2  "> </asp:Label>
                </div>
                <asp:Panel runat="server" ID="Pn_img" data-slide="slide" class=" d-none slide m-0 container_slide Pn_slide" Style="max-width: 100%; box-shadow: none;">
                    <div class="slide-items" style="border-radius: 0px;">
                        <asp:Image runat="server" ID="Imagem_Publi_1" Visible="false" Style="border-radius: 0px;" CssClass="img-fluid card-img Img_slide " onerror="this.onerror=null; this.src='../Cliente/Foto_Cliente/undraw_resume_folder_re_e0bi.svg'" alt="Img 1" />
                        <asp:Image runat="server" ID="Imagem_Publi_2" Visible="false" Style="border-radius: 0px;" CssClass="img-fluid card-img Img_slide " onerror="this.onerror=null; this.src='../Cliente/Foto_Cliente/undraw_resume_folder_re_e0bi.svg'" alt="Img 2" />
                        <asp:Image runat="server" ID="Imagem_Publi_3" Visible="false" Style="border-radius: 0px;" CssClass="img-fluid card-img Img_slide" onerror="this.onerror=null; this.src='../Cliente/Foto_Cliente/undraw_resume_folder_re_e0bi.svg'" alt="Img 3" />
                    </div>
                    <nav class="slide-nav   ">
                        <div class="slide-thumb " style=""></div>
                        <input runat="server" type="button" class="slide-prev   opacity-0 " />
                        <input runat="server" type="button" class="slide-next  opacity-0 " />
                    </nav>
                </asp:Panel>
                 <asp:Panel runat="server" ID="Pn_Video" data-slide="slide"   class=" slide_publicacao_repeter_Video d-none slide m-0 container_slide  " Style="max-width: 100%; box-shadow: none;" >
                    <iframe   height="315" class="d-none iframe_youtube_1 container-fluid  " target="_parent" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"  allowfullscreen="allowfullscreen" ></iframe>
                    <iframe   height="315" class="d-none iframe_youtube_2 container-fluid  " target="_parent"   title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen="allowfullscreen"></iframe>
                </asp:Panel>

            </div>
            <asp:Repeater ID="Rpt_Comentario_Publicacao" runat="server"   >
                <ItemTemplate >
                    <div class="footer_card card-footer   px-1   font-monospace text-uppercase fw-bold Rpt_Comentario_Publicacao d-none">

                        <div class="list-group w-auto">

                            <a href="View_Perfil.aspx?id_comentarios" class="list-group-item bg-transparent border-0 list-group-item-action d-flex gap-3 py-1" aria-current="true">
                                <asp:Image runat="server" ImageUrl="https://github.com/twbs.png" alt="twbs" Width="32" Height="32" class="rounded-circle flex-shrink-0" />
                                <div class="d-flex gap-2 w-100 justify-content-between">
                                    <div>
                                        <asp:Label runat="server" class=" label_comentario text-start mt-0 mb-2" Style="vertical-align: inherit;"> Título do item do grupo de lista </asp:Label>
                                        <asp:Label runat="server" class="mb-0 bg-body opacity-75" Style="vertical-align: inherit;">Algum conteúdo de espaço reservado em um parágrafo.</asp:Label>
                                    </div>
                                    <asp:Label runat="server" class="opacity-50 text-nowrap" Style="vertical-align: inherit;">agora</asp:Label>
                                </div>
                            </a>

                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <a   onclick="Open_Comentarios()" type="button"  href="#" id="painel_Btn_Comentarios"  class="footer_card card-footer panel_btn_comentario       g-4  gap-2  px-3  text-center  font-monospace text-uppercase fw-bold"  >Comentarios</a>
            <asp:Panel runat="server" ID="Form_Comentar"  class="panel_Form_comentar  footer_card card-footer  d-none g-4  gap-2  px-3   font-monospace text-uppercase fw-bold">
                    <div class="col-10  float-start  ">
                        <asp:TextBox type="search" class="form-control   form-control-sm col-10" id="txtcomentario" placeholder="Comentar..." aria-label="Pesquisa"   runat="server" />

                    </div>
                    <div class="col-2 float-end   ">
                        <asp:Button ID="BtnEnviar_Comentario"  runat="server" type="button"   OnClick="EnviarComentarioPublicacao" class="btn col btn-sm btn-primary float-end " Text="Enviar" />
                    </div>
            </asp:Panel>
        </div>
    </div> 


    <%--       <asp:Repeater ID="Rpt_Publicacao_text" runat="server" Visible="false">
                                    <ItemTemplate>

                    <div class="  col-sm-12  col-lg-6 col-xxl-4      ">
                        <div id="card___public" class="  card col-12 rounded-3 ">
                            <div class=" card-header   p-3">
                                <div class="toast-header small ">
                                    <svg class="bi   img-fluid rounded me-2" width="25" height="25" role="img">
                                        <use href="../Imagens/icones/bootstrap-icons.svg#bookmark-star"></use></svg>
                                    <asp:Label ID="lblNome_Publi" Font-Size="X-Small" runat="server" class="me-auto  fw-bold  ">Bootstrap</asp:Label>
                                    <small class="me-2">11 mins ago</small>
                                    <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
                                </div>
                            </div>
                            <div class="Main_card  ">
                                <div class="toast-body  bg-white p-3">
                                    Hello, world! This is a toast message.
                                </div>

                                <div data-slide="slide" class="  slide m-0  " style="max-width: 100%; box-shadow: none;">
                                    <div class="slide-items" style="border-radius: 0px;">
                                        <img src="../Imagens/Imagens.<span class="nome-empresa"></span>.jpg" alt="Img 1">
                                        <img src="../Imagens/<span class="nome-empresa"></span>.Imagem.jpg" alt="Img 2">
                                    </div>
                                    <nav class="slide-nav ">
                                        <div class="slide-thumb " style=""></div>
                                        <input runat="server" type="button" class="slide-prev   opacity-0 " />
                                        <input runat="server" type="button" class="slide-next  opacity-0 " />
                                    </nav>
                                </div>


                            </div>
                            <div class="footer_card card-footer">
                            </div>

                        </div>
                    </div>
                                                   </ItemTemplate>
                                </asp:Repeater>--%>

    <script type="text/javascript">
        function Open_Comentarios()
        {
            const Form_Comentar = document.querySelector('.panel_Form_comentar');
            Form_Comentar.classList.remove("d-none");
            document.querySelector('.panel_btn_comentario').classList.add("d-none")
          const rpt_comentarios = document.querySelector('.Rpt_Comentario_Publicacao')
            const exist1 = document.body.contains(rpt_comentarios);
            if (exist1 == true) {
                rpt_comentarios.classList.remove("d-none");
            }
        }

    </script>
</asp:Content>
