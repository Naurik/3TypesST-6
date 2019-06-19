using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using TaskManager.Model;

namespace TaskManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int change = 0;
        string check = "";
        int flag = 0;
        string hour = "";
        string minute = "";
        string time = "";


        public MainWindow()
        {
            InitializeComponent();
            #region ViewPanelElement
            textBlockPeriodOnes.Visibility = Visibility.Collapsed;
            textBlockPeriodMonth.Visibility = Visibility.Collapsed;
            textBlockPeriodDays.Visibility = Visibility.Collapsed;
            textBlockPeriodYear.Visibility = Visibility.Collapsed;
            textBlockDownloadName.Visibility = Visibility.Hidden;
            textBoxDownloadName.Visibility = Visibility.Hidden;
            textBoxDownload.Visibility = Visibility.Hidden;
            textBlockDownload.Visibility = Visibility.Hidden;
            buttonDownload.Visibility = Visibility.Hidden;
            textBlockMoveFirst.Visibility = Visibility.Hidden;
            textBlockMoveSecond.Visibility = Visibility.Hidden;
            textBoxMoveFirst.Visibility = Visibility.Hidden;
            textBoxMoveSecond.Visibility = Visibility.Hidden;
            buttonMove.Visibility = Visibility.Hidden;
            buttonSend.Visibility = Visibility.Hidden;
            textBlockSendFrom.Visibility = Visibility.Hidden;
            textBoxSendFrom.Visibility = Visibility.Hidden;
            textBoxSendTo.Visibility = Visibility.Hidden;
            textBlockSendTo.Visibility = Visibility.Hidden;
            textBoxSendLogin.Visibility = Visibility.Hidden;
            textBlockSendLogin.Visibility = Visibility.Hidden;
            textBlockSendMessage.Visibility = Visibility.Hidden;
            textBoxSendMessage.Visibility = Visibility.Hidden;
            passwordBoxSendPassword.Visibility = Visibility.Hidden;
            textBlockSendPassword.Visibility = Visibility.Hidden;
            #endregion
        }

        //Таймер
        private void ShowDate()
        {
            while(datePiker.SelectedDate.Value != DateTime.Now 
                && textBoxHour.Text != DateTime.Now.Hour.ToString()
                && textBoxMinute.Text != DateTime.Now.Minute.ToString())
            {
                DispatcherTimer time = new DispatcherTimer();
                time.Interval = TimeSpan.FromSeconds(1);
                time.Tick += TimeEvent;
                time.Start();
            }
            Timer timer = new Timer(Period, null, TimeSpan.FromSeconds(1), TimeSpan.FromDays(flag)); 
        }

        private void TimeEvent(object sender, EventArgs e)
        {
            textBlockData.Text = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            textBlockTime.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
        }

        SendEmailInformation email = new SendEmailInformation();
        MoveInformation move = new MoveInformation();
        DownLoadInformation downLoad = new DownLoadInformation();

        #region TypesClick
        private void ClickDownload(object sender, RoutedEventArgs e)
        {
            change = 1;
            check = "DownLoad";
            VisibilityWindow();
        }

        private void ClickMoving(object sender, RoutedEventArgs e)
        {
            change = 2;
            check = "Move";
            VisibilityWindow();
        }

        private void ClickSend(object sender, RoutedEventArgs e)
        {
            change = 3;
            check = "Send";
            VisibilityWindow();
        }
        #endregion

        #region ShowHidden
        public void VisibilityWindow()
        {
            if (change == 1)
            {
                textBlockDownload.Visibility = Visibility.Visible;
                textBoxDownload.Visibility = Visibility.Visible;
                buttonDownload.Visibility = Visibility.Visible;
                textBlockDownloadName.Visibility = Visibility.Visible;
                textBoxDownloadName.Visibility = Visibility.Visible;
                textBlockMoveFirst.Visibility = Visibility.Hidden;
                textBlockMoveSecond.Visibility = Visibility.Hidden;
                textBoxMoveFirst.Visibility = Visibility.Hidden;
                textBoxMoveSecond.Visibility = Visibility.Hidden;
                buttonMove.Visibility = Visibility.Hidden;
                buttonSend.Visibility = Visibility.Hidden;
                textBlockSendFrom.Visibility = Visibility.Hidden;
                textBoxSendFrom.Visibility = Visibility.Hidden;
                textBoxSendTo.Visibility = Visibility.Hidden;
                textBlockSendTo.Visibility = Visibility.Hidden;
                textBoxSendLogin.Visibility = Visibility.Hidden;
                textBlockSendLogin.Visibility = Visibility.Hidden;
                textBlockSendMessage.Visibility = Visibility.Hidden;
                textBoxSendMessage.Visibility = Visibility.Hidden;
                passwordBoxSendPassword.Visibility = Visibility.Hidden;
                textBlockSendPassword.Visibility = Visibility.Hidden;

            }
            else if (change == 2)
            {
                textBlockDownloadName.Visibility = Visibility.Hidden;
                textBoxDownloadName.Visibility = Visibility.Hidden;
                textBoxDownload.Visibility = Visibility.Hidden;
                textBlockDownload.Visibility = Visibility.Hidden;
                buttonDownload.Visibility = Visibility.Hidden;
                textBoxMoveFirst.Visibility = Visibility.Visible;
                textBoxMoveSecond.Visibility = Visibility.Visible;
                textBlockMoveFirst.Visibility = Visibility.Visible;
                textBlockMoveSecond.Visibility = Visibility.Visible;
                buttonMove.Visibility = Visibility.Visible;
                buttonSend.Visibility = Visibility.Hidden;
                textBlockSendFrom.Visibility = Visibility.Hidden;
                textBoxSendFrom.Visibility = Visibility.Hidden;
                textBoxSendTo.Visibility = Visibility.Hidden;
                textBlockSendTo.Visibility = Visibility.Hidden;
                textBoxSendLogin.Visibility = Visibility.Hidden;
                textBlockSendLogin.Visibility = Visibility.Hidden;
                textBlockSendMessage.Visibility = Visibility.Hidden;
                textBoxSendMessage.Visibility = Visibility.Hidden;
                passwordBoxSendPassword.Visibility = Visibility.Hidden;
                textBlockSendPassword.Visibility = Visibility.Hidden;
            }
            else if (change == 3)
            {
                textBlockDownloadName.Visibility = Visibility.Hidden;
                textBoxDownloadName.Visibility = Visibility.Hidden;
                textBoxDownload.Visibility = Visibility.Hidden;
                textBlockDownload.Visibility = Visibility.Hidden;
                buttonDownload.Visibility = Visibility.Hidden;
                textBlockMoveFirst.Visibility = Visibility.Hidden;
                textBlockMoveSecond.Visibility = Visibility.Hidden;
                textBoxMoveFirst.Visibility = Visibility.Hidden;
                textBoxMoveSecond.Visibility = Visibility.Hidden;
                buttonMove.Visibility = Visibility.Hidden;
                textBlockSendFrom.Visibility = Visibility.Visible;
                textBoxSendFrom.Visibility = Visibility.Visible;
                textBoxSendTo.Visibility = Visibility.Visible;
                textBlockSendTo.Visibility = Visibility.Visible;
                textBoxSendLogin.Visibility = Visibility.Visible;
                textBlockSendLogin.Visibility = Visibility.Visible;
                textBlockSendMessage.Visibility = Visibility.Visible;
                textBoxSendMessage.Visibility = Visibility.Visible;
                passwordBoxSendPassword.Visibility = Visibility.Visible;
                textBlockSendPassword.Visibility = Visibility.Visible;
                buttonSend.Visibility = Visibility.Visible;
            }
        }
        #endregion


        #region TypesMethod
        public void DownLoad()//Экземпляр Загрузки
        {
            using (WebClient web = new WebClient())
            {
                string url = textBoxDownload.Text;
                web.DownloadFile(url, "File.pdf");
                MessageBox.Show("Файл загружен в папку с проектом");
            }
        }

        public void Move()
        {
            using (var context = new ContextTypes())
            {
                try
                {
                    string filePath = System.IO.Path.Combine(textBoxMoveFirst.Text);
                    string query = "Действительно переместить файл \n" + filePath + " ?";
                    if (MessageBox.Show(query, "Переместить файл?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        File.Move(filePath, textBoxMoveSecond.Text);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не удается переместить файл из-за исключения: " + ex.Message);
                }
            }

        }

        public void Send()
        {
            using (var context = new ContextTypes())
            {
                MailAddress from = new MailAddress(textBoxSendFrom.Text);
                MailAddress to = new MailAddress(textBoxSendTo.Text);
                MailMessage message = new MailMessage(from, to);
                message.Subject = textBoxSendMessage.Text;
                message.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("nauzikm@gmail.com", "mawimovnauryzbai1994");
                smtp.EnableSsl = true;
                smtp.Send(message);
            }
        }
        #endregion

        #region ButtonClick
        private async void ButtonDownloadClick(object sender, RoutedEventArgs e)
        {
            hour = textBlockHour.Text;
            minute = textBlockMinute.Text;
            time = hour + minute;
            Thread thread = new Thread(ShowDate);
            using (var context = new ContextTypes())
            {
                downLoad = new DownLoadInformation
                {
                    UrlAddress = textBoxDownload.Text,
                    FileName = textBoxDownloadName.Text,
                    Data = datePiker.SelectedDate.Value,
                    Time = time
                };
                context.DownLoad.Add(downLoad);
                await context.SaveChangesAsync();
            }
        }

        private async void ButtonMoveClick(object sender, RoutedEventArgs e)
        {
            hour = textBlockHour.Text;
            minute = textBlockMinute.Text;
            time = hour + minute;
            Thread thread = new Thread(ShowDate);
            using (var context = new ContextTypes())
            {
                move = new MoveInformation
                {
                    PathFrom = System.IO.Path.Combine(textBoxMoveFirst.Text),
                    PathTo = textBoxMoveSecond.Text,
                    Data = datePiker.SelectedDate.Value,
                    Time = time
                };
                context.Moving.Add(move);
                await context.SaveChangesAsync();
            }
            
        }


        private async void ButtonClickToSend(object sender, RoutedEventArgs e)
        {
            hour = textBlockHour.Text;
            minute = textBlockMinute.Text;
            time = hour + minute;
            Thread thread = new Thread(ShowDate);
            using (var context = new ContextTypes())
            {
                email = new SendEmailInformation
                {
                    NameFrom = textBoxSendFrom.Text,
                    NameTo = textBoxSendTo.Text,
                    Text = textBoxSendMessage.Text,
                    Data = datePiker.SelectedDate.Value,
                    Time = time
                };
                context.SendEmail.Add(email);
                await context.SaveChangesAsync();
            }
        }
        #endregion


        #region Period
        private void ClickOnes(object sender, RoutedEventArgs e)
        {
            flag = 0;
            textBlockPeriodOnes.Visibility = Visibility.Visible;
            textBlockPeriodMonth.Visibility = Visibility.Collapsed;
            textBlockPeriodDays.Visibility = Visibility.Collapsed;
            textBlockPeriodYear.Visibility = Visibility.Collapsed;
        }

        private void ClickEveryDay(object sender, RoutedEventArgs e)
        {
            flag = 1;
            textBlockPeriodOnes.Visibility = Visibility.Collapsed;
            textBlockPeriodMonth.Visibility = Visibility.Collapsed;
            textBlockPeriodDays.Visibility = Visibility.Visible;
            textBlockPeriodYear.Visibility = Visibility.Collapsed;
        }

        private void ClickEveryMonth(object sender, RoutedEventArgs e)
        {
            flag = 30;
            textBlockPeriodOnes.Visibility = Visibility.Collapsed;
            textBlockPeriodMonth.Visibility = Visibility.Visible;
            textBlockPeriodDays.Visibility = Visibility.Collapsed;
            textBlockPeriodYear.Visibility = Visibility.Collapsed;
        }

        private void ClickEveryYear(object sender, RoutedEventArgs e)
        {
            flag = 365;
            textBlockPeriodOnes.Visibility = Visibility.Collapsed;
            textBlockPeriodMonth.Visibility = Visibility.Collapsed;
            textBlockPeriodDays.Visibility = Visibility.Collapsed;
            textBlockPeriodYear.Visibility = Visibility.Visible;
        }
        #endregion

        public void Period(object state)
        {
            if (check == "DownLoad")
            {
                DownLoad();
            }
            else if (check == "Move")
            {
                Move();
            }
            else if (check == "Send")
            {
                Send();
            }
        }
    }
}
