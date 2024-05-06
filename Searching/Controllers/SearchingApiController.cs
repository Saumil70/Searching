using Microsoft.AspNetCore.Mvc;
using Searching.Repository.IRepository;
using Searching.ViewModel;

namespace Searching.Controllers
{
    [Route("api/SearchingApi")]
    [ApiController]
    public class SearchingApiController : Controller
    {
        public readonly IUnitOfWork _unitOfWork;

        public SearchingApiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("ProductList")]
        public IActionResult ProductList()
        {
            var products = _unitOfWork.ProductRepository.GetAll().ToList();

            return Ok(products);
        }

        [HttpGet("Search")]
        public JsonResult Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                var data = _unitOfWork.ProductRepository.GetAll().ToList();
                return Json(data);
            }
            else
            {
                var data = _unitOfWork.ProductRepository.GetAll(
                    u => (u.ProductName.Contains(searchTerm) ||
                          u.BrandName.Contains(searchTerm) ||
                          u.Categories.CategoryName.Contains(searchTerm) ||
                          u.ProductVariantMappings.Any(pvm => pvm.Variants.Ram.ToString().Contains(searchTerm.Replace("GB","")) ||
                                                                    pvm.Variants.Storage.Contains(searchTerm) ||
                                                                    pvm.Variants.Processor.Contains(searchTerm))) &&
                         !string.IsNullOrEmpty(u.ProductName) &&
                         !string.IsNullOrEmpty(u.BrandName) &&
                         !string.IsNullOrEmpty(u.Categories.CategoryName),
                    includeProperties: "Categories,ProductVariantMappings.Variants"
                ).ToList();

                return Json(data);
            }
        }

        [HttpGet("SearchByFilter")]
        public JsonResult SearchByFilter(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                var data = _unitOfWork.ProductRepository.GetAll().ToList();
                return Json(data);
            }
            else
            {
                var searchTerms = searchTerm.Split(',');

                // Fetch products based on category
                var categoryFilteredData = _unitOfWork.ProductRepository.GetAll(u => u.Categories.CategoryName == searchTerms[0]);

                // Apply additional search conditions
                var filteredData = categoryFilteredData.Where(u =>
                    searchTerms.Skip(1).Any(st =>
                        u.ProductName.Contains(st) ||
                        u.BrandName.Contains(st) ||
                        u.Categories.CategoryName.Contains(st) ||
                        u.ProductVariantMappings.Any(pvm =>
                            pvm.Variants.Ram.ToString().Equals(st) ||
                            pvm.Variants.Storage.Equals(st) ||
                            pvm.Variants.Processor.Equals(st)
                        )
                    ) &&
                    !string.IsNullOrEmpty(u.ProductName) &&
                    !string.IsNullOrEmpty(u.BrandName) &&
                    !string.IsNullOrEmpty(u.Categories.CategoryName)
                ).ToList();

                return Json(filteredData);
            }
        }


    }
}
