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

namespace MATINFO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btSupprimerCategorie_Click(object sender, RoutedEventArgs e)
        {
            if (lvCategorie.SelectedItem != null)
            {

                var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette catégorie ?", "Confirmation de suppression", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    // Supprimer la categorie sélectionnée de la liste
                    ((Categorie)lvCategorie.SelectedItem).Delete();
                    applicationData.lesCategories.Remove(((Categorie)lvCategorie.SelectedItem));
                    lvCategorie.Items.Refresh();
                }
            }
            else
            {
                var ok = MessageBox.Show("Sélectionnez une catégorie pour la supprimer", "Selection supression", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void btSupprimerMateriel_Click(object sender, RoutedEventArgs e)
        {
            if (lvMateriel.SelectedItem != null)
            {

                var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce matériel ?", "Confirmation de suppression", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    // Supprimer la categorie sélectionnée de la liste
                    ((Materiel)lvMateriel.SelectedItem).Delete();
                    applicationData.lesMateriels.Remove(((Materiel)lvMateriel.SelectedItem));
                    lvMateriel.Items.Refresh();

                }
            }
            else
            {
                var ok = MessageBox.Show("Sélectionnez un matériel pour le supprimer", "Selection supression", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btSupprimerPersonnel_Click(object sender, RoutedEventArgs e)
        {
            if (lvPersonnel.SelectedItem != null)
            {

                var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette personne ?", "Confirmation de suppression", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    // Supprimer la categorie sélectionnée de la liste
                    ((Personnel)lvPersonnel.SelectedItem).Delete();
                    applicationData.LesPersonnels.Remove(((Personnel)lvPersonnel.SelectedItem));
                    lvPersonnel.Items.Refresh();
                }
            }
            else
            {
                var ok = MessageBox.Show("Sélectionnez un personnel pour le supprimer", "Selection supression", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btModifierCategorie_Click(object sender, RoutedEventArgs e)
        {

            if (lvCategorie.SelectedItem != null)
            {
                new WindowPopUp(((Categorie)lvCategorie.SelectedItem).Idcategorie, Mode.Update).ShowDialog();
                applicationData.Refresh();

                lvCategorie.ItemsSource = applicationData.lesCategories;


            }

            else
            {
                var ok = MessageBox.Show("Sélectionnez une catégorie pour la modifier", "Selection supression", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        private void btModifierMateriel_Click(object sender, RoutedEventArgs e)
        {

            if (lvMateriel.SelectedItem != null)
            {
                new WindowModifMat(((Materiel)lvMateriel.SelectedItem).Idmateriel, ModeMat.Update).ShowDialog();
                applicationData.Refresh();

                lvMateriel.ItemsSource = applicationData.lesMateriels;


            }

            else
            {
                var ok = MessageBox.Show("Sélectionnez un matériel pour la modifier", "Selection supression", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btModifierPersonnel_Click(object sender, RoutedEventArgs e)
        {
            if (lvPersonnel.SelectedItem != null)
            {
                new WindowModifPerso(((Personnel)lvPersonnel.SelectedItem).Idpersonnel, ModePerso.Update).ShowDialog();
                applicationData.Refresh();

                lvPersonnel.ItemsSource = applicationData.LesPersonnels;

            }

            else
            {
                var ok = MessageBox.Show("Sélectionnez un personnel pour la modifier", "Selection supression", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btAjouterCategorie_Click(object sender, RoutedEventArgs e)
        {
            new WindowPopUp(0, Mode.Insert).ShowDialog();
            applicationData.Refresh();

            lvCategorie.ItemsSource = applicationData.lesCategories;
        }
    }
}
