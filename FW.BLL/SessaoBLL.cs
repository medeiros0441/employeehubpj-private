using FW.DAL;
using FW.DTO;
using System;
using System.Collections.Generic;
using System.Web;


namespace FW.BLL
{
    public class SessaoBLL : ObjetoCompartilhado
    {

        protected SessaoDAL SessaoDAL = new SessaoDAL();




        public SessaoDTO CadastrarSessao(SessaoDTO sessao)
        {
            try
            {
                // Consultar a sessão por IP do cliente e navegador
                SessaoDTO retorno_sessao = SessaoDAL.ConsultarSessaoPorIpCliente(sessao.IpClienteSs, sessao.NavegadorSs);

                if (retorno_sessao == null)
                {
                    // Se a sessão não existe, cadastrar uma nova
                    sessao.StatusSs = true;
                    sessao.DateTimeInsertSs = DataHoraAtual;
                    sessao.IniciouSs = DataHoraAtual;
                    int id = SessaoDAL.CadastrarSessao(sessao);
                    sessao = ConsultarSessaoPorId(id);

                    // Adicionar a sessão temporária à verificação de sessões
                    Sessao.VerificarSessao.AdicionarSessaoTemporaria(sessao);

                    return sessao;
                }
                else
                {
                    // Se a sessão já existe, adicionar a sessão temporária à verificação de sessões
                    Sessao.VerificarSessao.AdicionarSessaoTemporaria(retorno_sessao);
                    return retorno_sessao;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar sessão!" + ex.Message);
            }

        }
        public SessaoDTO ConsultarSessaoPorIpCliente(string ip_Cliente, string navegador)
        {
            try
            {
                return SessaoDAL.ConsultarSessaoPorIpCliente(ip_Cliente, navegador);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar sessão por id!" + ex.Message);
            }
        }
        public SessaoDTO ConsultarSessaoPorId(int idSessao)
        {
            try
            {
                return SessaoDAL.ConsultarSessaoPorId(idSessao);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao consultar sessão por id!" + ex.Message);
            }
        }

        public void AtualizarSessao(SessaoDTO sessao)
        {
            try
            {
                SessaoDAL.Atualizar_Sessao(sessao);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar sessão!" + ex.Message);
            }
        }
    }

   
}
