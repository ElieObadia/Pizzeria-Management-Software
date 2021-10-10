using System;
using System.Collections.Generic;
using System.Text;

namespace Projet
{
    class Boisson //Done
    {
        #region Attributs
        protected string nom;
        protected int volume;
        protected int prix;
        #endregion

        #region Constructeur
        public Boisson(string nom, int volume, int prix)
        {
            this.nom = nom;
            this.volume = volume;
            this.prix = prix;
        }
        #endregion

        #region Propriété
        public int Prix { get { return this.prix; } }
        #endregion

        #region Méthode
        public override string ToString()
        {
            return this.nom + " " + this.volume + " " + this.prix ;
        }
        #endregion
    }
}
