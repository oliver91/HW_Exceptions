using System;

namespace Exceptions_Task2
{
    [Serializable]
    class StoreNotFoundException : Exception
    {
        public StoreNotFoundException() { }
        public StoreNotFoundException(string str) : base(str) { }
        public StoreNotFoundException(
        string str, Exception inner) : base(str, inner)
        { }
        protected StoreNotFoundException(
        System.Runtime.Serialization.SerializationInfo si,
        System.Runtime.Serialization.StreamingContext sc) : base(si, sc)
        { }

        public override string Message
        {
            get
            {
                return "StoreNotFoundException!";
            }
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
