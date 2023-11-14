using FW.BLL;
using FW.DTO;
using System;
using System.Drawing;
using System.IO;
using System.Web.UI.WebControls;

namespace FW.UI.pages
{
    public partial class Formulario_Publicacao : System.Web.UI.Page
    {
        protected PublicacaoDTO PublicacaoDTO = new PublicacaoDTO();
        protected PublicacaoBLL PublicacaoBLL = new PublicacaoBLL();
        protected Random GeradorCodigo = new Random();
        protected int ID_Cliente = ClienteTemporario.ID_Cliente;

        protected void Page_Load(object sender, EventArgs e)
        {

            int ID_Publi = Convert.ToInt32(Request.QueryString["id_Publicacao"]);
            int id_cliente = Convert.ToInt32(Request.QueryString["id_cliente"]);

            if (ID_Publi != 0 && id_cliente != 0)
            {
                Selecionar_publicacao(ID_Publi, id_cliente);

            }


            if (!IsPostBack == true)
            {
                Master.MensagemJS("Sucesso", "Use esse espaço para demonstrar seus trabalho, Projetos, Sejá  criativo.");
            }
            

        }

        protected void Selecionar_publicacao(int id_publicacao, int id_cliente)
        {
            PublicacaoDTO.FkClientePb = id_cliente;
            PublicacaoDTO.IdPublicacao = id_publicacao;
            PublicacaoDTO = PublicacaoBLL.Selecionar_IdCliente_IdPublicacao(PublicacaoDTO);
            txtMenssagem.Text = PublicacaoDTO.DescricaoPb;
        }
        protected void AltarandoName_foto(string Caminhoimg, string Nome_arquivo)
        {
            bool result = File.Exists(Server.MapPath(Caminhoimg));
            if (result == true)
            {
                File.Move(Server.MapPath(Caminhoimg), Server.MapPath(Nome_arquivo));

            }
            else
            {
                Master.MensagemJS("Erro",   "Erro, Aquivo não encontrado.");
            }

        }

        protected string VerificandoFoto(FileUpload File_Foto)
        {
            string Nome_arquivo;
            try
            {
                if (File_Foto.HasFile)
                {

                    var Arquivo = File_Foto.PostedFile;
                    var bitmap = Bitmap.FromStream(Arquivo.InputStream);
                    var tamanho = File_Foto.PostedFile.ContentLength;
                    if (tamanho < 5100000)
                    {
                        string CaminhoImg = @"../Cliente/Publicacao/";
                        Nome_arquivo = "Publicacao_IdCliente_" + Convert.ToInt32(ID_Cliente).ToString() + "_COD_" + GeradorCodigo.Next(1, 900000).ToString() + ".png";
                        bool result2 = File.Exists(Server.MapPath(CaminhoImg + Nome_arquivo));
                        if (result2 == true)
                        {
                            string Nome_arquivo_new = "Publicacao_IdCliente_" + Convert.ToInt32(ID_Cliente).ToString() + "_COD_" + GeradorCodigo.Next(1, 900000).ToString() + GeradorCodigo.Next(1, 900000).ToString() + ".png";
                            string Caminho_Arquivo = CaminhoImg + File_Foto.FileName;
                            File_Foto.PostedFile.SaveAs(Server.MapPath(Caminho_Arquivo));
                            AltarandoName_foto(CaminhoImg, CaminhoImg + Nome_arquivo_new);
                            string Nome_temp = "../Cliente/Publicacao/" + Nome_arquivo_new;
                            return Nome_temp;
                        }
                        else
                        {

                            string Caminho_Arquivo = CaminhoImg + File_Foto.FileName;
                            File_Foto.PostedFile.SaveAs(Server.MapPath(Caminho_Arquivo));
                            AltarandoName_foto(Caminho_Arquivo, CaminhoImg + Nome_arquivo);
                            string Nome_temp = "../Cliente/Publicacao/" + Nome_arquivo;
                            return Nome_temp;
                        }
                    }
                    else
                    {
                        Master.MensagemJS("Alerta", $"tamanho do arquivo no Campo imagem {File_Foto.ID} é invalido, coloque arquivo de até 5 MB");
                        return null;
                    }
                }
                else
                {
                    Master.MensagemJS("Erro", $"Erro, não tem um arquivo valido, no Campo imagem {File_Foto.ID}");
                    return null;
                }
            }
            catch
            {

                Master.MensagemJS("Erro", $"Erro!, o arquivo do campo imagem {File_Foto.ID} não é uma imagem valida! use Arquivos do tipo JPG ou PNG");
                return null;

            }
            // return Nome_arquivo;
        }


        public void Insert(PublicacaoDTO PublicacaoDTO)
        {
            PublicacaoDTO.FkClientePb = ID_Cliente;

            PublicacaoDTO = PublicacaoBLL.Cadastrar_Publicacao(PublicacaoDTO);

            Response.Redirect($"View_Publicacao.aspx?id_Publicacao={PublicacaoDTO.IdPublicacao}&&Id_cliente={PublicacaoDTO.FkClientePb}");

        }

        protected void BtnCadastrar_texto_Click(object sender, EventArgs e)
        {
            string Texto_form = txtMenssagem.Text.Trim().Replace("\r\n", "</br>");

            if (Texto_form != null && Texto_form != "")
            {
                PublicacaoDTO.DescricaoPb = Texto_form;
                Insert(PublicacaoDTO);

            }
            else
            {
                Master.MensagemJS("Erro", "Erro. o texto é invalido. ");
            }


        }

        protected void Btn_PublicarVideo_Click(object sender, EventArgs e)
        {
            string Texto_form = txtMenssagem.Text.Trim().Replace("\r\n", "</br>");

            if (Texto_form != null && Texto_form != "")
            {
                if (UrlYoutube1.Text != null && UrlYoutube1.Text != "")
                {
                    PublicacaoDTO.UrlVideo1Pb = UrlYoutube1.Text;
                }
                if (UrlYoutube2.Text != null && UrlYoutube2.Text != "")
                {
                    PublicacaoDTO.UrlVideo2Pb = UrlYoutube2.Text;

                }


                PublicacaoDTO.DescricaoPb = Texto_form;
                Insert(PublicacaoDTO);



            }
            else
            {
                Master.MensagemJS("Erro", "Erro, o campo descrição está nulo!");
            }

        }

        protected void BtnPublicar_foto_Click(object sender, EventArgs e)
        {
            PublicacaoDTO PublicacaoDTO = new PublicacaoDTO();


            try
            {
                string Texto_form = txtMenssagem.Text.Trim().Replace("\r\n", "</br>");

                if (Texto_form != null && Texto_form != "")
                {
                    if (File_1.FileName != "" && File_1.FileName != null)
                    {
                        string Url_foto = VerificandoFoto(File_1);
                        PublicacaoDTO.UrlImagen1Pb = Url_foto;
                    }
                    if (File_2.FileName != "" && File_2 != null)
                    {
                        string Url_foto = VerificandoFoto(File_2);

                        PublicacaoDTO.UrlImagen2Pb = Url_foto;

                    }
                    if (File_3.FileName != "" && File_3.FileName != null)
                    {
                        string Url_foto = VerificandoFoto(File_3);
                        PublicacaoDTO.UrlImagen3Pb = Url_foto;

                    }
                    PublicacaoDTO.DescricaoPb = Texto_form;
                    Insert(PublicacaoDTO);
                }
                else
                {
                    Master.MensagemJS("Erro", "Erro, o campo descrição está nulo!");
                }
            }
            catch
            {
                Master.MensagemJS("Erro", "Erro ao cadastrar Publicacao!");

            }
        }
    }
}
