using IRAMIMMO.Utilities;
using IRAMIMMO.ViewModel;

namespace IRAMIMMO
{
    public partial class MainPage : ContentPage
    {



        public MainPage(MainPageViewModel mainPageVM, DataAccess dataAccessService)
        {
            mainPageViewModel = mainPageVM;
            BindingContext = mainPageVM;
            dataAccess = dataAccessService;
            InitializeComponent();

        }

        private DataAccess dataAccess;

        private MainPageViewModel mainPageViewModel;


    }
}

