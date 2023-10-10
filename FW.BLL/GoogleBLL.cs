using FW.DAL;
using FW.DTO;
using System;
using System.Globalization;
using System.Linq;

namespace FW.BLL
{
    public class GoogleBLL : ObjetoCompartilhado
    {

        protected HistoricoDTO HistoricoDTO = new HistoricoDTO();
        protected HistoricoDAL HistoricoDAL = new HistoricoDAL();
        protected GoogleDAL GoogleDAL = new GoogleDAL();

        public static string AlfanumericoAleatorio(int tamanho)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }

        public int Verificar_email(GoogleDTO GoogleDTO)
        {

            //esse ´parte é execultado depois de fazer o get em googleAPI e pegar os dados, caso o cliente exista na tb_cliente mas nao na tabela google, fazemos o cadastro.
            //caso exista na tabela google  e na tabela cliente, pagamos os id que retorna um dynamic
            //e verificamos se foi inserido no dto empresa ou profissional,  e entã o passamos o valor para
            //ClienteTemporario uma funçao que fica armazenando temporariamente 
            // caso o cliente nao exista direciona para a segunda etapa de cadastro.

            Sessao.GoogleDTO = GoogleDTO;

            var retorno = GoogleDAL.VerificarTipoClienteEmail(GoogleDTO.EmailGl);

            if (retorno != null)
            {
                if (retorno is GoogleDTO)
                {
                    //cadastrando cliente existe na tabela google, caso nao seja.
                    GoogleDAL.Cadastrar_Cliente_google(GoogleDTO);
                    retorno = GoogleDAL.VerificarTipoClienteEmail(GoogleDTO.EmailGl);
                }
                if (retorno is ProfissionalDTO profissionalDTO)
                {
                    ClienteTemporario.InfoCliente = profissionalDTO;

                    return 2;
                }
                else if (retorno is EmpresaDTO empresaDTO)
                {
                    ClienteTemporario.InfoCliente = empresaDTO;

                    return 3;
                }
            }
            return 0;
        }



        public bool CadastrarCliente<T>(GoogleDTO GoogleDTO)  
        {
 
          
           
            GoogleDTO.UsuarioCl = "User_" + GeradorCodigo.Next(10, 9000).ToString();
            string alfanumericoAleatorio_ = AlfanumericoAleatorio(15);
            GoogleDTO.SenhaCl = "chateau_" + alfanumericoAleatorio_;

            var cliente = GoogleDAL.Cadastrar_Cliente<T>(GoogleDTO);

            if (cliente is ProfissionalDTO profissionalDTO)
            {
                ClienteTemporario.InfoCliente = profissionalDTO;
                return true;
            }
            else if (cliente is EmpresaDTO empresaDTO)
            {
                ClienteTemporario.InfoCliente = empresaDTO;
                return true;
            }
            else
            {
                return false;
            }
        }

          

    }
}