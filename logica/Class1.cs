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
                Console.WriteLine("\nLISTA DE LIVROS:");
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
                    Console.WriteLine("ID não encontrado.");
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
                        Console.WriteLine($"O livro '{livro.Titulo}' foi devolvido.");
                    }
                    else Console.WriteLine("Este livro já está na biblioteca.");
                }
                else Console.WriteLine("ID não encontrado.");
            }

            public void EmprestarLivro(int id)
            {
                var livro = _livros.FirstOrDefault(l => l