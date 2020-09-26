using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProvider.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    
    public partial class FriendQuote
    {
        [JsonProperty("quote")]
        public string Quote { get; set; }

        [JsonProperty("character")]
        public string Character { get; set; }
    }
}

