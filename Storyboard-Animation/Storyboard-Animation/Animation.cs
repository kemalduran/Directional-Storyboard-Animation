using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Storyboard_Animation
{
    public class Animation
    {
        public Storyboard sb;
        public Animation()
        {
            sb = new Storyboard();
        }

        public void animate(Image image, Settings.DIRECTION dir)
        {
            DoubleAnimation animX, animY;

            if (dir == Settings.DIRECTION.Right || dir == Settings.DIRECTION.Left)
            {
                int to = Settings.SIZE;
                if (dir == Settings.DIRECTION.Left)
                    to = -to;
                animX = new DoubleAnimation()
                {
                    From = 0,
                    To = to,
                    Duration = TimeSpan.FromMilliseconds(Settings.DURATION)
                };
                Storyboard.SetTarget(animX, image);

                Storyboard.SetTargetProperty(animX, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[0].(TranslateTransform.X)"));
                sb.Children.Add(animX);
            }
            else if (dir == Settings.DIRECTION.Down || dir == Settings.DIRECTION.Up)
            {
                int to = Settings.SIZE;
                if (dir == Settings.DIRECTION.Up)
                    to = -to;

                animY = new DoubleAnimation()
                {
                    From = 0,
                    To = to,
                    Duration = TimeSpan.FromMilliseconds(Settings.DURATION)
                };
                Storyboard.SetTarget(animY, image);
                Storyboard.SetTargetProperty(animY, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[0].(TranslateTransform.Y)"));
                sb.Children.Add(animY);
            }
            else // if corners
            {
                int toX = Settings.SIZE, toY = Settings.SIZE;
                if (dir == Settings.DIRECTION.Left_Down || dir == Settings.DIRECTION.Left_Up)
                    toX = -toX;
                if (dir == Settings.DIRECTION.Left_Up || dir == Settings.DIRECTION.Right_Up)
                    toY = -toY;


                animX = new DoubleAnimation()
                {
                    From = 0,
                    To = toX,
                    Duration = TimeSpan.FromMilliseconds(Settings.DURATION)
                };
                Storyboard.SetTarget(animX, image);
                Storyboard.SetTargetProperty(animX, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[0].(TranslateTransform.X)"));
                sb.Children.Add(animX);

                animY = new DoubleAnimation()
                {
                    From = 0,
                    To = toY,
                    Duration = TimeSpan.FromMilliseconds(Settings.DURATION)
                };
                Storyboard.SetTarget(animY, image);
                Storyboard.SetTargetProperty(animY, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[0].(TranslateTransform.Y)"));
                sb.Children.Add(animY);
            }
            // begin animation
            sb.Begin();
        }

    }
}
