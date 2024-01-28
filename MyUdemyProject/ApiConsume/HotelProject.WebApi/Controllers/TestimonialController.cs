﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;

        }
        [HttpGet]
        public IActionResult TestimonialList()
        {
            var entities = _testimonialService.TGetList();
            return Ok(entities);
        }
        [HttpPost]
        public IActionResult AddTestimonial(Testimonial testimonial)
        {

            _testimonialService.TInsert(testimonial);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var entity = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(entity);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            _testimonialService.TUpdate(testimonial);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var entity = _testimonialService.TGetByID(id);
            

            return Ok(entity);
        }
    }
}
