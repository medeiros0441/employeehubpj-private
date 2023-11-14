using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FW.BLL;
namespace FW.UI.pages
{
    public partial class SelectCurriculoPro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Add_Valores_Click(object sender, EventArgs e)
        {
            Sessao.ID_Cliente_PDF = 0;
            Sessao.ID_Profissional_PDF = 0;
            //  Response.Redirect("../Cliente/curriculo/Curriculo_profissional.aspx", true);
            string url = "../Cliente/curriculo/Curriculo_Profissional.aspx";
            string script = "window.open('" + url + "', '_blank');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "AbrirNovaAba", script, true);
        }
    }
}