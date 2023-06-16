using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour WindowModifMat.xaml
    /// </summary>
    /// 

    public enum ModeMat { Insert, Update };
    public partial class WindowModifMat : Window
    {
        
        int idmateriel;
        public WindowModifMat(int idmateriel, ModeMat mode)
        {
            InitializeComponent();
            this.idmateriel = idmateriel;
        }

        private void btValiderMateriel_Click(object sender, RoutedEventArgs e)
        {
            ((Materiel)applicationData.lesMateriels.Single(x => x.Idmateriel == this.idmateriel)).Nommateriel = tbNomMateriel.Text;
            ((Materiel)applicationData.lesMateriels.Single(x => x.Idmateriel == this.idmateriel)).Update();

            ((Materiel)applicationData.lesMateriels.Single(x => x.Idmateriel == this.idmateriel)).Referenceconstructeurmateriel = tbReference.Text;
            ((Materiel)applicationData.lesMateriels.Single(x => x.Idmateriel == this.idmateriel)).Update();

            ((Materiel)applicationData.lesMateriels.Single(x => x.Idmateriel == this.idmateriel)).Codebarreinventaire = tbCodeBarre.Text;
            ((Materiel)applicationData.lesMateriels.Single(x => x.Idmateriel == this.idmateriel)).Update();
            this.Close();
        }


    }
}
