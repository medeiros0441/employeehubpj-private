Employee Hub PJ - Software de Gestão de Vagas

Bem-vindo ao Employee Hub PJ, um software web desenvolvido em .NET 4.8 utilizando WebForms. Este sistema oferece funcionalidades abrangentes para gerenciamento de vagas, destinado a dois tipos de usuários: empresas e profissionais.
Funcionalidades Principais
Para Empresas

    Criação e publicação de vagas disponíveis.
    Busca por profissionais e análise de seus currículos gerados por meio do C# com o auxílio de bibliotecas como iTextSharp para a geração de PDFs.
    Edição e cadastro de perfis de empresa para que os profissionais possam visualizar as vagas disponíveis.

Para Profissionais

    Geração de currículo em PDF ou armazenamento de um já existente.
    Criação, exclusão e edição de informações como experiências profissionais e certificações.
    Atualização do perfil e candidatura a vagas disponíveis.

Processo de Cadastro de Vagas

Oferecemos duas opções para o cadastro de vagas:

    Cadastro a partir do Login:
        Empresas podem cadastrar vagas de forma detalhada.

    Cadastro Simplificado:
        Profissionais inserem informações básicas como nome, e-mail e WhatsApp.
        O currículo é enviado mediante upload.
        A empresa recebe um e-mail com as informações do profissional que se candidatou.

Estrutura do Projeto

    BLL (Business Logic Layer): Responsável pela conexão com o DAL e pelas verificações.
    DTO (Data Transfer Object): Armazena os modelos.
    DAL (Data Access Layer): Responsável pela conexão com o banco de dados SQL Server, contendo todas as operações CRUD necessárias para o funcionamento do software.
    
Integrações Implementadas

    Cadastro e Login via Google:
        Facilitamos o acesso com a opção de registro e login utilizando contas do Google.

    Pagamento via Pix com Mercado Pago:
        Oferecemos a comodidade de realizar pagamentos através do Pix, integrado ao sistema de pagamento Mercado Pago. Especialmente para empresas que desejam adicionar saldo para consultar leads de profissionais.

Recursos Financeiros para Empresas

    Adição de Saldo para Consulta de Leads:
        Empresas têm a opção de adicionar saldo à sua conta para facilitar a consulta de perfis profissionais e aproveitar ao máximo as oportunidades disponíveis.

Recursos de Segurança

    Autenticação de E-mail:
        Reforçamos a segurança com a autenticação de e-mail durante o processo de registro.

    Atualização de Senha via E-mail:
        A recuperação de senha é simplificada com a opção de atualização via e-mail.

Personalização de Perfis

    Cadastro de Redes Sociais:
        Profissionais podem adicionar suas redes sociais aos perfis, proporcionando uma visão mais abrangente de suas habilidades e experiências.

Status Atual e Acesso ao Software

    Status de Implementação:
        O software foi desenvolvido ao longo de dois anos, refinando continuamente suas funcionalidades e aprimorando a experiência do usuário.

    Acesso Online:
        O Employee Hub PJ está publicado e acessível através da URL: employeehubpj.azurewebsites.net.
        
Por razões de segurança, apenas o front-end é visível. O back-end foi construído utilizando bibliotecas .NET Framework.

Sinta-se à vontade para explorar e melhorar a documentação do projeto conforme necessário. Estamos comprometidos com a qualidade e eficiência na gestão de vagas.
