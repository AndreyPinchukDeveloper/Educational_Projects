using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows.Data;
using System.Windows.Input;
using CustomControllersPractice.Commands;

namespace CustomControllersPractice.CustomControls
{
    public delegate void TimeChangedEventHandler(object sender, TimeChangedEventArgs e);

    public class AnalogClock:Control
    {
        private Line hourHand;
        private Line minuteHand;
        private Line secondHand;
        private string _currentTime;

        public string CurrentTime
        {
            get { return _currentTime; }
            set { _currentTime = value;}
        }

        /// <summary>
        /// we call this event every time when time has changed
        /// </summary>
        private static RoutedEvent TimeChangedEvent = EventManager.RegisterRoutedEvent(
            "TimeChanged", RoutingStrategy.Bubble, typeof(TimeChangedEventHandler), typeof(AnalogClock));

        public event TimeChangedEventHandler TimeChanged
        {
            add { AddHandler(TimeChangedEvent, value); }
            remove { RemoveHandler(TimeChangedEvent, value); }
        }

        public bool ShowSeconds
        {
            get { return (bool)GetValue(ShowSecondsProperty); }
            set { SetValue(ShowSecondsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowSeconds.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowSecondsProperty = DependencyProperty.Register(
            "ShowSeconds", typeof(bool), typeof(AnalogClock), new PropertyMetadata(true));

        static AnalogClock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnalogClock), new FrameworkPropertyMetadata(typeof(AnalogClock))); 
            
        }

        /*public AnalogClock()
        {
            ShowTextCommand = new ShowTextCommand(this);
            ShowTextCommand.Execute(this);
        }*/

        protected virtual void OnTimeChanged(DateTime time)
        {
            UpdateHandAngles(time);
            RaiseEvent(new TimeChangedEventArgs(TimeChangedEvent, this) { NewTime = time});
        }

        /// <summary>
        /// Get date from template(styles XAML), call calculated for minute, hour, seconds
        /// start timer
        /// </summary>
        public override void OnApplyTemplate()
        {
            hourHand = Template.FindName("PART_HourHand", this) as Line;
            minuteHand = Template.FindName("PART_MinuteHand", this) as Line;
            secondHand = Template.FindName("PART_SecondHand", this) as Line;

            OnTimeChanged(DateTime.Now);

            DispatcherTimer timer= new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += (s, e) => OnTimeChanged(DateTime.Now);
            timer.Start();

            base.OnApplyTemplate();
        }

        /// <summary>
        /// Calculate for each period of time
        /// </summary>
        private void UpdateHandAngles(DateTime time)
        {
            hourHand.RenderTransform = new RotateTransform((time.Hour / 12.0) * 360, 0.5, 0.5);
            minuteHand.RenderTransform = new RotateTransform((time.Minute / 12.0) * 60, 0.5, 0.5);
            secondHand.RenderTransform = new RotateTransform((time.Second / 12.0) * 60, 0.5, 0.5);
        }

        //ICommand ShowTextCommand { get; }
    }
}
