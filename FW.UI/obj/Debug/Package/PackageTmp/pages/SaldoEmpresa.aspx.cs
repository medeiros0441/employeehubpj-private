using System;
using FW.DTO;
using FW.BLL;
using System.Web.UI.WebControls;

namespace FW.UI.pages
{
	public partial class SaldoEmpresa : System.Web.UI.Page
    {
        protected PagamentoBLL PagamentoBLL = new PagamentoBLL();
        
        protected void Page_Load(object sender, EventArgs e)
		{
            if (Sessao.PagamentoDTO != null)
            {
                InserindoValores(Sessao.PagamentoDTO);
                if (Sessao.PagamentoDTO.StatusPg == "pending")
                {
                    LB_Cancelar.Visible = true;
                }
                else
                {
                    LB_Cancelar.Visible = false;
                }
            }
        }

        protected void InserindoValores(PagamentoDTO PagamentoDTO)
        {
            // Exibe a imagem e os dados do pagamento na tela
            imgQRCode.ImageUrl = "data:image/png;base64," + PagamentoDTO.ImgQrcodebase64Pg;
            lbl_ValorCopiar.Attributes.Add("data-clipboard-text", PagamentoDTO.QrcodepixPg);
            lbl_Produto.Text = PagamentoDTO.NomeProdutoPg;
            lbl_valor.Text = PagamentoDTO.ValorPg.ToString();
            lbl_Data.Text = PagamentoDTO.DateTimeInsertPg.ToString("dd/MM/yyyy");
            lbl_Hora.Text = PagamentoDTO.DateTimeInsertPg.ToString("HH:mm");
            lbl_Status.Text = PagamentoDTO.StatusPg;
        }

        protected void LB_Cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Sessao.PagamentoDTO.PaymentidPg != "")
                {
                    bool retorn_status = PagamentoBLL.CancelarPagamento(Sessao.PagamentoDTO.PaymentidPg);
                    if (retorn_status == true)
                    {
                        Response.Redirect("View_Saldo.aspx");
                        Master.MensagemJS("Sucesso", "Pagamento Cancelado com Sucesso.");
                    }
                }
                else
                {
                    Master.MensagemJS("Erro", "Erro ao obter id.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao Cancelar o pagamento. Tente novamente mais tarde.", ex);
            }
        }



    }
}