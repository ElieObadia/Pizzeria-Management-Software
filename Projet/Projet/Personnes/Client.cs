using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Projet
{
    class Client : Personne //Done
    {
        #region Attributs
        protected DateTime premierecommande;
        protected int cumulachats = 0;
        #endregion

        #region Constructeur
        public Client(string nom, string prenom, string adresse, string ville, int numtelephone):base(nom, prenom, adresse, ville, numtelephone){ }
        #endregion

        #region Propriétés
        public int Cumulachats { get { return this.cumulachats; } set { this.cumulachats = value; } }
        public DateTime Premierecommande { set { this.premierecommande = value; } }
        #endregion

        #region Méthodes
        /// <summary>
        /// Retourne un client sous forme de string
        /// </summary>
        /// <returns> string de certains attributs de l'instance de client </returns>
        public override string ToString()
        {
            return nom + " " + prenom + " " + adresse + " " + ville + " " + numtelephone + " " + this.premierecommande;
        }

        /// <summary>
        /// Permet de modifier une instance de client
        /// </summary>
        /// <param name="nom">Nouveau nom</param>
        /// <param name="prenom">Nouveau prénom</param>
        /// <param name="adresse">Nouvelle adresse</param>
        /// <param name="numtelephone">Nouveau numéro de téléphone</param>
        /// <param name="premierecommande">Nouvelle date de première commande</param>
        public void ModifierClient(string nom = null, string prenom = null, string adresse = null, int numtelephone = 0, DateTime premierecommande = new DateTime())
        {
            if (nom != null)
            {
                this.nom = nom;
            }
            if (prenom != null)
            {
                this.prenom = prenom;
            }
            if (adresse != null)
            {
                this.adresse = adresse;
            }
            if (numtelephone != 0)
            {
                this.numtelephone = numtelephone;
            }
            if (premierecommande != new DateTime())
            {
                this.premierecommande = premierecommande;
            }
        }

        /// <summary>
        /// Permet de définir comment comparer deux instances de client
        /// </summary>
        /// <param name="obj">Comparé par rapport à l'instance actuelle</param>
        /// <returns>Valeur numérique issues de la comparaison des deux clients</returns>
        public int CompareTo(object obj)
        {
            if (obj == null) //L'object est null
            {
                return 1; //L'instance actuelle est supérieur en terme d'ordre à l'objet
            }
            Client otherclient = obj as Client; //On considère obj comme un client et on le nomme otherclient
            if (otherclient != null) //Si le client n'est pas null
            {
                return cumulachats.CompareTo(otherclient.Cumulachats); //Comparaison des instances de clients avec la valeur de leurs achats cumulés
            }
            else //L'objet n'est pas un client
            {
                throw new ArgumentException("Object is not a Participant");
            }
        }
        #endregion
    }
}
