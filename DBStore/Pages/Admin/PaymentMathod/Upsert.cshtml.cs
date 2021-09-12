using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBStore.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DBStore.Pages.Admin.PaymentMathod
{
    public class UpsertModel : PageModel
    {
        
            private readonly IUnitOfWorkRepository _unitOfWork;


            public UpsertModel(IUnitOfWorkRepository unitOfWork)
            {
                _unitOfWork = unitOfWork;

            }

            [BindProperty]
            public Models.PaymentMathod PaymentMathodObj { get; set; }
            public IActionResult OnGet(int? id)
            {
        PaymentMathodObj = new Models.PaymentMathod();

                if (id != null)
                {
                PaymentMathodObj = _unitOfWork.PaymentMathod.GetFirstOrDefault(u => u.Id == id.GetValueOrDefault());
                    if (PaymentMathodObj == null)
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
                if (PaymentMathodObj.Id == 0)
                {
                    _unitOfWork.PaymentMathod.Add(PaymentMathodObj);
                }
                else
                {
                    _unitOfWork.PaymentMathod.Update(PaymentMathodObj);
                }
                _unitOfWork.Save();
                return RedirectToPage("./Index");

            }



        }
    }
