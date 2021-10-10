using System;
using System.Collections.Generic;

namespace Projet
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c1 = new Client("Pakiry", "Jules", "frfr", "Paris", 3876546, DateTime.Now);
            Client c2 = new Client("Perez", "Hugo", "ffvuyh", "Grenoble", 987654, DateTime.Now);
            Client c3 = new Client("Obadia", "Elie", "bvhivug", "Agde", 34567, DateTime.Now);
            Client c4 = new Client("Moussa", "Amine", "ivhvhv", "Paris", 987654, DateTime.Now);

            List<Client> liste = new List<Client> { c1, c2, c3, c4 };
            string nonordo = "";
            foreach(Client c in liste) { nonordo += c + "\n"; }
            Console.WriteLine("Liste non ordonnée :\n" + nonordo);

            string ordonom = "";
            liste.Sort(Client.CompareByName);
            foreach (Client c in liste) { ordonom += c + "\n"; }
            Console.WriteLine("Liste ordonnée nom :\n" + ordonom);

            string ordoville = "";
            liste.Sort(Client.CompareByVille);
            foreach (Client c in liste) { ordoville += c + "\n"; }
            Console.WriteLine("Liste ordonnée ville :\n" + ordoville);

            Console.ReadKey();
        }
    }
}
