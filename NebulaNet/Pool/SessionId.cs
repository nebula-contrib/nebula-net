using System;
using System.Collections.Generic;
using System.Text;

namespace NebulaNet
{
    public class SessionId
    {
        public long Id { get;private set; }
        public DateTime CreateTime { get;private set; } = DateTime.Now;
        public bool IsValid => (DateTime.Now - CreateTime).TotalHours < 7;

        public void SetId(long id)
        {
            Id = id;
        }
    }
}
