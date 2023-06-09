﻿using AutoMapper;
using Azure;
using CanariaApi.Data;
using CanariaApi.Models;
using CanariaApi.Models.DTO;
using CanariaApi.Repository.Irepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace CanariaApi.Controllers
{
    [Route("api/CanariaApi")]
    [ApiController]
    public class CanariaApiController : Controller
    {
        private readonly IApartmentRepository _CanariDb;
        private readonly IMapper _mapper;
        protected ApiResponse _apiResponse;
        public CanariaApiController(IApartmentRepository context, IMapper mapper)
        {
            _CanariDb = context;
            _mapper = mapper;
            this._apiResponse = new();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse>> GetApartment()
        {
            try
            {
                IEnumerable<Apartment> apartmentList = await _CanariDb.GetAllAsync();
                _apiResponse.Result = _mapper.Map<List<ApartmentDto>>(apartmentList);
                _apiResponse.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _apiResponse;
        }
        [HttpGet("{id:int}", Name ="GetApartment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse>> GetApartment(int id)
        {
            try
            {
                if (id == 0)
                {
                    _apiResponse.StatusCode=HttpStatusCode.BadRequest;
                    return BadRequest(_apiResponse);
                }
                var apartment = await _CanariDb.GetAsync(ap => ap.ApartmentId == id);
                if (apartment == null)
                {
                    _apiResponse.StatusCode = HttpStatusCode.NotFound;
                    return BadRequest(_apiResponse);
                }
                _apiResponse.Result = _mapper.Map<ApartmentDto>(apartment);
                _apiResponse.StatusCode = HttpStatusCode.OK;
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _apiResponse;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> CreateApartment([FromBody] ApartmentCreateDto createDto)
        {
            try
            {
                if (await _CanariDb.GetAsync(ap => ap.Name.ToLower() == createDto.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("Custom error", "This apartment alredy exist");
                    return BadRequest(ModelState);
                }
                if (createDto == null)
                {
                    return BadRequest(createDto);
                }
                Apartment apartment = _mapper.Map<Apartment>(createDto);
                await _CanariDb.CreateAsync(apartment);
                _apiResponse.Result = _mapper.Map<ApartmentDto>(apartment);
                _apiResponse.StatusCode = System.Net.HttpStatusCode.Created;
                return CreatedAtRoute("GetApartment", new { id = apartment.ApartmentId }, _apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _apiResponse;
        }
        [HttpDelete("{id:int}", Name = "DeleteApartment")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse>> DeleteApartment(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var apartment = await _CanariDb.GetAsync(ap => ap.ApartmentId == id);
                if (apartment == null)
                {
                    return NotFound();
                }
                await _CanariDb.RemoveAsync(apartment);
                _apiResponse.StatusCode = System.Net.HttpStatusCode.NoContent;
                _apiResponse.IsSuccess = true;
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _apiResponse;
        }
        [HttpPut("{id:int}", Name = "UpdateApartment")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse>> UpdateApartment(int id, [FromBody] ApartmentUpdateDto updateDto)
        {
            try
            {
                if (updateDto == null || id != updateDto.ApartmentId)
                {
                    return BadRequest();
                }
                //var apartment = _CanariDb.GetAsync(ap => ap.ApartmentId == id, tracked:false);
                Apartment model = _mapper.Map<Apartment>(updateDto);

                await _CanariDb.UpdateAsync(model);
                _apiResponse.StatusCode = HttpStatusCode.NoContent;
                _apiResponse.IsSuccess = true;
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _apiResponse;
        }
        [HttpPatch("{id:int}", Name = "UpdatePartialApartment")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialApartment(int id, JsonPatchDocument<ApartmentUpdateDto> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }
            var apartment = await _CanariDb.GetAsync(ap => ap.ApartmentId == id, tracked: false);
            ApartmentUpdateDto apartmentDto = _mapper.Map<ApartmentUpdateDto>(apartment);
            if (apartment==null)
            {
                return BadRequest();
            }
            patchDto.ApplyTo(apartmentDto, ModelState);
            Apartment model = _mapper.Map<Apartment>(apartmentDto);

            await _CanariDb.UpdateAsync(model);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}
