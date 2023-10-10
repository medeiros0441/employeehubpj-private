using FW.BLL;
using FW.DTO;
using System;
using System.Web.UI.WebControls;

namespace FW.UI
{
    public partial class Cadastro :  System.Web.UI.Page
    {
        protected internal ClienteDTO ClienteDTO { get; set; } = new ClienteDTO();
        protected internal ClienteBLL ClienteBLL { get; set; } = new ClienteBLL();
        protected internal ClienteBLL ObjetoCompartilhado { get; set; } = new ClienteBLL();
        protected EmailBLL EmailBLL = new EmailBLL();


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

        public ClienteDTO VerificandoUser()
        {

        

            ClienteDTO.UsuarioCl = txtUser.Text.Trim();
            ClienteDTO = ClienteBLL.ConsultarUsuario(ClienteDTO);
            return ClienteDTO;
        }

        public void VerificandoTelefone()
        {
            ClienteDTO = null;
            ClienteDTO = ClienteBLL.ConsultarTelefone(txtTelefone.Text);

            if (ClienteDTO.NumeroTelefoneCl == null)
            {
                verificacao.Visible = false;
                verificacao2.Visible = false;
                verificacao3.Visible = true;

            }
            else
            {
                Master.MensagemJS("Erro","Telefone já cadastrado!");
                verificacao.Visible = false;
                verificacao2.Visible = true;
                verificacao3.Visible = false;

            }
        }

        public void Insert_Cliente()
        {
            TipoUserDTO TipoUserDTO = new TipoUserDTO();

            try
            {

                TipoUserDTO.PrimeiroNomeCl = txtNome.Text;
                TipoUserDTO.SobrenomeCl = txtSobrenome.Text;
                TipoUserDTO.EmailCl = txtEmail.Text;
                TipoUserDTO.UsuarioCl = txtUser.Text;
                TipoUserDTO.SenhaCl = Sessao.Senha_Cliente;
                TipoUserDTO.NumeroTelefoneCl = txtTelefone.Text;
                TipoUserDTO.DataNascimentoCl = Convert.ToDateTime(txtData.Text);
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

                ClienteDTO = VerificandoUser();

                if (ClienteDTO.UsuarioCl == null)
                {
                    VerificandoTelefone();
                }
                else
                {
                    verificacao.Visible = false;
                    Master.MensagemJS("Erro", "USUARIO já cadastrado!");
                    verificacao2.Visible = true;
                    verificacao3.Visible = false;

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
            Response.Redirect("~/autenticacao.aspx");
        }

        public void Enviandoemail()
        {
            Random geradaorcodigo = new Random();
            int Codigoemail = geradaorcodigo.Next(100000, 900000);
            Sessao.CodigoEmail = Codigoemail.ToString();
            
            string NomeDestinatario = txtNome.Text;
            string   EmailDestinatario = txtEmail.Text;
            string Assunto = "Verificação de email";
            string Mensagem = "Olá " + txtNome.Text + " Seu codigo é : " + Codigoemail;


               bool status = EmailBLL.Enviando_Email(EmailDestinatario,NomeDestinatario, Assunto, Mensagem);
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
        public void ValidateDate(object source, ServerValidateEventArgs args)

        {


            DateTime dtNascimentoMax = DateTime.Now.AddYears(-10);

            DateTime dtMax = DateTime.Parse("1/1/1973 12:00:00");



            if (DateTime.TryParse(args.Value, out DateTime dt) == false)

                args.IsValid = false;



            //Valida se é maior de idade

            if (dt >= dtNascimentoMax)

                args.IsValid = false;



            //Valida a data para não dar SqlDateTime overflow       

            if (dt <= dtMax)

                args.IsValid = false;

        }

    }
}