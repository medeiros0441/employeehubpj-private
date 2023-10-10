<%@ Page Title="" Language="C#" Async="true" MasterPageFile="../Default.Master" AutoEventWireup="true" CodeBehind="View_Saldo.aspx.cs" Inherits="FW.UI.pages.View_Saldo" %>

<%@ MasterType VirtualPath="../Default.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class=" container mx-auto">
    <div class=" my-3 row justify-content-between">
        <div class="   col">
            <svg class="bi me-2" width="35" height="35" fill="currentColor">
                <use href="../Imagens/icones/bootstrap-icons.svg#cash-coin"></use></svg>
            <asp:Label runat="server" CssClass="fs-4  font-monospace   fw-bold ">Saldo</asp:Label>
        </div>
        <div class="   text-end  col     ">
            <asp:LinkButton runat="server" OnClick="BtnPagar_Click" ID="btn_AddValor" class=" rounded-1 float-end font-monospace text-decoration-none btn-outline-customer  p-1 btn-sm   border-0  col d-flex ">
                <svg class="bi me-2" width="30" height="30" fill="currentColor">
                    <use href="../Imagens/icones/bootstrap-icons.svg#credit-card"></use></svg>
                <small class=" my-2 ">Adicionar Credito</small>
            </asp:LinkButton>

        </div>
    </div>


    <asp:Panel runat="server" ID="Panel_Saldo" CssClass="row" Visible="false">

        <div class=" col-12 col-sm-5 order-sm-1 order-2 mt-5">
            <label class="fw-bold font-monospace small">PRODUTO:   <small class=" link-dark   text-decoration-underline  fw-bolder ">Saldo em conta <span class="nome-empresa"></span></small></label>
            <br />
            <label class="fw-bold font-monospace small">VALOR</label>
            <div class="input-group col-5 mb-3  ">
                <span class="input-group-text">$</span>
                <asp:TextBox runat="server" ID="txtValor" type="text" class="form-control money ValorReal"></asp:TextBox>
                <span class="input-group-text">.00</span>
            </div>
            <asp:LinkButton runat="server" OnClick="BtnCriar_QRCode_Click" ID="btnCriar_QRCode" class="sidebar-heading  font-monospace mt-2 text-decoration-none btn-outline-customer  p-1 btn-sm   border-0  col d-flex ">
                <svg class="bi me-2" width="15" height="15" fill="currentColor" >
                    <use href="../Imagens/icones/bootstrap-icons.svg#qr-code"></use></svg>
                <small class=" link-dark   text-decoration-underline  fw-bolder ">Gerar QR-Code</small>
            </asp:LinkButton>
        </div>
        <div class=" col-sm-7 col-12  order-sm-2 order-1 row  d-inline-flex  ">
            <img src="../Imagens/pix-banco-central.svg" alt="ícone" class="bi img-fluid  d-inline-flex col-6 px-3   ">
            <img src="../Imagens/mercado-pago.svg" alt="ícone" class="bi img-fluid  col-6  d-inline-flex  px-3     ">
        </div>

    </asp:Panel>
    <asp:Panel runat="server" ID="pn_pagamentos" Visible="true">

        <div class="  alert alert-success " role="alert">
            <asp:Label runat="server" Font-Size="Small" class="alert-heading small font-monospace   fw-bold d-inline-flex">Informações</asp:Label>
            <asp:Label runat="server"  Font-Size="Small" ID="LblSaldoAtual" class="alert-heading    text-dark font-monospace fw-bold d-inline-flex float-end">Saldo Atual R$ </asp:Label>
            <br />
                <asp:Label runat="server"  Font-Size="X-Small" class="small font-monospace form-text  ">O valor Minino a ser recaregado é de R$ 10,00 reais. Cada cliente em que vc consulta consome R$ 3,00 reais de sua recarga.  
                Ops, O saldo é descontado apenas para usuarios profissionais que são verificados.  caso ele nao tenha o Selo seu saldo não é Consumido, não se preocupe nós avisaremos quando estiver a usufluir seu saldo. usuarios verificados são aqueles Que possuiem dados para contato por exemplo Telefone, ou Redes Sociais ou o curriculo em nossa base de dados.</asp:Label>
        </div>
        <table class="table  table-responsive     table-sm table-hover table-borderless  font-monospace">

            <thead>
                <tr class="row d-flex">
                    <th   class=" col  text-start  text-truncate">ID</th>
                    <th   class="col text-start  text-truncate">Status</th>
                    <th  class="col   text-center  ">Valor</th>
                    <th   class="col text-center">Detalhes</th>
                </tr>
            </thead>
            <tbody>

                <asp:Repeater ID="rpt_pagamentos" Visible="true" runat="server">
                    <ItemTemplate>
                        <tr class="row d-flex">
                            <td class=" col   text-start  text-truncate">
                                <label><%#Eval( "IdPagamento") %></label></td>
                            <td class=" col text-start  text-truncate">
                                <p><%#Eval( "StatusPg") %></p>
                            </td>
                            <td class=" col   text-center">
                                <p><%#Eval( "ValorPg") %></p>
                            </td>

                            <td class="  col   text-center">
                                <asp:LinkButton runat="server" CommandArgument='<%#Eval( "IdPagamento") %>' ID="LB_Detalhes" OnClick="LB_Detalhes_Click">
                                    <svg class="bi me-2 " width="20" height="20" fill="currentColor">
                                        <use href="../Imagens/icones/bootstrap-icons.svg#patch-question"></use></svg>
                                </asp:LinkButton></td>
                        </tr>

                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
    </asp:Panel>
    <asp:Panel runat="server" ID="Panel_Consumo" Visible="true">
        <div class=" my-3 row justify-content-between">
            <div class="   col">
                <svg class="bi me-2" width="35" height="35" fill="currentColor">
                    <use href="../Imagens/icones/bootstrap-icons.svg#bar-chart-line"></use></svg>
                <asp:Label runat="server" CssClass="fs-4  font-monospace   fw-bold ">Consumo</asp:Label>
            </div>
        </div>

        <table class="table  table-responsive     table-sm table-hover table-borderless  font-monospace">

            <thead>
                <tr class="row d-flex">
                    <th scope="col" class=" col  text-start  text-truncate">Nome Profissional</th>
                    <th scope="col" class="col  text-center  ">Valor Pago</th>
                    <th scope="col" class="col  text-center  ">Pefil</th>
                    <th scope="col" class="col text-center">Currículo</th>
                </tr>
            </thead>
            <tbody>

                <asp:Repeater ID="rpt_consumo" Visible="true" runat="server">
                    <ItemTemplate>
                        <tr class="row d-flex">
                            <td class=" col-3   text-start  text-truncate">
                                <asp:Label runat="server" Text=' <%# DataBinder.Eval(Container.DataItem, "PrimeiroNomeCl") %>' />
                            </td>
                            <td class="  col     text-center"><%# Eval("ValorDescontadoCs") %> </td>
                            <td class="  col    text-center">
                                <asp:LinkButton ID="LBPefilView" runat="server" OnClick="LBPefilView_Click" CommandArgument='<%# Eval("FkClienteTu") %>'>
                                    <svg class="bi me-2" width="15" height="15" fill="currentColor">
                                        <use href="../Imagens/icones/bootstrap-icons.svg#eye"></use>
                                    </svg>
                                </asp:LinkButton>
                            </td>
                            <td class="  col    text-center">
                                <asp:LinkButton ID="lnkCurriculo" runat="server" OnClick="LinkCurriculo_Click" CommandArgument='<%# Eval("FkClienteTu")  + ";" + Eval("FkProfissionalCs") %>' >
        <svg class="bi me-2" width="15" height="15" fill="currentColor">
            <use href="../Imagens/icones/bootstrap-icons.svg#file-pdf"></use>
        </svg>
                                </asp:LinkButton></td>
                        </tr>

                    </ItemTemplate>
                </asp:Repeater>

            </tbody>
        </table>
    </asp:Panel>
        </div>


</asp:Content>
