using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FW.DTO;
using FW.DAL;
using System.IO;
using MercadoPago.Resource.Payment; 
using MercadoPago.Config;
using System.Configuration;
using MercadoPago.Client.Payment;
using MercadoPago.Client.Common;
using System.Globalization;
using Newtonsoft.Json;
using System.Net;
using System.Threading;

namespace FW.BLL
{
    public class PagamentoBLL : ObjetoCompartilhado
    {
        protected PagamentoDAL PagamentoDAL = new PagamentoDAL();
        protected GerenciamentoSaldoBLL GerenciamentoSaldoBLL = new GerenciamentoSaldoBLL();
        protected PagamentoDTO PagamentoDTO = new PagamentoDTO();

        public void Credeciais()
        {
       
            // string Token_Test = "TEST-5866360090675816-032521-a1da4f1df83010005a5bad5031f7d952-318147008";
            string accessToken = ConfigurationManager.AppSettings["MercadoPago_AccessToken"];
            MercadoPagoConfig.AccessToken = accessToken;

        }
        public void AtualizarStatusPagamentosPeriodicamente()
        {
                // Recupera todos os pagamentos registrados no sistema
                List<PagamentoDTO> ListaPagamentos = PagamentoDAL.ListarPagamentos();

                foreach (PagamentoDTO pagamento in ListaPagamentos)
                {
                    // Verifica o status atual do pagamento
                    string statusAtual = pagamento.StatusPg;

                    // Consulta o status atualizado do pagamento na API do Mercado Pago
                    var novoStatus = ConsultarStatusPagamento(pagamento.PaymentidPg);

                // Se houver mudança no status, atualiza o status do pagamento na DAL
                if (novoStatus != statusAtual)
                {
                    pagamento.StatusPg = novoStatus;
                    PagamentoDAL.AtualizarPagamento(pagamento.IdPagamento, pagamento.FkClientePg, novoStatus);

                    if (novoStatus == "approved")
                    {

                        decimal saldo_atual  =GerenciamentoSaldoBLL.GetSaldo(pagamento.FkClientePg);
                        GerenciamentoSaldoDTO SaldoDTO = new GerenciamentoSaldoDTO
                        {
                            SaldoAnteriorGs = saldo_atual,
                            SaldoAtualGs = pagamento.ValorPg,
                            DescricaoGs = "Adicionando Saldo, Pagamento Aprovado.",
                            FkClienteGs = pagamento.FkClientePg,
                            FkPagamentoGs = pagamento.IdPagamento
                        };

                        GerenciamentoSaldoBLL.Create(SaldoDTO);
                    }
                }
            }
        }
        public bool CancelarPagamento(string paymentId)
        {
            // Obtém o access token a partir do arquivo de configuração
            Credeciais();
            long payment_Id = long.Parse(paymentId);

            var client = new PaymentClient();
            client.Cancel(payment_Id);
            return true;
        }
         
        public async Task<string> CriarPagamentoAsync(PagamentoDTO Model)
        {
            try
            {
                Credeciais();

               
                
                    var request = new PaymentCreateRequest
                    {
                        TransactionAmount = Model.ValorPg,
                        Installments = 1,
                        Description = Model.NomeProdutoPg,
                        PaymentMethodId = "pix",
                        Payer = new PaymentPayerRequest
                        {
                            Email = Model.EmailCl,
                            FirstName = Model.PrimeiroNomeCl,
                            LastName = Model.SobrenomeCl,
                            Identification = new IdentificationRequest
                            {
                                Type = "CPF",
                                Number = Model.NroCpfCl.ToString()
                            }
                        }
                    };
                    var client = new PaymentClient();
                    Payment savedPayment = await client.CreateAsync(request);
                    if (savedPayment != null)
                    {
                        var qrCode = savedPayment.PointOfInteraction.TransactionData.QrCode;
                        var qrCodeBase64 = savedPayment.PointOfInteraction.TransactionData.QrCodeBase64;
                        Model.QrcodepixPg = qrCode;
                        Model.ImgQrcodebase64Pg = qrCodeBase64;
                        Model.PaymentidPg = savedPayment.Id.ToString();

                        CultureInfo culturaPtBr = new CultureInfo("pt-BR");
                        string textoTraduzido = culturaPtBr.TextInfo.ToTitleCase(savedPayment.Status.ToLower());
                        Model.StatusPg = textoTraduzido;
                        Model.FkClientePg =   ClienteTemporario.ID_Cliente;
                        Model.IdPagamento = CadastrarPagamento(Model);
                        Sessao.PagamentoDTO = Model;
                        return "Sucesso";
                    }
                    else
                    {
                        Model.StatusPg = "Erro ao criar pagamento. Verifique se todas as informações estão corretas.";
                        Sessao.PagamentoDTO = Model;
                        return "Erro ao criar QR-code";

                    }
                
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao criar pagamento", ex);
            }
        }

        public PagamentoDTO SelecionarPagamento(int fkCliente, int idPagamento)
        {
            try
            {
             return  PagamentoDTO = PagamentoDAL.SelecionarPagamento(fkCliente, idPagamento);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar pagamento! " + ex.Message);
            }
        }


        public string ConsultarStatusPagamento(string paymentId)
        {
            // Setando a URL da API do Mercado Pago para consulta do status de pagamento
            string accessToken = ConfigurationManager.AppSettings["MercadoPago_AccessToken"];
            string url = "https://api.mercadopago.com/v1/payments/" + paymentId + "?access_token="+ accessToken;

            try
            {
                // Fazendo uma requisição GET na URL informada acima
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json";

                // Recebendo a resposta da requisição e lendo seu conteúdo em JSON
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    // Convertendo o JSON em objeto dinâmico para acessar as propriedades de maneira fácil
                    dynamic jsonResponse = JsonConvert.DeserializeObject(reader.ReadToEnd());

                        return jsonResponse.status;
                    
                }
            }
            catch (WebException ex)
            {
                throw new Exception("Erro ao consultar status do pagamento: " + ex.Message);
            }
        }
          
        public int CadastrarPagamento(PagamentoDTO pagamento)
        {
            //Validações do objeto pagamento, se necessário
            int idPagamento = PagamentoDAL.CadastrarPagamento(pagamento);
            //Outras ações, se necessário

            return idPagamento;
        }
        public void AtualizarPagamento(int idPagamento, int fkCliente, string novoStatus)
        {
            PagamentoDAL.AtualizarPagamento(idPagamento, fkCliente, novoStatus);
        }

        public List<PagamentoDTO> ListarPagamentos(int fkCliente)
        {
            return PagamentoDAL.ListarPagamentos(fkCliente);
        }
        public List<PagamentoDTO> GetPagamentos()
        {
            List<PagamentoDTO> pagamentos = PagamentoDAL.ListarPagamentos();
            return pagamentos;
        }
    }
}
