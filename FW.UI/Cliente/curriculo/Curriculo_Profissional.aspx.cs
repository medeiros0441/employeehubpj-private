using FW.BLL;
using FW.DTO;//
using iTextSharp.text;//ESTENSAO 1 (TEXT)
using iTextSharp.text.pdf;//ESTENSAO 2 (PDF),
using System;
using System.Collections.Generic;
using Image = iTextSharp.text.Image;
using Paragraph = iTextSharp.text.Paragraph;

namespace FW.UI.Cliente.curriculo
{
    public partial class Curriculo_Profissional : System.Web.UI.Page
    {

        protected ProfissionalBLL ProfissionalBLL = new ProfissionalBLL();
        protected ProfissionalDTO ProfissionalDTO = new ProfissionalDTO();
        protected ExperienciaDTO ExperienciaDTO = new ExperienciaDTO();
        protected ExperienciaBLL ExperienciaBLL = new ExperienciaBLL();
        protected CertificadoDTO CertificadoDTO = new CertificadoDTO();
        protected CertificadoBLL CertificadoBLL = new CertificadoBLL();

        protected RedesocialDTO RedesocialDTO = new RedesocialDTO();
        protected RedesocialBLL RedesocialBLL = new RedesocialBLL();

         

        protected void Page_Load(object sender, EventArgs e)
        {
            int ID_Cliente = Sessao.ID_Cliente_PDF;
            int ID_Profissional = Sessao.ID_Profissional_PDF;
            if (ID_Cliente > 0  && ID_Profissional > 0) {
                ProfissionalDTO.IdCliente = ID_Cliente;
                ProfissionalDTO = ProfissionalBLL.SelecionarIdProfissional(ID_Profissional);

                List<RedesocialDTO> Lista_Redes = RedesocialBLL.Listar_Fkcliente(ID_Cliente);

                List<CertificadoDTO> Lista_Certificado = CertificadoBLL.ListarCertificado_IDProfissional(ID_Profissional);

                ExperienciaDTO.IdCliente = ID_Cliente;
                List<ExperienciaDTO> Lista_Experiencia = ExperienciaBLL.Listar_Experiencia_Profissional(ID_Profissional);
                Gerando_PDF(ProfissionalDTO, Lista_Redes, Lista_Certificado, Lista_Experiencia);

            }
            else
            {
                Response.Redirect("../../default.aspx");
            }
        }
        public class HeaderFooter : PdfPageEventHelper
        {
            private readonly Image image;
            private readonly string usuario;
            private readonly Font font = new Font(Font.FontFamily.HELVETICA, 8, Font.NORMAL, BaseColor.BLACK);

            public HeaderFooter(string usuario, Image image)
            {
                this.image = image;
                this.usuario = usuario;
            }

            public override void OnStartPage(PdfWriter writer, Document document)
            {
                // Verifica se a imagem foi carregada corretamente
                if (image == null)
                {
                    throw new Exception("A imagem não pôde ser carregada.");
                }

                // Redimensiona a imagem para o tamanho desejado
                image.ScaleAbsolute(25, 25);

                // Cria uma nova linha de texto
                Phrase linhaPhrase = new Phrase
                {
                    new Chunk(image, 0, 0),
                    new Chunk("Este é um PDF gerado por", font)
                };

                Anchor link = new Anchor("employeehubpj.azurewebsites.net", font)
                {
                    Reference = "employeehubpj.azurewebsites.net"
                };
                linhaPhrase.Add(link);
                linhaPhrase.Add("\r\n");
                linhaPhrase.Add(new Chunk("Para encontrar esse cliente basta buscar o usuário " + usuario + " em nosso site.", font));

                // Cria um novo parágrafo com a linha de texto criada anteriormente
                Paragraph paragraph = new Paragraph(linhaPhrase)
                {
                    Alignment = Element.ALIGN_CENTER
                };

                // Adiciona o parágrafo ao cabeçalho
                PdfPTable table = new PdfPTable(1)
                {
                    TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin
                };
                table.DefaultCell.Border = Rectangle.NO_BORDER;
                table.AddCell(paragraph);
                table.WriteSelectedRows(0, -1, document.LeftMargin, document.PageSize.GetTop(document.TopMargin) + 10, writer.DirectContent);
            }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                Phrase Linha_Phrase = new Phrase
                {
                    new Chunk(image, 25, 25),
                    new Chunk("este é um PDF gerado por", font)
                };

                Anchor link_chateau = new Anchor(" chateaudupet.azurewebsites.net", font)
                {
                    Reference = "chateaudupet.azurewebsites.net"
                };
                Linha_Phrase.Add(link_chateau);
                Linha_Phrase.Add("\r\n");
                Linha_Phrase.Add(new Chunk("Para encontrar esse cliente basta buscar o usuario " + usuario + " em nosso site.", font));
                // Criar o texto a ser adicionado no rodapé
                Paragraph Paragraph = new Paragraph(Linha_Phrase)
                {
                    Alignment = Element.ALIGN_CENTER
                };

                // Adicionar o texto no rodapé
                PdfPTable table = new PdfPTable(1)
                {
                    TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin
                };
                table.DefaultCell.Border = Rectangle.TOP_BORDER;
                table.DefaultCell.BorderColorTop = BaseColor.LIGHT_GRAY;
                table.AddCell(Paragraph);
                table.WriteSelectedRows(0, -1, document.LeftMargin, table.TotalHeight + document.BottomMargin, writer.DirectContent);
            }
        }
        public void Gerando_PDF(ProfissionalDTO ProfissionalDTO, List<RedesocialDTO> Lista_Redes, List<CertificadoDTO> Lista_Certificado, List<ExperienciaDTO> Lista_Experiencia)
        {

            // Configura a resposta HTTP para exibir o arquivo PDF no navegador
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "inline;filename=arquivo.pdf");

            // Cria um novo documento PDF em memória
            Document document = new Document(PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, Response.OutputStream);
            document.Open();

            // adicionar o cabeçalho e o rodapé ao documento
            string Caminho_Server = Server.MapPath(@"../../imagens/objetos-empresa/");
            Image imagem_Logo = Image.GetInstance(Caminho_Server + "Logo-black.png");

            HeaderFooter headerFooter = new HeaderFooter(ProfissionalDTO.UsuarioCl, imagem_Logo);
            writer.PageEvent = headerFooter;

            // Definir a família de fontes
            string fontName = "Geo Sans Light";

            // Criar a fonte para o título
            Font Font_Titulo = new Font(FontFactory.GetFont(fontName, 12, Font.BOLD, BaseColor.BLACK));


            // Criar a fonte para a descrição
            Font Font_Descricao = new Font(FontFactory.GetFont(fontName, 12, Font.NORMAL, BaseColor.BLACK));



            //inserindo linha Nome
            Paragraph paragraph_Cliente = new Paragraph(ProfissionalDTO.PrimeiroNomeCl+ " " + ProfissionalDTO.SobrenomeCl, new Font(FontFactory.GetFont(fontName, 15, Font.BOLD, BaseColor.BLACK)))
            {
                Alignment = Element.ALIGN_CENTER,
                // Define um espaço antes de 10 pontos// superior 
                // paragraph_Cliente.SpacingBefore = 10f;
                // Define um espaço depois de 20 pontos /inferior
                SpacingAfter = 10f
            };
            document.Add(paragraph_Cliente);


            //linha Contato
            Phrase Linha_Contato = new Phrase
            {
                new Chunk("Email: ", Font_Titulo),
                new Chunk(ProfissionalDTO.EmailCl + "  ", Font_Descricao),
                new Chunk("Telefone: ", Font_Titulo),
                new Chunk(ProfissionalDTO.NumeroTelefoneCl + " ", Font_Descricao)
            };
            Paragraph paragraph_contact = new Paragraph(Linha_Contato)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 5f
            };

            document.Add(paragraph_contact);

            // Linha Perfil
            Phrase Linha_perfil = new Phrase
            {
                new Chunk("Formacao Escolar: ", Font_Titulo),
                new Chunk(ProfissionalDTO.FormacaoEscolarPf + "  ", Font_Descricao),
                new Chunk("Data de Nascimento: ", Font_Titulo),
                new Chunk(ProfissionalDTO.DataNascimentoCl.ToString("dd/MM/yyyy") + "  ", Font_Descricao),
                new Chunk("Sexo: ", Font_Titulo),
                new Chunk(ProfissionalDTO.SexoCl + "  ", Font_Descricao)
            };
            Paragraph paragraph_perfi = new Paragraph(Linha_perfil)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 5f
            };
            document.Add(paragraph_perfi);

            /// linha endereco
            Phrase Linha_Endereco = new Phrase
            {
                new Chunk("Rua: ", Font_Titulo),
                new Chunk(ProfissionalDTO.DescricaoRuaCl + "  ", Font_Descricao),
                new Chunk("Bairro: ", Font_Titulo),
                new Chunk(ProfissionalDTO.DescricaoBairroCl + "  ", Font_Descricao),
                new Chunk("Cidade: ", Font_Titulo),
                new Chunk(ProfissionalDTO.DescricaoCidadeCl + "  ", Font_Descricao),
                new Chunk("UF: ", Font_Titulo),
                new Chunk(ProfissionalDTO.DescricaoEstadoCl + "  ", Font_Descricao),
                new Chunk("CEP: ", Font_Titulo),
                new Chunk(ProfissionalDTO.NumeroCepCl + "  ", Font_Descricao)
            };
            Paragraph paragraph_Endereco = new Paragraph(Linha_Endereco)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 5f
            };

            document.Add(paragraph_Endereco);


            //criando os conteudo em um container  para inserir no paragraph
            Phrase Linha_RedeSociais = new Phrase();

            foreach (RedesocialDTO item_list in Lista_Redes)
            {
                string Lbl_Linkedin = item_list.LinkRedeRs.Replace("https://www.linkedin.com/in/", "");

                if (item_list.DescricaoRedeRs == "URL Linkedin"&& Lbl_Linkedin != "")
                {
                    Image imagem = Image.GetInstance(Caminho_Server + "Linkedin.png");
                    Linha_RedeSociais.Add(new Chunk(imagem, 0, 0));
                    Anchor link = new Anchor(Lbl_Linkedin, new Font(FontFactory.GetFont(fontName, 12, Font.UNDERLINE, BaseColor.BLACK)))
                    {
                        Reference = item_list.LinkRedeRs
                    };
                    Linha_RedeSociais.Add("  ");
                    Linha_RedeSociais.Add(link);
                    Linha_RedeSociais.Add("  ");


                }
                string Lbl_Instagram = item_list.LinkRedeRs.Replace("https://www.instagram.com/", "");

                if (item_list.DescricaoRedeRs == "URL Instagram" && Lbl_Instagram != "")
                {
                    Image imagem = Image.GetInstance(Caminho_Server + "instagram.png");
                    Linha_RedeSociais.Add(new Chunk(imagem, 0, 0));

                    Anchor link = new Anchor(Lbl_Instagram, new Font(FontFactory.GetFont(fontName, 12, Font.UNDERLINE, BaseColor.BLACK)))
                    {
                        Reference = item_list.LinkRedeRs
                    };

                    Linha_RedeSociais.Add("  ");
                    Linha_RedeSociais.Add(link);
                    Linha_RedeSociais.Add("  ");


                }
                string Lbl_Whatsapp = item_list.LinkRedeRs.Replace("https://wa.me/", "");

                if (item_list.DescricaoRedeRs == "URL Whatsapp" && Lbl_Whatsapp != "")
                {
                    Image imagem = Image.GetInstance(Caminho_Server + "Whatsapp.png");
                    Linha_RedeSociais.Add(new Chunk(imagem, 0, 0));

                    //add um hiperlink com text & font 
                    Anchor link = new Anchor(Lbl_Whatsapp, new Font(FontFactory.GetFont(fontName, 12, Font.UNDERLINE, BaseColor.BLACK)))
                    {
                        ///add url no acho
                        Reference = item_list.LinkRedeRs
                    };
                    //add link na linha
                    Linha_RedeSociais.Add("  ");
                    Linha_RedeSociais.Add(link);
                    Linha_RedeSociais.Add("  ");

                }
            }
            // add phrase no paragraph 
            Paragraph paragraph_redesociais = new Paragraph(Linha_RedeSociais)
            {
                //centralizando paragraph
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 10f
            };
            document.Add(paragraph_redesociais);

            Phrase Phrase_Biografia = new Phrase
            {
                new Chunk("Biografia: ", Font_Titulo),
                new Chunk(ProfissionalDTO.BiografiaCl.Replace("\r\n", " "), Font_Descricao)
            };
            Paragraph Paragraph_Biografia = new Paragraph(Phrase_Biografia)
            {
                SpacingAfter = 10f
            };
            document.Add(Paragraph_Biografia);


            Paragraph paragraph_Formacao = new Paragraph("Formação Profissional", Font_Titulo)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 10f
            };
            document.Add(paragraph_Formacao);

            foreach (CertificadoDTO Item_Certificado in Lista_Certificado)
            {
                // Criar uma tabela com 2 colunas
                PdfPTable table = new PdfPTable(2)
                {
                    WidthPercentage = 100
                };

                Phrase Linha_Certificado = new Phrase
                {
                    new Chunk("Curso: ", Font_Titulo),
                    new Chunk(Item_Certificado.NomeCursoCf + "  ", Font_Descricao)
                };
                // Adicionar as informações do certificado na tabela
                PdfPCell cell1 = new PdfPCell(Linha_Certificado)
                {
                    Border = 0
                };
                Phrase Linha_Certificado_right = new Phrase
                {
                    new Chunk("Instituicão: ", Font_Titulo),
                    new Chunk(Item_Certificado.NomeInstituicaoCf + "  ", Font_Descricao)
                };
                PdfPCell cell2 = new PdfPCell(Linha_Certificado_right)
                {
                    Border = 0
                };
                table.AddCell(cell1);
                table.AddCell(cell2);
                document.Add(table);
                // Criar uma tabela com 2 colunas
                PdfPTable table_Date = new PdfPTable(2)
                {
                    WidthPercentage = 100
                };
                Phrase Linha_Certificado_date = new Phrase
                {
                    new Chunk("Iniciou: ", Font_Titulo),
                    new Chunk(Item_Certificado.DateInicioCf.ToString("MM/yyyy") + "  ", Font_Descricao)
                };
                // Adicionar as informações do certificado na tabela
                PdfPCell cell1_date = new PdfPCell(Linha_Certificado_date)
                {
                    //definindo tamanho da borda
                    Border = 0
                };
                Phrase Linha_CertificadoDate_right = new Phrase
                {
                    new Chunk("Finalizou: ", Font_Titulo),
                    new Chunk(Item_Certificado.DateFinalizouCf.ToString("MM/yyyy") + "  ", Font_Descricao)
                };
                // Adicionar a Phrase na celula
                PdfPCell cell2_date = new PdfPCell(Linha_CertificadoDate_right)
                {
                    Border = 0
                };
                // Adicionar a celula no table
                table_Date.AddCell(cell1_date);
                table_Date.AddCell(cell2_date);
                // Adicionar a tabela no documento
                document.Add(table_Date);

                Phrase Phrase_Formacao = new Phrase
                {
                    new Chunk("Descricão: ", Font_Titulo),
                    new Chunk(Item_Certificado.DescricaoCf.Replace("\r\n", " "), Font_Descricao)
                };
                Paragraph Paragraph_Formacao_titulo = new Paragraph(Phrase_Formacao)
                {
                    SpacingAfter = 10f
                };
                document.Add(Paragraph_Formacao_titulo);
            }


            Paragraph paragraph_Experiencia = new Paragraph("Experiencia Profissional", Font_Titulo)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 10f
            };

            document.Add(paragraph_Experiencia);

            foreach (ExperienciaDTO Item_lista in Lista_Experiencia)
            {

                // Criar uma tabela com 2 colunas
                PdfPTable table_1 = new PdfPTable(2)
                {
                    WidthPercentage = 100
                };

                Phrase Linha_Coluna1 = new Phrase
                {
                    new Chunk("Empresa: ", Font_Titulo),
                    new Chunk(Item_lista.NomeEmpresaEx + "  ", Font_Descricao)
                };
                // Adicionar as informações do certificado na tabela
                PdfPCell celula1 = new PdfPCell(Linha_Coluna1)
                {
                    Border = 0
                };
                Phrase Linha_coluna2 = new Phrase
                {
                    new Chunk("Cargo: ", Font_Titulo),
                    new Chunk(Item_lista.NomeCargoEx + "  ", Font_Descricao)
                };
                PdfPCell celula2 = new PdfPCell(Linha_coluna2)
                {
                    Border = 0
                };
                table_1.AddCell(celula1);
                table_1.AddCell(celula2);
                document.Add(table_1);

                // Criar uma tabela com 2 colunas/
                PdfPTable table_2 = new PdfPTable(2)
                {
                    WidthPercentage = 100
                };

                Phrase Linha_coluna_date = new Phrase
                {
                    new Chunk("Iniciou: ", Font_Titulo),
                    new Chunk(Item_lista.DateInicioEx.ToString("MM/yyyy") + "  ", Font_Descricao)
                };
                // Adicionar as informações do certificado na tabela
                PdfPCell cell1_date = new PdfPCell(Linha_coluna_date)
                {
                    //definindo tamanho da borda
                    Border = 0
                };
                Phrase Linha_coluna_date_right = new Phrase
                {
                    new Chunk("Finalizou: ", Font_Titulo),
                    new Chunk(Item_lista.DateFinalizouEx.ToString("MM/yyyy") + "  ", Font_Descricao)
                };

                // Adicionar a Phrase na celula
                PdfPCell cell2_date = new PdfPCell(Linha_coluna_date_right)
                {
                    Border = 0
                };

                // Adicionar a celula no table
                table_2.AddCell(cell1_date);
                table_2.AddCell(cell2_date);
                // Adicionar a tabela no documento

                document.Add(table_2);
                Phrase Phrase_Experiencia = new Phrase
                {
                    new Chunk("Descricão: ", Font_Titulo),
                    new Chunk(Item_lista.DescricaoEx.Replace("\r\n", " "), Font_Descricao)
                };
                Paragraph Paragraph_Experiencia = new Paragraph(Phrase_Experiencia)
                {
                    SpacingAfter = 10f
                };
                document.Add(Paragraph_Experiencia);

            }

            // Definir o alinhamento do parágrafo como centralizado
            //paragrapho Contato

            // Adiciona um parágrafo de exemplo ao documento

            // Finaliza o documento e envia a resposta ao navegador
            document.Close();
            writer.Close();
            Response.End();

        }
      

    }
}