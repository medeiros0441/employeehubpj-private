using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FW.BLL;
using FW.DTO;

namespace FW.UI.ascx
{
    public partial class MenuCliente : System.Web.UI.UserControl
    {

        protected int CodigoTU => ClienteTemporario.Codigo_TU;
        protected int ID_Empresa => ClienteTemporario.ID_Empresa;
        protected int ID_Profissional => ClienteTemporario.ID_Profissional;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnViewCliente_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            Sessao.ID_Cliente = ClienteTemporario.ID_Cliente;
            Response.Redirect("View_Perfil.aspx");
        }
        protected void Add_value_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            Sessao.ID_Vaga = 0;
            Response.Redirect("ListCandidatosEmpresa.aspx");
        }
    }
}