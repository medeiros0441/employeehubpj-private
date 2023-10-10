using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FW.BLL;
namespace FW.UI.ascx
{
    public partial class CarroselCliente : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        } 

        public void RptCliente<T>( List<T> Lista) where T : new()
        {
            rptCliente.DataSource = Lista;
            rptCliente.DataBind();
        }
        public void Btn_sessao_Click(object sender, EventArgs e)
        {

            LinkButton btn = (LinkButton)sender;
            Sessao.ID_Cliente = Convert.ToInt32(btn.CommandArgument);
            Response.Redirect("View_Perfil.aspx");
        }

    }
}