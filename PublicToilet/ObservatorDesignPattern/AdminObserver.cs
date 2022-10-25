using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PublicToilet.ObservatorDesignPattern
{
    internal class AdminObserver : IOurObserver
    {
        private readonly TextBox _output;

        public AdminObserver(TextBox output)
        {
            _output = output;
        }

        public void NotificationRaised(IOurObservable source)
        {
            _output.AppendText(source.GetState().ToString() + Environment.NewLine);
        }

        public void UnSubscribe()
        {
            throw new NotImplementedException();
        }
    }
}
