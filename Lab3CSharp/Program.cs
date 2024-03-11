namespace Lab3CSharp
{
    internal class Program
    {
        class Point
        { 
            protected int x, y;
            protected int c;
            public int X
            {
                get { return x; }
                set { x = value; }
            }
            public int Y
            {
                get { return y;}
                set { y = value; }
            }
            public int C
            {
                get { return c; }
            }

            public Point()
            {
                this.x = 0;
                this.y = 0;
            }
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public void Show()
            {
                Console.WriteLine("X: {0}", x);
                Console.WriteLine("Y: {0}", y);
            }
            public double Distance()
            {
                return Math.Sqrt(x * x + y * y);
            }
            public void Vector(int x1, int y1)
            {
                this.x += x1;
                this.y += y1;
            }

        }
        static void task1()
        {
            /*
            Завдання 1. Варіанти задач. Для розв’язання задачі згідно варіанту створити клас із полями, 
            конструкторами, методами та властивостями. 
            До запропонованих полів, методів та властивосте можна додавати власні. 

            1.1. Задано масив точок. Вивести в консоль інформацію про точку та відстань до центра координат. 
            Точки які знаходяться більше середньої відстані, перемістити на заданий вектор. 
            Створити клас Point, розробивши такі елементи класу:
             Поля (захищені):
                 координати точки ( int x, y);
                 колір точки ( int с );
             Конструктори, що дозволяють створити екземпляр класу:
                 з нульовими координатами;
                 із заданими координатами.
             Методи, що дозволяють:
                 вивести координати точки на екран;
                 розрахувати відстань від початку координат до точки;
                 перемістити точку на вектор з координатами (x1, y1).
             Властивості:
                 отримати-встановити координати точки (доступні для 
                читань і запису);
                 отримати колір точки (доступна тільки для читання) 
             */
            Point[] points = new Point[5];
            points[0] = new Point(5, 9);
            points[1] = new Point(2, -3);
            points[2] = new Point(6, 7);
            points[3] = new Point(1, 5);
            points[4] = new Point(-4, 2);
            double avgDistance = 0;

            for(int i  = 0; i < points.Length; i++)
            {
                points[i].Show();
                Console.WriteLine(points[i].Distance());
                avgDistance += points[i].Distance();
            }
            avgDistance /= points.Length;

            for(int i = 0; i < points.Length; i++) 
            {
                if (points[i].Distance() < avgDistance)
                {
                    points[i].Vector(10, 10);
                }
                points[i].Show();
            }
        }
        class Person
        {
            protected int id;
            protected string name;
            protected int age;
            public Person(int id, string name, int age)
            {
                this.name = name;
                this.age = age;
                this.id = id;
            }
            public virtual void Show()
            {
                Console.WriteLine("Name: {0}", name);
                Console.WriteLine("ID: {0}", id);
                Console.WriteLine("Age: {0}", age);
            }
            public virtual string GetName()
            {
                return name;
            }
        }
        class Student : Person
        {
            private string specialty;
            public Student(int id, string name, int age, string specialty) : base(id, name, age)
            {
                this.specialty = specialty;
            }
            public override void Show()
            {
                Console.WriteLine("Name: {0}", name);
                Console.WriteLine("ID: {0}", id);
                Console.WriteLine("Age: {0}", age);
                Console.WriteLine("Specialty: {0}", specialty);
            }
            public override string GetName()
            {
                return name; 
            }
        }
        class Teacher : Person
        {
            protected int salary;
            public Teacher(int id, string name, int age, int salary) : base(id, name, age)
            {
                this.salary = salary;
            }
            public override void Show()
            {
                Console.WriteLine("Name: {0}", name);
                Console.WriteLine("ID: {0}", id);
                Console.WriteLine("Age: {0}", age);
                Console.WriteLine("Salary: {0}", salary);
            }
            public override string GetName()
            {
                return name;
            }
        }
        class Head : Teacher
        {
            private int bonus;
            public Head(int id, string name, int age, int salary, int bonus) : base(id, name, age, salary)
            {
                this.bonus = bonus;
            }
            public override void Show()
            {
                Console.WriteLine("Name: {0}", name);
                Console.WriteLine("ID: {0}", id);
                Console.WriteLine("Age: {0}", age);
                Console.WriteLine("Salary + bonus: {0}", salary + bonus);
            }
            public override string GetName()
            {
                return name;
            }
        }
        static void FillArrayWithObjects(Person[] array)
        {
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                int objectType = random.Next(1, 4);

                switch (objectType)
                {
                    case 1:
                        array[i] = new Student(i + 1, "Student", random.Next(18, 25), "Specialty");
                        break;
                    case 2:
                        array[i] = new Teacher(i + 1, "Teacher", random.Next(30, 50), random.Next(40000, 60000));
                        break;
                    case 3:
                        array[i] = new Head(i + 1, "Head", random.Next(35, 55), random.Next(50000, 70000), random.Next(2000, 5000));
                        break;
                    default:
                        break;
                }
            }
        }
        static void task2()
        {
            /*
             Завдання 2. Побудувати ієрархію класів відповідно до варіанта завдання. 
            Згідно завдання вибрати базовий клас та похідні. В класах задати поля, які характерні для кожного класу. 
            Для всіх класів розробити метод Show(), який виводить дані про об’єкт класу. 
            Створити масив базового класу та написати функцію наповняє масив різними об’єктами похідних класів. 
            Вивести масив впорядкований за деякким критерієм який характеризує всі об’єкти масиву.
            
            2.1. Студент, викладач, персона, завідувач кафедри. 
             */

            Person[] people = new Person[5];
            FillArrayWithObjects(people);

            Array.Sort(people, (p1, p2) => String.Compare(p1.GetName(), p2.GetName(), StringComparison.Ordinal));
            foreach (var person in people)
            {
                person.Show();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Lab 3 ");
            Console.Write("Enter task number: ");
            int task_id = int.Parse(Console.ReadLine());
            switch(task_id)
            {
                case 1:
                    task1();
                    break;
                case 2:
                    task2();
                    break;
                default:
                    Console.WriteLine("No task under such number!");
                    break;
            }
        }
    }
}
