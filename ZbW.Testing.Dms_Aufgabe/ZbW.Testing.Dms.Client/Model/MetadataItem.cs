using System;
using System.Windows;
using System.Collections.Generic;
using Microsoft.Win32;
using ZbW.Testing.Dms.Client.ViewModels;
using ZbW.Testing.Dms.Client.Views;
using ZbW.Testing.Dms.Client.TestableObjects;

namespace ZbW.Testing.Dms.Client.Model
{
    internal class MetadataItem
    {
        private string bezeichung;
        private DateTime? valutaDatum;
        private string selectedTypItems;
        private string stichwoerter;

        public MetadataItem(string bezeichung, DateTime? valutaDatum, string selectedTypItems,  string stichwoerter)
        {
            this.bezeichung = bezeichung;
            this.valutaDatum = valutaDatum;
            this.selectedTypItems = selectedTypItems;
            this.stichwoerter = stichwoerter;
        }

        public string Bezeichung
        {
            get { return bezeichung; }
        }

        public DateTime? ValutaDatum
        {
            get { return valutaDatum; }
        }

        public string SelectedTypItems
        {
            get { return selectedTypItems; }
        }

        public string Stichwoerter
        {
            get { return stichwoerter; }
        }

        public bool ValideMetadata(TestableMessageBox messageBox)
        {
            if (!string.IsNullOrEmpty(bezeichung) && valutaDatum != null && !string.IsNullOrEmpty(selectedTypItems))
                return true;
            else

                messageBox.Show("Es müssen alle Pflichtfelder ausgefüllt werden");
            return false;
        }

    }
}