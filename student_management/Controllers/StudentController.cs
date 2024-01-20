using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student_management.Data;
using student_management.Models;
using student_management.Models.Dto;

namespace student_management.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDBContext _db;
        private ResponceDto _responceDto;

        public StudentController(AppDBContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _responceDto = new ResponceDto();
        }
        [HttpGet]
        public ResponceDto Get() {
            try
            {
                IEnumerable<Student_Management> studentList = _db.student_Managements.ToList();
                 var students =new List<Student_ManagementDto>();
                foreach (var item in studentList)
                {
                    Student_ManagementDto student = new Student_ManagementDto()
                    {
                        Id =item.Id,
                        Roll=item.Roll,
                        Registation=item.Registation,
                        Student_Email=item.Student_Email,
                        Student_Name=item.Student_Name,
                        DateTime=item.DateTime,
                        present=item.present,
                        absent=item.absent,

                };
                    students.Add(student);

                }
                _responceDto.Result=students;
            }
            catch (Exception ex)
            {
             _responceDto.Massage =ex.Message;
                _responceDto.Success = false;
            }
            return _responceDto;
        }

        [HttpGet]
        [Route("GetByRoll/{roll}")]
        public ResponceDto GetByRoll([FromQuery] int roll)
        {
            try
            {
                IEnumerable<Student_Management> students = _db.student_Managements.Where(x => x.Roll == roll).ToList();
                var totalPresent = students.Sum(x => x.present);
                var totalAbsent = students.Sum(x => x.absent);
                //var studentList = new List<Student_ManagementDto>();
                foreach (var item in students)
                {
                    Student_ManagementDto student = new Student_ManagementDto()
                    {
                        Id = item.Id,
                        Roll = item.Roll,
                        Registation = item.Registation,
                        Student_Name = item.Student_Name,
                        Student_Email = item.Student_Email,
                        present = item.present,
                        absent = item.absent,
                        TotalPresent = totalPresent,
                        TotalAbsent = totalAbsent,
                    };
                    //studentList.Add(student);
                    _responceDto.Result = student;
                }
               
            }
            catch (Exception ex)
            {
                _responceDto.Massage = ex.Message;
                _responceDto.Success = true;
            }
            return _responceDto;
        }

        [HttpGet]
        [Route("/GetbyEmail{email}")]
        public ResponceDto GetbyEmail([FromQuery] string email) {
            try
            {
                IEnumerable<Student_Management> studentList = _db.student_Managements.Where(x => x.Student_Email == email);
                var totalPreaent = studentList.Sum(x => x.present);
                var totalAbsent =studentList.Sum(x => x.absent);
                var students = new List<Student_ManagementDto>();
                foreach (var item in studentList)
                {
                    Student_ManagementDto student = new Student_ManagementDto() {
                      Id= item.Id,
                      Roll=item.Roll,
                      Registation=item.Registation,
                      Student_Email=item.Student_Email,
                      Student_Name=item.Student_Name,
                      present=item.present,
                      absent=item.absent,
                      TotalPresent=totalPreaent,
                      TotalAbsent=totalAbsent
                    };
                    students.Add(student);
                }

                _responceDto.Result=students;

            }
            catch(Exception ex) {
            _responceDto.Massage=ex.Message;
            _responceDto.Success = false;
            
            }  
            return _responceDto;
         }

        [HttpPost]
        public ResponceDto Post([FromBody] Student_ManagementDto students)
        {
            try
            {
                Student_Management StudentsList = new Student_Management()
                {
                    Roll=students.Roll,
                    Registation=students.Registation,
                    DateTime=students.DateTime,
                    Student_Name=students.Student_Name,
                    Student_Email=students.Student_Email,
                    present=students.present,
                    absent=students.absent,

                };
                _db.student_Managements.Add(StudentsList);
                _db.SaveChanges();
                _responceDto.Result = StudentsList;
            }
            catch (Exception ex)
            {
                _responceDto.Massage = ex.Message;
                _responceDto.Success = false;
            }
            return _responceDto;
        }

        [HttpPut]
        public object Put([FromBody] Student_ManagementDto students)
        {
            try
            {
                Student_Management StudentsList = new Student_Management()
                {
                    Id = students.Id,
                    Roll = students.Roll,
                    Registation = students.Registation,
                    DateTime = students.DateTime,
                    Student_Name = students.Student_Name,
                    Student_Email = students.Student_Email,
                    present = students.present,
                    absent = students.absent,

                };
                _db.student_Managements.Update(StudentsList);
                _db.SaveChanges();
                _responceDto.Result = StudentsList;
            }
            catch (Exception ex)
            {
                _responceDto.Massage = ex.Message;
                _responceDto.Success = false;
            }
            return _responceDto;
        }

        [HttpDelete]
        [Route("{id:int}")]
        public object Delete(int id)
        {
            try
            {
                Student_Management studentList = _db.student_Managements.First(x => x.Id == id);
                _db.student_Managements.Remove(studentList);
                _db.SaveChanges();
               _responceDto.Result=studentList;
                _responceDto.Massage = "successfull";
            }
            catch (Exception ex)
            {
                _responceDto.Massage = ex.Message;
                _responceDto.Success = false;
            }
            return _responceDto;
        }
    }
}
