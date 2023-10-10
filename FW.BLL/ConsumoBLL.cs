using FW.DAL;
using FW.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW.BLL
{
    public class ConsumoBLL
    {
        private readonly ConsumoDAL consumoDAL = new ConsumoDAL();
        private readonly GerenciamentoSaldoDAL GSDAL = new GerenciamentoSaldoDAL();

        public int CreateConsumo(ConsumoDTO consumo)
        {
            try
            {
                GSDAL.AtualizarSaldo(consumo.FkClienteTu,consumo.ValorDescontadoCs);
               return consumoDAL.Create(consumo);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar o consumo.", ex);
            }
        }

        public ConsumoDTO GetConsumoById(int id)
        {
            try
            {
                return consumoDAL.Read(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter o consumo por ID.", ex);
            }
        }

        public void UpdateTime(ConsumoDTO consumo)
        {
            try
            {

                consumoDAL.UpdateTime(consumo);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o consumo.", ex);
            }
        }

        public void DeleteConsumo(int id)
        {
            try
            {
                consumoDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir o consumo.", ex);
            }
        }

        public List<ConsumoDTO> GetAllConsumos()
        {
            try
            {
                return consumoDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter todos os consumos.", ex);
            }
        }

        public List<ConsumoDTO> GetConsumosByEmpresa(int empresaId)
        {
            try
            {
                return consumoDAL.GetByEmpresa(empresaId);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter os consumos por empresa.", ex);
            }
        }

        public ConsumoDTO GetConsumoByEmpresaEndProfissional(int empresaId,int profissionalId)
        {
            try
            {
                return consumoDAL.GetConsumoByEmpresaEndProfissional(empresaId, profissionalId);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter os consumos por empresa.", ex);
            }
        }
        public List<ConsumoDTO> ListarConsumos(int ID_empresa)
        {
            try
            {
                return consumoDAL.ListarConsumosPorEmpresa(ID_empresa);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar consumos: " + ex.Message);
            }
        }
    }
}

