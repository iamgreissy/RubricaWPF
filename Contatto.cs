using System;
using System.Collections.Generic;

namespace syziu.regreis.4i.rubrica
{
    internal class Contatto
    {
        private int _numero;
        private string _cognome;

        public int Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException();

                _numero = value;
            }
        }

        public string Nome { get; set; }
        public string EMail { get; set; }
        public string Telefono { get; set; }
        public string Citta { get; set; }
        public string CAP { get; set; }

        public string Cognome { get => _cognome; set => _cognome = value; }

        public Contatto() { }

        public Contatto(string riga)
        {
            string[] campi = riga.Split(';');
            if (campi.Length >= 4)
            {
                if (int.TryParse(campi[0], out int numero))
                {
                    this.Numero = numero;
                }

                this.Nome = campi[1];
                this.Cognome = campi[2];
                this.Telefono = campi[3];
                this.EMail = campi[4]; // Assumendo che l'email sia nella quinta colonna
            }
        }

    public Contatto(int numero, string nome, string cognome)
        {
            Numero = numero;
            Nome = nome;
            Cognome = cognome;
        }
    }

    internal class Program
    {
        private static void Main()
        {
            List<Contatto> rubrica = new List<Contatto>();

            rubrica.Add(new Contatto(1, "Mario", "Rossi"));
            rubrica.Add(new Contatto(2, "Luigi", "Verdi"));
            rubrica.Add(new Contatto(3, "Anna", "Bianchi"));

            Console.WriteLine("Rubrica:");
            foreach (Contatto contatto in rubrica)
            {
                Console.WriteLine($"Numero: {contatto.Numero}, Nome: {contatto.Nome}, Cognome: {contatto.Cognome}");
            }
        }
    }
}

