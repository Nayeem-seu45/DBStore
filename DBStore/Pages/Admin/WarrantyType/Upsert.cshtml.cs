using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBStore.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DBStore.Pages.Admin.WarrantyType
{
   public class UpsertModel : PageModel
    {
        
            private readonly IUnitOfWorkRepository _unitOfWork;


            public UpsertModel(IUnitOfWorkRepository unitOfWork)
            {
                _unitOfWork = unitOfWork;

            }

            [BindProperty]
            public Models.WarrantyType WarrantyObj { get; set; }
            public IActionResult OnGet(int? id)
            {
            WarrantyObj = new Models.WarrantyType();

                if (id != null)
                {
                WarrantyObj = _unitOfWork.WarrantyType.GetFirstOrDefault(u => u.Id == id.GetValueOrDefault());
                    if (WarrantyObj == null)
                    {
                        return NotFound();
                    }
                }
                return Page();
            }

            public IActionResult OnPost()
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                if (WarrantyObj.Id == 0)
                {
                    _unitOfWork.WarrantyType.Add(WarrantyObj);
                }
                else
                {
                    _unitOfWork.WarrantyType.Update(WarrantyObj);
                }
                _unitOfWork.Save();
                return RedirectToPage("./Index");

            }



        }
}