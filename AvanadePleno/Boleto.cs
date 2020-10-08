using System;
using System.Collections.Generic;
using System.Text;

namespace AvanadePleno
{
    public class Boleto : Pagamento
    {
        public Boleto(double valor, int parcelamento) 
            : base(valor, parcelamento)
        {

        }

        public Guid Numero { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Banco { get; set; }
        public decimal Juros { get; set; }

        public void GerarBoleto()
        {
            Numero = Guid.NewGuid();
            DataVencimento = DateTime.Now.AddDays(-1);
        }

        public void CalcularJurosVencimento()
        {
            var taxa = Valor * 0.05;
            Valor = Valor + taxa;
        }
    }
}
