using AutoMapper;
using CourseSelection.Controllers.Mappings;
using CourseSelection.Dtos;
using CourseSelection.Service.Dtos.Info;
using CourseSelection.Service.Dtos.ResultModel;
using CourseSelection.Service.Interface;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace CourseSelection.Controllers
{
    /// <summary>
    /// 學生資料
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;

        /// <summary>
        /// 建構式
        /// </summary>
        public StudentController(IStudentService studentService)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ControllerMappings>());
            this._mapper = config.CreateMapper();
            this._studentService = studentService;
        }

        /// <summary>
        /// 查詢學生列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<StudentViewModel> GetList([FromQuery] StudentParameter parameter)
        {
            var info = this._mapper.Map<StudentParameter, StudentInfo>(parameter);
            var student = this._studentService.GetList(info);
            var result = this._mapper.Map<IEnumerable<StudentResultModel>, IEnumerable<StudentViewModel>>(student);

            return result;
        }

        /// <summary>
        /// 學生單筆資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [Produces("application/json")]
        public StudentViewModel Get([FromRoute] Guid id)
        {
            var student = this._studentService.Get(id);
            var result = this._mapper.Map<StudentResultModel, StudentViewModel>(student);

            return result;
        }

        /// <summary>
        /// 新增學生資料
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Insert([FromBody] StudentParameter parameter)
        {
            var info = this._mapper.Map<StudentParameter, StudentInfo>(parameter);
            var isInsertSuccess = this._studentService.Insert(info);
            if (isInsertSuccess)
            {
                return Ok();
            }
            return StatusCode(500);
        }

        /// <summary>
        /// 更新學生資料
        /// </summary>
        /// <param name="id"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] StudentParameter parameter)
        {
            var targetCard = this._studentService.Get(id);
            if (targetCard is null)
            {
                return NotFound();
            }

            var info = this._mapper.Map<StudentParameter, StudentInfo>(parameter);

            var isUpdateSuccess = this._studentService.Update(id, info);
            if (isUpdateSuccess)
            {
                return Ok();
            }
            return StatusCode(500);
        }

        /// <summary>
        /// 刪除學生資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            this._studentService.Delete(id);
            return Ok();
        }
    }
}
