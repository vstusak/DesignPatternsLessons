using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicToilet
{
    public enum ToiletState
    {
        Free,
        Occupied,
        Paid,
        PaymentRefused
    }

    public class ToiletDoorResult
    {
        public string DisplayText { get; set; }
        public ToiletState ToiletState { get; set; }
    }
    public class Toilet : IToilet
    {
        private ToiletState _state = ToiletState.Free;
        private PaymentService _paymentService;

        public Toilet(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public ToiletDoorResult Enter()
        {
            if (_state == ToiletState.Free)
            {
                return new ToiletDoorResult { DisplayText = "Free.", ToiletState = _state };
            }
            else if (_state == ToiletState.Occupied)
            {
                return new ToiletDoorResult { DisplayText = "Occupied.", ToiletState = _state };
            }
            else if (_state == ToiletState.PaymentRefused)
            {
                return new ToiletDoorResult { DisplayText = "Payment refused.", ToiletState = _state };
            }
            else //ToiletState.Paid
            {
                _state = ToiletState.Occupied;
                return new ToiletDoorResult { DisplayText = "Occupied.", ToiletState = _state };
            }
        }

        public ToiletDoorResult Leave()
        {
            switch (_state)
            {
                case ToiletState.Free:
                    return new ToiletDoorResult { DisplayText = "Free.", ToiletState = _state };
                case ToiletState.Occupied:
                    _state = ToiletState.Free;
                    return new ToiletDoorResult { DisplayText = "Free.", ToiletState = _state };
                case ToiletState.PaymentRefused:
                    return new ToiletDoorResult { DisplayText = "Payment refused.", ToiletState = _state };
                //ToiletState.Paid
                default:
                    return new ToiletDoorResult { DisplayText = "You can enter.", ToiletState = _state };
            }
        }

        public ToiletDoorResult SwipeCard()
        {
            switch (_state)
            {
                case ToiletState.Free:
                case ToiletState.PaymentRefused:
                    var paymentResult = _paymentService.Pay();
                    _state = paymentResult ? ToiletState.Paid : ToiletState.PaymentRefused;
                    return new ToiletDoorResult { DisplayText = paymentResult ? "You can enter." : "Payment refused.", ToiletState = _state };
                case ToiletState.Occupied:
                    return new ToiletDoorResult { DisplayText = "Occupied.", ToiletState = _state };
                //ToiletState.Paid
                default:
                    return new ToiletDoorResult { DisplayText = "You can enter.", ToiletState = _state };
            }
        }
    }
}
