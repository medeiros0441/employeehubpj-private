using FW.BLL;
using FW.DTO;
using System;
using System.Globalization;

namespace FW.UI.pages
{
    public partial class EditarPerfil : System.Web.UI.Page
    {


        protected internal TipoUserDTO TipoUserDTO = new TipoUserDTO();
        protected internal TipoUserBLL TipoUserBLL = new TipoUserBLL();

        private protected static string Usuario_Temp;
        private protected static string CPF_Temp;

        protected   int ID_Cliente = ClienteTemporario.ID_Cliente;
        protected   int ID_Profissinal = ClienteTemporario.ID_Profissional;
        protected   string FormacaoProfissional;
        protected internal ObjetoCompartilhado ObjetoCompartilhado = new ObjetoCompartilhado();

        protected internal ProfissionalBLL ProfissionalBLL = new ProfissionalBLL();
        protected internal ProfissionalDTO ProfissionalDTO = new ProfissionalDTO();
        protected internal ClienteDTO ClienteDTO = new ClienteDTO();
        protected internal ClienteBLL ClienteBLL = new ClienteBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
             
            if (!IsPostBack)
            {
                SelecionaDados();

            }

        }
        public ProfissionalDTO SelecionaDados()
        {
            ProfissionalDTO = ProfissionalBLL.SelecionarIdProfissional(ID_Profissinal);
            ClienteDTO = ClienteBLL.SelectAvancedCliente(ID_Cliente);
            Usuario_Temp = ClienteDTO.UsuarioCl;
            CPF_Temp = ClienteDTO?.NroCpfCl?.ToString() ?? "";


            if (ProfissionalDTO.IdProfissional != 0)
            {
                txtNome.Text = ClienteDTO.PrimeiroNomeCl;
                txtSobrenome.Text = ClienteDTO.SobrenomeCl;
                txtCPF.Text = ClienteDTO?.NroCpfCl?.ToString() ?? "";
                txtTelefone.Text = ClienteDTO.NumeroTelefoneCl;
                txtData.Text = ClienteDTO.DataNascimentoCl != DateTime.MinValue ? ClienteDTO.DataNascimentoCl.ToString("dd/MM/yyyy") : string.Empty;
                DDLSexo.Text = ClienteDTO.SexoCl;
                txtUser.Text = ClienteDTO.UsuarioCl;
                txtBiografia.Text = ClienteDTO.BiografiaCl;
                ddlFormacao.Text = ProfissionalDTO.FormacaoEscolarPf;
             
            }
            else
            {
                Master.MensagemJS("Erro", "Erro Ao Selecionar Usuario");
            }
            return ProfissionalDTO;
        }

        public void Salvar_Dados()
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
                if (FormacaoProfissional != null || ddlFormacao.Text != FormacaoProfissional)
                {
                    //caso tenha alterar do o valor é alterardo no banco
                    ProfissionalDTO.FormacaoEscolarPf = ddlFormacao.Text;
                    ProfissionalDTO.IdProfissional = ID_Profissinal;
                    ProfissionalDTO.FkClienteTu = ID_Cliente;
                    ProfissionalBLL.Editar_FormacaoEscolar_CaminhoCurriculo(ProfissionalDTO);
                }
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