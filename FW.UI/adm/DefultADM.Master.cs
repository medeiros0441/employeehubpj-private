using FW.BLL;
using System;

namespace FW.UI
{
    public partial class DefultADM : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void Sair_Click(object sender, EventArgs e)
        {
            Desconectar_user();
        }

        public void MensagemSucesso(string texto)
        {
            PlMensagemErro.Visible = false;
            PlMensagemSucesso.Visible = true;
            lblMensagemSucesso.Visible = true;
            lblMensagemSucesso.Text = texto;
        }
        public void MensagemErro(string texto)
        {
            PlMensagemSucesso.Visible = false;
            PlMensagemErro.Visible = true;
            lblMensagemErro.Visible = true;
            lblMensagemErro.Text = texto;
        }

        protected void BtnAbrir_Click(object sender, EventArgs e)
        {
            AbrirMenu();
        }

        protected void BtnFechar_Click(object sender, EventArgs e)
        {
            FecharMenu();
        }

        public void FecharMenu()
        {
            BtnFechar.Visible = false;
            BtnAbrir.Visible = true;
            MenuIcon.Visible = false;
            mainpro1.Attributes["class"] = "MainPro navbar-nav-scroll mx-auto  col-12 col-md-9";


        }

        public void AbrirMenu()
        {

            BtnAbrir.Visible = false;
            BtnFechar.Visible = true;
            MenuIcon.Visible = true;
            mainpro1.Attributes["class"] = "MainPro   navbar-nav-scroll mx-auto  col-10 col-md-9";
        }
        public void Desconectar_user()
        {
            Response.Redirect("~/default.aspx");
        }

        protected void Btn_Busca_Unload(object sender, EventArgs e)
        {
            if (TxtBusca.Text != null && TxtBusca.Text != "")
            {

            }
            else
            {
            }
        }
    }
}