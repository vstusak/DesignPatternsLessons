using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublicToilet.States;

namespace PublicToilet
{
    public interface IToiletV2: IToilet
    {
        void ChangeStateObject(IToiletState toiletState);
    }
}
