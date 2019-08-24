using RentBikes.Core.Domain;
using System.Web.Mvc;

namespace RentBikes.Core.BLL
{
    public static class helper
    {
        private static Ibll_Base<State> BizStates
        {
            get { return new bll_Base<State>(); }
        }

        public static SelectList States(int? stateID)
        {

            SelectList list = null;
            if (stateID == null)
                list = new SelectList(BizStates.GetAll(), "stateID", "description");
            else
                list = new SelectList(BizStates.GetAll(), "stateID", "description", stateID);

            return list;
        }
    }
}