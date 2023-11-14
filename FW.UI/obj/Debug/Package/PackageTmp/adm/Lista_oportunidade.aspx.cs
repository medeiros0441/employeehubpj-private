using FW.BLL;
using FW.DTO;
using System;


namespace FW.UI.adm
{
    public partial class Lista_oportunidade : System.Web.UI.Page
    {


        protected internal VagaDTO VagaDTO = new VagaDTO();
        protected internal VagaBLL VagaBLL = new VagaBLL();

        protected internal ProfissionalBLL ProfissionalBLL = new ProfissionalBLL();
        protected internal ProfissionalDTO ProfissionalDTO = new ProfissionalDTO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FiltroVaga();
                FiltroProfissional();
            }
            Master.FecharMenu();

        }


        public void FiltroVaga()
        {
            rptVaga1.DataSource = VagaBLL.ListarVaga(true);
            rptVaga1.DataBind();

        }

        public void FiltroProfissional()
        {
            
            rptPro2.DataSource = ProfissionalBLL.ListaProfissional();
            rptPro2.DataBind();
        }
    }
}