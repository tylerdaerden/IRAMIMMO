using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IRAMIMMO.Biens
{
    public class BienImmobilier
    {
        //implémentation de INotifyPropertyChanged ↓↓↓
        public event PropertyChangedEventHandler? PropertyChanged;

        #region Attributs


        private const double PCT_COMMISSION = 5.0;
        private const double PRIX_MIN = 5000.0;
        private string _nomProprio;
        private double _prixNetCNC;
        private double _commissionAgence;
        private double _prixdeventeCC;

        #endregion

        #region Constructeur

        public BienImmobilier(string nomproprio, double prixnet)
        {
            NomProprio = nomproprio;
            PrixNetCNC = prixnet;
            //CommissionAgence = CalculCommission();
            //PrixVenteCC = CalculPrixVenteTotal();
        }

        #endregion

        #region Props

        public string NomProprio
        {
            get => _nomProprio;
            set
            {
                _nomProprio = value;
                OnPropertyChanged(nameof(NomProprio));
            }

        }

        public double PrixNetCNC
        {
            get => _prixNetCNC;
            set
            {
                if (CheckValue(value))
                {
                    _prixNetCNC = value;
                    CalculCommission();
                    CalculPrixVenteTotal();
                    OnPropertyChanged(nameof(PrixNetCNC));

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
            get => _prixdeventeCC;
            set
            {
                _prixdeventeCC = value;
                OnPropertyChanged(nameof(PrixVenteCC));

            }
        }

        #endregion


        #region Methodes

        public bool CheckValue(double prixventenet)
        {

            return (prixventenet <= PRIX_MIN);
        }

        public virtual void CalculCommission()
        {
            if (CheckValue(_prixNetCNC))
            {
                _commissionAgence = _prixNetCNC * (PCT_COMMISSION / 100);
            }

        }

        public void CalculPrixVenteTotal()
        {
            _prixdeventeCC = _prixNetCNC + CommissionAgence;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


    }
}
