﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRAMIMMO.Biens
{
    public class Maison : BienImmobilier
    {

        #region Attributs

        private int _metreFacade;

        #endregion


        #region Attributs

        public Maison(string nomproprio, double prixnet, int metrefacade) : base(nomproprio, prixnet)
        {

            _metreFacade = metrefacade;

        }

        #endregion


        #region Props

        public int MetreFacade
        {
            get => _metreFacade;
            set => _metreFacade = value;
        }

        #endregion


    }
}
