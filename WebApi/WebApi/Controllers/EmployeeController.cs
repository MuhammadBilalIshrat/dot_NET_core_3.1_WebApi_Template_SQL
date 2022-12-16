using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Abstraction;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IDbStratrgy db;
        public EmployeeController(IDbStratrgy dbStratrgy)
        {
            db = dbStratrgy;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                using (var con = db.Connection)
                {
                    var data = await con.QueryAsync<Employee>(@"SELECT [employeeId] ,[employeeName] ,[department] ,[dateOfJoining] ,[photoFileName] FROM [dbo].[Employee]"); 
                    return Ok(data.ToList());
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                using (var con = db.Connection)
                {
                    var data = await con.QueryAsync<Employee>(@$"SELECT [employeeId] ,[employeeName] ,[department] ,[dateOfJoining] ,[photoFileName] FROM [dbo].[Employee] where [employeeId] = {id}");
                    return Ok(data.ToList());
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Employee model)
        {
            try
            {
                using (var con = db.Connection)
                {
                    var data = await con.ExecuteAsync(@$" INSERT INTO [dbo].[Employee] ([employeeName] ,[department] ,[dateOfJoining] ,[photoFileName]) VALUES('{model.employeeaName}','{model.department}','{model.dateOfJoining}','{model.photoFileName}')");
                    return Ok(data);
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Employee model)
        {
            try
            {
                using (var con = db.Connection)
                {
                    var data = await con.ExecuteAsync(@$"update [dbo].[Employee] set [employeeName] = '{model.employeeaName}',[department] = '{model.department}',[dateOfJoining] = '{model.dateOfJoining}',[photoFileName] = '{model.photoFileName}' where [employeeId] = {model.employeeId}");
                    return Ok(data);
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                using (var con = db.Connection)
                {
                    var data = await con.ExecuteAsync(@$"delete from [dbo].[Employee] where employeeId = {id}");
                    return Ok(data);
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
