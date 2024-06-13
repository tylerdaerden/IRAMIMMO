using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRAMIMMO.Biens
{
    public class Garage : BienImmobilier
    {

        #region Attributs

        private const double PCT_GARAGE = 10.0;
        private const double FORFAIT_COMM = 500.0;
        private bool _voletelectrique;
        private const string TYPE_BIEN = "Garage";

        #endregion


        #region Constructeur

        public Garage(string nomproprio, float prixnet, bool voletelectrique) : base(nomproprio, prixnet)
        {
            _voletelectrique = voletelectrique;
        }

        #endregion



        #region Props

        public bool VoletElectrique
        {
            get => _voletelectrique;
            set => _voletelectrique = value;
        }

        #endregion


        public override void CalculCommission()
        {

            CommissionAgence = FORFAIT_COMM + ( PrixNetVendeur * (PCT_GARAGE / 100));

        }

        public override string BienProprio => $" {TYPE_BIEN} {NomProprio} ";



    }
}
