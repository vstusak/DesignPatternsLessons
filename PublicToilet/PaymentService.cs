﻿using System;

namespace PublicToilet
{
    public static class PaymentService
    {
        public static bool Pay()
        {
            Random rnd = new Random(DateTime.Now.Second);
            var result =  rnd.Next(0, 2);
            return result != 0;
        }
    }
}
