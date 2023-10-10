<%@ Page Title="" Language="C#" MasterPageFile="../pages/Default.Master" AutoEventWireup="true" CodeBehind="Vagas-cadastradas.aspx.cs" Inherits="FW.UI.Profissional.Vagas_cadastradas" %>
<%@ MasterType VirtualPath="../pages/Default.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 

    <h1 class="card-title">Cadastrar Experiência</h1>
     <hr class="featurette-divider">
          <div class="row g-3 "  style="max-height:700px" tabindex="-1" >

    <asp:Repeater runat="server"    ID="rptVaga"> 
        <ItemTemplate>
             
            <div class="col-md-5">
                <label  class="form-label">Vaga</label>
                <asp:Label runat="server" Class="text-info" ID="txtVaga" TabIndex="1" Text="<%# DataBinder.Eval(Container.DataItem, "VagaVg") %>" />
            </div>

            <div class="col-md-5">
                <label class="form-label">Nivél de Experiência </label>
                <asp:Label  runat="server" CssClass="text-info" TabIndex="2" ID="lblExperiencia" Text="<%# DataBinder.Eval(Container.DataItem, "TempoExperienciaVg") %>" />

            </div>
            <div class="col-md-4">
                <label class="form-label">Tipo de Registro</label>
                <asp:label runat="server" CssClass=" text-info" TabIndex="3" ID="lblResgistro" Text="<%# DataBinder.Eval(Container.DataItem, "TipoRegistroVg") %>" />

            </div>
            <div class=" col-md-3">
                <label class="form-label">Sexo</label>
                <asp:TextBox runat="server" CssClass="text-info" ID="lblSexo"   TabIndex="4" Text="<%# DataBinder.Eval(Container.DataItem, "SexoCl") %>" />
                <br />
                
            </div>
            <div class=" col-md-3">
                <label class="form-label">Validade</label>
                <asp:Label  runat="server" CssClass="text-info"  ID="lblValidade" " TabIndex="5" Text="<%# DataBinder.Eval(Container.DataItem, "DescricaoValidadeVg") %>" />
                <br />
            </div>
              
            <div class="col-md-3">

                <label class="form-label">Descrição</label>
                <asp:TextBox runat="server" Class="form-control" ID="txtDescricao" TabIndex="6" TextMode="MultiLine" Text="<%# DataBinder.Eval(Container.DataItem, "DescricaoVg") %>" />
                
            </div>
    </ItemTemplate>
    </asp:Repeater>
        </div> 
  
    <div class="col-md-12 row g-3"> 
   <asp:Label runat="server" ID="lblMensagem"   CssClass="alert alert-danger col-md-4" Visible="False" />
       <asp:Label runat="server" ID="lblMensagemCadastrado"  CssClass="alert alert-success col-md-4" Visible="False"/>
    <hr class="featurette-divider">
        <div class="col-5 ms-auto">

         <asp:Button runat="server"  CssClass="btn col-md-2 ms-auto"  OnClick="btnExcluir_Click" ID="btnExcluir"  Text="Excluir" />
        </div>
        </div>


</asp:Content>
