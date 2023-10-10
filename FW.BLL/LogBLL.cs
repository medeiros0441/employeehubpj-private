using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FW.DAL;
using FW.DTO;

namespace FW.BLL
{
    public class LogBLL : ObjetoCompartilhado
    {
        protected LogDAL LogDAL = new LogDAL();

        public void CadastrarLog(LogDTO log)
        {
            LogDAL.CadastrarLog(log);
        }

        public List<LogDTO> ListarLogs()
        {
            return LogDAL.ListarLogs();
        }
    }
}
