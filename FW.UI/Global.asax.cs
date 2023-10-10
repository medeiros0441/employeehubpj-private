using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using FW.BLL;
using FW.DTO;
using System.Text.RegularExpressions;

namespace FW.UI
{
    public static class PathConfig
    {
        public static string RaizPath { get; } = "~/";
        public static string IconesPath { get; } = "Imagens/icones/bootstrap-icons.svg#";
        public static string ObjetosEmpresaPath { get; } = "~/Images/objetos-empresa/";
        public static string UndrawPath { get; } = "~/Images/undraw/";
        public static string ImagensPath { get; } = "~/Images/";
        public static string ClientCurriculoPath { get; } = "~/Cliente/curriculo/";
        public static string ClientFotoPath { get; } = "~/Cliente/foto_cliente/";
        public static string ClientPath { get; } = "~/Cliente/";
        public static string ScriptsPath { get; } = "~/scripts/";
        public static string EmpresaPath { get; } = "~/empr/";
        public static string ProfissionalPath { get; } = "~/pro/";
        public static string ContainersPath { get; } = "~/containers/";
        public static string ContainersAspxPath { get; } = "~/containers/aspx/";
        public static string ContainersAscxPath { get; } = "~/containers/ascx/";
    }

    public class Global : System.Web.HttpApplication
    {

        protected SessaoBLL sessaoBLL = new SessaoBLL();
        protected SessaoDTO SessaoDTO = new SessaoDTO();
        protected ClienteBLL ClienteBLL = new ClienteBLL();
        protected ClienteDTO ClienteDTO = new ClienteDTO();
        protected ProcessadorBLL processadorBLL = new ProcessadorBLL();

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string path = HttpContext.Current.Request.Url.AbsolutePath;

            // Verifica se o caminho é vazio (URL raiz)
            if (string.IsNullOrEmpty(path) || path == "/")
            {
                // Redireciona para a página desejada (por exemplo, "default.aspx")
                HttpContext.Current.Response.Redirect("~/pages/default.aspx");
            }
        }
        protected void Application_Start(object sender, EventArgs e)
        {
          
        }


        public string GetCookie(string name)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie != null)
            {
                return cookie.Value;
            }
            return null;
        }

        public void SetSessionData(string name, string value)
        {
            HttpCookie cookie = new HttpCookie(name, value)
            {
                Expires = DateTime.Now.AddDays(7)
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        protected void LimparCookies()
        {
            Sessao.DesconectUsuario();
            HttpContext.Current.Response.Cookies.Clear();
        }
        public static string ParseBrowser(string userAgent)
        {
            string browser = "Desconhecido";

            if (!string.IsNullOrEmpty(userAgent))
            {
                // Expressão regular para encontrar o nome do navegador
                string pattern = @"(MSIE|Edge|Chrome|Safari|Firefox)";
                Match match = Regex.Match(userAgent, pattern, RegexOptions.IgnoreCase);

                if (match.Success)
                {
                    browser = match.Value;
                }
            }

            return browser;
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            try
            {
                string ip_cookie = GetCookie("ip_cliente");
                string navegador_cookie = GetCookie("navegador_cliente");
                string id_sessao = GetCookie("id_sessao");
                if (ip_cookie == null && navegador_cookie == null && id_sessao == null)
                {
                    string ip_cliente = HttpContext.Current.Request.UserHostAddress;
                    string userAgent = HttpContext.Current.Request.UserAgent;
                    string browser = ParseBrowser(userAgent);
                    SessaoDTO.IpClienteSs = ip_cliente;
                    SessaoDTO.NavegadorSs = browser;
                    SessaoDTO = sessaoBLL.CadastrarSessao(SessaoDTO);
                    SessaoDTO sessaoDTO = sessaoBLL.ConsultarSessaoPorIpCliente(ip_cliente, browser);
                    if (sessaoDTO.IdSessao != 0)
                    {
                        SetSessionData("id_sessao", SessaoDTO.IdSessao.ToString());
                        SetSessionData("ip_cliente", ip_cliente);
                        SetSessionData("navegador_cliente", browser);
                    } 
                }
                //ClienteDTO.EmailCl = GetCookie("email_cookie");
                //ClienteDTO.SenhaCl = GetCookie("senha_cookie");  
                //if (ClienteDTO.EmailCl != null && ClienteDTO.SenhaCl != null)
                //{
                //    ClienteBLL.AutenticarEmailSenha(ClienteDTO);
                //}

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao processar dados " + ex.Message);
            }
        }


        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

            Exception ex = Server.GetLastError();

            // Obtém a mensagem de erro
            string mensagemErro = ex.InnerException?.Message ?? ex.Message;

            // Redireciona para a página de erro e passa a mensagem como parâmetro de consulta
            Server.Transfer("Erro.aspx?mensagem=" + Server.UrlEncode(mensagemErro));
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}