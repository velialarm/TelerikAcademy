/**
 * Define a class that holds information about a mobile phone device: 
 * model, manufacturer, price, owner, battery characteristics (model, hours idle and hours talk) 
 * and display characteristics (size and number of colors). 
 * Define 3 separate classes (class GSM holding instances of the classes Battery and Display).
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace _01MobilePhones
{
    class GSM
    {
        //fields   
        private double? _price;
        private String _model;
        private String _owner;
        private List<Calls> _callHistory;

        //Properties
        public double? Price
        {
            get { return _price; }
            set
            {
                if (value >= 0 || value == null)
                {
                    this._price = value;
                }

            }
        }
        public String Model { get { return _model; } set { _model = value; } }
        public String Owner { get { return _owner; } set { _owner = value; } }
        public string Manifucter { get; set; }
        public List<Calls> CallHistory { get { return _callHistory; } set { _callHistory = value; } }
        public Battery Bat { get; set; }
        public Display DisplayProp { get; set; }
        public static GSM IPhone4S { get; set; }

        //Constructors
        public GSM(String model, String manifucter)
            : this(model, manifucter, null, null, null, null, null)
        {
        }
        public GSM(String model, String manifucter, double? price, String owner, Battery battery, Display display, List<Calls> callHistory)
        {
            this._model = model;
            this.Manifucter = manifucter;
            this._price = price;
            this._owner = owner;
            this.Bat = battery;
            this._callHistory = callHistory;
        }

        public GSM()
        {
        }

        //Methods
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (_model != null)
            {
                sb.Append("Model " + _model);
            }
            if (_price != null)
            {
                sb.Append(", Price " + _price);
            }
            if (_owner != null)
            {
                sb.Append(", Owner " + _owner);
            }
            return sb.ToString();
        }

        public void AddCalls(Calls call)
        {
            _callHistory.Add(call);
        }
        public void DeleteCalls(Calls call)
        {
            if (call != null) _callHistory.Remove(call);
        }

        public void ClearCalls()
        {
            _callHistory.Clear();
        }
        public static decimal CalculateTotalPrice(decimal pricePerMinute)
        {
            decimal result = 0;
            CallHistory ch = new CallHistory();
            foreach (Calls call in ch)
            {
                if (call.Duration < 60)
                {
                    result += pricePerMinute;
                }
                else
                {
                    result += call.Duration / 60 * pricePerMinute;
                }
            }
            return result;
        }
    }
}
