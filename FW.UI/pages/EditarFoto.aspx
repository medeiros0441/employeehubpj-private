<%@ Page Title="" Language="C#" MasterPageFile="../Default.Master" AutoEventWireup="true" CodeBehind="EditarFoto.aspx.cs" Inherits="FW.UI.pages.EditarFoto" %>
<%@ MasterType VirtualPath="../Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row ">
   
           
  <div class=" my-3 row justify-content-between"  > 
     <div class="   col-10">
          <svg class="bi me-2" width="30" height="30"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#person-bounding-box"></use></svg>
                <asp:Label runat="server" CssClass="fs-4  font-monospace   fw-bold ">Editar Foto</asp:Label>
 </div>
     <div class="   text-end   col-2">
         <asp:LinkButton runat="server"    OnClick="BtnExcluir_Click"  ID="BtnExcluir" class="sidebar-heading  text-secondary">
               <svg class="bi me-2" width="25" height="25"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#person-x"></use></svg>
        </asp:LinkButton>
 </div>
 </div>

     

    <div class="container-fluid">
         <div class="container-xxl">

                <div class="accordion" id="accordion">
            
                         <div class="accordion-item">
    <h2 class="accordion-header m-0" id="headingOne">
      <button class="accordion-button text-uppercase font-monospace" type="button" data-bs-toggle="collapse"   aria-expanded="true" aria-controls="collapseOne">
           Foto 
      </button>
    </h2>
                     
                    <div id="collapseOne" class="accordion-collapse collapse show Campo_imagem" aria-labelledby="headingOne" data-bs-parent="#accordion">
                            <div class="accordion-body">
                                <div class="col-md-3 my-2  mx-auto  order-1"  >
                <asp:Image runat="server" ID="imagePro" CssClass="bd-placeholder-img Foto_URL bd-placeholder-img-lg featurette-image  img-fluid mx-auto rounded img_caminho"  style="max-width: 200px; max-height: 200px" onerror="this.onerror=null; this.src='../Cliente/Foto_Cliente/undraw_resume_folder_re_e0bi.svg'" />

            </div>

                                <div class="col-md-3 my-2  mx-auto  order-1 preview d-none" id="preview"  >

            </div>

                                <div class="mb-2 mx-auto col-md-6"  id="btn_buscar_imagem">
                                            <label class="form-label font-monospace">Selecione uma imagem</label>
                                           <asp:FileUpload  runat="server" class=" File_Foto d-none "  type="file"     ID="File_Foto" TabIndex="2" accept=".png,.webp,.jpg"  />

                                   <button type="button" class="btn btn-sm py-2 mb-2  w-100 btn-lg btn-outline-customer rounded-3 "  onclick="Verificar_Imagem_Js()"  >Buscar</button>
                                                                    </div>
                                <div class="mb-2 col-md-6 mx-auto id_campo_varificacao" >

                                <asp:Button  OnClientClick="this.disabled = true; this.value = 'Enviando...';" UseSubmitBehavior="false"   id="btn_enviar" runat="server" CssClass=" btn btn-lg w-100 py-2 mb-2 btn  btn-outline-customer rounded-3 Btn_foto_upload  d-none      disabled   "     Text="Enviar" OnClick="Btn_foto_upload_Click"   ></asp:Button>
                                    <button type="button" class="btn btn-sm py-2 mb-2  w-100 btn-lg btn-outline-secondary rounded-3 disabled d-none " id="btn_cortar_imagem">Cortar</button>
                              </div> </div>
                        </div>
                    </div>
        </div>
        </div>
    </div>
    </div>
    <script >

       
    </script>

</asp:Content>
