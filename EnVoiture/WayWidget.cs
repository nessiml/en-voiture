using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnVoiture
{
    public class WayWidget
    {
        public static int SIZE = 100;
        public Way Way { get; set; }

        public WayWidget(Way way)
        {
            Way = way;
        }
        public void Paint(Graphics g)
        {
            int Left = Way.Location.X * SIZE;
            int Top = Way.Location.Y * SIZE;
            int TailleX = Way.Size.Width * SIZE;
            int TailleY = Way.Size.Height * SIZE;

            g.FillRectangle(Brushes.YellowGreen, Left, Top,TailleX, TailleY);
            Pen BlackPen = new Pen(Color.Black, 20);
            Pen GreyPen = new Pen(Color.Gray, 5);
            Point point2 = new Point(Left + TailleY / 2, Top + TailleY / 2);
            Point point1;

            g.FillEllipse(Brushes.Black, point2.X - 10, point2.Y - 10, 20, 20);

            if (Way.GetDictionaire.ContainsKey(Orientation.NORTH) && Way.GetDictionaire[Orientation.NORTH])
            {
                point1 = new Point(Left + TailleX / 2,Top);

                Point pointTrottoirDroite2 = new Point(point2.X, point2.Y);
                Point pointTrottoirDroite1 = new Point(point1.X,point1.Y);
                
                pointTrottoirDroite2.Offset(12, -10);
                pointTrottoirDroite1.Offset(12, 0);

                Point pointTrottoirGauche2 = new Point(point2.X, point2.Y);
                Point pointTrottoirGauche1 = new Point(point1.X, point1.Y);

                pointTrottoirGauche2.Offset(-12, -10);
                pointTrottoirGauche1.Offset(-12, 0);
                

                g.DrawLine(GreyPen, pointTrottoirDroite1, pointTrottoirDroite2);
                g.DrawLine(GreyPen, pointTrottoirGauche1, pointTrottoirGauche2);
                
                g.DrawLine(BlackPen, point1, point2);

            }
            if (Way.GetDictionaire.ContainsKey(Orientation.SOUTH) && Way.GetDictionaire[Orientation.SOUTH])
            {
                point1 = new Point(Left + TailleX / 2, Top + TailleY);

                Point pointTrottoirDroite2 = new Point(point2.X, point2.Y);
                Point pointTrottoirDroite1 = new Point(point1.X, point1.Y);

                pointTrottoirDroite2.Offset(12, 10);
                pointTrottoirDroite1.Offset(12, 0);

                Point pointTrottoirGauche2 = new Point(point2.X, point2.Y);
                Point pointTrottoirGauche1 = new Point(point1.X, point1.Y);

                pointTrottoirGauche2.Offset(-12, 10);
                pointTrottoirGauche1.Offset(-12, 0);


                g.DrawLine(GreyPen, pointTrottoirDroite1, pointTrottoirDroite2);
                g.DrawLine(GreyPen, pointTrottoirGauche1, pointTrottoirGauche2);

                g.DrawLine(BlackPen, point1, point2);
            }
            if (Way.GetDictionaire.ContainsKey(Orientation.EAST) && Way.GetDictionaire[Orientation.EAST])
            {
                point1 = new Point(Left + TailleX, Top + TailleY / 2);

                Point pointTrottoirDroite2 = new Point(point2.X, point2.Y);
                Point pointTrottoirDroite1 = new Point(point1.X, point1.Y);

                pointTrottoirDroite2.Offset(10, 12);
                pointTrottoirDroite1.Offset(0, 12);

                Point pointTrottoirGauche2 = new Point(point2.X, point2.Y);
                Point pointTrottoirGauche1 = new Point(point1.X, point1.Y);

                pointTrottoirGauche2.Offset(10, -12);
                pointTrottoirGauche1.Offset(0, -12);


                g.DrawLine(GreyPen, pointTrottoirDroite1, pointTrottoirDroite2);
                g.DrawLine(GreyPen, pointTrottoirGauche1, pointTrottoirGauche2);

                g.DrawLine(BlackPen, point1, point2);
            }
            if (Way.GetDictionaire.ContainsKey(Orientation.WEST) && Way.GetDictionaire[Orientation.WEST])
            {
                point1 = new Point(Left, Top + TailleY / 2);

                Point pointTrottoirDroite2 = new Point(point2.X, point2.Y);
                Point pointTrottoirDroite1 = new Point(point1.X, point1.Y);

                pointTrottoirDroite2.Offset(-10, 12);
                pointTrottoirDroite1.Offset(0, 12);

                Point pointTrottoirGauche2 = new Point(point2.X, point2.Y);
                Point pointTrottoirGauche1 = new Point(point1.X, point1.Y);

                pointTrottoirGauche2.Offset(-10, -12);
                pointTrottoirGauche1.Offset(0, -12);


                g.DrawLine(GreyPen, pointTrottoirDroite1, pointTrottoirDroite2);
                g.DrawLine(GreyPen, pointTrottoirGauche1, pointTrottoirGauche2);

                g.DrawLine(BlackPen, point1, point2);
            }
        }

        public void PaintOnOrigin(Graphics g)
        {
            g.FillRectangle(Brushes.Black, new Rectangle(0, 0, 100, 100));
        }
    }
}
