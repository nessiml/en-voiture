﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EnVoiture
{
    /// <summary>
    /// Classe principale du projet.
    /// </summary>
    public partial class EnVoitureForm : Form
    {
        // Liste des elements qui seront affichés
        private List<RoadUserWidget> _roadUsers = new List<RoadUserWidget>();
        private ToolsBox _toolBox;

        Car voiture;
        bool bAvancer = false, bReculer = false, bDroite = false, bGauche = false;
        bool bEditing = false;
        bool bCtrl = false;

        /// <summary>
        /// 
        /// </summary>
        private List<Way> Ways = new List<Way>();

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public EnVoitureForm()
        {
            InitializeComponent();
            List<WayWidget> ww = new List<WayWidget>();
            ww.Add(new WayWidget(new Way(50, 100, 100, 100, new List<Orientation>() { Orientation.NORTH })));
            this._toolBox = new ToolsBox(ww);
            this._roadUsers.Add(new CarWidget(0, 0, 10, 20, 80));
            this.voiture = (_roadUsers[0] as CarWidget).Car;
        }

        public Way CreateWay(int x, int y)
        {
            Way RouteBase = new Way(x, y, 100, 100, new List<Orientation>() { Orientation.NORTH });
            return RouteBase;
        }
        /// <summary>
        /// Est apellé beaucoup de fois par seconde 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnVoiture_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (bEditing)
            {
                // mode edition
                foreach (RoadUserWidget user in _roadUsers)
                {
                    if (!(user is CarWidget))
                        user.Paint(g);
                }

                foreach (WayWidget w in _toolBox.WayWidgets)
                {
                    w.Paint(g);
                }
            }
            else
            {
                foreach (RoadUserWidget user in _roadUsers)
                {
                    user.Paint(g);
                }
            }
        }

        private void EnVoitureForm_KeyDown(object sender, KeyEventArgs e)
        {
            

            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                bAvancer = true;
            }
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                bReculer = true;
            }

            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                bGauche = true;
            }

            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                bDroite = true;
            }

            if (e.KeyCode == Keys.ControlKey)
                bCtrl = true;
            if (bCtrl && e.KeyCode == Keys.E)
            {
                bCtrl = false;
                bEditing = !bEditing;
            }
        }

        private void EnVoitureForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                bAvancer = false;
            }
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                bReculer = false;
            }

            if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                bGauche = false;
            }

            if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                bDroite = false;
            }

            if (e.KeyCode == Keys.ControlKey)
                bCtrl = false;
        }

        private void timerDirection_Tick(object sender, System.EventArgs e)
        {
            if (bAvancer)
            {
                voiture.Avancer();
            }

            if (bReculer)
            {
                voiture.Reculer();
            }

            if (bGauche)
            {
                voiture.Gauche();
            }

            if (bDroite)
            {
                voiture.Droite();
            }
            Invalidate();
        }
    }
}
