using FW.BLL;
using FW.DTO;
using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.UI.HtmlControls;

namespace FW.UI
{

    public partial class Default : System.Web.UI.MasterPage
    {
        protected SessaoBLL sessaoBLL = new SessaoBLL();
        protected SessaoDTO SessaoDTO = new SessaoDTO();
        protected ClienteBLL ClienteBLL = new ClienteBLL();
        protected ClienteDTO ClienteDTO = new ClienteDTO();
        protected ProcessadorBLL processadorBLL = new ProcessadorBLL();
        protected int CodigoTU = ClienteTemporario.Codigo_TU;
        protected int ID_Cliente = ClienteTemporario.ID_Cliente;
        protected int ID_Empresa = ClienteTemporario.ID_Empresa;
        protected int ID_Profissional = ClienteTemporario.ID_Profissional;

        protected TipoUserBLL TipoUserBLL = new TipoUserBLL();
        protected TipoUserDTO TipoUserDTO = new TipoUserDTO();
        protected VagaDTO VagaDTO = new VagaDTO();
        protected VagaBLL VagaBLL = new VagaBLL();
        protected ProfissionalDTO ProfissionalDTO = new ProfissionalDTO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                //  processadorBLL.ExecutarPeriodicamente();
            }
            Verificar_usuario();
        }
        protected internal void Verificar_usuario()
        {

            if (CodigoTU == 0)
            {
                MenuControl.Visible = false;
            }else if (CodigoTU == 2 && ID_Profissional > 0)
            {
                HeaderControl.MenuClienteBtns.Visible = true;
                MenuControl.btnInscricao.Visible = true;
                MenuControl.btnExperiencia.Visible = true;
                MenuControl.btnCertificado.Visible = true;
            }
            else if (CodigoTU == 3 && ID_Empresa > 0)
            {
                HeaderControl.MenuClienteBtns.Visible = true;
                MenuControl.btnCriarOportunidade.Visible = true;
                MenuControl.btnCandidatos.Visible = true;
                MenuControl.btnSaldo.Visible = true;
            }
        }
        protected internal void Desconectar_user()
        {
            Sessao.DesconectUsuario();
            Response.Redirect("../pages/default.aspx");
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

        protected internal void MensagemJS(string type, string texto)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Alerta", $"alerta('{type}','{texto}');", true);

        }  

        public void Loading(bool status)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "loading", $"loading('{status.ToString().ToLower()})';", true);
        } 
    }
}