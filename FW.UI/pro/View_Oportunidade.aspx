<%@ Page Title="" Language="C#" MasterPageFile="~/pro/Default.Master" AutoEventWireup="true" CodeBehind="View_Oportunidade.aspx.cs" Inherits="FW.UI.pro.View_Oportunidade" %>
<%@ MasterType VirtualPath="~/pro/Default.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container-xl my-3 g-2 ">
          <div class="card-header p-3 rounded-top  " style="background-color: var(--laranja)">
            <asp:Label runat="server" Font-Size="Larger" CssClass="  font-monospace  fw-bold    " ID="lblVaga" />
            <div class="  d-flex float-end    ">
                <svg class="bi me-2 my-auto  " width="25" height="25" fill="currentColor">
                    <use href="../Imagens/icones/bootstrap-icons.svg#geo-alt"></use></svg>
                <asp:Label runat="server" Font-Size="Medium" class="fs-6 font-monospace  fw-bold  " ID="LblTipoVaga" />
            </div>

        </div>
        <div class=" bg-light  rounded-bottom shadow">
            <div class="  row p-3 font-monospace       ">

                <div class="col-sm-8  d-inline-flex ">
                    <asp:Label runat="server" Font-Size="Medium" class=" fw-semibold  font-monospace" Text="Nivél de Experiência:  " />
                    <asp:Label runat="server" Font-Size="Small" CssClass=" ms-2 font-monospace text-secondary" TabIndex="2" ID="lblExperiencia" />
                </div>
                <div class="col-sm-6 d-inline-flex ">
                    <asp:Label runat="server" Font-Size="Medium" class="fw-semibold font-monospace " Text="Tipo de Registro:  " />
                    <asp:Label runat="server" CssClass="ms-2 font-monospace   text-secondary" TabIndex="3" ID="lblResgistro" />
                </div>
                <div class="  d-inline-flex  col-sm-6">
                    <asp:Label runat="server" Font-Size="Medium" class=" fw-semibold     font-monospace " Text="Sexo:" />
                    <asp:Label runat="server" CssClass="  ms-2 font-monospace text-secondary" ID="lblSexo" />
                </div>
                <div class="  d-inline-flex col-sm-6 col-8">
                    <asp:Label runat="server" Font-Size="Medium" class=" fw-semibold    font-monospace " Text="Cidade:" />
                    <asp:Label runat="server" CssClass=" ms-2    font-monospace text-secondary" ID="LblCidade" />
                </div>

                <div class="d-inline-flex col-sm-6 col-4">
                    <asp:Label runat="server" Font-Size="Medium" class=" fw-semibold   font-monospace " Text="Estado:" />
                    <asp:Label runat="server" CssClass="  ms-2 font-monospace text-secondary" ID="LblEstado" />
                </div>
                <div class="col-sm-12  ">
                    <asp:Label runat="server" Font-Size="Medium" class=" fw-semibold    font-monospace " Text="Descrição:" />
                    <asp:Label runat="server" Class="    font-monospace text-secondary" ID="lblDescricao" />
                </div>

            </div>
        </div>
              

                <div class=" col-lg-12  my-3 mb-4  ">
                        <asp:Button runat="server" CssClass="btn  ms-auto    order-2 " Style="background-color: var(--laranja)" ID="BtnCadastrar"  Text="Enviar Currículo" TabIndex="7" OnClick="Cadastrar_Click" />
                </div>
                </div>

          <div class="container-xl my-3 p-1">

        <div class="col-sm-6  g-3">
      <asp:Repeater ID="rptVaga1" runat="server">
            <itemtemplate>
                <div class="card my-1  ">
                    <div class="card-header fw-semibold text-capitalize  ">
                       <label class="fs-6 font-monospace  fw-bold    ">   
                           <%# DataBinder.Eval(Container.DataItem, "NomeVg") %>
                  </label>  <div  class="  d-flex float-end    " >
        <svg class="bi me-2 my-auto  " width="15" height="15"  fill="currentColor"><use href="../Imagens/icones/bootstrap-icons.svg#geo-alt"></use></svg>
          <label class="fs-6 font-monospace  fw-bold  "><%# DataBinder.Eval(Container.DataItem, "TipoVagaVg").ToString() %></label>
       </div>
                    </div>
                    <div class="card-body">
                      <p class="card-text cont-text-200 font-monospace "><%# ((string)DataBinder.Eval(Container.DataItem, "DescricaoVg")).Replace(Environment.NewLine, "<br />") %></p>
                        
                    </div>
                    <div class="card-footer text-muted  ">
                              <asp:Label runat="server"  class="small  Date_Alter_TempoPublicado float-start"   ><%# DataBinder.Eval(Container.DataItem, "DateTimeUpdateVg").ToString() %></asp:Label>
                     <label class="menu ms-2 float-end" >
                         <a class=" font-monospace fw-bolder "  href="View_oportunidade.aspx?id_oportunidade=<%# DataBinder.Eval(Container.DataItem, "IdVaga ") %>" style="font-size:10pt;">Ver detalhes</a></label> 
                       
                    </div>
                </div>
            </itemtemplate>
        </asp:Repeater>
    </div>
    </div>

</asp:Content>
