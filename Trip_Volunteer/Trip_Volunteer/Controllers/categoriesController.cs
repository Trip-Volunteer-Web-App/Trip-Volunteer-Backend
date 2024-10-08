﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Trip_Volunteer.Core.Data;
using Trip_Volunteer.Core.Service;

namespace Trip_Volunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class categoriesController : ControllerBase
    {

        private readonly IcategoriesService _categoriesService;
        public categoriesController(IcategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        
        [HttpGet]
        [Route("GetAllcategories")]

        public List<Category> GetAllcategories()
        {
            return _categoriesService.GetAllcategories();
        }

        [HttpGet]
        [Route("GetcategoriesById/{id}")]
        public Category GetcategoriesById(int id)
        {
            return _categoriesService.GetcategoriesById(id);
        }



        [HttpPost]
        [Route("CREATEcategories")]
        public void CREATEcategories(Category category)
        {
            _categoriesService.CREATEcategories(category);
        }


        [HttpPut]
        [Route("UPDATEcategories")]

        public void UPDATEcategories(Category category)
        {
            _categoriesService.UPDATEcategories(category);
        }


        [HttpDelete]
        [Route("Deletecategories/{id}")]
        public void Deletecategories(int id)
        {
            _categoriesService.Deletecategories(id);
        }


    }
}
