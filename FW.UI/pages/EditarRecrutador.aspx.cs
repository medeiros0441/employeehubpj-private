using System;
using FW.BLL;
using FW.DTO;
using System.Globalization;
namespace FW.UI.pages
{
    public partial class EditarRecrutador : System.Web.UI.Page
    {
        private protected static string Usuario_Temp;
        private protected static string CPF_Temp;
        protected private ClienteDTO ClienteDTO = new ClienteDTO();
        protected private ClienteBLL ClienteBLL = new ClienteBLL();
        protected private EmpresaBLL EmpresaBLL = new EmpresaBLL();
        protected private EmpresaDTO EmpresaDTO = new EmpresaDTO();
        protected private TipoUserDTO TipoUserDTO = new TipoUserDTO();
        protected private TipoUserBLL TipoUserBLL = new TipoUserBLL();
        protected private ObjetoCompartilhado ObjetoCompartilhado = new ObjetoCompartilhado();


        protected static int ID_Cliente = ClienteTemporario.ID_Cliente;
        protected static int ID_Empresa = ClienteTemporario.ID_Empresa;

        protected void Page_Load(object sender, EventArgs e)
        {

            Master.Verificar_usuario();
            if (!IsPostBack)
            {
                SelecionaDados();

            }

        }
        protected void SelecionaDados()
        {
            CPF_Temp = EmpresaDTO.NroCpfCl;

            ClienteDTO = ClienteBLL.SelectAvancedCliente(ID_Cliente);
            if (ClienteDTO.IdCliente != 0)
            {

                txtNome.Text = ClienteDTO.PrimeiroNomeCl;
                txtSobrenome.Text = ClienteDTO.SobrenomeCl;
                txtCPF.Text = ClienteDTO?.NroCpfCl?.ToString() ?? "";
                txtTelefone.Text = ClienteDTO.NumeroTelefoneCl;
                txtData.Text = ClienteDTO.DataNascimentoCl != DateTime.MinValue ? ClienteDTO.DataNascimentoCl.ToString("dd/MM/yyyy") : string.Empty;
                DDLSexo.Text = ClienteDTO.SexoCl;
                txtUser.Text = ClienteDTO.UsuarioCl;
                txtBiografia.Text = ClienteDTO.BiografiaCl;
            }
            else
            {
                Master.MensagemJS("Erro", "Erro Ao Selecionar Usuario");
            }
        }
        protected void Salvar_Dados()
        {

            ClienteDTO.PrimeiroNomeCl = txtNome.Text;
            ClienteDTO.SobrenomeCl = txtSobrenome.Text;
            ClienteDTO.NroCpfCl = txtCPF.Text;
            ClienteDTO.NumeroTelefoneCl = txtTelefone.Text;
            string dataTexto = txtData.Text;

            if (DateTime.TryParseExact(dataTexto, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dataNascimento))
            {
                ClienteDTO.DataNascimentoCl = dataNascimento;

                ClienteDTO.SexoCl = DDLSexo.Text;
                ClienteDTO.UsuarioCl = txtUser.Text;
                ClienteDTO.BiografiaCl = txtBiografia.Text;

                ClienteDTO.IdCliente = ID_Cliente;
                ClienteBLL.Editar_Dados_Cliente(ClienteDTO);

                Master.MensagemJS("Sucesso", "Dados de perfil Editado com sucesso!");
            }
            else { Master.MensagemJS("Erro", "A data de nascimento é invalida."); }
        }  


        protected void BtnSalvarDadosPerfil_Click(object sender, EventArgs e)
        {

            if (Usuario_Temp != txtUser.Text)
            {
                VerificandoUser(txtUser.Text.Trim());
            }
            if (CPF_Temp != txtCPF.Text)
            {
                VerificandoCPF();
            }
            if (txtUser.Text == Usuario_Temp && txtCPF.Text == CPF_Temp)
            {
                Salvar_Dados();
            }

        }


        protected void VerificandoUser(string usuario)
        {

            ClienteDTO.UsuarioCl = usuario;
            ClienteDTO = ClienteBLL.ConsultarUsuario(ClienteDTO);

            if (ClienteDTO.UsuarioCl == null || ClienteDTO.IdCliente == ID_Cliente)
            {
                Usuario_Temp = txtUser.Text;
            }
            else
            {
                Master.MensagemJS("Erro", "USUARIO já cadastrado!");
            }
        }

        protected void VerificandoCPF()
        {
            ClienteDTO.NroCpfCl = txtCPF.Text;
            ClienteDTO = ClienteBLL.ConsultarPorCpf(ClienteDTO);
            if (txtCPF.Text == "" || ClienteDTO.IdCliente == ID_Cliente || ClienteDTO.IdCliente == 0)
            {
                CPF_Temp = txtCPF.Text;

            }
            else
            {
                Master.MensagemJS("Erro", "CPF já cadastrado!");
            }
        }

    }
}