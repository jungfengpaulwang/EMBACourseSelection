using System;

namespace CourseSelection.Event
{
    class DeliverActiveRecord
    {
        public DeliverActiveRecord()
        {

        }

        internal static void RaiseSendingEvent(object sender, DeliverCSAttendEventArgs e)
        {
            if (DeliverActiveRecord.Received != null)
                DeliverActiveRecord.Received(sender, e);
        }

        internal static event EventHandler<DeliverCSAttendEventArgs> Received;
    }
}
