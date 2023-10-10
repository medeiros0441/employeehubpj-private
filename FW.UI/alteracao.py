import os
import re

# Função para encontrar e listar os atributos href e src em um arquivo
def find_href_src_attributes(file_path):
    try:
        with open(file_path, 'r', encoding='utf-8') as file:
            lines = file.readlines()
        
        # Expressão regular para encontrar atributos href e src com valores
        href_src_pattern = re.compile(r'(href|src)="([^"]+)"', re.IGNORECASE)

        # Lista para armazenar resultados
        results = []

        for line_number, line in enumerate(lines, start=1):
            matches = href_src_pattern.findall(line)
            if matches:
                for match in matches:
                    attribute, value = match
                    results.append((file_path, line_number, attribute, value))
        
        return results
    except Exception as e:
        print(f"Erro ao processar o arquivo {file_path}: {e}")
        return []

# Diretório da pasta "Pages" com os arquivos ASPX e ASPX.CS
pages_directory = 'C:/Users/medei/source/repos/project/FW.UI/pages'

# Lista para armazenar todos os resultados
all_results = []

# Percorre todos os arquivos na pasta "Pages" e suas subpastas
for root, dirs, files in os.walk(pages_directory):
    for file in files:
        # Verifica se o arquivo é um ASPX ou ASPX.CS
        if file.endswith('.aspx') or file.endswith('.aspx.cs'):
            file_path = os.path.join(root, file)
            results = find_href_src_attributes(file_path)
            all_results.extend(results)

# Imprime os resultados em forma de tabela
print("{:<50} {:<10} {:<10} {:<10}".format("Arquivo", "Linha", "Atributo", "Valor"))
print("-" * 80)

for result in all_results:
    file_path, line_number, attribute, value = result
    print("{:<50} {:<10} {:<10} {:<10}".format(file_path, line_number, attribute, value))
