using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPExtended.Services.Common.Interfaces
{
    public class WebFilterElement
    {
        /// <summary>
        /// Id of this element
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Title of the element
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Number of results from this filter
        /// </summary>
        public int NumResults { get; set; }

        /// <summary>
        /// Has subfilters
        /// </summary>
        public bool HasSubFilter { get; set; }
    }
}
