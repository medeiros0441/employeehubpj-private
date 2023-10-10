<%@ Page Title="" Language="C#" MasterPageFile="../Default.Master" AutoEventWireup="true" CodeBehind="EditarRedeSociais.aspx.cs" Inherits="FW.UI.pages.EditarRedeSociais" %>
<%@ MasterType VirtualPath="../Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row  container mx-auto p-2 p-md-4 ">
    <div class=" mt-2 mb-4 col-10 float-start text-start ">
            <svg class="bi me-2 " width="30" height="30" fill="currentColor">
                <use href="../Imagens/icones/bootstrap-icons.svg#share"></use></svg>
            <label class="fs-6   text-uppercase font-monospace pt-1  fw-bold">REDES SOCIAIS</label>
        </div>
          
         <div class="container-xxl">

                <div class="accordion" id="accordion">
            
                  

        <div class="accordion-item">
                        <h2 class="accordion-header m-0" id="headingRedeSocial">
                            <button class="accordion-button   text-uppercase font-monospace"   type="button" data-bs-toggle="collapse"   aria-expanded="true" aria-controls="collapseOne">
                                REDES SOCIAIS
                            </button>
                        </h2>
                        <div id="collapseRedeSocial" class="accordion-collapse collapse show" aria-labelledby="headingRedeSocial" data-bs-parent="#accordion">
                            <div class="accordion-body">
                                <asp:Panel runat="server" class="row g-1" DefaultButton="btnSalvarRedesSociais">
                                        <div class="my-auto text-center col-1">
                                            <svg class="bi img-fluid   " width="32" height="32" fill="currentColor">
                                                <use href="../Imagens/icones/bootstrap-icons.svg#linkedin" />
                                            </svg>
                                        </div>
                                        <div class=" col-11 form-floating">
                                            <asp:TextBox runat="server" CssClass="form-control" placeholder="Link" ID="urllinkedin" />
                                            <label for="urllinkedin" class="text-secondary">Usuario</label>

                                        </div>
                                        <div class="my-auto text-center col-1">
                                            <svg class="bi img-fluid " width="32" height="32" fill="currentColor">
                                                <use href="../Imagens/icones/bootstrap-icons.svg#instagram" />
                                            </svg>
                                        </div>
                                        <div class=" col-11 form-floating">
                                            <asp:TextBox runat="server" CssClass="form-control" placeholder="Link" ID="urlinstagram" />
                                            <label for="urlinstagram" class="text-secondary">Usuario</label>

                                        </div>
                                        <div class="my-auto text-center col-1">
                                            <svg class="bi img-fluid   " width="32" height="32" fill="currentColor">
                                                <use href="../Imagens/icones/bootstrap-icons.svg#whatsapp" />
                                            </svg>
                                        </div>
                                        <div class=" col-11 form-floating">
                                            <asp:TextBox runat="server" CssClass="form-control phone" placeholder="Link" ID="urlWhatsapp" />
                                            <label for="Whatsapp" class="text-secondary">DD + Num </label>
                                        </div>
                                        <asp:Button runat="server" CssClass=" btn btn-lg w-50 mx-auto py-2 mb-2 btn mt-2  btn-outline-customer rounded-3"
                                            ID="btnSalvarRedesSociais" OnClick="BtnSalvarRedesSociais_Click" Text="Salvar"></asp:Button>

                                </asp:Panel>
                            </div>
                        </div>
                    </div>

        </div>
        </div>
    </div> 

</asp:Content>
