using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebPPublished.DTO;
using WebPPublished.Manager;
using WebPPublished.Models;

namespace WebPPublished.ApiControllers
{
    public class CategoriesController : ApiController
    {
        [HttpGet]
        public IEnumerable<CategoryHeaderData> GetAllCategories()
        {
            return new CategoryManager().GetAllCategory();
        }
    }
}
