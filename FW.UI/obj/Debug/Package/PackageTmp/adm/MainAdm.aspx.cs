using FW.BLL;
using FW.DTO;
using System;
using System.Collections.Generic;

namespace FW.UI
{
    public partial class MainAdm : System.Web.UI.Page
    {
        ProfissionalDTO ProfissionalDTO = new ProfissionalDTO();
        ProfissionalBLL ProfissionalBLL = new ProfissionalBLL();
        EmpresaBLL EmpresaBLL = new EmpresaBLL();
        EmpresaDTO EmpresaDTO = new EmpresaDTO();

        ClienteDTO ClienteDTO = new ClienteDTO();
        ClienteBLL ClienteBLL = new ClienteBLL();

        TipoUserDTO TipoUserDTO = new TipoUserDTO();
        TipoUserBLL TipoUserBLL = new TipoUserBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            Quantidade();
        }


        public void Quantidade()
        {
            List<TipoUserDTO> ListaCliente = TipoUserBLL.ListarCliente();

            int Empresa = 0;
            int Profissional = 0;


            lbl_qunt_Clientes.Text = ListaCliente.Count.ToString();
            foreach (var Cliente in ListaCliente)
            {
                if (Cliente.CodigoTu == 2)
                {
                    Profissional++;
                    lbl_qunt_Profissionais.Text = Profissional.ToString();
                }
                if (Cliente.CodigoTu == 3)
                {
                    Empresa++;
                    lbl_qunt_Empresa.Text = Empresa.ToString();

                }
            }

        }
    }
}