using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MATINFO
{
    public partial class WindowModifMat : Window
    {
        Mode leMode;
        int idmateriel;

        /// <summary>
        /// Elle initialise les composants et elle permet de changer le content du bouton selon le mode, elle permet aussi d'avoir les items catégories dans la combobox
        /// </summary>
        /// <param name="idmateriel">ce paramètre permet de récupérer ou créer l'id d'un matériel dans la BDD</param>
        /// <param name="mode">ce paramètre sert a connaitre le mode de la Pop-up</param>
        public WindowModifMat(int idmateriel, Mode mode)
        {
            InitializeComponent();


            foreach (Categorie categorie in applicationData.lesCategories)
            {
                cbCategorie.Items.Add(new ComboBoxItem()
                {
                    Content = categorie.Nomcategorie,
                    Name = $"Categorie{categorie.Idcategorie}"
                });
            }
            
            this.idmateriel = idmateriel;
            this.leMode = mode;

            
            if (mode == Mode.Update)
            {
                btValiderMateriel.Content = "Modifier";
                this.Title = "Modifier Matériel";
            }
            else if (mode == Mode.Insert)
            {
                btValiderMateriel.Content = "Ajouter";
                this.Title = "Ajouter Matériel";
            }
        }

        /// <summary>
        /// Le code du bouton 'valider' de la Pop-up permet d'ajouter si leMode est Insert ou de modifier si leMode est Update dans la BDD avec les regex
        /// </summary>
        /// <param name="sender">l'objet qui appelle la méthode. Elle regarde si le bouton valider a été appuyé</param>
        /// <param name="e">est un argument</param>
        private void btValiderMateriel_Click(object sender, RoutedEventArgs e)
        {
            // on doit déclencher la mise à jour du binding
            if (Mode.Update == leMode)
            {
                ((Materiel)applicationData.lesMateriels.Single(x => x.Idmateriel == this.idmateriel)).Nommateriel = tbNomMateriel.Text;
                ((Materiel)applicationData.lesMateriels.Single(x => x.Idmateriel == this.idmateriel)).Update();

                ((Materiel)applicationData.lesMateriels.Single(x => x.Idmateriel == this.idmateriel)).Referenceconstructeurmateriel = tbNomMateriel.Text;
                ((Materiel)applicationData.lesMateriels.Single(x => x.Idmateriel == this.idmateriel)).Update();

                ((Materiel)applicationData.lesMateriels.Single(x => x.Idmateriel == this.idmateriel)).Codebarreinventaire = tbNomMateriel.Text;
                ((Materiel)applicationData.lesMateriels.Single(x => x.Idmateriel == this.idmateriel)).Update();
            }
            else if (Mode.Insert == leMode)
            {
                if (ValidationCodeBarre(tbCodeBarre.Text) == true)
                {
                    if (ValidationReference(tbReference.Text) == true)
                    {
                        Materiel mat = new Materiel(Materiel.RecupeId(), int.Parse(((ComboBoxItem)cbCategorie.SelectedItem).Name.ToString().Substring(9)), tbNomMateriel.Text, tbReference.Text.ToUpper(), tbCodeBarre.Text.ToUpper());
                        applicationData.lesMateriels.Add(mat);
                        mat.Create();
                    }
                    else
                    {
                        MessageBox.Show("Reference non-conforme", "ERROR", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Codebarre non-conforme", "ERROR", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                }
            }
            this.Close();
        }

        /// <summary>
        ///  Cette méthode permet de montrer une Pop-up de confirmation d'annulation si on appuye sur le bouton annuler
        /// </summary>
        /// <param name="sender">l'objet qui appelle la méthode. Elle regarde si le bouton annuler a été appuyé</param>
        /// <param name="e">est un argument</param>
        private void btAnnulerMateriel_Click(object sender, RoutedEventArgs e)
        {
            if (Mode.Update == leMode)
            {
                var result = MessageBox.Show("En fermant cette fenêtre votre modification d'un matériel sera annulé", "Confirmation Annulation modification", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                if (result == MessageBoxResult.OK)
                {
                    this.Close();
                }
            }
            else if (Mode.Insert == leMode)
            {
                var result = MessageBox.Show("En fermant cette fenêtre votre ajout d'un matériel sera annulé", "Confirmation Annulation ajout", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                if (result == MessageBoxResult.OK)
                {
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Permet d'avoir les regex demander
        /// </summary>
        static bool ValidationCodeBarre(string codebarre)
        {
            string pattern = @"^[A-Za-z]{5}\d{7}[A-Za-z]{3}$";
            return Regex.IsMatch(codebarre, pattern);
        }

        static bool ValidationReference(string reference)
        {
            string pattern = @"^[A-Za-z]-\d{3}[A-Za-z]{6}$";
            return Regex.IsMatch(reference, pattern);
        }
    }
}
