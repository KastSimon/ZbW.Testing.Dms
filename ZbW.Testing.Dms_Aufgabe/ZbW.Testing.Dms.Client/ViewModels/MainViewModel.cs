namespace ZbW.Testing.Dms.Client.ViewModels
{
    using System.Windows.Controls;

    using Prism.Commands;
    using Prism.Mvvm;
    using ZbW.Testing.Dms.Client.Services;
    using ZbW.Testing.Dms.Client.TestableObjects;
    using ZbW.Testing.Dms.Client.Views;

    internal class MainViewModel : BindableBase
    {
        private string _benutzer;

        private UserControl _content;

        private FileControl fileControl;

        public MainViewModel(string benutzername)
        {
            Benutzer = benutzername;
            CmdNavigateToSearch = new DelegateCommand(OnCmdNavigateToSearch);
            CmdNavigateToDocumentDetail = new DelegateCommand(OnCmdNavigateToDocumentDetail);

            fileControl = new FileControl();
        }

        public string Benutzer
        {
            get
            {
                return _benutzer;
            }

            set
            {
                SetProperty(ref _benutzer, value);
            }
        }

        public UserControl Content
        {
            get
            {
                return _content;
            }

            set
            {
                SetProperty(ref _content, value);
            }
        }

        public DelegateCommand CmdNavigateToSearch { get; }

        public DelegateCommand CmdNavigateToDocumentDetail { get; }

        private void OnCmdNavigateToSearch()
        {
            NavigateToSearch();
        }

        private void OnCmdNavigateToDocumentDetail()
        {
            Content = new DocumentDetailView(Benutzer, NavigateToSearch, fileControl);
        }

        private void NavigateToSearch()
        {
            Content = new SearchView(fileControl);
        }
    }
}