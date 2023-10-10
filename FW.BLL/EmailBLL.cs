using FW.DTO;
using System;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.IO;
using System.Collections.Generic;

namespace FW.BLL
{
    public class EmailBLL
    {

        public bool EnviarEmailAlternativo(string Email_Destinatario, string Assunto, string NomeCliente, string TextIntroducao, string TextContainer2 = "", string TextContainer3 = "", bool btn_vermais = false)
        {
            try
            {
                // Lista de contas de e-mail que você deseja alternar em caso de problemas
                var contasEmail = new List<(string Username, string Password)>
                {
                    ("medeiros0441@gmail.com", "lsudyhkesbwgbrez"),
                    ("medeiros0442@gmail.com", "qfahwvhwnewsymkg")
                    // Adicione mais contas se necessário
                };

                bool emailEnviado = false;  // Variável de controle para rastrear se o e-mail foi enviado

                foreach (var conta in contasEmail)
                {
                    if (emailEnviado)
                        break;  // Se o e-mail já foi enviado, sair do loop

                    string smtpUsername = conta.Username;
                    string smtpPassword = conta.Password;

                    // Configurar o email
                    var email = new MailMessage
                    {
                        // Remetente
                        From = new MailAddress(smtpUsername, "Seu Nome Remetente")
                    };

                    // Destinatário
                    email.To.Add(new MailAddress(Email_Destinatario));

                    // Assunto
                    email.Subject = Assunto;

                    // Configurar o corpo do e-mail como HTML
                    email.IsBodyHtml = true;

                    // Corpo do e-mail HTML
                    email.Body = GerarHtmlEmail(NomeCliente, TextIntroducao, TextContainer2, TextContainer3, btn_vermais);

                    // Configurar o SmtpClient
                    var smtp = new SmtpClient
                    {
                        // Dados do servidor (Gmail)
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(smtpUsername, smtpPassword)
                    };

                    try
                    {
                        // Enviar o e-mail
                        smtp.Send(email);
                        Console.WriteLine("Email enviado com sucesso!");
                        emailEnviado = true;  // Definir a variável de controle para True
                    }
                    catch (SmtpException ex)
                    {
                        if (ex.StatusCode == SmtpStatusCode.MustIssueStartTlsFirst)
                        {
                            Console.WriteLine("Erro ao enviar o email: A conexão SSL/TLS não pôde ser estabelecida.");
                        }
                        else if (ex.StatusCode == SmtpStatusCode.ExceededStorageAllocation)
                        {
                            Console.WriteLine("Erro ao enviar o email: A alocação de armazenamento foi excedida.");
                        }
                        else
                        {
                            Console.WriteLine($"Erro ao enviar o email: {ex.Message}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao enviar o email: {ex.Message}");
                    }
                }

                if (!emailEnviado)
                {
                    Console.WriteLine("Não foi possível enviar o email com nenhuma conta.");
                }

                return emailEnviado;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar o email: {ex.Message}");
                return false;
            }
        }
        private string GerarHtmlEmail(string nomeCliente, string TextoIntrodutivo, string TextContainer2 = null, string TextContainer3 = null, bool btnVerMais = false)
        {
            string link = "https://employeehubpj.azurewebsites.net/";

            string saudacao = nomeCliente != null ? $"Prezado {nomeCliente}," : "";
            // Montar o corpo do email em HTML com base nas variáveis
            string htmlBody = $@"
            <head>
                <style>
                    .highlighted {{
                        color: #DF6316;
                        font-family: ""Arial"", sans-serif;
                        font-size: 30px;
                    }}
                </style>
            </head>
            <body>

            <!--header padrão -->
            <div style=""text-align: center;"">
                <img alt=""Logo da Empresa"" style=""width: 100%;"" src=""https://employeehubpj.azurewebsites.net/Imagens/objetos-empresa/name-empresa.png"">
                <br>
            </div>

            <!--main padrão -->
            <div style=""center;background: #white;border: none;border-radius: 20px;padding: 10px 30px;"">
                <p style=""font-size: 20px; font-family: Arial, sans-serif; color: #333;"">
                         {saudacao}
                    <br><br>
                    {TextoIntrodutivo}
                </p>
            </div>";

            // texto secundário caso a var TextContainer2 for diferente de null, colocamos o container como visível
            if (!string.IsNullOrEmpty(TextContainer2))
            {
                htmlBody += $@"
                <div style=""text-align: center;background: #DF6316;border: none; border-radius: 20px; padding: 10px 30px;"">
                    <p style=""font-size: 20px; font-family: Arial, sans-serif; color: #333;"">
                        {TextContainer2}
                        <br><br>
                    </p>
                </div>";
            }

            // texto secundário caso a var TextContainer3 for diferente de null, colocamos o container como visível
            if (!string.IsNullOrEmpty(TextContainer3))
            {
                htmlBody += $@"
                <div style=""text-align: center;background: #000000;border: none;border-radius: 20px;padding: 10px 30px;margin: 15px 0 15px 0;"">
                    <p style=""font-size: 20px;font-family: Arial, sans-serif;color: #fff;"">
                        {TextContainer3}
                    </p>
                </div>";
            }

            // precisamos de um if caso o valor bool for True, coloco o botão como visível
            if (btnVerMais)
            {
                htmlBody += $@"
                <div style=""text-align: center;"">
                    <a href=""{link}"" style=""text-decoration: none;"">
                        <button style=""background-color: #DF6316; color: dark; border: none; border-radius: 20px; padding: 10px 30px; font-weight: bold; cursor: pointer;"">
                            Saiba mais
                        </button>
                    </a>
                </div>";
            }

            // rodapé padrão
            htmlBody += $@"
            <div style=""text-align:center;background: #000000;border: none; ;font-size: 10px;color: white;margin:10px 0 0 0"">
                <img alt=""Logo da Empresa"" style=""width: 100%"" src=""https://employeehubpj.azurewebsites.net/Imagens/objetos-empresa/banner-frase.png"">
                <br>
                Atenciosamente, Samuel Medeiros
                <br>
                <div style=""padding: 10px 30px"">
                    <a href=""{link}"" style=""font-size:8px;color: #DF6316;text-align:center"">Caso tenha alguma dúvida ou precise de assistência, nossa equipe de suporte estará à disposição para ajudar.</a>
                </div>
            </div>
            </body>
            ";

            return htmlBody;
        }

        protected private bool Enviar(string Email_Destinatario, string NomeDestinatario, string Assunto, string Mensagem, byte[] arquivo = null, string nome_arquivo = null, string TextContainer2 = "", string TextContainer3 = "", bool btn_vermais = false)
        {
            try
            {
                // Lista de contas de e-mail que você deseja alternar em caso de problemas
                var contasEmail = new List<(string Username, string Password)>
                {
                    ("medeiros0441@gmail.com", "lsudyhkesbwgbrez"),
                    ("medeiros0442@gmail.com", "qfahwvhwnewsymkg")
                    // Adicione mais contas se necessário
                };

                bool emailEnviado = false;  // Variável de controle para rastrear se o e-mail foi enviado

                foreach (var conta in contasEmail)
                {
                    if (emailEnviado)
                        break;  // Se o e-mail já foi enviado, sair do loop

                    string smtpUsername = conta.Username;
                    string smtpPassword = conta.Password;

                    // Configurar o email
                    MailMessage email = new MailMessage
                    {
                        // Remetente
                        From = new MailAddress("medeiros0441@gmail.com", "CHATEAU DU PET")
                    };

                    // Destinatário
                    email.To.Add(new MailAddress(Email_Destinatario, NomeDestinatario));

                    // Assunto
                    email.Subject = Assunto;

                    // Configurar o corpo do e-mail como HTML
                    email.IsBodyHtml = true;

                    // Corpo do e-mail HTML
                    email.Body = GerarHtmlEmail(NomeDestinatario, Mensagem, TextContainer2, TextContainer3, btn_vermais);

                    // Obtém os dados do arquivo como um array de bytes
                    if (arquivo != null && arquivo.Length > 0 && nome_arquivo != null)
                    {
                        // Obtém o nome do arquivo
                        string nomeArquivo = nome_arquivo;

                        // Cria o objeto Attachment com os dados do arquivo e o nome do arquivo
                        Attachment anexo = new Attachment(new MemoryStream(arquivo), nomeArquivo);

                        // Adiciona o anexo à coleção de anexos da mensagem de email
                        email.Attachments.Add(anexo);
                    }

                    // Configurar o SmtpClient
                    var smtp = new SmtpClient
                    {
                        // Dados do servidor (Gmail)
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(smtpUsername, smtpPassword)
                    };

                    try
                    {
                        // Enviar o e-mail
                        smtp.Send(email);
                        Console.WriteLine("Email enviado com sucesso!");
                        emailEnviado = true;  // Definir a variável de controle para True
                    }
                    catch (SmtpException ex)
                    {
                        if (ex.StatusCode == SmtpStatusCode.MustIssueStartTlsFirst)
                        {
                            Console.WriteLine("Erro ao enviar o email: A conexão SSL/TLS não pôde ser estabelecida.");
                        }
                        else if (ex.StatusCode == SmtpStatusCode.ExceededStorageAllocation)
                        {
                            Console.WriteLine("Erro ao enviar o email: A alocação de armazenamento foi excedida.");
                        }
                        else
                        {
                            Console.WriteLine($"Erro ao enviar o email: {ex.Message}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Erro ao enviar o email: {ex.Message}");
                    }
                }

                if (!emailEnviado)
                {
                    Console.WriteLine("Não foi possível enviar o email com nenhuma conta.");
                    return false;
                }

                return emailEnviado;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar o email: {ex.Message}");
                return false;
            }
        }

        public bool Enviando_Email(string Email, string Assunto, string Mensagem, string NomeDestinatario, byte[] arquivo = null, string nome_arquivo = null, string TextContainer2 = "", string TextContainer3 = "", bool btn_vermais = false)
        {
            bool status = Enviar(Email, NomeDestinatario, Assunto, Mensagem, arquivo, nome_arquivo,TextContainer2,TextContainer3,btn_vermais);
            if (status)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
