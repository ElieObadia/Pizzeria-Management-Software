using System;
using System.Collections.Generic;
using System.Text;

namespace Projet
{
    class Pizza //Done
    {
        #region Attributs
        protected string taille;
        protected string type;
        protected int prix;
        #endregion

        #region Constructeur
        public Pizza(string taille, string type, int prix)
        {
            this.taille = taille;
            this.type = type;
            this.prix = prix;
        }
        #endregion

        #region Propriété
        public int Prix { get { return this.prix; } }
        #endregion

        #region Méthode
        /// <summary>
        /// Retourne une pizza sous forme de string
        /// </summary>
        /// <returns> string de tous attributs de l'instance de pizza </returns>
        public override string ToString()
        {
            return this.taille + " " + this.type + " " + this.prix;
        }
        #endregion
    }
}
