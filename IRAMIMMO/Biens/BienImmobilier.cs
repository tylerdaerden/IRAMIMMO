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
            get => _prixNetVendeur;
            set
            {
                if (CheckValue(value))
                {
                    _prixNetVendeur = value;
                    CalculCommission();
                    CalculPrixVenteTotal();
                    OnPropertyChanged(nameof(PrixNetVendeur));

                }
                else 
                {
                    _prixNetVendeur = 0.0;

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
