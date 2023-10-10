using FW.BLL;
using FW.DTO;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Oauth2.v2;
using Google.Apis.Services;
using System;
using System.Configuration;
using System.Threading;
namespace FW.UI
{
    public partial class Autenticacao : System.Web.UI.Page
    {

        protected   EmailBLL EmailBLL = new EmailBLL();
        protected   ClienteDTO ClienteDTO = new ClienteDTO();
        protected   ClienteBLL ClienteBLL = new ClienteBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtEmail.Focus();
            if (!IsPostBack)
            {
                // Verifica se o código de autorização foi retornado pelo Google
                var authCode = Request.QueryString["code"];
                if (!string.IsNullOrEmpty(authCode))
                {
                    GoogleCallback(authCode);
                }
            }
        }

        protected void BtnEntrar_Click(object sender, EventArgs e)
        {
            ClienteDTO.EmailCl = txtEmail.Text.Trim();
            ClienteDTO.SenhaCl = txtSenha.Text;
            int retorno = ClienteBLL.AutenticarEmailSenha(ClienteDTO);
            if (retorno != 0)
            {
                     Master.SetSessionData("email_cookie" , ClienteDTO.EmailCl);
                     Master.SetSessionData("senha_cookie", ClienteDTO.SenhaCl);
                     Master.SetSessionData("codigoTU_cookie", retorno.ToString());
                    Response.Redirect("../pages/DefaultCliente.aspx");
                 
            }
            else
            {
                Master.MensagemJS("Erro","Dados Inválidos!");
                Limpar();
            }
        }

        protected void Btncadastrase_Click(object sender, EventArgs e)
        {
            Response.Redirect("cadastro.aspx");
        }

        protected void Limpar()
        {
            txtEmailRecuperacao.Text =
            txtEmail.Text =
            txtSenha.Text = String.Empty;
            txtEmail.Focus();
        }

        protected void Linksenha_Click(object sender, EventArgs e)
        {
            AbrirContainerAtualizacaoSenha();
        }
        protected void AbrirContainerAtualizacaoSenha()
        {
            PnLogin.Visible = false;
            Limpar();
            PnRecuperacaoSennha.Visible = true;
            PnTextBoxEmail.Visible = true;
        }


        protected void BtnAutenticacaoSenha_Click(object sender, EventArgs e)
        {
            VerificandoEmail();
        } 
        protected void VerificandoEmail()
        {

            ClienteDTO.EmailCl = txtEmailRecuperacao.Text.Trim();
            ClienteDTO = ClienteBLL.ConsultarEmail(ClienteDTO.EmailCl);

            if (ClienteDTO.IdCliente != 0)
            {
              bool status = Enviandoemail(ClienteDTO.EmailCl, ClienteDTO.IdCliente);

                if (status == true) {

                    Sessao.ID_Cliente = ClienteDTO.IdCliente;
                    Sessao.Emai_Cliente = ClienteDTO.EmailCl;
                    Master.MensagemJS("Sucesso","Email enviado com sucesso.");

                    txtCodigo.Text = String.Empty;
                    txtCodigo.Focus();
                    PnTextBoxEmail.Visible = false;
                    PnFinalizacao.Visible = true;
                }

            }
            else
            {
                Master.MensagemJS("Erro","Email não encontrado!");

            }

        }
        protected bool Enviandoemail(string Email, int id_cliente)
        {
            try
            {
                // Obtém informações do cliente
                ClienteDTO ClienteDTO = ClienteBLL.SelectBasicCliente(id_cliente);

                // Gera um código de email aleatório, se Sessao.CodigoEmail for nulo ou vazio
                if (string.IsNullOrEmpty(Sessao.CodigoEmail))
                {
                    var geradorCodigo = new Random();
                    Sessao.CodigoEmail = geradorCodigo.Next(100000, 900000).ToString();
                }

                // Define o assunto e a mensagem do email
                var assunto = "Verificação de email";
                var mensagem = $"Olá {ClienteDTO.PrimeiroNomeCl}, encontramos seu email em nossa base de dados. Seu código é: {Sessao.CodigoEmail} para a alteração de senha.";

                // Envia o email
                EmailBLL.Enviando_Email(Email, assunto, mensagem, ClienteDTO.PrimeiroNomeCl);

                // Exibe uma mensagem de sucesso
                Master.MensagemJS("Sucesso", "E-mail enviado com Sucesso!");

                return true; // Retorna true para indicar sucesso
            }
            catch
            {
                // Em caso de erro, exibe uma mensagem de erro
                Master.MensagemJS("Erro", "Tente novamente mais tarde!");

                return false; // Retorna false para indicar falha
            }
        }


        protected void BtnVoltar_Click(object sender, EventArgs e)
        {
            PnRecuperacaoSennha.Visible = false;
            PnLogin.Visible = true;
        }

        protected void BtnVerificandoCodigoEmail_Click(object sender, EventArgs e)
        {


            string codigo = txtCodigo.Text.Replace("-", "");

            if (codigo == Sessao.CodigoEmail)
            {

                PnConfSenha.Visible = true;
                PnFinalizacao.Visible = false;
                Senha1.Focus();
                Master.MensagemJS("Sucesso","Codigo confirmado");

            }
            else
            {
                Master.MensagemJS("Erro", "Codigo Invalido");

            }

        }

        protected void BtnVoltar2_Click(object sender, EventArgs e)
        {
            PnFinalizacao.Visible = false;
            PnTextBoxEmail.Visible = true;
        }

        protected void Btnrenviar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Sessao.CodigoEmail) &&  Sessao.ID_Cliente !=0)
            {
                Enviandoemail(Sessao.Emai_Cliente, Sessao.ID_Cliente);
            }
            else
            {
                AbrirContainerAtualizacaoSenha();
            }
        }

        protected void BtnFinalizacao_Click(object sender, EventArgs e)
        {
                if (Senha1.Text == Senha2.Text)
                {
                    if (Sessao.ID_Cliente != 0 && !string.IsNullOrEmpty(Sessao.CodigoEmail) )
                    {
                        ClienteDTO.SenhaCl = Senha1.Text;
                        ClienteDTO.EmailCl = Sessao.Emai_Cliente;
                        ClienteDTO.IdCliente = Sessao.ID_Cliente;
                        ClienteBLL.Editar_Senha_Cliente(ClienteDTO);
                    string mensagem = $" {ClienteDTO.PrimeiroNomeCl}, Sua Senha foi Alterada com Sucesso.";
                         EmailBLL.Enviando_Email(Sessao.Emai_Cliente, "Senha Alterada.", mensagem, ClienteDTO.PrimeiroNomeCl);

                         PnConfirmado.Visible = true;
                        PnConfSenha.Visible = false;
                    }
                    else
                    {
                        Master.MensagemJS("Erro", "Tempo expirou, volte ao inicio.");
                    }
                }
                else
                {
                    Master.MensagemJS("Erro", "As senhas estão Diferentes");

                }
            
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            PnConfirmado.Visible = false;
            PnLogin.Visible = true;
            PnRecuperacaoSennha.Visible = false;

        }

        protected int Verificando_usuario(string Email_sub, string Email_user, string nome_completo, string primeiro_nome, string segundo_nome, string url_img)
        {
           
           bool imagemExiste = false;

            try
            {
            var request = System.Net.WebRequest.Create(url_img);
            request.Method = "HEAD";

            using (var response = request.GetResponse() as System.Net.HttpWebResponse)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    // A imagem existe e está acessível
                    imagemExiste = true;
                }
            }
            }
            catch (System.Net.WebException)
            {
                    // Aconteceu um erro ao tentar acessar a imagem
                    imagemExiste = false;
            }

           
            GoogleDTO GoogleDTO = new GoogleDTO();

            if (Email_user != null && Email_sub != null)
            {
                GoogleDTO.IdEmailGl = Email_sub.ToString();
                GoogleDTO.EmailGl = Email_user;
                GoogleDTO.NomeCompletoGl = nome_completo;
                GoogleDTO.PrimeiroNomeGl = primeiro_nome;
                GoogleDTO.SobrenomeGl = segundo_nome;
               GoogleDTO.CaminhoFotoCl = imagemExiste == false ? null : url_img ;
            }

            
            GoogleBLL GoogleBLL = new GoogleBLL();
            int Situcao = GoogleBLL.Verificar_email(GoogleDTO);
            return Situcao;
        }
         
        protected void BtnGoogleLogin_Click(object sender, EventArgs e)
        {
            var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = ConfigurationManager.AppSettings["GoogleAPI_ID_cliente"],
                    ClientSecret = ConfigurationManager.AppSettings["GoogleAPI_ChaveSecretaCliente"]
                },
                Scopes = new[] { "email", "profile" },
            });

            // Armazena a URL de retorno na sessão
            bool isLocal = Request.Url.IsLoopback;
            string returnUrl;
            if (isLocal)
            {
                returnUrl = Request.Url.Scheme + "://localhost:8023/employeehubpj/pages/autenticacao.aspx";
            }
            else
            {
                returnUrl = Request.Url.Scheme + "://" + Request.Url.Authority + "/pages/autenticacao.aspx";
            }
            Session["GoogleReturnUrl"] = returnUrl;

            var uri = flow.CreateAuthorizationCodeRequest(returnUrl).Build();

            Response.Redirect(uri.AbsoluteUri);
        }
        protected void GoogleCallback(string authCode)
        {
            var flow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = ConfigurationManager.AppSettings["GoogleAPI_ID_cliente"],
                    ClientSecret = ConfigurationManager.AppSettings["GoogleAPI_ChaveSecretaCliente"]
                },

                Scopes = new[] { "email", "profile" },
            });

            // Obtém o código de autorização retornado pelo Google após o usuário fazer login

            string returnUrl = (string)Session["GoogleReturnUrl"];
            // Troca o código de autorização por um token de acesso
            var token = flow.ExchangeCodeForTokenAsync("", authCode, returnUrl, CancellationToken.None).Result;

            // Obtém as informações do usuário do Google a partir do token de acesso
            var credentials = new UserCredential(flow, "", token);
            var service = new Oauth2Service(new BaseClientService.Initializer
            {
                HttpClientInitializer = credentials,
                ApplicationName = "Employee"
            });
            var userInfo = service.Userinfo.Get().Execute();


            // Use as informações do usuário do Google conforme necessário
            int Situcao = Verificando_usuario(userInfo.Id, userInfo.Email,  userInfo.Name, userInfo.GivenName, userInfo.FamilyName, userInfo.Picture);
            if (Situcao != 0)
            {
                Master.SetSessionData("email_cookie", userInfo.Email);
                Response.Redirect("../pages/DefaultCliente.aspx");
            }
        }
    }

}