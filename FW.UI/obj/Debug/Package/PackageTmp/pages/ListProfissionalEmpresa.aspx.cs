using FW.BLL;
using FW.DTO;
using System;

namespace FW.UI.Empresa
{
    public partial class ListProfissional : System.Web.UI.Page
    {

        protected internal ProfissionalBLL ProfissionalBLL = new ProfissionalBLL();
        protected internal ProfissionalDTO ProfissionalDTO = new ProfissionalDTO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Master.Verificar_usuario();
            }
        }
        public void List()
        {
            rptPro.DataSource = ProfissionalBLL.ListaProfissional();
            rptPro.DataBind();
        }
    }
}