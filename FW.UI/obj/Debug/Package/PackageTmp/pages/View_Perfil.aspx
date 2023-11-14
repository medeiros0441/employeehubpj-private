<%@ Page Title="" Language="C#" MasterPageFile="../Default.Master" AutoEventWireup="true" CodeBehind="View_Perfil.aspx.cs" Inherits="FW.UI.pages.View_Perfil" %>
<%@ Register TagName="RptVagas" TagPrefix="uc" Src="../ascx/RptVagas.ascx" %>
<%@ MasterType VirtualPath="../Default.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="Pn_ClienteOFF" runat="server" Visible="false">
                        <img src="../Imagens/undraw/undraw_World_re_768g.svg"    class="img-fluid   container mx-auto col-10 d-flex  " />

                    </asp:Panel>

    <asp:panel runat="server" ID="PnCliente" class="container-fluid g-3   m-0 p-0 "  >
          <%--panel Profissional --%>
             
         <asp:panel runat="server" ID="PnProfissional" Visible="false" class="container-fluid m-0 p-0"> 

    <div class="row my-4  clearfix container mx-auto">

        <div class="col-md-3  col-7 my-auto  mx-sm-auto h-100 p-3 mx-auto  order-1"  >
            <asp:Image runat="server"  ID="ImagePro"   CssClass="  img-fluid mx-auto rounded" onerror="this.onerror=null; this.src='../Cliente/Foto_Cliente/undraw_resume_folder_re_e0bi.svg'" alt="..." />
        </div>
        <div class="col-sm-9 order-2 mx-auto">
            <div class="row  gy-2 p-2 mb-3   ">
                <div class="col-sm-12 p-0 px-md-2">
                    <asp:Label runat="server" CssClass="form-text col-md-10 font-monospace" Font-Size="X-Large" ID="lblNomePro" />
                </div>
                <div class="col-sm-auto col-12 p-0 m-0 px-md-2">
                       <asp:label runat="server" Font-Size="Medium"  class=" font-monospace fw-semibold "  Text="Formação Acadêmica: " />
                    <asp:Label ID="lblFormacaoEscolar" CssClass="form-text font-monospace" Font-Size="Medium" runat="server" />
                </div>
                <div class="col-sm-auto col-12 p-0 m-0 px-md-2 px-md-2">
                       <asp:label runat="server" Font-Size="Medium"  class=" font-monospace fw-semibold "  Text="Data de Nascimento: " />
                    <asp:Label runat="server" ID="DataAniversario" CssClass="form-text font-monospace" Font-Size="Medium" />
                </div>
                <div class="col-sm-auto col-12 p-0 m-0 px-md-2">
                     <asp:label runat="server" Font-Size="Medium"  class=" font-monospace fw-semibold " Text="Sexo: "/>
                    <asp:Label runat="server" ID="lblSexo" CssClass="form-text font-monospace" Font-Size="Medium" />
                </div>
<hr class="my-1  w-75 mx-auto">
                <div class="col-sm-auto col-12 p-0 m-0 px-md-2">
                    <asp:label runat="server" Font-Size="Medium"  class=" font-monospace fw-semibold  " Text="Biografia Acadêmica"/>
                    <asp:Label ID="lblBiografiaPro" runat="server" CssClass="cont-text-400-click   form-text font-monospace" Font-Size="Medium" />

                </div>


            </div>

        </div>

    </div>
                    </asp:panel>
        <asp:panel runat="server" ID="PnEmpresa" Visible="false"> 

    <div class="row container my-4  clearfix    mx-auto">

        <div class="col-sm-3 my-auto  h-100 p-3 mx-auto  order-1"  >
            <asp:Image runat="server" ID="ImageEmpresa" CssClass="  img-fluid mx-auto rounded" onerror="this.onerror=null; this.src='../Cliente/Foto_Cliente/undraw_resume_folder_re_e0bi.svg'" alt="..." />
        </div>

        <div class="col-sm-9 order-2">
            <div class="row  gy-2 p-2 mb-3  ">
                <div class="col-sm-12">
                    <label class="form-label  font-monospace fw-bold">Nome Empresa</label>
                    <asp:Label runat="server" CssClass="form-text col-md-10" ID="LblNomeEmpresa" />
                </div>
                <div class="col-sm-12  ">
                    <label class="form-label  font-monospace fw-bold">Sobre</label><br />
                    <asp:Label ID="lblBiografiaEmpresa" runat="server" CssClass=" cont-text-400-click blockquote form-text" />
                </div>
            </div>
        </div>

    </div>
                    </asp:panel>

         
       
    <div class="row g-1">
                <%--panel Publicacao_status Off --%>
                <asp:panel runat="server" ID="PnPublicacao" Visible="false"> 

        <div class="col-md-8 d-none col-xl-9   order-2">
            <div class="hstack gap-3 mx-3">
                <div class=" fs-3 fw-bold text-uppercase font-monospace  ">Publicaçães</div>
                <a runat="server" class=" btn  ms-auto" typeof="button" href="Formulario_publicacao.aspx">
                    <svg class="bi   img-fluid rounded  " width="30" height="30" role="img">
                        <use href="../Imagens/icones/bootstrap-icons.svg#plus-lg"></use></svg>
                </a>
            </div>
            <!-- Campo img caso o profissional nao tenha publicado nada-->
            <asp:Panel ID="PnImage_publicacao" runat="server" Visible="false" CssClass="mx-auto col-10 my-3">
                <img src="../Imagens/Undraw/undraw_Social_growth_re_tjy9.svg" class="img-fluid   " />
            </asp:Panel>
            <!-- Card publicacao SemFOTO com foto ou link do youtube analise via js e C#-->
            <asp:Repeater ID="Rpt_Publicacao" runat="server" Visible="false">
                <ItemTemplate>
                    <asp:Panel runat="server" class="  flex-row row py-2 mx-2  g-2  gy-2   " ID="Card_Publi_cols">
                        <div class="  col-sm-12  col-lg-11 col-xxl-6 small   mx-auto     ">
                            <div id="card__public" class="  card col-12 rounded-3 ">
                                <div class=" card-header  p-3">
                                    <div class="toast-header">
                                        <image id="Imagem_Perfil_Publi" src="<%# DataBinder.Eval(Container.DataItem, "Url_Foto").ToString().Replace("~", ".") %>" class="bi img-fluid rounded me-2" width="50" height="50" role="img" onerror="this.onerror=null; this.src='../Cliente/Foto_Cliente/undraw_resume_folder_re_e0bi.svg'"></image>
                                        <asp:Label runat="server" ID="Nome_cliente" Font-Size="Medium" CssClass=" font-monospace  me-auto strong"><%# DataBinder.Eval(Container.DataItem, "Usuario") %></asp:Label>
                                        <div>
                                                <asp:Label runat="server"  class="small  Date_dia_mes me-2"   ><%# DataBinder.Eval(Container.DataItem, "Data_Publicacao").ToString() %></asp:Label>
                                        </div>

                                        <div class="flex-shrink-0 dropdown">
                                            <a href="#" id="dd_menu" class="d-block link-dark text-decoration-none  " data-bs-toggle="dropdown" aria-expanded="false">
                                                <svg class="bi   img-fluid rounded  float-end  " width="20" height="20" role="img">
                                                    <use href="../Imagens/icones/bootstrap-icons.svg#list"></use></svg>
                                            </a>
                                            <ul class="dropdown-menu text-small shadow" id="ul_menu"  >
                                                <li><a class="dropdown-item" href="View_Publicacao.aspx?id_publicacao=<%# DataBinder.Eval(Container.DataItem, "id_Publicacao") %>"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">ver detalhes...</font></font></a></li>
                                                <li><a class="dropdown-item" href="#"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Configurações</font></font></a></li>
                                                <li><a class="dropdown-item" href="#"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Perfil</font></font></a></li>
                                                <li>
                                                    <hr class="dropdown-divider">
                                                </li>
                                                <li><a class="dropdown-item" href="#"><font style="vertical-align: inherit;"><font style="vertical-align: inherit;">Sair</font></font></a></li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>

                                <div class="Main_card  ">
                                    <div class="toast-body  bg-white p-3">
                                        <asp:Label runat="server" ID="Descricao_Publicacao" Font-Size="Larger" CssClass="me-2  "> <%# DataBinder.Eval(Container.DataItem, "Descricao_Publicacao") %> </asp:Label>
                                    </div>
                                    <asp:Panel runat="server" ID="Pn_img" data-slide="slide" class=" slide_publicacao_repeter_imagens d-none slide m-0 container_slide  " Style="max-width: 100%; box-shadow: none;">
                                        <div class="slide-items" style="border-radius: 0px;">
                                            <image id="Imagem_Publi_1" src="<%# DataBinder.Eval(Container.DataItem, "URL_Imagen1").ToString().Replace("~", ".") %>" style="border-radius: 0px;" class="img-fluid card-img Img_Publicacao d-none  " alt="Img 1"></image>
                                            <image id="Imagem_Publi_2" src="<%# DataBinder.Eval(Container.DataItem, "URL_Imagen2").ToString().Replace("~", ".") %>" style="border-radius: 0px;" class="img-fluid card-img Img_Publicacao  d-none " alt="Img 2"></image>
                                            <image id="Imagem_Publi_3" src="<%# DataBinder.Eval(Container.DataItem, "URL_Imagen3").ToString().Replace("~", ".") %>" style="border-radius: 0px;" class="img-fluid card-img Img_Publicacao  d-none" alt="Img 3"></image>
                                        </div>
                                        <nav class="slide-nav   ">
                                            <div class="slide-thumb " ></div>
                                            <input runat="server" type="button" class="slide-prev   opacity-0 " />
                                            <input runat="server" type="button" class="slide-next  opacity-0 " />
                                        </nav>
                                    </asp:Panel>

                                    <asp:Panel runat="server" ID="Pn_Video" data-slide="slide" class=" slide_publicacao_repeter_Video slide m-0 container_slide  " Style="max-width: 100%; box-shadow: none;">
                                        <iframe height="315" class="d-none iframe_youtube container-fluid  " target="_parent" src="<%# DataBinder.Eval(Container.DataItem, "URL_Video1") %>" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                                        <iframe height="315" class="d-none iframe_youtube container-fluid  " target="_parent" src="<%# DataBinder.Eval(Container.DataItem, "URL_Video2")  %>" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                                    </asp:Panel>
                                </div>
                                <asp:Repeater ID="Rpt_Comentario_Publicacao" runat="server" Visible="false">
                                    <ItemTemplate>
                                        <div class="footer_card card-footer   px-1   font-monospace text-uppercase fw-bold">

                                            <div class="list-group w-auto">

                                                <a href="View_Perfil.aspx?id_comentarios" class="list-group-item bg-transparent border-0 list-group-item-action d-flex gap-3 py-1" aria-current="true">
                                                    <asp:Image runat="server" ImageUrl="https://github.com/twbs.png" alt="twbs" Width="32" Height="32" class="rounded-circle flex-shrink-0" />
                                                    <div class="d-flex gap-2 w-100 justify-content-between">
                                                        <div>
                                                            <asp:Label runat="server" class=" text-start mt-0 mb-2" Style="vertical-align: inherit;"> Título do item do grupo de lista </asp:Label>
                                                            <asp:Label runat="server" class="mb-0 bg-body opacity-75" Style="vertical-align: inherit;">Algum conteúdo de espaço reservado em um parágrafo.</asp:Label>
                                                        </div>
                                                        <asp:Label runat="server" class="opacity-50 text-nowrap" Style="vertical-align: inherit;">agora</asp:Label>
                                                    </div>
                                                </a>

                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>

                                <asp:Panel runat="server" ID="panel_SemComentario" Visible="false" class="footer_card card-footer  g-4  gap-2  px-3   font-monospace text-uppercase fw-bold">
                                    <div class="col-10  float-start  ">
                                        <asp:TextBox type="search" class="form-control  form-control-sm col-10" ID="txtcomentario" placeholder="Comentar..." aria-label="Pesquisa" runat="server" />

                                    </div>
                                    <div class="col-2 float-end   ">
                                        <asp:Button ID="BtnEnviar_Comentario" runat="server" type="button"  class="btn col btn-sm btn-primary float-end " Text="Enviar" />
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>

                    </asp:Panel>


                </ItemTemplate>
            </asp:Repeater>
        </div>
                    </asp:panel>

        <div class="col-md-4_caso_painelPubliativo col-xl-3_caso_painelPubli_ativo mx-auto    col-12 col-lg-10 order-1 order-md-2">
            <div class="container-fluid p-0 m-0">
                <%--Card rede-social--%>
            <asp:Panel runat="server" ID="PnRedeSocial"  CssClass="  col-11 col-sm-8 mx-auto ">
                        <div class="card-header rounded-top p-2" style="background-color: var(--laranja)">
                            <svg class="bi figure-img img-fluid" width="25" height="25" role="img">
                                <use href="../Imagens/icones/bootstrap-icons.svg#bookmark-star"></use></svg>
                            <label class="fs-5 ms-1 fw-bold text-uppercase font-monospace">contato</label>
                       

                        </div>
                        <div class="card-body pb-0  p-4 pt-1 bg-light mb-3  shadow rounded-bottom">
                            <asp:Panel runat="server" ID="PnRedeInfo" Visible="false">

                                <div class="row text-center  pb-3">
                                    <asp:HyperLink ID="HLEmail" runat="server"    class="col-12 text-start  font-monospace  fw-bolder text-decoration-none">
                                        <svg class="bi    " width="20" height="20" fill="currentColor">
                                            <use href="../Imagens/icones/bootstrap-icons.svg#envelope"></use>
                                        </svg>
                                        <asp:Label runat="server" ID="LblEmail" CssClass=" font-monospace  fw-bolder" />
                                    </asp:HyperLink>
                                    <asp:HyperLink runat="server" ID="HLTelefone"  CssClass="col-12 text-start mb-2 font-monospace text-decoration-none fw-bolder">
                                        <svg class="bi" width="20" height="20" fill="currentColor">
                                            <use href="../Imagens/icones/bootstrap-icons.svg#telephone"></use>
                                        </svg>
                                        <asp:Label runat="server" ID="LblTelefone" CssClass="font-monospace  fw-bolder"/>                                
                                             </asp:HyperLink>

                                    <asp:HyperLink runat="server" ID="HLWhatsapp"  Target="_blank" Visible="false" CssClass="col-12 text-start text-decoration-none mb-2 font-monospace fw-bolder">
                                        <svg class="bi" width="20" height="20" fill="currentColor">
                                            <use href="../Imagens/icones/bootstrap-icons.svg#whatsapp"></use>
                                        </svg>
                                        <asp:Label runat="server" ID="LblWhatsapp2" Visible="true" CssClass=" col-12 font-monospace fw-bolder" Text="aaa" />

                                    </asp:HyperLink>

                                    <asp:HyperLink runat="server" ID="HLInstagram" Target="_blank"  Visible="false" CssClass="col-12 text-start text-decoration-none mb-2 font-monospace fw-bolder">
                                        <svg class="bi" width="20" height="20" fill="currentColor">
                                            <use href="../Imagens/icones/bootstrap-icons.svg#instagram"></use>
                                        </svg>
                                        <asp:Label runat="server" ID="LblInstagram2" Visible="true" CssClass="font-monospace fw-bolder" />
                                    </asp:HyperLink>

                                    <asp:HyperLink runat="server" ID="HLLinkedin" Target="_blank" Visible="false" CssClass="col-12 text-start mb-2 text-decoration-none font-monospace fw-bolder">
                                        <svg class="bi" width="20" height="20" fill="currentColor">
                                            <use href="../Imagens/icones/bootstrap-icons.svg#linkedin"></use>
                                        </svg>
                                        <asp:Label runat="server" ID="LblLinkedin2" Visible="true" CssClass="font-monospace fw-bolder"/>
                                    </asp:HyperLink>

                                </div>
                            </asp:Panel>

                            <asp:Panel ID="PnRedeImg" runat="server" Visible="true">
                                <img src="../Imagens/Undraw/undraw_Social_growth_re_tjy9.svg" style="max-height: 300px; max-width: 300px;" class="img-fluid mx-auto  " />
                            </asp:Panel>

                        </div>
                    </asp:Panel>
                <%--Card Endereço--%>
              
                    <asp:Panel ID="PnEndereco" runat="server" CssClass="  col-11 col-sm-8 mx-auto "  Visible="false">

                <div class="card-header  rounded-top p-2" style="background-color: var(--laranja)">
                    <svg class="bi   figure-img img-fluid" width="25" height="25" role="img">
                        <use href="../Imagens/icones/bootstrap-icons.svg#house"></use></svg>
                    <label class="fs-5 ms-1 fw-bold text-uppercase font-monospace ">endereço </label>
                </div>

                <div class="card-body  pb-0 px-2 pt-1 bg-light mb-3   shadow rounded-bottom">
                    <asp:Panel ID="PanelEnderecoInfo" runat="server" Visible="true">

                        <div class="  row">

                      
                            <div class="col-12">
                                <asp:label  runat="server" Font-Size="Small" class="   font-monospace fw-bold">Bairro</asp:label>
                                <asp:Label runat="server" Font-Size="Smaller" CssClass="text-secondary font-monospace " ID="lblBairro" />
                            </div>
                            <div class="col-12">
                                <asp:label  runat="server" Font-Size="Small" class="   font-monospace fw-bold">Cidade</asp:label>
                                <asp:Label runat="server"  Font-Size="Smaller" Class="   font-monospace  text-secondary" ID="lblCidade" />
                            </div>

                            <div class="col-12">
                                <asp:label  runat="server" Font-Size="Small" class="    font-monospace fw-bold">UF</asp:label>
                                <asp:Label runat="server"  Font-Size="Smaller" Class="   font-monospace text-secondary " ID="lblUF" />
                            </div>

                            <div class="col-12 mb-2">
                                <asp:label  runat="server" Font-Size="Small" class="   font-monospace fw-bold">CEP</asp:label>
                                <asp:Label runat="server"  Font-Size="Smaller" Class="   font-monospace text-secondary" ID="lblCEP" />
                            </div>



                        </div>

                    </asp:Panel>

                    <asp:Panel ID="PanelEnderecoImg" runat="server" Visible="false">
                        <img src="../Imagens/undraw/undraw_World_re_768g.svg"   style=" max-height:300px; max-width:300px;" class="img-fluid mx-auto  "  />

                    </asp:Panel>
                </div>
             </asp:panel>

                <asp:panel runat="server" ID="PnExeperiencia"  CssClass=" col-11 col-sm-8 mx-auto "    Visible="false"> 
                    
                <%--Card Exeperiencia Profissional--%>

                <div class="card-header shadow  rounded-top p-2" style="background-color: var(--laranja)">
                    <svg class="bi img-fluid  figure-img" width="25" height="25" role="img">
                        <use href="../Imagens/icones/bootstrap-icons.svg#folder-plus"></use></svg>
                    <label class=" fs-5 ms-1 fw-bold text-uppercase font-monospace">experiência</label>
                </div>

                <div class="card-body  pb-0 px-2 pt-1 bg-light mb-3  shadow rounded-bottom">

                    <asp:Panel ID="PanelExperienciaInfo" runat="server" Visible="false">

                        <div class="  row">

                            <asp:Repeater ID="rptExperiencia" runat="server">
                                <ItemTemplate>

                                    <div class="col-12">
                                        <asp:label runat="server" Font-Size="Small" class="   font-monospace fw-bold" Text="Cargo: "/>
                                     <asp:label runat="server" Font-Size="Smaller" class="   font-monospace text-secondary" Text='<%# DataBinder.Eval(Container.DataItem, "NomeCargoEx") %>'/>
                                    </div>
                                    <div class="col-12">
                                        <asp:label  runat="server" Font-Size="Small" class="   font-monospace fw-bold"  Text="Nome da Empresa: " />
                                        <asp:Label runat="server" Font-Size="Smaller" class="   font-monospace text-secondary" Text='<%# DataBinder.Eval(Container.DataItem, "NomeEmpresaEx") %>' />

                                    </div>
                                    <div class="col-12">
                                       <asp:label  runat="server" Font-Size="Small" class="   font-monospace fw-bold"  Text="Iniciou: " />
                                        <asp:Label runat="server" Font-Size="Smaller" class="   font-monospace  text-secondary"  TextMode="Date" Text='<%#  ((DateTime)DataBinder.Eval(Container.DataItem, "DateInicioEx")).ToString("mm/yyyy") %>'/>   
                                    </div>
                                    <div class="col-12">
                                        <asp:label  runat="server" Font-Size="Small" class="   font-monospace fw-bold"  Text="Conclusão: " />
                                        <asp:Label runat="server" Font-Size="Smaller" class="   font-monospace text-secondary"   TextMode="Date"  Text='<%#  ((DateTime)Eval("DateFinalizouEx")).ToString("mm/yyyy") %>' />
                                    </div>
                                    <div class="col-12">
                                        <asp:label  runat="server" Font-Size="Small" class="   font-monospace fw-bold"  Text="Contratação: "/>
                                        <asp:Label runat="server" Font-Size="Smaller" class="   font-monospace text-secondary " Text='<%# DataBinder.Eval(Container.DataItem, "TipoContratoEx") %>' />

                                    </div>
                                    <div class="border-bottom"></div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="PanelExperienciaImg" runat="server" Visible="false">
                        <img src="../Imagens/undraw/undraw_Mobile_encryption_re_yw3o.svg"   style=" max-height:300px; max-width:300px;" class="img-fluid mx-auto  "  />
                    </asp:Panel>
                </div>
                </asp:panel>
                <%--Card Certificados Profissional--%>

                <asp:panel runat="server" CssClass=" col-11 col-sm-8 mx-auto " ID="PnCertificado" Visible="false"> 
                <div class="card-header shadow  rounded-top p-2" style="background-color: var(--laranja)">
                    <svg class="bi img-fluid  figure-img" width="25" height="25" role="img">
                        <use href="../Imagens/icones/bootstrap-icons.svg#mortarboard"></use></svg>
                    <label class="fs-5 ms-1 fw-bold text-uppercase font-monospace ">certificados</label>
                </div>
                <div class="card-body pb-0 px-2 pt-1 bg-light mb-3  shadow rounded-bottom">
                    <asp:Panel ID="PanelFormEscoInfo" runat="server" Visible="false">
                        <div class=" row">
                            <asp:Repeater ID="rptCurso" runat="server">
                                <ItemTemplate>

                                    <div class="col-12">
                                        <asp:label  runat="server" Font-Size="Small"  CssClass="   font-monospace fw-bold"  Text="Curso: "/>
                                        <asp:Label runat="server" Font-Size="Smaller"  CssClass="   font-monospace text-secondary " Text='<%# DataBinder.Eval(Container.DataItem, "NomeCursoCf ") %>' />
                                    </div>

                                    <div class="col-12">
                                        <asp:label  runat="server" Font-Size="Small"  CssClass="   font-monospace fw-bold"  Text="Instituição: "/>
                                        <asp:Label runat="server" Font-Size="Smaller"  CssClass="   font-monospace text-secondary "  Text='<%# DataBinder.Eval(Container.DataItem, "NomeInstituicaoCf") %>' />

                                    </div>
                                    <div class=" col-12">
                                        <asp:label  runat="server" Font-Size="Small"  CssClass="   font-monospace fw-bold"  Text="Iniciou: "/>
                                        <asp:Label runat="server" Font-Size="Smaller"  CssClass="   font-monospace text-secondary "  TextMode="Month" Text='<%#  ((DateTime)DataBinder.Eval(Container.DataItem, "DateInicioCf")).ToString("mm/yyyy") %> ' />

                                    </div>
                                    <div class=" col-12">
                                        <asp:label  runat="server" Font-Size="Small"  CssClass="   font-monospace fw-bold"  Text="Conclução: "/>
                                        <asp:Label runat="server" Font-Size="Smaller"  CssClass="   font-monospace text-secondary "   Text='<%#  ((DateTime)DataBinder.Eval(Container.DataItem, "DateFinalizouCf")).ToString("mm/yyyy") %>' />                                    </div>


                                    <div class="border-bottom"></div>

                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="PanelFormEscoImg" runat="server" Visible="false">
                        <img src="../Imagens/undraw/undraw_Certificate_re_yadi.svg" style=" max-height:300px; max-width:300px;" class="img-fluid mx-auto  " />
                    </asp:Panel>
                </div>
                </asp:panel>

            </div>
        </div>
    </div>

        <asp:panel runat="server" ID="PnVagas" Visible="false" class="container mx-auto p-2"> 
     
            <uc:RptVagas runat="server" ID="RptVagasControl" />
              
                    </asp:panel>
                    </asp:Panel>

</asp:Content>
