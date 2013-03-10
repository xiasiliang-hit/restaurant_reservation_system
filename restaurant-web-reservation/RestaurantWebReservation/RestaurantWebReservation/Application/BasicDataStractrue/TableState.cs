using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantWebReservation.Application.BasicDataStractrue
{
    public enum TableState
    {
        AVAILABLE = 0,
        RESERVED = 1,
        BUSY = 2,
        TIMEOUT = 3,
    }
}