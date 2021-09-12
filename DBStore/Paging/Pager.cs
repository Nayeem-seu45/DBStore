using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBStore.Paging
{
    public class Pager
    {
        public string AreaName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string PageName{ get; set; }
        public PagedList PagedList { get; set; }
    }
}
