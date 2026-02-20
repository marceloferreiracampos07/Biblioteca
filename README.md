
📚 Sistema de Gerenciamento de Biblioteca (Console)
Este é um projeto desenvolvido em C# para gerenciar o acervo de uma biblioteca através de uma interface de linha de comando. O foco principal foi o aprendizado de lógica de programação, manipulação de listas e Programação Orientada a Objetos.

🚀 Funcionalidades
O sistema oferece um menu interativo com as seguintes operações:

Adicionar Livro: Cadastra um novo livro com título e autor. O ID é gerado automaticamente.

Remover Livro: Remove um livro do sistema utilizando seu ID.

Listar Acervo: Exibe todos os livros cadastrados, mostrando ID, Título, Autor e Status (Disponível ou Emprestado).

Emprestar Livro: Altera o status do livro para "Indisponível". Possui validação para impedir o empréstimo de livros que já saíram.

Devolver Livro: Altera o status do livro para "Disponível". Possui validação para garantir que o livro estava realmente emprestado.

🛠️ Tecnologias e Conceitos Aplicados
Linguagem: C# (.NET)

Paradigma: Orientação a Objetos (Classes, Propriedades e Métodos).

Estrutura de Dados: Uso de List<T> para armazenamento em memória.

Expressões Lambda & LINQ: Utilização do método .Find() para buscas eficientes por ID.

Lógica de Fluxo: Uso de while, switch case e condicionais aninhadas (if/else) para controle de estado.

📂 Como o Código está Estruturado
Livro.cs: Define o modelo do objeto (Atributos: Id, Titulo, Autor, EstaDisponivel).

Biblioteca.cs: Classe responsável pela lógica de negócio (o repositório de livros).

Program.cs: Ponto de entrada que contém o menu de interação com o usuário.

💻 Exemplo de Uso
Ao iniciar o programa, o usuário se depara com o menu:

Plaintext
============ BIBLIOTECA ===========
1- ADICIONAR LIVRO
2- REMOVER LIVRO 
3- LISTAR LIVROS 
4- DEVOLVER LIVRO 
5- EMPRESTAR LIVRO 
6- SAIR
===================================
escolha a opçao :
