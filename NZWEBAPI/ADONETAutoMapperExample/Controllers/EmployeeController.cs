using ADONETAutoMapperExample.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADONETAutoMapperExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository rep;
        private readonly IMapper mapper;

        public EmployeeController(IEmployeeRepository rep, IMapper mapper)
        {
            this.rep = rep;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllEmployee()
        {

            var employee = rep.GetEmployees();
            var employeesDTO = mapper.Map<List<Models.DTO.EmployeeDTO>>(employee);
            return Ok(employeesDTO);

        }
    }
}
