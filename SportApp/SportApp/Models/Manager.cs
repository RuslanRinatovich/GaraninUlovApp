using System.Windows.Controls;

namespace SportApp.Models
{
    public class Manager
    {
        /// <summary>
        /// Фрейм, в котором отбражаются Page
        /// </summary>
        public static Frame MainFrame { get; set; }
        /// <summary>
        /// Текущий пользователь системы
        /// </summary>
        public static User CurrentUser { get; set; }
    }
}
