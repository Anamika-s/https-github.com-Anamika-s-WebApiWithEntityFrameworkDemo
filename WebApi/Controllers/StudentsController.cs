using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        static List<Student> list = null;
        void InitializeStudentList()
        {
            if (list == null)
            {
                list = new List<Student>()
                {
               new Student() { StudentId=1, Name="Ajay" , Batch="B001", Marks=89, DateOfBirth=Convert.ToDateTime("12/12/2020")},

               new Student() { StudentId=2, Name="Deepak" , Batch="B002", Marks=78, DateOfBirth=Convert.ToDateTime("10/06/2020")},


                };

            }
        }
        public StudentsController()
        {
            if (list == null)
                InitializeStudentList();
        }

        [HttpGet]
        public List<Student> Get()
        {
            return list.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        public Student Get(int id)
        {
            return list.FirstOrDefault(x => x.StudentId == id);
        }

        [HttpPost]
        public void Post(Student student)
        {
            list.Add(student);
        }

    }
}
