using FW.BLL;
using FW.DTO;
using System;
using System.IO;
using System.Windows.Documents;
using System.Net;

namespace FW.UI
{
    public partial class Users_google : System.Web.UI.Page
    {

        protected internal Random GeradorCodigo { get; set; } = new Random();

        protected TipoUserDTO TipoUserDTO = new TipoUserDTO();
        protected ClienteDTO ClienteDTO = new ClienteDTO();
        protected GoogleDTO GoogleDTO = Sessao.GoogleDTO;

        protected void Page_Load(object sender, EventArgs e)
        {


            GoogleDTO GoogleDTO = Sessao.GoogleDTO;

            if (!IsPostBack && GoogleDTO == null)
            {
                Response.Redirect("autenticacao.aspx");

            }
        }


        protected int Cadastrando_usuario_google(int CodigoTU, string Sexo)
        {
            Sessao.GoogleDTO.SexoCl = Sexo;
            Sessao.GoogleDTO.CodigoTu = Convert.ToInt32(CodigoTU);
            GoogleBLL GoogleBLL = new GoogleBLL();
            if (GoogleDTO.CaminhoFotoCl != null)
            {
                // Fazer o download da imagem
                string imageUrl = GoogleDTO.CaminhoFotoCl;
                string nome_foto = @"../Cliente/Foto_cliente/Foto_Cliente_Google_Cod_" + GeradorCodigo.Next(10, 100000).ToString() + ".jpg";
                string caminhoCompleto = Server.MapPath(nome_foto);

                bool arquivoExiste = File.Exists(caminhoCompleto);

                while (arquivoExiste)
                {
                    // Caso o arquivo já exista com o nome gerado, gera um novo nome de arquivo único
                    nome_foto = @"../Cliente/Foto_cliente/Foto_Cliente_Google_Cod_" + GeradorCodigo.Next(10, 100000).ToString() + ".jpg";
                    caminhoCompleto = Server.MapPath(nome_foto);
                    arquivoExiste = File.Exists(caminhoCompleto);
                }
                //fazendo download e renomeando
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(imageUrl, caminhoCompleto);
                }

                // Atualizar a propriedade GoogleDTO.CaminhoFotoCl com o novo caminho
                GoogleDTO.CaminhoFotoCl = nome_foto;
            }
            else
            {
                // Copiar uma imagem padrão com base no sexo
                string nome_foto = @"../Cliente/Foto_cliente/Foto_Cliente_Google_Cod_" + GeradorCodigo.Next(10, 100000).ToString() + ".jpg";
                string caminhoCompleto = Server.MapPath(nome_foto);

                bool arquivoExiste = File.Exists(caminhoCompleto);

                while (arquivoExiste)
                {
                    // Caso o arquivo já exista com o nome gerado, gera um novo nome de arquivo único
                    nome_foto = @"../Cliente/Foto_cliente/Foto_Cliente_Google_Cod_" + GeradorCodigo.Next(10, 100000).ToString() + ".jpg";
                    caminhoCompleto = Server.MapPath(nome_foto);
                    arquivoExiste = File.Exists(caminhoCompleto);
                }

                if (Sexo == "Masculino")
                {
                    // Caminho da imagem de avatar padrão para o sexo masculino
                    string male_avatar = @"../Cliente/Foto_cliente/undraw_male_avatar_323b.svg";

                    // Copiar o arquivo de avatar padrão para o caminho e nome de arquivo gerado
                    File.Copy(Server.MapPath(male_avatar), caminhoCompleto);
                }
                else if (Sexo == "Feminino")
                {
                    // Caminho da imagem de avatar padrão para o sexo feminino
                    string female_avatar = @"../Cliente/Foto_cliente/undraw_female_avatar_w3jk.svg";

                    // Copiar o arquivo de avatar padrão para o caminho e nome de arquivo gerado
                    File.Copy(Server.MapPath(female_avatar), caminhoCompleto);
                }

                // Atualizar a propriedade GoogleDTO.CaminhoFotoCl com o novo caminho
                GoogleDTO.CaminhoFotoCl = nome_foto;
            }



            if (Convert.ToInt32(CodigoTU) == 2)
            {
                Sessao.GoogleDTO.DescricaoTu = "PROFISSIONAL";
                bool status = GoogleBLL.CadastrarCliente<ProfissionalDTO>(Sessao.GoogleDTO);
                if (status)
                {
                    return 2;
                }
            }
            else if (Convert.ToInt32(CodigoTU) == 3)
            {
                Sessao.GoogleDTO.DescricaoTu = "EMPRESA";

                bool status = GoogleBLL.CadastrarCliente<EmpresaDTO>(Sessao.GoogleDTO);
                if (status)
                {
                    return 3;
                }
            }
                    return 0;
        }


        protected void Btn_confirmar_Click(object sender, EventArgs e)
        {
            int codigo = Convert.ToInt32(DLLTipoUSer.SelectedValue);
            string sexo = DDLSexo.SelectedValue;
            int retorno = Cadastrando_usuario_google(codigo, sexo);


            if (retorno == 0)
            {
                Master.MensagemJS("Erro", "Erro ao Cadastrar");
                Response.Redirect("../pages/Default.aspx");
            }
            else
            {
                Response.Redirect("../pages/DefaultCliente.aspx");
            }
        }
         
    }
}