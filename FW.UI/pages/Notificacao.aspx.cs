using FW.BLL;
using FW.DTO;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;


namespace FW.UI
{
    public partial class Notificacao : System.Web.UI.Page
    {

        protected private int ID_Cliente_Master = ClienteTemporario.ID_Cliente;
        protected internal int ID_Profissional_Master = ClienteTemporario.ID_Profissional;

        protected internal NotificacaoDTO NotificacaoDTO = new NotificacaoDTO();
        protected internal NotificacaoBLL NotificacaoBLL = new NotificacaoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Verificar_usuario();

            if (!IsPostBack)
            {
                // Carrega a lista de notificações e armazena em uma variável de sessão
                List<NotificacaoDTO> Lista_Notificacao = NotificacaoBLL.ListarNotificacoes(ID_Cliente_Master);
                Session["Lista_Notificacao"] = Lista_Notificacao;

                if (Lista_Notificacao.Count > 0)
                {
                    rpt_Notificacao.DataSource = Lista_Notificacao;
                    rpt_Notificacao.DataBind();
                }
                else
                {
                    not_notificacao.Visible = true;
                    Master.MensagemJS("Alerta", "ops, nunhuma notificação por enquanto.");
                }
            }

        }


        protected void Btn_abrir_notificacao_Click(object sender, EventArgs e)
        {
            rpt_Notificacao.Visible = false;

            // Recupera o ID da notificação a partir do botão clicado
            LinkButton btn = (LinkButton)sender;
            int id_notificacao_btn = int.Parse(btn.CommandArgument);

            // Recupera a lista de notificações da variável de sessão
            List<NotificacaoDTO> Lista_Notificacao = (List<NotificacaoDTO>)Session["Lista_Notificacao"];
            if (Lista_Notificacao != null)
            {
                // Procura a notificação com o ID correspondente
                foreach (NotificacaoDTO notificacao in Lista_Notificacao)
                {
                    if (notificacao.IdNotificacao == id_notificacao_btn)
                    {
                        if (notificacao.VisibilidadeNc == false)
                        {
                            NotificacaoBLL.AtualizarVisibilidade(id_notificacao_btn, true);
                        }
                        lbl_Titulo_notificacao.Text = notificacao.TituloNc;
                        lbl_descricao_notificacao.Text = notificacao.MensagemNc;
                        lbl_data_notificacao.Text = notificacao.DateTimeInsertNc.ToString("dd/mm/yyyy hh/mm");
                        panel_mensagem.Visible = true;

                        break;
                    }
                }
            }

        }
    }
}