using FW.BLL;
using FW.DTO;
using System;
using System.Drawing;
using System.IO;

namespace FW.UI.empr
{
    public partial class EditarFoto : System.Web.UI.Page
    {
        static string foto_Atual;
        protected internal Random GeradorCodigo { get; set; } = new Random();
        public int ID_Cliente_Master = ClienteTemporario.ID_Cliente;

        protected internal ClienteDTO ClienteDTO { get; set; } = new ClienteDTO();
        protected internal ClienteBLL ClienteBLL { get; set; } = new ClienteBLL();
        protected void Page_Load(object sender, EventArgs e)
        {



            Master.Verificar_usuario();
            if (!IsPostBack)
            {
                SelecionandoImagem();

            }
        }

        protected void Btn_foto_upload_Click(object sender, EventArgs e)
        {
            var str = File_Foto.FileName;

            if (str.ToString() != "")
            {
                try
                {
                    var Arquivo = File_Foto.PostedFile;
                    var bitmap = Bitmap.FromStream(Arquivo.InputStream);
                    if (File_Foto.HasFile)
                    {
                        File_Foto.PostedFile.SaveAs(Server.MapPath("../Cliente/Foto_cliente/" + Arquivo));
                        string Caminhoimg = @"../Cliente/Foto_cliente/" + Arquivo.ToString();
                        string nome_foto = @"../Cliente/Foto_cliente/Foto_Cliente_" + Convert.ToInt32(ID_Cliente_Master).ToString() + "_Cod_" + GeradorCodigo.Next(10, 1000).ToString() + ".png";

                        AltarandoName_foto(Caminhoimg, nome_foto);

                        AlterardoFoto(nome_foto);
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

        public void SelecionandoImagem()
        {
            ClienteDTO = ClienteBLL.Selecionar_Foto(ID_Cliente_Master);
            if (ClienteDTO != null)
            {
                imagePro.ImageUrl = ClienteDTO.CaminhoFotoCl;
                foto_Atual = ClienteDTO.CaminhoFotoCl;
            }

        }
        public void AltarandoName_foto(string Arquivo, string nome_foto)
        {

            bool result = File.Exists(Server.MapPath(nome_foto));
            if (result == true)
            {
                File.Delete(Server.MapPath(nome_foto));
                File.Delete(Server.MapPath(foto_Atual));
                File.Move(Server.MapPath(Arquivo), Server.MapPath(nome_foto));
            }
            else
            {
                File.Delete(Server.MapPath(foto_Atual));

                File.Move(Server.MapPath(Arquivo), Server.MapPath(nome_foto));
            }

        }
        public void AlterardoFoto(string FotoCaminho)
        {

            ClienteDTO.IdCliente = ID_Cliente_Master;
            ClienteDTO.CaminhoFotoCl = FotoCaminho;

            ClienteBLL.Editar_Foto_cliente(ClienteDTO);
            SelecionandoImagem();
            Master.MensagemJS("Sucesso", "Imagem alterada.");

        }

        protected void BtnExcluir_Click(object sender, EventArgs e)
        {
            Remover_Foto(foto_Atual);
        }

        public void Remover_Foto(string foto_Atual)
        {
            ClienteDTO.IdCliente = ID_Cliente_Master;
            ClienteDTO = ClienteBLL.Selecionar_Foto(ID_Cliente_Master);
            if (ClienteDTO.SexoCl == "Masculino")
            {
                string Caminhoimg = @"../Cliente/Foto_cliente/undraw_male_avatar_323b.svg";
                string nome_foto = @"../Cliente/Foto_cliente/Foto_Cliente_" + Convert.ToInt32(ID_Cliente_Master).ToString() + "_Cod_" + GeradorCodigo.Next(10, 1000).ToString() + ".svg";
                bool result = File.Exists(Server.MapPath(nome_foto));
                if (result == true)
                {
                    string nome_foto_New = @"../Cliente/Foto_cliente/Foto_Cliente_" + Convert.ToInt32(ID_Cliente_Master).ToString() + "_Cod_" + GeradorCodigo.Next(10, 1000).ToString() + ".svg";
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
                string nome_foto = @"../Cliente/Foto_cliente/Foto_Cliente_" + Convert.ToInt32(ID_Cliente_Master).ToString() + "_Cod_" + GeradorCodigo.Next(10, 1000).ToString() + ".svg";
                bool result = File.Exists(Server.MapPath(nome_foto));
                if (result == true)
                {
                    string nome_foto_New = @"../Cliente/Foto_cliente/Foto_Cliente_" + Convert.ToInt32(ID_Cliente_Master).ToString() + "_Cod_" + GeradorCodigo.Next(10, 1000).ToString() + ".svg";
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
    }
}