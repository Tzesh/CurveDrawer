using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace _CurveDrawer
{
    public partial class CurveForm : Form
    {
        /// <summary>
        /// Curve of the form
        /// </summary>
        Curve curve = new Curve();

        /// <summary>
        /// Pens of the form
        /// </summary>
        IList<Color> colors = new List<Color>();

        /// <summary>
        /// Current X location of mouse in bounds of drawing panel
        /// </summary>
        int LocationX;

        /// <summary>
        /// Current Y location of mouse in bounds of drawing panel
        /// </summary>
        int LocationY;

        /// <summary>
        /// Default constructor of CurveForm
        /// </summary>
        public CurveForm()
        {
            InitializeComponent();

            // adding the predefined colors
            colors.Add(Color.Black);
            colors.Add(Color.Red);
            colors.Add(Color.Blue);

            LoadColors(cboxLineColor);
            LoadColors(cboxPointColor);
        }

        /// <summary>
        /// Method used to load predefined colors as items to given combobox
        /// </summary>
        /// <param name="cbox">target combobox</param>
        private void LoadColors(ComboBox cbox)
        {
            // adding all the colors into both colors list and combobox
            foreach (Color color in new ColorConverter().GetStandardValues())
            {
                if (!this.colors.Contains(color))
                    this.colors.Add(color);
            }

            // clearing items of the combobox
            cbox.Items.Clear();
            foreach (Color color in this.colors)
            {
                // adding colors as their names
                cbox.Items.Add(color.Name);
            }

            // selecting Black as 'default'
            cbox.SelectedIndex = 0;
        }

        /// <summary>
        /// Closes form when exit button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            // close the form and exit the application
            this.Close();
        }

        /// <summary>
        /// Event trigger used to get current X and Y coordinates of the mouse according to drawing panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlDrawing_MouseMove(object sender, MouseEventArgs e)
        {
            // get the present X and Y coordinates of mouse and present them via changing the text of LabelXY component
            this.LocationX = e.Location.X;
            this.LocationY = e.Location.Y;

            this.lblXY.Text = String.Format("X: {0} Y: {1}", LocationX, LocationY);
        }

        /// <summary>
        /// Event trigger used to get every kind of mouse-button events (left-click, right-click, etc.)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlDrawing_MouseDown(object sender, MouseEventArgs e)
        {
            // if left mouse button is clicked
            if (e.Button == MouseButtons.Left)
            {
                // we should check if this x point is already in use to create a literally curve
                int result = curve.AddPoint(new Point(LocationX, LocationY));
                if (result == 1) // if result is 1 that means that everything is OK
                {
                    this.lblProgress.Text = String.Format("Point ({0}, {1}) has been added to the curve", LocationX, LocationY); // notifying the user
                    PlotDrawingArea();
                }
                else if (result == -1) // if result is -1 that means that point is already in the curve
                {
                    curve.RemovePoint(new Point(LocationX, LocationY)); // then we should remove the point from the curve
                    this.lblProgress.Text = String.Format("Point ({0}, {1}) has been deleted from the curve", LocationX, LocationY); // notify the user
                    PlotDrawingArea();
                }
                else // if result is -2 that indices a point with the same x value is already in present
                {
                    this.lblProgress.Text = String.Format("You cannot define 2 points on the same x coordinate", LocationX, LocationY);
                }
            }
            // if right mouse button is clicked
            else if (e.Button == MouseButtons.Right)
            {
                Point deleted = curve.RemoveLastPoint(); // removing the last point
                if (deleted.x != -1 && deleted.y != -1) // if there any point has been deleted
                {
                    this.lblProgress.Text = String.Format("Point ({0}, {1}) has been deleted from the curve", deleted.x, deleted.y);
                    PlotDrawingArea();
                }
                else // when there is not any point to delete
                {
                    this.lblProgress.Text = "There's nothing left to delete from the curve";
                    PlotDrawingArea();
                }
            }
        }

        /// <summary>
        /// Method used for plotting the drawing area
        /// </summary>
        private void PlotDrawingArea()
        {
            DrawPoints(curve.GetPoints());
            DrawLines(curve.Sort());
        }

        /// <summary>
        /// Drawing lines into the drawing panel according to given sorted (with respect to x) points
        /// </summary>
        /// <param name="points"></param>
        private void DrawLines(IList<Point> points)
        {
            Color color = colors[cboxLineColor.SelectedIndex];
            if (points.Count < 1) return;
            using (Graphics g = pnlDrawing.CreateGraphics())
            {
                Pen pen = new Pen(color, 1);
                for (int i = 0; i < points.Count - 1; i++)
                {
                    if (i == points.Count - 1) continue;
                    g.DrawLine(pen, points[i].x, points[i].y, points[i + 1].x, points[i + 1].y);
                }
                pen.Dispose();
            }
        }

        /// <summary>
        /// Drawing given points into the drawing panel
        /// </summary>
        /// <param name="points"></param>
        private void DrawPoints(IList<Point> points)
        {
            if (points.Count < 1)
            {
                using (Graphics g = pnlDrawing.CreateGraphics())
                {
                    g.Clear(pnlDrawing.BackColor);
                }
                return;
            }
            Color color = colors[cboxPointColor.SelectedIndex];
            using (Graphics g = pnlDrawing.CreateGraphics())
            {
                g.Clear(pnlDrawing.BackColor); // clearing the drawing panel to prevent collusions
                Pen pen = new Pen(color, 3);
                foreach (Point p in points)
                {
                    // drawing rectangle which is used to denote the location of point
                    g.DrawRectangle(pen, p.x, p.y, 1, 1);
                }
                pen.Dispose();
            }
        }

        /// <summary>
        /// When 'calculate curve length' button clicked this method will be called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCurveLength_Click(object sender, EventArgs e)
        {
            double length = curve.CurveLength();
            MessageBox.Show("Length of the curve is: " + length, "Curve Drawer", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// When point color combobox selected index changes all the drawing panel will be redrawn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboxPointColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawPoints(curve.GetPoints());
            DrawLines(curve.Sort());
        }

        /// <summary>
        /// When line color combobox selected index changes all the drawing panel will be redrawn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboxLineColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawPoints(curve.GetPoints());
            DrawLines(curve.Sort());
        }

        /// <summary>
        /// When mouse leaves the drawing area x and y coordinates will be cleared
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlDrawing_MouseLeave(object sender, EventArgs e)
        {
            this.lblXY.Text = String.Format("X: Y:");
        }
    }
}
