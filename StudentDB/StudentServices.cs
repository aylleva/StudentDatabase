using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB
{
    internal class StudentServices
    {
        private static SQL _sql;

        public StudentServices()
        {
            _sql = new SQL();
        }

        public void Add(Student student)
        {
          int result=_sql.ExecuteCommant($"INSERT INTO Students VALUES('{student.Name}','{student.Surname}',{student.Age})");
            if (result > 0)
            {
                Console.WriteLine("Adding a student is succesfully done!");
            }
            else
            {
                Console.WriteLine("Try Again!!");
            }

        }
        public List<Student> ShowAll()
        {
            List<Student> students = new List<Student>();
           DataTable table= _sql.ExecuteQuery("SELECT * FROM Students");

            foreach(DataRow item in table.Rows)
            {
                Student student = new Student {
                    Id =(int) item["Id"],
                    Name =(string) item["Name"],
                    Surname = (string) item["Surname"],
                    Age = (int)item["Age"]
                
                };
                students.Add(student);
            }
            return students;
        }

        public void Delete(int Id)
        {
            _sql.ExecuteCommant($"DELETE FROM Students WHERE Id={Id} ");
        }

        //tasks
        public Student Get(int Id)
        {
          Student student=new Student();
          DataTable table= _sql.ExecuteQuery($"SELECT * FROM Students WHERE Id={Id}");

            foreach(DataRow item in table.Rows)
            {
                student.Id = (int)item["Id"];
                student.Name = (string)item["Name"];
                student.Surname = (string)item["Surname"];
                student.Age = (int)item["Age"];

                Console.WriteLine(student.Name+" "+student.Surname+" "+student.Age);
            }
            return student;
          

        }

        public void Update(Student student)
        {
           int result= _sql.ExecuteCommant($"UPDATE Students SET Name='{student.Name}',Surname='{student.Surname}',Age={student.Age} WHERE Id={student.Id}");

            if (result > 0)
            {
                Console.WriteLine("Done!");
            }
            else
            {
                Console.WriteLine("Error!!Try Again");
            }
        }
    }
}
