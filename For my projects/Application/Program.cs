using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace For_my_projects
{
    static class Program
    {
        static LoginForm loginForm;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DBWork.Init();
            loginForm = new LoginForm();
            Application.Run(loginForm);
        }

        public static void returnToLoginForm()
        {
            loginForm.clearPass();
            loginForm.Show();
        }
    }
}
