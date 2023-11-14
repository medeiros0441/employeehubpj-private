using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using FW.BLL;
using FW.DTO;
using System.IO; 
namespace FW.UI
{
    /// <summary>
    /// Descrição resumida de Global1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que esse serviço da web seja chamado a partir do script, usando ASP.NET AJAX, remova os comentários da linha a seguir. 
     [System.Web.Script.Services.ScriptService]
    public class GlobalServices : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Olá, Mundo";
        }

        [WebMethod]
        public  string[] GetSugestoes(string prefixo, string tipo)
        {
            List<string> suggestions = new List<string>();

  	 if (tipo == "NomeCliente")
            {
                var profissionalDTO = new ProfissionalDTO();
                profissionalDTO.PrimeiroNomeCl = prefixo;

                var profissionalBLL = new ProfissionalBLL();
                var ListaRetorno = profissionalBLL.Pesquisa_profissional(profissionalDTO);

                foreach (var profissional in ListaRetorno)
                {
                    string nome = profissional.PrimeiroNomeCl;
                    suggestions.Add(nome);
                }
            }else
            if (tipo == "usuario")
            {
                var profissionalDTO = new ProfissionalDTO();
                profissionalDTO.UsuarioCl = prefixo;

                var profissionalBLL = new ProfissionalBLL();
                var ListaRetorno = profissionalBLL.Pesquisa_profissional(profissionalDTO);

                foreach (var profissional in ListaRetorno)
                {
                    string nome = profissional.UsuarioCl;
                    suggestions.Add(nome);
                }
            }
            else if (tipo == "NomeVaga")
            {
                var vagaDTO = new VagaDTO();
                vagaDTO.NomeVg = prefixo;

                var vagaBLL = new VagaBLL();
                var ListaOportunidade = vagaBLL.BuscarVaga(vagaDTO);

                foreach (var DTO in ListaOportunidade)
                {
                    string nome = DTO.NomeVg;
                    suggestions.Add(nome);
                }
            }
		else if (tipo == "Cidade")
            {
                var profissionalDTO = new ProfissionalDTO();
                profissionalDTO.DescricaoCidadeCl = prefixo;

                var profissionalBLL = new ProfissionalBLL();
                var ListaRetorno = profissionalBLL.Pesquisa_profissional(profissionalDTO);

                foreach (var profissional in ListaRetorno)
                {
                    string nome = profissional.DescricaoCidadeCl;
                    suggestions.Add(nome);
                }
            }
 else if (tipo == "Uf")
            {
                var profissionalDTO = new ProfissionalDTO();
                profissionalDTO.DescricaoEstadoCl = prefixo;

                var profissionalBLL = new ProfissionalBLL();
                var ListaRetorno = profissionalBLL.Pesquisa_profissional(profissionalDTO);

                foreach (var profissional in ListaRetorno)
                {
                    string nome = profissional.DescricaoEstadoCl;
                    suggestions.Add(nome);
                }
            }
            return suggestions.ToArray();
        }



    [WebMethod]
  public string UploadFile(string fileData, string fileName, string email, int userId)
{
    try
    {
        // Converter a string base64 de volta para bytes
        byte[] fileBytes = Convert.FromBase64String(fileData);
            // Verifique se o diretório de armazenamento existe. Você pode ajustar o caminho conforme necessário.
            string storagePath = Server.MapPath("~/Uploads");
            if (!Directory.Exists(storagePath))
            {
                Directory.CreateDirectory(storagePath);
            }

            // Gere um nome de arquivo único com base no email e no ID do usuário
            string fileExtension = Path.GetExtension(fileName);
            string uniqueFileName = $"{email}_{userId}_{Guid.NewGuid()}{fileExtension}";

            // Combine o caminho do diretório com o nome de arquivo único
            string filePath = Path.Combine(storagePath, uniqueFileName);

          using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
{
    fileStream.Write(fileBytes, 0, fileBytes.Length);
}

            // Retorne o caminho do arquivo salvo (ou você pode retornar qualquer outra informação necessária)
            return filePath;
        }
        catch (Exception ex)
        {
            // Trate qualquer exceção e registre informações de erro, se necessário.
            return "Erro: " + ex.Message;
        }
    }
    }

}
