using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MATINFO
{
    public class ApplicationData
    {
        public ObservableCollection<Personnel> lesPersonnels { get; set; }

        public ObservableCollection<Materiel> lesMateriels { get; set; }

        public ObservableCollection<Categorie> lesCategories { get; set; }

        public ObservableCollection<Attribution> lesAttributions { get; set; }

        public ApplicationData()
        {
            Refresh();
        }
        public void Refresh()
        {
            Personnel e = new Personnel();
            lesPersonnels = e.FindAll();

            Materiel m = new Materiel();
            lesMateriels = m.FindAll();

            Categorie c = new Categorie();
            lesCategories = c.FindAll();

            Attribution a = new Attribution();
            lesAttributions = a.FindAll();


            // pour chaque materiel, on affecte la référence de son categorie
            foreach (Materiel unMat in lesMateriels.ToList())
            {
                unMat.UneCategorie = lesCategories.ToList().Find(g => g.Idcategorie == unMat.FK_Idcategorie);
            }
            // pour chaque categorie, on affecte toutes les références des materiels appartenant au categorie
            foreach (Categorie uneCat in lesCategories.ToList())
            {
                uneCat.lesMateriels = new ObservableCollection<Materiel>(
                lesMateriels.ToList().FindAll(e => e.FK_Idcategorie == uneCat.Idcategorie));
            }



            // pour chaque Attribution, on affecte la référence de son materiel
            foreach (Attribution uneAttrib in lesAttributions.ToList())
            {
                uneAttrib.UnMateriel = lesMateriels.ToList().Find(g => g.Idmateriel == uneAttrib.FK_Idmateriel);
            }
            // pour chaque matériel, on affecte toutes les références des attributions appartenant au matériel
            foreach (Materiel unMater in lesMateriels.ToList())
            {
                unMater.lesAttributions = new ObservableCollection<Attribution>(
                lesAttributions.ToList().FindAll(e => e.FK_Idmateriel == unMater.Idmateriel));
            }



            // pour chaque Attribution, on affecte la référence de son personnel
            foreach (Attribution uneAttrib in lesAttributions.ToList())
            {
                uneAttrib.UnPersonnel = lesPersonnels.ToList().Find(g => g.Idpersonnel == uneAttrib.FK_Idpersonnel);
            }
            // pour chaque personnel, on affecte toutes les références des attributions appartenant au personnel
            foreach (Personnel unPerso in lesPersonnels.ToList())
            {
                unPerso.lesAttributions = new ObservableCollection<Attribution>(
                lesAttributions.ToList().FindAll(e => e.FK_Idpersonnel == unPerso.Idpersonnel));
            }





            //ATTENTION CECI EST A TITRE EXPERIMENTAL
            // pour chaque materiel, on affecte la référence de son categorie
            foreach (Personnel unPers in lesPersonnels.ToList())
            {
                unPers.UneAttribution = lesAttributions.ToList().Find(g => g.FK_Idpersonnel == unPers.Idpersonnel);
            }
            // pour chaque categorie, on affecte toutes les références des materiels appartenant au categorie
            foreach (Attribution uneAttrib in lesAttributions.ToList())
            {
                uneAttrib.lesPersonnels = new ObservableCollection<Personnel>(
                lesPersonnels.ToList().FindAll(e => e.Idpersonnel == uneAttrib.FK_Idpersonnel));
            }
        }
    }
}
