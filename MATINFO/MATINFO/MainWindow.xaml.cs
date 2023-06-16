﻿using System;
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
                    ApplicationData.lesCategories.Remove(((Categorie)lvCategorie.SelectedItem));
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
                    ApplicationData.lesMateriels.Remove(((Materiel)lvMateriel.SelectedItem));
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
                    ApplicationData.LesPersonnels.Remove(((Personnel)lvPersonnel.SelectedItem));
                    lvPersonnel.Items.Refresh();
                }
            }
            else
            {
                var ok = MessageBox.Show("Sélectionnez un personnel pour le supprimer", "Selection supression", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
