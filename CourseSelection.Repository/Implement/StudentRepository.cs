using CourseSelection.Repository.Dtos.Condition;
using CourseSelection.Repository.Dtos.DataModel;
using CourseSelection.Repository.Interface;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CourseSelection.Repository.Implement
{
    public class StudentRepository : IStudentRepository
    {
        /// <summary>
        /// 連線字串
        /// </summary>
        private readonly string _connectString;

        public StudentRepository(string connectString)
        {
            this._connectString = connectString;
        }

        /// <summary>
        /// 查詢學生列表
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IEnumerable<StudentDataModel> GetList(StudentCondition condition)
        {
            var sql = "Select * From Students";

            using (var conn = new SqlConnection(_connectString))
            {
                var result = conn.Query<StudentDataModel>(sql, condition);
                return result;
            }
        }

        /// <summary>
        /// 查詢學生單筆資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StudentDataModel Get(Guid id)
        {
            var sql = @"		
                Select * From Students 
                Where Id = @id
                ";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, System.Data.DbType.Guid);

            using (var conn = new SqlConnection(_connectString))
            {
                var result = conn.QueryFirstOrDefault<StudentDataModel>(sql, parameters);
                return result;
            }
        }

        /// <summary>
        /// 新增學生
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public bool Insert(StudentCondition condition)
        {
            var sql = @"
                Insert Into Students
                (
                   [Code]
                  ,[Name]
                  ,[Age]
                  ,[Sex]
                  ,[Grade]
                ) 
                VALUES 
                (
                   @Code
                  ,@Name
                  ,@Age
                  ,@Sex
                  ,@Grade
                );

                SELECT @@IDENTITY;
            ";

            using (var conn = new SqlConnection(_connectString))
            {
                var result = conn.Execute(sql, condition);
                return result > 0;
            }
        }

        /// <summary>
        /// 更新學生資料
        /// </summary>
        /// <param name="id"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public bool Update(Guid id, StudentCondition condition)
        {
            var sql = @"
                Update Students
                SET 
                    [Code] = @Code
                   ,[Name] = @Name
                   ,[Age] = @Age
                   ,[Sex] = @Sex
                   ,[Grade] = @Grade
                WHERE
                    Id = @id
                ";

            var parameters = new DynamicParameters();

            parameters.AddDynamicParams(condition);
            parameters.Add("Id", id, System.Data.DbType.Guid);

            using (var conn = new SqlConnection(_connectString))
            {
                var result = conn.Execute(sql, parameters);
                return result > 0;
            }
        }

        /// <summary>
        /// 刪除學生資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(Guid id)
        {
            var sql = @"
                Delete From Students
                WHERE Id = @Id
                ";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, System.Data.DbType.Guid);

            using (var conn = new SqlConnection(_connectString))
            {
                var result = conn.Execute(sql, parameters);
                return result > 0;
            }
        }


    }
}
