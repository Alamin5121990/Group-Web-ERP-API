using System;

namespace LabaidMIS.Data.Classes
{
    public class SingleValueString
    {
        public string ReturnValue { get; set; }
    }

    public class SingleValueDecimal
    {
        public Nullable<decimal> ReturnValue { get; set; }
    }

    public class SingleValueInt
    {
        public Nullable<int> ReturnValue { get; set; }
    }
}