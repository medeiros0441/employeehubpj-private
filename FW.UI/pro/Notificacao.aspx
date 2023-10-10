<%@ Page Title="" Language="C#" MasterPageFile="~/pro/Default.Master" AutoEventWireup="true" CodeBehind="Notificacao.aspx.cs" Inherits="FW.UI.notificacaopro" %>
<%@ MasterType VirtualPath="~/pro/Default.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class=" my-3">
          <svg class="bi me-2" width="30" height="30"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#bell"></use></svg>
                <asp:Label runat="server" CssClass="fs-5 fw-bolder font-monospace ">Notificações</asp:Label>
 </div>
     
    <asp:repeater ID="rpt_Notificacao"   runat="server">
        <ItemTemplate>   


    <div class="list-group      w-auto ">
 <asp:LinkButton OnClick="Btn_abrir_notificacao_Click" runat="server" ID="btn_abrir_notificacao" CssClass="bg-light list-group  btn border rounded-2  list-group-item w-auto my-1  " aria-current="true" CommandArgument='<%# Eval("IdNotificacao") %>'>
    
     <div class="toast-header">
     <img src="../Imagens/Logo_<span class="nome-empresa"></span>.png" class="bi rounded me-2" width="30" height="30"  />

    <asp:label runat="server"   ID="lbl_Titulo_notificacao" class="me-auto   fw-semibold font-monospace fs-6"><%# Eval("TituloNc") %> </asp:label>
    <asp:label runat="server"  class="text-muted font-monospace  Date_Calcule_tempo"><%# Eval("DateTimeInsertNc") %></asp:label>
            </div>
 
</asp:LinkButton>

 </ItemTemplate>
    </asp:repeater>


    <asp:panel runat="server" ID="not_notificacao" Visible="false">

        <asp:Image runat="server" ID="img_not_notificacao"  ImageUrl="~/Imagens/Undraw/undraw_at_work_re_qotl.svg" CssClass="mx-auto " Width="100" Height="100" />
    </asp:panel>
    <asp:panel runat="server" ID="panel_mensagem" CssClass="mx-auto " Visible="false">
        
 <div class=" bg-light list-group  border rounded-2  list-group-item w-auto my-3"  >
  <div class="toast-header mb-2">
     <img src="../Imagens/Logo_<span class="nome-empresa"></span>.png" class="bi rounded me-2" width="30" height="30"  />

    <asp:label runat="server"   ID="lbl_Titulo_notificacao" class="me-auto   fw-semibold font-monospace fs-6"> </asp:label>
    <asp:label runat="server" ID="lbl_data_notificacao"  class="text-muted font-monospace Date_Calcule_tempo"></asp:label>
  </div>
  <asp:label runat="server" ID="lbl_descricao_notificacao" class="toast-body small text-bg-light font-monospace my-4">
   
 </asp:label>
</div>  
    </asp:panel>

</asp:Content>
