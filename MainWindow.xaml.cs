using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DigitalFishing
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contrat> lesContrats = new List<Contrat>();
        List<Magazine> lesMagazines = new List<Magazine>();
        List<Pigiste> lesPigistes = new List<Pigiste>();

        public MainWindow()
        {
            InitializeComponent();

            //Lie le Datagrid dtgMagazine avec la collection cMagazine
            dtgMagazine.ItemsSource = lesMagazines;

            //Lie le Datagrid dtgPigiste avec la collection cPigiste
            dtgPigiste.ItemsSource = lesPigistes;

            //Lie le Datagrid dtgContrat avec la collection cContrat
            dtgContrat.ItemsSource = lesContrats;


            Pigiste p1 = new Pigiste(1, "Liguili", "Guy", "11 rue des lilas", "71000", "Macon", "guy@yopmail.fr", "1820696000000", "cc-01");
            Pigiste p2 = new Pigiste(2, "Terrieur", "Alain", "12 rue des lilas", "71000", "Macon", "alain@yopmail.fr", "1820696000000", "cc-02");
            Pigiste p3 = new Pigiste(3, "Terrieur", "Alex", "13 rue des lilas", "71000", "Macon", "alex@yopmail.fr", "1820696000000", "cc-03");

            Magazine m1 = new Magazine(1, "01/01/2022", "01/02/2022", "01/03/2022", 3500);
            Magazine m2 = new Magazine(2, "01/04/2022", "01/05/2022", "01/06/2022", 3500);
            Magazine m3 = new Magazine(3, "01/07/2022", "01/08/2022", "01/09/2022", 3500);

            Contrat c1 = new Contrat(1, 144, 140, true, false, 0, p1, m1);
            Contrat c2 = new Contrat(3, 288, 280, true, false, 0, p2, m1);
            Contrat c3 = new Contrat(2, 144, 140, true, false, 0, p1, m2);


            // On ajoute nos objets créés dans les collections
            lesPigistes.Add(p1);
            lesPigistes.Add(p2);
            lesPigistes.Add(p3);
            lesMagazines.Add(m1);
            lesMagazines.Add(m2);
            lesMagazines.Add(m3);
            lesContrats.Add(c1);
            lesContrats.Add(c2);
            lesContrats.Add(c3);


            // Lie les 2 comboboxs de l'onglet contrat avec les collections cPigiste et cMagazine
            cboPigiste.ItemsSource = lesPigistes;
            cboMagazine.ItemsSource = lesMagazines;

            //Selection de la première ligne dans les 3 datagrids pour éviter les erreurs de manipulation (A/M/S sans selection préalable)
            dtgContrat.SelectedIndex = 0;
            dtgMagazine.SelectedIndex = 0;
            dtgPigiste.SelectedIndex = 0;
        }

        private void dtgContrat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contrat selectedContrat = dtgContrat.SelectedItem as Contrat;

            try
            {
                txtNumContrat.Text = Convert.ToString(selectedContrat.Num);
                txtLettreAccordContrat.Text = selectedContrat.LettreAccord;
                txtMontantBrutContrat.Text = Convert.ToString(selectedContrat.MontantBrut);
                txtMontantNetContrat.Text = Convert.ToString(selectedContrat.MontantNet);
                cboEtatContrat.SelectedIndex = selectedContrat.Etat;

                if (selectedContrat.Facture == true)
                { chkFacture.IsChecked = true; }
                else
                { chkFacture.IsChecked = false; }

                if (selectedContrat.DeclarationAgessa == true)
                { chkAgessa.IsChecked = true; }
                else
                { chkAgessa.IsChecked = false; }

                // Sélection du pigiste concerné dans la Combobox
                //cboPigiste.SelectedItem = selectedContrat.PigisteContrat;

                int i = 0;
                bool trouve = false;

                while (i < cboPigiste.Items.Count && trouve == false)
                {
                    if (Convert.ToString(cboPigiste.Items[i]) == Convert.ToString(selectedContrat.LePigiste))
                    {
                        trouve = true;
                        cboPigiste.SelectedIndex = i;

                    }
                    i++;
                }

                // Sélection du magazine concerné dans la Combobox
                //cboPigiste.SelectedItem = selectedContrat.PigisteContrat;

                i = 0;
                trouve = false;

                while (i < cboMagazine.Items.Count && trouve == false)
                {
                    if (Convert.ToString(cboMagazine.Items[i]) == Convert.ToString(selectedContrat.LeMagazine))
                    {
                        trouve = true;
                        cboMagazine.SelectedIndex = i;

                    }
                    i++;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Erreur sur la mise à jour du formulaire lors du changement dans le Datagrid dtgContrat");
            }
        }

        private void dtgMagazine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Magazine selectedMagazine = dtgMagazine.SelectedItem as Magazine;

            try
            {
                txtNumMagazine.Text = Convert.ToString(selectedMagazine.Num);
                dtpBouclageMagazine.Text = Convert.ToString(selectedMagazine.DateBouclage);
                dtpParutionMagazine.Text = Convert.ToString(selectedMagazine.DateParution);
                dtpPaiementMagazine.Text = Convert.ToString(selectedMagazine.DatePaiement);
                txtBudgetMagazine.Text = Convert.ToString(selectedMagazine.Budget);
            }
            catch (Exception)
            {
                Console.WriteLine("Erreur sur la mise à jour du formulaire lors du changement dans le Datagrid dtgMagazine");
            }
        }

        private void dtgPigiste_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pigiste selectedPigiste = dtgPigiste.SelectedItem as Pigiste;
            
            try
            {
                txtNumPigiste.Text = Convert.ToString(selectedPigiste.Num);
                txtNomPigiste.Text = Convert.ToString(selectedPigiste.Nom);
                txtPrenomPigiste.Text = Convert.ToString(selectedPigiste.Prenom);
                txtAdressePigiste.Text = Convert.ToString(selectedPigiste.Adresse);
                txtCPPigiste.Text = Convert.ToString(selectedPigiste.Cp);
                txtVillePigiste.Text = Convert.ToString(selectedPigiste.Ville);
                txtNumSecuPigiste.Text = Convert.ToString(selectedPigiste.NumSecu);
                txtMailPigiste.Text = Convert.ToString(selectedPigiste.Mail);
                txtContratCadrePigiste.Text = Convert.ToString(selectedPigiste.ContratCadre);
            }
            catch (Exception)
            {
                Console.WriteLine("Erreur sur la mise à jour du formulaire lors du changement dans le Datagrid dtgPigiste");
            }
        }

        private void btnAjouterMagazine_Click(object sender, RoutedEventArgs e)
        {
            Bdd.InsertMagazine(dtpBouclageMagazine.Text, dtpParutionMagazine.Text, dtpPaiementMagazine.Text, Convert.ToInt16(txtBudgetMagazine.Text));
            Bdd.SelectMagazine();
            dtgMagazine.Items.Refresh();
        }

        private void btnModifierMagazine_Click(object sender, RoutedEventArgs e)
        {
            //On recherche à quel indice de la collection se trouve l'object selectionné dans le datagrid
            int indice = lesMagazines.IndexOf((Magazine)dtgMagazine.SelectedItem);

            // On change les propritétés de l'objet à l'indice trouvé. On ne change pas le numéro de magazine via l'interface, trop de risques d'erreurs en base de données
            lesMagazines.ElementAt(indice).DateParution = dtpParutionMagazine.Text;
            lesMagazines.ElementAt(indice).DatePaiement = dtpPaiementMagazine.Text;
            lesMagazines.ElementAt(indice).DateBouclage = dtpBouclageMagazine.Text;
            lesMagazines.ElementAt(indice).Budget = Convert.ToInt32(txtBudgetMagazine.Text);

            dtgMagazine.Items.Refresh();
        }

        private void btnSupprimerMagazine_Click(object sender, RoutedEventArgs e)
        {
            lesMagazines.Remove((Magazine)dtgMagazine.SelectedItem);
            //On préselectionne par défaut le premier élément du Datagrid après la suppression
            dtgMagazine.SelectedIndex = 0;
            dtgMagazine.Items.Refresh();
        }

        private void btnAjouterPigiste_Click(object sender, RoutedEventArgs e)
        {
            Bdd.InsertPigiste(txtNomPigiste.Text, txtPrenomPigiste.Text, txtAdressePigiste.Text, txtCPPigiste.Text, txtVillePigiste.Text, txtMailPigiste.Text, txtNumSecuPigiste.Text, txtContratCadrePigiste.Text);
            Bdd.SelectPigiste();
            dtgPigiste.Items.Refresh();
        }

        private void btnModifierPigiste_Click(object sender, RoutedEventArgs e)
        {
            //On recherche à quel indice de la collection se trouve l'object selectionné dans le datagrid
            int indice = lesPigistes.IndexOf((Pigiste)dtgPigiste.SelectedItem);

            // On change les propritétés de l'objet à l'indice trouvé. On ne change pas le numéro de magazine via l'interface, trop de risques d'erreurs en base de données
            lesPigistes.ElementAt(indice).Nom = txtNomPigiste.Text;
            lesPigistes.ElementAt(indice).Prenom = txtPrenomPigiste.Text;
            lesPigistes.ElementAt(indice).NumSecu = txtNumSecuPigiste.Text;
            lesPigistes.ElementAt(indice).ContratCadre = txtContratCadrePigiste.Text;
            lesPigistes.ElementAt(indice).Adresse = txtAdressePigiste.Text;
            lesPigistes.ElementAt(indice).Cp = txtCPPigiste.Text;
            lesPigistes.ElementAt(indice).Ville = txtVillePigiste.Text;
            lesPigistes.ElementAt(indice).Mail = txtMailPigiste.Text;

            dtgPigiste.Items.Refresh();
        }

        private void btnSupprimerPigiste_Click(object sender, RoutedEventArgs e)
        {
            lesPigistes.Remove((Pigiste)dtgPigiste.SelectedItem);
            //On préselectionne par défaut le premier élément du Datagrid après la suppression
            dtgPigiste.SelectedIndex = 0;
            dtgPigiste.Items.Refresh();
        }

        private void btnAjouterContrat_Click(object sender, RoutedEventArgs e)
        {
            // Récupération du Pigiste sélectionné dans le Combobox cboPigiste
            Pigiste ModifPigiste = cboPigiste.SelectedItem as Pigiste;

            // Récupération du Magazine sélectionné dans le Combobox cboMagazine
            Magazine ModifMagazine = cboMagazine.SelectedItem as Magazine;


            Bdd.InsertContrat(Convert.ToInt32(txtMontantBrutContrat.Text), Convert.ToInt32(txtMontantNetContrat.Text), (bool)chkAgessa.IsChecked, (bool)chkFacture.IsChecked, cboEtatContrat.SelectedIndex, Convert.ToInt16(Pigiste.NumPigiste), (Magazine)cboMagazine.SelectedItem);
            Bdd.SelectContrat();
            dtgContrat.Items.Refresh();
        }

        private void btnModifierContrat_Click(object sender, RoutedEventArgs e)
        {
            //On recherche à quel indice de la collection se trouve l'object selectionné dans le datagrid
            int indice = lesContrats.IndexOf((Contrat)dtgContrat.SelectedItem);

            // On change les propritétés de l'objet à l'indice trouvé. On ne change pas le numéro de magazine via l'interface, trop de risques d'erreurs en base de données
            lesContrats.ElementAt(indice).LettreAccord = txtLettreAccordContrat.Text;
            lesContrats.ElementAt(indice).MontantBrut = Convert.ToInt32(txtMontantBrutContrat.Text);
            lesContrats.ElementAt(indice).MontantNet = Convert.ToInt32(txtMontantNetContrat.Text);
            lesContrats.ElementAt(indice).Etat = cboEtatContrat.SelectedIndex;
            lesContrats.ElementAt(indice).LePigiste = (Pigiste)cboPigiste.SelectedItem;
            lesContrats.ElementAt(indice).LeMagazine = (Magazine)cboMagazine.SelectedItem;
            lesContrats.ElementAt(indice).Facture = (bool)chkFacture.IsChecked;
            lesContrats.ElementAt(indice).DeclarationAgessa = (bool)chkAgessa.IsChecked;

            dtgContrat.Items.Refresh();
        }

        private void btnSupprimerContrat_Click(object sender, RoutedEventArgs e)
        {

            Bdd.DeleteContrat(Convert.ToInt16(txtNumContrat.Text));

            
            lesContrats.Remove((Contrat)dtgContrat.SelectedItem);
            //On préselectionne par défaut le premier élément du Datagrid après la suppression
            dtgContrat.SelectedIndex = 0;
            dtgContrat.Items.Refresh();
        }

        private void txtMontantBrutContrat_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                double brut = Convert.ToDouble(txtMontantBrutContrat.Text);
                double ss = brut * 0.011;
                double csg = brut * 0.985 * 0.075;
                double crds = brut * 0.985 * 0.005;
                double fp = brut * 0.0035;
                double net = brut - Math.Floor(ss + csg + crds + fp);
                txtMontantNetContrat.Text = Convert.ToString(net);

            }
            catch (Exception)
            {
                txtMontantNetContrat.Text = "";
            }
        }
    }
}