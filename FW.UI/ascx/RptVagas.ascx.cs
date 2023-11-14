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
    public partial class RptVagas : System.Web.UI.UserControl
    {
        // Propriedade para receber o valor
        public List<VagaDTO> ListaDeVagas { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            // ...
        }

        public void FiltroVaga(List<VagaDTO>  ListaDeVagas)
        {
            PlTitle.Visible =true;
            Default Master = Page.Master as Default;
            if (ListaDeVagas != null && ListaDeVagas.Count > 0)
            {
                rptVaga1.DataSource = ListaDeVagas;
                rptVaga1.DataBind();
            }
            else
            {
                pnNotResult.Visible = true; 
            }
        }
    }
}