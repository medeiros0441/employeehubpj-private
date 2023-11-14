using FW.BLL;
using FW.DTO;
using System;
using System.Web.UI.WebControls;
using System.Web;
namespace FW.UI.pages
{
    public partial class EditarVagas : System.Web.UI.Page
    {
        protected  static int id_vaga;

        protected internal ClienteDTO ClienteDTO = new ClienteDTO();
        protected internal ClienteBLL ClienteBLL = new ClienteBLL();
        protected internal VagaDTO VagaDTO = new VagaDTO();
        protected internal VagaBLL VagaBLL = new VagaBLL();

        protected private int ID_Cliente  = ClienteTemporario.ID_Cliente;
        protected private int ID_Empresa  = ClienteTemporario.ID_Empresa;

        protected void Page_Load(object sender, EventArgs e)
        {

            Master.Verificar_usuario();
            if (!IsPostBack)
            {
                AbrirLista();
            }
        }
        protected void FiltroLista(int ID_empresa)
        {
            VagaBLL VagaBLL = new VagaBLL();

            RptListaVaga.DataSource = VagaBLL.Listar_Vagas_ativa_Empresa(ID_empresa);
            RptListaVaga.DataBind();
        }

        protected void SelecionaVaga(int id_vaga)
        {

            VagaDTO = VagaBLL.SelecionarVagaAtivaEmpresa(id_vaga, ID_Empresa);
            if (VagaDTO != null)
            {
                AbrindoFormulario();
                PlEditar.Visible = true;
                txtTitulo.Text = VagaDTO.NomeVg;
                DDLExperiencia.SelectedValue = VagaDTO.TempoExperienciaVg.ToString();
                DDLStatus.SelectedValue = VagaDTO.StatusVg ? "Ativo" : "Desativado";
                DDLTipoContrato.SelectedValue = VagaDTO.TipoRegistroVg.ToString();
                DDLTipoVaga.SelectedValue = VagaDTO.TipoVagaVg.ToString();
                DDLSexo.SelectedValue = VagaDTO.SexoVg;
                DDLValidade.SelectedValue = VagaDTO.DescricaoValidadeVg;
                txtDescricao.Text = VagaDTO.DescricaoVg; 
                PlEditar.Visible = true;
                PlCadastrar.Visible = false;
            }
            else
            {
                PnList.Visible = true;
                pn_Editar_Vagas.Visible = false;
                Master.MensagemJS("Erro", "Erro! Ao Selecionar Oportunidade!");

            }

        }

        protected void Cadastrar_Click(object sender, EventArgs e)
        {

            SalvarVaga();
        }


        protected void Limpar()
        {
            txtTitulo.Text = string.Empty;
            DDLExperiencia.SelectedValue = "0";
            DDLTipoContrato.SelectedValue = "0";
            DDLSexo.SelectedValue = "0";
            DDLSexo.SelectedValue = "0";
            DDLValidade.SelectedValue = "0";
            txtDescricao.Text = string.Empty;
            txtTitulo.Focus();

        }

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
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
            pn_Editar_Vagas.Visible = true;
        }

        protected void AbrirLista()
        {
          id_vaga = 0;
            FiltroLista(ID_Empresa);
            AbriForm.Visible = true;
            AbrirList.Visible = false;
            PlEditar.Visible = false;
            PlCadastrar.Visible = false;
            PnList.Visible = true;
            pn_Editar_Vagas.Visible = false;
        }


        protected void SalvarVaga(int Id_vaga = 0)
        {

            if (ID_Empresa != 0)
            {
                VagaDTO.NomeVg = txtTitulo.Text;
                VagaDTO.TempoExperienciaVg = DDLExperiencia.SelectedValue;
                VagaDTO.StatusVg =  DDLStatus.SelectedValue == "Ativo" ? true : false;
                VagaDTO.TipoVagaVg = DDLTipoVaga.SelectedValue;
                VagaDTO.TipoRegistroVg = DDLTipoContrato.SelectedValue;
                VagaDTO.SexoVg = DDLSexo.SelectedValue;
                VagaDTO.DescricaoValidadeVg = DDLValidade.SelectedValue;
                VagaDTO.DescricaoVg = txtDescricao.Text;
                VagaDTO.FkEmpresaVg = ID_Empresa;
                VagaDTO.IdVaga = Id_vaga;
                if (VagaDTO.IdVaga == 0) {
                    VagaBLL.CadastrarVaga(VagaDTO);
                   
                    Master.MensagemJS("Sucesso", "Vaga Publicada com Sucesso!");
                }
                else
                {
                    VagaBLL.EditarVaga(VagaDTO);
                    Master.MensagemJS("Sucesso", "Editado com Sucesso!");
                }
                    AbrirLista();
                Limpar();

            }
            else
            {
                Master.MensagemJS("Erro", "Erro ao Editar!");
            }

        }


        protected void BtnEditar_Click(object sender, EventArgs e)
        {

            SalvarVaga(id_vaga);
        }

        protected void BtnExcluir_Click(object sender, EventArgs e)
        {
            DeleteVaga(id_vaga); 
            AbrirLista(); 
            Limpar();
        }
        protected void DeleteVaga(int id_vaga)
        {
            if (id_vaga != 0 && ID_Empresa != 0)
            {
                VagaDTO.FkEmpresaVg = ID_Empresa;
                VagaDTO.IdVaga = id_vaga;
                VagaBLL.ExcluirVaga(VagaDTO);
                Limpar();
                Master.MensagemJS("Sucesso", "Oportunidade Excluida!");
                AbrirLista();
            }
            else
            {
                Master.MensagemJS("Erro", "Erro Ao Excluir!");
                Response.Redirect(Request.RawUrl);
            }
        }


        protected void AbriForm_Click(object sender, EventArgs e)
        {
            AbrindoFormulario();
            Limpar();

        }

        protected void AbrirList_Click(object sender, EventArgs e)
        {
            AbrirLista(); Limpar();
        }

        protected void LkEditar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            id_vaga = Convert.ToInt32(btn.CommandArgument);
            SelecionaVaga(id_vaga);
        }

        protected void LkViewCandidato_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
          Sessao.ID_Vaga =  Convert.ToInt32(btn.CommandArgument);
            Response.Redirect("ListCandidatosEmpresa.aspx");


        }
    }
}