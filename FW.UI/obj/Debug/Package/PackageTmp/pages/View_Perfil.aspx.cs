using FW.BLL;
using FW.DTO;
using System;
using System.Collections.Generic;
using System.IO;

namespace FW.UI.pages
{
    public partial class View_Perfil : System.Web.UI.Page
    {
        protected CertificadoDTO CertificadoDTO = new CertificadoDTO();
        protected CertificadoBLL CertificadoBLL = new CertificadoBLL();

        protected ExperienciaDTO ExperienciaDTO = new ExperienciaDTO();
        protected ExperienciaBLL ExperienciaBLL = new ExperienciaBLL();

        protected RedesocialDTO RedesocialDTO = new RedesocialDTO();
        protected RedesocialBLL RedesocialBLL = new RedesocialBLL();

        protected internal EmpresaBLL EmpresaBLL = new EmpresaBLL();
        protected internal EmpresaDTO EmpresaDTO = new EmpresaDTO();


        protected ProfissionalBLL ProfissionalBLL = new ProfissionalBLL();
        protected ProfissionalDTO ProfissionalDTO = new ProfissionalDTO();

        protected private TipoUserDTO TipoUserDTO = new TipoUserDTO();
        protected private TipoUserBLL TipoUserBLL = new TipoUserBLL();
        protected internal ClienteDTO ClienteDTO = new ClienteDTO();
        protected internal ClienteBLL ClienteBLL = new ClienteBLL();

        protected int ID_Profissional= ClienteTemporario.ID_Profissional;
        protected int ID_Cliente = ClienteTemporario.ID_Cliente;


        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Verificar_usuario();
            if (!IsPostBack)
            {
                if (Sessao.ID_Cliente != 0)
                {
                    VerificandoCliente(Sessao.ID_Cliente);
                }
                else
                {
                    Master.MensagemJS("Erro", "Ops, Falhar ao recuperar cliente");
                    Pn_ClienteOFF.Visible = true;
                }
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
                    }
                    else if (TipoUserDTO.CodigoTu == 3)
                    {
                        SelectEmpresa(TipoUserDTO.FkClienteTu);
                    }

                    SelectRedeSociais(TipoUserDTO.FkClienteTu);
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

            ImageEmpresa.ImageUrl = EmpresaDTO.CaminhoFotoCl?.ToString();
            LblNomeEmpresa.Text = EmpresaDTO.NomeFantasiaEp?.ToString();
            lblBiografiaEmpresa.Text = EmpresaDTO.BiografiaCl?.Replace(Environment.NewLine, "<br />");

            FiltroLista(EmpresaDTO.IdEmpresa);


        }
        protected void FiltroLista(int ID_empresa)
        {
            PnVagas.Visible = true;
            VagaBLL VagaBLL = new VagaBLL();
            RptVagasControl.FiltroVaga(VagaBLL.Listar_Vagas_ativa_Empresa(ID_empresa));
        }
        protected void SelectEndereco(int IdCliente)
        {

            try
            {
                PnEndereco.Visible = true;
                ClienteDTO DTO_Endereco = ClienteBLL.SelectEndereco(IdCliente);
                if (DTO_Endereco.DescricaoRuaCl != "" && DTO_Endereco.DescricaoRuaCl != null)
                {
                    PanelEnderecoImg.Visible = false;
                    PanelEnderecoInfo.Visible = true;
                    lblBairro.Text = DTO_Endereco.DescricaoBairroCl?.ToString();
                    lblCidade.Text = DTO_Endereco.DescricaoCidadeCl?.ToString();
                    lblUF.Text = DTO_Endereco.DescricaoEstadoCl?.ToString();
                    lblCEP.Text = DTO_Endereco.NumeroCepCl?.ToString();
                }
                else
                {
                    PanelEnderecoImg.Visible = true;
                    PanelEnderecoInfo.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao processar endereço dados!" + ex.Message);
            }
        }

        protected void SelectProfissional(int IdCliente)
        {

            PnProfissional.Visible = true;

            ProfissionalDTO = ProfissionalBLL.Select_Profissional_IdCliente(IdCliente);
            ImagePro.ImageUrl = ProfissionalDTO.CaminhoFotoCl;
            if (!File.Exists(Server.MapPath(ProfissionalDTO.CaminhoFotoCl)))  // Verifica se a imagem da src não existe, caso nao exista passa uma img 
            {
                ImagePro.ImageUrl = "../imagens/undraw_resume_folder_re_e0bi.svg";
            }
            else { ImagePro.ImageUrl = ProfissionalDTO.CaminhoFotoCl; }
            lblNomePro.Text = ProfissionalDTO.NomeCompletoCl;
            lblFormacaoEscolar.Text = ProfissionalDTO.FormacaoEscolarPf?.ToString();
            DataAniversario.Text = ProfissionalDTO.DataNascimentoCl.ToString("dd/MM/yyyy");
            lblSexo.Text = ProfissionalDTO.SexoCl?.ToString();

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


        private bool RedeSocialControleView(int idcliente) {

            // Verifica se o ID do cliente é diferente do ID do cliente temporário.
            if (idcliente == ClienteTemporario.ID_Cliente)
            {
                PnRedeInfo.Visible = true;
                PnRedeImg.Visible = false;
                return true;
            }
            return false;
        }
        
        // Este método controla a exibição de informações de redes sociais com base em parâmetros de entrada.
        protected void SelectRedeSociais(int id_Cliente)
        {
            // Torna o painel PnRedeSocial visível.
          bool status  = RedeSocialControleView(id_Cliente);

            // Verifica se o status é verdadeiro (indicando que as informações das redes sociais devem ser exibidas).
            if (status)
            {
                // Obtém informações do cliente usando o ID do cliente fornecido.
                ClienteDTO = ClienteBLL.SelectAvancedCliente(id_Cliente);
                LblEmail.Text = ClienteDTO.EmailCl;
                LblTelefone.Text = ClienteDTO.NumeroTelefoneCl;

                // Oculta o hiperlink de telefone se o número de telefone do cliente estiver em branco.
                if (ClienteDTO.NumeroTelefoneCl == "")
                {
                    HLTelefone.Visible = false;
                }

                // Inicializa os hiperlinks das redes sociais como invisíveis.
                HLLinkedin.Visible = false;
                HLWhatsapp.Visible = false;
                HLInstagram.Visible = false;

                

                // Lista as redes sociais associadas ao cliente.
                List<RedesocialDTO> redesociais = RedesocialBLL.Listar_Fkcliente(id_Cliente);

                // Percorre a lista de redes sociais e executa ações com base na descrição da rede.
                foreach (RedesocialDTO rede in redesociais)
                {
                    if (rede.DescricaoRedeRs == "URL Linkedin")
                    {
                        // Obtém o valor do LinkedIn da URL da rede social e verifica se não é nulo ou vazio.
                        string valorLinkdin = rede.LinkRedeRs?.Replace("https://www.linkedin.com/in/", "");
                        if (!string.IsNullOrEmpty(valorLinkdin) && status)
                        {
                            // Torna o hiperlink do LinkedIn visível e o painel de informações da rede visível, enquanto oculta o painel de imagens da rede.
                            HLLinkedin.Visible = true;
                            PnRedeInfo.Visible = true;
                            PnRedeImg.Visible = false;
                            LblLinkedin2.Text = valorLinkdin;
                            HLLinkedin.NavigateUrl = rede.LinkRedeRs;
                        }
                    }
                    else if (rede.DescricaoRedeRs == "URL Whatsapp")
                    {
                        // Obtém o valor do WhatsApp da URL da rede social e verifica se não é nulo ou vazio.
                        string valorWhatsapp = rede.LinkRedeRs?.Replace("https://wa.me/+55", "");
                        if (!string.IsNullOrEmpty(valorWhatsapp) && status)
                        {
                            // Torna o hiperlink do WhatsApp visível e o painel de informações da rede visível, enquanto oculta o painel de imagens da rede.
                            HLWhatsapp.Visible = true;
                            PnRedeInfo.Visible = true;
                            PnRedeImg.Visible = false;
                            LblWhatsapp2.Text = valorWhatsapp;
                            HLWhatsapp.NavigateUrl = rede.LinkRedeRs;
                        }
                    }
                    else if (rede.DescricaoRedeRs == "URL Instagram")
                    {
                        // Obtém o valor do Instagram da URL da rede social e verifica se não é nulo ou vazio.
                        string valorInstagram = rede.LinkRedeRs?.Replace("https://www.instagram.com/", "");
                        if (!string.IsNullOrEmpty(valorInstagram) && status)
                        {
                            // Torna o hiperlink do Instagram visível e o painel de informações da rede visível, enquanto oculta o painel de imagens da rede.
                            HLInstagram.Visible = true;
                            PnRedeInfo.Visible = true;
                            PnRedeImg.Visible = false;
                            LblInstagram2.Text = valorInstagram;
                            HLInstagram.NavigateUrl = rede.LinkRedeRs;
                        }
                    }
                }
            }
            else
            {
                // Se o status for falso, mostra o painel de imagens da rede e oculta o painel de informações da rede.
                PnRedeImg.Visible = true;
                PnRedeInfo.Visible = false;
            }
        }

    }
}