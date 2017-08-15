using System; 
using System.Collections.Generic; 
using System.Text; 
using System.Windows.Forms; 
using System.Drawing; 
using System.Drawing.Drawing2D; 

namespace RoundPanel 
{ 
    public class RoundPanel : Panel 
    { 
        private int mMatrixRound = 8; 
        private Color mBack; 

        public Color Back 
        { 
             get { return mBack; } 
            set 
            { 
                if (value == null) 
                { 
                     mBack = Control.DefaultBackColor; 
                } 
                else 
                { 
                     mBack = value; 
                } 
                base.Refresh(); 
            } 
        } 

        public int MatrixRound 
        { 
             get { return mMatrixRound; } 
            set 
            { 
                mMatrixRound = value; 
                base.Refresh(); 
            } 
        } 

        private GraphicsPath CreateRound(Rectangle rect, int radius) 
        { 
            GraphicsPath roundRect = new GraphicsPath(); 
//���� 
            roundRect.AddLine(rect.Left + radius - 1, rect.Top - 1, rect.Right - radius, rect.Top - 1);              
//���Ͻ� 
roundRect.AddArc(rect.Right - radius, rect.Top - 1, radius, radius, 270, 90); 
//�ұ� 
            roundRect.AddLine(rect.Right, rect.Top + radius, rect.Right, rect.Bottom - radius); 
            //���½�

            roundRect.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90); 
//�ױ� 
            roundRect.AddLine(rect.Right - radius, rect.Bottom, rect.Left + radius, rect.Bottom); 
            //���½� 
roundRect.AddArc(rect.Left - 1, rect.Bottom - radius, radius, radius, 90, 90); 
//��� 
            roundRect.AddLine(rect.Left - 1, rect.Top + radius, rect.Left - 1, rect.Bottom - radius); 
//���Ͻ� 
            roundRect.AddArc(rect.Left - 1, rect.Top - 1, radius, radius, 180, 90); 
            return roundRect; 
        } 

        protected override void OnPaint(PaintEventArgs e) 
        { 
            int width = base.Width - base.Margin.Left - base.Margin.Right; 
            int height = base.Height - base.Margin.Top - base.Margin.Bottom; 
            Rectangle rec = new Rectangle(base.Margin.Left, base.Margin.Top, width, height); 
            GraphicsPath round = CreateRound(rec, mMatrixRound); 
             e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; 
             e.Graphics.FillPath((Brush)(new SolidBrush(mBack)), round); 
        } 

        protected override void OnResize(EventArgs eventargs) 
        { 
             base.Refresh(); 
        } 
    } 
}