using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FW.BLL;
using FW.DTO;

namespace FW.UI.ascx
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected int CodigoTU = ClienteTemporario.Codigo_TU;

        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected int ID_Empresa = ClienteTemporario.ID_Empresa;
        protected int ID_Profissional = ClienteTemporario.ID_Profissional;
        protected void Btn_login_Click(object sender, EventArgs e)
        {
            if (CodigoTU == 0)
            {
                Response.Redirect("../pages/autenticacao.aspx");
            }
            else
            {
                Response.Redirect("../pages/defaultcliente.aspx");

            }
        }

    }
}