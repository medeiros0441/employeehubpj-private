using System; 
using FW.BLL;
using FW.DTO;


namespace FW.UI.pages
{
    public partial class EditarEndereco : System.Web.UI.Page
    {

        protected  private TipoUserBLL TipoUserBLL = new TipoUserBLL();
        protected private TipoUserDTO TipoUserDTO = new TipoUserDTO();
        protected private ProfissionalDTO ProfissionalDTO = new ProfissionalDTO();
        protected private ProfissionalBLL ProfissionalBLL = new ProfissionalBLL();
        protected private ClienteBLL ClienteBLL = new ClienteBLL();
        protected private ClienteDTO ClienteDTO = new ClienteDTO();

        protected int ID_Cliente = ClienteTemporario.ID_Cliente;
    
        protected int ID_Profissinal  = ClienteTemporario.ID_Profissional;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (ID_Profissinal == 0)
            {
                Response.Redirect("~/default.aspx");
            }
            if (!IsPostBack)
            {
                SelecionarEndereco();
            }
        }
        protected void BtnSalvarEndereco_Click(object sender, EventArgs e)
        {
            Salvar_Endereco();
        }
        protected void SelecionarEndereco()
        {

            ClienteDTO = ClienteBLL.SelectEndereco(ID_Cliente);
            if (ClienteDTO.IdCliente != 0)
            {
                txtEndereco.Text = ClienteDTO.DescricaoRuaCl;
                txtNumero.Text = ClienteDTO.NumeroCasaCl;
                txtCEP.Text = ClienteDTO.NumeroCepCl;
                txtcomplemento.Text = ClienteDTO.DescricaoComplementoCl;
                txtBairro.Text = ClienteDTO.DescricaoBairroCl;
                txtCidade.Text = ClienteDTO.DescricaoCidadeCl;
                txtUF.Text = ClienteDTO.DescricaoEstadoCl;

            }
            else
            {
                Master.MensagemJS("Erro", "Erro Ao Selecionar Endereço");
            }
        }

        protected void Salvar_Endereco()
        {
            if (txtUF.Text != "")
            {
                ClienteDTO.DescricaoRuaCl = txtEndereco.Text;
                ClienteDTO.NumeroCasaCl = txtNumero.Text;
                ClienteDTO.NumeroCepCl = txtCEP.Text;
                ClienteDTO.DescricaoComplementoCl = txtcomplemento.Text;
                ClienteDTO.DescricaoBairroCl = txtBairro.Text;
                ClienteDTO.DescricaoCidadeCl = txtCidade.Text;
                ClienteDTO.DescricaoEstadoCl = txtUF.Text;
                ClienteDTO.IdCliente = ID_Cliente;
                ClienteBLL.Editar_Endereco_cliente(ClienteDTO);

                Master.MensagemJS("Sucesso", "Endereço Editado com sucesso!");
                SelecionarEndereco();
            }
            else
            {
                Master.MensagemJS("Erro", "Selecione o Estado");
            }

        }
    }
}