﻿using System;
using System.Windows;
using System.Collections.Generic;
using Microsoft.Win32;
using ZbW.Testing.Dms.Client.ViewModels;
using ZbW.Testing.Dms.Client.Views;
using ZbW.Testing.Dms.Client.TestableObjects;

namespace ZbW.Testing.Dms.Client.Model
{
    public class MetadataItem
    {
        private string bezeichung;
        private DateTime? valutaDatum;
        private string selectedTypItems;
        private string stichwoerter;
        private string filePath;
        private string fileGuid;


        public string Bezeichung
        {
            get { return bezeichung; }
            set { bezeichung = value; }
        }

        public DateTime? ValutaDatum
        {
            get { return valutaDatum; }
            set { valutaDatum = value; }
        }

        public string DokumentTyp
        {
            get { return selectedTypItems; }
            set { selectedTypItems = value; }
        }

        public string Stichwoerter
        {
            get { return stichwoerter; }
            set { stichwoerter = value; }
        }

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        public string FileGuid
        {
            get { return fileGuid; }
            set { fileGuid = value; }
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