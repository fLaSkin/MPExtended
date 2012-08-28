using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MPExtended.Services.Common.Interfaces
{
    [DataContract]
    public enum WebFilterOperator
    {
        /// <summary>
        /// == 
        /// </summary>
        [EnumMember]
        Equals = 0,
        /// <summary>
        /// !=
        /// </summary>
        [EnumMember]
        NotEquals = 1,
        /// <summary>
        /// "<"
        /// </summary>
        [EnumMember]
        LowerThen = 2,
        /// <summary>
        /// ">"
        /// </summary>
        [EnumMember]
        GreaterThen = 3,
                /// <summary>
        /// "<"
        /// </summary>
        [EnumMember]
        LowerOrEqualThen = 4,
        /// <summary>
        /// ">"
        /// </summary>
        [EnumMember]
        GreaterOrEqualThen = 5,
        /// <summary>
        /// ">"
        /// </summary>
        [EnumMember]
        And = 6,
        /// <summary>
        /// ">"
        /// </summary>
        [EnumMember]
        Or = 7
    }
}
