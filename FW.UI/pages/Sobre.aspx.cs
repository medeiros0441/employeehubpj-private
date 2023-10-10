using FW.BLL;
using FW.DTO;
using System;

namespace FW.UI
{
    public partial class Sobre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnEnviar_Click(object sender, EventArgs e)
        {
            //monta o conteúdo da mensagem ( DTO )
            EmailDTO objDTO = new EmailDTO
            {
                NomeDestinatario = "Employee Hub PJ",
                EmailDestinatario = "medeiros0442@gmail.com",
                Assunto = "Contato via Site",
                Mensagem = txtMensagem.Text + " - NOME: " + txtNome.Text + " - FONE: " + txtTelefone.Text + txtEmail.Text
            };

            //instanciar a classe envia email (BLL)
            EmailBLL objEmail = new EmailBLL();
               bool status = objEmail.Enviando_Email("medeiros0442@gmail.com", txtNome.Text,"Contato Via Site", objDTO.Mensagem);
                if(status)
                Master.MensagemJS("Sucesso", "E-mail enviado com Sucesso!");
                else
                Master.MensagemJS("Erro", "Erro, Tente novamente mais tarde!");
                Limpar();
        }
        public void Limpar()
        {
            txtNome.Text =
            txtEmail.Text =
            txtTelefone.Text =
            txtMensagem.Text = string.Empty;

        }

        protected void Btncancelar_Click(object sender, EventArgs e)
        {
            Limpar();
            Master.MensagemJS("Alerta", "Limpado com sucesso!");

        }
    }
}