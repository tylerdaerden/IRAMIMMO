using IRAMIMMO.Utilities.Check;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IRAMIMMO.Biens
{
    public class BienImmobilier : INotifyPropertyChanged
    {
        //implémentation de INotifyPropertyChanged ↓↓↓
        public event PropertyChangedEventHandler? PropertyChanged;

        #region Attributs


        private const double PCT_COMMISSION = 5.0;
        private const double PRIX_MIN = 5000.0;
        private string _nomProprio;
        private double _prixNetVendeur;
        private double _commissionAgence;
        private double _prixVenteCC;

        #endregion

        #region Constructeur

        public BienImmobilier(string nomproprio, double prixnet)
        {
            NomProprio = nomproprio;
            PrixNetVendeur = prixnet;
            CalculCommission();
            CalculPrixVenteTotal();
        }

        #endregion

        #region Props

        public string NomProprio
        {
            get => _nomProprio;
            set
            {
                if (CheckTools.CheckEntryName(value))
                {
                    _nomProprio = value;
                }

                OnPropertyChanged(nameof(NomProprio));
            }

        }

        public double PrixNetVendeur
        {
            get => _prixNetVendeur; // Retourne la valeur actuelle de _prixNetVendeur
            set
            {
                // Vérifie si la nouvelle valeur est différente de l'ancienne valeur
                if (_prixNetVendeur != value)
                {
                    // Vérifie si la nouvelle valeur est supérieure ou égale à PRIX_MIN
                    if (CheckValue(value))
                    {
                        // Si la nouvelle valeur est valide, elle est assignée à _prixNetVendeur
                        _prixNetVendeur = value;
                    }
                    else
                    {
                        // Si la nouvelle valeur est inférieure à PRIX_MIN, assigne PRIX_MIN à _prixNetVendeur
                        _prixNetVendeur = PRIX_MIN;
                    }
                    // Calcule la commission basée sur le nouveau prix net vendeur
                    CalculCommission();
                    // Calcule le prix de vente total TTC (toutes charges comprises)
                    CalculPrixVenteTotal();
                    // Notifie que la propriété PrixNetVendeur a changé
                    OnPropertyChanged(nameof(PrixNetVendeur));
                }
            }
        }


        public double CommissionAgence
        {
            get => _commissionAgence;
            set
            {
                _commissionAgence = value;
                OnPropertyChanged(nameof(CommissionAgence));
            }

        }

        public double PrixVenteCC
        {
            get => _prixVenteCC;
            set
            {
                _prixVenteCC = value;
                OnPropertyChanged(nameof(PrixVenteCC));

            }
        }

        public virtual string BienProprio => _nomProprio;

        #endregion


        #region Methodes

        public static bool CheckValue(double prixventenet)
        {
            if(prixventenet >= PRIX_MIN)
            {
                return true;
            }

            return false;

        }

        public virtual void CalculCommission()
        {

                CommissionAgence = PrixNetVendeur * (PCT_COMMISSION / 100.0);
 

        }

        public void  CalculPrixVenteTotal()
        {
            PrixVenteCC = PrixNetVendeur + CommissionAgence;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


    }
}
