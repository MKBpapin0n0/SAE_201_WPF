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
        Mode leMode;
        int idmateriel;
        public WindowModifMat(int idmateriel, Mode mode)
        {
            InitializeComponent();

            
            foreach(Categorie categorie in applicationData.lesCategories)
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
                Materiel mat = new Materiel(Materiel.RecupeId(), int.Parse(((ComboBoxItem)cbCategorie.SelectedItem).Name.ToString().Substring(9)), tbNomMateriel.Text, tbReference.Text, tbReference.Text);
                applicationData.lesMateriels.Add(mat);
                mat.Create();
            }
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
