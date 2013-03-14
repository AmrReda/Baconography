﻿using BaconographyPortable.Model.Reddit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaconographyPortable.Model.KitaroDB.ListingHelpers
{
    class UserActivity : IListingProvider
    {
        public Tuple<Task<Listing>, Task<Listing>> GetInitialListing(Dictionary<object, object> state)
        {
            return Tuple.Create<Task<Listing>, Task<Listing>>(null, Task.Run(async () => new Listing { Kind = "Listing", Data = new ListingData { Children = new List<Thing>() } }));
        }

        public Task<Listing> GetAdditionalListing(string after, Dictionary<object, object> state)
        {
            throw new NotImplementedException();
        }

        public Task<Listing> GetMore(IEnumerable<string> ids, Dictionary<object, object> state)
        {
            throw new NotImplementedException();
        }
    }
}
