using FW.BLL;
using FW.DTO;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace FW.UI
{
    public partial class ListProfissionais : System.Web.UI.Page
    {
        protected ProfissionalBLL ProfissionalBLL = new ProfissionalBLL();
        protected ProfissionalDTO ProfissionalDTO = new ProfissionalDTO();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FiltroProfissional(ProfissionalBLL.ListaProfissional());
            }
        }
        protected void FiltroProfissional(List<ProfissionalDTO> Lista)
        {
            if (Lista.Count > 0)
            {
                rpt_cliente.DataSource = Lista;
                rpt_cliente.DataBind();
                rptPro1.DataSource = Lista;
                rptPro1.DataBind();

            }
            else
            {
                Master.MensagemJS("Alerta", "Nenhum resultado Ao buscar");
            }

        }

        protected void InsereDTO()
        {

            if (txtNome_pesquisa.Text != "")
            {
                ProfissionalDTO.PrimeiroNomeCl = txtNome_pesquisa.Text;
            }
            if (txtUsuario_pesuisa.Text != "")
            {
                ProfissionalDTO.UsuarioCl = txtUsuario_pesuisa.Text;
            }
            if (txtCidade.Text != "")
            {
                ProfissionalDTO.DescricaoCidadeCl = txtCidade.Text;
            }
            if (txtUF.Text != "")
            {
                ProfissionalDTO.DescricaoEstadoCl = txtUF.Text;
            }
            if(DdlFormacaoAcademica_pesquisa.SelectedValue != "0")
            {
                ProfissionalDTO.FormacaoEscolarPf = DdlFormacaoAcademica_pesquisa.SelectedValue.ToString();
            }if(ddlSexo_pesquisa.SelectedValue != "0")
            {
                ProfissionalDTO.SexoCl = ddlSexo_pesquisa.SelectedValue.ToString();
            }

            FiltroProfissional(ProfissionalBLL.Pesquisa_profissional(ProfissionalDTO));
        }

        protected void Btn_buscarCliente_Click(object sender, EventArgs e)
        {
            InsereDTO();
        }
        public void Btn_viewCliente_Command(object sender, EventArgs e)
        {

            LinkButton btn = (LinkButton)sender;
            Sessao.ID_Cliente = Convert.ToInt32(btn.CommandArgument);
            Response.Redirect("View_Perfil.aspx");
        }
    }
}