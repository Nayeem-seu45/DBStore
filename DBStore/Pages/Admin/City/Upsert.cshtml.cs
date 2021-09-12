 using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBStore.DataAccess.Data.Repository.IRepository;
using DBStore.Models.VModels;
using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DBStore.Pages.Admin.City
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
      

        public UpsertModel(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
          
        }

        [BindProperty]
        public Models.City CityObj { get; set; }
        public IActionResult OnGet(int? id)
        {
            CityObj = new Models.City();

            if (id != null)
            {
                CityObj = _unitOfWork.City.GetFirstOrDefault(u => u.Id == id.GetValueOrDefault());
                if (CityObj == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(CityObj.Id==0)
            {
                _unitOfWork.City.Add(CityObj);
            }
            else
            {
                _unitOfWork.City.Update(CityObj);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");

        }

      
            
    }
}