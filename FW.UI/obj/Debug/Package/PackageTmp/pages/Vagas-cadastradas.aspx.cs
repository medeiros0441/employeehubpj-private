using FW.BLL;
using FW.DTO;
using System;

namespace FW.UI.Profissional
{
    public partial class Vagas_cadastradas : System.Web.UI.Page
    {
        protected CandidatoBLL CandidatoBLL = new CandidatoBLL();
        protected CandidatoDTO CandidatoDTO = new CandidatoDTO();

        protected VagaBLL VagaBLL = new VagaBLL();
        protected VagaDTO VagaDTO = new VagaDTO();
        protected string Email_Cliente = ClienteTemporario.Email_Cliente;
        protected int ID_Profissional = ClienteTemporario.ID_Profissional;

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Verificar_usuario();
            if (!IsPostBack)
            {
                SelecionaVaga();
            }
        }

        public void SelecionaVaga()
        {
            int IDVaga = Convert.ToInt32(Request.QueryString["id"]);
            if (IDVaga != 0)
            {
                rptVaga.DataSource = CandidatoBLL.FiltrarVaga(IDVaga);
                rptVaga.DataBind();

            }
        }

        protected void BtnExcluir_Click(object sender, EventArgs e)
        {
            int Candidato = Convert.ToInt32(Request.QueryString["id"]);

            CandidatoBLL.ExcluirCandidatura(Candidato, ID_Profissional);
        }
    }
}