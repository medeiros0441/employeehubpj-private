<%@ Page Title="" Language="C#" MasterPageFile="../pages/Default.Master" AutoEventWireup="true" CodeBehind="EditarCurriculo.aspx.cs" Inherits="FW.UI.pro.EditarCurriculo" %>
<%@ MasterType VirtualPath="../pages/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row ">
    <div class=" mt-2 mb-4 col-10 float-start text-start ">
            <svg class="bi me-2 " width="30" height="30" fill="currentColor">
                <use href="../Imagens/icones/bootstrap-icons.svg#folder-plus"></use></svg>
            <label class="fs-6   text-uppercase font-monospace pt-1">Editar Perfil</label>
        </div>

     


    <div class="container-fluid">
         <div class="container-xxl">

                <div class="accordion" id="accordion">
            
          <div class="accordion-item">
                       
    <h2 class="accordion-header m-0" id="headingOne">
      <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
          Upload o curriculo
                            </button>
                        </h2>
                         <div id="collapseOne" class="accordion-collapse collapse show" aria-labelledby="headingOne" data-bs-parent="#accordion">
                            <div class="accordion-body">
                                <div class="mb-2 col-12">
                                     <asp:Image runat="server" ID="image2"  CssClass="bd-placeholder-img bd-placeholder-img-lg featurette-image img-fluid mx-auto rounded" onerror="this.onerror=null; this.src='../Cliente/Foto_Cliente/undraw_resume_folder_re_e0bi.svg'" />
                                            <label class="form-label font-monospace">Selecione o curriculo</label>
                                           <asp:FileUpload  runat="server" class="form-control form-control-sm  file-input file"  id="File_Curriculo" TabIndex="2" accept=".doc,.pdf" />
                                        </div>
                                <asp:Button runat="server" CssClass=" btn btn-lg w-100 py-2 mb-2 btn  btn-outline-customer rounded-3" Text="Salvar" OnClick="Btn_foto_upload_Click" ID="Button1"></asp:Button>
                            </div>
                        </div>
                    </div>

           


        </div>
        </div>
    </div>
    </div>
</asp:Content>
