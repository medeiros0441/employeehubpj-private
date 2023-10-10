using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;

namespace FW.BLL
{
    public partial class ProcessadorBLL  
    {
        protected   PagamentoBLL pagamentoBLL = new PagamentoBLL();

        public void ExecutarPeriodicamente()
        {
            // Cria e configura o timer para a função AtualizarDados()
            var timerAtualizarDados = new System.Timers.Timer
            {
                Interval = TimeSpan.FromMinutes(5).TotalMilliseconds
            };
            timerAtualizarDados.Elapsed += (sender, e) => AtualizarDados();
            timerAtualizarDados.Start();

            // Cria e configura o timer para a função EnviarEmail()
            var timerEnviarEmail = new System.Timers.Timer
            {
                Interval = TimeSpan.FromMinutes(10).TotalMilliseconds
            };
            timerEnviarEmail.Elapsed += (sender, e) => EnviarEmail();
            timerEnviarEmail.Start();
        }

        public void AtualizarDados()
        {
            // Implementação da função AtualizarDados()
            //   pagamentoBLL.AtualizarStatusPagamentosPeriodicamente();
            //IniciarVerificadorSessoesInativas
        }

        public void EnviarEmail()
        {
            // Implementação da função EnviarEmail()
        }
         
    }
}
