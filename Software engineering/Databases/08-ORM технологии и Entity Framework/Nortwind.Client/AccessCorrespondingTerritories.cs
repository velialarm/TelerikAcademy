using System.Data.Entity;
using Nortwind.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nortwind.Client
{
    /// <summary>
    /// 8. Task
    /// By inheriting the Employee entity class create a class which allows employees to access their corresponding territories as property of type EntitySet<T>.
    /// </summary>
    public partial class Employee
    {
        public DbSet<Territory> Teritories { get; set; }
    }
}
