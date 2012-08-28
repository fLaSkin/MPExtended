using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPExtended.Services.Common.Interfaces
{
    public class WebFilterOperator
    {

        public WebFilterOperator(string op, string title)
        {
            this.Operator = op;
            this.Title = Title;
        }
        public String Operator { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public List<String> SuitableTypes { get; set; }
    }
}
