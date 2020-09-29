using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Bourse.Outils;
using Bourse.Modele;

namespace Bourse.VuesModele
{
	class Societe_VM : INotifyPropertyChanged
   {
      //private SocieteADO societeADO = new SocieteADO();
      public ICommand cmdAjouter_Societe { get; set; }
      public ICommand cmdModifier_Societe { get; set; }
      public ICommand cmdSupprimer_Societe { get; set; }
	  public ICommand cmdVider_Societe { get; set; }

		public Societe_VM()
		{
			cmdAjouter_Societe = new Commande(cmdAjouter);
			cmdModifier_Societe = new Commande(cmdModifier);
			cmdSupprimer_Societe = new Commande(cmdSupprimer);
			cmdVider_Societe = new Commande(cmdVider);
			// SommaireSocietes = societeADO.Recuperer();
			SommaireSocietes = new ObservableCollection<Societe>();
			var sRequete = from soc in OutilEF.BrsCtx.LEconomie.Include("Actionnaires.Acheteur") select soc;

			foreach (Societe s in sRequete)
				SommaireSocietes.Add(s);
		}

		private ObservableCollection<Societe> _sommaireSocietes;

		public ObservableCollection<Societe> SommaireSocietes
      {
         get { return _sommaireSocietes; }
         set
         {
            _sommaireSocietes = value;
            OnPropertyChanged("SommaireSocietes");
         }
      }

		private Societe _societeSelectionnee;

		public Societe SocieteSelectionnee
		{
			get { return _societeSelectionnee; }
			set
			{
				_societeSelectionnee = value;
				if (_societeSelectionnee != null)
				{
					RaisonSociale = _societeSelectionnee.RaisonSociale;
					NbActions = _societeSelectionnee.NbActions;
					DateCreation = _societeSelectionnee.DateCreation;
					ValeurUnitaire = _societeSelectionnee.ValeurUnitaire;
					Actionnaires = _societeSelectionnee.Actionnaires;
					if (_societeSelectionnee.ID < 4)
					{
						EvenementBourse.OnChangementImageSociete(new ChangementImageSocieteEventArgs(_societeSelectionnee.ID));
					}
					else
					{
						EvenementBourse.OnChangementImageSociete(new ChangementImageSocieteEventArgs(0));
					}
				}
				OnPropertyChanged("societeSelectionne");
			}
		}

		private ObservableCollection<Transaction> _actionnaires;

		public ObservableCollection<Transaction> Actionnaires
		{
			get { return _actionnaires; }
			set
			{
				_actionnaires = value;
				OnPropertyChanged("Actionnaires");
			}
		}

		private string _raisonSociale;

		public string RaisonSociale
		{
			get { return _raisonSociale; }
			set 
         { 
            _raisonSociale = value;
            OnPropertyChanged("RaisonSociale");
         }
		}

		private int _nbActions;

		public int NbActions
		{
			get { return _nbActions; }
			set 
         { 
            _nbActions = value;
            OnPropertyChanged("NbActions");
         }
		}

		private int _valeurUnitaire;

		public int ValeurUnitaire
		{
			get { return _valeurUnitaire; }
			set 
         { 
            _valeurUnitaire = value;
            OnPropertyChanged("ValeurUnitaire");
         }
		}

		private DateTime _dateCreation;

		public DateTime DateCreation
		{
			get { return _dateCreation; }
			set 
         { 
            _dateCreation = value;
            OnPropertyChanged("DateCreation");
         }
		}
		
      private void cmdAjouter(object param)
      {
			Societe s = new Societe();
			s.RaisonSociale = RaisonSociale;
			s.DateCreation = DateCreation;
			s.NbActions = NbActions;
         s.ValeurUnitaire = ValeurUnitaire;

			SommaireSocietes.Add(s);
			OutilEF.BrsCtx.LEconomie.Add(s);
			OutilEF.BrsCtx.SaveChanges();
			//societeADO.Ajouter(s);
			SocieteSelectionnee = s;
		}

      private void cmdModifier(object param)
      {
			if (SocieteSelectionnee == null)
				return;

			Societe socMod = OutilEF.BrsCtx.LEconomie.Find(SocieteSelectionnee.ID);
			socMod.RaisonSociale = RaisonSociale;
			socMod.DateCreation = DateCreation;
			socMod.NbActions = NbActions;
			socMod.ValeurUnitaire = ValeurUnitaire;

			//ObservableCollection<Societe> listSocTmp = new ObservableCollection<Societe>();
			//foreach (Societe s in SommaireSocietes)
			//{
			//	if (s.ID == sNeo.ID)
			//		listSocTmp.Add(sNeo);
			//	else
			//		listSocTmp.Add(s);
			//}

			//societeADO.Modifier(sNeo);
			//SommaireSocietes = listSocTmp;

			SocieteSelectionnee = socMod;
			OutilEF.BrsCtx.SaveChanges();
		}

      private void cmdSupprimer(object param)
      {
			if (SocieteSelectionnee == null)
				return;

			//societeADO.Supprimer(SocieteSelectionnee.ID);

			OutilEF.BrsCtx.LEconomie.Remove(SocieteSelectionnee);
			SommaireSocietes.Remove(SocieteSelectionnee);
			SocieteSelectionnee = null;
			RaisonSociale = null;
			NbActions = 0;
			ValeurUnitaire = 0;
			DateCreation = new DateTime();
		}

		private void cmdVider(object param)
        {
			SocieteSelectionnee = null;
			RaisonSociale = null;
			NbActions = 0;
			ValeurUnitaire = 0;
			DateCreation = new DateTime();
			EvenementBourse.OnChangementImageSociete(new ChangementImageSocieteEventArgs(0));
		}


	  public event PropertyChangedEventHandler PropertyChanged;
      private void OnPropertyChanged(string nomPropriete)
      {
         if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
      }
   }
}
