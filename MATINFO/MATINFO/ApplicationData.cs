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
        public ObservableCollection<Personnel> LesPersonnels { get; set; }

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
            LesPersonnels = e.FindAll();

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





            // pour chaque materiel, on affecte la référence de son categorie
            foreach (Personnel unPers in LesPersonnels.ToList())
            {
                unPers.UneAttribution = lesAttributions.ToList().Find(g => g.FK_Idpersonnel == unPers.Idpersonnel);
            }
            // pour chaque categorie, on affecte toutes les références des materiels appartenant au categorie
            foreach (Attribution uneAttrib in lesAttributions.ToList())
            {
                uneAttrib.lesPersonnels = new ObservableCollection<Personnel>(
                LesPersonnels.ToList().FindAll(e => e.Idpersonnel == uneAttrib.FK_Idpersonnel));
            }
        }
    }
}
