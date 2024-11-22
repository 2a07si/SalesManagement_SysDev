using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // 追加


namespace SalesManagement_SysDev.Classまとめ
{
    internal class GlobalBadge
    {
        private int _notificationCount;
        private string _badgeCount;

        public GlobalBadge( string badgeCount)
        {
            _badgeCount = badgeCount;
        }
        public GlobalBadge( int notificationCount )
        {
            _notificationCount = notificationCount; //通知数を代入
        }

        public void DrawBadge(PaintEventArgs e, Button button)
        {
            if (!string.IsNullOrEmpty(_badgeCount))
            {
                Graphics g = e.Graphics;

                // バッジの位置とサイズ
                int badgeSize = 22; // バッジの直径
                Rectangle badgeBounds = new Rectangle(button.Width - badgeSize, 0, badgeSize, badgeSize);

                // バッジを描画
                Color customColor = Color.FromArgb(255, 100, 100);
                SolidBrush customBrush = new SolidBrush(customColor);
                g.FillEllipse(customBrush, badgeBounds);

                // 通知数を描画
                string countText = _badgeCount;
                Font font = new Font("Arial", 8, FontStyle.Bold);
                SizeF textSize = g.MeasureString(countText, font);
                PointF textPosition = new PointF(
                    badgeBounds.X + (badgeSize - textSize.Width) / 2,
                    badgeBounds.Y + (badgeSize - textSize.Height) / 2
                );

                g.DrawString(countText, font, Brushes.White, textPosition);
            }
        }
        public void SecondBadge(PaintEventArgs e, Button button)
        {
            if (_notificationCount > 0)
            {
                Graphics g = e.Graphics;

                // バッジの位置とサイズ
                int badgeSize = 30; // バッジの直径
                Rectangle badgeBounds = new Rectangle(button.Width - badgeSize, 0, badgeSize, badgeSize);

                // バッジを描画
                Color customColor = Color.FromArgb(255, 100, 100);
                SolidBrush customBrush = new SolidBrush(customColor);
                g.FillEllipse(customBrush, badgeBounds);

                // 通知数を描画
                string countText = _notificationCount.ToString();
                Font font = new Font("Arial", 10, FontStyle.Bold);
                SizeF textSize = g.MeasureString(countText, font);
                PointF textPosition = new PointF(
                    badgeBounds.X + (badgeSize - textSize.Width) / 2,
                    badgeBounds.Y + (badgeSize - textSize.Height) / 2
                );

                g.DrawString(countText, font, Brushes.White, textPosition);
            }
        }
        public void pinpoint(PaintEventArgs e, Button button)
        {

            if (!string.IsNullOrEmpty(_badgeCount))
            {
                Graphics g = e.Graphics;

                // バッジの位置とサイズ
                int badgeSize = 13; // バッジの直径
                Rectangle badgeBounds = new Rectangle(button.Width - badgeSize, 0, badgeSize, badgeSize);

                // バッジを描画
                Color customColor = Color.FromArgb(255, 100, 100);
                SolidBrush customBrush = new SolidBrush(customColor);
                g.FillEllipse(customBrush, badgeBounds);

                // 通知数を描画
                string countText = _badgeCount;
                Font font = new Font("Arial", 8, FontStyle.Bold);
                SizeF textSize = g.MeasureString(countText, font);
                PointF textPosition = new PointF(
                    badgeBounds.X + (badgeSize - textSize.Width) / 2,
                    badgeBounds.Y + (badgeSize - textSize.Height) / 2
                );

                g.DrawString(countText, font, Brushes.White, textPosition);
            }
        }

    }
}
