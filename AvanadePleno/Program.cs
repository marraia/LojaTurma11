using System;
using System.Collections.Generic;
using System.Linq;

namespace AvanadePleno
{
    class Program
    {
        static void Main(string[] args)
        {
            var listaCompra = new List<Boleto>();

            Console.WriteLine("===================================");
            Console.WriteLine("Selecione uma opção");
            Console.WriteLine("1-Compra | 2-Pagamento");
            var opcao = int.Parse(Console.ReadLine());


            if (opcao == 1)
            {
                Console.WriteLine("Digite o valor:");
                var valor = Double.Parse(Console.ReadLine());
                Console.WriteLine("Digite se haverá parcelamento:");
                var parcelamento = int.Parse(Console.ReadLine());

                var boletoCompra = new Boleto(valor, parcelamento);
                boletoCompra.GerarBoleto();
                Console.WriteLine($"Numero do boleto {boletoCompra.Numero} com data para {boletoCompra.DataVencimento}");
                
                listaCompra.Add(boletoCompra);

                Console.WriteLine("===================================");
                Console.WriteLine("Selecione uma opção");
                Console.WriteLine("1-Compra | 2-Pagamento");
                var opcao1 = int.Parse(Console.ReadLine());

                if (opcao1 == 3)
                {
                    var dinheiro = new Dinheiro(1000);
                    dinheiro.Pagar();
                    Console.WriteLine($"Numero do pagamento {dinheiro.Id} pago na data {dinheiro.Data}");
                }

                var numeroBoleto = Guid.Parse(Console.ReadLine());
                var boletoPagamento = listaCompra
                                        .Where(a => a.Numero == numeroBoleto)
                                        .FirstOrDefault();
                
                if (boletoPagamento != null)
                {
                    boletoPagamento.Pagar();
                    Console.WriteLine($"Numero do boleto {boletoPagamento.Numero} pago na data {boletoPagamento.Data} \n Valor Parcela: {boletoPagamento.ValorParcela}");
                }
            }
        }
    }
}
