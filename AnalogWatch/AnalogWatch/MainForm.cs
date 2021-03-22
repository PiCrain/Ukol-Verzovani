/*
 * Created by SharpDevelop.
 * User: Miško
 * Date: 21.10.2020
 * Time: 22:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AnalogWatch
{
	
	public partial class MainForm : Form
	{
		public Point middlePoint = new Point(100, 100);
		public MainForm()
		{	
			
			InitializeComponent();
			timer1.Start();
			
		}
		
		public Point CalculateEndpoint(double angle, int prepona)
		{
			double angleRadians = angle * (Math.PI/180);
			double deltaX = Math.Cos(angleRadians) * prepona;
			double deltaY = Math.Sin(angleRadians) * prepona;
			
			int X = (int)Math.Round(middlePoint.X + deltaX);
			int Y = (int)Math.Round(middlePoint.Y + deltaY);

			return new Point(X, Y);
		}

		public void DrawHands()
        {
			var g = pictureBox1.CreateGraphics();
			Brush b = new SolidBrush(Color.Green);

			//Ručičky 1min=6 stupnů, 1s= 6 stupnu , 1h=30 stupnu;
			g.DrawLine(new Pen(Color.Red,2), middlePoint, CalculateEndpoint((DateTime.Now.Second-15) * 6, 70)); //vteřinová
			g.DrawLine(new Pen(Color.Gold,4), middlePoint, CalculateEndpoint((DateTime.Now.Minute-15) * 6, 70)); //minutová
			g.DrawLine(new Pen(Color.Gold,4), middlePoint, CalculateEndpoint((DateTime.Now.Hour-15) *30, 50)); //hodinová


		}

        private void timer1_Tick(object sender, EventArgs e)
        {

			pictureBox1.Refresh();
			DrawWatches();
			DrawHands();
			
		}
		public void DrawWatches()
        {
			Font drawfont =new Font ("Comic Sans",10);
			Font hlavni = new Font("Comic Sans",12,FontStyle.Bold);
			var g = pictureBox1.CreateGraphics();
			SolidBrush b = new SolidBrush (Color.Aqua);

			//vykresleni ciferníku
			g.DrawString("12", hlavni,b, 90F, 5F);
			g.DrawString("6", hlavni, b, 95F, 175F);
			g.DrawString("3", hlavni, b, 175F, 90F);
			g.DrawString("9", hlavni, b, 12F, 90F);
			g.DrawString("1", drawfont, b, 140F, 17F);
			g.DrawString("2", drawfont, b, 170F, 50F);
			g.DrawString("4", drawfont, b, 166F, 135F);
			g.DrawString("5", drawfont, b, 139F, 162F);
			g.DrawString("7", drawfont, b, 49F, 160F);
			g.DrawString("8", drawfont, b, 17F, 135F);
			g.DrawString("10", drawfont, b, 19F, 50F);
			g.DrawString("11", drawfont, b, 50F, 17F);
			
			date.Text= DateTime.Now.ToString("dd.MM.yyyy");
			Day.Text= DateTime.Now.ToString("D");
		}

    }
}
