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
      private SocieteADO societeADO = new SocieteADO();
      public ICommand cmdAjouter_Societe { get; set; }
      public ICommand cmdModifier_Societe { get; set; }
      public ICommand cmdSupprimer_Societe { get; set; }

		public Societe_VM()
		{
			cmdAjouter_Societe = new Commande(cmdAjouter);
			cmdModifier_Societe = new Commande(cmdModifier);
			cmdSupprimer_Societe = new Commande(cmdSupprimer);
			// SommaireSocietes = societeADO.Recuperer();
			SommaireSocietes = new ObservableCollection<Societe>();
			var sRequete = from soc in OutilEF.BrsCtx.LEconomie select soc;

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
				}
            OnPropertyChanged("SocieteSelectionnee");
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
			societeADO.Ajouter(s);
			SocieteSelectionnee = s;
		}

      private void cmdModifier(object param)
      {
			if (SocieteSelectionnee == null)
				return;

			Societe sNeo = new Societe();
			sNeo.ID = SocieteSelectionnee.ID;
			sNeo.RaisonSociale = RaisonSociale;
			sNeo.DateCreation = DateCreation;
			sNeo.NbActions = NbActions;
			sNeo.ValeurUnitaire = ValeurUnitaire;

			ObservableCollection<Societe> listSocTmp = new ObservableCollection<Societe>();
			foreach (Societe s in SommaireSocietes)
			{
				if (s.ID == sNeo.ID)
					listSocTmp.Add(sNeo);
				else
					listSocTmp.Add(s);
			}
			societeADO.Modifier(sNeo);
			SommaireSocietes = listSocTmp;
			SocieteSelectionnee = sNeo;
		}

      private void cmdSupprimer(object param)
      {
			if (SocieteSelectionnee == null)
				return;

			societeADO.Supprimer(SocieteSelectionnee.ID);
			SommaireSocietes.Remove(SocieteSelectionnee);
			SocieteSelectionnee = null;
			RaisonSociale = null;
			NbActions = 0;
			ValeurUnitaire = 0;
			DateCreation = new DateTime();
		}

      public event PropertyChangedEventHandler PropertyChanged;
      private void OnPropertyChanged(string nomPropriete)
      {
         if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
      }
   }
}
