namespace _16oct_taskkk
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Group.Groups = new Group[2];
            Group group1 = new Group("Group 1");
            Group group2 = new Group("Group 2");

            Student student1 = new Student("Nigar", "Gulmaliyeva");
            Student student2 = new Student("Zulfiyya", "Qurbanova");
            Student student3 = new Student("Sabuhi", "Jamalzadeh");
            Student student4 = new Student("Shamama", "Khuliyeva");

            group1.AddStudent(student1);
            group1.AddStudent(student2);
            group1.AddStudent(student3);
            group1.AddStudent(student4);

            Student student5 = new Student("Adil", "Nasirli");
            Student student6 = new Student("Leyla", "Shafi");
            Student student7 = new Student("Aqil", "Baxshaliyev");
            Student student8 = new Student("Muslum", "Khalilov");

            group2.AddStudent(student5);
            group2.AddStudent(student6);
            group2.AddStudent(student7);
            group2.AddStudent(student8);

            Group.ShowAllGroups();
        }
    }
    

public class Student
    {
        private static int Count = 0;

        public int Id { get; }
        public string Name { get; }
        public string Surname { get; }

        public Student(string name, string surname)
        {
            this.Id = ++Count;
            this.Name = name;
            this.Surname = surname;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Id: {Id}, Ad: {Name}, Soyad: {Surname}");
        }
    }

    public class Group
    {
        public static Group[] Groups;
        private static int GroupCount = 0;

        public int GroupId { get; }
        public string GroupName { get; }
        public Student[] Students;

        public Group(string groupName)
        {
            this.GroupId = ++GroupCount;
            this.GroupName = groupName;
            Groups[GroupCount - 1] = this;
            Students = new Student[0];
        }

        public void GetGroupInfo()
        {
            Console.WriteLine($"Group Id: {GroupId}, Group Name: {GroupName}, Telebelerin sayi: {Students.Length}");
        }

        public Student GetStudent(int id)
        {
            foreach (var student in Students)
            {
                if (student.Id == id)
                    return student;
            }
            return null;
        }

        public void AddStudent(Student student)
        {
            Array.Resize(ref Students, Students.Length + 1);
            Students[Students.Length - 1] = student;
        }

        public void Search(string searchString)
        {
            foreach (var student in Students)
            {
                if (student.Name.Contains(searchString) || student.Surname.Contains(searchString))
                    student.GetInfo();
            }
        }

        public void RemoveStudent(int id)
        {
            for (int i = 0; i < Students.Length; i++)
            {
                if (Students[i].Id == id)
                {
                    for (int j = i; j < Students.Length - 1; j++)
                    {
                        Students[j] = Students[j + 1];
                    }
                    Array.Resize(ref Students, Students.Length - 1);
                    break;
                }
            }
        }

        public void ShowStudents()
        {
            foreach (var student in Students)
            {
                student.GetInfo();
            }
        }

        public static void ShowAllGroups()
        {
            foreach (var group in Groups)
            {
                group.GetGroupInfo();
            }
        }

        public static void AddGroup(Group group)
        {
            Array.Resize(ref Groups, GroupCount + 1);
            Groups[GroupCount] = group;
        }
    }

}