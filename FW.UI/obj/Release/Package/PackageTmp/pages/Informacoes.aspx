<%@ Page Title="" Language="C#" MasterPageFile="../Default.Master" AutoEventWireup="true" CodeBehind="Informacoes.aspx.cs" Inherits="FW.UI.Informacoes" %>
<%@ MasterType VirtualPath="../Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  


 
<div class="mb-2 mx-auto container my-5 col-12">
 
    <asp:Label runat="server" ID="name_file" class="form-label font-monospace">Selecione o arquivo</asp:Label>
    <asp:FileUpload runat="server" class="File_doc d-none" ID="File_Doc" TabIndex="2" accept=".pdf,.doc,.docx" />
    <button type="button" class="btn btn-sm btn-outline-customer rounded-3 btn-buscar float-end" id="fileButton">Buscar</button>
 <asp:Button runat="server"  type="button" class="btn btn-sm btn-outline-customer rounded-3 btn-buscar float-end d-none"OnClick="SalvarArquivo" Text="Salvar" ID="SaveFile"/>

 </div>

<script>

 


document.addEventListener("DOMContentLoaded", function () {
    const fileButton = document.getElementById("fileButton");
    const SaveFile =document.getElementById('<%= SaveFile.ClientID %>'); 
    const fileUpload = document.getElementById('<%= File_Doc.ClientID %>'); 

    fileButton.addEventListener("click", function () {
        fileUpload.click();
    });

    fileUpload.addEventListener("change", function () {
        const nameFileLabel = document.getElementById('<%= name_file.ClientID %>');
        const file = fileUpload.files[0]; 

        if (file) {
            nameFileLabel.innerText = "Arquivo " + file.name + " selecionado.";
            SaveFile.classList.remove("d-none");
            fileButton.classList.add("d-none");
        } else {
            nameFileLabel.innerText = ""; 
        }
    });

    SaveFile.addEventListener("click", function () {
        salvarArquivoNoServidor(); // Chama a função para enviar o arquivo para o servidor
    });
});
</script>




 

</asp:Content>