using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FW.DTO
{
    public class ClienteDTO : ClienteStatusAdm
    {
            public int IdCliente { get; set; }
            public string NomeCompletoCl { get; set; }
            public string PrimeiroNomeCl { get; set; }
            public string SobrenomeCl { get; set; }
            public string EmailCl { get; set; }
            public string UsuarioCl { get; set; }
            public string SenhaCl { get; set; }

        public DateTime DataNascimentoCl { get; set; }
        public string NumeroTelefoneCl { get; set; }
            public string SexoCl { get; set; }
            public string DescricaoRuaCl { get; set; }
            public string NumeroCasaCl { get; set; }
            public string DescricaoComplementoCl { get; set; }
            public string NumeroCepCl { get; set; }
            public string DescricaoBairroCl { get; set; }
            public string DescricaoCidadeCl { get; set; }
            public string DescricaoEstadoCl { get; set; }
            public string CaminhoFotoCl { get; set; }
            public bool StatusCl { get; set; }
         

        public DateTime DateTimeInsertCl { get; set; }
        

        public DateTime DateTimeUpdateCl { get; set; }
        public string NroCpfCl { get; set; }
            public string BiografiaCl { get; set; }
            public bool StatusVerificacaoCl { get; set; }
            public decimal SaldoAtualCl { get; set; }

    }
    public class ClienteStatusAdm  
    {
        public int IdClienteCla { get; set; }
        public bool StatusAdmCla { get; set; }
        public DateTime DateTimeInsertCla { get; set; }
        public DateTime? DateTimeUpdateCla { get; set; }
        public string DescricaoCla { get; set; }
        public int FkClienteCla { get; set; }
    }
}
