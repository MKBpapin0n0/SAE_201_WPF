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
    public partial class WindowPopUp : Window
    {
        int idcategorie;
        public WindowPopUp(int idcategorie)
        {
            InitializeComponent();
            this.idcategorie = idcategorie;
        }

        private void btValiderPopUp_Click(object sender, RoutedEventArgs e)
        {
            // on doit déclencher la mise à jour du binding

            ((Categorie)applicationData.lesCategories.Single(x => x.Idcategorie == this.idcategorie)).Nomcategorie = tbPopUp.Text;
            ((Categorie)applicationData.lesCategories.Single(x => x.Idcategorie == this.idcategorie)).Update();
            this.Close();
        }
    }
}
