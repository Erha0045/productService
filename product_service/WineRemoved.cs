using System;

namespace product_service
{
    public class WineRemoved
    {
        public int WineRemoveId { get; set; }
        public Wine WineId { get; set; }
        public Wine Wine { get; set; }
        public DateTime RemovedDate { get; set; }
    }
  
}
