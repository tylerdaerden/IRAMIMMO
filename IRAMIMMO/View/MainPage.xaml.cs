using IRAMIMMO.ViewModel;

namespace IRAMIMMO
{
    public partial class MainPage : ContentPage
    {



        public MainPage(MainPageViewModel mainPageVM)
        {
            mainPageViewModel = mainPageVM;
            BindingContext = mainPageVM;
            InitializeComponent();

        }


        private MainPageViewModel mainPageViewModel;


    }
}

