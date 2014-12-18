namespace _01.CarSearchForm.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Producer
    {
        public string Name { get; set; }

        public ICollection<string> Models { get; set; }
    }
}