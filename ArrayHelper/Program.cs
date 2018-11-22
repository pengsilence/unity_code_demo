using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjArraryHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            //普通方法
            //int[] tstArr = new int[] { 1, 3, 6, 2 };
            //ArraryHelper.OrderBy(tstArr);
            //foreach (var item in tstArr)
            //{
            //    Console.WriteLine(item);
            //}

            //接口方法
            //Student[] stu_arr = new Student[]
            //{
            //new Student{ Id = 1, Name = "aa", Age = 20, Tall = 1.81f},
            //new Student{ Id = 2, Name = "cc", Age = 25, Tall = 1.75f},
            //new Student{ Id = 3, Name = "ee", Age = 19, Tall = 1.63f},
            //new Student{ Id = 4, Name = "bb", Age = 28, Tall = 1.72f},
            //new Student{ Id = 5, Name = "dd", Age = 26, Tall = 1.68f},
            //};

            //ArraryHelper.OrderBy(stu_arr,new Student());
            //foreach (var item in stu_arr)
            //{
            //Console.WriteLine(item.Name);
            //}

            //委托方法
            //Student objStu = new Student { Id = 1, Name = "aa", Age = 20, Tall = 1.81f };
            //CompareHandler<Student, int> cmpHandler = (p) => p.Age;
            //int res = cmpHandler(objStu);
            //Console.WriteLine(res);

            int[] tstArr = new int[] { 1, 3, 6, 2 };
            Student[] stu_arr = new Student[]
            {
                new Student{ Id = 1, Name = "aa", Age = 20, Tall = 1.81f},
                new Student{ Id = 2, Name = "cc", Age = 25, Tall = 1.75f},
                new Student{ Id = 3, Name = "ee", Age = 19, Tall = 1.63f},
                new Student{ Id = 4, Name = "bb", Age = 28, Tall = 1.72f},
                new Student{ Id = 5, Name = "dd", Age = 26, Tall = 1.68f},
            };

            //升序调用
            //ArraryHelper.OrderBy(stu_arr, (q) => q.Age);

            //降序调用
            //ArraryHelper.OrderByDes(stu_arr, (q) => q.Age); 
            //foreach (var item in stu_arr)
            //{
            //    Console.WriteLine(item.Age);
            //}

            //取最大调用
            //Console.WriteLine(ArraryHelper.GetMax(stu_arr, (q) => q.Tall).Id);

            //取最小调用
            //Console.WriteLine(ArraryHelper.GetMin(stu_arr, (q) => q.Tall).Id);

            //取符合条件的第一个数组元素调用
            //Console.WriteLine(ArraryHelper.Find(stu_arr, (q) => (q.Tall-1.80f) < 0.0 ).Name);

            //取符合条件的所有数组元素调用
            //ArraryHelper.FindAll(stu_arr, (q) => (q.Tall - 1.80f) < 0.0);
            //foreach (var item in ArraryHelper.FindAll(stu_arr, (q) => (q.Tall - 1.80f) < 0.0))
            //{
            //    Console.WriteLine("Id:{0},Name:{1}",item.Id,item.Name);
            //}
            //取数组所有元素的一个属性调用
            foreach (var item in ArraryHelper.FindWithAttr(stu_arr, (q) => q.Tall))
            {
                Console.WriteLine(item);
            }
        }
    }

    class Student//:IComparable<Student>,IComparer<Student>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public float Tall { get; set; }

        //public int CompareTo(Student other)
        //{
        //    return this.Tall.CompareTo(other.Tall);
        //}
        //public int Compare(Student stu1,Student stu2)
        //{
        //    return stu1.Name.CompareTo(stu2.Name);
        //}
    }
}
