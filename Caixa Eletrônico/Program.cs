using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class cliente
{
    String numeroCartao;
    int senha;
    String nome;
    String sobrenome;
    double saldo;
    List<string> extrato;
                

    public cliente(string numeroCartao, int senha, string nome, string sobrenome, double saldo)
    {
        this.numeroCartao = numeroCartao;
        this.senha = senha;
        this.nome = nome;
        this.sobrenome = sobrenome;
        this.saldo = saldo;
        extrato = new List<string>();
    }
    public String getNumero()
    {
        return numeroCartao;
    }
    public int getSenha()
    {
        return senha;
    }
    public String getNome()
    {
        return nome;
    }
    public String getSobrenome() 
    { 
        return sobrenome;
    }

    public double getSaldo()
    {
        return saldo;
    }

    public void setNumero(String novoNumeroCartao)
    {
        numeroCartao = novoNumeroCartao;
    }

    public void setSenha(int novaSenha)
    {
        senha = novaSenha;
    }

    public void setNome(String novoNome)
    {
        this.nome = novoNome;
    }

    public void setSobrenome(String novoSobrenome)
    {
        this.sobrenome = novoSobrenome;
    }

    public void setSaldo(double novoSaldo)
    {
        this.saldo = novoSaldo;
    }

    public static void Main(String[] args)
    {

        void mostrarFuncoes()
        {
            Console.WriteLine("Por favor escolha uma das opções a seguir: ");
            Console.WriteLine("1 - Depositar ");
            Console.WriteLine("2 - Sacar ");
            Console.WriteLine("3 - Mostrar Saldo ");
            Console.WriteLine("4 - Transferência ");
            Console.WriteLine("5 - Extrato ");
            Console.WriteLine("6 - Sair ");
        }

        void deposito(cliente usuarioAtual)
        {
            Console.WriteLine("Digite o valor do depósito: ");
            double deposito = Double.Parse(Console.ReadLine());
            usuarioAtual.setSaldo(usuarioAtual.getSaldo() + deposito);                             // atencao nessa linha, colocar dposito + saldo atual

            Console.WriteLine(" Deposito realizado com sucesso \r\n Data: " + DateTime.Now + "\r\n Seu saldo atual é: R$ " + usuarioAtual.getSaldo());

            String mensagemOperacao = "Depósito realizado - Valor: " + deposito + " - Data: " + DateTime.Now;
            usuarioAtual.extrato.Add(mensagemOperacao);
            Console.WriteLine(mensagemOperacao);
            Console.WriteLine("Seu saldo atual é: R$ " + usuarioAtual.getSaldo());

        }
        
        void saque(cliente usuarioAtual)
        {
            Console.WriteLine("Quanto gostaria de sacar: ");
            double saque = Double.Parse(Console.ReadLine());

            // Conferir se cliente tem grana suficiente

            if (usuarioAtual.getSaldo() < saque)
            {
                Console.WriteLine("Saldo Insuficiente. ;( ");
            }
            else 
            {
                usuarioAtual.setSaldo(usuarioAtual.getSaldo() - saque);
                Console.WriteLine(" Saque realizado com sucesso \r\n Data: " + DateTime.Now + "\r\n Seu saldo atual é: R$ " + usuarioAtual.getSaldo()); 
            }

            string mensagemOperacao = "Saque realizado - Valor: " + saque + " - Data: " + DateTime.Now;
            usuarioAtual.extrato.Add(mensagemOperacao);
            Console.WriteLine(mensagemOperacao);
            Console.WriteLine("Seu saldo atual é: R$ " + usuarioAtual.getSaldo());

        }
        void saldo(cliente usuarioAtual)
        {
                
            Console.WriteLine("Seu saldo atual é: R$ " + usuarioAtual.getSaldo());

        }


        
        


        List<cliente> clientes = new List<cliente>();
        clientes.Add(new cliente("15915928392389", 1234, "João Vitor ", "Komatsu ", 55000.94));
        clientes.Add(new cliente("48929747192947", 2121, "Hector ", "Balderrama ", 2350.10));
        clientes.Add(new cliente("92749275197592", 7777, "Samuel ", "Cardoso ", 1000000.0));
        clientes.Add(new cliente("23586238983568", 8080, "Jessé ", "Cardoso ", 1000000.55));
        clientes.Add(new cliente("23895629385699", 9090, "Edvaldo ", "Ferreira ", 20300.47));

        // Alertar usuario

        Console.WriteLine("Bem-vindo ao Caixa Eletrônico ");
        Console.WriteLine("Por Favor insira o cartão: ");
        String numeroCartaoDebito;
        cliente usuarioAtual;
        
        while (true)
        {
            try
            {
                numeroCartaoDebito = Console.ReadLine();
                // confere no """"" BANCO DE DADOS  """""
                usuarioAtual = clientes.FirstOrDefault(a => a.numeroCartao == numeroCartaoDebito);

                if (usuarioAtual != null) { break; }
                else { Console.WriteLine("Cartão Inválido, por favor tente novamente. "); }
                
            }
            catch { Console.WriteLine("Cartão Inválido, por favor tente novamente. "); }
        }

        Console.WriteLine("Por favor, digite sua senha: ");
        int senhaUsuario = 0;
        while (true)
        
        {
            try
            {
                senhaUsuario = int.Parse(Console.ReadLine());
                // Confere no """"" BANCO DE DADOS  """""
       
                if (usuarioAtual.getSenha() == senhaUsuario) { break; }
                else { Console.WriteLine("Senha Inválida, por favor tente novamente. "); }

            }
            catch { Console.WriteLine("Senha Inválida, por favor tente novamente. "); }
        }

        Console.WriteLine("Bem-vindo " + usuarioAtual.getNome() + ";) ");
        int opcao = 0;
        while (opcao != 6)
        {
            mostrarFuncoes();
            try
            {
                opcao = int.Parse(Console.ReadLine());
            }
            catch { }
            if (opcao == 1) { deposito(usuarioAtual); }
            else if (opcao == 2) { saque(usuarioAtual); }
            else if (opcao == 3) { saldo(usuarioAtual); }
            else if (opcao == 4) { transferencia(usuarioAtual); }
            else if (opcao == 5) { extrato(usuarioAtual); }
            else if (opcao == 6) { break; }
            else { opcao = 0; }
        }

        while (opcao != 5);
        Console.WriteLine("Obrigado, até a próxima ;) ");


        void transferencia(cliente usuarioAtual)
        {
            Console.WriteLine("Insira o valor a ser transferido: ");
            double valorTransferencia = Double.Parse(Console.ReadLine());

            Console.WriteLine("Insira o número da conta: ");
            String numeroCartaoDestino;

            cliente destinatario = null;

            while (true)
            {
                try
                {
                    numeroCartaoDestino = Console.ReadLine();
                    // Confere no "banco de dados"
                    destinatario = clientes.FirstOrDefault(a => a.numeroCartao == numeroCartaoDestino);

                    if (destinatario != null)
                    {
                        Console.WriteLine("Deseja confirmar a transferência no valor de R$:" + valorTransferencia + " para " + destinatario.getNome() +
                            destinatario.getSobrenome() + "\r\n Pressione \"S\" para CONFIRMAR ou \"N\" para CANCELAR a operação.");

                        String resposta = Console.ReadLine();
                        if (resposta.ToLower() == "s")
                        {
                            if (usuarioAtual.getSaldo() < valorTransferencia)
                            {
                                Console.WriteLine("Saldo Insuficiente. ;(");
                            }
                            else
                            {
                                // Lógica de transferência
                                usuarioAtual.setSaldo(usuarioAtual.getSaldo() - valorTransferencia);
                                destinatario.setSaldo(destinatario.getSaldo() + valorTransferencia);
                                Console.WriteLine("Transferência Realizada com Sucesso ");
                                Console.WriteLine("Seu saldo atual é: R$ " + usuarioAtual.getSaldo());
                                Console.WriteLine("Data:" + DateTime.Now);

                                String mensagemOperacao = "Transferência realizada - Valor: " + valorTransferencia + " - Data: " + DateTime.Now;
                                usuarioAtual.extrato.Add(mensagemOperacao);
                            }
                            break;
                        }
                        else if (resposta.ToLower() == "n")
                        {
                            Console.WriteLine("Operação Cancelada");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Resposta Inválida, por favor tente novamente.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Conta Inválida, por favor tente novamente. ");
                    }
                }
                catch
                {
                    Console.WriteLine("Conta Inválida, por favor tente novamente. ");
                }
            }
        }

        void extrato(cliente usuarioAtual)
        {
            Console.WriteLine("Extrato Conta-Corrente, banco XPTO \r\nTodo Período");
            Console.WriteLine("Nome: " + usuarioAtual.getNome() + " " + usuarioAtual.getSobrenome());
            Console.WriteLine("Número do Cartão: " + usuarioAtual.getNumero());
            Console.WriteLine("Seu saldo atual é: R$ " + usuarioAtual.getSaldo());
            Console.WriteLine("Data: " + DateTime.Now);

            Console.WriteLine("Operações realizadas:");

            foreach (string operacao in usuarioAtual.extrato)
            {
                Console.WriteLine(operacao);
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey(true); // Aguarda a entrada de uma tecla antes de continuar
            Console.Clear(); // Limpa a tela antes de voltar ao menu
            
        }



    }  

    

}