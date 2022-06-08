using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public class DetailView : IView
    {
        public void Render()
        {
            throw new NotImplementedException();
        }

        public IProduct Product { get; set; }
    }

    public class PromotionView : IView
    {
        public void Render()
        {
            throw new NotImplementedException();
        }

        public IProduct Product { get; set; }
    }

    public class ListView : IView
    {
        public void Render()
        {
            throw new NotImplementedException();
        }

        public IProduct Product { get; set; }
    }

    public class AccessoryView : IView
    {
        public void Render()
        {
            throw new NotImplementedException();
        }

        public IProduct Product { get; set; }
    }

    interface IView
    {
        void Render();
        IProduct Product { get; set; }
    }
}
