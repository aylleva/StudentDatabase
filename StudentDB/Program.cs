namespace StudentDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
         StudentServices servis=new StudentServices();

         Student student=new Student { Name="Ayla",Surname="Atakishiyeva",Age=19 };
         Student student2 = new Student { Name = "Nezrin", Surname = "Ismayilova", Age = 20 };


            Student student3 = new Student { Id = 1, Name = "Samurai", Surname ="Samuraiova",Age=18};
            servis.Update(student3);

            Student student4 = new Student { Id = 3, Name = "Harry", Surname = "Potter", Age = 15 };
            servis.Update(student4);

            servis.Add(student);
            servis.Add(student2);

            servis.Delete(2);

            List<Student> students = servis.ShowAll();
           
            foreach(var item in students)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.Surname + " " + item.Age);
            }

            servis.Get(3);
        }
    }
}