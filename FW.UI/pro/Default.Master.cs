using FW.BLL;
using FW.DTO;
using iText.StyledXmlParser.Jsoup.Nodes;
using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace FW.UI
{
    public partial class DefaultProfissional : System.Web.UI.MasterPage
    {
      
        protected int ID_Profissional = ClienteTemporario.ID_Profissional;
        protected int ID_Cliente = ClienteTemporario.ID_Cliente;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Verificar_usuario();
        }

        protected void Sair_Click(object sender, EventArgs e)
        {
            Desconectar_user();
        }
        internal protected bool Verificar_usuario()
        {

            if (ID_Profissional == 0 || ID_Cliente == 0)
            {
                Response.Redirect("../default.aspx");
                return false;
            }
            return true;
        }

        internal protected void MensagemJS(string type, string texto)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Alerta", $"alerta('{type}','{texto}');", true);

        }
        protected internal void Loading_script_js(bool status)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "loading", $"loading('{status.ToString().ToLower()}');", true);
        }

        internal protected void Loading(bool status)
        {
            HtmlGenericControl content = (HtmlGenericControl)FindControl("container_loading");
            HtmlGenericControl loading = (HtmlGenericControl)FindControl("loading");

            if (status == true)
            {
                loading.Attributes.Remove("class");
                content.Attributes.Add("class", "d-none");
            }
            else
            {
                content.Attributes.Remove("class");
                loading.Attributes.Add("class", "d-none");
                System.Threading.Thread.Sleep(500); // Espera 500ms
            }
        }

        internal protected void Desconectar_user()
        {
             Sessao.DesconectUsuario();
            Response.Redirect("../default.aspx");

        }
         
    }
}