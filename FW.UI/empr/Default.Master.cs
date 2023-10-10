using FW.BLL;
using FW.DTO;
using System;
using System.Web.UI;
using System.Web;
namespace FW.UI
{


    public partial class DefaultEmpresa : System.Web.UI.MasterPage
    {
      

        protected internal int ID_Cliente = ClienteTemporario.ID_Cliente;
        protected internal int ID_Empresa = ClienteTemporario.ID_Empresa;
        protected internal ProfissionalDTO ProfissionalDTO = new ProfissionalDTO();
        protected internal ProfissionalBLL ProfissionalBLL = new ProfissionalBLL();
        protected internal TipoUserDTO TipoUserDTO = new TipoUserDTO();
        protected internal TipoUserBLL TipoUserBLL = new TipoUserBLL();
        protected internal VagaDTO VagaDTO = new VagaDTO();
        protected internal VagaBLL VagaBLL = new VagaBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            Verificar_usuario();
        }

        protected internal void Verificar_usuario() {

            if (ID_Cliente == 0 & ID_Empresa == 0)
            {
                Response.Redirect("../default.aspx");
            }
        }
        protected void Sair_Click(object sender, EventArgs e)
        {
            Desconectar_user();

        }
        public string GetCookie(string name)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie != null)
            {
                return cookie.Value;
            }
            return null;
        }

        public void SetSessionData(string name, string value)
        {
            HttpCookie cookie = new HttpCookie(name, value)
            {
                Expires = DateTime.Now.AddDays(7)
            };
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        protected internal void Desconectar_user()
        {
            Sessao.DesconectUsuario();
                Response.Redirect("../default.aspx");
        }
        protected void Btn_Busca_Click(object sender, EventArgs e)
        {
            if (TxtBusca.Text != null && TxtBusca.Text != "")
            {
                Sessao.Tipo_Pesquisa = "Simples";
                TxtBusca.Text.Trim();
                TipoUserDTO.PrimeiroNomeCl = TxtBusca.Text;
                VagaDTO.NomeVg = TxtBusca.Text;
                Sessao.VagaDTO = VagaDTO;
                Sessao.TipoUserDTO = TipoUserDTO;
                Response.Redirect("Pesquisa_Lista.aspx");
            }
            else
            {
                MensagemJS("Erro", "Ops, O campo nome está vazio.");
            }
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
            Response.Redirect("Pesquisa_Lista.aspx");

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
            Response.Redirect("Pesquisa_Lista.aspx");

        }
        public void MensagemJS(string type ,string texto)
        { 
            ScriptManager.RegisterStartupScript(this, GetType(), "Alerta", $"alerta('{type}','{texto}');", true);

        }

        protected void BtnViewCliente_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            Sessao.ID_Cliente = ClienteTemporario.ID_Cliente;
            Response.Redirect("View_Perfil.aspx");
        }

        protected void Add_value_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            Sessao.ID_Vaga = 0;
            Response.Redirect("ListCandidatosEmpresa.aspx");
        }
    }
}