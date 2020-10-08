using System;
using System.Collections.Generic;
using System.Text;

namespace AvanadePleno
{
    public class Dinheiro : Pagamento
    {
        public Dinheiro(double valor) 
            :base (valor)
        {

        }

        public override void Pagar()
        {
            Data = DateTime.Now;
        }
    }
}
