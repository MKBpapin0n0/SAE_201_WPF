using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace MATINFO
{
    /// <summary>
    /// Initialiser les composants
    /// </summary>
    public partial class WindowAjouterAttribution : Window
    {
        int idpersonnel;
        int idmateriel;
        public WindowAjouterAttribution(int idpersonnel, int idmateriel)
        {
            InitializeComponent();
            this.idpersonnel = idpersonnel;
            this.idmateriel = idmateriel;


            foreach (Personnel perso in applicationData.lesPersonnels)
            {
                cbPersonnelAttribution.Items.Add(new ComboBoxItem()
                {
                    Content = perso.Nompersonnel,
                    Name = $"Categorie{perso.Idpersonnel}"
                });
            }

            foreach (Materiel mat in applicationData.lesMateriels)
            {
                cbMaterielAttribution.Items.Add(new ComboBoxItem()
                {
                    Content = mat.Nommateriel,
                    Name = $"Categorie{mat.Idmateriel}"
                });
            }
        }

        /// <summary>
        /// Cette méthode permet d'ajouter l'attribution dans la BDD
        /// </summary>
        private void btValiderMateriel_Click(object sender, RoutedEventArgs e)
        {
            Attribution attrib = new Attribution(int.Parse(((ComboBoxItem)cbPersonnelAttribution.SelectedItem).Name.ToString().Substring(9)), int.Parse(((ComboBoxItem)cbMaterielAttribution.SelectedItem).Name.ToString().Substring(9)), ((DateTime)dpDateAttribution.SelectedDate!), tbCommentaireAttribution.Text);
            applicationData.lesAttributions.Add(attrib);
            attrib.Create();
            this.Close();
        }

        /// <summary>
        /// Cette méthode permet d'avoir une Pop-up de confirmation pour annuler un ajout d'une attribution
        /// </summary>
        private void btAnnulerAttribution_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("En fermant cette fenêtre votre ajout d'une attrubtion sera annulé", "Confirmation Annulation modification", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

            if (result == MessageBoxResult.OK)
            {
                this.Close();
            }
        }
    }
}
