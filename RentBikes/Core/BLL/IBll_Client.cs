﻿using RentBikes.Core.Domain;
using System.Collections.Generic;

namespace RentBikes.Core.BLL
{
    public interface IBll_Client : IBll_Base<Client>
    {
        IEnumerable<Client> GetAllFull();
    }
}
