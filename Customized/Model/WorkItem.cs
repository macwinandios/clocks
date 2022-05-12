using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms.Internals;

namespace Customized.Model
{
    public class WorkItem
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }


        public TimeSpan Total 
        {
            get => End - Start;
        }


        public WorkItem()
        {
         
        }

    }
}
