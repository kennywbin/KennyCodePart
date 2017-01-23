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

            /*
             * 字符串是不可变的对象。字符串的不可变性，意味着每当对字符串进行操作时，都将产生一个新的字符串对象，如果频繁操作字符串对象，会在托管堆中产生大量的无用字符串，增加垃圾收集器的压力，从而造成系统资源的损失。使用字符串的Replace、split、Remove等方法操作字符串时，实际上都产生一个新的字符串对象，原有的字符串如果没有被引用，将会被垃圾收集器回收。
             * 使用StringBuilder可以解决以上出现的问题，它将不会产生新的字符串对象。
             * 
             * 字符Char是值类型，总是表示成16为的Unicode代码值。如果将Char显示转换为数值类型，可以得到ASCII码值；相反，如果将ASCII码数值强制转换为Char，将会得到一个Char对象。
             * 
             * 区位码：汉子的区位码，首先通过Encoding对象的GetBytes方法得到汉字的字节数组，将字节数组的第一位和第二位分别取整，然后将得到的两个整形数值分别减去160后转换为字符串，链接在一起就是汉字区位码。
             * (((shor)(P_bt_array[0]-'\0'))-160).ToString() + (((short)(P_bt_array[1]-'\0'))-160).ToString()
             * 使用Encoding对象的GetBytes方法可以得到字符串对象的字节数组，可以创建一个FileStream对象，方便讲字节数组写入文件中。
             * 
             * 
             * 
             * 
             * */
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
