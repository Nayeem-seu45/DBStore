using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DBStore.DataAccess.Data.Repository.IRepository;
using DBStore.Models;
using DBStore.Models.VModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DBStore.Pages.Customer.Home
{
    public class ContactModel : PageModel
    {
        private readonly IUnitOfWorkRepository _unitOfWork;


        public ContactModel(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        [BindProperty]
        public MassageVM MassageObj { get; set; }
        public IActionResult OnGet(int? id)
        {
            MassageObj = new MassageVM
            {

                Massage = new Models.Massage()


            };
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null)
            {
                return Redirect("/Identity/Account/Login");




            }
            if (id != null)
            {
                MassageObj.Massage = _unitOfWork.Massage.GetFirstOrDefault(u => u.Id == id.GetValueOrDefault());
                if (MassageObj.Massage == null)
                {
                    return NotFound();
                }
            }

            ApplicationUser applicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(c => c.Id == claim.Value);
            MassageObj.Massage.YourName = applicationUser.FullName;
            MassageObj.Massage.PhoneNumber = applicationUser.PhoneNumber;
            MassageObj.Massage.Email = applicationUser.Email;
            return Page();

        }


        public IActionResult OnPost()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            MassageObj.Massage.UserId = claim.Value;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (MassageObj.Massage.Id == 0)
            {
                _unitOfWork.Massage.Add(MassageObj.Massage);
            }
            else
            {
                _unitOfWork.Massage.Update(MassageObj.Massage);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}