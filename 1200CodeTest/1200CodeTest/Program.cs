using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Next 3.1 Page73
/// </summary>

namespace _1200CodeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            GetTypeMethods();
        }


        public static void strReturn(int year)
        {
            var str1 = "hellow\"C#\"";
            var str2 = "hellow\u0022C#\u0022";

            if (str1.Equals(str2))
            {
                //OK;

                var a = (year % 4 == 0 && year % 100 != 0) || year % 400 == 0 ? "闰年" : "非闰年";
            }
        }

        public static string getCodeFromHanzi()
        {
            //byte,sbyte,shor,ushort 进行位移操作后值的类型将自动转成int类型。

            var chr = "王";

            byte[] gb2312_bt = Encoding.GetEncoding("GB2312").GetBytes(chr);

            int n = (int)gb2312_bt[0] << 8;
            n += (int)gb2312_bt[1];

            return n.ToString();

        }

        public static void useChecked()
        {
            //使用checked关键判断是否有溢出  这个关键字可能对程序的性能会有一点点影响，合理位置使用checked关键字检查溢出，用性能换来健康。
            try
            {
                checked
                {

                }

            }
            catch (OverflowException ex)
            {

            }
        }

        public static void GetTypeMethods()
        {
            Type type = typeof(System.Int32);

            StringBuilder sb = new StringBuilder();

            foreach (MethodInfo method in type.GetMethods())
            {
                sb.Append(method.Name + Environment.NewLine);

                foreach (ParameterInfo parameter in method.GetParameters())
                {
                    sb.Append(parameter.Name + Environment.NewLine);
                }
            }

            using (Test t = new Test())
            {
                //
            }

            //无限循环
            //for (;;)
            //{

            //}

        }

        //类型转换不成功会出现异常，从抛出异常到catch并处理异常，无形增加系统的开销
        //-------------%%%%%%%%%%%% is 用于检查对象是否与给定类型兼容，兼容true   %%%%%%%%%%%%%%%%%%%%%%------------------
        //-------------%%%%%%%%%%%%%%%%  as 直接进行类型转换，成功返回转换后的对象，不成功则不会抛出异常而是返回NULL。   %%%%%%%%%%%%%%%%%%------------------
        /*
         * object P_str="String";
          object P_obj=P_str;
          string P_str2=P_obj as string;
          if(P_str2!=null){}
         */
         //as is 一样都不会抛出异常，使用as关键字对对象进行类型转换，如果成功将会返回转换后的对象，如果不成功则不会抛出异常而不是返回NULL。

        //C#中，每建立一条线程都会被分配1MB大小的地址空间，由于线程栈有固定的大小，如果进行递归的层次太深，有可能会出现溢出。






    }

    class Test : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
