using FW.BLL;
using FW.DTO;
using System;
using System.Web.UI.WebControls;

using System.Linq;
using System.Globalization;
namespace FW.UI
{
    public partial class Cadastro :  System.Web.UI.Page
    {
        protected internal ClienteDTO ClienteDTO { get; set; } = new ClienteDTO();
        protected internal ClienteBLL ClienteBLL { get; set; } = new ClienteBLL();
        protected EmailBLL EmailBLL = new EmailBLL();
        TipoUserDTO TipoUserDTO = new TipoUserDTO();


        protected void Page_Load(object sender, EventArgs e)
        {
             
        }

        public void VerificandoEmail()
        {

            ClienteDTO.EmailCl = txtEmail.Text.Trim();
            ClienteDTO = ClienteBLL.ConsultarEmail(ClienteDTO.EmailCl);

            if (ClienteDTO.EmailCl == null)
            {

                verificacao.Visible = false;
                verificacao2.Visible = true;
                verificacao3.Visible = false;
                PnbuntonLogin.Visible = false;
            }
            else
            {
                Master.MensagemJS("Erro", "Email já cadastrado!");

            }

        }
 
        public void Insert_Cliente()
        {

            try
            {

                TipoUserDTO.PrimeiroNomeCl = txtNome.Text;
                TipoUserDTO.SobrenomeCl = txtSobrenome.Text;
                TipoUserDTO.EmailCl = txtEmail.Text;
                TipoUserDTO.UsuarioCl = txtUser.Text;
                TipoUserDTO.SenhaCl = Sessao.Senha_Cliente;
                TipoUserDTO.NumeroTelefoneCl = txtTelefone.Text;
                if (DateTime.TryParseExact(txtData.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataNascimento))
                {
                       TipoUserDTO.DataNascimentoCl = dataNascimento;
                }
                else
                {
                    // A conversão falhou, trate o erro aqui.
                    Master.MensagemJS("Erro", "Formato de data inválido.");
                    return;
                }
                if (DDLSexo.SelectedItem.ToString() == "Masculino")
                {
                    TipoUserDTO.CaminhoFotoCl = @"../Cliente/Foto_Cliente/undraw_male_avatar_323b.svg";
                    TipoUserDTO.SexoCl = "Masculino";

                }
                if (DDLSexo.SelectedItem.ToString() == "Feminino")
                {
                    TipoUserDTO.CaminhoFotoCl = @"../Cliente/Foto_Cliente/undraw_female_avatar_w3jk.svg";
                    TipoUserDTO.SexoCl = "Feminino";
                }
                TipoUserDTO.CodigoTu = Convert.ToInt32(DLLTipoUSer.SelectedValue);
                TipoUserDTO.DescricaoTu = DLLTipoUSer.SelectedItem.ToString();
                ClienteBLL.Cadastrar_Cliente(TipoUserDTO);

                AutenticacaoEmail.Visible = false;
                painelcadastrado.Visible = true;
                lblcadastrado.Visible = true;
                Sessao.Senha_Cliente = null;
                lblcadastrado.Text = "Cliente cadastradado com sucesso";
                PnbuntonLogin.Visible = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar Cliente" + ex.Message);
            }
        }

        protected void BtnInicio_Click(object sender, EventArgs e)
        {



            if (DLLTipoUSer.SelectedItem.ToString() == "Profissional")
            {
                VerificandoEmail();

            }
            if (DLLTipoUSer.SelectedItem.ToString() == "Empresa")
            {
                VerificandoEmail();

            }
            if (DLLTipoUSer.SelectedItem.ToString() == "Selecione uma opção")
            {
                Master.MensagemJS("Erro", "Selecione o tipo de usuario");

            }

        }

        protected void BtnFim_Click(object sender, EventArgs e)
        {
            if (Senha1 != null)
            {
                if (Senha1.Text == Senha2.Text)
                {

                    Sessao.Senha_Cliente = Senha2.Text;

                    if (cbTermos.Checked && cbPolitica.Checked)
                    {

                        verificacao.Visible = false;
                        verificacao2.Visible = false;
                        verificacao3.Visible = false;
                        AutenticacaoEmail.Visible = true;
                        Enviandoemail();
                        txtCodigo.Text = null;

                    }
                    else
                    {
                        Master.MensagemJS("Erro", "Selecione os Termos de uso e as Pilítica de privacidade!");


                    }
                }
                else
                {
                    Master.MensagemJS("Erro", "As senhas estão Diferentes");



                }
            }
            else
            {
                Master.MensagemJS("Erro", "O campo senha não foi inserido");



            }
        }

        protected void BtnMeio_Click(object sender, EventArgs e)
        {
            if (DDLSexo.SelectedItem.ToString() != "Selecione uma opção")
            {
                ClienteDTO.UsuarioCl = txtUser.Text.Trim();
                ClienteDTO = ClienteBLL.ConsultarUsuario(ClienteDTO);

                // Verifica se a propriedade UsuarioCl NÃO é nula ou vazia
                bool UsuarioExiste = !string.IsNullOrEmpty(ClienteDTO.UsuarioCl);

                // Se UsuarioExiste for verdadeiro, exibe uma mensagem e encerra a execução
                if (UsuarioExiste)
                {
                    verificacao.Visible = false;
                    Master.MensagemJS("Erro", "USUARIO já cadastrado!");
                    verificacao2.Visible = true;
                    verificacao3.Visible = false;
                    return;
                }

                ClienteDTO = ClienteBLL.ConsultarTelefone(txtTelefone.Text);
                bool TelefoneExiste = !string.IsNullOrEmpty(ClienteDTO.NumeroTelefoneCl);

                // Se TelefoneExiste for verdadeiro, exibe uma mensagem e encerra a execução
                if (TelefoneExiste)
                {
                    Master.MensagemJS("Erro", "Telefone já cadastrado!");
                    verificacao.Visible = false;
                    verificacao2.Visible = true;
                    verificacao3.Visible = false;
                    return;
                }
                 
                if (DateTime.TryParseExact(txtData.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataNascimento))
                {
                    // Verificações adicionais para garantir uma data válida
                    if (dataNascimento.Year < 1950 || dataNascimento.Year > DateTime.Now.Year || dataNascimento.Month < 1 || dataNascimento.Month > 12 || dataNascimento.Day < 1 || dataNascimento.Day > DateTime.DaysInMonth(dataNascimento.Year, dataNascimento.Month))
                    {
                        // A data está fora dos limites aceitáveis, trate o erro aqui.
                        Master.MensagemJS("Erro", "Data de nascimento inválida.");
                    }
                    else
                    {
                        verificacao.Visible = false;
                        verificacao2.Visible = false;
                        verificacao3.Visible = true;

                        TipoUserDTO.DataNascimentoCl = dataNascimento;
                    }
                }
                else
                {
                    // A conversão falhou, trate o erro aqui.
                    Master.MensagemJS("Erro", "Formato de data inválido.");
                }
            }
            else
            {
                Master.MensagemJS("Erro", "Selecione uma opção");
            }
        }





        protected void BtnFinalização_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text.Replace("-", "");


            if (codigo == Sessao.CodigoEmail)
            {
                Insert_Cliente();

            }
            else
            {
                txtCodigo.Text = null;
                Master.MensagemJS("Erro", "Codigo inválido");

            }
        }

        protected void BntVoltar2_Click(object sender, EventArgs e)
        {
            verificacao.Visible = false;
            verificacao2.Visible = true;
            verificacao3.Visible = false;
            AutenticacaoEmail.Visible = false;
        }

        protected void BtnVoltar_Click(object sender, EventArgs e)
        {
            verificacao.Visible = true;
            verificacao3.Visible = false;
            AutenticacaoEmail.Visible = false;
            verificacao2.Visible = false;

        }
       

        protected void BtnVoltar3_Click(object sender, EventArgs e)
        {
            verificacao.Visible = false;
            verificacao2.Visible = false;
            verificacao3.Visible = true;
            AutenticacaoEmail.Visible = false;

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("../pages/autenticacao.aspx");
        }

        public void Enviandoemail()
        {
            Random geradaorcodigo = new Random();
            int Codigoemail = geradaorcodigo.Next(100000, 900000);
            Sessao.CodigoEmail = Codigoemail.ToString();
            
            string NomeDestinatario = txtNome.Text;
            string   EmailDestinatario = txtEmail.Text; 
            string Mensagem = "Olá " + txtNome.Text + " Seu codigo é : " + Codigoemail;


               bool status = EmailBLL.Enviando_Email(EmailDestinatario, "Verificação de email", Mensagem,NomeDestinatario);
            if (status)
                Master.MensagemJS("Sucesso", "E-mail enviado com Sucesso!");
            else
                Master.MensagemJS("Erro", "Tente novamente mais tarde!");
        }

        protected void Btnrenviar_Click(object sender, EventArgs e)
        {
            Enviandoemail();
        }

        protected void Btncadastrase_Click(object sender, EventArgs e)
        {
            PnCadastro.Visible = true;

        }
       

    }
}