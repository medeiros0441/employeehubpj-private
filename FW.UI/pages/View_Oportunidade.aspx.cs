using FW.BLL;
using FW.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static FW.BLL.CandidaturaSimplificadaBLL;

namespace FW.UI
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
        protected CandidaturaSimplificadaBLL CandidaturaSimplificadaBLL = new CandidaturaSimplificadaBLL();
        protected CandidatoSimplificadoDTO CandidatoSimplificadoDTO = new CandidatoSimplificadoDTO();

        protected private static int ID_CandidatoSimplificado;
        protected private static string Email_CandidatoSimplificado;
        protected static int ID_Vaga;
        protected static string Email_Cliente = ClienteTemporario.Email_Cliente;

        protected static int ID_Profissional = ClienteTemporario.ID_Profissional;
        protected void Get_candidato()
        {
            Email_CandidatoSimplificado = Master.GetCookie("email_candidato_simplificado");
            ID_CandidatoSimplificado = Convert.ToInt32(Master.GetCookie("id_candidato_simplificado"));

            if (Email_CandidatoSimplificado != null)
            {
                CandidatoSimplificadoDTO = CandidaturaSimplificadaBLL.CosultarEmailCandidato(Email_CandidatoSimplificado);
                TxtNome.Text = CandidatoSimplificadoDTO.NomeCs;
                TxtEmail.Text = CandidatoSimplificadoDTO.EmailCs;
                TxtTelefone.Text = CandidatoSimplificadoDTO.TelefoneCs;
                ID_CandidatoSimplificado = CandidatoSimplificadoDTO.IdCandidatoCs;

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ID_Vaga = Convert.ToInt32(Request.QueryString["id_oportunidade"]);
            if (!IsPostBack)
            {
                Get_candidato();
                SelecionaVaga(ID_Vaga);
            }
            AlterText_BTN();

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
            }
            else
            {
                Master.MensagemJS("Erro", "Erro! Ao Selecionar Oportunidade.");
            }
            return VagaDTO;
        }

        protected void AbrirModal()
        {
            // Crie o script a ser injetado
            ScriptManager.RegisterStartupScript(this, this.GetType(), "AtivarModalFormaCandidatura", "OpenModal();", true);
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

                    }
                    catch
                    {
                        Master.MensagemJS("Erro", "Erro ao se cadastrar na vaga.!");
                    }
                }
                else
                {
                    AbrirModal();
                }

            }
            else
            {

                Master.MensagemJS("Alerta", "Falha, atualize a pagina!");
            }
        }
        protected bool AlterText_BTN()
        {
            bool status = false;
            if (ClienteTemporario.ID_Empresa == 0) {
                if (ID_Profissional != 0)
                {
                    status = CanditatoBLL.AutenticandoVeP(ID_Vaga, ID_Profissional);
                }
                 
                if (ID_CandidatoSimplificado != 0 && ID_Profissional == 0)
                {
                    status = CandidaturaSimplificadaBLL.VerificarRelacionamentoExistente(ID_CandidatoSimplificado, ID_Vaga);
                }

                if (status)
                {
                    BtnCadastrar.Enabled = false;
                    BtnCadastrar.Text = "Já está Cadastrado !";
                    return true;
                }
                BtnCadastrar.Text = "Enviar Currículo";
                return false;

            }
            BtnCadastrar.Visible =false;
            return false;

        }

        protected void Cadastrar_Click(object sender, EventArgs e)
        {
            InscricaoCandidato(ID_Profissional);
        }



        protected void BtnCandidaturaSimplificada_Click(object sender, EventArgs e)
        {

            try
            {
                bool status = AlterText_BTN();
                if (!status)
                {
                    CandidatoSimplificadoDTO DTO = new CandidatoSimplificadoDTO
                    {
                        NomeCs = TxtNome.Text,
                        EmailCs = TxtEmail.Text,
                        TelefoneCs = TxtTelefone.Text,
                        FkVagaCsr = ID_Vaga
                    };
                    if (File_Doc.HasFile)
                    {
                        byte[] arquivoBytes = new byte[File_Doc.PostedFile.ContentLength];
                        File_Doc.PostedFile.InputStream.Read(arquivoBytes, 0, File_Doc.PostedFile.ContentLength);

                        string nomeArquivo = File_Doc.PostedFile.FileName;

                        ArquivoManager.ArmazenarArquivo(arquivoBytes, nomeArquivo);

                        CandidaturaSimplificadaBLL BLL = new CandidaturaSimplificadaBLL();
                        if (DTO.NomeCs != null || DTO.EmailCs != null || DTO.TelefoneCs != null || DTO.FkVagaCsr != 0)
                        {
                            CandidatoSimplificadoDTO retorno = BLL.ProcessarCandidatura(DTO);
                            AlterText_BTN();
                            if (retorno.IdCandidatoCs != 0)
                            {
                                Master.SetSessionData("id_candidato_simplificado", DTO.IdCandidatoCs.ToString());
                                Master.SetSessionData("email_candidato_simplificado", DTO.EmailCs.ToString());
                                Master.MensagemJS("Sucesso", "Candidatura Feita. Enviamos uma confirmação  no seu e-mail e no da empresa.");
                            }
                            if (retorno.StatusCandidatoCs == "já está relacionado existe!")
                            {
                                Master.MensagemJS("Alerta", "Esse email já está relacionado!");
                            }
                            else if (retorno.StatusCandidatoCs == "operação Conculuida com sucesso!")
                            {
                                Master.SetSessionData("id_candidato_simplificado", retorno.IdCandidatoCs.ToString());
                                Master.SetSessionData("email_candidato_simplificado", retorno.EmailCs.ToString());
                                Master.MensagemJS("Sucesso", "Candidatura Feita. Enviamos uma confirmação  no seu e-mail e no da empresa.");

                            }
                            else if (retorno.StatusCandidatoCs == "operação Finalizada!")
                            {
                                Master.MensagemJS("Erro", "Ops, ouve algum erro interno.");
                            }
                        }
                        else
                        {
                            Master.MensagemJS("Erro", "Ops, Erro ao inserir valores.");
                        }
                    }
                    else
                    {
                        Master.MensagemJS("Alerta", "Ops, Precisa Selecionar o arquivo.");
                    }
                }
                else
                {
                    Master.MensagemJS("Alerta", "vôce já está candidatado.");
                }

            }
            catch(Exception ex) { 
                throw new Exception("Erro ao processar candidatura!" + ex.Message);
            }
        } 
    }
}
