using FW.BLL;
using System;

namespace FW.UI
{
    public partial class Erro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtém a mensagem de erro da query string
                string mensagemErro = Request.QueryString["mensagem"];

                // Exibe a mensagem de erro
                lblMensagem.Text = mensagemErro;
            }
        }
    }
}