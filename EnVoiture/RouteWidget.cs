using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnVoiture
{
    public class RouteWidget
    {
        public static int SIZE = 100;
        public Route Route { get; set; }

        public RouteWidget(Route way)
        {
            Route = way;
        }
        public void Dessiner(Graphics g)
        {
            int Left = Route.Position.X * SIZE;
            int Top = Route.Position.Y * SIZE;
            int TailleX = Route.Taille.Width * SIZE;
            int TailleY = Route.Taille.Height * SIZE;

            g.FillRectangle(Brushes.YellowGreen, Left, Top,TailleX, TailleY);
            Pen BlackPen = new Pen(Color.Black, 20);
            Pen GreyPen = new Pen(Color.Gray, 5);
            Point point2 = new Point(Left + TailleY / 2, Top + TailleY / 2);
            Point point1;

            if (Route.GetDictionaire.ContainsKey(Orientation.NORTH) && Route.GetDictionaire[Orientation.NORTH])
            {
                point1 = new Point(Left + TailleX / 2,Top);

                Point pointTrottoirDroite2 = new Point(point2.X, point2.Y);
                Point pointTrottoirDroite1 = new Point(point1.X,point1.Y);

                Point pointTrottoirGauche2 = new Point(point2.X, point2.Y);
                Point pointTrottoirGauche1 = new Point(point1.X, point1.Y);

                pointTrottoirDroite2.Offset(12, -10);
                pointTrottoirDroite1.Offset(12, 0);

                pointTrottoirGauche2.Offset(-12, -10);
                pointTrottoirGauche1.Offset(-12, 0);

                if (Route.GetDictionaire[Orientation.EAST] == false)
                {
                    pointTrottoirDroite2.Offset(0, 10);
                }
                if (Route.GetDictionaire[Orientation.WEST] == false)
                {
                    pointTrottoirGauche2.Offset(0, 10);
                }

                if (Route.GetDictionaire[Orientation.SOUTH] == false && Route.GetDictionaire[Orientation.EAST] == false)
                {
                    g.FillEllipse(Brushes.Gray, point2.X - 10, point2.Y - 10, 25, 25);
                }

                if (Route.GetDictionaire[Orientation.SOUTH] == false && Route.GetDictionaire[Orientation.WEST] == false)
                {
                    g.FillEllipse(Brushes.Gray, point2.X - 15, point2.Y - 10, 25, 25);
                }

                g.DrawLine(GreyPen, pointTrottoirDroite1, pointTrottoirDroite2);
                g.DrawLine(GreyPen, pointTrottoirGauche1, pointTrottoirGauche2);
                
                g.DrawLine(BlackPen, point1, point2);

            }
            if (Route.GetDictionaire.ContainsKey(Orientation.SOUTH) && Route.GetDictionaire[Orientation.SOUTH])
            {
                point1 = new Point(Left + TailleX / 2, Top + TailleY);

                Point pointTrottoirDroite2 = new Point(point2.X, point2.Y);
                Point pointTrottoirDroite1 = new Point(point1.X, point1.Y);


                Point pointTrottoirGauche2 = new Point(point2.X, point2.Y);
                Point pointTrottoirGauche1 = new Point(point1.X, point1.Y);

                pointTrottoirDroite2.Offset(12, 10);
                pointTrottoirDroite1.Offset(12, 0);

                pointTrottoirGauche2.Offset(-12, 10);
                pointTrottoirGauche1.Offset(-12, 0);

                if (Route.GetDictionaire[Orientation.EAST] == false)
                {
                    pointTrottoirDroite2.Offset(0, -10);
                }
                if (Route.GetDictionaire[Orientation.WEST] == false)
                {
                    pointTrottoirGauche2.Offset(0, -10);
                }

                if (Route.GetDictionaire[Orientation.NORTH] == false && Route.GetDictionaire[Orientation.EAST] == false)
                {
                    g.FillEllipse(Brushes.Gray, point2.X - 10, point2.Y -15, 25, 25);
                }

                if (Route.GetDictionaire[Orientation.NORTH] == false && Route.GetDictionaire[Orientation.WEST] == false)
                {
                    g.FillEllipse(Brushes.Gray, point2.X - 15, point2.Y - 15, 25, 25);
                }

                g.DrawLine(GreyPen, pointTrottoirDroite1, pointTrottoirDroite2);
                g.DrawLine(GreyPen, pointTrottoirGauche1, pointTrottoirGauche2);

                g.DrawLine(BlackPen, point1, point2);
            }
            if (Route.GetDictionaire.ContainsKey(Orientation.EAST) && Route.GetDictionaire[Orientation.EAST])
            {
                point1 = new Point(Left + TailleX, Top + TailleY / 2);

                Point pointTrottoirDroite2 = new Point(point2.X, point2.Y);
                Point pointTrottoirDroite1 = new Point(point1.X, point1.Y);


                Point pointTrottoirGauche2 = new Point(point2.X, point2.Y);
                Point pointTrottoirGauche1 = new Point(point1.X, point1.Y);

                pointTrottoirDroite2.Offset(10, 12);
                pointTrottoirDroite1.Offset(0, 12);

                pointTrottoirGauche2.Offset(10, -12);
                pointTrottoirGauche1.Offset(0, -12);

                if (Route.GetDictionaire[Orientation.SOUTH] == false)
                {
                    pointTrottoirDroite2.Offset(-10, 0);
                }
                if (Route.GetDictionaire[Orientation.NORTH] == false)
                {
                    pointTrottoirGauche2.Offset(-10, 0);
                }

                g.DrawLine(GreyPen, pointTrottoirDroite1, pointTrottoirDroite2);
                g.DrawLine(GreyPen, pointTrottoirGauche1, pointTrottoirGauche2);

                g.DrawLine(BlackPen, point1, point2);
            }
            if (Route.GetDictionaire.ContainsKey(Orientation.WEST) && Route.GetDictionaire[Orientation.WEST])
            {
                point1 = new Point(Left, Top + TailleY / 2);

                Point pointTrottoirDroite2 = new Point(point2.X, point2.Y);
                Point pointTrottoirDroite1 = new Point(point1.X, point1.Y);


                Point pointTrottoirGauche2 = new Point(point2.X, point2.Y);
                Point pointTrottoirGauche1 = new Point(point1.X, point1.Y);

                pointTrottoirDroite2.Offset(-10, 12);
                pointTrottoirDroite1.Offset(0, 12);

                pointTrottoirGauche2.Offset(-10, -12);
                pointTrottoirGauche1.Offset(0, -12);

                if (Route.GetDictionaire[Orientation.SOUTH] == false)
                {
                    pointTrottoirDroite2.Offset(10, 0);
                }
                if (Route.GetDictionaire[Orientation.NORTH] == false)
                {
                    pointTrottoirGauche2.Offset(10, 0);
                }

                g.DrawLine(GreyPen, pointTrottoirDroite1, pointTrottoirDroite2);
                g.DrawLine(GreyPen, pointTrottoirGauche1, pointTrottoirGauche2);

                g.DrawLine(BlackPen, point1, point2);
            }

            g.FillEllipse(Brushes.Black, point2.X - 10, point2.Y - 10, 20, 20);
        }

        public void DessinerSurOrigine(Graphics g)
        {
            g.FillRectangle(Brushes.Black, new Rectangle(0, 0, 100, 100));
        }
    }
}
