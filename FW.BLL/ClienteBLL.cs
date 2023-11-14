using FW.DAL;
using FW.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FW.BLL
{
    

    public   class ObjetoCompartilhado
    {

        public DateTime DataHoraAtual
        {
            get { return DATA_HORA_BR.Data_Hora; }
        }
        protected Random GeradorCodigo = new Random();
         
         
        public bool ValidaCPF(int cpf)
        {
            if (cpf.ToString().Length != 11)
            {
                return false;
            }

            int soma1 = 0;
            int soma2 = 0;

            for (int i = 0; i < 9; i++)
            {
                soma1 += (10 - i) * int.Parse(cpf.ToString()[i].ToString());
                soma2 += (11 - i) * int.Parse(cpf.ToString()[i].ToString());
            }

            soma2 += 2 * int.Parse(cpf.ToString()[9].ToString());

            int digito1 = (soma1 * 10) % 11;
            int digito2 = (soma2 * 10) % 11;

            if (digito1 == 10)
            {
                digito1 = 0;
            }

            if (digito2 == 10)
            {
                digito2 = 0;
            }

            return digito1 == int.Parse(cpf.ToString()[9].ToString()) && digito2 == int.Parse(cpf.ToString()[10].ToString());
        }
        public bool ValidaCNPJ(int cnpj)
        {
            if (cnpj.ToString().Length != 14)
            {
                return false;
            }

            int[] multiplicadores1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma1 = 0;
            int soma2 = 0;

            for (int i = 0; i < 12; i++)
            {
                soma1 += int.Parse(cnpj.ToString()[i].ToString()) * multiplicadores1[i];
                soma2 += int.Parse(cnpj.ToString()[i].ToString()) * multiplicadores2[i];
            }

            soma2 += 2 * int.Parse(cnpj.ToString()[12].ToString());

            int digito1 = (soma1 % 11);
            int digito2 = (soma2 % 11);

            digito1 = digito1 < 2 ? 0 : 11 - digito1;
            digito2 = digito2 < 2 ? 0 : 11 - digito2;

            return digito1 == int.Parse(cnpj.ToString()[12].ToString()) && digito2 == int.Parse(cnpj.ToString()[13].ToString());
        }

    }
     
    public class ClienteBLL : ObjetoCompartilhado
    {


        protected ClienteDTO ClienteDTO = new ClienteDTO();

        protected ClienteDAL ClienteDAL = new ClienteDAL();
        protected TipoUserDAL TipoUserDAL = new TipoUserDAL();
        protected ProfissionalDAL ProfissionalDAL = new ProfissionalDAL();
        protected EmpresaDTO EmpresaDTO = new EmpresaDTO();
        protected EmpresaDAL EmpresaDAL = new EmpresaDAL();

        protected HistoricoDTO HistoricoDTO = new HistoricoDTO();
        protected HistoricoDAL HistoricoDAL = new HistoricoDAL();

        public void Cadastrar_Cliente(TipoUserDTO TipoUserDTO)
        {
            ProfissionalDTO ProfissionalDTO = new ProfissionalDTO();
            try
            {
                TipoUserDTO.StatusTu = true;
                int id_clienteR = ClienteDAL.Cadastrar(TipoUserDTO);

                TipoUserDTO.FkClienteTu = id_clienteR;
                TipoUserDAL.Cadastrar_Cliente(TipoUserDTO);
                TipoUserDTO TipoUserDTO_retorno = TipoUserDAL.AutenticarEmail(TipoUserDTO);

                if (TipoUserDTO_retorno.CodigoTu == 2)
                {
                    ProfissionalDTO.FkClienteTu = id_clienteR;
                    ProfissionalDTO.FkTipouserPf = TipoUserDTO_retorno.IdTipouser;
                    int id_profissional = ProfissionalDAL.Cadastrar(ProfissionalDTO);
                    ProfissionalDTO.IdProfissional = id_profissional;
                    ClienteTemporario.InfoCliente = ProfissionalDTO;
                }else
                if (TipoUserDTO_retorno.CodigoTu == 3)
                {
                    EmpresaDTO.FkClienteTu = id_clienteR;
                    EmpresaDTO.FkTipouserEp = TipoUserDTO_retorno.IdTipouser;
                    int id_empresa_R =  EmpresaDAL.Cadastrar(EmpresaDTO);
                    EmpresaDTO.IdEmpresa = id_empresa_R;
                    ClienteTemporario.InfoCliente = EmpresaDTO;


                }

                HistoricoDTO.FkClienteHt = id_clienteR;
                HistoricoDAL.Cadastrar_Inclusao(HistoricoDTO);
                ProcessadorBLL processadorBLL = new ProcessadorBLL();
                processadorBLL.Cadastro(id_clienteR, TipoUserDTO.PrimeiroNomeCl, TipoUserDTO.EmailCl);
            }
            catch (Exception ex)
            {
                LogBLL logBLL = new LogBLL();
                LogDTO logDTO = new LogDTO
                {
                    NivelGravidadeLg = "grave",
                    DescricaoSistemaLg = ex.Message,
                    FkSessaoLg = Sessao.SessaoDTO.IdSessao,
                    DadosAdicionaisLg = "Erro ao excutar ClienteBLL  metodo Cadastrar_Cliente.." + ex.ToString(),
                };
                logBLL.CadastrarLog(logDTO);

                throw new Exception("Erro ao cadastrar Cliente BLL" + ex.ToString());
            }
        }

        //Autentica

        public ClienteDTO ConsultarUsuario(ClienteDTO ClienteDTO)
        {
            return ClienteDAL.ConsultarUsuario(ClienteDTO);
        }
        public ClienteDTO ConsultarTelefone(string telefone_ddd_nume)
        {
            return ClienteDAL.ConsultarTelefone(telefone_ddd_nume);
        }

        public ClienteDTO ConsultarPorCpf(ClienteDTO ClienteDTO)
        {
            return ClienteDAL.ConsultarPorCpf(ClienteDTO);
        }

        public ClienteDTO ConsultarEmail(string email)
        {
            return ClienteDAL.ConsultarEmail(email);
        }
        public TipoUserDTO AutenticarTipouserPorIdCliente(int IdCliente )
        {
            return ClienteDAL.AutenticarTipouserPorIdCliente(IdCliente);
        }
      
        public int AutenticarEmailSenha(ClienteDTO ClienteDTO)
        {
            try
            {
                // Conecta ao banco de dados e executa a consulta SQL para buscar informações do usuário
                var retorno = ClienteDAL.AutenticarEmailSenha(ClienteDTO.EmailCl,ClienteDTO.SenhaCl);

               
                if (retorno != null)
                { 
                    if (retorno is ProfissionalDTO profissionalDTO)
                    {
                        ClienteTemporario.InfoCliente = profissionalDTO;
                        return  2;
                    }
                    else if (retorno is EmpresaDTO empresaDTO)
                    {
                        ClienteTemporario.InfoCliente = empresaDTO;

                        return 3;
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao autenticar usuário: " + ex.Message);
            }
        }
        public void Editar_Senha_Cliente(ClienteDTO ClienteDTO)
        {

            ClienteDAL.AtualizarSenha(ClienteDTO);

            HistoricoDTO.FkClienteHt = ClienteDTO.IdCliente;
            HistoricoDAL.Cadastrar_Senha(HistoricoDTO);
        }
        public void Editar_Email_cliente(ClienteDTO ClienteDTO)
        {

            
            ClienteDAL.Atualizar_Email_Cliente(ClienteDTO);

            HistoricoDTO.FkClienteHt = ClienteDTO.IdCliente;
            HistoricoDAL.Cadastrar_Senha(HistoricoDTO);
        }
        public void Editar_Dados_Cliente(ClienteDTO ClienteDTO)
        {

            ClienteDAL.Atualizar(ClienteDTO);
            HistoricoDTO.FkClienteHt = ClienteDTO.IdCliente;
            HistoricoDAL.Cadastrar_Senha(HistoricoDTO);
        }
        public void Editar_Endereco_cliente(ClienteDTO ClienteDTO)
        {

            ClienteDAL.AtualizarEndereco(ClienteDTO);

            HistoricoDTO.FkClienteHt = ClienteDTO.IdCliente;
            HistoricoDAL.Cadastrar_Senha(HistoricoDTO);
        }
        public void Editar_Foto_cliente(ClienteDTO ClienteDTO)
        {

            ClienteDAL.AtualizarUrlFotoCliente(ClienteDTO);

            HistoricoDTO.FkClienteHt = ClienteDTO.IdCliente;
            HistoricoDAL.Cadastrar_Senha(HistoricoDTO);
        }
        public ClienteDTO Selecionar_Foto(int IdCliente)
        {
            return ClienteDAL.Selecionar_Foto(IdCliente);
        }
         
        public ClienteDTO SelectAvancedCliente(int ID_Cliente)
        {
            return ClienteDAL.SelectAvancedCliente(ID_Cliente);
        }

        public ClienteDTO SelectBasicCliente(int ID_Cliente)
        {
            return ClienteDAL.SelectBasicCliente(ID_Cliente);
        }
        public ClienteDTO SelectEndereco(int ID_Cliente)
        {
            return ClienteDAL.SelectEndereco(ID_Cliente);
        }

        public List<ClienteDTO> Buscar_Cliente(ClienteDTO ClienteDTO)
        {
            return ClienteDAL.Buscar_Cliente(ClienteDTO);
        }
        public List<T> Lista_Cliente<T>() where T : new()
        {
            return ClienteDAL.Lista_Cliente<T>();
        }
    }
}
