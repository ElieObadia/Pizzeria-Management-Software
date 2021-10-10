using System;
using System.Collections.Generic;
using System.Text;

namespace Projet
{
    class Livreur : Personne //Done
    {
        #region Attributs
        protected string moyentransport;
        protected string etat;
        protected int nombrecommande;
        #endregion

        #region Constructeur
        public Livreur(string nom, string prenom, string adresse, string ville, string moyentransport, string etat, int numtelephone = 0) : base(nom, prenom, adresse, ville, numtelephone)
        {
            this.moyentransport = moyentransport;
            this.etat = etat;
        }
        #endregion

        #region  Propriétés
        public string Etat { get { return this.etat; } }
        public int Nbcommande { get { return this.nombrecommande; } set { this.nombrecommande = value; } }
        #endregion

        #region Méthodes
        /// <summary>
        /// Retourne un livreur sous forme de string
        /// </summary>
        /// <returns> string de certains attributs de l'instance de livreur </returns>
        public override string ToString()
        {
            return nom + " " + prenom + " " + adresse + " " + numtelephone + " " + this.moyentransport;
        }

        /// <summary>
        /// Retourne si la commande peut être attribuée à cette instance de livreur et mets la commande en livraison
        /// </summary>
        /// <param name="commande">Commande a analyser</param>
        /// <returns>True si la commande est faisable et mise en livraison / False sinon</returns>
        public bool LivraisonLivreur(Commande commande)
        {
            bool retour = false;
            if(commande != null && this.etat == "Sur place" && commande.Etat =="En préparation") 
            {
                commande.Etat = "En livraison";
                retour = true;
            }
            return retour;
        }
        #endregion
    }
}
