using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFridge
{
    public struct ShoppingUnit
    {
        public ShoppingPackage PackageType { get; set; }
        public int BaseUnitsPerPackage { get; set; }

        public ShoppingUnit(ShoppingPackage package, int unitsPerPackage)
            : this()
        {
            this.PackageType = package;
            this.BaseUnitsPerPackage = unitsPerPackage;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.PackageType, this.BaseUnitsPerPackage);
        }
    }
}
