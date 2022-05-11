using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalFishing
{
    public class Magazine
    {
        #region Champs
        private int _num;
        private string _dateBouclage;
        private string _dateParution;
        private string _datePaiement;
        private int _budget;
        #endregion


        #region Constructeur
        public Magazine(int p_num, string p_dateBouclage, string p_dateParution, string p_datePaiement, int p_budget)
        {
            _num = p_num;
            _dateBouclage = p_dateBouclage;
            _dateParution = p_dateParution;
            _datePaiement = p_datePaiement;
            _budget = p_budget;
        }
        #endregion

        #region Accesseurs/Mutateurs
        public int Num
        {
            get { return _num; }
            set { _num = value; }
        }

        public string DateParution
        {
            get { return _dateParution; }
            set { _dateParution = value; }
        }


        public string DateBouclage
        {
            get { return _dateBouclage; }
            set { _dateBouclage = value; }
        }

        public string DatePaiement
        {
            get { return _datePaiement; }
            set { _datePaiement = value; }
        }

        public int Budget
        {
            get { return _budget; }
            set { _budget = value; }
        }
        #endregion


        #region Methodes
        public override string ToString()
        {
            // Méthode ToString() surchargée qui écrase la méthode ToString() de base
            return Convert.ToString(_num);
        }
        #endregion

    }
}
