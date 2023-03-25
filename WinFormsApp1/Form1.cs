using System.Drawing;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private bool DesenharGráfico = false;
        private List<Point> points = new List<Point>();
        private List<PointF> points_circles = new List<PointF>();
        public Form1()
        {
            InitializeComponent();
        }
        

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "")
                return;
            DesenharGráfico = true;
            this.Refresh();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            DesenharGráfico = false;
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            DesenharGráfico = false;
        }

        private void Form1_Resize_1(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            float radius = 5.0F;
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            int xOrigem = this.ClientRectangle.Width / 2;
            int yOrigem = this.ClientRectangle.Height / 2;
            points.Add(new Point(xOrigem, yOrigem));
            g.DrawLine(Pens.Black, new Point(xOrigem, 0), new Point(xOrigem, this.Bottom));
            g.DrawLine(Pens.Black, new Point(0, yOrigem), new Point(this.Right, yOrigem));
            g.FillEllipse(Brushes.Black, new Rectangle(new Point(xOrigem - 2, yOrigem - 2), new Size(4, 4)));

            if (DesenharGráfico == true)
            {
                int x = int.Parse(textBox1.Text);
                int y = int.Parse(textBox2.Text);

                Point point1 = new Point(xOrigem + x, yOrigem - y);
                //PointF point2 = new PointF(xOrigem + ((float)x-rad), yOrigem - ((float)(y-rad)));
                points.Add(point1);
                //points_circles.Add(point2);

                Point[] points1 = points.Distinct().ToArray();
                //PointF[] points2 = points_circles.Distinct().ToArray();

                PointF center = new PointF((float)50, (float)50);
                float xc = (float)xOrigem + (center.X - radius);
                float yc = (float)yOrigem - (center.Y + radius);
                Console.WriteLine("cerchio_x:" + xc);
                Console.WriteLine("cerchio_y:" + yc);
                Console.WriteLine("punto_x:" + point1.X);
                Console.WriteLine("punto_y:" + point1.Y);
                float width = 2 * radius;
                float height = 2 * radius;

                SolidBrush redBrush = new SolidBrush(Color.Red);

                for (int i = 1; i < points1.Length; i++)
                {

                    g.DrawLine(Pens.Red, points1[i], points1[i - 1]);
                    g.FillEllipse(redBrush, xc, yc, width, height);


                }
            }
        }
    }
}


