using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
    /// <summary>
    /// Logique d'interaction pour WindowModifPerso.xaml
    /// </summary>
    /// 
    
    public partial class WindowModifPerso : Window
    {
        Mode leMode;
        int idpersonnel;
        public WindowModifPerso(int idpersonnel, Mode mode)
        {
            InitializeComponent();
            this.idpersonnel = idpersonnel;
            this.leMode = mode;

            if (mode == Mode.Update)
            {
                btValiderPerso.Content = "Modifier";
                this.Title = "Modifier Catégorie";
            }
            else if (mode == Mode.Insert)
            {
                btValiderPerso.Content = "Ajouter";
                this.Title = "Ajouter Catégorie";
            }
        }

        private void btValiderPerso_Click(object sender, RoutedEventArgs e)
        {
            // on doit déclencher la mise à jour du binding
            if (Mode.Update == leMode)
            {
                ((Personnel)applicationData.LesPersonnels.Single(x => x.Idpersonnel == this.idpersonnel)).Nompersonnel = tbNomPerso.Text;
                ((Personnel)applicationData.LesPersonnels.Single(x => x.Idpersonnel == this.idpersonnel)).Update();

                ((Personnel)applicationData.LesPersonnels.Single(x => x.Idpersonnel == this.idpersonnel)).Prenompersonnel = tbPrenomPerso.Text;
                ((Personnel)applicationData.LesPersonnels.Single(x => x.Idpersonnel == this.idpersonnel)).Update();

                ((Personnel)applicationData.LesPersonnels.Single(x => x.Idpersonnel == this.idpersonnel)).Emailpersonnel = tbEmailPerso.Text;
                ((Personnel)applicationData.LesPersonnels.Single(x => x.Idpersonnel == this.idpersonnel)).Update();
            }
            else if (Mode.Insert == leMode)
            {
                Personnel perso = new Personnel(Personnel.RecupeId(), tbNomPerso.Text, tbPrenomPerso.Text, tbEmailPerso.Text);
                applicationData.LesPersonnels.Add(perso);
                perso.Create();
            }
            this.Close();
        }
    }
}
