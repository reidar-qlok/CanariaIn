using AutoMapper;
using Azure;
using CanariaApi.Data;
using CanariaApi.Models;
using CanariaApi.Models.DTO;
using CanariaApi.Repository.Irepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CanariaApi.Controllers
{
    [Route("api/CanariaApi")]
    [ApiController]
    public class CanariaApiController : Controller
    {
        private readonly IApartmentRepository _CanariDb;
        private readonly IMapper _mapper;
        public CanariaApiController(IApartmentRepository context, IMapper mapper)
        {
            _CanariDb = context;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult <IEnumerable<ApartmentDto>>> GetApartment()
        {
            IEnumerable<Apartment> apartmentList = await _CanariDb.GetAllAsync();
            return Ok(_mapper.Map<List<ApartmentDto>>(apartmentList));
        }
        [HttpGet("{id:int}", Name ="GetApartment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApartmentDto>> GetApartment(int id)
        {
            if (id==0)
            {
                return BadRequest();
            }
            var apartment= await _CanariDb.GetAsync(ap=>ap.ApartmentId == id);
            if (apartment ==null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ApartmentDto>(apartment));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApartmentDto>> CreateApartment([FromBody] ApartmentCreateDto createDto)
        {
            if (await _CanariDb.GetAsync(ap=>ap.Name.ToLower() == createDto.Name.ToLower())!=null)
            {
                ModelState.AddModelError("Custom error", "This apartment alredy exist");
                return BadRequest(ModelState);
            }
            if (createDto==null)
            {
                return BadRequest(createDto);
            }
            //var apartment = await _CanariDb.GetAsync(ap => ap.Name == createDto.Name);
            Apartment model = _mapper.Map<Apartment>(createDto);
            await _CanariDb.CreateAsync(model);
            return CreatedAtRoute("GetApartment", new { id = model.ApartmentId }, model);
        }
        [HttpDelete("{id:int}", Name = "DeleteApartment")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteApartment(int id)
        {
            if (id==0)
            {
                return BadRequest();
            }
            var apartment = await _CanariDb.GetAsync(ap => ap.ApartmentId == id);
            if (apartment==null)
            {
                return NotFound();
            }
            await _CanariDb.RemoveAsync(apartment);
            return NoContent();
        }
        [HttpPut("{id:int}", Name = "UpdateApartment")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateApartment(int id, [FromBody] ApartmentUpdateDto updateDto)
        {
            if (updateDto == null || id != updateDto.ApartmentId)
            {
                return BadRequest();
            }
            //var apartment = _CanariDb.GetAsync(ap => ap.ApartmentId == id, tracked:false);
            Apartment model = _mapper.Map<Apartment>(updateDto);
   
            await _CanariDb.UpdateAsync(model);
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            return NoContent();

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
