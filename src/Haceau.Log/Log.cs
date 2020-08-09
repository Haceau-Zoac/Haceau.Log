using System;
using System.IO;

namespace Haceau
{
    public class Log
    {
        /// <summary>
        /// 文件目录
        /// </summary>
        public string src;
        /// <summary>
        /// 文件名
        /// </summary>
        public string fileName;

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="message">信息</param>
        public void Write(string type, string message)
        {
            FileStream fs = new FileStream(src + fileName, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine($"[{DateTime.Now}] {type} {message}");
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// 写警告日志
        /// </summary>
        /// <param name="message">信息</param>
        public void Warning(string message) =>
            Write("WARN", message);

        /// <summary>
        /// 写普通日志
        /// </summary>
        /// <param name="message">信息</param>
        public void Info(string message) =>
            Write("INFO", message);

        /// <summary>
        /// 写错误日志
        /// </summary>
        /// <param name="message">信息</param>
        public void Error(string message) =>
            Write("ERROR", message);

        /// <summary>
        /// 写致命错误日志
        /// </summary>
        /// <param name="message">信息</param>
        public void Fatal(string message) =>
            Write("FATAL", message);

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="src">路径</param>
        /// <param name="fileName">文件名</param>
        public Log(string src, string fileName)
        {
            this.src = src;
            this.fileName = fileName;
            if (!Directory.Exists(src))
                Directory.CreateDirectory(src);
            if (!File.Exists(src + fileName))
                File.Create(src + fileName);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="src">文件目录</param>
        public Log(string fileName) : this(Environment.CurrentDirectory + $@"\log\", fileName)
        {
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public Log() : this(Environment.CurrentDirectory + $@"\log\", DateTime.Now.ToString("G").Replace('/', '-').Replace(':', '-') + ".txt")
        {
        }
    }
}