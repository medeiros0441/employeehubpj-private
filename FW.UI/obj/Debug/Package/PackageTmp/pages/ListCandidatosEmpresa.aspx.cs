using FW.BLL;
using FW.DTO;
using System;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;
namespace FW.UI.pages
{
    public partial class ListCandidatosEmpresa : System.Web.UI.Page
    {

        protected internal CandidatoBLL CandidatoBLL = new CandidatoBLL();
        protected internal CandidatoDTO CandidatoDTO = new CandidatoDTO();
        protected private int ID_Cliente = ClienteTemporario.ID_Cliente;
        protected private int ID_Empresa = ClienteTemporario.ID_Empresa;
        protected private static int ID_VAGA;

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Verificar_usuario();
            if (!IsPostBack)
            {
                ID_VAGA = Sessao.ID_Vaga;
            }
            if (ID_VAGA > 0)
            {
                CandidatoDTO.FkEmpresaVg = ID_Empresa;
                CandidatoDTO.FkVagaCt = ID_VAGA;
                Listar(CandidatoBLL.List_Candidato_Empresa_IDVaga(CandidatoDTO));
            }
            else if (ID_VAGA == 0)
            {

                CandidatoDTO.FkEmpresaVg = ID_Empresa;
                Listar(CandidatoBLL.List_Candidato_Empresa(CandidatoDTO));
            }
        }
        public void Listar<T>(List<T> Lista)
        {
            if (Lista.Count > 0)
            {
                rptViewCandidatos.DataSource = Lista;
                rptViewCandidatos.DataBind();
            }
            else {
            
                Master.MensagemJS("Alerta", "Nenhum Candidato inscrito por enquanto");
                
            }
        }


        protected void Btn_Add_Valores_Click(object sender, EventArgs e)
        {

            LinkButton btn = (LinkButton)sender;
            int idCliente = Convert.ToInt32(btn.CommandArgument);

            Sessao.ID_Cliente = idCliente;
            Response.Redirect("View_perfil.aspx");

        }

        protected void Btn_viewCurriculo_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string[] argumentos = btn.CommandArgument.ToString().Split(';');
            Sessao.ID_Cliente_PDF = Convert.ToInt32(argumentos[0]);
            Sessao.ID_Profissional_PDF = Convert.ToInt32(argumentos[1]);
            string url = "../Cliente/curriculo/Curriculo_Profissional.aspx";
            string script = "window.open('" + url + "', '_blank');";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "AbrirNovaAba", script, true);

        }
    }
}