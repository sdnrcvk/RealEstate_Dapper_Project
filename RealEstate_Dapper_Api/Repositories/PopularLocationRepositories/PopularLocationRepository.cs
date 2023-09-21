using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly Context _context;

        public PopularLocationRepository(Context context)
        {
            _context = context;
        }

        public async void CreatePopularLocation(CreatePopularLocationDto popularLocationDto)
        {
            string query = "Insert Into PopularLocation (CityName, ImageUrl) values (@cityName, @imageUrl)";
            var parameters = new DynamicParameters();
            parameters.Add("@cityName", popularLocationDto.CityName);
            parameters.Add("@imageUrl", popularLocationDto.ImageUrl);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeletePopularLocation(int id)
        {
            string query = "Delete From PopularLocation Where LocationId=@locationId";
            var parameters = new DynamicParameters();
            parameters.Add("@locationId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync()
        {
            string query = "Select * From PopularLocation";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdPopularLocationDto> GetPopularLocation(int id)
        {
            string query = "Select * From PopularLocation Where LocationId=@locationId";
            var parameters = new DynamicParameters();
            parameters.Add("@locationId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstAsync<GetByIdPopularLocationDto>(query, parameters);
                return values;
            }
        }

        public async void UpdatePopularLocation(UpdatePopularLocationDto popularLocationDto)
        {
            string query = "Update PopularLocation Set CityName=@cityName, ImageUrl=@imageUrl Where LocationId=@locationId";
            var parameters = new DynamicParameters();
            parameters.Add("@cityName", popularLocationDto.CityName);
            parameters.Add("@imageUrl", popularLocationDto.ImageUrl);
            parameters.Add("@locationId", popularLocationDto.LocationId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
