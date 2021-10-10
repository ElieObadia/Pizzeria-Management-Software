using System;
using System.Collections.Generic;
using System.Text;

namespace Projet
{
    class Effectif //Done
    {
        #region Attributs
        protected List<Comis> listecomis;
        protected List<Livreur> listelivreur;
        #endregion

        #region Constructeur
        public Effectif(List<Comis> listecomis, List<Livreur> listelivreur)
        {
            this.listecomis = listecomis;
            this.listelivreur = listelivreur;
        }
        #endregion

        #region Propriétés
        public List<Comis> Listecomis { get { return this.listecomis; } }
        public List<Livreur> Listelivreur { get { return this.listelivreur; } }
        #endregion

        #region Méthode
        /// <summary>
        /// Retourne un effectif sous forme de string
        /// </summary>
        /// <returns> string de tous attributs de l'instance d'effectif </returns>
        public override string ToString()
        {
            string co = "";
            string li = "";
            foreach(Comis c in listecomis) //On récupère chaque comis
            {
                co += c+"\n";
            }
            foreach (Livreur l in listelivreur) //On récupère chaque livreur
            {
                li += l + "\n";
            }
            return "Comis :\n" + co + "Livreurs :\n" + li;
        }
        #endregion
    }
}
