using FW.BLL;
using FW.DTO;
using System;
using System.Collections.Generic;

namespace FW.UI
{
    public partial class ListVagasDefult : System.Web.UI.Page
    {
        protected VagaBLL VagaBLL = new VagaBLL();
        protected VagaDTO VagaDTO = new VagaDTO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                FiltroVaga(VagaBLL.ListarVaga(true));
            }
        }
        public void FiltroVaga(List<VagaDTO> Lista)
        {
            RptVagasControl.FiltroVaga(Lista);

        }
        protected void InsertDTO()
        {
            if (txtTitulo_buscar.Text != "")
            {
                VagaDTO.NomeVg = txtTitulo_buscar.Text;
            }
            if (txtCidade.Text != "")
            {
                VagaDTO.DescricaoCidadeCl = txtCidade.Text;
            }
            if (txtUF.Text != "")
            {
                VagaDTO.DescricaoEstadoCl = txtUF.Text;
            }
            if (ddlExperiencia.SelectedValue != "0")
            {
                VagaDTO.TempoExperienciaVg = ddlExperiencia.SelectedValue;
            }
            if (dllRegistro_pesquisa.SelectedValue != "0") {
               VagaDTO.TipoRegistroVg = dllRegistro_pesquisa.SelectedValue;


            }
            if (DDLTipoVaga.SelectedValue != "0")
            {
                VagaDTO.TipoVagaVg = DDLTipoVaga.SelectedValue;
            }
            List<VagaDTO> Lista = VagaBLL.BuscarVaga(VagaDTO);
            FiltroVaga(Lista);
        }

        protected void BtnProcurarOportunidade_Click(object sender, EventArgs e)
        {
            InsertDTO();
        }
    }
}