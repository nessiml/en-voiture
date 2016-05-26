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
       // public static int Route.SIZE(100);
        public Route Route { get; set; }

        public RouteWidget(Route way)
        {
            Route = way;
        }
        public void Dessiner(Graphics g)
        {
            int Left = Route.Position.X * Route.SIZE;
            int Top = Route.Position.Y * Route.SIZE;
            int TailleX = Route.Taille.Width * Route.SIZE;
            int TailleY = Route.Taille.Height * Route.SIZE;

            g.FillRectangle(Brushes.YellowGreen, Left, Top,TailleX, TailleY);
            Pen BlackPen = new Pen(Color.Black, 20);
            Pen GreyPen = new Pen(Color.Gray, 5);
            Point point2 = new Point(Left + TailleY / 2, Top + TailleY / 2);
            Point point1;
            
            // Test des clés d'une route
            //          Test si la clé existe                            Test si la clé nord est à TRUE 
            if (Route.GetDictionaire.ContainsKey(Orientation.NORD) && Route.GetDictionaire[Orientation.NORD])
            {
                //Definit le centre de la route
                point1 = new Point(Left + TailleX / 2,Top);

                Point pointTrottoirDroite2 = new Point(point2.X, point2.Y);
                Point pointTrottoirDroite1 = new Point(point1.X,point1.Y);

                Point pointTrottoirGauche2 = new Point(point2.X, point2.Y);
                Point pointTrottoirGauche1 = new Point(point1.X, point1.Y);

                pointTrottoirDroite2.Offset(12, -10);
                pointTrottoirDroite1.Offset(12, 0);

                pointTrottoirGauche2.Offset(-12, -10);
                pointTrottoirGauche1.Offset(-12, 0);

                if (Route.GetDictionaire[Orientation.EST] == false)
                {
                    pointTrottoirDroite2.Offset(0, 10);
                }
                if (Route.GetDictionaire[Orientation.OUEST] == false)
                {
                    pointTrottoirGauche2.Offset(0, 10);
                }

                if (Route.GetDictionaire[Orientation.SUD] == false && Route.GetDictionaire[Orientation.EST] == false)
                {
                    g.FillEllipse(Brushes.Gray, point2.X - 10, point2.Y - 10, 25, 25);
                }

                if (Route.GetDictionaire[Orientation.SUD] == false && Route.GetDictionaire[Orientation.OUEST] == false)
                {
                    g.FillEllipse(Brushes.Gray, point2.X - 15, point2.Y - 10, 25, 25);
                }

                g.DrawLine(GreyPen, pointTrottoirDroite1, pointTrottoirDroite2);
                g.DrawLine(GreyPen, pointTrottoirGauche1, pointTrottoirGauche2);
                
                g.FillRectangle(Brushes.Black, point1.X - 10, point2.Y - 50, Route.LargeurNordSud, Route.HauteurNordSud);

            }
            if (Route.GetDictionaire.ContainsKey(Orientation.SUD) && Route.GetDictionaire[Orientation.SUD])
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

                if (Route.GetDictionaire[Orientation.EST] == false)
                {
                    pointTrottoirDroite2.Offset(0, -10);
                }
                if (Route.GetDictionaire[Orientation.OUEST] == false)
                {
                    pointTrottoirGauche2.Offset(0, -10);
                }

                if (Route.GetDictionaire[Orientation.NORD] == false && Route.GetDictionaire[Orientation.EST] == false)
                {
                    g.FillEllipse(Brushes.Gray, point2.X - 10, point2.Y -15, 25, 25);
                }

                if (Route.GetDictionaire[Orientation.NORD] == false && Route.GetDictionaire[Orientation.OUEST] == false)
                {
                    g.FillEllipse(Brushes.Gray, point2.X - 15, point2.Y - 15, 25, 25);
                }

                g.DrawLine(GreyPen, pointTrottoirDroite1, pointTrottoirDroite2);
                g.DrawLine(GreyPen, pointTrottoirGauche1, pointTrottoirGauche2);

                g.FillRectangle(Brushes.Black, point1.X - 10, point2.Y, Route.LargeurNordSud, Route.HauteurNordSud);
            }
            if (Route.GetDictionaire.ContainsKey(Orientation.EST) && Route.GetDictionaire[Orientation.EST])
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

                if (Route.GetDictionaire[Orientation.SUD] == false)
                {
                    pointTrottoirDroite2.Offset(-10, 0);
                }
                if (Route.GetDictionaire[Orientation.NORD] == false)
                {
                    pointTrottoirGauche2.Offset(-10, 0);
                }

                g.DrawLine(GreyPen, pointTrottoirDroite1, pointTrottoirDroite2);
                g.DrawLine(GreyPen, pointTrottoirGauche1, pointTrottoirGauche2);

                g.FillRectangle(Brushes.Black, point1.X - 50, point2.Y - 10, Route.LargeurEstOuest, Route.HauteurEstOuest);
            }
            if (Route.GetDictionaire.ContainsKey(Orientation.OUEST) && Route.GetDictionaire[Orientation.OUEST])
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

                if (Route.GetDictionaire[Orientation.SUD] == false)
                {
                    pointTrottoirDroite2.Offset(10, 0);
                }
                if (Route.GetDictionaire[Orientation.NORD] == false)
                {
                    pointTrottoirGauche2.Offset(10, 0);
                }

                g.DrawLine(GreyPen, pointTrottoirDroite1, pointTrottoirDroite2);
                g.DrawLine(GreyPen, pointTrottoirGauche1, pointTrottoirGauche2);

                g.FillRectangle(Brushes.Black, point1.X, point2.Y - 10, Route.LargeurEstOuest, Route.HauteurEstOuest);
            }

            g.FillEllipse(Brushes.Black, point2.X - 10, point2.Y - 10, 20, 20);
        }

        public void DessinerSurOrigine(Graphics g)
        {
            g.FillRectangle(Brushes.Black, new Rectangle(0, 0, 100, 100));
        }
    }
}
