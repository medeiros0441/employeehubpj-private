using FW.BLL;
using System;

namespace FW.UI
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [System.Web.Services.WebMethod]
        public static string Info_cliente(string IP_Cliente, string Navegado_Cliente)
        {

            return "Sucesso.";
        }
    }
}