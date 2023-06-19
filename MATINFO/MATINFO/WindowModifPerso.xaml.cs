using System;
using System.Collections.Generic;
using System.IO;
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
//V.AB

namespace MATINFO
{
    public partial class WindowModifPerso : Window
    {
        Mode leMode;
        int idpersonnel;

        /// <summary>
        /// Elle initialise les composants et elle permet de changer le content du bouton selon le mode
        /// </summary>
        /// <param name="idpersonnel">ce paramètre permet de récupérer ou créer l'id d'un personnel dans la BDD</param>
        /// <param name="mode">ce paramètre sert a connaitre le mode de la Pop-up</param>
        public WindowModifPerso(int idpersonnel, Mode mode)
        {
            InitializeComponent();
            this.idpersonnel = idpersonnel;
            this.leMode = mode;

            if (mode == Mode.Update)
            {
                btValiderPerso.Content = "Modifier";
                this.Title = "Modifier Personnel";
            }
            else if (mode == Mode.Insert)
            {
                btValiderPerso.Content = "Ajouter";
                this.Title = "Ajouter Personnel";
            }
        }

        /// <summary>
        /// Le code du bouton 'valider' de la Pop-up permet d'ajouter si leMode est Insert ou de modifier si leMode est Update dans la BDD avec le regex
        /// </summary>
        /// <param name="sender">l'objet qui appelle la méthode. Elle regarde si le bouton valider a été appuyé</param>
        /// <param name="e">est un argument</param>
        private void btValiderPerso_Click(object sender, RoutedEventArgs e)
        {
            // on doit déclencher la mise à jour du binding
            if (Mode.Update == leMode)
            {
                ((Personnel)applicationData.lesPersonnels.Single(x => x.Idpersonnel == this.idpersonnel)).Nompersonnel = tbNomPerso.Text;
                ((Personnel)applicationData.lesPersonnels.Single(x => x.Idpersonnel == this.idpersonnel)).Update();

                ((Personnel)applicationData.lesPersonnels.Single(x => x.Idpersonnel == this.idpersonnel)).Prenompersonnel = tbPrenomPerso.Text;
                ((Personnel)applicationData.lesPersonnels.Single(x => x.Idpersonnel == this.idpersonnel)).Update();

                ((Personnel)applicationData.lesPersonnels.Single(x => x.Idpersonnel == this.idpersonnel)).Emailpersonnel = tbEmailPerso.Text;
                ((Personnel)applicationData.lesPersonnels.Single(x => x.Idpersonnel == this.idpersonnel)).Update();
            }
            else if (Mode.Insert == leMode)
            {
                if (ValidationEmail(tbEmailPerso.Text) == true)
                {
                    Personnel perso = new Personnel(Personnel.RecupeId(), tbEmailPerso.Text, tbNomPerso.Text, tbPrenomPerso.Text);
                    applicationData.lesPersonnels.Add(perso);
                    perso.Create();
                }
                else
                {
                    MessageBox.Show("Email non-conforme", "Email Non-Conforme", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                }
            }
            this.Close();
        }

        /// <summary>
        /// Cette méthode permet de montrer une Pop-up de confirmation d'annulation si on appuye sur le bouton annuler
        /// </summary>
        /// <param name="sender">l'objet qui appelle la méthode. Elle regarde si le bouton annuler a été appuyé</param>
        /// <param name="e">est un argument</param>
        private void btAnnulerPerso_Click(object sender, RoutedEventArgs e)
        {
            if (Mode.Update == leMode)
            {
                var result = MessageBox.Show("En fermant cette fenêtre votre modification d'un personnel sera annulé", "Confirmation Annulation modification", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                if (result == MessageBoxResult.OK)
                {
                    this.Close();
                }
            }
            else if (Mode.Insert == leMode)
            {
                var result = MessageBox.Show("En fermant cette fenêtre votre ajout d'un personnel sera annulé", "Confirmation Annulation ajout", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                if (result == MessageBoxResult.OK)
                {
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Permet d'avoir les regex demander
        /// </summary>
        static bool ValidationEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }
    }
}