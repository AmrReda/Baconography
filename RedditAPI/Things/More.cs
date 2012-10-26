﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baconography.RedditAPI.Things
{
    public class More : IThingData
    {
        [JsonProperty("children")]
        public List<string> Children { get; set; }
    }
}
