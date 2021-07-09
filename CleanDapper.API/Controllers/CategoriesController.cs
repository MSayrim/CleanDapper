using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CleanDapper.API.Data;
using CleanDapper.CORE.Entity.Concrete;
using Microsoft.Extensions.Configuration;
using CleanDapper.CORE.Repository.Concrete.EntityTypes;
using System.Data;
using CleanDapper.CORE.Enums;
using Dapper;

namespace CleanDapper.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        DapperCategoryRepository _dapperCategoryRepository;

        public CategoriesController(IConfiguration config)
        {
            _dapperCategoryRepository = new DapperCategoryRepository(config);
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<List<Category>> GetCategory()
        {
            
            var result = await Task.FromResult( _dapperCategoryRepository.QueryGetALL<Category>("SELECT * FROM Categories",null,commandType:CommandType.Text));
            return result;
        }

      

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(Guid id)
        {
            var result = await Task.FromResult(_dapperCategoryRepository.QueryGetByID<Category>($"Select * from Categories where ID = {id}", null, commandType: CommandType.Text));
            return result;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{CategoryName}")]
        public async Task<bool> Create(Category data)
        {
            var result = await Task.FromResult(_dapperCategoryRepository.Create<Category>($" INSERT INTO  Categories (CategoryName,CreateDate,Statu) VALUES({data.CategoryName},{DateTime.Now},{Situations.Active})", null, commandType: CommandType.StoredProcedure));
            return result;
        }

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("ID", category.ID);
            dbPara.Add("CategoryName", category.CategoryName, DbType.String);
            dbPara.Add("UpdateDate", DateTime.Now);

            var updateArticle = Task.FromResult(_dapperCategoryRepository.Update<bool>("[dbo].[SP_Update_Category]",
                            dbPara,
                            commandType: CommandType.StoredProcedure));

            return CreatedAtAction("GetCategory", new { id = category.ID }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteCategory(Guid id)
        {
            var result = await Task.FromResult(_dapperCategoryRepository.Delete<bool>($"Delete Categories Where Id = {id}", null, commandType: CommandType.Text));
            return result;
        }

        private bool CategoryExists(Guid id)
        {
            return true;
        }
    }
}
