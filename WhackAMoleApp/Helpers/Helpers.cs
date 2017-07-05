using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhackAMoleApp
{
    public class FormSingleton<TForm> 
        where TForm : Form, new()
    {
        private TForm instance;
        public TForm Form
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                    instance = new TForm();

                return instance;
            }
        }    
    }

    public static class EnumerableHelper
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T item in source)
                action(item);
        }
    }

    public static class ControlHelper
    {
        public static IEnumerable<T> GetControlsOfType<T>(Control root) where T : Control
        {
            var t = root as T;
            if (t != null)
                yield return t;

            var container = root as ContainerControl;
            if (container != null)
                foreach (Control c in container.Controls)
                    foreach (var i in GetControlsOfType<T>(c))
                        yield return i;
        }
    }

    public static class EnumHelper
    {
        public static TEnum ToEnum<TEnum>(this string str) where TEnum : struct
        {
            return (TEnum)Enum.Parse(typeof(TEnum), str);
        }

        public static TEnum ToEnumOrDefault<TEnum>(this object obj, TEnum defaultEnum) where TEnum : struct
        {
            return obj.ToString().ToEnumOrDefault(defaultEnum);
        }

        public static TEnum ToEnumOrDefault<TEnum>(this string str, TEnum defaultEnum) where TEnum : struct
        {
            TEnum test = default(TEnum);
            return (Enum.TryParse(str, out test)) ? test : defaultEnum;
        }
    }

    public static class NumberHelper
    {
        public static double PercOf(this double val, double maxVal = 100)
        {
            if (val > maxVal) return 1;
            if (val < 0) return 0;
            return (val / maxVal); // Will return a number between 0 and 1
        }
    }
}
