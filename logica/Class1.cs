using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    class Program
    {
        public class Livro
        {
            private static int _proximoId = 1;
            private string _titulo;
            private string _autor;

            public int Id { get; private set; }

            public string Titulo
            {
                get => _titulo;
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("O título não pode ser vazio.");
                    _titulo = value;
                }
            }

            public string Autor
            {
                get => _autor;
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("O nome do autor não pode ser vazio.");
                    _autor = value;
                }
            }

            public bool EstaDisponivel { get; set; } = true;
            public string StatusTexto => EstaDisponivel ? "O livro está disponível" : "O livro está emprestado";

            public Livro(string titulo, string autor, bool estaDisponivel = true)
            {
                Id = _proximoId++;
                Titulo = titulo;
                Autor = autor;
                EstaDisponivel = estaDisponivel;
            }
        }

        public class Biblioteca
        {
            private List<Livro> _livros;

            public Biblioteca()
            {
                _livros = new List<Livro>();
            }

            public void AdicionarLivro(Livro livro)
            {
                if (livro == null) return;
                _livros.Add(livro);
                Console.WriteLine($"Livro '{livro.Titulo}' (ID: {livro.Id}) adicionado com sucesso.");
            }

            public void ListarTodosLivros()
            {
                if (!_livros.Any())
                {
                    Console.WriteLine("A biblioteca está vazia.");
                    return;
                }
                Console.WriteLine("\n--- LISTA DE LIVROS ---");
                foreach (var livro in _livros)
                {
                    Console.WriteLine($"ID: {livro.Id} | Título: {livro.Titulo} | Autor: {livro.Autor} | Status: {livro.StatusTexto}");
                }
            }

            public void RemoverLivro(int id)
            {
                var livro = _livros.FirstOrDefault(l => l.Id == id);
                if (livro != null)
                {
                    _livros.Remove(livro);
                    Console.WriteLine("Livro removido com sucesso.");
                }
                else
                {
                    Console.WriteLine("Erro: ID não encontrado.");
                }
            }

            public void Devolver(int id)
            {
                var livro = _livros.FirstOrDefault(l => l.Id == id);
                if (livro != null)
                {
                    if (!livro.EstaDisponivel)
                    {
                        livro.EstaDisponivel = true;
                        Console.WriteLine($"Sucesso: O livro '{livro.Titulo}' foi devolvido.");
                    }
                    else Console.WriteLine("Aviso: Este livro já está na biblioteca.");
                }
                else Console.WriteLine("Erro: ID não encontrado.");
            }

            public void EmprestarLivro(int id)
            {
                var livro = _livros.FirstOrDefault(l => l.Id == id);
                if (livro != null)
                {
                    if (livro.EstaDisponivel)
                    {
                        livro.EstaDisponivel = false;
                        Console.WriteLine($"Sucesso: O livro '{livro.Titulo}' foi emprestado.");
                    }
                    else Console.WriteLine("Aviso: Este livro já está emprestado.");
                }
                else Console.WriteLine("Erro: ID não encontrado.");
            }
        }

        public static void Main(string[] args)
        {
            Biblioteca minhaBiblioteca = new Biblioteca();
            int opcao = -1;

            while (opcao != 6)
            {
                Console.WriteLine("\n============ SISTEMA BIBLIOTECA ===========");
                Console.WriteLine("1- ADICIONAR LIVRO");
                Console.WriteLine("2- REMOVER LIVRO");
                Console.WriteLine("3- LISTAR LIVROS");
                Console.WriteLine("4- DEVOLVER LIVRO");
                Console.WriteLine("5- EMPRESTAR LIVRO");
                Console.WriteLine("6- SAIR");
                Console.Write("Escolha a opção: ");

                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Por favor, digite um número válido.");
                    continue;
                }

                try
                {
                    switch (opcao)
                    {
                        case 1:
                            Console.Write("Título: ");
                            string t = Console.ReadLine();
                            Console.Write("Autor: ");
                            string a = Console.ReadLine();
                            Console.Write("Disponível agora? (s/n): ");
                            bool disp = Console.ReadLine().ToLower() == "s";

                           
                            minhaBiblioteca.AdicionarLivro(new Livro(t, a, disp));
                            break;

                        case 2:
                            Console.Write("Digite o ID para remover: ");
                            if (int.TryParse(Console.ReadLine(), out int idR))
                                minhaBiblioteca.RemoverLivro(idR);
                            break;

                        case 3:
                            minhaBiblioteca.ListarTodosLivros();
                            break;

                        case 4:
                            Console.Write("Digite o ID para devolver: ");
                            if (int.TryParse(Console.ReadLine(), out int idD))
                                minhaBiblioteca.Devolver(idD);
                            break;

                        case 5:
                            Console.Write("Digite o ID para emprestar: ");
                            if (int.TryParse(Console.ReadLine(), out int idE))
                                minhaBiblioteca.EmprestarLivro(idE);
                            break;

                        case 6:
                            Console.WriteLine("Saindo...");
                            break;

                        default:
                            Console.WriteLine("Opção inválida!");
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    
                    Console.WriteLine($"\n[ERRO DE VALIDAÇÃO]: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n[ERRO INESPERADO]: {ex.Message}");
                }
            }
        }
    }
}