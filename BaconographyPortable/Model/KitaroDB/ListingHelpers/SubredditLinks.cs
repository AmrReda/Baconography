﻿using BaconographyPortable.Model.Reddit;
using BaconographyPortable.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaconographyPortable.Model.KitaroDB.ListingHelpers
{
    class SubredditLinks : IListingProvider
    {
        private string _subreddit;
        private IOfflineService _offlineService;

        public SubredditLinks(IBaconProvider baconProvider, string subreddit, string subredditId)
        {
            _offlineService = baconProvider.GetService<IOfflineService>();
            _subreddit = subreddit;
        }

        public Task<Listing> GetInitialListing(Dictionary<object, object> state)
        {
            return _offlineService.LinksForSubreddit(_subreddit, null);
        }

        public Task<Listing> GetAdditionalListing(string after, Dictionary<object, object> state)
        {
            return _offlineService.LinksForSubreddit(_subreddit, after);
        }

        public Task<Listing> GetMore(IEnumerable<string> ids, Dictionary<object, object> state)
        {
            throw new NotImplementedException();
        }
    }
}
