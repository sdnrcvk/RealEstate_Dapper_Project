using Dapper;
using RealEstate_Dapper_Api.Dtos.TestimonialDtos;
using RealEstate_Dapper_Api.Dtos.TestimonialDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepositories
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly Context _context;

        public TestimonialRepository(Context context)
        {
            _context = context;
        }

        public async void CreateTestimonial(CreateTestimonialDto testimonialDto)
        {
            string query = "Insert Into Testimonial (NameSurname, Title, Comment, Status) values (@nameSurname, @title, @comment, @status)";
            var parameters = new DynamicParameters();
            parameters.Add("@nameSurname", testimonialDto.NameSurname);
            parameters.Add("@title", testimonialDto.Title);
            parameters.Add("@comment", testimonialDto.Comment);
            parameters.Add("@status", testimonialDto.Status);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteTestimonial(int id)
        {
            string query = "Delete From Testimonial Where TestimonialId=@testimonialId";
            var parameters = new DynamicParameters();
            parameters.Add("@testimonialId", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
        {
            string query = "Select * From Testimonial";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultTestimonialDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdTestimonialDto> GetTestimonial(int id)
        {
            string query = "Select * From Testimonial Where TestimonialId=@testimonialId";
            var parameters = new DynamicParameters();
            parameters.Add("@testimonialId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstAsync<GetByIdTestimonialDto>(query, parameters);
                return values;
            }
        }

        public async void UpdateTestimonial(UpdateTestimonialDto testimonialDto)
        {
            string query = "Update Testimonial Set NameSurname=@nameSurname, Title=@title, Comment=@comment, Status=@status Where TestimonialId=@testimonialId";
            var parameters = new DynamicParameters();
            parameters.Add("@nameSurname", testimonialDto.NameSurname);
            parameters.Add("@title", testimonialDto.Title);
            parameters.Add("@comment", testimonialDto.Comment);
            parameters.Add("@status", testimonialDto.Status);
            parameters.Add("@testimonialId", testimonialDto.TestimonialId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
