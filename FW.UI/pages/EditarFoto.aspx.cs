using FW.BLL;
using FW.DTO;
using System;
using System.Drawing;
using System.IO;
using System.Web.UI.WebControls;

namespace FW.UI.pages
{
    public partial class EditarFoto : System.Web.UI.Page
    {
        protected static string foto_Atual;

        protected int ID_Profissional = ClienteTemporario.ID_Profissional;
        protected int ID_Cliente = ClienteTemporario.ID_Cliente;
        protected internal Random GeradorCodigo { get; set; } = new Random();

        protected internal ClienteDTO ClienteDTO = new ClienteDTO();
        protected internal ClienteBLL ClienteBLL = new ClienteBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
           Master.Verificar_usuario();
            if (!IsPostBack)
            {
                SelecionandoImagem(ID_Cliente);
                Verificando_Imagem();
            }
        }




        protected void Btn_foto_upload_Click(object sender, EventArgs e)
        {
            if (File_Foto.HasFile)
            {
                try
                {
                    //postando o arquivo no var
                    var Arquivo = File_Foto.PostedFile;
                    //verificando se a  imagem é valida.
                    Bitmap.FromStream(Arquivo.InputStream);
                    // verificando o tamanho da imagen se é iguam a 5 MB
                    var tamanho = File_Foto.PostedFile.ContentLength;
                    if (tamanho < 5100000)
                    {

                        // postando o arquivo no servidor
                        File_Foto.PostedFile.SaveAs(Server.MapPath("../Cliente/Foto_cliente/" + Arquivo));
                        //caminho do aquivo salvo.
                        string Caminhoimg = @"../Cliente/Foto_cliente/" + Arquivo.ToString();
                        // alterando nome do arquivo com numero Alertorio
                        string nome_foto = @"../Cliente/Foto_cliente/Foto_Cliente_" + Convert.ToInt32(ID_Cliente).ToString() + "_Cod_" + GeradorCodigo.Next(10, 10000).ToString() + ".png";
                        AltarandoName_foto(Caminhoimg, nome_foto);
                        AlterardoFoto(nome_foto);

                    }
                    else
                    {
                        Master.MensagemJS("Erro", "tamanho do arquivo é invalido");
                    }
                }
                catch
                {
                    Master.MensagemJS("Erro", "Erro, o arquivo não é uma imagem valida! use Arquivos do tipo JPG ou PNG");
                }
            }
            else
            {
                Master.MensagemJS("Erro", "Erro, não tem um arquivo valido.");

            }

        }

        protected void SelecionandoImagem(int ID_Cliente)
        {
            ClienteDTO = ClienteBLL.Selecionar_Foto(ID_Cliente);
            if (ClienteDTO != null)
            {
                //passando para o preview
                imagePro.ImageUrl = ClienteDTO.CaminhoFotoCl;
                // passando a foto   atual para uma string  statica 
                foto_Atual = ClienteDTO.CaminhoFotoCl;
            }

        }
        protected void AltarandoName_foto(string Arquivo, string nome_foto)
        {
            // verifica se nome da foto exist 
            bool result = File.Exists(Server.MapPath(nome_foto));

            if (result == true)
            {
                // caso exista ele deleta o arquivo  haja vista que é do mesmo cliente a foto. pq a foto recebe o id dele.
                File.Delete(Server.MapPath(nome_foto));
                ///deleta a foto atual
                File.Delete(Server.MapPath(foto_Atual));
                // copia a foto e cola com o novo nome 
                File.Move(Server.MapPath(Arquivo), Server.MapPath(nome_foto));
            }
            else
            {
                // se for false 
                //ele deleta a foto atual 

                File.Delete(Server.MapPath(foto_Atual));
                // altera o nome da foto nova.

                File.Move(Server.MapPath(Arquivo), Server.MapPath(nome_foto));
            }

        }
        protected void AlterardoFoto(string FotoCaminho)
        {
            // alterando no banco o caminho e nome da imagem
            ClienteDTO.IdCliente = ID_Cliente;
            ClienteDTO.CaminhoFotoCl = FotoCaminho;

            ClienteBLL.Editar_Foto_cliente(ClienteDTO);
            SelecionandoImagem(ID_Cliente);
            Master.MensagemJS("Alerta", "Imagem alterada.");
            Response.Redirect("EditarFoto.aspx");

        }

        protected void BtnExcluir_Click(object sender, EventArgs e)
        {
            Remover_Foto(foto_Atual,ID_Cliente);
        }

        protected void Remover_Foto(string foto_Atual , int id_cliente)
        {
            ClienteDTO.IdCliente = ID_Cliente;
            ClienteDTO = ClienteBLL.Selecionar_Foto(ID_Cliente);
            if (ClienteDTO.SexoCl == "Masculino")
            {
                string Caminhoimg = @"../Cliente/Foto_cliente/undraw_male_avatar_323b.svg";
                string nome_foto = @"../Cliente/Foto_cliente/Foto_Cliente_" + Convert.ToInt32(ID_Cliente).ToString() + "_Cod_" + GeradorCodigo.Next(10, 1000).ToString() + ".svg";
                bool result = File.Exists(Server.MapPath(nome_foto));
                if (result == true)
                {
                    string nome_foto_New = @"../Cliente/Foto_cliente/Foto_Cliente_" + Convert.ToInt32(ID_Cliente).ToString() + "_Cod_" + GeradorCodigo.Next(10, 1000).ToString() + ".svg";
                    File.Delete(Server.MapPath(foto_Atual));
                    File.Copy(Server.MapPath(Caminhoimg), Server.MapPath(nome_foto_New));
                }
                else
                {
                    File.Delete(Server.MapPath(foto_Atual));
                    File.Copy(Server.MapPath(Caminhoimg), Server.MapPath(nome_foto));
                }
                File.Delete(Server.MapPath(ClienteDTO.CaminhoFotoCl));
                AlterardoFoto(nome_foto);
            }
            else if (ClienteDTO.SexoCl == "Feminino")
            {
                string Caminhoimg = @"../Cliente/Foto_cliente/undraw_female_avatar_w3jk.svg";
                string nome_foto = @"../Cliente/Foto_cliente/Foto_Cliente_" + Convert.ToInt32( ID_Cliente).ToString() + "_Cod_" + GeradorCodigo.Next(10, 1000).ToString() + ".svg";
                bool result = File.Exists(Server.MapPath(nome_foto));
                if (result == true)
                {
                    string nome_foto_New = @"../Cliente/Foto_cliente/Foto_Cliente_" + Convert.ToInt32(ID_Cliente).ToString() + "_Cod_" + GeradorCodigo.Next(10, 1000).ToString() + ".svg";
                    File.Delete(Server.MapPath(foto_Atual));
                    File.Copy(Server.MapPath(Caminhoimg), Server.MapPath(nome_foto_New));
                }
                else
                {
                    File.Delete(Server.MapPath(foto_Atual));
                    File.Copy(Server.MapPath(Caminhoimg), Server.MapPath(nome_foto));
                }
                File.Delete(Server.MapPath(foto_Atual));

                AlterardoFoto(nome_foto);
            }


        }


        [System.Web.Services.WebMethod]
        public static bool Verificando_Imagem()
        {
            //try
            //{
            //    var mc = new EditarFoto();
            //    FileUpload newFile = mc.valor();
            //    //postando o arquivo no var
            //    var Arquivo = newFile.PostedFile;
            //    //verificando se a  imagem é valida.
            //    Bitmap.FromStream(Arquivo.InputStream);

            //    return true;
            //}
            //catch
            //{
            return false;
            //}
        }



        public FileUpload Valor()
        {
            FileUpload FileUpload = new FileUpload();
            return FileUpload;
        }

    }

}
