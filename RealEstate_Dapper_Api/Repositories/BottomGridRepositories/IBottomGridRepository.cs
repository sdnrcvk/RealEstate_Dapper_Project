using RealEstate_Dapper_Api.Dtos.BottomGridDtos;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGridAsync();
        void CreateBottomGrid(CreateBottomGridDto bottomGridDto);
        void DeleteBottomGrid(int id);
        void UpdateBottomGrid(UpdateBottomGridDto bottomGridDto);
        Task<GetByIdBottomGridDto> GetBottomGrid(int id);
    }
}
