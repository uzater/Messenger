using System.Collections.Generic;

namespace MessengerServiceLib
{
    public class DataBaseResult
    {
        public List<List<object>> DataResult;
        public bool Readable;

        public DataBaseResult(List<List<object>> dataResult, bool readable)
        {
            DataResult = dataResult;
            Readable = readable;
        }
    }
}