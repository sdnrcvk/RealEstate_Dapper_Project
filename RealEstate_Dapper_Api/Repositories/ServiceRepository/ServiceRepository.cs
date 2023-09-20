using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public async void CreateService(CreateServiceDto serviceDto)
        {
            string query = "Insert Into Service (ServiceName, ServiceStatus) values (@serviceName,@serviceStatus)";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceName", serviceDto.ServiceName);
            parameters.Add("@serviceStatus", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteService(int id)
        {
            string query = "Delete From Service Where ServiceId=@serviceId";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultServiceDto>> GetAllServiceAsync()
        {
            string query = "Select * From Service";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultServiceDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdServiceDto> GetService(int id)
        {
            string query = "Select * From Service Where ServiceId=@serviceId";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstAsync<GetByIdServiceDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateService(UpdateServiceDto serviceDto)
        {
            string query = "Update Service Set ServiceName=@serviceName, ServiceStatus=@serviceStatus Where ServiceId=@serviceId";
            var parameters = new DynamicParameters();
            parameters.Add("@serviceName", serviceDto.ServiceName);
            parameters.Add("@serviceStatus", serviceDto.ServiceStatus);
            parameters.Add("@serviceId", serviceDto.ServiceId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
