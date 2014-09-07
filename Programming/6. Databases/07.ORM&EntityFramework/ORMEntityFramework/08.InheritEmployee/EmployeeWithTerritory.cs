// 8.By inheriting the Employee entity class create a class which allows employees to access their
// corresponding territories as property of type EntitySet<T>.

namespace _08.InheritEmployee
{
    using System.Collections.Generic;
    using System.Data.Entity.Core.Metadata.Edm;
    using Northwind.Data;

    public class EmployeeWithTerritory : Employee
    {
        public override ICollection<Territory> Territories
        {
            get
            {
                return this.Territories;        // this property exists already in the Employee class no need to implement it
            }
        }
    }
}
