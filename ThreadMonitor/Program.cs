using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace ThreadMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.LockThread();//lock方法
            program.LockThread1();///Monitor方法
            program.LockThread2();//Mutex方法
            program.Show();
            Console.ReadLine();
        }
        public  void LockThread()
        {
            lock (this)
            {
                Console.WriteLine("锁定线程以实现线程同步！");
            }

        }
        public void LockThread1()
        {
            Monitor.Enter(this);//锁定当前线程
            Console.WriteLine("锁定线程以实现线程同步！");
            Monitor.Exit(this);

        }
        public void LockThread2()
        {
            Mutex mutex = new Mutex(false); //实例化Mutex类
            mutex.WaitOne();
            Console.WriteLine("锁定线程以实现线程同步！");
            mutex.ReleaseMutex(); ///释放mutex对象

        }
        public void Show()
        {
            string a = "0";
            string b = string.Format("编号:{0}",a);
            Console.Write("输出：{0}",b);
        }
    }
}
