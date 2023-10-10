using FW.DAL;
using FW.DTO;
using System.Collections.Generic;

namespace FW.BLL
{
    public class ExperienciaBLL
    {
       protected  ExperienciaDAL objDAL = new ExperienciaDAL();

        //Cadastrar Experiencia - Insert
        public void CadastrarExperiencia(ExperienciaDTO objCad)
        {
            objDAL.Cadastrar(objCad);
        }


        //Delete
        public void ExcluirExperiencia(int idProfissional, int objExclui)
        {
            objDAL.Excluir(idProfissional, objExclui);
        }

        //Editar
        public void EditarExperiencia(ExperienciaDTO objEdita)
        {
            objDAL.Editar(objEdita);
        }

         
        public List<ExperienciaDTO> Listar_Experiencia_Profissional(int id_cliente)
        {
            return objDAL.Listar(id_cliente);
        }
        public ExperienciaDTO SelecionaExperienciaID(int idExperiencia)
        {
            return objDAL.SelecionarExperienciaPorId( idExperiencia);
        }
        
    }
}
