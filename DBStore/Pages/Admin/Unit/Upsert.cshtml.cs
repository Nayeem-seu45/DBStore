using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBStore.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DBStore.Pages.Admin.Unit
{
    public class UpsertModel : PageModel
    {
        
            private readonly IUnitOfWorkRepository _unitOfWork;


            public UpsertModel(IUnitOfWorkRepository unitOfWork)
            {
                _unitOfWork = unitOfWork;

            }

            [BindProperty]
            public Models.Unit UnitObj { get; set; }
            public IActionResult OnGet(int? id)
            {
            UnitObj = new Models.Unit();

                if (id != null)
                {
                UnitObj = _unitOfWork.Unit.GetFirstOrDefault(u => u.Id == id.GetValueOrDefault());
                    if (UnitObj == null)
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
                if (UnitObj.Id == 0)
                {
                    _unitOfWork.Unit.Add(UnitObj);
                }
                else
                {
                    _unitOfWork.Unit.Update(UnitObj);
                }
                _unitOfWork.Save();
                return RedirectToPage("./Index");

            }



        }
    }
