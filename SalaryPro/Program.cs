using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace SalaryPro
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // 1. Ініціалізація конфігурації
            ApplicationConfiguration.Initialize();

            // 2. Встановлюємо українську мову для всієї програми (включаючи календарі)
            var culture = new CultureInfo("uk-UA");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            // 3. Запуск програми
            Application.Run(new Form1());
        }
    }
}