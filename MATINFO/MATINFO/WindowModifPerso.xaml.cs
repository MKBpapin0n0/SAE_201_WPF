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
    /// Logique d'interaction pour WindowModifPerso.xaml
    /// </summary>
    /// 
    public enum ModePerso { Insert, Update };
    public partial class WindowModifPerso : Window
    {
        
        int idpersonnel;
        public WindowModifPerso(int idpersonnel, ModePerso mode)
        {
            InitializeComponent();
            this.idpersonnel = idpersonnel;
        }

        private void btValiderPerso_Click(object sender, RoutedEventArgs e)
        {
            ((Personnel)applicationData.LesPersonnels.Single(x => x.Idpersonnel == this.idpersonnel)).Nompersonnel = tbNomPerso.Text;
            ((Personnel)applicationData.LesPersonnels.Single(x => x.Idpersonnel == this.idpersonnel)).Update();

            ((Personnel)applicationData.LesPersonnels.Single(x => x.Idpersonnel == this.idpersonnel)).Prenompersonnel = tbPrenomPerso.Text;
            ((Personnel)applicationData.LesPersonnels.Single(x => x.Idpersonnel == this.idpersonnel)).Update();

            ((Personnel)applicationData.LesPersonnels.Single(x => x.Idpersonnel == this.idpersonnel)).Emailpersonnel = tbEmailPerso.Text;
            ((Personnel)applicationData.LesPersonnels.Single(x => x.Idpersonnel == this.idpersonnel)).Update();
            this.Close();
        }
    }
}
