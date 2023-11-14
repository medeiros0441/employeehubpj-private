using FW.BLL;
using FW.DTO;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace FW.UI
{
    public partial class Pesquisa_Lista : System.Web.UI.Page
    {
        protected VagaBLL VagaBLL = new VagaBLL();
        protected TipoUserBLL TipoUserBLL = new TipoUserBLL();
        protected ProfissionalBLL ProfissionalBLL = new ProfissionalBLL();
        protected VagaDTO VagaDTO_Sessao = Sessao.VagaDTO;
        protected ProfissionalDTO ProfissionalDTO_Sessao = Sessao.ProfissionalDTO;
        protected TipoUserDTO TipoUserDTO_Sessao = Sessao.TipoUserDTO;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Sessao.Tipo_Pesquisa == "Simples")
                {
                    Buscar_Simples();
                }
                else if (Sessao.Tipo_Pesquisa == "BuscaOportunidade")
                {
                    Buscar_Oportunidade();
                }
                else if (Sessao.Tipo_Pesquisa == "BuscaCliente")
                {
                    Buscar_Cliente();
                }
            }
        }

        protected void Buscar_Simples()
        {
            List<TipoUserDTO> ListaRetorno_cliente = TipoUserBLL.Buscar_Cliente(TipoUserDTO_Sessao);
            List<VagaDTO> ListaOportunidade = VagaBLL.BuscarVaga(VagaDTO_Sessao);
            if (ListaRetorno_cliente.Count != 0)
            {
                lbl_qunt_Clientes.Text += ListaRetorno_cliente.Count.ToString();
                rpt_cliente.DataSource = ListaRetorno_cliente;
                rpt_cliente.DataBind();
                pn_result_clientes.Visible = true;
                pn_nenhum_result.Visible = false;
            }
            else
            {
                Master.MensagemJS("Erro", "Ops, Não encontramos algo.");
                pn_nenhum_result.Visible = true;
                pn_result_clientes.Visible = false;
            }
            if (ListaOportunidade.Count != 0)
            {
                pn_nenhum_result.Visible = false;
                RptVagasControl.FiltroVaga(ListaOportunidade);
            }
        }

        protected void Buscar_Cliente()
        {

            List<ProfissionalDTO> ListaRetorno = ProfissionalBLL.Pesquisa_profissional(Sessao.ProfissionalDTO);
            if (ListaRetorno.Count != 0)
            {
                lbl_qunt_Clientes.Text += ListaRetorno.Count.ToString();
                rpt_cliente.DataSource = ListaRetorno;
                rpt_cliente.DataBind();
                pn_result_clientes.Visible = true;
                pn_nenhum_result.Visible = false;

            }
            else
            {
                Master.MensagemJS("Erro", "Ops, Não encontramos algo.");
                pn_nenhum_result.Visible = true;
                pn_result_clientes.Visible = false;
            }
        }
        protected void Buscar_Oportunidade()
        {


            List<VagaDTO> ListaOportunidade = VagaBLL.BuscarVaga(VagaDTO_Sessao);

            if (ListaOportunidade.Count != 0)
            {
                RptVagasControl.FiltroVaga(ListaOportunidade);
                pn_nenhum_result.Visible = false;
               

            }
            else
            {
                Master.MensagemJS("Alerta", "Ops, Não encontramos algo.");
                pn_nenhum_result.Visible = true;
            }
        }


        public void Btn_sessao_Click(object sender, EventArgs e)
        {

            LinkButton btn = (LinkButton)sender;
            Sessao.ID_Cliente = Convert.ToInt32(btn.CommandArgument);
            Response.Redirect("View_Perfil.aspx");
        }
    }
}