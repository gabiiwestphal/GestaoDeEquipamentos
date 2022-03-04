using System;

namespace GestaoDeEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //equipamento
            string[] nomesDosEquipamentos = new string[100];
            string[] precoDoEquipamento = new string[100];
            string[] numeroDeSerie = new string[100];
            DateTime[] dataDeFabricacao = new DateTime[100];
            string[] fabricante = new string[100];
            int countEquipamentos = 0;
            string opcao, opcaoEditar = "";
            string nomeDoEquipamento;

            //chamado
            string[] nomesDosChamados = new string[100];
            string[] descricoesDosChamados = new string[100];
            string[] equipamentosDosChamados = new string[100];
            DateTime[] datasAberturaChamados = new DateTime[100];
            DateTime[] datasChamadoAberto = new DateTime[100];
            int countChamados = 0;
            String opcaoChamado, opcaoEditarChamado = "";
            DateTime dataEquipamentos = DateTime.MinValue, dataChamados = DateTime.MinValue;

            do
            {
                nomeDoEquipamento = null;
                Console.Clear();
                Console.WriteLine("Selecione a opção desejada: ");
                Console.WriteLine("\n1.Registrar \n2.Visualizar Inventário \n3.Editar Inventário \n4.Excluir item  \n5.Chamada de Manutenção \n6.Sair\n");

                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":

                        do
                        {
                            Console.Clear();
                            Console.Write("Nome do Equipamento: ");
                            nomeDoEquipamento = Console.ReadLine();
                            if (nomeDoEquipamento.Length < 6)
                            {
                                Console.WriteLine("\nO nome deve ter pelo menos 6 caracteres. Tente novamente");
                                Console.ReadLine();
                            }
                        }
                        while (nomeDoEquipamento.Length < 6);

                        Console.Write("Preço do Equipamento: ");
                        precoDoEquipamento[countEquipamentos] = Console.ReadLine();

                        Console.Write("Número de série: ");
                        numeroDeSerie[countEquipamentos] = Console.ReadLine();

                        Console.Write("Data de fabricação: ");
                        dataDeFabricacao[countEquipamentos] = Convert.ToDateTime(Console.ReadLine());

                        Console.Write("Fabricante: ");
                        fabricante[countEquipamentos] = Console.ReadLine();

                        nomesDosEquipamentos[countEquipamentos] = nomeDoEquipamento;
                        countEquipamentos++;
                        break;

                    case "2":
                        Console.Clear();
                        if (countEquipamentos != 0)
                        {
                            for (int i = 0; i < countEquipamentos; i++)
                            {
                                if (numeroDeSerie[i] == null)
                                {
                                    Console.WriteLine("Item " + i + " Excluído");
                                    if (numeroDeSerie[i] != null)
                                        Console.WriteLine("Item " + i);
                                }
                                else
                                {
                                    Console.Write("\n\n" + (i + 1) + "° Equipamento registrado: ");
                                    Console.Write("\nNome do equipamento: " + nomesDosEquipamentos[i]);
                                    Console.Write("\nNumero de serie: " + numeroDeSerie[i]);
                                    Console.WriteLine("\nFabricante: " + fabricante[i]);
                                }
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nenhum item no inventário");
                            Console.ReadLine();
                        }
                        break;

                    case "3":
                        Console.Clear();
                        do
                        {
                            if (countEquipamentos != 0)
                            {
                                Console.WriteLine("Equipamentos resgistrados: ");
                                for (int i = 0; i < countEquipamentos; i++)
                                {
                                    if (nomesDosEquipamentos[i] == null)
                                    {
                                        Console.WriteLine("Item " + i + " Excluído");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Item " + i + ": " + nomesDosEquipamentos[i]);
                                    }
                                }
                                Console.ReadLine();
                                Console.WriteLine("\n\nDigite o número do item no inventário que deseja editar: ");
                                int i2 = int.Parse(Console.ReadLine());
                                Console.Clear();
                                if (nomesDosEquipamentos[i2] == null)
                                {
                                    Console.WriteLine("Este item foi excluído, não é possível editá-lo");
                                    Console.ReadLine();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Menu de Edição\n");
                                    Console.WriteLine("Digite o número do que deseja editar: \n");
                                    Console.WriteLine("\n1. Nome do equipamento \n2. Preço do equipamento \n3. Número de série");
                                    Console.WriteLine("4. Data da fabricação \n5. Fabricante \n6. voltar para o menu principal\n");
                                    opcaoEditar = Console.ReadLine();

                                    switch (opcaoEditar)
                                    {
                                        case "1":
                                            do
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Digite o novo nome: ");
                                                nomesDosEquipamentos[i2] = Console.ReadLine();
                                                if (nomesDosEquipamentos.Length < 6)
                                                {
                                                    Console.WriteLine("\nO nome deve ter pelo menos 6 caracteres. Tente novamente");
                                                    Console.ReadLine();
                                                }
                                            } while (nomesDosEquipamentos.Length < 6);
                                            opcaoEditar = "6";
                                            Console.Clear();
                                            break;
                                        case "2":
                                            Console.Clear();
                                            Console.WriteLine("Digite o novo preço: ");
                                            precoDoEquipamento[i2] = Console.ReadLine();
                                            opcaoEditar = "6";
                                            Console.Clear();
                                            break;
                                        case "3":
                                            Console.Clear();
                                            Console.WriteLine("Digite o novo Número de série: ");
                                            numeroDeSerie[i2] = Console.ReadLine();
                                            opcaoEditar = "6";
                                            Console.Clear();
                                            break;

                                        case "4":
                                            Console.Clear();
                                            Console.WriteLine("Digite a nova data de fabricação: ");
                                            dataDeFabricacao[i2] = Convert.ToDateTime(Console.ReadLine());
                                            opcaoEditar = "6";
                                            Console.Clear();
                                            break;
                                        case "5":
                                            Console.Clear();
                                            Console.WriteLine("Digite o novo fabricante: ");
                                            fabricante[i2] = Console.ReadLine();
                                            opcaoEditar = "6";
                                            Console.Clear();
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nNão há nenhum item para editar");
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                        } while (opcaoEditar != "6");
                        break;

                    case "4": // nao pode exluir equipamento que esta em um chamado 
                        if (countEquipamentos != 0)
                        {
                            Console.Clear();
                            for (int i = 0; i < countEquipamentos; i++)
                            {
                                Console.WriteLine(i + ": " + nomesDosEquipamentos[i]);

                            }
                            Console.WriteLine("Digite o número do item no inventário que deseja excluir: ");
                            int i2 = int.Parse(Console.ReadLine());

                            //if (nomesDosEquipamentos == equipamentosDosChamados)
                            // {
                            //   Console.WriteLine(" Equipamento não excluído, está vínculado a um chamado.");
                            // }

                            nomesDosEquipamentos[i2] = null;
                            numeroDeSerie[i2] = null;
                            fabricante[i2] = null;

                            Console.Clear();
                        }

                        break;

                    case "5":

                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("menu de chamados");
                            Console.WriteLine("\n1.Registrar Chamado\n2.Vizualizar Chamados\n3.Editar Chamado\n4.Excluir Chamado\n5.Voltar");
                            opcaoChamado = Console.ReadLine();
                            if (opcaoChamado == "5")
                            {
                                Console.Clear();
                                Console.WriteLine("\n\nPressione qualquer tecla para continuar");
                                Console.ReadLine();
                                break;
                            }

                            switch (opcaoChamado)
                            {
                                case "1":
                                    Console.Clear();
                                    Console.WriteLine("Título do Chamado: ");
                                    nomesDosChamados[countChamados] = Console.ReadLine();

                                    Console.Clear();
                                    Console.WriteLine("Descrição do Chamado: ");
                                    descricoesDosChamados[countChamados] = Console.ReadLine();

                                    Console.Clear();
                                    Console.WriteLine("Escolha um dos equipamento: ");
                                    for (int i = 0; i < countEquipamentos; i++)
                                    {                                                               
                                            Console.WriteLine("Item " + i + ": " + nomesDosEquipamentos[i]);                                      
                                    }

                                    int numeroEscolhido = int.Parse(Console.ReadLine());
                                    equipamentosDosChamados[countChamados] = nomesDosEquipamentos[numeroEscolhido];

                                    Console.Clear();
                                    Console.WriteLine("Data de Abertura: ");
                                    dataChamados = Convert.ToDateTime(Console.ReadLine());

                                    Console.WriteLine("Seu Chamado foi registrado com sucesso!\n\n");

                                    Console.ReadLine();
                                    Console.Clear();
                                    datasAberturaChamados[countChamados] = dataChamados;
                                    countChamados++;

                                    continue;

                                case "2":

                                    if (countChamados != 0)
                                    {
                                        for (int i = 0; i < countChamados; i++)
                                        {
                                            if (nomesDosChamados[i] == null)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("Chamada " + i + " excluída.");
                                                Console.ReadLine();
                                            }
                                            else
                                            {
                                                TimeSpan diasEmAberto = (DateTime.Now) - (datasAberturaChamados[i]);
                                                Console.Clear();
                                                Console.WriteLine("\n\n" + (i + 1) + "° Chamado resgistrado:");
                                                Console.WriteLine("\nTítulo do Chamado: " + nomesDosChamados[i]);
                                                Console.WriteLine("\nEquipamento: " + equipamentosDosChamados[i]);
                                                Console.WriteLine("\nData de Abertura: " + datasAberturaChamados[i].ToString("dd/MM/yyyy"));
                                                Console.WriteLine("\nDias decorridos: " + diasEmAberto.ToString("dd"));
                                                Console.ReadLine();
                                                Console.Clear();
                                                opcaoChamado = "5";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\nNenhum chamado registrado\n\n");
                                        Console.ReadLine();
                                    }
                                    Console.Clear();
                                    continue;

                                case "3":
                                    Console.Clear();
                                     if (countChamados != 0)
                                     {
                                        
                                        Console.WriteLine("Chamados resgistrados: ");
                                        for (int i = 0; i < countChamados; i++)
                                        {
                                            if (nomesDosChamados[i] == null)
                                            {
                                                Console.WriteLine("Chamado " + i + " Excluído");
                                            }
                                            else
                                            {
                                                Console.WriteLine(i + ": " + nomesDosChamados[i]);
                                            }
                                        }
                                        Console.WriteLine("\n\nDigite o número do chamado que deseja editar: ");
                                        int i3 = int.Parse(Console.ReadLine());
                                        Console.Clear();
                                        if (nomesDosChamados[i3] == null)
                                        {
                                            Console.WriteLine("Este chamado foi excluído, não é possível editá-lo");
                                            Console.ReadLine();
                                            break;
                                        }
                                        else
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Menu de Edição\n");
                                            Console.WriteLine("\n1. Editar Título do Chamado\n2. Editar Descrição do Chamado\n3. Editar Equipamento");
                                            Console.WriteLine("4. Editar Data de Abertura\n5. voltar para o menu de chamados\n");
                                            opcaoEditarChamado = Console.ReadLine();

                                            switch (opcaoEditarChamado)
                                            {
                                                case "1":
                                                    Console.Clear();
                                                    Console.WriteLine("Digite o novo Título: ");
                                                    nomesDosChamados[i3] = Console.ReadLine();
                                                    Console.ReadLine();
                                                    opcaoEditarChamado = "5";
                                                    Console.Clear();
                                                    continue;
                                                case "2":
                                                    Console.Clear();
                                                    Console.WriteLine("Digite a nova Descrição: ");
                                                    descricoesDosChamados[i3] = Console.ReadLine();
                                                    Console.ReadLine();
                                                    opcaoEditarChamado = "5";
                                                    Console.Clear();
                                                    continue;
                                                case "3":
                                                    Console.Clear();
                                                    Console.WriteLine("Digite o novo Equipamento: ");
                                                    equipamentosDosChamados[i3] = Console.ReadLine();
                                                    Console.ReadLine();
                                                    opcaoEditarChamado = "5";
                                                    Console.Clear();
                                                    continue;
                                                case "4":

                                                    Console.Clear();
                                                    Console.WriteLine("Digite a nova Data de Abertura: ");
                                                    dataChamados = Convert.ToDateTime(Console.ReadLine());
                                                    datasAberturaChamados[i3] = dataChamados;
                                                    opcaoEditarChamado = "5";
                                                    Console.Clear();
                                                    continue;
                                                case "5":
                                                    Console.Clear();
                                                    Console.WriteLine("Voltando ao Menu Principal...\n\n\n");
                                                    Console.ReadLine();
                                                    Console.Clear();
                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\nNão há nenhum chamado para editar\n\n\n");
                                        Console.ReadLine();
                                        Console.Clear();
                                        continue;
                                    }
                                    continue;

                                case "4":

                                    if (countChamados != 0)
                                    {
                                        Console.Clear();
                                        for (int i = 0; i < countChamados; i++)
                                        {
                                            Console.WriteLine(i + ": " + nomesDosChamados[i]);
                                        }
                                        Console.WriteLine("Digite o número do chamado que deseja excluir: ");
                                        int i4 = int.Parse(Console.ReadLine());
            
                                        nomesDosChamados[i4] = null;

                                        Console.ReadLine();
                                        Console.Clear();
                                        continue;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\nNão há nenhum chamado para excluir\n\n\n");
                                        Console.ReadLine();
                                        Console.Clear();
                                        continue;

                                    }
                                    continue;

                                case "5":
                                    Console.Clear();
                                    Console.WriteLine("\n\nPressione qualquer tecla para continuar");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                            }
                        }
                        break;
                }

            } while (opcao != "6");
        }
    }
}

    
