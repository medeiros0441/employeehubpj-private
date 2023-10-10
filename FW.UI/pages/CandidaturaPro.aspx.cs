using FW.BLL;
using FW.DTO;
using System;

namespace FW.UI
{
    public partial class CandidaturaPro : System.Web.UI.Page
    {

        protected CandidatoDTO CandidatoDTO = new CandidatoDTO();
        protected CandidatoBLL CandidatoBLL = new CandidatoBLL();
        protected int ID_Profissional = ClienteTemporario.ID_Profissional;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(ID_Profissional != 0){
            if (!IsPostBack)
            {
                RepeterVaga();
            }
            }
            else {
                Response.Redirect("../pages/default.aspx");
            }
        }

        protected void RepeterVaga()
        {
            rptVagaTable.DataSource = CandidatoBLL.ListCantdidaturaProfissional(ID_Profissional);
            rptVagaTable.DataBind();
        }

        protected void Add_sessao_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            Sessao.ID_Cliente = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("View_Perfil.aspx");
        }
    }
}