using System;

namespace cet322_hw1.Models
{
    public class BookModel
    {
        public string Name { get; set; }
        public string Writer { get; set; }
        public bool Available { get; set; }
        public DateTime? DeliveryTime { get; set; }

        public TimeSpan TimeLeft
        {
            get
            {
                if (DeliveryTime.HasValue)
                {
                    var timeLeft = DeliveryTime.Value - DateTime.Now;
                    return timeLeft > TimeSpan.Zero ? timeLeft : TimeSpan.Zero;
                }
                return TimeSpan.Zero;
            }
        }
    }
}
