using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBStore.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBStore.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class CityController : Controller
    {
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
      
        public CityController(IUnitOfWorkRepository unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
         
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWorkRepository.City.GetAll() });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
              var objFromDb = _unitOfWorkRepository.City.GetFirstOrDefault(u => u.Id == id);
                if (objFromDb == null)
                {
                    return Json(new { success = false, message = "Erroe while deleting" });
                }
                _unitOfWorkRepository.City.Remove(objFromDb);
                _unitOfWorkRepository.Save();
            
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}