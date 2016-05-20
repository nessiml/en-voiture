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
        public static int TAILLE = 100;
        public Route Route { get; set; }

        public RouteWidget(Route route)
        {
            Route = route;
        }
        public void Dessiner(Graphics g)
        {
            int Left = Route.Position.X * TAILLE;
            int Top = Route.Position.Y * TAILLE;
            int TailleX = Route.Taille.Width * TAILLE;
            int TailleY = Route.Taille.Height * TAILLE;

            g.FillRectangle(Brushes.YellowGreen, Left, Top,TailleX, TailleY);
            Pen BlackPen = new Pen(Color.Black, 20);
            Pen GreyPen = new Pen(Color.Gray, 5);
            Point point2 = new Point(Left + TailleY / 2, Top + TailleY / 2);
            Point point1;

            g.FillEllipse(Brushes.Black, point2.X - 10, point2.Y - 10, 20, 20);

            if (Route.GetDictionaire.ContainsKey(Orientation.NORTH) && Route.GetDictionaire[Orientation.NORTH])
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
                
                g.FillRectangle(Brushes.Black, point1.X - 10, point2.Y - 50, 20, 50);


            }
            if (Route.GetDictionaire.ContainsKey(Orientation.SOUTH) && Route.GetDictionaire[Orientation.SOUTH])
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

                g.FillRectangle(Brushes.Black, point1.X - 10, point2.Y, 20, 50);
            }
            if (Route.GetDictionaire.ContainsKey(Orientation.EAST) && Route.GetDictionaire[Orientation.EAST])
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

                g.FillRectangle(Brushes.Black, point1.X - 50, point2.Y - 10, 50, 20);
            }
            if (Route.GetDictionaire.ContainsKey(Orientation.WEST) && Route.GetDictionaire[Orientation.WEST])
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

                g.FillRectangle(Brushes.Black, point1.X, point2.Y - 10, 50, 20);
            }
        }

        public void DessinerSurOrigine(Graphics g)
        {
            g.FillRectangle(Brushes.Black, new Rectangle(0, 0, 100, 100));
        }
    }
}
