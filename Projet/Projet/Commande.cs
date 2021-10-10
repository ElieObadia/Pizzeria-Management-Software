using System;
using System.Collections.Generic;
using System.Text;

namespace Projet
{
    class Commande //Done
    {
        #region Attributs
        protected List<Pizza> listepizza;
        protected List<Boisson> listeboisson;
        protected int numerocommande;
        protected int heure;
        protected DateTime date;
        protected string comisencharge;
        protected string nomclient;
        protected int prix;
        protected string adresse;
        protected string etat = "En préparation";
        #endregion

        #region Constructeur
        public Commande(List<Pizza> listepizza, int numerocommande, int heure, DateTime date, string nomclient, string comisencharge, List<Boisson> listeboisson = null)
        {
            this.listepizza = listepizza;
            this.listeboisson = listeboisson;
            this.numerocommande = numerocommande;
            this.heure = heure;
            this.date = date;
            this.nomclient = nomclient;
            this.comisencharge = comisencharge;
            this.prix = Total();
        }

        public Commande(List<Pizza> listepizza, int numerocommande, int heure, DateTime date, string nomclient, string comisencharge)
        {

        }
        #endregion

        #region Propriétés
        public List<Pizza> Listepizza { get { return this.listepizza; } set { this.listepizza = value; } }
        public List<Boisson> Listeboisson { get { return this.listeboisson; } set { this.listeboisson = value; } }
        public string Nomclient { get { return this.nomclient; } set { this.nomclient = value; } }
        public string Etat { get { return this.etat; } set { this.etat = value; } }
        public int Numerocommande { get { return this.numerocommande; } }
        public string NomComis { get { return this.comisencharge; } }
        public string Adresse { get { return this.adresse; } }
        public DateTime Date { get { return this.date; } }
        public int Prix { get { return this.prix; } }
        #endregion

        #region Méthodes
        /// <summary>
        /// Retourne une commande sous forme de string
        /// </summary>
        /// <returns> string de certains attributs de l'instance de commande </returns>
        public override string ToString()
        {
            string pi = "Pizza : \n";
            string bo = "";
            foreach (Pizza p in listepizza) //On recupère chaque pizza composant la commande
            {
                pi += p + "\n";
            }
            if (this.listeboisson != null && this.listeboisson.Count != 0) //On regarde si il y a des boissons dans la commande 
            {
                bo += "Boissons :\n";
                foreach (Boisson b in listeboisson) //On recupère chaque pizza composant la commande
                {
                    bo += b + "\n";
                }
            }
            return this.numerocommande + " " + this.heure + " " + this.date + "  " + this.comisencharge + " " + this.nomclient + " " + this.etat + "\n" + pi + bo;
        }

        /// <summary>
        /// Calcul du prix total de la commande
        /// </summary>
        /// <returns>Valeur totale de la commande</returns>
        private int Total()
        {
            int total = 0;
            if(this.listepizza!=null && this.listepizza.Count != 0)
            {
                foreach (Pizza p in this.listepizza) //On récupère chaque pizza de la commande
                {
                    total += p.Prix; //On ajoute le prix de la pizza au total
                }
            }
            else { Console.WriteLine("Erreur calcul avec pizza"); }
            if (this.listeboisson != null && this.listeboisson.Count != 0) //On regarde si il y a des boissons dans la commande 
            {
                foreach (Boisson b in this.listeboisson) //On recupère chaque pizza composant la commande
                {
                    total += b.Prix; //On ajoute le prix de la boisson au total
                }
            }
            return total; //On retourne le total
        }

        /// <summary>
        /// Affichage du numéro de la commande et de son prix
        /// </summary>
        public void AffichagePrix()
        {
            Console.WriteLine("Commande n°" + this.numerocommande + " : " + this.prix +"eur");
        }
        #endregion
    }
}
