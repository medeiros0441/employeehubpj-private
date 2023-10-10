using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FW.UI.pro
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