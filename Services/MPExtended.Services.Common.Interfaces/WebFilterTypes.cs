using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MPExtended.Services.Common.Interfaces
{
    [DataContract]
    public enum WebFilterTypes
    {
        /// <summary>
        /// Numeric values 
        /// </summary>
        [EnumMember]
        Numeric = 0,
        /// <summary>
        /// Generic text
        /// </summary>
        [EnumMember]
        Text = 1,
        /// <summary>
        /// Yes or no
        /// </summary>
        [EnumMember]
        Boolean = 2,
        /// <summary>
        /// Custom values, have to be retrieved from MpExtended
        /// </summary>
        [EnumMember]
        Custom = 3
    }
}
