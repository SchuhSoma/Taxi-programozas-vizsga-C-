using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi
{
    class Taxi
    {
        public int Azonosito;
        public String Indulas;
        public int UtazasiIdo;
        public double Tavolsag;
        public double Viteldij;
        public double Borravalo;
        public string Fizetesmod;

        public Taxi(string sor)
        {
            var dbok = sor.Split(';');
            this.Azonosito = int.Parse(dbok[0]);
            this.Indulas = dbok[1];
            this.UtazasiIdo = int.Parse(dbok[2]);
            this.Tavolsag=double.Parse(dbok[3]);
            this.Viteldij = double.Parse(dbok[4]);
            this.Borravalo = double.Parse(dbok[5]);
            this.Fizetesmod = dbok[6];

        }
    }
}
