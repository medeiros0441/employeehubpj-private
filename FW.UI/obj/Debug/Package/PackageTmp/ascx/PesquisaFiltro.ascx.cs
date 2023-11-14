using FW.BLL;
using FW.DTO;
using System;
using System.Web;
using System.Web.UI;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.Services;
namespace FW.UI.ascx
{
    public partial class PesquisaFiltro : System.Web.UI.UserControl
    {


        protected TipoUserBLL TipoUserBLL = new TipoUserBLL();
        protected TipoUserDTO TipoUserDTO = new TipoUserDTO();
        protected VagaDTO VagaDTO = new VagaDTO();
        protected VagaBLL VagaBLL = new VagaBLL();
        protected ProfissionalDTO ProfissionalDTO = new ProfissionalDTO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_BuscaOportunidade_Click(object sender, EventArgs e)
        {


            txtTitulo_buscar.Text.Trim();
            if (txtTitulo_buscar.Text != "")
            {
                VagaDTO.NomeVg = txtTitulo_buscar.Text;
            }
            if (dllRegistro_pesquisa.SelectedValue != "0")
            {
                VagaDTO.TipoRegistroVg = dllRegistro_pesquisa.SelectedItem.Text;
            }
            if (ddlExperiencia.SelectedValue != "0")
            {
                VagaDTO.TempoExperienciaVg = ddlExperiencia.SelectedItem.Text;
            }
            if (DDLTipoVaga.SelectedValue != "0")
            {
                VagaDTO.TipoVagaVg = DDLTipoVaga.SelectedValue;
            }
            if (txtCidade.Text != "")
            {
                VagaDTO.DescricaoCidadeCl = txtCidade.Text;
            }
            if (txtUF.Text != "")
            {
                VagaDTO.DescricaoEstadoCl = txtUF.Text;
            }
            Sessao.Tipo_Pesquisa = "BuscaOportunidade";
            Sessao.VagaDTO = VagaDTO;
            Response.Redirect("../pages/Pesquisa_Lista.aspx");

        }
        protected void Btn_BuscaClientes_Click(object sender, EventArgs e)
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
            if (DdlFormacaoAcademica_pesquisa.SelectedValue != "0")
            {
                ProfissionalDTO.FormacaoEscolarPf = DdlFormacaoAcademica_pesquisa.SelectedValue.ToString();
            }
            if (ddlSexo_pesquisa.SelectedValue != "0")
            {
                ProfissionalDTO.SexoCl = ddlSexo_pesquisa.SelectedValue.ToString();
            }

            Sessao.Tipo_Pesquisa = "BuscaCliente";
            Sessao.ProfissionalDTO = ProfissionalDTO;
            Response.Redirect("../pages/Pesquisa_Lista.aspx");

        }
 
}

}