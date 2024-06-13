using CommunityToolkit.Mvvm.ComponentModel;
using IRAMIMMO.Biens;
using IRAMIMMO.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRAMIMMO.ViewModel
{
    public partial class MainPageViewModel : ObservableObject
    {



        public MainPageViewModel(DataAccess dataAccessService)
        {
            dataAccess = dataAccessService;
            BiensImmoEnVente = dataAccess.GetBiensEnVente();

        }


        private DataAccess dataAccess;

        public BiensEnVente BiensImmoEnVente { get; set; }

        [ObservableProperty]
        private BienImmobilier bienUserSelection;





    }
}
