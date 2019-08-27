using RentBikes.Core.Domain;
using System;
using System.Web.Mvc;

namespace RentBikes.Core.BLL
{
    public static class Helper
    {
        private static IBll_State BizStates
        {
            get { return new Bll_State(); }
        }

        private static IBll_Base<VehicleType> BizVehicleTypes
        {
            get { return new Bll_Base<VehicleType>(); }
        }

        private static IBll_Station BizStations
        {
            get { return new Bll_Station(); }
        }

        private static IBll_Base<Client> BizClients
        {
            get { return new Bll_Base<Client>(); }
        }

        private static IBll_Base<RentalType> BizRentalTypes
        {
            get { return new Bll_Base<RentalType>(); }
        }

        internal static SelectList States(int? stateID)
        {
            SelectList list = null;
            if (stateID == null)
                list = new SelectList(BizStates.GetAll(), "stateID", "description");
            else
                list = new SelectList(BizStates.GetAll(), "stateID", "description", stateID);

            return list;
        }

        internal static SelectList VehicleTypes(int? vehicleTypeID)
        {
            SelectList list = null;
            if (vehicleTypeID == null)
                list = new SelectList(BizVehicleTypes.GetAll(), "vehicleTypeID", "description");
            else
                list = new SelectList(BizVehicleTypes.GetAll(), "vehicleTypeID", "description", vehicleTypeID);

            return list;
        }

        internal static SelectList RentalTypes(int? rentalTypeID)
        {
            SelectList list = null;
            if (rentalTypeID == null)
                list = new SelectList(BizRentalTypes.GetAll(), "rentalTypeID", "description");
            else
                list = new SelectList(BizRentalTypes.GetAll(), "rentalTypeID", "description", rentalTypeID);

            return list;
        }

        internal static dynamic Clients(int? clientID)
        {
            SelectList list = null;
            if (clientID == null)
                list = new SelectList(BizClients.GetAll(), "clientID", "name");
            else
                list = new SelectList(BizClients.GetAll(), "clientID", "name", clientID);

            return list;
            
        }

        internal static dynamic Stations(int? stationID)
        {
            SelectList list = null;
            if (stationID == null)
                list = new SelectList(BizStations.GetAll(), "stationID", "description");
            else
                list = new SelectList(BizStations.GetAll(), "stationID", "description", stationID);

            return list;
            
        }
    }
}