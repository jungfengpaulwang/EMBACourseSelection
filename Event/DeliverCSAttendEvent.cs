using System;
using System.Collections.Generic;
using FISCA.UDT;

namespace CourseSelection.Event
{
    public class DeliverCSAttendEventArgs : EventArgs
    {
        private IEnumerable<UDT.CSAttend> records;
        public IEnumerable<UDT.CSAttend> ActiveRecords
        {
            get
            {
                return records;
            }
        }
        public DeliverCSAttendEventArgs(IEnumerable<UDT.CSAttend> records)
        {
            this.records = records;
        }
    }
}