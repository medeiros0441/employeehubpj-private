using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using FW.DAL;
using FW.DTO;
namespace FW.BLL
{
    public static class ArquivoManager
    {
        private static byte[] arquivo;
        private static string nomeArquivo;

        public static void ArmazenarArquivo(byte[] arquivoBytes, string nomeDoArquivo)
        {
            arquivo = arquivoBytes;
            nomeArquivo = nomeDoArquivo;
        }

        public static byte[] ObterArquivoArmazenado()
        {
            return arquivo;
        }

        public static string ObterNomeArquivo()
        {
            return nomeArquivo;
        }
    }

    public class CandidaturaSimplificadaBLL
    {
        protected CandidaturaSimplificadaDAL ObjDAL;
        protected EmpresaDAL EmpresaDAL;
        protected ClienteDAL ClienteDAL;
        protected ClienteDTO clienteDTO;
        protected EmailBLL EmailBLL;
        protected VagaBLL VagaBLL;
        protected VagaDTO VagaDTO;
        public CandidaturaSimplificadaBLL()
        {
            ObjDAL = new CandidaturaSimplificadaDAL();
            EmpresaDAL = new EmpresaDAL();
            ClienteDAL = new ClienteDAL(); clienteDTO = new ClienteDTO();
            EmailBLL = new EmailBLL();
            VagaBLL = new VagaBLL();
            VagaDTO = new VagaDTO();
        }
        public CandidatoSimplificadoDTO CosultarEmailCandidato(string email)
        {
           return  ObjDAL.ConsultarEmail(email); // Consulta o email do candidato
        }
        public  bool VerificarRelacionamentoExistente(int fkCandidato, int fkVaga)
        {
            return ObjDAL.VerificarRelacionamento(fkCandidato, fkVaga);
        }
        public CandidatoSimplificadoDTO ProcessarCandidatura(CandidatoSimplificadoDTO DTO)
        {
            try
            {
                bool relacionamento = false; // Variável que indica se há relacionamento
                CandidatoSimplificadoDTO retorno = ObjDAL.ConsultarEmail(DTO.EmailCs); // Consulta o email do candidato

                if (retorno == null && DTO.IdCandidatoCs ==0)
                {
                    // Se não há um candidato com o email consultado, realiza o insert do candidato
                    ObjDAL.InsertCandidato(DTO);
                }

                relacionamento = ObjDAL.VerificarRelacionamento(retorno.IdCandidatoCs, DTO.FkVagaCsr);

                if (relacionamento)
                {
                    //Já existe um relacionamento, não é necessário fazer mais nada
                    retorno.StatusCandidatoCs = "esse já está relacionado existe!";
                    return retorno;
                }
                else if (!relacionamento )
                {

                    retorno = ObjDAL.ConsultarEmail(DTO.EmailCs); // Consulta o email do para obter o id
                    // Se não há relacionamento, realiza o insert do relacionamento
                    relacionamento = ObjDAL.InsertRelacionamento(retorno.IdCandidatoCs, DTO.FkVagaCsr);
                }


                // Criar a candidatura apenas se há relacionamento e não foi tratado ainda
                if (relacionamento)
                {
                    VagaDTO = VagaBLL.SelecionarVaga(DTO.FkVagaCsr, true); // Seleciona a vaga
                    DTO.NomeVg = VagaDTO.NomeVg;
                    DTO.FkEmpresaVg = VagaDTO.FkEmpresaVg;

                    // Processar os emails somente se for um novo relacionamento
                    if (retorno != null || relacionamento)
                    {
                        ProcessandoEmail_Candidato(DTO); // Processa o email do candidato
                        ProcessandoEmail_Empresa(DTO); // Processa o email da empresa
                    }
                    ObjDAL.ConsultarEmail(DTO.EmailCs);// Consulta o email do para obter o id, colocando no cookie
                    retorno.StatusCandidatoCs = "operação Conculuida com sucesso!";
                    return retorno;  
                }

                  retorno.StatusCandidatoCs = "operação Finalizada!";
                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao processar candidatura simplificada, " + ex.Message);
            }
        }


        public void ProcessandoEmail_Candidato(CandidatoSimplificadoDTO DTO)
        {
            try
            {
                string Assunto = "Candidatura Simplificada";
                string Menssagem = $"Olá {DTO.NomeCs} A candidatura foi feita com sucesso para a vaga {DTO.NomeVg}, faça o cadastro em nosssa plataforma para receber as novidades";
                EmailBLL.Enviando_Email(DTO.EmailCs, Assunto, Menssagem, DTO.NomeCs);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao email candidato " + ex.Message);
            }
        }
        public void ProcessandoEmail_Empresa(CandidatoSimplificadoDTO DTO)
        {
            try
            {

                EmpresaDTO retornoEmpresa = EmpresaDAL.ConsultarPorId(DTO.FkEmpresaVg);
                string email = retornoEmpresa.EmailCl;
                string Assunto = "Candidato Simplificado";
                string Menssagem = $"Olá um cliente {DTO.NomeCs} em nosso site se candidatou na Oportunidade, foi uma candidatura simplificada" +
                    $" então nao armazenamos os dados, esse são os dados de contato {DTO.EmailCs} {DTO.TelefoneCs}, segue em anexo o Curriculo em pdf. ";
                byte[] arquivo = ArquivoManager.ObterArquivoArmazenado();
                string nome_arquivo = ArquivoManager.ObterNomeArquivo();
                if (email == null || Assunto == null || Menssagem == null || retornoEmpresa.PrimeiroNomeCl == null || arquivo == null || nome_arquivo == null)
                {
                    List<string> valoresNulos = new List<string>();

                    if (email == null)
                    {
                        valoresNulos.Add("email");
                    }
                    if (Assunto == null)
                    {
                        valoresNulos.Add("Assunto");
                    }
                    if (Menssagem == null)
                    {
                        valoresNulos.Add("Menssagem");
                    }
                    if (retornoEmpresa.PrimeiroNomeCl == null)
                    {
                        valoresNulos.Add("retornoEmpresa.PrimeiroNomeCl");
                    }
                    if (arquivo == null || arquivo.Length == 0)
                    {
                        valoresNulos.Add("arquivo");
                    }
                    if (nome_arquivo == null)
                    {
                        valoresNulos.Add("nome_arquivo");
                    }

                    string valoresNulosStr = string.Join(", ", valoresNulos.ToArray());
                    throw new ArgumentException("Os seguintes valores são nulos ou vazios: " + valoresNulosStr);
                }
                else
                {
                    EmailBLL.Enviando_Email(email, Assunto, Menssagem, retornoEmpresa.PrimeiroNomeCl, arquivo, nome_arquivo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao email empresa " + ex.Message);
            }
        }
    }
}
