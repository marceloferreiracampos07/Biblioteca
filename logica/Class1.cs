using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using static Logica.Program;

namespace Logica
{
    class Program
    {
        public class Livro
        {
            private static int _proximoid = 1;
            private string _titulo;
            private string _autor;
           
            public int id {  get; private set; }
            public string titulo { get { return _titulo; } set {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        Console.WriteLine("o titulo do livro nao deve ser vazio");
                        
                    } else
                    {
                        _titulo = value;
                    }
                } }
            public string autor { get { return _autor; } set {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        Console.WriteLine("o nome do autor nao deve ser vazio ");
                    }
                    else
                    {
                        _autor = value;
                    }
                } }
            public bool EstaDisponivel { get; set; } = true;
            public string StatusTexto => EstaDisponivel ? "O livro está disponível" : "O livro está emprestado";

            public Livro(string titulo , string autor,bool EstaDisponivel = true )
            {

                this.id = _proximoid++;
                this.titulo = titulo;
                this.autor = autor;
                this.EstaDisponivel= EstaDisponivel;
            }
        }
        public class Biblioteca
        {
            private List<Livro> _livro;

            public Biblioteca()
            {
                _livro = new List<Livro>();
            }
            public void adicionarlivro(Livro livro)
            {
                if (livro == null)
                {
                    Console.WriteLine("nao é possivel adicionar um livro nulo");
                    return;
                }
                if (_livro.Any(l => l.id == livro.id))
                {
                    Console.WriteLine($"ja existe um livro com esse id {livro.id}");
                }
                _livro.Add(livro);
                Console.WriteLine($"livro do titulo{livro.titulo} do id {livro.id} adicionado com sucesso");
            }
            public void listarTodoslivros()
            {
                if (_livro.Count == 0)
                {
                    Console.WriteLine("a biblioteca esta vazia no momento");
                    return;
                }
                Console.WriteLine("LISTA DE LIVROS ");
                foreach (var livro in _livro)
                {
                    Console.WriteLine($"ID : {livro.id} | TITULO : {livro.titulo} | AUTOR: {livro.autor}|STATUS: {livro.StatusTexto} |");
                }
            }
            public void Removerlivro( int id)
            {
                for (int i = 0; i < _livro.Count; i++)
                {
                    if (_livro[i].id == id )
                    {
                        _livro.RemoveAt(i);
                        Console.WriteLine("livro removido com sucesso ");
                        return;

                    }
                }
            }
            public void devolver(int id)
            {
                var livroencontrado = _livro.Find(l => l.id == id);

               
                if (livroencontrado != null)
                {
                    
                    if (livroencontrado.EstaDisponivel == false)
                    {
                        livroencontrado.EstaDisponivel = true;
                        Console.WriteLine($"Sucesso O livro '{livroencontrado.titulo}' foi devolvido.");
                    }
                    else
                    {
                      
                        Console.WriteLine("Este livro já está na biblioteca.");
                    }
                }
                else
                {
                  
                    Console.WriteLine(" ID não encontrado no sistema.");
                }
            }
            public void EmprestarLivro(int id)
            {
             
                var livroemprestado = _livro.Find(l => l.id == id);

                
                if (livroemprestado != null)
                {
                   
                    if (livroemprestado.EstaDisponivel == true)
                    {
                        livroemprestado.EstaDisponivel = false;
                        Console.WriteLine($"Sucesso! O livro '{livroemprestado.titulo}' foi emprestado.");
                    }
                    else
                    {
                        Console.WriteLine("Este livro já está com outra pessoa.");
                    }
                }
                else
                {
                   
                    Console.WriteLine("Erro: ID não encontrado no sistema.");
                }
            }
        }

   
        public Program()
        {
            
        }
        public static void Main(string[] args)
        {
            Biblioteca minhabiblioteca = new Biblioteca();
           
            int opcao = -1;

            
            while (opcao != 6)
            {
                Console.WriteLine("\n============ BIBLIOTECA ===========");
                Console.WriteLine("""
    1- ADICIONAR LIVRO
    2- REMOVER LIVRO 
    3- LISTAR LIVROS 
    4- DEVOLVER LIVRO 
    5- EMPRESTAR LIVRO 
    6- SAIR
    """);
                Console.WriteLine("escolha a opçao :");

                
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Console.Write("Título: ");
                        string t = Console.ReadLine();

                        Console.Write("Autor: ");
                        string a = Console.ReadLine();

                        
                        Console.Write("O livro está disponível agora? (s/n): ");
                        string resposta = Console.ReadLine().ToLower();
                        bool disponivel = (resposta == "s"); 

                       
                        Livro novo = new Livro(t, a, disponivel);
                        minhabiblioteca.adicionarlivro(novo);
                        break;
                    case 2:
                        Console.Write("Digite o ID do livro para remover: ");
                        int idRemover = int.Parse(Console.ReadLine());
                        minhabiblioteca.Removerlivro(idRemover);
                        break;

                    case 3:
                        minhabiblioteca.listarTodoslivros();
                        break;

                    case 4:
                        Console.Write("Digite o ID do livro para devolver: ");
                        int idDevolver = int.Parse(Console.ReadLine());
                        minhabiblioteca.devolver(idDevolver);
                        break;

                    case 5:
                        Console.Write("Digite o ID do livro para emprestar: ");
                        int idEmprestar = int.Parse(Console.ReadLine());
                        minhabiblioteca.EmprestarLivro(idEmprestar);
                        break;

                    case 6:
                        Console.WriteLine("Encerrando o sistema...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }


        }
    }
}
