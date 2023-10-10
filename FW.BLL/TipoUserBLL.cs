using FW.DAL;
using FW.DTO;
using System.Collections.Generic;//

namespace FW.BLL
{
    public class TipoUserBLL
    {
        //objeto para acoes gerais
        protected private TipoUserDAL TipoUserDAL = new TipoUserDAL();

        //autentica Email
        public TipoUserDTO AutenticarEmail(TipoUserDTO TipoUserDTO)
        {
            return TipoUserDAL.AutenticarEmail(TipoUserDTO);
        }
        //autentica USER
        public TipoUserDTO AutenticarUser(TipoUserDTO TipoUserDTO)
        {
            return TipoUserDAL.AutenticarUser(TipoUserDTO);
        }

        //Cadastrar empresa - Insert
        public void Cadastrar_cliente_empresa(TipoUserDTO TipoUserDTO)
        {
            TipoUserDAL.Cadastrar_empresa(TipoUserDTO);

        }
        //Cadastrar PRofissional - Insert
        public void Cadastrar_cliente_profissional(TipoUserDTO TipoUserDTO)
        {
            TipoUserDAL.Cadastrar_profissional(TipoUserDTO);

        }
        //Cadastrar Adm - Insert
        public void Cadastrar_cliente_adm(string objEmail, string objUsuario)
        {
            TipoUserDAL.Cadastrar_Adm(objEmail, objUsuario);

        }

        public List<TipoUserDTO> Buscar_Cliente(TipoUserDTO TipoUserDTO)
        {
            return TipoUserDAL.Buscar_Cliente(TipoUserDTO);
        }
        //Listar
        public List<TipoUserDTO> ListarCliente()
        {
            return TipoUserDAL.Listar_cliente();
        }

        //Listar empresas
        public List<TipoUserDTO> Listar_cliente_empresa()
        {
            return TipoUserDAL.Listar_Empresas();
        }
        //Listar profissional
        public List<TipoUserDTO> Listar_cliente_profissional()
        {
            return TipoUserDAL.Listar_Profissional();
        }
           
    }
}
