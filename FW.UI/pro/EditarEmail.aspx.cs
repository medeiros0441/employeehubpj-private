using FW.BLL;
using FW.DTO;
using System;

namespace FW.UI.pro
{
    public partial class EditarEmail : System.Web.UI.Page
    {
        private  protected TipoUserBLL TipoUserBLL = new TipoUserBLL();
        private protected TipoUserDTO TipoUserDTO = new TipoUserDTO();
        private protected ProfissionalDTO ProfissionalDTO = new ProfissionalDTO();
        private protected ProfissionalBLL ProfissionalBLL = new ProfissionalBLL();

        protected string Email_Cliente= ClienteTemporario.Email_Cliente;
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Verificar_usuario();
           

        }
        protected void Btn_EditarEmail_Click(object sender, EventArgs e)
        {
            if (txtEmail.Enabled == false)
            {
                txtEmail.Enabled = true;
                icon_email.Attributes["href"] = "../Imagens/icones/bootstrap-icons.svg#pencil-square";
            }
            if (txtEmail.Enabled == true && Email_Cliente != txtEmail.Text)
            {
                txtEmail.Enabled = true;
                icon_email.Attributes["href"] = "../Imagens/icones/bootstrap-icons.svg#cloud-upload";
            }
            if (txtEmail.Enabled == true && Email_Cliente == txtEmail.Text)
            {
                txtEmail.Enabled = true;
                icon_email.Attributes["href"] = "../Imagens/icones/bootstrap-icons.svg#check-circle";
            }
        }

        protected void VerificandoEmail()
        {

            TipoUserDTO = TipoUserBLL.AutenticarEmail(TipoUserDTO);

            if (TipoUserDTO.EmailCl == null)
            {
                PlMensagemSucesso.Visible = true;
                lblMensagemSucesso.Visible = true;
                lblMensagemSucesso.Text = "Email disponivel";

                PlMensagemErro.Visible = false;
                lblMensagemErro.Visible = false;
            }
            else
            {
                PlMensagemSucesso.Visible = false;
                PlMensagemErro.Visible = true;
                lblMensagemErro.Visible = true;
                lblMensagemErro.Text = "Email já cadastrado!";
            }

        }

    }
}