namespace _16oct_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "Murad";
            string surname = "Aliyev";
            

            if (Student.CheckName(name, surname))
            {
                Student student = new Student(name, surname);
                Console.WriteLine($"Telebe maili yaradildi: {student.CodeEmail}");
            }
            else
            {
                Console.WriteLine("Ad ve ya Soyad duzgun daxil edilmeyib.Mail yaradila bilmedi.");
            }

        }
    }
    
   

public interface ICodeAcademy
    {
        string CodeEmail { get; set; }
        void GenerateEmail();
    }

    public class Student : ICodeAcademy
    {
        private static int Count = 0;
        public int Id { get; }
        public string Name { get; }
        public string Surname { get; }
        public string CodeEmail { get; set; }

        public Student(string name, string surname)
        {
            if (CheckName(name, surname))
            {
                this.Id = ++Count;
                this.Name = name;
                this.Surname = surname;
                GenerateEmail();
            }
        }

        public static bool CheckName(string name, string surname)
        {
            if (name.Length < 3 || name.Length > 25)
                return false;

            if (surname.Length < 3 || surname.Length > 25)
                return false;

            if (!IsAllLetters(name) || !IsAllLetters(surname))
                return false;

            return true;
        }

        private static bool IsAllLetters(string input)
        {
            foreach (char c in input)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }

        public void GenerateEmail()
        {
            string email = $"{Name.ToLower()}.{Surname.ToLower()}{Id}@code.edu.az";
            CodeEmail = email;
        }
    }

}