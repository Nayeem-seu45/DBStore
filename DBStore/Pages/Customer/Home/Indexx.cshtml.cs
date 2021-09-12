using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBStore.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using DBStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DBStore.Models.VModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace DBStore.Pages.Customer.Home
{
    public class IndexxModel : PageModel
    {
        //        private readonly IUnitOfWorkRepository _unitOfWork;
        //        private readonly RoleManager<IdentityRole> _roleManager;
        //        private readonly IWebHostEnvironment _hostingEnvironment;
        //        public IndexxModel(IUnitOfWorkRepository unitOfWork, RoleManager<IdentityRole> roleManager, IWebHostEnvironment hostingEnvironment)
        //        {
        //            _unitOfWork = unitOfWork;
        //            _roleManager = roleManager;
        //            _hostingEnvironment = hostingEnvironment;
        //        }

        //        [BindProperty]
        //        public ReviewsVM UserReviews { get; set; }
        //        public IActionResult OnGet()
        //        {
        //            UserReviews = new ReviewsVM()
        //            {

        //            };
        //            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
        //            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

        //             //ApplicationUser applicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(c => c.Id == claim.Value);

        //            //UserReviews.Reviews.AddedBy = applicationUser.FullName;

        //            //UserReviews.Reviews.EmailAddress = applicationUser.Email;

        //            return Page();
        //        }

        //        public IActionResult OnPost()
        //        {
        //            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
        //            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        //            ApplicationUser applicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(c => c.Id == claim.Value);

        //            UserReviews.Reviews.UserId = claim.Value;
        //            UserReviews.Reviews.AddDate = DateTime.Now;
        //            UserReviews.Reviews.AddedBy = applicationUser.FullName;

        //            UserReviews.Reviews.EmailAddress = applicationUser.Email;

        //            string webRootPath = _hostingEnvironment.WebRootPath;
        //            var files = HttpContext.Request.Form.Files;
        //            if (!ModelState.IsValid)
        //            {
        //                return Page();

        //            }
        //            if (UserReviews.Reviews.Id == 0)
        //            {
        //                string fileName = Guid.NewGuid().ToString();
        //                var uploads = Path.Combine(webRootPath, @"images\Reviewss");
        //                var extension = Path.GetExtension(files[0].FileName);
        //                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
        //                {
        //                    files[0].CopyTo(fileStream);
        //                }
        //                UserReviews.Reviews.ProductImage = @"\images\Reviewss\" + fileName + extension;

        //                _unitOfWork.Reviews.Add(UserReviews.Reviews);
        //            }
        //            else
        //            {
        //                var objFromDb = _unitOfWork.Reviews.Get(UserReviews.Reviews.Id);
        //                if (files.Count > 0)
        //                {
        //                    string fileName = Guid.NewGuid().ToString();
        //                    var uploads = Path.Combine(webRootPath, @"images\Reviewss");
        //                    var extension = Path.GetExtension(files[0].FileName);

        //                    var imagePath = Path.Combine(webRootPath, objFromDb.ProductImage.TrimStart('\\'));

        //                    if (System.IO.File.Exists(imagePath))
        //                    {
        //                        System.IO.File.Delete(imagePath);
        //                    }

        //                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
        //                    {
        //                        files[0].CopyTo(fileStream);
        //                    }
        //                    UserReviews.Reviews.ProductImage = @"\images\Reviewss\" + fileName + extension;
        //                }

        //                else
        //                {
        //                    UserReviews.Reviews.ProductImage = objFromDb.ProductImage;
        //                }
        //                _unitOfWork.Reviews.Update(UserReviews.Reviews);
        //            }
        //            _unitOfWork.Save();
        //            return RedirectToPage("/Customer/Home/");
        //        }
    }


}