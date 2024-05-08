using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Wpf.Ui;
using Wpf.Ui.Controls;
using Wpf.Ui.Extensions;

namespace Reptile_Tools.ViewModels
{
    partial class MVVMTimeStampToolsPageViewModels: ObservableObject
    {
        [ObservableProperty]
        public int _timestamp = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        private DispatcherTimer timer;
        public MVVMTimeStampToolsPageViewModels() 
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // 每秒触发一次事件
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            Timestamp = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }
        [ObservableProperty]
        public string _stopstartbuttontext = "开始";
        [ObservableProperty]
        public bool _timerstatus = false;
        [RelayCommand]
        public void StopTimer()
        {
            if (Timerstatus)
            {
                timer.Stop();
                Timerstatus = false;
                Stopstartbuttontext = "开始";
            }
            else
            {
                timer.Start();
                Timerstatus = true;
                Stopstartbuttontext = "停止";
            }
        }
        [ObservableProperty]
        public string _timestamptext;
        partial void OnTimestamptextChanged(string value)
        {
            if (value == null || value.Trim() == "") 
            { 
                IsEnableTotime = false;
                Timetext = "";
            } else { 
                IsEnableTotime = true;
                TimestampToTime();
            }
        }
        [ObservableProperty]
        public string _timetext;
        [ObservableProperty]
        public string _timestamptext2;
        [ObservableProperty]
        public bool _isEnableTotime;
        [ObservableProperty]
        public bool _isEnableTotimestamp;
        [ObservableProperty]
        public string _timetext2;
        partial void OnTimetext2Changed(string value)
        {
            if (value == null || value.Trim() == "")
            {
                IsEnableTotimestamp = false;
                Timestamptext2 = "";
            }
            else
            {
                IsEnableTotimestamp = true;
                TimeToTimestamp();
            }
        }
        [RelayCommand]
        public void TimestampToTime()
        {
            long timestamp = long.Parse(Timestamptext);
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(timestamp);
            DateTime dateTime = dateTimeOffset.LocalDateTime;
            Timetext = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
        [RelayCommand]
        public void TimeToTimestamp()
        {
            string format = "yyyy-MM-dd HH:mm:ss";
            DateTimeOffset dateTimeOffset = DateTimeOffset.ParseExact(Timetext2, format, null);
            long timestamp = dateTimeOffset.ToUnixTimeSeconds();
            Timestamptext2 = timestamp.ToString("D");
        }
    }
}
