using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Projet
{
    abstract class Personne //Done
    {
        #region Attributs
        protected string nom;
        protected string prenom;
        protected string adresse;
        protected string ville;
        protected int numtelephone;
        #endregion

        #region Constructeur
        public Personne(string nom, string prenom, string adresse, string ville, int numtelephone = 0)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.ville = ville;
            this.numtelephone = numtelephone;
        }
        #endregion

        #region Propriétes
        public string Nom { get { return nom; } set { nom = value; } }
        public string Prenom { get { return prenom; } set { prenom = value; } }
        public string Adresse { get { return adresse; } set { adresse = value; } }
        public int Numtelephone { get { return numtelephone; } set { numtelephone = value; } }
        public string Ville { get { return this.ville; } set { this.ville = value; } }
        #endregion

        #region Méthodes
        /// <summary>
        /// Retourne une personne sous forme de string
        /// </summary>
        /// <returns> string de tous les attributs de l'instance de personne </returns>
        public override string ToString()
        {
            return this.nom+" "+ this.prenom+" "+this.adresse+" "+this.numtelephone;
        }

        /// <summary>
        /// Permet de comparer deux personnes en foction de leur nom
        /// </summary>
        /// <param name="p1">Personne comparante</param>
        /// <param name="p2">Personne comparée</param>
        /// <returns>Valeur numérique de la comparaison des noms des deux personnes</returns>
        public static int CompareByName(Personne p1, Personne p2)
        {
            return String.Compare(p1.Nom, p2.Nom); //Comparaison des noms et retour de la valeur de comparaison
        }

        /// <summary>
        /// Permet de comparer deux personnes en foction de leur ville
        /// </summary>
        /// <param name="p1">Personne comparante</param>
        /// <param name="p2">Personne comparée</param>
        /// <returns>Valeur numérique de la comparaison des villes des deux personnes</returns>
        public static int CompareByVille(Personne p1, Personne p2)
        {
            return String.Compare(p1.Ville, p2.Ville); //Comparaison des villes et retour de la valeur de comparaison
        }
        #endregion
    }
}
