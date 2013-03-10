using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using RestaurantWebReservation.DataAccess;

namespace RestaurantWebReservation.Application.BasicDataStractrue
{
    public class SysTable
    {
        public SysTable() { }
        public SysTable(Guid pId, string pName, int pSeat, string pPictPath, TableState pState)
        {
            id = pId;
            name = pName;
            seat = pSeat;
            pictPath = pPictPath;
            state = pState;

            hide = state.ToString();
        }

        public void ChageState(TableState pState)
        {
            state = pState;
            hide = pState.ToString();

            //~ synchronize to db, if need to maintain the state in db
            DataContextDataContext dc = new DataContextDataContext();
            dc.update_state_table(id, (int?)state);
        }

        public void SetReservation(Reservation pReservation)
        {
            currentReservation = pReservation;
        }

        public Reservation GetReservation()
        {
            return currentReservation;
        }


        public Guid id = new Guid();
        public string name { get; set; }
        public int seat { get; set; }
        public string pictPath { get; set; }
        public TableState state = TableState.AVAILABLE;

        public string hide {get; set;}
        //current reservation maintained by table can only be passed as a parameter in SetReservation(Reservation pReservation)
        //when WalkInArrive or this table object enter in the RESERVED state caused by this reservation 
        //initialized by ManagerService.WalkInArrive() or CheckTimeout()
        Reservation currentReservation = null;
    }
}