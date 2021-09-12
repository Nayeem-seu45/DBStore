using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBStore.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWorkRepository : IDisposable
    {
        ICategoryRepository Category { get; }

        IProductRepository Product { get; }

        IShoppingCartRepository ShoppingCart { get; }

        IApplicationUserRepository ApplicationUser{get; }

        IOrderHeaderRepository OrderHeader { get; }
        IOrderDetailsRepository OrderDetails { get; }

        ISlideShowRepository SlideShow { get; }

        IBrandRepository Brand { get; }

        ICityRepository City { get; }

        IUnitRepository Unit { get; }
        IWarrantyTypeRepository WarrantyType { get; }

        IPaymentMathodRepository PaymentMathod { get; }

        IRequestProductRepository RequestProduct { get; }
        IColorRepository Color { get; }
        IReviewsRepository Reviews { get; }

        IMessageRepository Massage { get; }
        IOfferZoneRepository OfferZone { get; }

        IQuestionRepository Question { get; }
        void Save();
    }
}
