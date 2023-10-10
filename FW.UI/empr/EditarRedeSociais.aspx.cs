using System;
using FW.BLL;
using FW.DTO;
using System.Collections.Generic;

namespace FW.UI.empr
{
    public partial class EditarRedeSociais : System.Web.UI.Page
    {

        protected private int ID_Cliente_Master = ClienteTemporario.ID_Cliente;
        protected private int ID_Empresa_Master = ClienteTemporario.ID_Empresa;

        protected internal RedesocialDTO redesocialDTO = new RedesocialDTO();
        protected internal RedesocialBLL redesocialBLL = new RedesocialBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Verificar_usuario();
            if (!IsPostBack)
            {
                SelecionarRedeSociais(ID_Cliente_Master);

            }
        }

        protected void BtnSalvarRedesSociais_Click(object sender, EventArgs e)
        {
            Salvar_RedeSocial(ID_Cliente_Master);
        }

        protected static int ID_RedeInsta;
        protected static string Link_RedeInsta;
        protected static int ID_RedeLinkdin;
        protected static string Link_RedeLinkdin;
        protected static int ID_RedeWhats;
        protected static string Link_RedeWhats;

        protected void SelecionarRedeSociais(int id_cliente)
        {
            List<RedesocialDTO> redesociais = redesocialBLL.Listar_Fkcliente(id_cliente);

            foreach (RedesocialDTO rede in redesociais)
            {
                if (rede.DescricaoRedeRs == "URL Linkedin")
                {
                    urllinkedin.Text = rede.LinkRedeRs?.Replace("https://www.linkedin.com/in/", "");
                    Link_RedeLinkdin = rede.LinkRedeRs?.Replace("https://www.linkedin.com/in/", "");
                    ID_RedeLinkdin = rede.IdRede;
                }
                else if (rede.DescricaoRedeRs == "URL Whatsapp")
                {
                    urlWhatsapp.Text = rede.LinkRedeRs?.Replace("https://wa.me/+55", "");
                    Link_RedeWhats = rede.LinkRedeRs?.Replace("https://wa.me/+55", "");
                    ID_RedeWhats = rede.IdRede;
                }
                else if (rede.DescricaoRedeRs == "URL Instagram")
                {
                    ID_RedeInsta = rede.IdRede;
                    Link_RedeInsta = rede.LinkRedeRs?.Replace("https://www.instagram.com/", "");
                    urlinstagram.Text = rede.LinkRedeRs?.Replace("https://www.instagram.com/", "");
                }
            }
        }

        protected void Salvar_RedeSocial(int id_clienteSessao)
        {

            if (Link_RedeLinkdin != null && Link_RedeLinkdin != urllinkedin.Text)
            {
                redesocialDTO.IdRede = ID_RedeLinkdin;
                redesocialDTO.FkClienteRs = id_clienteSessao;
                redesocialDTO.LinkRedeRs = "https://www.linkedin.com/in/" + urllinkedin.Text;
                redesocialDTO.DescricaoRedeRs = "URL  Linkedin";
                redesocialBLL.Editar(redesocialDTO);
                Master.MensagemJS("Sucesso", "Linkedin  Alterado");
            }
            else if (ID_RedeLinkdin == 0 && urllinkedin.Text != "")
            {
                redesocialDTO.DescricaoRedeRs = "URL Linkedin";
                redesocialDTO.FkClienteRs = id_clienteSessao;
                redesocialDTO.LinkRedeRs = "https://www.linkedin.com/in/" + urllinkedin.Text;
                redesocialBLL.Cadastrar_Link(redesocialDTO);
                Master.MensagemJS("Sucesso", "Linkedin Cadastrado");
            }

            if (Link_RedeWhats != null && Link_RedeWhats != urlWhatsapp.Text)
            {
                redesocialDTO.IdRede = ID_RedeWhats;
                redesocialDTO.FkClienteRs = id_clienteSessao;
                redesocialDTO.LinkRedeRs = "https://wa.me/+55" + urlWhatsapp.Text;
                redesocialDTO.DescricaoRedeRs = "URL Whatsapp";
                redesocialBLL.Editar(redesocialDTO);

                Master.MensagemJS("Sucesso", "Whatsapp Alterado");

            }
            else if (ID_RedeWhats == 0 && urlWhatsapp.Text != "")
            {
                redesocialDTO.DescricaoRedeRs = "URL Whatsapp";
                redesocialDTO.FkClienteRs = id_clienteSessao;
                redesocialDTO.LinkRedeRs = "https://wa.me/+55" + urlWhatsapp.Text;
                redesocialBLL.Cadastrar_Link(redesocialDTO);
                Master.MensagemJS("Sucesso", "Whatsapp Cadastrado");
            }

            if (Link_RedeInsta != null && Link_RedeInsta != urlinstagram.Text)
            {
                redesocialDTO.IdRede = ID_RedeInsta;
                redesocialDTO.FkClienteRs = id_clienteSessao;
                redesocialDTO.LinkRedeRs = "https://www.instagram.com/" + urlinstagram.Text;
                redesocialDTO.DescricaoRedeRs = "URL Instagram";
                redesocialBLL.Editar(redesocialDTO);
                Master.MensagemJS("Sucesso", "Instagram  Alterado");
            }
            else if (ID_RedeInsta == 0 && urlinstagram.Text != "")
            {
                redesocialDTO.DescricaoRedeRs = "URL Instagram";
                redesocialDTO.FkClienteRs = id_clienteSessao;
                redesocialDTO.LinkRedeRs = "https://www.instagram.com/" + urlinstagram.Text;
                redesocialBLL.Cadastrar_Link(redesocialDTO);
                Master.MensagemJS("Sucesso", "Instagram Cadastrado");

            }

            SelecionarRedeSociais(id_clienteSessao);

        }
    }
}
