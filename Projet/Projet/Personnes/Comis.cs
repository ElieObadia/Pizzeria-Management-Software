using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projet
{
    class Comis : Personne //Done
    {
        #region Attributs
        protected DateTime embauche;
        protected string etat;
        protected int nbcommande = 0;
        #endregion

        #region Constructeur
        public Comis(string nom, string prenom, string adresse, string ville, int numtelephone, DateTime embauche, string etat) : base(nom, prenom, adresse, ville, numtelephone)
        {
            this.embauche = embauche;
            this.etat = etat;
        }
        #endregion

        #region Propriétés
        public string Etat { get { return this.etat; } }
        public int NbCommande { get { return this.nbcommande; } set { this.nbcommande = value; } }
        #endregion

        #region Méthode
        /// <summary>
        /// Retourne un comis sous forme de string
        /// </summary>
        /// <returns> string de certains attributs de l'instance de comis </returns>
        public override string ToString()
        {
            return nom + " " + prenom + " " + adresse + " " + numtelephone + " " + this.embauche;
        }

        /// <summary>
        /// Consultation par affichage l'état des effectifs
        /// </summary>
        /// <param name="e">Effectif dont on souhaite obtenir l'état</param>
        public void EtatEffectif(Effectif e)
        {
            if(e.Listecomis!=null && e.Listecomis.Count!=0)
            {
                Console.WriteLine("Etat des comis : ");
                foreach (Comis c in e.Listecomis) //On consulte les comis
                {
                    Console.WriteLine(c.Nom + " " + c.Etat); //On affiche l'état des comis
                }
            }
            if(e.Listelivreur!=null && e.Listelivreur.Count!=0)
            { 
                Console.WriteLine("Etat des livreurs : ");
                foreach (Livreur l in e.Listelivreur) //On consulte les livreurs
                {
                    Console.WriteLine(l.Nom + " " + l.Etat); //On affiche l'état des livreurs
                }
            }
        }

        /// <summary>
        /// Fermeture d'une commande lors du retour du livreur
        /// </summary>
        /// <param name="commande">Commande en cours de traitement</param>
        public void RetourCommande(Commande commande) // La fonction vérifie que la commande peut être cloturée et la cloture dans ce cas là
        {
            if(commande != null && commande.NomComis == this.nom && commande.Etat!="Fermée") // Vérification de l'état actuel de la commande et du comis en charge
            {
                commande.Etat = "Fermée"; // Fermeture de la commande
            }
            else { Console.WriteLine("Erreur lors de la fermeture de la commande"); }
        }

        /// <summary>
        /// Consultation par affichage de l'état d'une commande
        /// </summary>
        /// <param name="c">Commande dont on souhaite consulter l'état</param>
        public void EtatCommande(Commande c) 
        {
            if (c != null)
            {
                Console.WriteLine("La commande n°" + c.Numerocommande + " est " + c.Etat); 
            }
            else { Console.WriteLine("Erreur"); }
        }
        #endregion
    }
}
