using FW.DAL;
using FW.DTO;
using System.Collections.Generic;

namespace FW.BLL
{
    public class AdministrativoBLL
    {
        AdministrativoDAL objDAL = new AdministrativoDAL();

        //Cadastrar Admin - Insert
        public void CadastrarAdministrativo(AdministrativoDTO objCad)
        {
            objDAL.Cadastrar(objCad);
        }

        //Listar
        public List<AdministrativoDTO> ListarAdministrativo()
        {
            return objDAL.Listar();
        }

        //Editar
        public void EditarAdministrativo(AdministrativoDTO objEdita)
        {
            objDAL.Editar(objEdita);
        }

        //Delete
        public void ExcluirAdministrativo(int objExclui)
        {
            objDAL.Excluir(objExclui);
        }

        //autentica
        public AdministrativoDTO AutenticarAdministrativo(AdministrativoDTO AdministrativoDTO)
        {
            return objDAL.Autenticar(AdministrativoDTO);
        }

        //Filtrar
        public List<AdministrativoDTO> FiltrarAdministrativo()
        {
            return objDAL.Filtrar();
        }

        //Filtrar
        public List<AdministrativoDTO> FiltrarAdministrativoID(int idOperador)
        {
            return objDAL.FiltrarID(idOperador);
        }
    }
}
