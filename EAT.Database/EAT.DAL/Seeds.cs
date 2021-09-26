using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using EAT.Models.Entities;

namespace EAT.DAL
{
    public static class Seeds
    {
        public static void Seed(this EatContext context)
        {
            try
            {
                if (!context.TipoDeUsuario.Any())
                {
                    var usuarios = new List<TipoDeUsuario>
                    {
                        new TipoDeUsuario{ Funcao = "Administrador"},
                        new TipoDeUsuario{ Funcao = "Vendedor Local"},
                        new TipoDeUsuario{ Funcao = "Vendedor da Pagina"},
                    };
                    context.TipoDeUsuario.AddRange(usuarios);
                    context.SaveChanges();
                }
                if (!context.Funcionario.Any())
                {
                    var funcionarios = new List<Funcionario>
                    {
                        new Funcionario
                        {
                            Nome = "Idarcio",
                            Sobrenome = "Filipe",
                            Telefone = "947017787",
                            NomeDeUsuario = "admin",
                            SenhaDeUsuario = "admin",
                            TipoDeUsuarioId = 1
                        },
                        new Funcionario
                        {
                            Nome = "Eliseu",
                            Sobrenome = "Itombe",
                            Telefone = "932435654",
                            NomeDeUsuario = "admin",
                            SenhaDeUsuario = "admin",
                            TipoDeUsuarioId = 1
                        },
                        new Funcionario
                        {
                            Nome = "Rosana",
                            Sobrenome = "Sambo",
                            Telefone = "923456789",
                            NomeDeUsuario = "r",
                            SenhaDeUsuario = "r",
                            TipoDeUsuarioId = 2
                        },
                        new Funcionario
                        {
                            Nome = "Natacha",
                            Sobrenome = "Maneta",
                            Telefone = "990123321",
                            NomeDeUsuario = "n",
                            SenhaDeUsuario = "n",
                            TipoDeUsuarioId = 3
                        }
                    };
                    context.Funcionario.AddRange(funcionarios);
                    context.SaveChanges();
                }
                if (!context.Estado.Any())
                {
                    var estados = new List<Estado>
                    {
                        new Estado {Nome = "Novo*"},
                        new Estado {Nome = "Pedido Aberto"},
                        new Estado {Nome = "Pedido Cancelado"},
                        new Estado {Nome = "Pedido Finalizado"},
                    };
                    context.Estado.AddRange(estados);
                    context.SaveChanges();
                }
                if (!context.Categoria.Any())
                {
                    var categoria = new List<Categoria>
                    {
                        new Categoria {Descricao = "Doces"},
                        new Categoria {Descricao = "Salgados"},
                        new Categoria {Descricao = "Refeições"},
                        new Categoria {Descricao = "Bolos"},
                        new Categoria {Descricao = "Bebidas"},
                        new Categoria {Descricao = "Pizzas"},
                        new Categoria {Descricao = "Tortas"}
                    };
                    context.Categoria.AddRange(categoria);
                    context.SaveChanges();
                }
                if (!context.Produto.Any())
                {
                    var produtos = new List<Produto>
                    {
                        new Produto{Descricao = "Chocobol", CategoriaId = 1, Preco = 2000},
                        new Produto{Descricao = "Torta de Coco", CategoriaId = 7, Preco = 2000}
                    };
                    context.Produto.AddRange(produtos);
                    context.SaveChanges();
                }
                if (!context.Morada.Any())
                {
                    var moradas = new List<Morada>();
                    var blocos = new[] { "A", "B", "C", "D" };
                    var portas = new[] { 101, 102, 103, 104, 201, 202, 203, 204, 301, 302, 303, 304 };
                    foreach (var bloco in blocos)
                    {
                        for (var edifico = 1; edifico <= 36; edifico++)
                        {
                            moradas.AddRange(portas.Select(porta =>
                                new Morada
                                {
                                    Bloco = bloco,
                                    NumeroDaPorta = porta,
                                    Edificio = edifico
                                }));
                        }
                    }

                    context.Morada.AddRange(moradas);
                    context.SaveChanges();
                }
                if (!context.Cliente.Any())
                {
                    var clientes = new List<Cliente>
                    {
                        new Cliente
                        {
                            Nome = "Indira",
                            Sobrenome = "Lubota",
                            Telefone = "945676532",
                            MoradaId = 30,
                            Email = "lubota2017@gmail.com"
                        },
                        new Cliente
                        {
                            Nome = "Maira",
                            Sobrenome = "Gime",
                            Telefone = "995654321",
                            MoradaId = 29,
                            Email = "mairaGime@gmail.com"
                        },
                        new Cliente
                        {
                            Nome = "Paulo",
                            Sobrenome = "Ngombota",
                            Telefone = "945678123",
                            MoradaId = 23,
                            Email = "paulo291@live.com"
                        },
                        new Cliente
                        {
                            Nome = "Enock",
                            Sobrenome = "Palmerin",
                            Telefone = "945687123",
                            MoradaId = 24
                        },
                        new Cliente
                        {
                            Nome = "Jacira",
                            Sobrenome = "Borges",
                            Telefone = "945005456",
                            MoradaId = 27
                        },
                        new Cliente
                        {
                            Nome = "Gilson",
                            Sobrenome = "Ferreira",
                            Telefone = "94567890",
                            MoradaId = 15,
                            Email = "Gilson@gmail.com"
                        },
                        new Cliente
                        {
                            Nome = "Osvaldo",
                            Sobrenome = "Belo",
                            Telefone = "925678971",
                            MoradaId = 10,
                            Email = "houby@hotmail.com"
                        },
                        new Cliente
                        {
                            Nome = "Gabriel",
                            Sobrenome = "Barros",
                            Telefone = "93356487",
                            MoradaId = 13,
                            Email = "Gbaroos20@gmail.com"
                        },
                        new Cliente
                        {
                            Nome = "Nayara",
                            Sobrenome = "Mateus",
                            Telefone = "990897456",
                            MoradaId = 20
                        },
                        new Cliente
                        {
                            Nome = "Angelina",
                            Sobrenome = "Luis",
                            Telefone = "996541112",
                            MoradaId = 2
                        },
                        new Cliente
                        {
                            Nome = "Filomena",
                            Sobrenome = "Oliveira",
                            Telefone = "929910883",
                            MoradaId = 1
                        },
                        new Cliente
                        {
                            Nome = "Fortunato",
                            Sobrenome = "Filipe",
                            Telefone = "932636310",
                            MoradaId = 5
                        },
                        new Cliente
                        {
                            Nome = "Karina",
                            Sobrenome = "Cardoso",
                            Telefone = "927876543",
                            MoradaId = 30
                        },
                        new Cliente
                        {
                            Nome = "Joana",
                            Sobrenome = "Muanda",
                            Telefone = "932123876",
                            MoradaId = 10
                        },
                        new Cliente
                        {
                            Nome = "Admilton",
                            Sobrenome = "Dos Anjos",
                            Telefone = "943887902",
                            MoradaId = 9
                        },
                        new Cliente
                        {
                            Nome = "Samara",
                            Sobrenome = "Joseph",
                            Telefone = "924345768",
                            MoradaId = 13
                        },
                        new Cliente
                        {
                            Nome = "Angelina",
                            Sobrenome = "Luis",
                            Telefone = "947654123",
                            MoradaId = 15
                        },
                        new Cliente
                        {
                            Nome = "Belucha",
                            Sobrenome = "Silvestre",
                            Telefone = "925345651",
                            MoradaId = 18
                        }
                    };
                    context.Cliente.AddRange(clientes);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Falha na conexão com o Servidor: {ex} ");
            }
        }
    }
}