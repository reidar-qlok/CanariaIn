using AutoMapper;
using Azure;
using CanariaApi.Data;
using CanariaApi.Migrations;
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
    [Route("api/CanariaNumberApi")]
    [ApiController]
    public class CanariaNumberApiController : Controller
    {
        private readonly IApartmentNumberRepository _CanariDb;
        private readonly IApartmentRepository _ApartmentDb;
        private readonly IMapper _mapper;
        protected ApiResponse _apiResponse;
        public CanariaNumberApiController(IApartmentNumberRepository context, IApartmentRepository ApartmentDb, IMapper mapper)
        {
            _CanariDb = context;
            _ApartmentDb = ApartmentDb;
            _mapper = mapper;
            this._apiResponse = new();
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse>> GetApartmentNumber()
        {
            try
            {
                IEnumerable<ApartmentNumber> apartmentNumberList = await _CanariDb.GetAllAsync();
                _apiResponse.Result = _mapper.Map<List<ApartmentNumberDto>>(apartmentNumberList);
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
        [HttpGet("{id:int}", Name = "GetApartmentNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse>> GetApartmentNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    _apiResponse.StatusCode=HttpStatusCode.BadRequest;
                    return BadRequest(_apiResponse);
                }
                var apartmentNumber = await _CanariDb.GetAsync(ap => ap.ApartmentNo == id);
                if (apartmentNumber == null)
                {
                    _apiResponse.StatusCode = HttpStatusCode.NotFound;
                    return BadRequest(_apiResponse);
                }
                _apiResponse.Result = _mapper.Map<ApartmentNumberDto>(apartmentNumber);
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
        public async Task<ActionResult<ApiResponse>> CreateApartmentNumber([FromBody] ApartmentNumberCreateDto createDto)
        {
            try
            {
                if (await _CanariDb.GetAsync(ap => ap.ApartmentNo == createDto.ApartmentNo) != null)
                {
                    ModelState.AddModelError("Custom error", "This apartment number alredy exist");
                    return BadRequest(ModelState);
                }
                if (await _ApartmentDb.GetAsync(apdb=>apdb.ApartmentId==createDto.FkApartmentId)==null)
                {
                    ModelState.AddModelError("CustomError", "Apartment id is not valid");
                    return BadRequest(ModelState);
                }
                if (createDto == null)
                {
                    return BadRequest(createDto);
                }
                ApartmentNumber apartmentNumber = _mapper.Map<ApartmentNumber>(createDto);
                await _CanariDb.CreateAsync(apartmentNumber);
                _apiResponse.Result = _mapper.Map<ApartmentNumberDto>(apartmentNumber);
                _apiResponse.StatusCode = System.Net.HttpStatusCode.Created;
                return CreatedAtRoute("GetApartment", new { id = apartmentNumber.ApartmentNo }, _apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages
                    = new List<string>() { ex.ToString() };
            }
            return _apiResponse;
        }
        [HttpDelete("{id:int}", Name = "DeleteApartmentNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse>> DeleteApartmentNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var apartmentNumber = await _CanariDb.GetAsync(ap => ap.ApartmentNo == id);
                if (apartmentNumber == null)
                {
                    return NotFound();
                }
                await _CanariDb.RemoveAsync(apartmentNumber);
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
        [HttpPut("{id:int}", Name = "UpdateApartmentNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse>> UpdateApartmentNumber(int id, [FromBody] ApartmentNumberUpdateDto updateDto)
        {
            try
            {
                if (updateDto == null || id != updateDto.ApartmentNo)
                {
                    return BadRequest();
                }
                if (await _ApartmentDb.GetAsync(apdb => apdb.ApartmentId == updateDto.FkApartmentId) == null)
                {
                    ModelState.AddModelError("CustomError", "Apartment id is not valid");
                }
                //var apartment = _CanariDb.GetAsync(ap => ap.ApartmentId == id, tracked:false);
                ApartmentNumber model = _mapper.Map<ApartmentNumber>(updateDto);

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
        //[HttpPatch("{id:int}", Name = "UpdatePartialApartment")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> UpdatePartialApartment(int id, JsonPatchDocument<ApartmentUpdateDto> patchDto)
        //{
        //    if (patchDto == null || id == 0)
        //    {
        //        return BadRequest();
        //    }
        //    var apartment = await _CanariDb.GetAsync(ap => ap.ApartmentId == id, tracked: false);
        //    ApartmentUpdateDto apartmentDto = _mapper.Map<ApartmentUpdateDto>(apartment);
        //    if (apartment==null)
        //    {
        //        return BadRequest();
        //    }
        //    patchDto.ApplyTo(apartmentDto, ModelState);
        //    Apartment model = _mapper.Map<Apartment>(apartmentDto);

        //    await _CanariDb.UpdateAsync(model);
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    return NoContent();
        //}
    }
}
