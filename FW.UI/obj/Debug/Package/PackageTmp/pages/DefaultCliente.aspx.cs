using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FW.BLL;
using FW.DTO;
namespace FW.UI.pages
{
    public partial class DefaultClient : System.Web.UI.Page
    {
        ClienteBLL ClienteBLL = new ClienteBLL();
        VagaBLL VagaBLL = new VagaBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

           List<EmpresaDTO> Lista = ClienteBLL.Lista_Cliente<EmpresaDTO>();
            RptClienteControl.RptCliente(Lista);

            RptVagasControl.FiltroVaga(VagaBLL.ListarVaga(true));


        }
    }
}