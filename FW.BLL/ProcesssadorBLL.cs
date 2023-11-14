using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;
using FW.DTO;

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
          //  timerEnviarEmail.Elapsed += (sender, e) => EnviarEmail();
            timerEnviarEmail.Start();
        }

        public void AtualizarDados()
        {
            // Implementação da função AtualizarDados()
            //   pagamentoBLL.AtualizarStatusPagamentosPeriodicamente();
            //IniciarVerificadorSessoesInativas
        }

        public void Cadastro(int idcliente, string nome , string email)
        {
            try
            {
                NotificacaoBLL notificacaoBLL = new NotificacaoBLL();
                NotificacaoDTO notificacaoDTO = new NotificacaoDTO
                {
                    TituloNc = "Bem-vindo ao Employee Hub PJ!",
                    FkClienteNc = idcliente,
                    MensagemNc = "Olá " + nome + " \r\nSeja muito bem-vindo ao Employee Hub PJ! Estamos empolgados por você ter escolhido se juntar a nós. Este é o seu portal exclusivo para gerenciar sua jornada profissional conosco.\r\n\r\nNo Employee Hub PJ, você terá acesso a recursos e ferramentas que facilitarão sua experiência como colaborador. Não deixe de explorar as funcionalidades. Você pode anexar seu currículo ou preencher seu formulário para que os recrutadores possam visualizar suas habilidades e experiências, entre outras facilidades disponíveis.\r\n\r\nEstamos comprometidos em criar um ambiente colaborativo e produtivo para todos os nossos membros. Caso precise de suporte ou tenha alguma dúvida, nossa equipe está pronta para ajudar.\r\n\r\nObrigado por fazer parte da nossa equipe!",

                };
                notificacaoBLL.CadastrarNotificacao(notificacaoDTO);

                EmailBLL emailBLL = new EmailBLL();
                string mensagem = "Olá,\r\n\r\nSeja muito bem-vindo ao Employee Hub PJ! Estamos empolgados por você ter escolhido se juntar a nós. Este é o seu portal exclusivo para gerenciar sua jornada profissional conosco.\r\n\r\nNo Employee Hub PJ, você terá acesso a recursos e ferramentas que facilitarão sua experiência como colaborador. Não deixe de explorar as funcionalidades, como o envio de currículos, preenchimento de formulários e outras facilidades disponíveis.\r\n\r\nEstamos comprometidos em criar um ambiente colaborativo e produtivo para todos os nossos membros. Caso precise de suporte ou tenha alguma dúvida, nossa equipe está pronta para ajudar.\r\n\r\nObrigado por fazer parte da nossa equipe!\r\n\r\nAtenciosamente,\r\n Employee Hub PJ";
                string mesagem_2 = "Queremos ressaltar que temos diversas oportunidades aguardando por você. Este é mais do que um sistema; é uma plataforma onde você pode moldar ativamente o seu caminho profissional.\r\n\r\nEstamos comprometidos em criar um ambiente colaborativo e produtivo para todos os membros. Se surgir alguma dúvida ou se precisar de suporte, nossa equipe está pronta para ajudar.\r\n\r\nAgradecemos por escolher fazer parte da nossa equipe e esperamos que aproveite ao máximo as oportunidades que o Employee Hub PJ oferece.";
                emailBLL.Enviando_Email(email, "Bem-vindo ao Employee Hub PJ!",mensagem,nome,null,null,mesagem_2,null,true);
                

            }
            catch (Exception ex)
            {
                LogBLL logBLL = new LogBLL();
                LogDTO logDTO = new LogDTO
                {
                    NivelGravidadeLg = "grave",
                    DescricaoSistemaLg = ex.Message,
                    FkSessaoLg = Sessao.SessaoDTO.IdSessao,
                    DadosAdicionaisLg = "Erro ao processar o cadastro do cliente, ProcessadorBLL metodo Cadastro.. IdCliente  " + idcliente +" ; "+ ex.ToString(),
                };
                logBLL.CadastrarLog(logDTO);

            }
        }
         
    }
}
