using System;
using FW.BLL;
using FW.DTO;

namespace FW.UI.empr
{
    public partial class EditarEndereco : System.Web.UI.Page
    {
        protected internal ClienteDTO ClienteDTO { get; set; } = new ClienteDTO();
        protected internal ClienteBLL ClienteBLL { get; set; } = new ClienteBLL();

        protected private int ID_Cliente = ClienteTemporario.ID_Cliente;
        protected private int ID_Empresa = ClienteTemporario.ID_Empresa;

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Verificar_usuario();
            if (!IsPostBack)
            {
                SelecionarEndereco(ID_Cliente);

            }
        }
        protected void BtnSalvarEndereco_Click(object sender, EventArgs e)
        {
            Salvar_Endereco(ID_Cliente);
        }
        protected void SelecionarEndereco(int ID_Cliente )
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

        protected void Salvar_Endereco(int ID_Cliente)
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
                SelecionarEndereco(ID_Cliente);
            }
            else
            {
                Master.MensagemJS("Erro", "Selecione o Estado");
            }

        }
    }
}