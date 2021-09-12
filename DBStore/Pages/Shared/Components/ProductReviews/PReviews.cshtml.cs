using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DBStore.DataAccess.Data.Repository.IRepository;
using DBStore.Models;
using DBStore.Models.VModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DBStore.Pages.Shared.Components.ProductReviews
{
    public class PReviewsModel : PageModel
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public PReviewsModel(IUnitOfWorkRepository unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public ProductDetails ProductDetailsObj { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnGet(int? id)
        {
            ProductDetailsObj = new ProductDetails
            {

                Reviews = new Models.Reviews()

            };
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (id != null)
            {
                ProductDetailsObj.Reviews = _unitOfWork.Reviews.GetFirstOrDefault(u => u.Id == id.GetValueOrDefault());
                if (ProductDetailsObj.Reviews == null)
                {
                    return NotFound();
                }
            }

            ApplicationUser applicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(c => c.Id == claim.Value);
            ProductDetailsObj.Reviews.YourName = applicationUser.FullName;

            ProductDetailsObj.Reviews.EmailAddress = applicationUser.Email;
            return Page();

        }

        public IActionResult ReviewsPost()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);


            ProductDetailsObj.Reviews.AddDate = DateTime.Now;
            ProductDetailsObj.Reviews.UserId = claim.Value;

            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            if (!ModelState.IsValid)
            {
                return Page();

            }
            if (ProductDetailsObj.Reviews.Id == 0)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\Reviews");
                var extension = Path.GetExtension(files[0].FileName);
                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                ProductDetailsObj.Reviews.ProductImage = @"\images\Reviews\" + fileName + extension;

                _unitOfWork.Reviews.Add(ProductDetailsObj.Reviews);
            }
            else
            {
                var objFromDb = _unitOfWork.RequestProduct.Get(ProductDetailsObj.Reviews.Id);
                if (files.Count > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\Reviews");
                    var extension = Path.GetExtension(files[0].FileName);

                    var imagePath = Path.Combine(webRootPath, objFromDb.ImgUrl.TrimStart('\\'));

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }

                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    ProductDetailsObj.Reviews.ProductImage = @"\images\Reviews\" + fileName + extension;
                }

                else
                {
                    ProductDetailsObj.Reviews.ProductImage = objFromDb.ImgUrl;
                }
                _unitOfWork.Reviews.Update(ProductDetailsObj.Reviews);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}