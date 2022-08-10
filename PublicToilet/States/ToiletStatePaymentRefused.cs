using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicToilet.States
{
    internal class ToiletStatePaymentRefused: IToiletState
    {
        private const ToiletState _state = ToiletState.PaymentRefused;
        
        private IPaymentService _paymentService;
        private IToiletV2 _toilet;

        public ToiletStatePaymentRefused(IToiletV2 toilet)
        {
            _paymentService = new PaymentService();
            _toilet = toilet;
        }

        public ToiletDoorResult Enter()
        {
            return new ToiletDoorResult { DisplayText = "Payment refused.", ToiletState = _state };
        }

        public ToiletDoorResult Leave()
        {
            return new ToiletDoorResult { DisplayText = "Payment refused.", ToiletState = _state };
        }

        public ToiletDoorResult SwipeCard()
        {
            var paymentResult = _paymentService.Pay();
            if (paymentResult)
            {
                _toilet.ChangeStateObject(new ToiletStatePaid(_toilet));
                return new ToiletDoorResult { DisplayText = "You can enter.", ToiletState = ToiletState.Paid };
            }
            else
            {
                return new ToiletDoorResult { DisplayText = "Payment refused.", ToiletState = _state };
            }
        }
    }
}
