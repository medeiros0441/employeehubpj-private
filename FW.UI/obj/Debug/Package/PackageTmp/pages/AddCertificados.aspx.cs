using FW.BLL;
using FW.DTO;
using System;
using System.Globalization;
using System.Web.UI.WebControls;

namespace FW.UI.pages
{
    public partial class AddCertificados : System.Web.UI.Page
    {

        protected CertificadoBLL CertificadoBLL = new CertificadoBLL();
        protected CertificadoDTO CertificadoDTO = new CertificadoDTO();

        protected int ID_Profissional = ClienteTemporario.ID_Profissional ;
        // string Email = Sessao.EmailUser;
        protected static int idcertificado;


        protected void Page_Load(object sender, EventArgs e)
        {


            if (ID_Profissional == 0)
            {
                Response.Redirect("~/default.aspx");
            }
            if (!IsPostBack)
            {
                AbrirLista();
            }

        }
        protected void FiltroLista(int idprofissional)
        {
            RptListaCertificado.DataSource = CertificadoBLL.ListarCertificado_IDProfissional(idprofissional);
            RptListaCertificado.DataBind();
        }

        protected void SelecionaCertificado(int idcertificado)
        {

            CertificadoDTO = CertificadoBLL.SelecionarCertificado(idcertificado);

            if (CertificadoDTO != null)
            {
                AbrindoFormulario();
                PlEditar.Visible = true;
                txtCurso.Text = CertificadoDTO.NomeCursoCf;
                txtInstituiçao.Text = CertificadoDTO.NomeInstituicaoCf;
                txtDataInicio.Text = CertificadoDTO.DateInicioCf.ToString("MM/yyyy");
                txtDataFinal.Text = CertificadoDTO.DateFinalizouCf.ToString("MM/yyyy");
                txtDescricaoCurso.Text = CertificadoDTO.DescricaoCf;

                

                PlEditar.Visible = true;
                PlCadastrar.Visible = false;

            }
            else
            {
                PnList.Visible = true;
                PnFormulario.Visible = false;
                Master.MensagemJS("Erro", "Erro! ao Selecionar Certificado!");


            }

        }
        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            Result result = MetodoSetDTO();
            if (idcertificado != 0 && ID_Profissional != 0 && result.Status == true)
            {
                CertificadoDTO.IdCertificado = idcertificado;
                CertificadoBLL.EditarCertificado(result.CertificadoDTO);
                AbrirLista();
                Master.MensagemJS("Sucesso", "Certificado Editado com Sucesso!");
            }
        }


        protected void Cadastrar_Click(object sender, EventArgs e)
        {
            Result result = MetodoSetDTO();
            if (ID_Profissional != 0 && result.Status == true)
            {
                CertificadoBLL.CadastrarCertificado(result.CertificadoDTO);
                AbrirLista();

                AbriForm.Visible = true;
                AbrirList.Visible = false;
                Master.MensagemJS("Sucesso", "Certificado editado com Sucesso!");
                Limpar();
            } 
        }
        public class Result
        {
            public bool Status { get; set; }
            public CertificadoDTO CertificadoDTO { get; set; }
        }
        public Result MetodoSetDTO()
        {
            Result result = new Result();
            if (ID_Profissional != 0)
            {

                CertificadoDTO.NomeCursoCf = txtCurso.Text;
                CertificadoDTO.NomeInstituicaoCf = txtInstituiçao.Text;
                CertificadoDTO.DescricaoCf = txtDescricaoCurso.Text;
                if (DateTime.TryParseExact(txtDataInicio.Text, "MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataInicio) &&
                       DateTime.TryParseExact(txtDataFinal.Text, "MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataFinal))
                {
                    CertificadoDTO.DateInicioCf = dataInicio;
                    CertificadoDTO.DateFinalizouCf = dataFinal;
                    CertificadoDTO.FkProfissionalCf = ID_Profissional;
                    CertificadoDTO.IdCertificado = idcertificado;
                    result.Status = true;
                    result.CertificadoDTO = CertificadoDTO;
                    return result;
                }
                else
                {
                    // Trate o caso em que a conversão falhou
                    Master.MensagemJS("Erro", "as datas estão invalida");
                }
            }
            else
            {
                Master.MensagemJS("Erro", "Erro ao editar experiência!");
            }
            result.Status = false;
            return result;
        }
        protected void Limpar()
        {

            txtCurso.Text =
            txtInstituiçao.Text =
            txtDataInicio.Text =
            txtDataFinal.Text =
            txtDataFinal.Text =
            txtDescricaoCurso.Text = string.Empty;
            txtCurso.Focus();

        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
            AbrirLista();

        }

        protected void AbrindoFormulario()
        {


            AbriForm.Visible = false;
            AbrirList.Visible = true;
             

            PlEditar.Visible = false;
            PlCadastrar.Visible = true;

            Limpar();
            PnList.Visible = false;
            PnFormulario.Visible = true;
        }

        protected void AbrirLista()
        {

            FiltroLista(ID_Profissional);
            AbriForm.Visible = true;
            AbrirList.Visible = false;

            PlEditar.Visible = false;
            PlCadastrar.Visible = false;
            PnList.Visible = true;
            PnFormulario.Visible = false;
        }

        
        protected void BtnExcluir_Click(object sender, EventArgs e)
        {

            if (idcertificado != 0 && ID_Profissional != 0)
            {
                CertificadoBLL.ExcluirCertificado(idcertificado);
                Limpar();
                AbrirLista();
                Master.MensagemJS("Sucesso", "Certificado Excluido com Sucesso!");
            }
            else
            {
                Master.MensagemJS("Erro", "Erro ao Excluir!");
            }
        }

        protected void LkEditar_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            int idcertificado_btn = Convert.ToInt32(button.CommandArgument);
            idcertificado = idcertificado_btn;
            SelecionaCertificado(idcertificado_btn);
        }

        protected void AbriForm_Click(object sender, EventArgs e)
        {
            AbrindoFormulario();
            Limpar();

        }

        protected void AbrirList_Click(object sender, EventArgs e)
        {
            AbrirLista();
        }
    }
}