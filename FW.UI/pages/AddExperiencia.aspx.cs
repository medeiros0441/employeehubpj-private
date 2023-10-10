using FW.BLL;
using FW.DTO;
using System;
using System.Globalization;
using System.Web.UI.WebControls;

namespace FW.UI.pages
{
    public partial class AddExperiência : System.Web.UI.Page
    {

        protected ExperienciaBLL ExperienciaBLL = new ExperienciaBLL();
        protected ExperienciaDTO ExperienciaDTO = new ExperienciaDTO();

        protected int ID_Profissional = ClienteTemporario.ID_Profissional;
        protected int ID_Cliente = ClienteTemporario.ID_Cliente;
        protected static int IdExperiencia;

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Verificar_usuario();


            if (IdExperiencia != 0)
            {
                if (!IsPostBack)
                {
                    PlEditar.Visible = true;
                    Seleciona(IdExperiencia);
                }
            }
            else
            {
                AbrindoLista();
            }

        }

        protected void LkEditar_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            int IdExperienciabtn = Convert.ToInt32(button.CommandArgument);
            Seleciona(IdExperienciabtn);
            IdExperiencia = IdExperienciabtn;

        }

        protected void Seleciona(int idExperiencia)
        {

            ExperienciaDTO = ExperienciaBLL.SelecionaExperienciaID(idExperiencia);
            if (ExperienciaDTO != null)
            {
                AbrindoFormulario();

                PlCadastrar.Visible = false;
                PlEditar.Visible = true;

                txtCargo.Text = ExperienciaDTO.NomeCargoEx;
                txtEmpresa.Text = ExperienciaDTO.NomeEmpresaEx;
                ddlTipoCa.Text = ExperienciaDTO.TipoContratoEx;
                txtDataInicio.Text = ExperienciaDTO.DateInicioEx.ToString("MM/yyyy"); 
                txtDataFinal.Text = ExperienciaDTO.DateFinalizouEx.ToString("MM/yyyy");
                txtDescricao.Text = ExperienciaDTO.DescricaoEx;
                ExperienciaDTO.FkProfissionalEx = Convert.ToInt32(ID_Profissional);
                ExperienciaDTO.IdExperiencia = Convert.ToInt32(idExperiencia);
            }
            else
            {
                Master.MensagemJS("Erro", "Erro! ao Selecionar Experiencia!");

            }
        }
        protected void FiltroLista(int id_cliente)
        {
            RptListaExperiencia.DataSource = ExperienciaBLL.Listar_Experiencia_Profissional(id_cliente);
            RptListaExperiencia.DataBind();
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {


            Result result = MetodoSetDTO();
            if (ID_Profissional != 0 && result.Status == true && IdExperiencia != 0)
            {
                ExperienciaDTO.FkProfissionalEx = ID_Profissional;
                ExperienciaBLL.EditarExperiencia(result.ExperienciaDTO);
                Master.MensagemJS("Sucesso", "Editado com Sucesso!");
                Limpar();
                AbrindoLista();
            }
        }
        protected void Cadastrar_Click(object sender, EventArgs e)
        {
            Result result = MetodoSetDTO();
            if (ID_Profissional != 0 && result.Status == true)
            {
                ExperienciaBLL.CadastrarExperiencia(result.ExperienciaDTO);
                AbrindoLista();
                Master.MensagemJS("Sucesso", "Expêrincia cadastrado com Sucesso!");
                Limpar();
                AbrindoLista();
            } 
        }

        protected void Limpar()
        {
            txtCargo.Text =
            txtEmpresa.Text =
            txtDescricao.Text =
            txtDataInicio.Text =
            txtDataFinal.Text = string.Empty;
            ddlTipoCa.SelectedValue = "1";
        }



        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            Limpar();
            AbrindoLista();

        }
         
        public class Result 
        {
            public   bool Status { get; set; }
            public   ExperienciaDTO ExperienciaDTO { get; set; }
        }
        public Result MetodoSetDTO()
        {
            Result result = new Result();
            if (ID_Profissional != 0)
            {
                ExperienciaDTO.NomeCargoEx = txtCargo.Text;
                ExperienciaDTO.NomeEmpresaEx = txtEmpresa.Text;
                ExperienciaDTO.DescricaoEx = txtDescricao.Text;
                ExperienciaDTO.TipoContratoEx = ddlTipoCa.SelectedValue;
                if (DateTime.TryParseExact(txtDataInicio.Text, "MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataInicio) &&
                 DateTime.TryParseExact(txtDataFinal.Text, "MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataFinal))
                {
                    ExperienciaDTO.DateInicioEx = dataInicio;
                    ExperienciaDTO.DateFinalizouEx = dataFinal;
                    ExperienciaDTO.TipoContratoEx = ddlTipoCa.Text;
                    ExperienciaDTO.FkProfissionalEx = ID_Profissional;
                    ExperienciaDTO.IdExperiencia = IdExperiencia;
                    result.Status = true;
                    result.ExperienciaDTO = ExperienciaDTO;
                    return result;
                }
                else
                {
                    Master.MensagemJS("Erro", "As datas estão inválidas");

                }
            }
            else
            {
                Master.MensagemJS("Erro", "Erro ao editar experiência!");
            }
            result.Status = false;
            return result;
        }
        protected void BtnExcluir_Click(object sender, EventArgs e)
        {


           

            if (IdExperiencia != 0 && ID_Profissional  != 0)
            {

                ExperienciaBLL.ExcluirExperiencia(ID_Profissional, IdExperiencia);
                AbrindoLista();
                Limpar();
                Master.MensagemJS("Sucesso", "Excluido com Sucesso!");
            }
            else
            {
                Master.MensagemJS("Erro", "Erro! ao Excluir Experiencia!");
            }
        }


        protected void AbrindoFormulario()
        {
            PnList.Visible = false;
            PnFormulario.Visible = true;

            AbrirList.Visible = true;
            AbrirFormulario.Visible = false;
        }

        protected void AbrindoLista()
        {
            FiltroLista(ID_Cliente);
            PnList.Visible = true;
            PnFormulario.Visible = false;
            AbrirFormulario.Visible = true;
            AbrirList.Visible = false;
            PlCadastrar.Visible = false;
            PlEditar.Visible = false;
        }

        protected void AbrirList_Click(object sender, EventArgs e)
        {
            Limpar();
            AbrindoLista();

        }

        protected void AbrirFormulario_Click(object sender, EventArgs e)
        {
            AbrindoFormulario(); Limpar();
            PlCadastrar.Visible = true;

        }
    }
}