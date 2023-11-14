using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FW.BLL;

namespace FW.UI.ascx
{
    public partial class Configuracoes : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ClienteTemporario.ID_Cliente != 0)
            {
                SelectViewUser(ClienteTemporario.Codigo_TU);
            }
        }
        public void SelectViewUser(int TipoUser) {
            if (TipoUser == 2)
            {
                BtnEditarProfissional.Visible = true;
                BtnSelectCurriculo.Visible = true;

            }
            else if (TipoUser == 3){
                BtnEditarRecrutador.Visible = true;
                BtnEditarEmpresa.Visible = true;
               
            }
        }
        protected void Sair_Click(object sender, EventArgs e)
        {
            Default Master = Page.Master as Default;

            Master.Desconectar_user();


        }
    }
}