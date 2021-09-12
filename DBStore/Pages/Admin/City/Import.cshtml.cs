using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBStore.DataAccess.Data.Repository.IRepository;
using DBStore.Models.VModels;
using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace DBStore.Pages.Admin.City
{
    public class ImportModel : PageModel
    {
        private IUnitOfWorkRepository _unitOfWork;
        private IWebHostEnvironment _hostingEnvironment;

        public ImportModel(IUnitOfWorkRepository unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        public void OnGet()
        {

        }
        [BindProperty]
        public CityVM CityObj { get; set; }


        //public IActionResult OnPost()
        //{
        //    var citycount = _unitOfWork.City.GetAll().Count();
        //    if (citycount > 0)

        //    {
        //        IFormFile file = Request.Form.Files[0];
        //        int startRec = Convert.ToInt32(HttpContext.Request.Form["start"][0]);
        //        string folderName = "ExcelFile";
        //        string webRootPath = _hostingEnvironment.WebRootPath;
        //        string newPath = Path.Combine(webRootPath, folderName);
        //        StringBuilder sb = new StringBuilder();
        //        if (!Directory.Exists(newPath))
        //        {
        //            Directory.CreateDirectory(newPath);
        //        }

        //        _unitOfWork.City.Add(CityObj.City);
        //    }
        //    else
        //    {
        //         int startRec = Convert.ToInt32(HttpContext.Request.Form["start"][0]);
        //        IFormFile file = Request.Form.Files[0];

        //        string folderName = "ExcelFile";
        //        string webRootPath = _hostingEnvironment.WebRootPath;
        //        string newPath = Path.Combine(webRootPath, folderName);

        //        if (file.Length > 0)
        //        {
        //            string sFileExtension = Path.GetExtension(file.FileName).ToLower();
        //            //ISheet sheet;
        //            string fullPath = Path.Combine(newPath, file.FileName);
        //            using (var stream = System.IO.File.Create(fullPath))
        //            {
        //                file.CopyToAsync(stream);
        //            }
        //            using (var streams = System.IO.File.Open(fullPath, FileMode.Open, FileAccess.Read))
        //            {
        //                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        //                using (var reader = ExcelReaderFactory.CreateReader(streams))
        //                {
        //                    while (reader.Read())
        //                    {
        //                        if (reader.GetValue(0) != null)
        //                        {

        //                            CityObj.City.Name = reader.GetValue(1) != null ? reader.GetValue(startRec).ToString() : "Not defined";
        //                            CityObj.City.AddDate = DateTime.Now;
        //                            CityObj.City.AddedBy = "1";
        //                            CityObj.City.Status = 1;


        //                        }

        //                    }
        //                }
        //                System.IO.File.Delete(fullPath);
        //            }

        //        }
        //        _unitOfWork.City.Update(CityObj.City);


        //    }
        //    return this.Content("Successfully saved in database");
        //}


        public void OnPost(IFormFile file)
        {

            //    IFormFile file = Request.Form.Files[0];
            //    int startRec = Convert.ToInt32(HttpContext.Request.Form["start"][0]); //startRec te value pass hoscche nah
            //    string folderName = "ExcelFile";
            //    string webRootPath = _hostingEnvironment.ContentRootPath;
            //    string newPath = Path.Combine(webRootPath, folderName);
            //    StringBuilder sb = new StringBuilder();
            //    if (!Directory.Exists(newPath))
            //    {
            //        Directory.CreateDirectory(newPath);
            //    }
            //    if (file.Length > 0)
            //    {
            //        string sFileExtension = Path.GetExtension(file.FileName).ToLower();
            //        //ISheet sheet;
            //        string fullPath = Path.Combine(newPath, file.FileName);
            //        using (var stream = System.IO.File.Create(fullPath))
            //        {
            //            file.CopyToAsync(stream);
            //        }
            //        using (var streams = System.IO.File.Open(fullPath, FileMode.Open, FileAccess.Read))
            //        {
            //            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            //            using (var reader = ExcelReaderFactory.CreateReader(streams))
            //            {
            //                while (reader.Read())
            //                {
            //                    if (reader.GetValue(0) != null)
            //                    {

            //                        CityObj.City.Name = reader.GetValue(1) != null ? reader.GetValue(startRec).ToString() : "Not defined";
            //                        CityObj.City.AddDate = DateTime.Now;
            //                        CityObj.City.AddedBy = "1";
            //                        CityObj.City.Status = 1;
            //                        //datas.LastName = reader.GetValue(2) != null ? reader.GetValue(1).ToString() : "Last Name";
            //                        //datas.Email = reader.GetValue(3) != null ? reader.GetValue(1).ToString() : "Email";
            //                        //datas.FbLink = reader.GetValue(4) != null ? reader.GetValue(1).ToString() : "FbLink";
            //                        _unitOfWork.City.Add(CityObj.City);
            //                    }

            //                }
            //            }
            //            System.IO.File.Delete(fullPath);
            //        }

            //    }
            //    return this.Content("Successfully saved in database");
            //}
            List<CityVM> users = new List<CityVM>();
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                stream.Position = 0;
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read()) //Each row of the file
                    {
                        //users.Add(new CityVM { Name = reader.GetValue(0).ToString(), City = reader.GetValue(1).ToString() });
                    }
                }
            }


        }
    }
}
