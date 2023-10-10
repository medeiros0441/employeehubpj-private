using System; 

namespace FW.UI
{
    public partial class ConfiguracaoEmpr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Verificar_usuario();
             
        }

        protected void Sair_Click(object sender, EventArgs e)
        {
            Master.Desconectar_user();


        }

    }
}