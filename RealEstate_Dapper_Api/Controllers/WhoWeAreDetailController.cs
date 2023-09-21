using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreDetailController : ControllerBase
    {
        private readonly IWhoWeAreRepository _whoWeAreRepository;

        public WhoWeAreDetailController(IWhoWeAreRepository whoWeAreRepository)
        {
            _whoWeAreRepository = whoWeAreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> WhoWeAreDetailList()
        {
            var values = await _whoWeAreRepository.GetAllWhoWeAreDetailAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetail)
        {
            _whoWeAreRepository.CreateWhoWeAreDetail(createWhoWeAreDetail);
            return Ok("Hakkımızda kısmı başarılı bir şekilde eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWhoWeAreDetail(int id)
        {
            _whoWeAreRepository.DeleteWhoWeAreDetail(id);
            return Ok("Hakkımızda kısmı başarılı bir şekilde silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetail)
        {
            _whoWeAreRepository.UpdateWhoWeAreDetail(updateWhoWeAreDetail);
            return Ok("Hakkımızda kısmı başarılı bir şekilde güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWhoWeAreDetail(int id)
        {
            var value = await _whoWeAreRepository.GetWhoWeAreDetail(id);
            return Ok(value);
        }
    }
}
