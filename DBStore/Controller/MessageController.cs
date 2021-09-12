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
    
    public class MessageController : Controller
    {
        private readonly IUnitOfWorkRepository _unitOfWorkRepository;
      

        public MessageController(IUnitOfWorkRepository unitOfWorkRepository)
        {
            _unitOfWorkRepository = unitOfWorkRepository;
            
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWorkRepository.Massage.GetAll() });
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var objFromDb = _unitOfWorkRepository.Massage.GetFirstOrDefault(u => u.Id == id);
                if (objFromDb == null)
                {
                    return Json(new { success = false, message = "Erroe while deleting" });
                }
               

                _unitOfWorkRepository.Massage.Remove(objFromDb);
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