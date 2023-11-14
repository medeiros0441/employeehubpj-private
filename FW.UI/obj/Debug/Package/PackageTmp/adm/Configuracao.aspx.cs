using FW.BLL;
using System;

namespace FW.UI.adm
{
    public partial class Configuracao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Master.FecharMenu();
            }
        }
        protected void Sair_Click(object sender, EventArgs e)
        {
            Master.Desconectar_user();
        }
         
    }
}