using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ArraryHelper
{
   //public static void OrderBy<T>(T[] arr) where T:IComparable<T>
   //{
   //     for (int i = 0; i < arr.Length; i++)
   //     {
   //         for (int j = i+1; j < arr.Length; j++)
   //         {
   //             if (arr[i].CompareTo(arr[j]) > 0)
   //             {
   //                 T tmp = arr[i];
   //                 arr[i] = arr[j];
   //                 arr[j] = tmp;
   //             }
   //         }
   //     }
   //}

    //public static void OrderBy<T>(T[] arr,IComparer<T> cmp) where T : IComparable<T>
    //{
    //    for (int i = 0; i < arr.Length; i++)
    //    {
    //        for (int j = i + 1; j < arr.Length; j++)
    //        {                
    //            if (cmp.Compare(arr[i], arr[j]) > 0)
    //            {
    //                T tmp = arr[i];
    //                arr[i] = arr[j];
    //                arr[j] = tmp;
    //            }
    //        }
    //    }
    //}

    /// <summary>
    /// 对T类型数组按数组中的Ty类型值，由小到大升序排列
    /// </summary>
    /// <typeparam name="T">数组类型</typeparam>
    /// <typeparam name="Ty">数组元素中的成员类型</typeparam>
    /// <param name="arr">被排序的数据</param>
    /// <param name="cmpHdl">返回数组元素中成员类型的方法的委托</param>
    public static void OrderBy<T,Ty>(T[] arr, CompareHandler<T, Ty> cmpHdl) where Ty : IComparable<Ty>
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {    
                //使用委托取属性的值，进行比较
                if (cmpHdl(arr[i]).CompareTo(cmpHdl(arr[j])) > 0)
                {
                    T tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;
                }
            }
        }
    }

    /// <summary>
    /// 对T类型数组按数组中的Ty类型值，由大到小降序排列
    /// </summary>
    /// <typeparam name="T">数组类型</typeparam>
    /// <typeparam name="Ty">数组元素中的成员类型</typeparam>
    /// <param name="arr">被排序的数据</param>
    /// <param name="cmpHdl">返回数组元素中成员类型的方法的委托</param>
    public static void OrderByDes<T, Ty>(T[] arr, CompareHandler<T, Ty> cmpHdl) where Ty : IComparable<Ty>
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                //使用委托取属性的值，进行比较
                if (cmpHdl(arr[i]).CompareTo(cmpHdl(arr[j])) < 0)
                {
                    T tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;
                }
            }
        }
    }

    /// <summary>
    /// 获取数组中给定的数组元素中成员最大的数组成员
    /// </summary>
    /// <typeparam name="T">数组类型</typeparam>
    /// <typeparam name="Ty">数组元素中的成员类型</typeparam>
    /// <param name="arr">被查找的数组</param>
    /// <param name="cmpHdl">返回数组元素中成员类型的方法的委托</param>
    /// <returns>返回最大的数组元素</returns>
    public static T GetMax<T, Ty>(T[] arr, CompareHandler<T, Ty> cmpHdl) where Ty : IComparable<Ty>
    {
        T tmp = arr[0];
        for (int i = 0; i < arr.Length; i++)
        {
            //使用委托取属性的值，进行比较
            if (cmpHdl(arr[i]).CompareTo(cmpHdl(tmp)) > 0)
            {                    
                tmp = arr[i];
            }
        }
        return tmp;
    }

    /// <summary>
    /// 获取数组中给定的数组元素中成员最小的数组成员
    /// </summary>
    /// <typeparam name="T">数组类型</typeparam>
    /// <typeparam name="Ty">数组元素中的成员类型</typeparam>
    /// <param name="arr">被查找的数组</param>
    /// <param name="cmpHdl">返回数组元素中成员类型的方法的委托</param>
    /// <returns>返回最小的数组元素</returns>
    public static T GetMin<T, Ty>(T[] arr, CompareHandler<T, Ty> cmpHdl) where Ty : IComparable<Ty>
    {
        T tmp = arr[0];
        for (int i = 0; i < arr.Length; i++)
        {
            //使用委托取属性的值，进行比较
            if (cmpHdl(arr[i]).CompareTo(cmpHdl(tmp)) < 0)
            {
                tmp = arr[i];
            }
        }
        return tmp;
    }

    /// <summary>
    /// 获取数组中满足给定条件的第一个元素
    /// </summary>
    /// <typeparam name="T">数组类型</typeparam>
    /// <typeparam name="Ty">数组元素中的成员类型</typeparam>
    /// <param name="arr">被查找的数组</param>
    /// <param name="condHdl">返回数组元素中成员类型的方法的委托</param>
    /// <returns>返回符合条件的数组元素</returns>
    public static T Find<T>(T[] arr, ConditionHandler<T> condHdl)
    {
        foreach (var item in arr)
        {
            if (condHdl(item) == true)
            {
                return item;
            }    
        }
        return default(T);
    }

    /// <summary>
    /// 获取数组中满足给定条件的所以元素
    /// </summary>
    /// <typeparam name="T">数组类型</typeparam>
    /// <typeparam name="Ty">数组元素中的成员类型</typeparam>
    /// <param name="arr">被查找的数组</param>
    /// <param name="condHdl">返回数组元素中成员类型的方法的委托</param>
    /// <returns>返回符合条件的一个List</returns>
    public static T[] FindAll<T>(T[] arr, ConditionHandler<T> condHdl)
    {
        List<T> resList = new List<T>();
        foreach (var item in arr)
        {
            if (condHdl(item) == true)
            {
                resList.Add(item);
            }
        }
        return resList.ToArray();  //可变数组转换为固定数组
    }

    /// <summary>
    /// 将数组所有元素的一个属性全部取出，组成一个新的数组
    /// </summary>
    /// <typeparam name="T">数组类型</typeparam>
    /// <typeparam name="Ty">数组元素中的成员类型</typeparam>
    /// <param name="arr">被查找的数组</param>
    /// <param name="cmpHdl">返回数组元素中成员类型的方法的委托</param>
    /// <returns>组成的新数组</returns>
    public static Ty[] FindWithAttr<T,Ty>(T[] arr, CompareHandler<T, Ty> cmpHdl)
    {
        Ty[] resArray = new Ty[arr.Length];
        int i = 0;
        foreach (var item in arr)
        {
            resArray[i] = cmpHdl(item);
            i++;
        }
        return resArray;
    }
}

//Ty是T类型中的某个属性的类型
public delegate Ty CompareHandler<T,Ty>(T t);

public delegate bool ConditionHandler<T>(T t);
