using System;
using System.Reflection;
using System.Runtime.Versioning;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("DLLのパスを指定してください。");
            return;
        }

        string dllPath = args[0];

        try
        {
            Assembly assembly = Assembly.LoadFrom(dllPath);
            var targetFrameworkAttribute = assembly.GetCustomAttribute<TargetFrameworkAttribute>();

            if (targetFrameworkAttribute != null)
            {
                Console.WriteLine($"ターゲットフレームワーク\t{targetFrameworkAttribute.FrameworkName}");
            }
            else
            {
                Console.WriteLine("ターゲットフレームワーク情報が見つかりませんでした。");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"エラーが発生しました: {ex.Message}");
        }
    }
}