using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBStore.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace DBStore.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;

        public CategoryController(IUnitOfWorkRepository unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository; 
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWorkRepository.Category.GetAll() });
        }

        [HttpDelete("{id}")]

        public IActionResult Delete (int id)
        {
            var objFromDb = _unitOfWorkRepository.Category.GetFirstOrDefault(u => u.Id == id);
            if(objFromDb == null)
            {
                return Json(new { success = false, message = "Erroe while deleting" });
            }
            _unitOfWorkRepository.Category.Remove(objFromDb);
            _unitOfWorkRepository.Save();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
