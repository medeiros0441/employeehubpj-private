using FW.BLL;
using FW.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FW.UI.pro
{
    public partial class View_Oportunidade : System.Web.UI.Page
    {
        protected CandidatoDTO CanditatoDTO = new CandidatoDTO();
        protected CandidatoBLL CanditatoBLL = new CandidatoBLL();

        protected VagaBLL VagaBLL = new VagaBLL();
        protected VagaDTO VagaDTO = new VagaDTO();

        protected ProfissionalBLL SelecionaBLL = new ProfissionalBLL();
        protected ProfissionalDTO SelecinaDTO = new ProfissionalDTO();
        protected CandidatoDTO CandidatoDTO = new CandidatoDTO();

        protected static int ID_Vaga;
        protected static string Email_Cliente = ClienteTemporario.Email_Cliente;

        protected static int ID_Profissional = ClienteTemporario.ID_Profissional;

        protected void Page_Load(object sender, EventArgs e)
        {
            ID_Vaga = Convert.ToInt32(Request.QueryString["id_oportunidade"]);
            if (!IsPostBack)
            {
                SelecionaVaga(ID_Vaga);
            }
        }

        protected VagaDTO SelecionaVaga(int ID_Vaga)
        {

            VagaDTO = VagaBLL.SelecionarVaga(ID_Vaga, true);
            if (VagaDTO.IdVaga != 0)
            {
                lblVaga.Text = VagaDTO.NomeVg;
                lblExperiencia.Text = VagaDTO.TempoExperienciaVg;
                LblTipoVaga.Text = VagaDTO.TipoVagaVg;
                lblResgistro.Text = VagaDTO.TipoRegistroVg;
                lblSexo.Text = VagaDTO.SexoVg;
                LblCidade.Text = VagaDTO.DescricaoCidadeCl;
                LblEstado.Text = VagaDTO.DescricaoEstadoCl;
                lblDescricao.Text = VagaDTO.DescricaoVg.Replace(Environment.NewLine, "<br />");

                FiltroVagaSimilares(VagaDTO);
                AlterText_BTN(VagaDTO.IdVaga, ID_Profissional);
            }
            else
            {
                Master.MensagemJS("Erro", "Erro! Ao Selecionar Oportunidade.");
            }
            return VagaDTO;
        }



        protected void FiltroVagaSimilares(VagaDTO VagaDTO)
        {
            //gerando uma nova DTO para buscar somente pelo nome;
            VagaDTO VagaDTO2 = new VagaDTO
            {
                NomeVg = VagaDTO.NomeVg
            };
            List<VagaDTO> vagas = VagaBLL.BuscarVaga(VagaDTO2);
            // Remover a vaga atual da lista de vagas similares
            vagas = vagas.Where(v => v.IdVaga != VagaDTO.IdVaga).ToList();
            rptVaga1.DataSource = vagas;
            rptVaga1.DataBind();
        }


        protected void InscricaoCandidato(int ID_Profissional = 0)
        {
            if (ID_Vaga != 0)
            {
                if (ID_Profissional != 0)
                {
                    try
                    {
                        CanditatoDTO.FkVagaCt = ID_Vaga;
                        CanditatoDTO.FkProfissionalCt = ID_Profissional;
                        CanditatoBLL.Cadastrar_Profissional_Vaga(CanditatoDTO);
                        Master.MensagemJS("Sucesso", "Cadastrado com Sucesso!");
                        AlterText_BTN(ID_Vaga, ID_Profissional);
                    }
                    catch
                    {
                        Master.MensagemJS("Erro", "Erro ao se cadastrar na vaga.!");
                    }
                }
                else
                {

                    Master.MensagemJS("Alerta", "Pra se candidatar precisamos que faça o login!");
                }

            }
            else
            {

                Master.MensagemJS("Alerta", "Falha, atualize a pagina!");
            }
        }
        protected bool AlterText_BTN(int ID_Vaga, int ID_Profissional)
        {
            bool status = CanditatoBLL.AutenticandoVeP(ID_Vaga, ID_Profissional);
            if (status)
            {
                BtnCadastrar.Enabled = false;
                BtnCadastrar.Text = "Já está Cadastrado !";
                return true;
            }
            BtnCadastrar.Text = "Enviar Currículo";
            return false;
        }

        protected void Cadastrar_Click(object sender, EventArgs e)
        {
            InscricaoCandidato(ID_Profissional);
        }
    }
}