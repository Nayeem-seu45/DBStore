using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBStore.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DBProject.Pages.Admin.Category
{
    [Authorize(Roles =SD.ManagerRole)]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}