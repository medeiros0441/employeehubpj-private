using FW.BLL;
using System;
using System.Web.UI;

namespace FW.UI
{
    public partial class Configuracao : System.Web.UI.Page
    {

        protected int ID_Profissional = ClienteTemporario.ID_Profissional;
        protected int ID_Cliente = ClienteTemporario.ID_Cliente;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (ID_Cliente == 0) { Response.Redirect("../pages/default.aspx"); }
            Master.Verificar_usuario();
        }
        protected void Btn_Add_Valores_Click(object sender, EventArgs e)
        {
            Sessao.ID_Cliente_PDF = ID_Cliente;
            Sessao.ID_Profissional_PDF = ID_Profissional;
            //  Response.Redirect("../Cliente/curriculo/Curriculo_profissional.aspx", true);
            string url = "../Cliente/curriculo/Curriculo_Profissional.aspx";
            string script = "window.open('" + url + "', '_blank');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "AbrirNovaAba", script, true);
        }
    }
}