using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBStore.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DBStore.Pages.Admin.Color
{
    public class UpsertModel : PageModel
    {
        
            private readonly IUnitOfWorkRepository _unitOfWork;


            public UpsertModel(IUnitOfWorkRepository unitOfWork)
            {
                _unitOfWork = unitOfWork;

            }

            [BindProperty]
            public Models.Color ColorObj { get; set; }
            public IActionResult OnGet(int? id)
            {
            ColorObj = new Models.Color();

                if (id != null)
                {
                ColorObj = _unitOfWork.Color.GetFirstOrDefault(u => u.Id == id.GetValueOrDefault());
                    if (ColorObj == null)
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
                if (ColorObj.Id == 0)
                {
                    _unitOfWork.Color.Add(ColorObj);
                }
                else
                {
                    _unitOfWork.Color.Update(ColorObj);
                }
                _unitOfWork.Save();
                return RedirectToPage("./Index");

            }



        }
    }
