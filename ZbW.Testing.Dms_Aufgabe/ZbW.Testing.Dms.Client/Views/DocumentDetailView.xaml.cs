﻿using ZbW.Testing.Dms.Client.Services;

namespace ZbW.Testing.Dms.Client.Views
{
    using System;
    using System.Windows.Controls;

    using ZbW.Testing.Dms.Client.ViewModels;

    /// <summary>
    /// Interaction logic for NewDocumentView.xaml
    /// </summary>
    public partial class DocumentDetailView : UserControl
    {
        public DocumentDetailView(string benutzer, Action navigateBack,FileControl fileControl)
        {
            InitializeComponent();
            DataContext = new DocumentDetailViewModel(benutzer, navigateBack, fileControl);
        }
    }
}