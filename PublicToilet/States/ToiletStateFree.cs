using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicToilet.States
{
    public class ToiletStateFree : IToiletState
    {
        public ToiletState State => ToiletState.Free;
        private IPaymentService _paymentService;
        private IToiletV2 _toilet;

        public ToiletStateFree(IToiletV2 toilet)
        {
            _toilet = toilet;
            _paymentService = new PaymentService();
        }

        public ToiletDoorResult Enter()
        {
            return new ToiletDoorResult { DisplayText = "Free.", ToiletState = State };
        }

        public ToiletDoorResult Leave()
        {
            return new ToiletDoorResult { DisplayText = "Free.", ToiletState = State };
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
                _toilet.ChangeStateObject(new ToiletStatePaymentRefused(_toilet));
                return new ToiletDoorResult { DisplayText = "Payment refused.", ToiletState = ToiletState.PaymentRefused };
            }
        }
    }
}
