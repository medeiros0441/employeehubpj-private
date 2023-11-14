using FW.BLL;
using FW.DTO;
using System;
using System.Collections.Generic;

namespace FW.UI.pro
{
    public partial class View_Publicacao : System.Web.UI.Page
    {
        protected PublicacaoDTO PublicacaoDTO = new PublicacaoDTO();
        protected PublicacaoBLL PublicacaoBLL = new PublicacaoBLL();
        protected Random GeradorCodigo = new Random();
        protected int ID_Cliente = ClienteTemporario.ID_Cliente;
        protected int ID_Profissional = ClienteTemporario.ID_Profissional;
         protected ComentarioBLL ComentarioBLL = new ComentarioBLL();
        protected ComentarioDTO ComentarioDTO = new ComentarioDTO();
        protected void Page_Load(object sender, EventArgs e)
        {
            int ID_Publi = Convert.ToInt32(Request.QueryString["id_Publicacao"]);
            //int ID_cliente = Convert.ToInt32(Request.QueryString["id_cliente"]);

            // string Mensagem = Request.QueryString["Messagem"];

            if (ID_Publi != 0)
            {

                PublicacaoDTO.FkClienteTu = ID_Cliente;
                PublicacaoDTO.IdPublicacao = ID_Publi;
                PublicacaoDTO = PublicacaoBLL.Selecionar_IdCliente_IdPublicacao(PublicacaoDTO);
                Seleciona_Publi(PublicacaoDTO);
                // CriandoOBJ_Publi(PublicacaoDTO);

            }
            //if(Mensagem != null)
            //{
            //    Master.MensagemSucesso(Mensagem);
            //}
        }

        protected PublicacaoDTO Seleciona_Publi(PublicacaoDTO PublicacaoDTO)
        {

            if (PublicacaoDTO != null)
            {
                Imagem_Perfil_Publi.ImageUrl = PublicacaoDTO.CaminhoFotoCl;
                Nome_cliente.Text = PublicacaoDTO.UsuarioCl;
                Date_Publicacao.Text = PublicacaoDTO.DateTimeUpdatePb.ToString("dd/mm/yyyy hh/mm");
                Descricao_Publicacao.Text = PublicacaoDTO.DescricaoPb;
                if (PublicacaoDTO.UrlImagen1Pb != "")
                {
                    Imagem_Publi_1.ImageUrl = PublicacaoDTO.UrlImagen1Pb;
                    Pn_img.Attributes["class"] = " container_slide Pn_slide slide m-0 ";
                    Imagem_Publi_1.Visible = true;

                    if (PublicacaoDTO.UrlImagen2Pb != "")
                    {
                        Imagem_Publi_2.Visible = true;
                        Imagem_Publi_2.ImageUrl = PublicacaoDTO.UrlImagen2Pb;

                    }
                    if (PublicacaoDTO.UrlImagen3Pb != "")
                    {
                        Imagem_Publi_3.Visible = true;
                        Imagem_Publi_3.ImageUrl = PublicacaoDTO.UrlImagen3Pb;
                    }
                }
                else if (PublicacaoDTO.UrlVideo1Pb != "")
                {
                    //tirando visibilidade do container slide
                    Pn_img.Attributes["class"] = " d-none";

                    // Pn_Video.Visible = true;
                    //Nome_cliente.Text = PublicacaoDTO.URL_Video1;
                    //Nome_cliente.Text = PublicacaoDTO.URL_Video2;
                }


                List<ComentarioDTO> Lista_comentarios = ListaComentarios(PublicacaoDTO.IdPublicacao);
                if (Lista_comentarios.Count != 0)
                {
                    Rpt_Comentario_Publicacao.Visible = true;
                    Rpt_Comentario_Publicacao.DataSource = Lista_comentarios;
                    Rpt_Comentario_Publicacao.DataBind();

                }
                else
                {

                    Rpt_Comentario_Publicacao.Visible = false;

                }
            }
            return null;
        }




        public List<ComentarioDTO> ListaComentarios(int id_publicacao)
        {
            
            ComentarioDTO.IdPublicacao = id_publicacao;
            List<ComentarioDTO> ListaDTO = ComentarioBLL.Filtrar(ComentarioDTO);
            return ListaDTO;
        }

        protected void EnviarComentarioPublicacao(object sender, EventArgs e)
        {
            ComentarioBLL ComentarioBLL = new ComentarioBLL();
            ComentarioDTO ComentarioDTO = new ComentarioDTO();
            if (txtcomentario.Text != null && txtcomentario.Text != "")
            {
                ComentarioDTO.ComentarioCm = txtcomentario.Text;
                ComentarioDTO.FkPublicacaoCm = Convert.ToInt32(Request.QueryString["id_Publicacao"]);
                ComentarioDTO.FkClienteCm =  ID_Cliente;
                ComentarioBLL.Cadastrar_Publicacao(ComentarioDTO);
            }
            else
            {
                Master.MensagemJS("Erro", "Erro, ao inserir comentario.");
            }


        }

        protected void BtnEnviar_Comentario_Click(object sender, EventArgs e)
        {

        }
    }
}