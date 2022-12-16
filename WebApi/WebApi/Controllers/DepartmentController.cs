using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Abstraction;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDbStratrgy db;
        public DepartmentController(IDbStratrgy dbStratrgy)
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
                    var data = await con.QueryAsync<Department>(@"SELECT [departmentId] , [departmentName] FROM [dbo].[Department]");
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
                    var data = await con.QueryAsync<Department>(@$"SELECT [departmentId] , [departmentName] FROM [dbo].[Department] where [departmentId] = {id}");
                    return Ok(data.ToList());
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Department model)
        {
            try
            {
                using (var con = db.Connection)
                {
                    var data = await con.ExecuteAsync(@$"INSERT INTO [dbo].[Department] ([departmentName]) VALUES('{model.departmentName}')");
                    return Ok(data);
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Department model)
        {
            try
            {
                using (var con = db.Connection)
                {
                    var data = await con.ExecuteAsync(@$"update [dbo].[Department] set [departmentName] = '{model.departmentName}' where departmentId = {model.departmentId}");
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
                    var data = await con.ExecuteAsync(@$"delete from [dbo].[Department] where departmentId = {id}");
                    return Ok(data);
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        // This template is for custom work in REST convention
        [HttpGet("{id}")]
        [Route("GetCutomData")]
        public async Task<IActionResult> GetCutomData(int id)
        {
            try
            {
                using (var con = db.Connection)
                {
                    //var data = await con.QueryAsync<Department>(@$"SELECT [departmentId] , [departmentName] FROM [dbo].[Department] where [departmentId] = {id}");
                    var data =  new { t1 = "ok" };

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
