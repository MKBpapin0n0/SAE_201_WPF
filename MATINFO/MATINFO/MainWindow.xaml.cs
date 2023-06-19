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
//V.AB

namespace MATINFO
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Sert a initialiser les composants
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cette méthode permet de supprimer une catégorie si une catégorie est sélectionné, sinon mettre une Pop-up d'erreur si aucune catégorie n'est sélectionné
        /// </summary>
        /// <param name="sender">l'objet qui appelle la méthode. Elle regarde si le bouton supprimé a été appuyé pour une catégorie</param>
        /// <param name="e">est un argument</param>
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

        /// <summary>
        /// Cette méthode permet de supprimer un matériel si un matériel est sélectionné, sinon mettre une Pop-up d'erreur si aucun matériel n'est sélectionné
        /// </summary>
        /// <param name="sender">l'objet qui appelle la méthode. Elle regarde si le bouton supprimé a été appuyé pour un matériel</param>
        /// <param name="e">est un argument</param>
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

        /// <summary>
        /// Cette méthode permet de supprimer un personnel si un personnel est sélectionné, sinon mettre une Pop-up d'erreur si aucun personnel n'est sélectionné
        /// </summary>
        /// <param name="sender">l'objet qui appelle la méthode. Elle regarde si le bouton supprimé a été appuyé pour un personnel</param>
        /// <param name="e">est un argument</param>
        private void btSupprimerPersonnel_Click(object sender, RoutedEventArgs e)
        {
            if (lvPersonnel.SelectedItem != null)
            {

                var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette personne ?", "Confirmation de suppression", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    // Supprimer la categorie sélectionnée de la liste
                    ((Personnel)lvPersonnel.SelectedItem).Delete();
                    applicationData.lesPersonnels.Remove(((Personnel)lvPersonnel.SelectedItem));
                    lvPersonnel.Items.Refresh();
                }
            }
            else
            {
                var ok = MessageBox.Show("Sélectionnez un personnel pour le supprimer", "Selection supression", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Cette méthode permet de modifier une catégorie si une catégorie est sélectionné, sinon mettre une Pop-up d'erreur si aucune catégorie n'est sélectionné
        /// </summary>
        /// <param name="sender">l'objet qui appelle la méthode. Elle regarde si le bouton modifier a été appuyé pour une catégorie</param>
        /// <param name="e">est un argument</param>
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

        /// <summary>
        /// Cette méthode permet de modifier un matériel si un matériel est sélectionné, sinon mettre une Pop-up d'erreur si aucun matériel n'est sélectionné
        /// </summary>
        /// <param name="sender">l'objet qui appelle la méthode. Elle regarde si le bouton modifier a été appuyé pour un matériel</param>
        /// <param name="e">est un argument</param>
        private void btModifierMateriel_Click(object sender, RoutedEventArgs e)
        {

            if (lvMateriel.SelectedItem != null)
            {
                new WindowModifMat(((Materiel)lvMateriel.SelectedItem).Idmateriel, Mode.Update).ShowDialog();
                applicationData.Refresh();

                lvMateriel.ItemsSource = applicationData.lesMateriels;


            }

            else
            {
                var ok = MessageBox.Show("Sélectionnez un matériel pour la modifier", "Selection supression", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Cette méthode permet de modifier un personnel si un personnel est sélectionné, sinon mettre une Pop-up d'erreur si aucun personnel n'est sélectionné
        /// </summary>
        /// <param name="sender">l'objet qui appelle la méthode. Elle regarde si le bouton modifier a été appuyé pour un personnel</param>
        /// <param name="e">est un argument</param>
        private void btModifierPersonnel_Click(object sender, RoutedEventArgs e)
        {
            if (lvPersonnel.SelectedItem != null)
            {
                new WindowModifPerso(((Personnel)lvPersonnel.SelectedItem).Idpersonnel, Mode.Update).ShowDialog();
                applicationData.Refresh();

                lvPersonnel.ItemsSource = applicationData.lesPersonnels;

            }

            else
            {
                var ok = MessageBox.Show("Sélectionnez un personnel pour la modifier", "Selection supression", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Cette méthode permet d'ajouter une catégorie
        /// </summary>
        /// <param name="sender">l'objet qui appelle la méthode. Elle regarde si le bouton ajouter a été appuyé pour une catégorie</param>
        /// <param name="e">est un argument</param>
        private void btAjouterCategorie_Click(object sender, RoutedEventArgs e)
        {
            new WindowPopUp(0, Mode.Insert).ShowDialog();
            applicationData.Refresh();

            lvCategorie.ItemsSource = applicationData.lesCategories;
        }

        /// <summary>
        /// Cette méthode permet d'ajouter un matériel
        /// </summary>
        /// <param name="sender">l'objet qui appelle la méthode. Elle regarde si le bouton ajouter a été appuyé pour un matériel</param>
        /// <param name="e">est un argument</param>
        private void btAjouterPersonnel_Click(object sender, RoutedEventArgs e)
        {
            new WindowModifPerso(0, Mode.Insert).ShowDialog();
            applicationData.Refresh();

            lvPersonnel.ItemsSource = applicationData.lesPersonnels;
        }

        /// <summary>
        /// Cette méthode permet d'ajouter un personnel
        /// </summary>
        /// <param name="sender">l'objet qui appelle la méthode. Elle regarde si le bouton ajouter a été appuyé pour un personnel</param>
        /// <param name="e">est un argument</param>
        private void btAjouterMateriel_Click(object sender, RoutedEventArgs e)
        {
            new WindowModifMat(0, Mode.Insert).ShowDialog();
            applicationData.Refresh();

            lvMateriel.ItemsSource = applicationData.lesMateriels;
        }

        /// <summary>
        /// Cette méthode permet d'afficher toute les attributions, catégories, matériels et personnels
        /// </summary>
        /// <param name="sender">l'objet qui appelle la méthode. Elle regarde si le bouton 'tout afficher' a été appuyé pour un personnel</param>
        /// <param name="e">est un argument</param>
        private void btToutAfficher_Click(object sender, RoutedEventArgs e)
        {
            lvMateriel.DataContext = null;
            lvMateriel.ItemsSource = applicationData.lesMateriels;

            lvAttribution.DataContext = null;
            lvAttribution.ItemsSource = applicationData.lesAttributions;
        }

        /// <summary>
        /// Cette méthode regarde si la sélection du personnel dans la listview a été changer
        /// </summary>
        /// <param name="sender">l'objet qui appelle la méthode. Elle regarde si la sélection du personnel dans la listview a été changer</param>
        /// <param name="e">est un argument</param>
        private void lvPersonnel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvPersonnel.SelectedItem != null)
            {
                Personnel selectedPersonnel = lvPersonnel.SelectedItem as Personnel;
                lvAttribution.ItemsSource = applicationData.lesAttributions
                    .Where(attribution => attribution.UnPersonnel == selectedPersonnel).ToList();
            }
            else
            {
                lvAttribution.ItemsSource = null;
            }
        }

        /// <summary>
        /// Cette méthode regarde si la sélection de la catégorie dans la listview a été changer
        /// </summary>
        /// <param name="sender">l'objet qui appelle la méthode. Elle regarde si la sélection de la catégorie dans la listview a été changer</param>
        /// <param name="e">est un argument</param>
        private void lvCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Binding pour le DataContext du ListView
            Binding dataContextBinding = new Binding("SelectedItem");
            dataContextBinding.ElementName = "lvCategorie";
            lvMateriel.SetBinding(ListView.DataContextProperty, dataContextBinding);

            // Binding pour l'ItemsSource du ListView
            Binding itemsSourceBinding = new Binding("lesMateriels");
            lvMateriel.SetBinding(ListView.ItemsSourceProperty, itemsSourceBinding);

            if (lvCategorie.SelectedItem != null)
            {
                Categorie selectedCategorie = lvCategorie.SelectedItem as Categorie;
                lvAttribution.ItemsSource = applicationData.lesAttributions.Where(attribution => attribution.UnMateriel.UneCategorie == selectedCategorie).ToList();
            }
            else
            {
                lvAttribution.ItemsSource = null;
            }
        }

        /// <summary>
        /// Cette méthode regarde si la sélection du matériel dans la listview a été changer
        /// </summary>
        /// <param name="sender">l'objet qui appelle la méthode. Elle regarde si la sélection du matériel dans la listview a été changer</param>
        /// <param name="e">est un argument</param>
        private void lvMateriel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvMateriel.SelectedItem != null)
            {
                Materiel selectedMateriel = lvMateriel.SelectedItem as Materiel;
                lvAttribution.ItemsSource = applicationData.lesAttributions
                    .Where(attribution => attribution.UnMateriel == selectedMateriel)
                    .ToList();
            }
            else
            {
                lvAttribution.ItemsSource = null;
            }
        }


        private void btSupprimerAttribution_Click(object sender, RoutedEventArgs e)
        {
            if (lvAttribution.SelectedItem != null)
            {

                var result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette attribution ?", "Confirmation de suppression", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    // Supprimer la categorie sélectionnée de la liste
                    ((Attribution)lvAttribution.SelectedItem).Delete();
                    applicationData.lesAttributions.Remove(((Attribution)lvAttribution.SelectedItem));
                    lvAttribution.Items.Refresh();
                }
            }
            else
            {
                var ok = MessageBox.Show("Sélectionnez une attribution pour la supprimer", "Selection supression", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void btAjouterAttribution_Click(object sender, RoutedEventArgs e)
        {
            new WindowAjouterAttribution(0, 0).ShowDialog();

            applicationData.Refresh();
            lvAttribution.ItemsSource = applicationData.lesAttributions;


        }


        private void btModifierAttribution_Click(object sender, RoutedEventArgs e)
        {
            if (lvAttribution.SelectedItem != null)
            {
                new WindowModifAttrib(((Attribution)lvAttribution.SelectedItem).FK_Idpersonnel, ((Attribution)lvAttribution.SelectedItem).FK_Idmateriel, ((Attribution)lvAttribution.SelectedItem).Dateattribution).ShowDialog();
                applicationData.Refresh();

                lvAttribution.ItemsSource = applicationData.lesAttributions;
            }
            else
            {
                var ok = MessageBox.Show("Sélectionnez une attribution pour la modifier", "Selection supression", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
