using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using DBStore.DataAccess.Data.Repository.IRepository;
using DBStore.Models.VModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace DBStore.Pages.Admin.Category
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UpsertModel(IUnitOfWorkRepository unitOfWork,IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public  CategoryVM CategoryObj  { get; set; }

        public IActionResult OnGet(int? id)
        {
            CategoryObj = new CategoryVM
            {

                Category = new Models.Category()

            };
            if (id != null)
            {
                CategoryObj.Category = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == id.GetValueOrDefault());
                if(CategoryObj == null)
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
            if(CategoryObj.Category.Id == 0)
            {
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\categores");

                    var extension = Path.GetExtension(files[0].FileName);



                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    CategoryObj.Category.CatIcon = @"\images\categores\" + fileName + extension;

                    _unitOfWork.Category.Add(CategoryObj.Category);
                };
            }
            else
            {
                var objFromDb = _unitOfWork.Category.Get(CategoryObj.Category.Id);
                if (files.Count > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\categores");
                    var extension = Path.GetExtension(files[0].FileName);

                    var imagePath = Path.Combine(webRootPath, objFromDb.CatIcon.TrimStart('\\'));

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }

                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    CategoryObj.Category.CatIcon = @"\images\categores\" + fileName + extension;
                }

                else
                {
                    CategoryObj.Category.CatIcon = objFromDb.CatIcon;
                }

                _unitOfWork.Category.Update(CategoryObj.Category);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}