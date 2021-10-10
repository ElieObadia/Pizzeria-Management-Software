using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Projet
{
    class Pizzeria //Done
    {
        #region Attributs
        protected Effectif e;
        protected List<Client> listeclient;
        protected List<Commande> listecommande = null;
        protected int caisse = 0;
        protected int perte = 0;
        #endregion

        #region Constructeur
        public Pizzeria(Effectif e, List<Client> listeclient, int caisse, int perte)
        {
            this.e = e;
            this.listeclient = listeclient;
            this.caisse = caisse;
            this.perte = perte;
        }
        #endregion

        #region Propriétés
        public int Caisse { get { return this.caisse; } set { this.caisse = value; } }
        public int Perte { get { return this.perte; } set { this.perte = value; } }
        public List<Client> Listeclient { get { return this.listeclient; } set { this.listeclient = value; } }
        #endregion

        #region Méthode
        /// <summary>
        /// Retourne une pizzeria sous forme de string
        /// </summary>
        /// <returns> string de certains attributs de l'instance de pizzeria </returns>
        public override string ToString()
        {
            return this.e + " Caisse : " + this.caisse + " Perte : " + this.perte;
        }
        
        /// <summary>
        /// Permet une saisie
        /// </summary>
        /// <param name="message">Message à afficher pour diriger la saisie</param>
        /// <returns>Saisie effectué par l'utilisateur</returns>
        private string Saisie(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        #region Fichier
        public void FichierClient(string fichier)
        {
            StreamReader st = null;
            try
            {
                st = new StreamReader(fichier);
                string line = null;

                while ((line = st.ReadLine()) != null)

                {
                    string[] lect = line.Split(';');
                    this.listeclient.Add(new Client(lect[0], lect[1], lect[2], lect[3], Convert.ToInt32(lect[4])));
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            { if (st != null) st.Close(); }

        }

        public void FichierComis(string fichier)
        {
            StreamReader st = null;
            try
            {
                st = new StreamReader(fichier);
                string line = null;

                while ((line = st.ReadLine()) != null)

                {
                    string[] lect = line.Split(';');
                    this.e.Listecomis.Add(new Comis(lect[0], lect[1], lect[2], lect[3], Convert.ToInt32(lect[4]), Convert.ToDateTime(lect[5]), lect[6]));
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            { if (st != null) st.Close(); }
        }

        public void FichierLivreur(string fichier)
        {
            StreamReader st = null;
            try
            {
                st = new StreamReader(fichier);
                string line = null;

                while ((line = st.ReadLine()) != null)

                {
                    string[] lect = line.Split(';');
                    this.e.Listelivreur.Add(new Livreur(lect[0], lect[1], lect[2], lect[3], lect[4], lect[5], Convert.ToInt32(lect[6])));
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            { if (st != null) st.Close(); }
        }

        public void FichiersCommande(string fichiercommande, string fichierdetail)
        {
            StreamReader lectdet = null;
            StreamReader lectcom = null;
            SortedList listeelt = new SortedList();
            try
            {
                lectdet = new StreamReader(fichierdetail);
                string line = null;

                while ((line = lectdet.ReadLine()) != null)

                {
                    string[] lect = line.Split(';');
                    if (lect[1] == "Pizza")
                    {
                        for (int i = 0; i < Convert.ToInt32(lect[5]); i++)
                        {
                            listeelt.Add(lect[0], new Pizza(lect[2], lect[3], Convert.ToInt32(lect[4])));
                        }
                    }
                    else
                    {
                        for (int i = 0; i < Convert.ToInt32(lect[4]); i++)
                        {
                            listeelt.Add(lect[0], new Boisson(lect[1], Convert.ToInt32(lect[2]), Convert.ToInt32(lect[3])));
                        }
                    }
                }
            }
            catch (FileNotFoundException e) { Console.WriteLine(e.Message); }
            catch (IOException e) { Console.WriteLine(e.Message); }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally { if (lectdet != null) lectdet.Close(); }

            try
            {
                lectcom = new StreamReader(fichierdetail);
                string line = null;

                while ((line = lectcom.ReadLine()) != null)

                {
                    string[] lect = line.Split(';');
                    List<Pizza> listepizza = new List<Pizza>();
                    for(int i = 0;i<listeelt.Count;i++)
                    {
                        
                    }
                }
            }
            catch (FileNotFoundException e) { Console.WriteLine(e.Message); }
            catch (IOException e) { Console.WriteLine(e.Message); }
            catch (Exception e) { Console.WriteLine(e.Message); }
            finally { if (lectcom != null) lectcom.Close(); }
        }
        #endregion

        #region Gestion Client
        /// <summary>
        /// Permet l'ajout d'un client
        /// </summary>
        /// <param name="c">Client à ajouter</param>
        public void AjouterClient(Client c) { listeclient.Add(c); }

        /// <summary>
        /// Permet la supression d'un client
        /// </summary>
        /// <param name="c">Client à retirer</param>
        public void SupprimerClient(Client c) 
        {
            if(this.listeclient != null && this.listeclient.Count != 0)
            {
                listeclient.Remove(c); 
            }
            else { Console.WriteLine("Erreur"); }
        }
        #endregion

        #region Tri
        /// <summary>
        /// Tri les clients par rapport au cumul de leurs achats
        /// </summary>
        public void TriClientParAchat() { listeclient.Sort(); }

        /// <summary>
        /// Tri les clients par ordre alphabétique
        /// </summary>
        public void TriClientAlpha() { listeclient.Sort(Client.CompareByName); }

        /// <summary>
        /// Tri les clients par rapport à l'ordre alphabétique de ville
        /// </summary>
        public void TriClientVille() { listeclient.Sort(Client.CompareByVille); }

        /// <summary>
        /// Tri des effectifs par ordre alphabétiques
        /// </summary>
        public void TriEffectifAlpha() { e.Listecomis.Sort(Comis.CompareByName); e.Listelivreur.Sort(Livreur.CompareByName); }

        /// <summary>
        /// Tri des effectifs par rapport à l'ordre alphabétique des ville
        /// </summary>
        public void TriEffectifVille() { e.Listecomis.Sort(Comis.CompareByVille); e.Listelivreur.Sort(Livreur.CompareByVille); }

        /// <summary>
        /// Tri des clients et des effectifs par ordre alphabétique
        /// </summary>
        public void TriTotalAlpha() { listeclient.Sort(Client.CompareByName); e.Listecomis.Sort(Comis.CompareByName); e.Listelivreur.Sort(Livreur.CompareByName); }
        
        /// <summary>
        /// Tri des clients et des effectifs par rapport à l'ordre alphabétique des villes
        /// </summary>
        public void TriTotalVille() { listeclient.Sort(Client.CompareByVille);  e.Listecomis.Sort(Comis.CompareByVille); e.Listelivreur.Sort(Livreur.CompareByVille); }
        #endregion

        #region Affichage
        /// <summary>
        /// Affichage de la commande à partir de son numéro
        /// </summary>
        /// <param name="numcom">Numéro de la commande à recherchée</param>
        public void AffichageCommandePartirNum(int numcom)
        {
            if(this.listecommande!=null && this.listecommande.Count!=0)
            {
                Console.WriteLine(listecommande.Find(x => x.Numerocommande == numcom));
            }
            else { Console.WriteLine("Erreur"); }
        }

        /// <summary>
        /// Affichage du prix de la commande à partir de son numéro
        /// </summary>
        /// <param name="numcom">Numéro de la commande à recherchée</param>
        public void AffichagePrixCommandePartirNum(int numcom)
        {
            if (this.listecommande != null && this.listecommande.Count != 0)
            {
                Commande temp = listecommande.Find(x => x.Numerocommande == numcom);
                temp.AffichagePrix();
            }
            else { Console.WriteLine("Erreur"); }
        }

        /// <summary>
        /// Affiche le nombre de commande gérées par un comis
        /// </summary>
        public void AffichageCommandeComis()
        {
            if(this.e.Listecomis!=null && this.e.Listecomis.Count!=0)
            {
                foreach (Comis c in this. e.Listecomis)
                {
                    Console.WriteLine(c.Nom + " : " + c.NbCommande + " commandes gérées");
                }
            }
            else { Console.WriteLine("Erreur"); }
        }

        /// <summary>
        /// Affiche le nombre de livraisons effectuées par livreur 
        /// </summary>
        public void AffichageLivraisonLivreur()
        {
            if (this.e.Listelivreur != null && this.e.Listelivreur.Count != 0)
            {
                foreach (Livreur l in this.e.Listelivreur)
                {
                    Console.WriteLine(l.Nom + " : " + l.Nbcommande + " commandes livrées");
                }
            }
            else { Console.WriteLine("Erreur"); }
        }

        /// <summary>
        /// Affiche toute les commandes réalisées entre deux dates
        /// </summary>
        /// <param name="a">Première borne de l'intervalle</param>
        /// <param name="b">Deuxième borne de l'intervalle</param>
        public void AffichageCommandeTemps(DateTime a, DateTime b)
        {
            if (this.listecommande != null && this.listecommande.Count != 0)
            {
                Console.WriteLine("Les commandes réalisés du " + a + " au " + b);
                foreach (Commande c in listecommande)
                {
                    if (a <= c.Date && c.Date <= b) { Console.WriteLine(c); }
                }
            }
            else { Console.WriteLine("Erreur"); }
        }

        /// <summary>
        /// Affiche le prix moyen des commandes
        /// </summary>
        public void AffichageMoyennePrixCommande()
        {
            double retour = 0;
            if (this.listecommande != null && this.listecommande.Count != 0)
            {
                foreach (Commande c in listecommande)
                {
                    retour += (double)c.Prix;
                }
                double moyenne = retour / listecommande.Count;
                Console.WriteLine("La valeur moyenne d'une commande est de " + moyenne + "eur");
            }
            else { Console.WriteLine("Erreur"); }
        }

        /// <summary>
        /// Affiche la moyenne du cumul des achats des clients
        /// </summary>
        public void AffichageMoyenneClient()
        {
            double retour = 0;
            if (this.listeclient != null && this.listeclient.Count != 0)
            {
                foreach (Client c in listeclient)
                {
                    retour += (double)c.Cumulachats;
                }
                retour = retour / listeclient.Count;
            }
            Console.WriteLine("La valeur cumulées moyenne des achat d'un client est de " + retour + "eur");
        }
        #endregion

        #region Gestion Commande
        /// <summary>
        /// Permet la prise d'une commande
        /// </summary>
        /// <param name="nomclient">Nom du client qui effectue la commande</param>
        /// <param name="comis">Comis qui prend la commande</param>
        /// <param name="listepizza">Liste des pizzas qui composent la commande</param>
        /// <param name="listeboisson">Liste des évntuelles boissons qui composent la commande</param>
        public void PriseCommande(string nomclient, Comis comis, List<Pizza> listepizza, List<Boisson> listeboisson = null)
        {
            bool presence = false;
            if (this.listeclient != null && this.listeclient.Count!=0)
            {
                foreach (Client c in this.listeclient) //On regarde si le client est déjà un client de la pizzeria
                {
                    if (c.Nom == nomclient)
                    {
                        presence = true;
                    }
                }
            }
            if (!presence) //Si le client n'est pas déjà un client on l'ajoute à la liste des clients
            {
                Client nouveau = new Client(nomclient, Saisie("Entrez le prenom du nouveau client :"), Saisie("Entrez l'adresse du nouveau client :"), Saisie("Entrez la ville du nouveau client :"), Convert.ToInt32(Saisie("Entrez le numéro de téléphone du nouveau client :")));
                AjouterClient(nouveau);
                nouveau.Premierecommande = DateTime.Now;
            }
            listecommande.Add(new Commande(listepizza, Convert.ToInt32(Saisie("Entrez le numéro de commande")), DateTime.Now.Hour, DateTime.Now, nomclient, comis.Nom, listeboisson));
        }

        /// <summary>
        /// Permet d'effectuer la livraion d'une commande
        /// </summary>
        /// <param name="c">Commande à livrée</param>
        /// <param name="numerolivreur">Numéro du livreur en charge de la livraison</param>
        public void Livraison(Commande c, int numerolivreur)
        {
            if (this.e.Listecomis != null && this.e.Listelivreur != null && this.listeclient != null && c!= null && this.e.Listecomis.Count != 0 && this.e.Listelivreur.Count != 0 && this.listeclient.Count != 0)
            {
                Livreur livreur = e.Listelivreur.Find(x => x.Numtelephone == numerolivreur);
                if(e.Listelivreur.Contains(livreur) && livreur.LivraisonLivreur(c))
                {
                    Comis comisencharge = e.Listecomis.Find(x => x.Nom == c.NomComis);
                    comisencharge.RetourCommande(c); // Le comis ferme la commande
                    Client client = listeclient.Find(x => x.Nom == c.Nomclient);
                    if (c.Adresse != null) // Condition d'adresse corecte à définir
                    {
                        livreur.Nbcommande++;
                        this.caisse += c.Prix; // Si la commande est livrée on ajoute le paiement à la caisse
                        client.Cumulachats += c.Prix; // Si la commande est livrée on augmente le cumul du client
                    }
                    else
                    {
                        this.perte += c.Prix; // Si la commande est non livrée on ajoute aux pertes
                    }
                }
                else { Console.WriteLine("Erreur"); }
            }
            else { Console.WriteLine("Erreur"); }
        }
        #endregion
        #endregion
    }
}
