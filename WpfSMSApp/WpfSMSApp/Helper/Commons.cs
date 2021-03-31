using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using NLog;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using WpfSMSApp.Model;

namespace WpfSMSApp
{
    public class Commons
    {
        //NLOg 정적 인스턴스 생성
        public static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();

        //로그인한 유저 정보
        public static User LOGINED_USER;

        /// <summary>
        /// MD5 암호화 처리 메서드
        /// </summary>
        /// <param name="md5hash"></param>
        /// <param name="planStr"></param>
        /// <returns></returns>
        public static string GetMdHash(MD5 md5hash, string planStr)
        {
            byte[] data = md5hash.ComputeHash(Encoding.UTF8.GetBytes(planStr));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }
            return builder.ToString();
        }
        /// <summary>
        /// 이메일 정규식 확인 메서드
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        internal static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?");
        }



        /// <summary>
        /// Metro MessageBox 공통메서드
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public static async Task<MessageDialogResult> ShowMessageAsync(
            string title, string message,
            MessageDialogStyle style = MessageDialogStyle.Affirmative)
        {
            return await ((MetroWindow)Application.Current.MainWindow)
                .ShowMessageAsync(title, message, style, null);
        }
            
    }
}
