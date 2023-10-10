using FW.BLL;
using FW.DTO;
using System;
namespace FW.UI.pages
{
    public partial class Lista_Oportunidades : System.Web.UI.Page
    {


        protected VagaBLL VagaBLL = new VagaBLL();
        protected VagaDTO VagaDTO = new VagaDTO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RepeterVaga();
            }
        }

        protected void RepeterVaga()
        {

            rptVaga.DataSource = VagaBLL.ListarVaga(true);
            rptVaga.DataBind();

        }

        protected void Btn_AddSessao_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {

        }
    }
}