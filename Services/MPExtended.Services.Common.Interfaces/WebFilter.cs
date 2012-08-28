using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPExtended.Services.Common.Interfaces
{
    public class WebFilter
    {
        /// <summary>
        /// Id of filter
        /// </summary>
        public String Id { get; set; }

        /// <summary>
        /// Name of filter
        /// </summary>
        public String Title { get; set; }

        /// <summary>
        /// Description of Filters
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// Type of filter
        /// </summary>
        public WebFilterTypes FilterType { get; set; }

        /// <summary>
        /// Allowed operators on this filter
        /// </summary>
        public List<WebFilterOperator> AllowedOperators { get; set; }
    }
}
