using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DBStore.DataAccess.Data.Repository.IRepository;
using DBStore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DBStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class SlideShowController : Controller
    {
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public SlideShowController(IUnitOfWorkRepository unitOfWorkRepository, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            _hostingEnvironment = hostingEnvironment;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWorkRepository.SlideShow.GetAll() });
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var objFromDb = _unitOfWorkRepository.SlideShow.GetFirstOrDefault(u => u.Id == id);
                if (objFromDb == null)
                {
                    return Json(new { success = false, message = "Erroe while deleting" });
                }
                var imagePath = Path.Combine(_hostingEnvironment.WebRootPath, objFromDb.ImgUrl.TrimStart('\\'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }

                _unitOfWorkRepository.SlideShow.Remove(objFromDb);
                _unitOfWorkRepository.Save();
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = "Erroe while deleting" });
            }
           

            return Json(new { success = true, message = "Delete successful" });
        }

    }
}