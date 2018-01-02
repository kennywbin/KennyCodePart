using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{

    //抽像算法类
    internal abstract class Streategy
    {
        //算法方法
        public abstract void AlgorithmInterface();
    }
    //ConcreteStrategy ，封装了具体的算法或行为  继承于Streategy

    //具体算法A
    internal class ConcreteStrategyA : Streategy
    {
        //算法实现
        public override void AlgorithmInterface()
        {
          Console.WriteLine("算法实现A");  
        }
    }
    //具体实现方法B
    class ConcreteStrategyB:Streategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine("算法实现B");  
        }
    }
    //具体实现方法C
    class ConcreteStrategyC : Streategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine("算法实现C");
        }
    }

    //Content，用一个ConcreteStrategy 类来配置，维护对Strategy对象的引用

    internal class Content
    {
        private Streategy streategy;

        //在初使化时。传入具体的策略对象
        public Content(Streategy streategy)
        {
            this.streategy = streategy;
        }
        //上下文接口   ----根据具体的策略对象。调用其算法与方法
        public void ContentInterface()
        {
            streategy.AlgorithmInterface();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //备注 由于实例化不同的策略，所以最终在调用 
            //content.ContentInterface() 时，所获得的结果就不尽相同
            Content content;
            content=new Content(new ConcreteStrategyA());
            content.ContentInterface();

            content=new Content(new ConcreteStrategyB());
            content.ContentInterface();

            content=new Content(new ConcreteStrategyC());
            content.ContentInterface();

            Console.Read();
        }
    }
}