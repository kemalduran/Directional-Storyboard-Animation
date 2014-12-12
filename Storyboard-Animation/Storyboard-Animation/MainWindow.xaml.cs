using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Storyboard_Animation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            putImage();
            Animation anim = new Animation();
            anim.sb.Completed += delegate
            {
                MessageBox.Show("animation ended!");
            };
            Settings.DIRECTION dir = Settings.DIRECTION.Right_Up;
            anim.animate(img, dir);
        }
        Image img;
        void putImage()
        {
            img = new Image();
            img.Width = img.Height = 50;
            img.Source = new BitmapImage(new Uri(@"../../Assets/android.png", UriKind.Relative));
            img.RenderTransformOrigin = new Point(0.5, 0.5);
            TransformGroup tg = new TransformGroup();
            tg.Children.Add(new TranslateTransform());
            img.RenderTransform = tg;

            LayoutRoot.Children.Add(img);
            Grid.SetRow(img, 0);
            Grid.SetColumn(img, 0);

        }
    }
}
