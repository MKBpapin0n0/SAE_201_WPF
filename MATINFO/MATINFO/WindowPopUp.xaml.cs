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
using System.Windows.Shapes;

namespace MATINFO
{
    /// <summary>
    /// Logique d'interaction pour WindowPopUp.xaml
    /// </summary>
    
    public enum Mode { Insert, Update};
    public partial class WindowPopUp : Window
    {
        int idcategorie;
        Mode leMode;
        public WindowPopUp(int idcategorie, Mode mode)
        {
            InitializeComponent();
            this.idcategorie = idcategorie;
            this.leMode = mode;

            if (mode == Mode.Update)
            {
                btValiderPopUp.Content = "Modifier";
                this.Title = "Modifier Catégorie";
            }
            else if (mode == Mode.Insert)
            {
                btValiderPopUp.Content = "Ajouter";
                this.Title = "Ajouter Catégorie";
            }
        }

        private void btValiderPopUp_Click(object sender, RoutedEventArgs e)
        {

            // on doit déclencher la mise à jour du binding
            if (Mode.Update == leMode)
            {
                ((Categorie)applicationData.lesCategories.Single(x => x.Idcategorie == this.idcategorie)).Nomcategorie = tbPopUp.Text;
                ((Categorie)applicationData.lesCategories.Single(x => x.Idcategorie == this.idcategorie)).Update();
        }
            else if (Mode.Insert == leMode)
            {
                Categorie cat = new Categorie(Categorie.RecupeId(),tbPopUp.Text);
                applicationData.lesCategories.Add(cat);
                cat.Create();
    }
            this.Close();
        }

        private void btAnnulerPopUp_Click(object sender, RoutedEventArgs e)
        {
            if (Mode.Update == leMode)
            {
                var result = MessageBox.Show("En fermant cette fenêtre votre modification d'une categorie sera annulé", "Confirmation Annulation modification", MessageBoxButton.OKCancel, MessageBoxImage.Question);

                if (result == MessageBoxResult.OK)
                {
                    this.Close();
                }
            }
            else if (Mode.Insert == leMode)
            {
                var result = MessageBox.Show("En fermant cette fenêtre votre ajout d'une catégorie sera annulé", "Confirmation Annulation ajout", MessageBoxButton.OKCancel, MessageBoxImage.Question);

                if (result == MessageBoxResult.OK)
                {
                    this.Close();
                }
            }
        }
    }
}
