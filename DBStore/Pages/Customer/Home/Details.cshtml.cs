using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DBStore.DataAccess.Data.Repository;
using DBStore.DataAccess.Data.Repository.IRepository;
using DBStore.Models;
using DBStore.Models.VModels;
using DBStore.Paging;
using DBStore.Utility;
using DevExpress.Data.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DBStore.Pages.Customer.Home
{

    // [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWorkRepository _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public DetailsModel(IUnitOfWorkRepository unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public ShoppingCart ShoppingCartObj { get; set; }
        [BindProperty]
        public ReviewsVM ReviewsObj { get; set; }
        [BindProperty]
        public AnswerVM AnswerObj { get; set; }

        [BindProperty]
        public QuestionVM QuestionObj { get; set; }
        [BindProperty]
        public ProductVM RelatedProdutObj { get; set; }
        //public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Models.Reviews> Reviews { get; set; }

        public IEnumerable<Models.Question> Questions { get; set; }

        public IEnumerable<ReviewsVM> ListReviews { get; set; }

        public IEnumerable<QuestionVM> ListQuestion { get; set; }

        public IEnumerable<Models.Product> RelatedProductList {get; set; }

        public IActionResult OnGet(int id)
        {
            //const int pageSize = 5;


            if (id < 1)
            {
                id = 1;
            }

            //var data = _unitOfWork.Reviews.GetAll().Skip(recSkip).Take(pagers.PageSize).ToList();
            //ViewData["pager"] = pagers;
            //Reviews = data;

            List<ReviewsVM> ListOfReviews = new List<ReviewsVM>();
            List<QuestionVM> ListOfQuestion = new List<QuestionVM>();

            //List<ProductVM> RelatedProductList = new List<ProductVM>();

            //RelatedProductList = _unitOfWork.Product.GetAll().ToList().Take(5);
            //foreach (var item in RelatedProductList)
            //{
            //    Category model = new Category();
            //    //var RelatedProduct = _unitOfWork.Product.GetAll().Where(c => c.Id == id).Take(5);

            //    item.CategoryId = model.Id;

            //    //ProductList.Add(model);


            //}

            QuestionObj = new QuestionVM()
            {

                Product = _unitOfWork.Product.GetFirstOrDefault(includeProperties: "Category,Brand,WarrantyType", filter: c => c.Id == id),
                ProductId = id
            };
            Questions = _unitOfWork.Question.GetAll(c => c.ProductId.Equals(id)).ToList();
          
            if (Questions != null)
            {
                foreach (var item in Questions)
                {
                    QuestionVM vm = new QuestionVM();
                    vm.ProductId = item.ProductId;
                    vm.Reviews = item.Description;
                    vm.Id = item.Id;
                    vm.Answer = item.Answer;
                    ListOfQuestion.Add(vm);
                }
            }

            ListQuestion = ListOfQuestion.AsEnumerable();

            ShoppingCartObj = new ShoppingCart()
            {
                Product = _unitOfWork.Product.GetFirstOrDefault(includeProperties: "Category,Brand,WarrantyType", filter: c => c.Id == id),
                ProductId = id
            };

            ReviewsObj = new ReviewsVM()
            {

                Product = _unitOfWork.Product.GetFirstOrDefault(includeProperties: "Category,Brand,WarrantyType", filter: c => c.Id == id),
                ProductId = id
            };

            //RelatedProdutObj = new ProductVM()
            //{

            //    Product = _unitOfWork.Product.GetFirstOrDefault(includeProperties: "Category,Brand,WarrantyType", filter: c => c.Id == id),
            //    CategoryId = RelatedProdutObj.CategoryId

            //};

            //int resCount = _unitOfWork.Reviews.GetAll().Where(c=>c.ProductId.Equals(id)).Count();
            //var pagers = new PagedList(resCount, id, pageSize);
            //int recSkip = (id - 1) * pageSize;
            var data  = _unitOfWork.Reviews.GetAll(c => c.ProductId.Equals(id)).ToList().Take(10);
           
            Reviews = data;
            var Ratings = _unitOfWork.Reviews.GetAll(c => c.ProductId.Equals(id)).ToList();
            if (Reviews != null)
            {
                foreach (var item in Reviews)
                {
                    ReviewsVM vm = new ReviewsVM();
                    vm.ProductId = item.ProductId;
                    vm.Reviews = item.Description;
                    vm.AddBy = item.AddedBy;
                    vm.AddDate = item.AddDate;
                    vm.ProductImage = item.ProductImage;
                    vm.Id = item.Id;
                    if (Ratings.Count() > 0)
                    {
                        var ratingSum = Ratings.Sum(c => c.Rating);
                        ViewData["RatingSum"] = ratingSum;
                        var ratingCount = Ratings.Count();
                        ViewData["RatingCount"] = ratingCount;

                    }
                    else
                    {
                        
                        ViewData["RatingSum"] = 0;
                        ViewData["RatingCount"] = 0;
                    }

                    ListOfReviews.Add(vm);
                }
            }

            ListReviews = ListOfReviews.AsEnumerable();

            return Page();
        }

        public IActionResult OnPostReviews(string returnUrl)
        {
            var redirectTarget = string.Empty;
            redirectTarget = string.IsNullOrWhiteSpace(returnUrl) ? "Details" : returnUrl;
            int num = Convert.ToInt32(HttpContext.Session.GetInt32("Num")) + 4;
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            int i = 0;
            foreach (var file in files)
            {
                Guid nameguid = Guid.NewGuid();
                string webrootpath = _hostingEnvironment.WebRootPath;
                string filename = nameguid.ToString();
                string extension = Path.GetExtension(file.FileName);
                string foldername = @"images\Reviews";
                filename = filename + extension;
                string path = Path.Combine(webrootpath, foldername, filename);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                string pathName = Path.Combine(foldername, filename);
                if (i == 0)
                {
                    ReviewsObj.ProductImage = "~/images/Reviews/" + filename;
                }
                //if (i == 1)
                //{
                //    ProductObj.Product.Image1 = "~/images/product/" + filename;
                //}
                //if (i == 2)
                //{
                //    ProductObj.Product.Image2 = "~/images/product/" + filename;
                //}
                //if (i == 3)
                //{
                //    ProductObj.Product.Image3 = "~/images/product/" + filename;
                //}
                i++;
            }
           
           

            if (ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)this.User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                if (claim == null)
                {
                    return Redirect("/Identity/Account/Login");


                }


                ApplicationUser applicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(c => c.Id == claim.Value);
                var Comment = _unitOfWork.Reviews.GetFirstOrDefault(c => c.ProductId == ReviewsObj.ProductId);
                var reviews = ReviewsObj.Reviews;
                var productId = ReviewsObj.ProductId;
                var rating = ReviewsObj.Rating;
                var productImage = ReviewsObj.ProductImage;
               

                Models.Reviews aComment = new Models.Reviews()
                {
                    ProductId = productId,
                    Description = reviews,
                    Rating = rating,
                    AddDate = DateTime.Now,
                    AddedBy = applicationUser.FullName,
                    ProductImage = productImage
                   

                };

                _unitOfWork.Reviews.Add(aComment);
                _unitOfWork.Save();

               
            }
            return RedirectToPage(redirectTarget, new { id = ReviewsObj.ProductId});
        }

        public IActionResult OnPostQuestion(string returnUrl)
        {
            var redirectTarget = string.Empty;
            redirectTarget = string.IsNullOrWhiteSpace(returnUrl) ? "Details" : returnUrl;
    
            if (ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)this.User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                if (claim == null)
                {
                    return Redirect("/Identity/Account/Login");


                }


                ApplicationUser applicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(c => c.Id == claim.Value);
               
                var reviews = QuestionObj.Reviews;
                var productId = QuestionObj.ProductId;
               


                Models.Question aComment = new Models.Question()
                {
                    ProductId = productId,
                    Description = reviews,
                    AddDate = DateTime.Now,
                    AddedBy = applicationUser.FullName
                   
                };

                _unitOfWork.Question.Add(aComment);
                _unitOfWork.Save();


            }
            return RedirectToPage(redirectTarget, new { id = ReviewsObj.ProductId });
        }

        //public void OnPostAnswer(string returnUrl)
        //{
        //    var redirectTarget = string.Empty;
        //    redirectTarget = string.IsNullOrWhiteSpace(returnUrl) ? "Details" : returnUrl;

        //    if (ModelState.IsValid)
        //    {
        //        var claimsIdentity = (ClaimsIdentity)this.User.Identity;
        //        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);


        //        ApplicationUser applicationUser = _unitOfWork.ApplicationUser.GetFirstOrDefault(c => c.Id == claim.Value);


        //        var questionId = AnswerObj.QuestionId;
        //        var answer = AnswerObj.AnswerQ;


        //        Models.Question aComment = new Models.Question()
        //        {
        //            Id = questionId,
        //           Answer = answer
             
        //        };

        //        _unitOfWork.Question.Add(aComment);
        //        _unitOfWork.Save();
               

        //    }
           
        //}


        public IActionResult OnPost(string returnUrl)
        {
            var redirectTarget = string.Empty;
            redirectTarget = string.IsNullOrWhiteSpace(returnUrl) ? "Details" : returnUrl;

            if (ModelState.IsValid)
            {
               
                var claimsIdentity = (ClaimsIdentity)this.User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                if (claim == null)
                {
                    return Redirect("/Identity/Account/Login");


                }
               
                
                ShoppingCartObj.ApplicationUserId = claim.Value;
                ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.GetFirstOrDefault(c => c.ApplicationUserId == ShoppingCartObj.ApplicationUserId &&
                 c.ProductId == ShoppingCartObj.ProductId);

                if (cartFromDb == null)
                {
                    _unitOfWork.ShoppingCart.Add(ShoppingCartObj);
                }

                
                else
                {
                    _unitOfWork.ShoppingCart.Remove(cartFromDb, ShoppingCartObj.Count);
                }
                _unitOfWork.Save();

                
                var count = _unitOfWork.ShoppingCart.GetAll(c => c.ApplicationUserId == ShoppingCartObj.ApplicationUserId).ToList().Count;
                HttpContext.Session.SetInt32(SD.ShoppingCart, count);
                //if (cartFromDb != null)
                //{
                //    //string url = this.Request.UrlReferrer.AbsolutePath;

                //    //return Redirect(url);
                //    return new PageResult();

                //}

            }


            return RedirectToPage(redirectTarget, new { id = ShoppingCartObj.ProductId });
        }

     
    }
}
