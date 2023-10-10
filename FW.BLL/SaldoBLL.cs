using FW.DAL;
using FW.DTO;
using System;
using System.Collections.Generic;

namespace FW.BLL
{
    public class GerenciamentoSaldoBLL
    {
        private readonly GerenciamentoSaldoDAL gerenciamentoSaldoDAL;

        public GerenciamentoSaldoBLL()
        {
            gerenciamentoSaldoDAL = new GerenciamentoSaldoDAL();
        }

        public void Create(GerenciamentoSaldoDTO DTO)
        {
            try
            {
                DTO.SaldoAnteriorGs = gerenciamentoSaldoDAL.GetSaldo(DTO.FkClienteGs);
                gerenciamentoSaldoDAL.Create(DTO);
                gerenciamentoSaldoDAL.AtualizarSaldo(DTO.FkClienteGs, DTO.SaldoAtualGs);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public decimal GetSaldo(int id_cliente) { 
           return  gerenciamentoSaldoDAL.GetSaldo(id_cliente);
        }
        public GerenciamentoSaldoDTO Read(int id)
        {
            try
            {
                return gerenciamentoSaldoDAL.Read(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(GerenciamentoSaldoDTO gerenciamentoSaldo)
        {
            try
            {
                gerenciamentoSaldoDAL.Update(gerenciamentoSaldo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                gerenciamentoSaldoDAL.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<GerenciamentoSaldoDTO> GetAll()
        {
            try
            {
                return gerenciamentoSaldoDAL.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}


