using System;

namespace cliente
{
    public class ExemploConstrutor
    {
        private int _valor1;
        private int _valor2;

        public ExemploConstrutor()
        {

        }

        public ExemploConstrutor(int valor1, int valor2)
        {
            _valor1 = valor1;
            _valor2 = valor2;
        }
        public ExemploConstrutor(int valor) : this(valor, 0)
        {
            
        }

        
    }
}