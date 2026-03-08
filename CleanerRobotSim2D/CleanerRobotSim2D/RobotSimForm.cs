using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

namespace CleanerRobotSim2D;

public partial class RobotSimForm : Form
{

    private System.Windows.Forms.Timer _animationTimer;
    private PointF _robotPos = new PointF(50, 50); // current position
    private PointF _targetPos = new PointF(300, 200); // target position
    private float _speed = 0.05f; // interval [0, 1]
    private int _robotRadius = 20;

    public RobotSimForm()
    {
        InitializeComponent();
        this.DoubleBuffered = true; // reduce flickering
        this.Text = "Cleaner Robot";
        this.Size = new Size(600, 400);

        // Timer setup (approx. 33 FPS)
        _animationTimer = new System.Windows.Forms.Timer();
        _animationTimer.Interval = 30;
        _animationTimer.Tick += AnimationTimer_Tick;
        _animationTimer.Start();
    }


    private void AnimationTimer_Tick(object sender, EventArgs e)
    { 
        // Basic Linear Interpolation logic (LERP)
        // One step ahead to the target
        float netX = _robotPos.X + (_targetPos.X - _robotPos.X) * _speed;
        float netY = _robotPos.Y + (_targetPos.Y - _robotPos.Y) * _speed;

        _robotPos = new PointF(netX, netY);

        // refresh the form (calls OnPaint)
        this.Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        // Draw target point (red x)
        g.DrawLine(Pens.Red, _targetPos.X - 5, _targetPos.Y - 5, _targetPos.X + 5, _targetPos.Y + 5);
        g.DrawLine(Pens.Red, _targetPos.X + 5, _targetPos.Y - 5, _targetPos.X - 5, _targetPos.Y + 5);

        // Draw robot (blue circle)
        RectangleF robotRect = new RectangleF(
            _robotPos.X - _robotRadius,
            _robotPos.Y - _robotRadius,
            _robotRadius * 2,
            _robotRadius * 2);

        g.FillEllipse(Brushes.DodgerBlue, robotRect);
        g.DrawEllipse(Pens.Black, robotRect);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        _targetPos = new PointF(e.X, e.Y);
    }

}
