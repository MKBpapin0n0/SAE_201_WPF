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
    public partial class WindowModifAttrib : Window
    {
        int idmateriel;
        int idpersonnel;
        DateTime date;
        public WindowModifAttrib(int idpersonnel, int idmateriel, DateTime date)
        {
            InitializeComponent();

            this.idmateriel = idmateriel;
            this.idpersonnel = idpersonnel;
            this.date = date;


        }

        /// <summary>
        /// Cette méthode permet d'ajouter l'attribution dans la BDD
        /// </summary>
        private void btValiderMateriel_Click(object sender, RoutedEventArgs e)
        {
            Attribution attribution = ((Attribution)applicationData.lesAttributions.Single(x => x.FK_Idpersonnel == this.idpersonnel && x.FK_Idmateriel == this.idmateriel && x.Dateattribution == this.date));

            attribution.Commentaireattribution = tbCommentaireAttribution.Text;

            attribution.Dateattribution = ((DateTime)dpDateAttribution.SelectedDate!);


            attribution.Update();

            this.Close();
        }

        /// <summary>
        /// Cette méthode permet d'avoir une Pop-up de confirmation pour annuler une modification d'une attribution
        /// </summary>
        private void btAnnulerAttribution_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("En fermant cette fenêtre votre modification d'une attrubtion sera annulé", "Confirmation Annulation modification", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

            if (result == MessageBoxResult.OK)
                {
                    this.Close();
                }
        }
    }
}
