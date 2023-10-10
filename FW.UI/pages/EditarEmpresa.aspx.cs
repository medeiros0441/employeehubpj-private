using FW.BLL;
using FW.DTO;
using System;

namespace FW.UI
{
    public partial class EditarEmpresa : System.Web.UI.Page
    {
        protected internal EmpresaBLL EmpresaBLL = new EmpresaBLL();
        protected internal EmpresaDTO EmpresaDTO { get; set; } = new EmpresaDTO();
        protected static string CNPJ_Temp;
        protected internal ObjetoCompartilhado ObjetoCompartilhado { get; set; } = new ObjetoCompartilhado();


        protected private int ID_Cliente_Master = ClienteTemporario.ID_Cliente;
        protected private int ID_Empresa_Master = ClienteTemporario.ID_Empresa;


        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                Selecionar();
            }
        }
        protected void Selecionar()
        {
            EmpresaDTO = EmpresaBLL.Select_Empresa_IdCliente(ID_Cliente_Master);
            if (EmpresaDTO != null)
            {
                CNPJ_Temp = EmpresaDTO.NumeroCnpjEp;
                txtCnpj.Text = EmpresaDTO.NumeroCnpjEp;
                txtDataAbertura.Text = EmpresaDTO.DateAberturaEp != DateTime.MinValue ? EmpresaDTO.DateAberturaEp.ToString("dd/MM/yyyy") : string.Empty;
                txtRazaoSocial.Text = EmpresaDTO.RazaoSocialEp;
                txtNomeFantasia.Text = EmpresaDTO.NomeFantasiaEp;
            }
            else
            {
                Master.MensagemJS("Erro","Erro Ao Selecionar Empresa");
            }
        }

        protected void SalvarDadosEmpresa_Click(object sender, EventArgs e)
        {
            VerificandoCNPJ();

            if (ID_Empresa_Master != 0)
            {
                EmpresaDTO.NumeroCnpjEp = txtCnpj.Text;
                EmpresaDTO.DateAberturaEp = Convert.ToDateTime(txtDataAbertura.Text);
                EmpresaDTO.RazaoSocialEp = txtRazaoSocial.Text;
                EmpresaDTO.NomeFantasiaEp = txtNomeFantasia.Text;
                EmpresaDTO.FkClienteTu = ID_Cliente_Master;
                EmpresaDTO.IdEmpresa = ID_Empresa_Master;
                EmpresaBLL.EditarEmpresa(EmpresaDTO);
                Selecionar();
                Master.MensagemJS("Sucesso", "Editado com Sucesso!");

            }
            else
            {
                Master.MensagemJS("Erro", "Erro ao Editar!");
            }
        }
        protected void VerificandoCNPJ()
        {
            if (txtCnpj.Text != "")
            {
                EmpresaDTO.NumeroCnpjEp = txtCnpj.Text.Trim();
                EmpresaDTO = EmpresaBLL.AutenticarCnpj(EmpresaDTO);
                if (EmpresaDTO.IdEmpresa == 0 || EmpresaDTO.IdEmpresa == ID_Empresa_Master || txtCnpj.Text == "")
                {
                    CNPJ_Temp = txtCnpj.Text;
                }
                else
                {
                    Master.MensagemJS("Erro", "CNPJ já cadastrado!");
                }
            }
        }
    }
}