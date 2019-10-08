using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ServerMiddlewareWatchDog
{
    /// <summary>
    /// 通用方法
    /// </summary>
    public static class Common
    {
        #region 延时操作
        /// <summary>
        /// 延时操作秒_秒 161014
        /// </summary>
        /// <param name="delayTime"></param>
        /// <returns></returns>
        public static bool Delay_Second(int delayTime)
        {
            DateTime now = DateTime.Now;
            int s;
            do
            {
                TimeSpan spand = DateTime.Now - now;
                s = spand.Seconds;
                Application.DoEvents();
            }
            while (s < delayTime);
            return true;
        }

        /// <summary>
        /// 延时操作_毫秒
        /// </summary>
        /// <param name="Millisecond"></param>
        public static void Delay_Millisecond(int Millisecond)
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(Millisecond) > DateTime.Now)
            {
                Application.DoEvents();
            }
            return;
        }

        #endregion

        #region 添加水印文字
        private const int EM_SETCUEBANNER = 0x1501;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        /// <summary>
        /// 为TextBox设置水印文字 
        /// </summary>
        /// <param name="textBox">TextBox</param>
        /// <param name="watermark">水印文字</param>
        public static void SetWatermark(this TextBox textBox, string watermark)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, watermark);
        }

        #endregion

        #region 网络相关

        /// <summary>
        /// Ping命令
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool CmdPing(IPAddress ip, int intTimeout_Millisecond = 1000)
        {
            try
            {
                Ping ping = new Ping();
                PingOptions options = new PingOptions();
                options.DontFragment = true;
                string s = "";
                byte[] bytes = Encoding.UTF8.GetBytes(s);
                return (ping.Send(ip, intTimeout_Millisecond, bytes, options).Status.ToString() == "Success");
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        /// <summary>
        /// 获取Dictionary对象 首个对象Key
        /// </summary>
        /// <returns></returns>
        public static object GetDictionaryFirstKey(System.Collections.IDictionary dic)
        {
            foreach (System.Collections.DictionaryEntry entry in dic)
            {
                return entry.Key;
            }
            return null;
        }

        /// <summary>
        /// 复制文件夹 文件
        /// 目录中的文件以及文件夹复制到指定目录中（不包含根目录）
        /// </summary>
        /// <param name="srcPath">原文件夹</param>
        /// <param name="aimPath">目的路径</param>
        public static int CopyDir(string srcPath, string aimPath)
        {
            try
            {
                // 检查目标目录是否以目录分割字符结束如果不是则添加
                if (aimPath[aimPath.Length - 1] != System.IO.Path.DirectorySeparatorChar)
                {
                    aimPath += System.IO.Path.DirectorySeparatorChar;
                }
                // 判断目标目录是否存在如果不存在则新建
                if (!System.IO.Directory.Exists(aimPath))
                {
                    System.IO.Directory.CreateDirectory(aimPath);
                }
                // 得到源目录的文件列表，该里面是包含文件以及目录路径的一个数组
                // 如果你指向copy目标文件下面的文件而不包含目录请使用下面的方法
                // string[] fileList = Directory.GetFiles（srcPath）；
                string[] fileList = System.IO.Directory.GetFileSystemEntries(srcPath);
                // 遍历所有的文件和目录
                foreach (string file in fileList)
                {
                    // 先当作目录处理如果存在这个目录就递归Copy该目录下面的文件
                    if (System.IO.Directory.Exists(file))
                    {
                        CopyDir(file, aimPath + System.IO.Path.GetFileName(file));
                    }
                    // 否则直接Copy文件
                    else
                    {
                        System.IO.File.Copy(file, aimPath + System.IO.Path.GetFileName(file), true);
                    }
                }

                return 1;
            }
            catch (Exception e)
            {
                throw;
            }
        }


        /// <summary>
        /// 删除文件夹文件(不删除根目录)
        /// </summary>
        /// <param name="srcPath"></param>
        /// <returns></returns>
        public static int DeleteDir(string srcPath)
        {
            DirectoryInfo dir = new DirectoryInfo(srcPath);
            FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
            foreach (FileSystemInfo i in fileinfo)
            {
                if (i is DirectoryInfo)            //判断是否文件夹
                {
                    DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                    subdir.Delete(true);          //删除子目录和文件
                }
                else
                {
                    File.Delete(i.FullName);      //删除指定文件
                }
            }
            return 1;
        }


        /// <summary>
        /// 深度拷贝
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T DeepCopy<T>(T obj)
        {
            //如果是字符串或值类型则直接返回
            if (obj is string || obj.GetType().IsValueType) return obj;

            object retval = Activator.CreateInstance(obj.GetType());
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (FieldInfo field in fields)
            {
                try { field.SetValue(retval, DeepCopy(field.GetValue(obj))); }
                catch { }
            }
            return (T)retval;
        }


        /// <summary>
        /// 创建文件地址
        /// </summary>
        /// <param name="strFolderPath"></param>
        /// <returns></returns>
        public static bool CreateFolder(string strFolderPath)
        {
            string Temp_strUpperLevelFolderPath = strFolderPath.Substring(0, strFolderPath.LastIndexOf("\\"));
            if (!Directory.Exists(Temp_strUpperLevelFolderPath))
            {
                CreateFolder(Temp_strUpperLevelFolderPath);
            }
            if (!Directory.Exists(strFolderPath))
            {
                Directory.CreateDirectory(strFolderPath);
            }
            return true;
        }


        public static bool KillProcess(string processName)
        {
            bool bolResult = false;
            System.Diagnostics.Process myproc = new System.Diagnostics.Process();
            //得到所有打开的进程   
            Process[] Temp_ = Process.GetProcessesByName(processName);
            foreach (Process thisproc in Temp_)
            {
                thisproc.Kill();
                bolResult = true;
                ////找到程序进程,kill之。
                //if (!thisproc.CloseMainWindow())
                //{
                //    thisproc.Kill();
                //    bolResult = true;
                //}
            }

            return bolResult;
        }
    }

}

namespace System.Runtime.CompilerServices
{
    public class ExtensionAttribute : Attribute { }
}
