<%@ Page Title="" Language="C#" MasterPageFile="../Default.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="FW.UI.pages.Default" %>
<%@ MasterType VirtualPath="../Default.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <style >

        .custom-shape-divider-bottom-1695014783 {
    position: relative;
    bottom: -1px;
    left: 0;
    width: 100%;
    overflow: hidden;
    line-height: 0;
    transform: rotate(180deg);
}

.custom-shape-divider-bottom-1695014783 svg {
    position: relative;
    display: block;
    width: calc(100% + 1.3px);
    height: 95px;
    transform: rotateY(180deg);
}

.custom-shape-divider-bottom-1695014783 .shape-fill {
    fill: #212529;
}

.custom-shape-divider-top-1695015253 {
 
    margin-top: -3px;
    width: 100%;
    overflow: hidden;
    line-height: 0;
    transform: rotate(180deg);
    z-index: -1;
}

.custom-shape-divider-top-1695015253 svg {
    position: relative;
    display: block;
    width: calc(100% + 1.3px);
    height: 95px;
    transform: rotateY(180deg);
}

.custom-shape-divider-top-1695015253 .shape-fill {
    fill: #212529;
}

.custom-shape-divider-top-1695015497 {
    position: relative;
    top: -1px;
    left: 0;
    width: 100%;
    overflow: hidden;
    line-height: 0;
}

.custom-shape-divider-top-1695015497 svg {
    position: relative;
    display: block;
    width: calc(100% + 1.3px);
    height: 73px;
    transform: rotateY(180deg);
}

.custom-shape-divider-top-1695015497 .shape-fill {
    fill: #212529;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="custom-shape-divider-top-1695015253">
    <svg data-name="Layer 1" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 1200 120" preserveAspectRatio="none">
        <path d="M985.66,92.83C906.67,72,823.78,31,743.84,14.19c-82.26-17.34-168.06-16.33-250.45.39-57.84,11.73-114,31.07-172,41.86A600.21,600.21,0,0,1,0,27.35V120H1200V95.8C1132.19,118.92,1055.71,111.31,985.66,92.83Z" class="shape-fill"></path>
    </svg>
</div>
    <br />
    <div class="container mx-auto p-5" style="max-height: 100%; margin: auto;">

        <div class="row featurett">
            <div class="col-md-7 p-4">
                <h2 id="typed-text" class="  font-monospace    fs-5 fw-bolder  ">Descubra Oportunidades de Negócios: Busca de Empresas PJ e Profissionais</h2>
                <p class=" text-muted fs-6  font-monospace fs-3 small"> 
                 Explore nosso diretório abrangente de empresas PJ e profissionais qualificados. Conecte-se com prestadores de serviços, empreendedores e consultores. Encontre a parceria ideal para o seu negócio ou projeto.
                </p>
                
            </div>
            <asp:panel runat="server"  Visible="true" ID="container_slide" class="col-md-5 container_slide   d-md-block">
                   <div data-slide="slide" class="slide Pn_slide  " id="Pn_slide">
    <div class="slide-items"  >
      <img src="../imagens/hunters-race-MYbhN8KaaEc-unsplash.jpg" class="Img_slide" alt="Img 1">
      <img src="../imagens/cytonn-photography-n95VMLxqM2I-unsplash.jpg" class="Img_slide" alt="Img 2">
      <img src="../imagens/austin-distel-mpN7xjKQ_Ns-unsplash.jpg" class="Img_slide" alt="Img 3">
      <img src="../imagens/evangeline-shaw-VLkoOabAxqw-unsplash.jpg" class="Img_slide" alt="Img 4">
    </div>
    <nav class="slide-nav d-none">
      <div class="slide-thumb "></div>
      <input runat="server"   type="button"  class="slide-prev   opacity-0 "  />
       <input runat="server"      type="button" class="slide-next  opacity-0 "    />
    </nav>
  </div>
                     
                   </asp:panel>
        </div>
        </div>



        <!-- Faixa azul -->
        <div class="custom-shape-divider-bottom-1695014783">
    <svg data-name="Layer 1" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 1200 120" preserveAspectRatio="none">
        <path d="M321.39,56.44c58-10.79,114.16-30.13,172-41.86,82.39-16.72,168.19-17.73,250.45-.39C823.78,31,906.67,72,985.66,92.83c70.05,18.48,146.53,26.09,214.34,3V0H0V27.35A600.21,600.21,0,0,0,321.39,56.44Z" class="shape-fill"></path>
    </svg>
</div>
    <div class="   container-fluid   " style="  max-height: 100%;    max-height: 100%;background:var(--bs-dark)">
        <div class=" container p-4 " style="margin: auto; max-height: 100%; color: whitesmoke; ">
           
            
            <div class="row">
                <div class="col-md-6">
                    <div class="row g-0  rounded overflow-hidden flex-md-row mb-4  text-light   h-md-250 position-relative">
                        <div class="col p-4 d-flex flex-column position-static">
                            <h3 class="">Objetivo</h3>
                         
                            <p class="card-text mb-auto"> Nosso objetivo é simplificar, por isso desenvolvemos um sistema para ajudar estudantes e profissionais ao compartilharem suas experiências e certificados nos disponibilizamos  para empresas do ramo.  <a href="Cadastro.aspx" >Cadastro completo. </a> </p>
                        </div>
                        <div class="col-auto d-none d-lg-block">
                            <asp:Image runat="server" ImageUrl="~/Imagens/undraw/undraw_Goals_re_lu76.svg" class=" my-4 img-fluid mx-auto" Width="200" Height="250" />

                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="row g-0   rounded overflow-hidden flex-md-row mb-4   h-md-250 position-relative">
                        <div class="col p-4 d-flex flex-column position-static text-light">
                            <h3 class="">Conexões</h3>
                         
                            <p class="mb-auto">
                                Além de anunciar vagas de emprego, a empresa também pode visualizar projetos, e consultar os dados para contato.</p>
                        </div>
                        <div class="col-auto d-none d-lg-block">
                            <asp:Image runat="server" ImageUrl="~/Imagens/undraw/undraw_real_time_collaboration_c62i.svg" class=" my-4 img-fluid mx-auto" Width="200" Height="250" />

                        </div>
                    </div>
                </div>
            </div>

             <svg class="bi mb-2 me-1" width="35" height="35"  fill="currentColor"><use href="../imagens/icones/bootstrap-icons.svg#building"/></svg> 
<a class="customer-link text-light" style="font-size:25pt;">Empresas</a> 
        <div class="row  p-4 featurette">
            <div class="col-md-8 ">
                <h2 class="featurette-heading">Analise de perfil</h2>
              <span class="">Pesquise com rapidez e segurança os melhores profissionais  PJ mercado. Tenha acesso a informações relevantes, filtre por perfil, tenha acesso a experiência, certificados</span>
            </div>
            <div class="col-md-4">
                <img src="../imagens/undraw/undraw_Swipe_profiles_re_tvqm (1).svg" class=" my-4 img-fluid mx-auto" width="250" height="250" />

            </div>
            
        </div> 

        <div class="row p-4 featurette">
            <div class="col-md-8">
                <h2 class="featurette-heading">Anuncie vagas</h2>
               <span class="">Reduza e otimize seu tempo na hora de realizar processo de recrutamento e análise dados,
                   Compartilhe vagas  que estão disponíveis e logo você terá acesso  aos dados dos profissionais que se candidatarão.</span>
            </div>
            <div class="col-md-4"> 
                <img src="../imagens/undraw/undraw_Push_notifications_re_t84m.svg" class=" my-4 img-fluid mx-auto" width="250" height="250" />

            </div>
        </div> 
        <div class="row p-4 featurette ">
            <div class="col-md-8">
                <h2 class="featurette-heading">Informações relevantes</h2>
               <span class=" ">São milhares de profissionais  que compartilham as suas experiências,Certificados, você pode contratá-los como freelance, CLT, PJ para isso faça  <a class=" link-primary" href="Cadastro.aspx">Cadastre-se como Recrutador.</a></span>
            </div>
            <div class="col-md-4">
                <img src="../imagens/undraw/undraw_ideas_s70l.svg" class="  my-4 img-fluid mx-auto" width="250" height="250" />

            </div>
        </div> 
 
            
 
 
    </div>
             
        </div>
       <div class="custom-shape-divider-top-1695015497">
    <svg data-name="Layer 1" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 1200 120" preserveAspectRatio="none">
        <path d="M321.39,56.44c58-10.79,114.16-30.13,172-41.86,82.39-16.72,168.19-17.73,250.45-.39C823.78,31,906.67,72,985.66,92.83c70.05,18.48,146.53,26.09,214.34,3V0H0V27.35A600.21,600.21,0,0,0,321.39,56.44Z" class="shape-fill"></path>
    </svg>
</div>  
        <div class="container p-5 mx-auto" style="max-height: 100%; margin: auto;"> 
            <svg class="bi mb-2 me-1" width="35" height="35"  fill="currentColor"><use href="../imagens/icones/bootstrap-icons.svg#mortarboard"/></svg>
                  <a class="customer-link text-dark" style="font-size:25pt;">  Profissionais</a>
            <div class="row p-4 featurette">
                <div class="col-md-7 order-md-2">
                    <h2 class="featurette-heading">Currículo</h2>
                  <span class="text-muted">A medida que o mercado se expande, manter o currículo atualizado é fundamental,
                      pois diversas empresas que agregam, estaram visualizando você.
                      Solicite a autenticação do seu usuário e se destaque com seus projetos.</span>
                </div>
                <div class="col-md-5 order-md-1">
                    <asp:Image runat="server" ImageUrl="~/Imagens/undraw/undraw_online_cv_qy9w.svg" class=" my-4 img-fluid mx-auto" Width="250" Height="250" />


                </div>
            </div>

            <div class="row p-4 featurette">
                <div class="col-md-7 order-md-2">
                    <h2 class="featurette-heading">Perfil</h2>
                    <span class="text-muted"> Crie seu Perfil de formas simples, são várias empresas internacionais  que estará acompanhando a plataforma. Você não vai ficar de fora, né ?  <a class=" text-bg-primary" href="Cadastro.aspx">CADASTRE-SE</a> </span>
                </div>
                <div class="col-md-5 order-md-1">
                    <asp:Image runat="server" ImageUrl="~/Imagens/undraw/undraw_Co_workers_re_1i6i.svg" class=" my-4 img-fluid mx-auto" Width="250" Height="250" />
                </div>
            </div>


        </div>
     
</asp:Content>
