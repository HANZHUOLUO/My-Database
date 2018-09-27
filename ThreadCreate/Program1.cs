using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ThreadCreate
{
    class Program1
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(CreateThread));///实例化一个线程
            thread.Start();///启动线程
            thread.Suspend();///挂起线程
            thread.Resume();//恢复挂起的线程
            Thread.Sleep(1000);//线程休眠一分钟
            thread.Abort();///终止线程
            thread.Join();//阻止调用该线程，直到该线程终止

            Thread thread1 = new Thread(new ThreadStart(Thread1));//创建线程一
            Thread thread2 = new Thread(new ThreadStart(Thread2));//创建线程二
            thread1.Start();
            thread2.Start();
            Program1 program = new Program1();///实例化类对象
           
            Console.ReadLine();
        }
        public static void CreateThread()
        {
            Console.WriteLine("线程开始");
        }
        public static void Thread1()
        {
            Console.WriteLine("线程一");
        }
        public static void Thread2()
        {
            Console.WriteLine("线程二");
        }
        public static void LockThead()
        {
            lock (this) {
                Console.WriteLine("锁定线程以实现线程同步");
            }
        }
    }
}
