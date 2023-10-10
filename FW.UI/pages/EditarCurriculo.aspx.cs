using FW.BLL;
using FW.DTO;
using System;
using System.IO;

namespace FW.UI.pro
{
    public partial class EditarCurriculo : System.Web.UI.Page
    {


        protected ClienteDTO ClienteDTO = new ClienteDTO();
        protected ClienteBLL ClienteBLL = new ClienteBLL();

        protected int ID_Profissional = ClienteTemporario.ID_Profissional;
        protected int ID_Cliente = ClienteTemporario.ID_Cliente;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
         
    }
}