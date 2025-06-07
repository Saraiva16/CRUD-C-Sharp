using System;
using System.Collections.Generic;

class Contato
{
  public int Id { get; set; }
  public string Nome { get; set; }
  public string Telefone { get; set; }
}

class Program
{
  static List<Contato> contatos = new List<Contato>();
  static int proximoId = 1;
  static void Main()
  {
    while (true)
    {
      Console.WriteLine("\n -- Menu de Contatos -- \n1. Criar contatos\n2. Listar contatos\n3. Atualizar contatos\n4. Deletar contatos\n5. Sair");
      Console.Write("Escolha uma opção: ");
      var opcao = Console.ReadLine();

      switch (opcao)
      {
        case "1": Criar(); break;
        case "2": Listar(); break;
        case "3": Atualizar(); break;
        case "4": Deletar(); break;
        case "5": return;
        default: Console.WriteLine("Opção inválida!"); break;
      }

    }
  }
  static void Criar()
  {
    Console.Write("Nome: ");
    string nome = Console.ReadLine();
    Console.Write("Telefone: ");
    string telefone = Console.ReadLine();

    contatos.Add(new Contato { Id = proximoId++, Nome = nome, Telefone = telefone });
    Console.WriteLine("Cadastro realizado com sucesso!");
  }

  static void Listar()
  {
    Console.WriteLine("\n -- Lista de contatos --");
    foreach (Contato c in contatos)
    {
      Console.WriteLine($"ID: {c.Id} | Nome: {c.Nome} | Telefone {c.Telefone}");
    }
  }

  static void Atualizar()
  {
    Console.Write("Digite o ID do contato que deseja atualizar: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
      var contato = contatos.Find(c => c.Id == id);
      if (contato == null)
      {
        Console.WriteLine("Contato não encontrado");
        return;
      }
      Console.Write("Novo nome (deixe em branco para manter): ");
      string nome = Console.ReadLine();
      if (!string.IsNullOrWhiteSpace(nome))
        contato.Nome = nome;

      Console.Write("Novo telefone (deixe em branco para manter): ");
      string telefone = Console.ReadLine();
      if (!string.IsNullOrWhiteSpace(telefone))
        contato.Telefone = telefone;

      Console.WriteLine("Contato atualizado!");
    }
  }
  static void Deletar()
  {
    Console.Write("Digite o ID do contato que deseja deletar: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
      var contato = contatos.Find(c => c.Id == id);
      if (contato == null)
      {
        Console.WriteLine("Contato não encontrado");
        return;
      }
      contatos.Remove(contato);
      Console.WriteLine("Contato removido com sucesso!");
    }
  }
}