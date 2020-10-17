using System;

namespace HelloWorldDepInjFA1017
{
    public class SimpleCustomClass : ISimpleCustomClass
    {
        private int _privateValue;

        public int SetSimpleCustomClassPrivateValue(string privateValue)
        {
            try
            {
                _privateValue = Convert.ToInt32(privateValue);
            }
            catch (Exception exc)
            {
                // Set up logger at later time, now swallowing exception for now
            }

            return _privateValue;            
        }

        public string ShowSimpleCustomClassPrivateValue()
        {
            return _privateValue.ToString();
        }
    }
}
