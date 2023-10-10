using FW.DAL;
using FW.DTO;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Web;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FW.BLL
{
    public static class DATA_HORA_BR 
    {
        private static readonly TimeZoneInfo _timeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
        public static DateTime Data_Hora => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _timeZone);
        public static DateTime Data => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _timeZone).Date;
        public static TimeSpan Hora => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _timeZone).TimeOfDay;
    }
    public static class ClienteTemporario
    {
        // Obtém o contexto HTTP atual
        private static readonly HttpContext httpContext = HttpContext.Current;
        public static int ID_Empresa
        {
            get
            {
                if (InfoCliente != null && InfoCliente is EmpresaDTO dTO)
                {
                    return dTO.IdEmpresa;
                }
                else
                {
                    return 0; // ou outra ação, dependendo do comportamento desejado
                }
            }
        }
        public static int ID_Cliente
        {
            get
            {
                if (InfoCliente != null)
                {
                    if (InfoCliente is ProfissionalDTO DTO2)
                    {
                        return DTO2.FkClienteTu;
                    }
                    if (InfoCliente is EmpresaDTO DTO)
                    {
                        return DTO.FkClienteTu;
                    }
                }
                return 0;
            }
        }
    

        private static readonly string _IP_Cliente = httpContext.Request.UserHostAddress;
        public static string IP_Cliente
        {
            get { return ClienteTemporario._IP_Cliente; }
        }
        private static readonly string _Navegador_Cliente = httpContext.Request.UserAgent;
        public static string Navegador_Cliente
        {
            get { return ClienteTemporario._Navegador_Cliente; }
        }

        public static string Email_Cliente
        {

            get
            {
                if (InfoCliente != null)
                {
                    if (InfoCliente is ProfissionalDTO dto2)
                    {
                        return dto2.EmailCl;
                    }
                    if (InfoCliente is EmpresaDTO dto)
                    {
                        return dto.EmailCl;
                    }
                }
                return null;
            }
        }
        public static int Codigo_TU
        {
            get
            {
                if (InfoCliente != null)
                {
                    if (InfoCliente is ProfissionalDTO DTO2)
                    {
                        return DTO2.CodigoTu;
                    }
                    if (InfoCliente is EmpresaDTO DTO)
                    {
                        return DTO.CodigoTu;
                    }
                }
                return 0;
            }
        }

        public static int ID_Profissional
        {
            get
            {
                if (InfoCliente != null && InfoCliente is ProfissionalDTO DTO)
                {
                    return DTO.IdProfissional;

                }
                return 0;
            }
        }
        // Declaração do objeto que será utilizado para sincronização de threads

        // Propriedade estática para armazenar o objeto do cliente temporário
        private static   object _infoCliente;

        // Propriedade pública que expõe o objeto do cliente temporário
        public static object InfoCliente
        {
            get
            {
                    // Verifica se o objeto do cliente temporário é um ProfissionalDTO
                    if (_infoCliente is ProfissionalDTO dTO)
                    {
                        return dTO; // Retorna o objeto como ProfissionalDTO
                    }
                    // Verifica se o objeto do cliente temporário é um EmpresaDTO
                    else if (_infoCliente is EmpresaDTO empresaDTO)
                    {
                        return empresaDTO; // Retorna o objeto como EmpresaDTO
                    }
                    return null; // Retorna o objeto como EmpresaDTO
            }
            set
            {
                    // Verifica se o valor atribuído é um ProfissionalDTO ou um EmpresaDTO
                    if (value is ProfissionalDTO || value is EmpresaDTO )
                    {
                        _infoCliente = value; // Atribui o valor ao objeto do cliente temporário
                    }
                    // Se o valor atribuído não é nem ProfissionalDTO nem EmpresaDTO, lança uma exceção
                    else
                    {
                        InfoCliente = null; //   throw new ArgumentException("Tipo de cliente inválido.");
                    }
            }
        }
    }




    public static class Sessao  
    {
        public static int InserindoValor(string email, string senha)
        {
            ClienteDAL ClienteDAL = new ClienteDAL();

            try
            {
                // Conecta ao banco de dados e executa a consulta SQL para buscar informações do usuário
                var retorno = ClienteDAL.AutenticarEmailSenha(email, senha);

                if (retorno == null)
                {
                    throw new Exception("Usuário não encontrado");
                }
                else
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
        public static bool DesconectUsuario()
        {
            
          
           
            if (ClienteTemporario.InfoCliente is ProfissionalDTO ProfissionalDTO)
            {
                ClienteTemporario.InfoCliente = ProfissionalDTO;
            }
            if (ClienteTemporario.InfoCliente is EmpresaDTO EmpresaDTO)
            {
                ClienteTemporario.InfoCliente = EmpresaDTO;
            }
            if (ClienteTemporario.ID_Cliente != 0)
            {
                return false;
            }
            return true;
        }



        public static class VerificarSessao
        {
            // Lista estática para armazenar as sessões temporárias
            private static readonly List<SessaoDTO> sessoesTemporarias = new List<SessaoDTO>();

            // Thread para verificar sessões inativas
            private static Thread verificadorSessoesInativas;

            // Método para adicionar uma nova sessão temporária na lista
            public static void AdicionarSessaoTemporaria(SessaoDTO sessao)
            {
                sessoesTemporarias.Add(sessao);
            }

            // Método para atualizar o status e o tempo online das sessões inativas
            private static void AtualizarStatusTempoOnline()
            {
                while (true)
                {
                    // Lista para armazenar as sessões inativas
                    List<SessaoDTO> sessoesInativas = new List<SessaoDTO>();

                    // Percorre a lista de sessões temporárias
                    foreach (var sessao in sessoesTemporarias)
                    {
                        // Calcula a diferença de tempo entre a data/hora atual e o momento em que a sessão foi iniciada
                        TimeSpan diferenca = DateTime.Now - sessao.IniciouSs;

                        // Se a diferença for maior que o tempo máximo de inatividade permitido (10 minutos neste exemplo)
                        if (diferenca.TotalMinutes > 10)
                        {
                            SessaoDAL sessaoDAL = new SessaoDAL();

                            // Atualiza o status da sessão para inativa e calcula o tempo online
                            sessao.StatusSs = false;
                            sessao.TimeOnlineSs = sessao.FinalizouSs - sessao.IniciouSs;
                            sessaoDAL.Atualizar_Sessao(sessao);

                            // Adiciona a sessão à lista de sessões inativas
                            sessoesInativas.Add(sessao);
                        }
                    }

                    // Remove as sessões inativas da lista de sessões temporárias
                    foreach (var sessao in sessoesInativas)
                    {
                        sessoesTemporarias.Remove(sessao);

                    }

                    // Aguarda 1 minuto antes de verificar novamente as sessões inativas
                    Thread.Sleep(TimeSpan.FromMinutes(1));
                }
            }

            // Método para iniciar a thread que verifica as sessões inativas
            public static void IniciarVerificadorSessoesInativas()
            {
                verificadorSessoesInativas = new Thread(AtualizarStatusTempoOnline);
                verificadorSessoesInativas.Start();
            }
        }


         
         
        private static int _ID_Candidato;
        public static int ID_Candidato
        {
            get { return Sessao._ID_Candidato; }
            set { Sessao._ID_Candidato = value; }

        }

        private static int _ID_Cliente;
        public static int ID_Cliente
        {
            get { return Sessao._ID_Cliente; }
            set { Sessao._ID_Cliente = value; }

        }
        public static class ValoresCadidato
        {
            public static int ID_Profissional { get; set; }
            public static int ID_Cliente { get; set; }
            public static int ID_Candidato { get; set; }
        }



        private static int _ID_Cliente_PDF;
        public static int ID_Cliente_PDF
        {
            get { return Sessao._ID_Cliente_PDF; }
            set { Sessao._ID_Cliente_PDF = value; }

        }


        private static int _ID_Profissional_PDF;
        public static int ID_Profissional_PDF
        {
            get { return Sessao._ID_Profissional_PDF; }
            set { Sessao._ID_Profissional_PDF = value; }

        }
        private static int _ID_Cliente_Empresa;
        public static int ID_Cliente_Empresa
        {
            get { return Sessao._ID_Cliente_Empresa; }
            set { Sessao._ID_Cliente_Empresa = value; }

        }


        private static string _ErroMensagem;
        public static string ErroMensagem
        {
            get { return Sessao._ErroMensagem; }
            set { Sessao._ErroMensagem = value; }


        }

        private static string _Navegador_cliente;
        public static string Navegador_cliente
        {
            get { return Sessao._Navegador_cliente; }
            set { Sessao._Navegador_cliente = value; }


        }


        private static int _CodigoTU;
        public static int CodigoTU
        {
            get { return Sessao._CodigoTU; }
            set { Sessao._CodigoTU = value; }
        }
        

        private static string _Emai_Cliente;
        public static string Emai_Cliente
        {
            get { return Sessao._Emai_Cliente; }
            set { Sessao._Emai_Cliente = value; }
        }
        private static string _Senha_Cliente;
        public static string Senha_Cliente
        {
            get { return Sessao._Senha_Cliente; }
            set { Sessao._Senha_Cliente = value; }
        }

        private static string _CodigoEmail;
        public static string CodigoEmail
        {
            get { return Sessao._CodigoEmail; }
            set { Sessao._CodigoEmail = value; }
        }
    
      
        private static int _ID_Tipouser;
        public static int ID_Tipouser
        {
            get { return Sessao._ID_Tipouser; }
            set { Sessao._ID_Tipouser = value; }
        }

        private static int _ID_Vaga;
        public static int ID_Vaga       
        {
            get { return Sessao._ID_Vaga; }
            set { Sessao._ID_Vaga = value; }
        }

        private static string _Usuario;
        public static string Usuario
        {
            get { return Sessao._Usuario; }
            set { Sessao._Usuario = value; }
        }
        private static string _Tipo_Pesquisa;
        public static string Tipo_Pesquisa
        {
            get { return Sessao._Tipo_Pesquisa; }
            set { Sessao._Tipo_Pesquisa = value; }
        }

        private static TipoUserDTO _TipoUserDTO;
        public static TipoUserDTO TipoUserDTO
        {
            get { return Sessao._TipoUserDTO; }
            set { Sessao._TipoUserDTO = value; }
        }
        private static VagaDTO _VagaDTO;
        public static VagaDTO VagaDTO
        {
            get { return Sessao._VagaDTO; }
            set { Sessao._VagaDTO = value; }
        }
        private static ProfissionalDTO _ProfissionalDTO;
        public static ProfissionalDTO ProfissionalDTO
        {
            get { return Sessao._ProfissionalDTO; }
            set { Sessao._ProfissionalDTO = value; }
        }
        private static GoogleDTO _GoogleDTO;
        public static GoogleDTO GoogleDTO
        {
            get { return Sessao._GoogleDTO; }
            set { Sessao._GoogleDTO = value; }
        }
        private static PagamentoDTO _PagamentoDTO;
        public static PagamentoDTO PagamentoDTO
        {
            get { return Sessao._PagamentoDTO; }
            set { Sessao._PagamentoDTO = value; }
        }
        private static SessaoDTO _SessaoDTO;
        public static SessaoDTO SessaoDTO
        {
            get { return Sessao._SessaoDTO; }
            set { Sessao._SessaoDTO = value; }
        }

    }
}
