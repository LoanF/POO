using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalFishing
{
    public class Pigiste
    {
        #region Champs
        private int _num;
        private string _nom;
        private string _prenom;
        private string _adresse;
        private string _cp;
        private string _ville;
        private string _mail;
        private string _numSecu;
        private string _contratCadre;


        
        #endregion

        #region Constructeur
        public Pigiste(int p_num, string p_nom, string p_prenom, string p_adresse, string p_cp, string p_ville, string p_mail, string p_numSecu, string p_contratCadre)
        {
            _num = p_num;
            _nom = p_nom;
            _prenom = p_prenom;
            _adresse = p_adresse;
            _cp = p_cp;
            _ville = p_ville;
            _mail = p_mail;
            _numSecu = p_numSecu;
            _contratCadre = p_contratCadre;
        }
        #endregion


        #region Accesseurs/Mutateurs
        public int Num
        {
            get { return _num; }
            set { _num = value; }
        }

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public string Prenom
        {
            get { return _prenom; }
            set { _prenom = value; }
        }
        public string Adresse
        {
            get { return _adresse; }
            set { _adresse = value; }
        }
        public string Cp
        {
            get { return _cp; }
            set { _cp = value; }
        }

        public string Ville
        {
            get { return _ville; }
            set { _ville = value; }
        }
        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }

        public string NumSecu
        {
            get { return _numSecu; }
            set { _numSecu = value; }
        }
        public string ContratCadre
        {
            get { return _contratCadre; }
            set { _contratCadre = value; }
        }
        #endregion


        #region Methodes
        override public string ToString()
        {
            // Méthode ToString() surchargée qui écrase la méthode ToString() de base
            return _nom + " " + _prenom;
        }
        #endregion










    }
}
