using Badges.Core.Common;
using Badges.Core.Data;
using Badges.Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges.Infra.Repository
{
    public class CourseTraineeRepository: ICourseTraineeRepository
    {
        private readonly IDbContext _dbContext;

        public CourseTraineeRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<CourseTrainee> GetAllCourseTrainee()
        {
            IEnumerable<CourseTrainee> result = _dbContext.Connection.Query<CourseTrainee>("Course_Trainee_Package.get_all", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public bool CreateCourseTrainee(CourseTrainee courseTrainee)
        {
            var create = new DynamicParameters();
            create.Add("mark", courseTrainee.Mark, dbType: DbType.Int32, direction: ParameterDirection.Input);
            create.Add("course_id", courseTrainee.FkCourseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            create.Add("user_id", courseTrainee.FkCourseid, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = _dbContext.Connection.Execute("Course_Trainee_Package.create_course_trainee", create, commandType: CommandType.StoredProcedure);

            return result > 0;
        }
        public bool UdateCourseTrainee(CourseTrainee CourseTrainee)
        {
            var update = new DynamicParameters();
            update.Add("id", CourseTrainee.Ctid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("mark", CourseTrainee.Mark, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("course_id", CourseTrainee.FkCourseid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            update.Add("user_id", CourseTrainee.FkUserid, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = _dbContext.Connection.Execute("Course_Trainee_Package.update_course_trainee", update, commandType: CommandType.StoredProcedure);

            return result > 0;
        }
        public bool DeleteCourseTrainee(int id)
        {
            var delete = new DynamicParameters();
            delete.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Course_Trainee_Package.delete_course_trainee", delete, commandType: CommandType.StoredProcedure);


            return result > 0;
        }
        public CourseTrainee GetCourseTraineeById(int id)
        {
            var get = new DynamicParameters();
            get.Add("id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Query<CourseTrainee>("Course_Trainee_Package.get_course_trainee_by_id", get, commandType: CommandType.StoredProcedure);


            return result.FirstOrDefault()!;
        }
    }
}