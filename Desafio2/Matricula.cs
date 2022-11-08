using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio2
{
    class Matricula
    {
        private int _mat { get; set; }
        private float _n1 { get; set; }
        private float _n2 { get; set; }
        private float _n3 { get; set; }

        public Matricula(int mat, float n1, float n2, float n3)
        {
            Mat = mat;
            N1 = n1;
            N2 = n2;
            N3 = n3;
        }

        public int Mat { get => _mat; set => _mat = value; }
        public float N1 { get => _n1; set => _n1 = value; }
        public float N2 { get => _n2; set => _n2 = value; }
        public float N3 { get => _n3; set => _n3 = value; }
    }
}
