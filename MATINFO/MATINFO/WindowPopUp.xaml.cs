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
    /// L'enum 'Mode' permet d'avoir une seule Pop-up pour ajouter / modifier une catégorie
    /// </summary>
    public enum Mode { Insert, Update };
    public partial class WindowPopUp : Window
    {
        int idcategorie;
        Mode leMode;

        /// <summary>
        /// Elle initialise les composants et elle permet de changer le content du bouton selon le mode
        /// </summary>
        /// <param name="idcategorie">ce paramètre permet de récupérer ou créer l'id d'une catégorie dans la BDD</param>
        /// <param name="mode">ce paramètre sert a connaitre le mode de la Pop-up</param>
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

        /// <summary>
        /// Le code du bouton 'valider' de la Pop-up permet d'ajouter si leMode est Insert ou de modifier si leMode est Update dans la BDD
        /// </summary>
        /// <param name="sender">l'objet qui appelle la méthode. Elle regarde si le bouton valider a été appuyé</param>
        /// <param name="e">est un argument</param>
        private void btValiderPopUp_Click(object sender, RoutedEventArgs e)
        {
            if (Mode.Update == leMode)
            {
                ((Categorie)applicationData.lesCategories.Single(x => x.Idcategorie == this.idcategorie)).Nomcategorie = tbPopUp.Text;
                ((Categorie)applicationData.lesCategories.Single(x => x.Idcategorie == this.idcategorie)).Update();
            }
            else if (Mode.Insert == leMode)
            {
                Categorie cat = new Categorie(Categorie.RecupeId(), tbPopUp.Text);
                applicationData.lesCategories.Add(cat);
                cat.Create();
            }
            this.Close();
        }

        /// <summary>
        /// Le bouton annuler permet de revenir sur la page principale sans avoir fait de modification ou d'ajout dans une catégorie
        /// </summary>
        /// <param name="sender">l'objet qui appelle la méthode. Elle reagarde si le bouton annuler a été appuyé</param>
        /// <param name="e">est un argument</param>
        private void btAnnulerPopUp_Click(object sender, RoutedEventArgs e)
        {
            if (Mode.Update == leMode)
            {
                var result = MessageBox.Show("En fermant cette fenêtre votre modification d'une categorie sera annulé", "Confirmation Annulation modification", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                if (result == MessageBoxResult.OK)
                {
                    this.Close();
                }
            }
            else if (Mode.Insert == leMode)
            {
                var result = MessageBox.Show("En fermant cette fenêtre votre ajout d'une catégorie sera annulé", "Confirmation Annulation ajout", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                if (result == MessageBoxResult.OK)
                {
                    this.Close();
                }
            }
        }
    }
}
