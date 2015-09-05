using System;

namespace Exceptions_Task1
{
    [Serializable]
    class YearFormatException : Exception
    {
        public YearFormatException() { }
        public YearFormatException(string str) : base(str) { }
        public YearFormatException(
        string str, Exception inner) : base(str, inner)
        { }
        protected YearFormatException(
        System.Runtime.Serialization.SerializationInfo si,
        System.Runtime.Serialization.StreamingContext sc) : base(si, sc)
        { }

        public override string Message
        {
            get
            {
                return "YearFormatException: Entered value does not match required format!!!";
            }
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
