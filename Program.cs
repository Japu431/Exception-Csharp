using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            CarregarContas();
            Console.ReadLine();
        }

        private static void CarregarContas()
        {

            using (LeitorDeArquivo leitor = new LeitorDeArquivo("contas.txt"))
            {
                leitor.LerProximaLinha();
            }

        //LeitorDeArquivo leitor = null;

        //try
        //{
        //    LeitorDeArquivo leitor = new LeitorDeArquivo("contas.txt");

        //    leitor.LerProximaLinha();
        //    leitor.LerProximaLinha();
        //    leitor.LerProximaLinha();
        //}
        //catch(IOException)
        //{
        //    Console.WriteLine("Exceção do tipo IOException capturada e tratada! ");
        //}

        //finally {
        //    if(leitor != null)
        //    {
        //        leitor.Fechar();
        //    }
        //}
    }
        private static void TestaInnerException()
        {
            try
            {
                ContaCorrente conta = new ContaCorrente(1231, 12313);
                conta.Depositar(500);
                Console.WriteLine($"Saldo: {conta.Saldo}");
                conta.Sacar(50000);


                ContaCorrente conta2 = new ContaCorrente(312, 12321321);
                //conta2.Transferir(1000, conta);

            }

            catch (ArgumentException e)
            {
                Console.WriteLine("Ocorreu uma exceção do tipo ArgumentException : " + e.ParamName);
                Console.WriteLine(e.Message);
            }
            catch (SaldoInsuficienteException e)
            {

                Console.WriteLine($"Valor do Saldo: {e.Saldo}");
                Console.WriteLine($"Valor do Saque: {e.ValorSaque}");

                Console.WriteLine(e.StackTrace);

                Console.WriteLine(e.Message);
                Console.WriteLine("Exceção do tipo SaldoInsuficienteException");
            }
            catch (OperacaoFinanceiraException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                Console.WriteLine("Informações do INNER Exception");

                Console.WriteLine(e.InnerException.Message);
                Console.WriteLine(e.InnerException.StackTrace);
            }
        }
    }
}
