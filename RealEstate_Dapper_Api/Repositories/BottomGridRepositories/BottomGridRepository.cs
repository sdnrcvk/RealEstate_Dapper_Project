using Dapper;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories
{
    public class BottomGridRepository : IBottomGridRepository
    {
        private readonly Context _context;

        public BottomGridRepository(Context context)
        {
            _context = context;
        }

        public async void CreateBottomGrid(CreateBottomGridDto bottomGridDto)
        {
            string query = "Insert Into BottomGrid (Icon, Title, Description) values (@icon, @title, @description)";
            var parameters = new DynamicParameters();
            parameters.Add("@icon", bottomGridDto.Icon);
            parameters.Add("@title", bottomGridDto.Title);
            parameters.Add("@description", bottomGridDto.Description);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteBottomGrid(int id)
        {
            string query = "Delete From BottomGrid Where BottomGridId=@bottomGridId";
            var parameters = new DynamicParameters();
            parameters.Add("@bottomGridId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
        {
            string query = "Select * From BottomGrid";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultBottomGridDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdBottomGridDto> GetBottomGrid(int id)
        {
            string query = "Select * From BottomGrid Where BottomGridId=@bottomGridId";
            var parameters = new DynamicParameters();
            parameters.Add("@bottomGridId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstAsync<GetByIdBottomGridDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateBottomGrid(UpdateBottomGridDto bottomGridDto)
        {
            string query = "Update BottomGrid Set Icon=@icon, Title=@title, Description=@description Where BottomGridId=@bottomGridId";
            var parameters = new DynamicParameters();
            parameters.Add("@icon", bottomGridDto.Icon);
            parameters.Add("@title", bottomGridDto.Title);
            parameters.Add("@description", bottomGridDto.Description);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
