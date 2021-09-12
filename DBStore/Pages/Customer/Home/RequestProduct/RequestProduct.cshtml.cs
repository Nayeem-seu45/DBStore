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

namespace DBStore.Pages.Customer.Home.RequestProduct
{
    public class RequestProductModel : PageModel
    {
          private readonly IUnitOfWorkRepository _unitOfWork;
            private readonly IWebHostEnvironment _hostingEnvironment;

            public RequestProductModel(IUnitOfWorkRepository unitOfWork, IWebHostEnvironment hostingEnvironment)
            {
                _unitOfWork = unitOfWork;
                _hostingEnvironment = hostingEnvironment;
            }

            [BindProperty]
            public RequestProductVM RequestProductObj { get; set; }

            public IActionResult OnGet(int? id)
            {
                RequestProductObj = new RequestProductVM
                {

                    RequestProduct = new Models.RequestProduct()

                };
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null)
            {
                return Redirect("/Identity/Account/Login");



                
            }
            
            if (id != null)
                {
                    RequestProductObj.RequestProduct = _unitOfWork.RequestProduct.GetFirstOrDefault(u => u.Id == id.GetValueOrDefault());
                    if (RequestProductObj.RequestProduct == null)
                    {
                        return NotFound();
                    }
                }

                ApplicationUser applicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(c => c.Id == claim.Value);
              RequestProductObj.RequestProduct.YourName = applicationUser.FullName;

              RequestProductObj.RequestProduct.Email = applicationUser.Email;
            return Page();

            }

            public IActionResult OnPost()
            {
            if (ModelState.IsValid)
            {


                return RedirectToPage("/Customer/Home/RequestProduct/RequestProduct");

            }
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            RequestProductObj.RequestProduct.UserId = claim.Value;
            string webRootPath = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if (ModelState.IsValid)
                {
                
               
                return RedirectToPage("/Customer/Home/RequestProduct/RequestProduct");

                }
                if (RequestProductObj.RequestProduct.Id == 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\RequestProducts");
                    var extension = Path.GetExtension(files[0].FileName);
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    RequestProductObj.RequestProduct.ImgUrl = @"\images\RequestProducts\" + fileName + extension;

                    _unitOfWork.RequestProduct.Add(RequestProductObj.RequestProduct);
                }
                else
                {
                    var objFromDb = _unitOfWork.RequestProduct.Get(RequestProductObj.RequestProduct.Id);
                    if (files.Count > 0)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        var uploads = Path.Combine(webRootPath, @"images\RequestProducts");
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
                        RequestProductObj.RequestProduct.ImgUrl = @"\images\RequestProducts\" + fileName + extension;
                    }

                    else
                    {
                        RequestProductObj.RequestProduct.ImgUrl = objFromDb.ImgUrl;
                    }
                    _unitOfWork.RequestProduct.Update(RequestProductObj.RequestProduct);
                }
                _unitOfWork.Save();
                return RedirectToPage("./Index");
            }
    }
       
    
}