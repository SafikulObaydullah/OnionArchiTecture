using DomainLayer.Models;
using DomainLayer.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer;
using ServicesLayer.CustomerService;
using ServicesLayer.CustomerService.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnionArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        public CountryController()
        {
                
        }
        //#region Property
        //private readonly ICountryService _customerService;
        //#endregion

        //#region Constructor
        //public CountryController(ICountryService countryService)
        //{
        //    _customerService = countryService;
        //}
        //#endregion

        //[HttpGet(nameof(GetCountry))]
        //public IActionResult GetCountry(int id)
        //{
        //    var result = _customerService.GetCountry(id);
        //    if (result is not null)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest("No records found");

        //}
        //[HttpGet(nameof(GetAllCountry))]
        //public IActionResult GetAllCountry()
        //{
        //    var result = _customerService.GetAllCountry();
        //    if (result is not null)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest("No records found");

        //}
        //[HttpPost(nameof(InsertCountry))]
        //public IActionResult InsertCountry(CreateCountry country)
        //{
        //    _customerService.InsertCountry(country);
        //    return Ok("Data inserted");
        //}
        //[AllowAnonymous]
        //[HttpPut(nameof(UpdateCountry))]
        //public IActionResult UpdateCountry(int id, UpadteCountry country)
        //{
        //    _customerService.UpdateCountry(id, country);
        //    return Ok("Updation done");

        //}
        //[HttpDelete(nameof(DeleteCountry))]
        //public IActionResult DeleteCountry(int Id)
        //{
        //    _customerService.DeleteCountry(Id);
        //    return Ok("Data Deleted");

        //}
    }
}
