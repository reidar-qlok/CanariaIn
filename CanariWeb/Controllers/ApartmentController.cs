using AutoMapper;
using CanariaWeb.Models.DTO;
using CanariWeb.Services.IServices;
using Canaria_Utility;
using CanariaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;
namespace MagicVilla_Web.Controllers
{
	public class ApartmentController : Controller
	{
		private readonly IApartmentService _apartmentService;
		private readonly IMapper _mapper;
		public ApartmentController(IApartmentService apartmentService, IMapper mapper)
		{
			_apartmentService = apartmentService;
			_mapper = mapper;
		}
		public async Task<IActionResult> IndexApartment()
		{
			List<ApartmentDto> list = new();

			var response = await _apartmentService.GetAllAsync<ApiResponse>();
			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<ApartmentDto>>(Convert.ToString(response.Result));
			}
			return View(list);
		}
		//GET
		public async Task<IActionResult> CreateApartment()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> CreateApartment(ApartmentCreateDto model)
		{
			if (ModelState.IsValid)
			{
				var response = await _apartmentService.CreateAsync<ApiResponse>(model);
				if (response != null && response.IsSuccess)

					return RedirectToAction(nameof(IndexApartment));
			}
			return View(model);
		}

        //GET
        public async Task<IActionResult> UpdateApartment(int apartmentid)
        {
            var response = await _apartmentService.GetAsync<ApiResponse>(apartmentid);
            if (response != null && response.IsSuccess)
			{
				ApartmentDto model = JsonConvert.DeserializeObject<ApartmentDto>(Convert.ToString(response.Result));
				return View(_mapper.Map<ApartmentUpdateDto>(model));
            }  
            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateApartment(ApartmentUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _apartmentService.UpdateAsync<ApiResponse>(model);
                if (response != null && response.IsSuccess)
				{
                    return RedirectToAction(nameof(IndexApartment));
                }    
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteApartment(int apartmentId)
		{
			var response = await _apartmentService.GetAsync<ApiResponse>(apartmentId);
			if (response != null && response.IsSuccess)
			{
				ApartmentDto model = JsonConvert.DeserializeObject<ApartmentDto>(Convert.ToString(response.Result));
				return View(model);
			}
			return NotFound();
		}
	}
}
