using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ZbW.Testing.Dms.Client.TestableObjects
{
    public class TestableMessageBox
    {
        public virtual MessageBoxResult Show(string messageBoxText)
        {
            return MessageBox.Show(messageBoxText);
        }
    }
}
