using System;
using System.Collections.Generic;
using System.Web.Services;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FW.BLL;
using FW.DTO;

namespace FW.UI.empr
{
    public partial class View_Perfil : System.Web.UI.Page
    {
        protected CertificadoDTO CertificadoDTO = new CertificadoDTO();
        protected CertificadoBLL CertificadoBLL = new CertificadoBLL();

        protected ExperienciaDTO ExperienciaDTO = new ExperienciaDTO();
        protected ExperienciaBLL ExperienciaBLL = new ExperienciaBLL();

        protected RedesocialDTO RedesocialDTO = new RedesocialDTO();
        protected RedesocialBLL RedesocialBLL = new RedesocialBLL();

        protected private EmpresaBLL EmpresaBLL = new EmpresaBLL();
        protected private EmpresaDTO EmpresaDTO = new EmpresaDTO();


        protected ProfissionalBLL ProfissionalBLL = new ProfissionalBLL();
        protected ProfissionalDTO ProfissionalDTO = new ProfissionalDTO();
        protected ConsumoBLL ConsumoBLL = new ConsumoBLL();
        protected ConsumoDTO ConsumoDTO = new ConsumoDTO();

        protected private TipoUserDTO TipoUserDTO = new TipoUserDTO();
        protected private TipoUserBLL TipoUserBLL = new TipoUserBLL();
        protected private ClienteDTO ClienteDTO = new ClienteDTO();
        protected private ClienteBLL ClienteBLL = new ClienteBLL();
        protected static int id_sessao;
        protected GerenciamentoSaldoBLL GerenciamentoSaldoBLL = new GerenciamentoSaldoBLL();
        protected GerenciamentoSaldoDTO GerenciamentoSaldoDTO = new GerenciamentoSaldoDTO();
        protected static int ID_Consumo_View;
        protected static int ID_Cliente_View;
        protected static int ID_Profissional_View;
        protected static int ID_Empresa = ClienteTemporario.ID_Empresa;
        protected int ID_Cliente => ClienteTemporario.ID_Cliente;

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Verificar_usuario();
            if (!IsPostBack)
            {
                id_sessao = Convert.ToInt32(Master.GetCookie("id_sessao"));
                if (Sessao.ID_Cliente != 0)
                {
                    VerificandoCliente(Sessao.ID_Cliente);
                }
                else
                {
                    Master.MensagemJS("Erro", "Ops, não conseguimos obter dados do cliente.  ");

                }
            }
          
        }

        public bool CadastrarConsumo() {

            try
            {
                decimal valor_atual = GerenciamentoSaldoBLL.GetSaldo(ID_Cliente_View);
                ConsumoDTO status = ConsumoBLL.GetConsumoByEmpresaEndProfissional(ID_Empresa, ID_Profissional_View);
                if (status.IdConsumo == 0 && id_sessao != 0 && ID_Profissional_View != 0 && ID_Empresa != 0 && valor_atual > 03.00m)
                {
                    ConsumoDTO.FkProfissionalCs = ID_Profissional_View;
                    ConsumoDTO.FkEmpresaCs = ID_Empresa;
                    ConsumoDTO.FkClienteTu = ID_Cliente;
                    ConsumoDTO.ValorDescontadoCs = -3;
                    ConsumoDTO.FkSessaoCs = id_sessao;
                    ConsumoBLL.CreateConsumo(ConsumoDTO);
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao processar consumo!" + ex.Message);
            }
        }
        public  bool Alterando_views()
        {
            // Verifica o status usando o método GetConsumoByEmpresaEndProfissional
            ConsumoDTO status = ConsumoBLL.GetConsumoByEmpresaEndProfissional(ID_Empresa, ID_Profissional_View);

            if (status.IdConsumo == 0)
            {
                // Se o status for falso, execute o seguinte código
                BtnViewContato.Visible = true;     // Torna o botão BtnViewContato visível
                pn_contato.Visible = true;         // Torna o painel pn_contato visível
                PnRedeInfo.Visible = false;        // Torna o painel PnRedeInfo invisível
                PnRedeImg.Visible = true;          // Torna o painel PnRedeImg visível
            }
            else if (status.IdConsumo > 0)
            {
                ID_Consumo_View = status.IdConsumo;// Se o status for verdadeiro, execute o seguinte código
                BtnViewContato.Visible = false;    // Torna o botão BtnViewContato invisível
                PnRedeInfo.Visible = true;         // Torna o painel PnRedeInfo visível
                PnRedeImg.Visible = false;         // Torna o painel PnRedeImg invisível
                pn_contato.Visible = false;        // Torna o painel pn_contato invisível
            }

            if (status.IdConsumo > 0)
            {
                SelectRedeSociais(ID_Cliente_View, true);
            }
            return false;
        }
        [WebMethod]
        public static string CalculeTimeView(int tempoPermanencia)
        {
            try
            {
                  ConsumoDTO ConsumoDTO = new ConsumoDTO();
                 ConsumoBLL ConsumoBLL = new ConsumoBLL();
                if (id_sessao != 0 && ID_Profissional_View != 0 && ID_Empresa != 0 && ID_Consumo_View != 0)
                {
                    ConsumoDTO.TempoViewCs = TimeSpan.FromMinutes(tempoPermanencia);
                    ConsumoDTO.IdConsumo = ID_Consumo_View;
                    ConsumoBLL.UpdateTime(ConsumoDTO);
                }
                return "Sucesso";
            }
            catch
            {
                return "Erro";
            }
        }
        protected bool VerificandoCliente(int IdCliente)
        {
            try
            {
                TipoUserDTO = ClienteBLL.AutenticarTipouserPorIdCliente(IdCliente);
                if (TipoUserDTO.FkClienteTu != 0)
                {
                    if (TipoUserDTO.CodigoTu == 2)
                    {
                        SelectProfissional(TipoUserDTO.FkClienteTu);
                        Alterando_views();
                    }
                    else if (TipoUserDTO.CodigoTu == 3)
                    {
                        SelectEmpresa(TipoUserDTO.FkClienteTu);
                        SelectRedeSociais(TipoUserDTO.FkClienteTu, true);
                    }
                    SelectEndereco(TipoUserDTO.FkClienteTu);
                    return true;
                }
                else
                {
                    Master.MensagemJS("Erro", "Erro Ao buscar o Cliente.");
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao processar dados!" + ex.Message);
            }
        }
        protected void SelectEmpresa(int IdCliente)
        {
            PnEmpresa.Visible = true;
            EmpresaDTO = EmpresaBLL.Select_Empresa_IdCliente(IdCliente);
            ImageEmpresa.ImageUrl = EmpresaDTO.CaminhoFotoCl;
            LblNomeEmpresa.Text = EmpresaDTO.NomeFantasiaEp;
            lblBiografiaEmpresa.Text = EmpresaDTO.BiografiaCl?.Replace(Environment.NewLine, "<br />");
            FiltroLista(EmpresaDTO.IdEmpresa);
        }
        protected void FiltroLista(int ID_empresa)
        {
            PnVagas.Visible = true;
            VagaBLL VagaBLL = new VagaBLL();

            rptVaga1.DataSource = VagaBLL.Listar_Vagas_ativa_Empresa(ID_empresa);
            rptVaga1.DataBind();
        }
        protected void SelectEndereco(int IdCliente)
        {

            PnEndereco.Visible = true;
            ClienteDTO DTO_Endereco = ClienteBLL.SelectEndereco(IdCliente);
            if (DTO_Endereco.DescricaoRuaCl != "" && DTO_Endereco.DescricaoRuaCl != null)
            {
                PanelEnderecoImg.Visible = false;
                PanelEnderecoInfo.Visible = true;
                lblendereco.Text = DTO_Endereco.DescricaoRuaCl;
                lblNroEndereco.Text = DTO_Endereco.NumeroCasaCl;
                lblBairro.Text = DTO_Endereco.DescricaoBairroCl;
                lblCidade.Text = DTO_Endereco.DescricaoCidadeCl;
                lblUF.Text = DTO_Endereco.DescricaoEstadoCl;
                lblCEP.Text = DTO_Endereco.NumeroCepCl;
            }
            else
            {
                PanelEnderecoImg.Visible = true;
                PanelEnderecoInfo.Visible = false;
            }
        }
        protected void SelectProfissional(int IdCliente)
        {

            PnProfissional.Visible = true;
            ProfissionalDTO = ProfissionalBLL.Select_Profissional_IdCliente(IdCliente);
           
            ID_Profissional_View = ProfissionalDTO.IdProfissional;
            ID_Cliente_View = IdCliente;

            ImagePro.ImageUrl = ProfissionalDTO.CaminhoFotoCl;
            if (!File.Exists(Server.MapPath(ProfissionalDTO.CaminhoFotoCl)))  // Verifica se a imagem da src não existe, caso nao exista passa uma img 
            {
                ImagePro.ImageUrl = "../imagens/undraw_resume_folder_re_e0bi.svg";
            }
            else { ImagePro.ImageUrl = ProfissionalDTO.CaminhoFotoCl; }
            lblNomePro.Text = ProfissionalDTO.NomeCompletoCl;
            lblFormacaoEscolar.Text = ProfissionalDTO.FormacaoEscolarPf;
            DataAniversario.Text = ProfissionalDTO.DataNascimentoCl.ToString("dd/MM/yyyy");
            lblSexo.Text = ProfissionalDTO.SexoCl;
            lblBiografiaPro.Text = ProfissionalDTO.BiografiaCl?.Replace(Environment.NewLine, "<br />");
            SelectCertificado(ProfissionalDTO.IdProfissional);
            SelectExperiencia(ProfissionalDTO.IdProfissional);

        }
        protected void SelectCertificado(int id_Profissional)
        {
            PnCertificado.Visible = true;

            List<CertificadoDTO> Lista = CertificadoBLL.ListarCertificado_IDProfissional(id_Profissional);

            if (Lista.Count > 0)
            {
                PanelFormEscoInfo.Visible = Visible;
                PanelFormEscoImg.Visible = false;
                rptCurso.DataSource = Lista;
                rptCurso.DataBind();
            }
            else
            {
                PanelFormEscoInfo.Visible = false;
                PanelFormEscoImg.Visible = true;
            }

        }
        protected void SelectExperiencia(int id_Profissional)
        {
            PnExeperiencia.Visible = true;
            List<ExperienciaDTO> Lista = ExperienciaBLL.Listar_Experiencia_Profissional(id_Profissional);
            if (Lista.Count != 0)
            {
                PanelExperienciaInfo.Visible = Visible;
                PanelExperienciaImg.Visible = false;
                rptExperiencia.DataSource = Lista;
                rptExperiencia.DataBind();
            }
            else
            {
                PanelExperienciaInfo.Visible = false;
                PanelExperienciaImg.Visible = true;
            }
        }
        protected void SelectRedeSociais(int id_Cliente , bool status)
        {
            if (status)
            {

                ClienteDTO = ClienteBLL.SelectAvancedCliente(id_Cliente);
                LblEmail.Text = ClienteDTO.EmailCl;
                    LblTelefone.Text = ClienteDTO.NumeroTelefoneCl;
                if (ClienteDTO.NumeroTelefoneCl  == "")
                {
                    HLTelefone.Visible = false;
                }


                PnRedeSocial.Visible = true;
                HLLinkedin.Visible = false;
                HLWhatsapp.Visible = false;
                HLInstagram.Visible = false;

                List<RedesocialDTO> redesociais = RedesocialBLL.Listar_Fkcliente(id_Cliente);

                // Percorra a lista e execute a tarefa para cada objeto RedesocialDTO
                foreach (RedesocialDTO rede in redesociais)
                {
                    if (rede.DescricaoRedeRs == "URL Linkedin")
                    {
                        string valorLinkdin = rede.LinkRedeRs?.Replace("https://www.linkedin.com/in/", "");
                        if (!string.IsNullOrEmpty(valorLinkdin) && status)
                        {
                            HLLinkedin.Visible = true;
                            PnRedeInfo.Visible = true;
                            PnRedeImg.Visible = false;
                            LblLinkedin2.Text = valorLinkdin;
                            HLLinkedin.NavigateUrl = rede.LinkRedeRs;
                        }
                    }
                    else if (rede.DescricaoRedeRs == "URL Whatsapp")
                    {
                        string valorWhatsapp = rede.LinkRedeRs?.Replace("https://wa.me/+55", "");
                        if (!string.IsNullOrEmpty(valorWhatsapp) && status)
                        {
                            HLWhatsapp.Visible = true;
                            PnRedeInfo.Visible = true;
                            PnRedeImg.Visible = false;
                            LblWhatsapp2.Text = valorWhatsapp;
                            HLWhatsapp.NavigateUrl = rede.LinkRedeRs;
                        }
                    }
                    else if (rede.DescricaoRedeRs == "URL Instagram")
                    {
                        string valorInstagram = rede.LinkRedeRs?.Replace("https://www.instagram.com/", "");
                        if (!string.IsNullOrEmpty(valorInstagram) && status)
                        {
                            HLInstagram.Visible = true;
                            PnRedeInfo.Visible = true;
                            PnRedeImg.Visible = false;
                            LblInstagram2.Text = valorInstagram;
                            HLInstagram.NavigateUrl = rede.LinkRedeRs;
                        }
                    }
                }
            }
            else {
                PnRedeImg.Visible = true;
                PnRedeInfo.Visible = false;
            }
        }

        bool valor = false;
        protected void BtnViewContato_Click(object sender, EventArgs e)
        {
            try {
                decimal VALOR_ATUAL = GerenciamentoSaldoBLL.GetSaldo(ID_Cliente);
                if (VALOR_ATUAL > 0.01m)
                {
                    if (!valor) {
                        Master.MensagemJS("Alerta", "verificamos e você tem saldo em conta para consultar, ao clicar novamente liberamos os dados de contato e seu saldo será descontato um valor de 3,00 reais");
                    }
                    if (valor)
                    {
                        bool cadastro = CadastrarConsumo();

                        Alterando_views();
                     
                        if (cadastro)
                        {
                            Master.MensagemJS("Alerta", "debitado 3,00 reais de seu saldo");
                        }
                    }
                    valor = true;
                }
                else { Master.MensagemJS("Alerta", "Ops, verificamos seu saldo e vimos que nao tem saldo suficiente para consultar esse cliente"); }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao processar consumo!" + ex.Message);
            }

        }
    }
}