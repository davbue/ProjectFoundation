using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using ProjectFoundation.Views;
using MaterialDesignThemes.Wpf;
using System.Windows.Media;

namespace ProjectFoundation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow AppWindow { get; set; }
        public static List<UserControl> ForwardStack { get; set; }
        public static List<UserControl> BackwardStack { get; set; }
        public static Dictionary<string, string> NavMapping { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            AppWindow = this;
            ForwardStack = new List<UserControl>();
            BackwardStack = new List<UserControl>();
            NavMapping = new Dictionary<string, string>();
            ViewHolder.Child = new ExploreView();
            CreateNavMapping();

            SourceInitialized += (s, e) =>
            {
                IntPtr handle = new WindowInteropHelper(this).Handle;
                HwndSource.FromHwnd(handle).AddHook(new HwndSourceHook(WindowProc));
            };
        }

        private void NavPanelMouseDown(object sender, MouseButtonEventArgs e)
        {
            StackPanel navPanel = sender as StackPanel;
            switch (navPanel.Name)
            {
                case "ExploreNav":
                    if (!(ViewHolder.Child is ExploreView))
                    {
                        ChangeView(new ExploreView());
                    }
                    break;
                case "DownloadsNav":
                    if (!(ViewHolder.Child is DownloadsView))
                    {
                        ChangeView(new DownloadsView());
                    }
                    break;
                case "LibraryNav":
                    if (!(ViewHolder.Child is LibraryView))
                    {
                        ChangeView(new LibraryView());
                    }
                    break;
                default:
                    break;
            }
        }

        private void ChangeNavPanel(UserControl userControl)
        {
            //Find Corresponding NavPanel
            StackPanel navPanel = (StackPanel)FindName(NavMapping[userControl.GetType().Name]);
            //Set Selected Design for selected Panel
            foreach (var control in NavBar.Children)
            {
                if (control is StackPanel)
                {
                    StackPanel panel = control as StackPanel;
                    panel.Children[0].Visibility = Visibility.Hidden;
                    panel.Background.Opacity = 0;
                    ((PackIcon)panel.Children[1]).Foreground = Brushes.Black;
                }
            }
            navPanel.Children[0].Visibility = Visibility.Visible;
            navPanel.Background.Opacity = 0.3;
            ((PackIcon)navPanel.Children[1]).Foreground = (LinearGradientBrush)FindResource("Gradient1");
        }

        private void ChangeView(UserControl userControl)
        {
            ChangeNavPanel(userControl);
            //ChangeView
            BackwardStack.Add((UserControl)ViewHolder.Child);
            ViewHolder.Child = userControl;
        }

        private void BackwardBtn_Click(object sender, RoutedEventArgs e)
        {
            if(BackwardStack.Count == 0)
            {
                return;
            }
            UserControl userControl = BackwardStack[BackwardStack.Count - 1];
            ForwardStack.Add((UserControl)ViewHolder.Child);
            ChangeNavPanel(userControl);
            ViewHolder.Child = userControl;
            BackwardStack.Remove(userControl);
        }

        private void ForwardBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ForwardStack.Count == 0)
            {
                return;
            }
            UserControl userControl = ForwardStack[ForwardStack.Count - 1];
            BackwardStack.Add((UserControl)ViewHolder.Child);
            ChangeNavPanel(userControl);
            ViewHolder.Child = userControl;
            ForwardStack.Remove(userControl);
        }

        private void CreateNavMapping()
        {
            NavMapping.Add("DownloadsView", "DownloadsNav");
            NavMapping.Add("ExploreView", "ExploreNav");
            NavMapping.Add("LibraryView", "LibraryNav");
        }

        //Window Settings
        private static IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case 0x0024:
                    WmGetMinMaxInfo(hwnd, lParam);
                    handled = true;
                    break;
            }
            return (IntPtr)0;
        }

        private static void WmGetMinMaxInfo(IntPtr hwnd, IntPtr lParam)
        {
            MINMAXINFO mmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));
            int MONITOR_DEFAULTTONEAREST = 0x00000002;
            IntPtr monitor = MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);
            if (monitor != IntPtr.Zero)
            {
                MONITORINFO monitorInfo = new MONITORINFO();
                GetMonitorInfo(monitor, monitorInfo);
                RECT rcWorkArea = monitorInfo.rcWork;
                RECT rcMonitorArea = monitorInfo.rcMonitor;
                mmi.ptMaxPosition.x = Math.Abs(rcWorkArea.left - rcMonitorArea.left);
                mmi.ptMaxPosition.y = Math.Abs(rcWorkArea.top - rcMonitorArea.top);
                mmi.ptMaxSize.x = Math.Abs(rcWorkArea.right - rcWorkArea.left);
                mmi.ptMaxSize.y = Math.Abs(rcWorkArea.bottom - rcWorkArea.top);
            }
            Marshal.StructureToPtr(mmi, lParam, true);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            /// <summary>x coordinate of point.</summary>
            public int x;
            /// <summary>y coordinate of point.</summary>
            public int y;
            /// <summary>Construct a point of coordinates (x,y).</summary>
            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
        };

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class MONITORINFO
        {
            public int cbSize = Marshal.SizeOf(typeof(MONITORINFO));
            public RECT rcMonitor = new RECT();
            public RECT rcWork = new RECT();
            public int dwFlags = 0;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 0)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
            public static readonly RECT Empty = new RECT();
            public int Width { get { return Math.Abs(right - left); } }
            public int Height { get { return bottom - top; } }
            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }
            public RECT(RECT rcSrc)
            {
                left = rcSrc.left;
                top = rcSrc.top;
                right = rcSrc.right;
                bottom = rcSrc.bottom;
            }
            public bool IsEmpty { get { return left >= right || top >= bottom; } }
            public override string ToString()
            {
                if (this == Empty) { return "RECT {Empty}"; }
                return "RECT { left : " + left + " / top : " + top + " / right : " + right + " / bottom : " + bottom + " }";
            }
            public override bool Equals(object obj)
            {
                if (!(obj is Rect)) { return false; }
                return (this == (RECT)obj);
            }
            /// <summary>Return the HashCode for this struct (not garanteed to be unique)</summary>
            public override int GetHashCode() => left.GetHashCode() + top.GetHashCode() + right.GetHashCode() + bottom.GetHashCode();
            /// <summary> Determine if 2 RECT are equal (deep compare)</summary>
            public static bool operator ==(RECT rect1, RECT rect2) { return (rect1.left == rect2.left && rect1.top == rect2.top && rect1.right == rect2.right && rect1.bottom == rect2.bottom); }
            /// <summary> Determine if 2 RECT are different(deep compare)</summary>
            public static bool operator !=(RECT rect1, RECT rect2) { return !(rect1 == rect2); }
        }

        [DllImport("user32")]
        internal static extern bool GetMonitorInfo(IntPtr hMonitor, MONITORINFO lpmi);

        [DllImport("User32")]
        internal static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);
    }
}
