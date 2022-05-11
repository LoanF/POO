using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalFishing
{
    public class Contrat
    {
        #region Champs
        private int _num;
        private string _lettreAccord;
        private double _montantBrut;
        private double _montantNet;
        private bool _declarationAgessa;
        private bool _facture;
        private int _etat;
        private Pigiste _lePigiste;
        private Magazine _leMagazine;
        #endregion


        #region Constructeurs

        public Contrat(int p_num, string p_lettreAccord, double p_montantBrut, double p_montantNet, bool p_declarationAgessa, bool p_facture, int p_etat, Pigiste p_lePigiste, Magazine p_leMagazine)
        {
            _num = p_num;
            _lettreAccord = p_lettreAccord;
            _montantBrut = p_montantBrut;
            _montantNet = p_montantNet;
            _declarationAgessa = p_declarationAgessa;
            _facture = p_facture;
            _etat = p_etat;
            _lePigiste = p_lePigiste;
            _leMagazine = p_leMagazine;
        }


        public Contrat(int p_num, double p_montantBrut, double p_montantNet, bool p_declarationAgessa, bool p_facture, int p_etat, Pigiste p_lePigiste, Magazine p_leMagazine)
        {
            _num = p_num;
            _lettreAccord = "1m2p-la-" + p_leMagazine.Num + "-" + p_lePigiste.Num;
            _montantBrut = p_montantBrut;
            _montantNet = p_montantNet;
            _declarationAgessa = p_declarationAgessa;
            _facture = p_facture;
            _etat = p_etat;
            _lePigiste = p_lePigiste;
            _leMagazine = p_leMagazine;
        }
        #endregion


        #region Accesseurs/Mutateurs
        public int Num
        {
            get { return _num; }
            set { _num = value; }
        }

        public string LettreAccord
        {
            get { return _lettreAccord; }
            set { _lettreAccord = value; }
        }
        public double MontantBrut
        {
            get { return _montantBrut; }
            set { _montantBrut = value; }
        }

        public double MontantNet
        {
            get { return _montantNet; }
            set { _montantNet = value; }
        }

        public bool DeclarationAgessa
        {
            get { return _declarationAgessa; }
            set { _declarationAgessa = value; }
        }
        public bool Facture
        {
            get { return _facture; }
            set { _facture = value; }
        }
        public int Etat
        {
            get { return _etat; }
            set { _etat = value; }
        }

        public Pigiste LePigiste
        {
            get { return _lePigiste; }
            set { _lePigiste = value; }
        }


        public Magazine LeMagazine
        {
            get { return _leMagazine; }
            set { _leMagazine = value; }
        }
        #endregion

        #region Methodes

        #endregion
    }
}
