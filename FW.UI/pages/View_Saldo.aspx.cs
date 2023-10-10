using FW.BLL;
using FW.DTO;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Globalization;

namespace FW.UI.pages
{
    public partial class View_Saldo : System.Web.UI.Page
    {
        readonly DateTime Data_Hora = DATA_HORA_BR.Data_Hora;

        protected PagamentoBLL PagamentoBLL = new PagamentoBLL();
        protected EmpresaBLL EmpresaBLL = new EmpresaBLL();
        protected ConsumoBLL ConsumoBLL = new ConsumoBLL();
        protected GerenciamentoSaldoDTO GerenciamentoSaldoDTO = new GerenciamentoSaldoDTO();
        protected GerenciamentoSaldoBLL GerenciamentoSaldoBLL = new GerenciamentoSaldoBLL();
        protected ClienteDTO ClienteDTO = new ClienteDTO();
        protected ClienteBLL ClienteBLL = new ClienteBLL();
        protected int ID_Empresa = ClienteTemporario.ID_Empresa;
        protected int ID_Cliente = ClienteTemporario.ID_Cliente;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                ListaConsumo_SaldoAtual();
                ListaPagamentos();
                GetSaldo( ID_Cliente);
            }
        }

        public void ListaConsumo_SaldoAtual()
        {
            List<ConsumoDTO> ListaConsumo = ConsumoBLL.ListarConsumos(ID_Empresa);
            rpt_consumo.DataSource = ListaConsumo;
            rpt_consumo.DataBind();
            rpt_consumo.Visible = true;
        }
        public void GetSaldo(int id_cliente)
        {
          decimal saldo_atual =  GerenciamentoSaldoBLL.GetSaldo(id_cliente);
            LblSaldoAtual.Text += saldo_atual.ToString();
        }
        public void ListaPagamentos()
        {
            PagamentoBLL.AtualizarStatusPagamentosPeriodicamente();
            List<PagamentoDTO> ListaPagamento = PagamentoBLL.ListarPagamentos(ID_Cliente);
            rpt_pagamentos.DataSource = ListaPagamento;
            rpt_pagamentos.DataBind();
            rpt_pagamentos.Visible = true;
        }
        protected  void BtnPagar_Click(object sender, EventArgs e)
		{
            ClienteDTO = ClienteBLL.SelectAvancedCliente(ID_Cliente);

            PagamentoDTO PagamentoDTO = new PagamentoDTO();

            if (ClienteDTO.NroCpfCl != null)
            {
                PagamentoDTO.NroCpfCl = ClienteDTO.NroCpfCl;
                PagamentoDTO.EmailCl = ClienteDTO.EmailCl;
                PagamentoDTO.PrimeiroNomeCl = ClienteDTO.PrimeiroNomeCl;
                PagamentoDTO.SobrenomeCl = ClienteDTO.SobrenomeCl;
                Sessao.PagamentoDTO = PagamentoDTO;

                Panel_Consumo.Visible = false;
                pn_pagamentos.Visible = false;
                Panel_Saldo.Visible = true;
                btn_AddValor.Visible = false;
            }
            else {
                Master.MensagemJS("Erro", "Ops, Vamos Precisar do CPF para gerar essa compra. vc consegue inserir no Perfil do Recrutador.");
            }
        }

        protected async void BtnCriar_QRCode_Click(object sender, EventArgs e)
        {
            PagamentoDTO Model = Sessao.PagamentoDTO;
            
            
            string valorFormatado = txtValor.Text; // Valor formatado como "00,00"

            // Remova os possíveis caracteres de formatação, como espaços ou pontos de milhar
            valorFormatado = valorFormatado.Replace(" ", "").Replace(".", "");

            // Defina a cultura brasileira (pt-BR) para garantir o formato correto
            CultureInfo cultura = CultureInfo.GetCultureInfo("pt-BR");

            // Tente fazer o parsing da string formatada para decimal
            if (decimal.TryParse(valorFormatado, NumberStyles.Currency, cultura, out decimal valorDecimal))
            {
                Model.ValorPg = valorDecimal;
            }

            Model.NomeProdutoPg = "Saldo em conta Employee Hub ";
            Model.DateTimeInsertPg = Data_Hora.Date;
            try
            {

                if (Model.ValorPg > 00.01m)
                {
                    string retorn_status = await PagamentoBLL.CriarPagamentoAsync(Model);
                    PagamentoDTO RetornoDTO = Sessao.PagamentoDTO;

                    // Verifica se a operação foi bem-sucedida e redireciona para a página de QR Code, ou exibe uma mensagem de erro
                    if (retorn_status == "Sucesso")
                    {
                        Sessao.PagamentoDTO = PagamentoBLL.SelecionarPagamento(ID_Cliente, RetornoDTO.IdPagamento);
                        Response.Redirect("SaldoEmpresa.aspx", true);
                    }
                    else if (retorn_status == "Erro")
                    {
                        Master.MensagemJS("Erro", "Ocorreu um erro ao processar o pagamento. Tente novamente mais tarde.");
                    }
                }
                else  
                {
                    Master.MensagemJS("Alerta", "Ops, o minimo  a recarregar é R$ 03,00");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao criar pagamento", ex);
            }
        }


        protected void LB_Detalhes_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton button = (LinkButton)sender;
                int idPagamento = Convert.ToInt32(button.CommandArgument);
                Sessao.PagamentoDTO = PagamentoBLL.SelecionarPagamento(ID_Cliente, idPagamento);
                Response.Redirect("SaldoEmpresa.aspx", true);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao Selecionar o pagamento. Tente novamente mais tarde.", ex);
            }
        }

        protected void LinkCurriculo_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string[] argumentos = btn.CommandArgument.ToString().Split(';');
            Sessao.ID_Cliente_PDF = Convert.ToInt32(argumentos[0]);
            Sessao.ID_Profissional_PDF = Convert.ToInt32(argumentos[1]);
            string url = "../Cliente/curriculo/Curriculo_Profissional.aspx";
            string script = "window.open('" + url + "', '_blank');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "AbrirNovaAba", script, true);

        }

        protected void LBPefilView_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            Sessao.ID_Cliente = Convert.ToInt32(button.CommandArgument);

            Response.Redirect("View_perfil.aspx");


        }
    }
}