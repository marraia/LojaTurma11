using System;
using System.Collections.Generic;
using System.Text;

namespace AvanadePleno
{
    public abstract class Pagamento
    {
        public Pagamento(double valor, int parcelamento)
        {
            Id = Guid.NewGuid();
            Valor = valor;
            Parcelamento = parcelamento;
        }

        public Pagamento(double valor)
        {
            Id = Guid.NewGuid();
            Valor = valor;
        }

        public Guid Id { get; set; }
        public double Valor { get; set; }
        public int Parcelamento { get; set; }
        public double ValorParcela { get; set; }
        public DateTime Data { get; set; }
        public bool Confirmacao { get; set; }

        public virtual void Pagar()
        {
            Data = DateTime.Now;
            if (Parcelamento > 0)
            {
                ValorParcela = Valor / Parcelamento;
            }
        }

        public void ConfirmarPagamento()
        {
            Confirmacao = true;
        }
    }
}
