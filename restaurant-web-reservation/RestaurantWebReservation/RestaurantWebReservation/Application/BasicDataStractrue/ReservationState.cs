using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantWebReservation.Application.BasicDataStractrue
{
    public enum ReservationState
    {
        RESRVED = 1,
        BUSY = 2,
        TIMEOUT = 3,
        FINISH = 0
    }
}