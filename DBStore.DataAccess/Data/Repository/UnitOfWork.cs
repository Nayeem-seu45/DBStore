
using System;
using System.Collections.Generic;
using System.Text;
using DBStore.DataAccess.Data.Repository.IRepository;
using DBStore.Models;
using DBStore.Models.CMS;
using Microsoft.AspNetCore.SignalR;
using Stripe;

namespace DBStore.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWorkRepository
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            OrderHeader = new OrderHeaderRepository(_db);
            OrderDetails = new OrderDetailsRepository(_db);
            SlideShow = new SlideShowRepository(_db);
            Brand = new BrandRepository(_db);
            City = new CityRepository(_db);
            Unit = new UnitRepository(_db);
            WarrantyType = new WarrantyTypeRepository(_db);
            RequestProduct = new RequestProductRepository(_db);
            PaymentMathod = new PaymentMathodRepository(_db);
            Color = new ColorRepository(_db);
            Reviews = new ReviewsRepository(_db);
            Massage = new MessageRepository(_db);
            OfferZone = new OfferZoneRepository(_db);
            Question = new QuestionRepository(_db);
        }

        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product{ get; private set; }

        public IShoppingCartRepository ShoppingCart { get; private set; }

        public IApplicationUserRepository ApplicationUser { get; private set; }

        public IOrderDetailsRepository OrderDetails { get; private set; }

        public IOrderHeaderRepository OrderHeader { get; private set; }

        public ISlideShowRepository SlideShow { get; private set; }

        public IBrandRepository Brand { get; private set; }

        public ICityRepository City { get; private set; }
        public IUnitRepository Unit { get; private set; }
        public IWarrantyTypeRepository WarrantyType { get; private set; }
        public IPaymentMathodRepository PaymentMathod { get; private set; }
        public IRequestProductRepository RequestProduct { get; private set; }

        public IColorRepository Color { get; private set; }

        public IReviewsRepository Reviews { get; private set; }
        public IMessageRepository Massage { get; private set; }

        public IQuestionRepository Question { get; private set; }

        public IOfferZoneRepository OfferZone { get; private set; }


        //ICategoryRepository IUnitOfWorkRepository.Category => throw new NotImplementedException();

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        //void IDisposable.Dispose()
        //{
        //    throw new NotImplementedException();
        //}

        //void IUnitOfWorkRepository.Save()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
