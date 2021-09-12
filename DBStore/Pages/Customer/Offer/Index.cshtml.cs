using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBStore.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DBStore.Pages.Customer.Offer
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWorkRepository _unitOfWork;

        public IndexModel(IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IEnumerable<Models.Product> DealOfTheDayList { get; set; }
        public IEnumerable<Models.Product> ToOfferList { get; set; }
        public IEnumerable<Models.Product> GadgetTopList { get; set; }

        public void OnGet()
        {
            var dt = "Deals Of The day";
            var ct = "Gadget Top Deals ";
            var bt = "Top Offers";
            DealOfTheDayList = _unitOfWork.Product.GetAll(s => s.OfferZone.Name == dt, null, "OfferZone").Take(12).ToList();
            ToOfferList = _unitOfWork.Product.GetAll(s => s.OfferZone.Name == bt, null, "OfferZone").Take(12).ToList();
            GadgetTopList = _unitOfWork.Product.GetAll(s => s.OfferZone.Name == ct, null, "OfferZone").Take(12).ToList();
        }
    }
}
