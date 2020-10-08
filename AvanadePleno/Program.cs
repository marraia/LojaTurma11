using System;
using System.Collections.Generic;
using System.Linq;

namespace AvanadePleno
{
    class Program
    {
        private static List<Boleto> listaCompra;

        static void Main(string[] args)
        {
            listaCompra = new List<Boleto>();

            while (true)
            {
                Console.WriteLine("===================================");
                Console.WriteLine("Selecione uma opção");
                Console.WriteLine("1-Compra | 2-Pagamento | 3-Dinheiro");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Comprar();
                        break;
                    case 2:
                        PagarBoleto();
                        break;
                    case 3:
                        PagarDinheiro();
                        break;
                    default:
                        break;
                }
            }
        }

        public static void Comprar()
        {
            Console.WriteLine("Digite o valor:");
            var valor = Double.Parse(Console.ReadLine());
            Console.WriteLine("Digite se haverá parcelamento:");
            var parcelamento = int.Parse(Console.ReadLine());

            var boletoCompra = new Boleto(valor, parcelamento);
            boletoCompra.GerarBoleto();
            Console.WriteLine($"Numero do boleto {boletoCompra.Numero} com data para {boletoCompra.DataVencimento}");

            listaCompra.Add(boletoCompra);
        }

        public static void PagarBoleto()
        {
            Console.WriteLine("Digite o número do boleto:");
            var numeroBoleto = Guid.Parse(Console.ReadLine());
            var boletoPagamento = listaCompra
                                    .Where(a => a.Numero == numeroBoleto)
                                    .FirstOrDefault();

            if (boletoPagamento != null)
            {
                if (boletoPagamento.DataVencimento < DateTime.Now)
                {
                    boletoPagamento.CalcularJurosVencimento();
                    Console.WriteLine($"Boleto está vencido, terá acrescimo de 5% ==== R$ {boletoPagamento.Valor}");
                }

                boletoPagamento.Pagar();
                Console.WriteLine($"Numero do boleto {boletoPagamento.Numero} pago na data {boletoPagamento.Data} \n Valor Parcela: {boletoPagamento.ValorParcela}");
            }
        }

        public static void PagarDinheiro()
        {
            Console.WriteLine("Digite o valor:");
            var valor = Double.Parse(Console.ReadLine());
            Console.WriteLine($"========= Á VISTA { valor } =========");
            var dinheiro = new Dinheiro(valor);
            dinheiro.Pagar();
            Console.WriteLine($"Numero do pagamento {dinheiro.Id} pago no valor: {dinheiro.Valor}");
        }
    }
}
