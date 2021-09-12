using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using DBStore.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using DBStore.Models.VModels;
using System.IO;
using System.Collections.Immutable;

namespace DBStore.Pages.Admin.SlideShow
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
        public SlideShowVM SlideShowObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            SlideShowObj = new SlideShowVM
            {

                SlideShow = new Models.CMS.SlideShow()
                
            };
            if(id != null)
            {
                SlideShowObj.SlideShow = _unitOfWork.SlideShow.GetFirstOrDefault(u => u.Id == id.GetValueOrDefault());
                if(SlideShowObj.SlideShow == null)
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
            if(!ModelState.IsValid)
            {
                return Page();

            }
            if(SlideShowObj.SlideShow.Id == 0)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\slideShows");
                var extension = Path.GetExtension(files[0].FileName);
                using(var fileStream = new FileStream(Path.Combine(uploads,fileName+extension), FileMode.Create ))
                {
                    files[0].CopyTo(fileStream);
                }
                SlideShowObj.SlideShow.ImgUrl = @"\images\slideShows\" + fileName+ extension ;

                _unitOfWork.SlideShow.Add(SlideShowObj.SlideShow);
            }
            else
            {
                var objFromDb = _unitOfWork.SlideShow.Get(SlideShowObj.SlideShow.Id);
                if(files.Count >0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\slideShows");
                    var extension = Path.GetExtension(files[0].FileName);

                    var imagePath = Path.Combine(webRootPath, objFromDb.ImgUrl.TrimStart('\\'));

                    if(System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }

                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    SlideShowObj.SlideShow.ImgUrl = @"\images\slideShows\" + fileName + extension;
                }

                else
                {
                    SlideShowObj.SlideShow.ImgUrl = objFromDb.ImgUrl;
                }
                _unitOfWork.SlideShow.Update(SlideShowObj.SlideShow);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}