using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using DBStore.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using DBStore.Models.VModels;

namespace DBStore.Pages.Admin.Brand
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UpsertModel(IUnitOfWorkRepository unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public BrandVM BrandObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            BrandObj = new BrandVM
            {

                Brand = new Models.Brand()

            };
            if (id != null)
            {
                BrandObj.Brand = _unitOfWork.Brand.GetFirstOrDefault(u => u.Id == id.GetValueOrDefault());
                if(BrandObj == null)
                {
                    return NotFound();
                }
            }
            return Page();

        }

        public IActionResult OnPost()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            if (!ModelState.IsValid)
            {
                return Page();

            }

            if (BrandObj.Brand.Id == 0)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\brands");
               
                    var extension = Path.GetExtension(files[0].FileName);
              

                    
                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                BrandObj.Brand.BrandIcon = @"\images\brands\" + fileName + extension;

                _unitOfWork.Brand.Add(BrandObj.Brand);
            }
            else
            {
                var objFromDb = _unitOfWork.Brand.Get(BrandObj.Brand.Id);
                if (files.Count > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\brands");
                    var extension = Path.GetExtension(files[0].FileName);

                    var imagePath = Path.Combine(webRootPath, objFromDb.BrandIcon.TrimStart('\\'));

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }

                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    BrandObj.Brand.BrandIcon = @"\images\brands\" + fileName + extension;
                }

                else
                {
                    BrandObj.Brand.BrandIcon = objFromDb.BrandIcon;
                }
              
                _unitOfWork.Brand.Update(BrandObj.Brand);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Brand");
        }
    }
}