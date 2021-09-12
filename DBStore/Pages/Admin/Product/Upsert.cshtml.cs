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
using Microsoft.AspNetCore.Authorization;

namespace DBStore.Pages.Admin.Product
{
    [Authorize]
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
        public ProductVM ProductObj { get; set; }


        public IActionResult OnGet(int? id)
        {
            ProductObj = new ProductVM
            {

                CategoryList = _unitOfWork.Category.GetGategoryListForDropDown(),
                BrandList = _unitOfWork.Brand.GetBrandListForDropDown(),
                UnitList = _unitOfWork.Unit.GetUnitListForDropDown(),
                OfferList = _unitOfWork.OfferZone.GetOffertListForDropDown(),
                WarrantyList = _unitOfWork.WarrantyType.GetWarrantyTypeListForDropDown(),
                //ColorList = _unitOfWork.Color.GetColorListForDropDown(),
                Product = new Models.Product()



            };
            if (id != null)
            {
                ProductObj.Product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id.GetValueOrDefault());

                ProductObj.Product.AddDate = DateTime.Now;
                
                if (ProductObj.Product == null)
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
            int i = 0;
            foreach (var file in files)
            {
                Guid nameguid = Guid.NewGuid();
                string webrootpath = _hostingEnvironment.WebRootPath;
                string filename = nameguid.ToString();
                string extension = Path.GetExtension(file.FileName);
                string foldername = @"images\product";
                filename = filename + extension;
                string path = Path.Combine(webrootpath, foldername, filename);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                string pathName = Path.Combine(foldername, filename);
                if (i == 0)
                {
                    ProductObj.Product.Image = "~/images/product/" + filename;
                }
                if (i == 1)
                {
                    ProductObj.Product.Image1 = "~/images/product/" + filename;
                }
                if (i == 2)
                {
                    ProductObj.Product.Image2 = "~/images/product/" + filename;
                }
                if (i == 3)
                {
                    ProductObj.Product.Image3 = "~/images/product/" + filename;
                }
                i++;
            }
            if (!ModelState.IsValid)
            {
                return Page();

            }
            if (ProductObj.Product.Id == 0)
            {
                //string fileName = Guid.NewGuid().ToString();
                //var uploads = Path.Combine(webRootPath, @"images\products");
                //var extension = Path.GetExtension(files[0].FileName);
                //using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                //{
                //    files[0].CopyTo(fileStream);
                //}
                //ProductObj.Product.Image = @"\images\products\" + fileName + extension;
                ProductObj.Product.AddDate = DateTime.Now;

                _unitOfWork.Product.Add(ProductObj.Product);
            }
            else
            {
                var objFromDb = _unitOfWork.Product.Get(ProductObj.Product.Id);
                if (files.Count > 0)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\product");
                    var extension = Path.GetExtension(files[0].FileName);

                    var imagePath = Path.Combine(webRootPath, objFromDb.Image.TrimStart('\\'));

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }

                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    ProductObj.Product.Image = @"\images\product\" + fileName + extension;
                }

                else
                {
                    
                   
                    foreach (var file in files)
                    {
                        Guid nameguid = Guid.NewGuid();
                        string webrootpath = _hostingEnvironment.WebRootPath;
                        string filename = nameguid.ToString();
                        string extension = Path.GetExtension(file.FileName);
                        string foldername = @"images\product";
                        filename = filename + extension;
                        string path = Path.Combine(webrootpath, foldername, filename);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }
                        string pathName = Path.Combine(foldername, filename);
                        if (i == 0)
                        {
                            ProductObj.Product.Image = "~/images/product/" + filename;
                        }
                        if (i == 1)
                        {
                            ProductObj.Product.Image1 = "~/images/product/" + filename;
                        }
                        if (i == 2)
                        {
                            ProductObj.Product.Image2 = "~/images/product/" + filename;
                        }
                        if (i == 3)
                        {
                            ProductObj.Product.Image3 = "~/images/product/" + filename;
                        }
                        i++;
                    }
                }
                _unitOfWork.Product.Update(ProductObj.Product);
            }
            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}