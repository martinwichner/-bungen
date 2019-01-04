using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        private Game GameOfLife;

        const Int32 ScreenWidth = 640;
        const Int32 ScreenHeight = 480;

        public Form1()
        {
            InitializeComponent();
            this.SetClientSizeCore( ScreenWidth, ScreenHeight );
        }

        private void Form1_Load( object sender, EventArgs e )
        {
            GameOfLife = new Game( ScreenWidth, ScreenHeight );
            timerRender.Start();
        }
        
        private void timerRender_Tick( object sender, EventArgs e )
        {
            BufferedGraphicsContext context = BufferedGraphicsManager.Current;
            BufferedGraphics graphics = context.Allocate( this.CreateGraphics(), new Rectangle( 0, 0, ScreenWidth, ScreenHeight ) );

            GameOfLife.Render( graphics.Graphics );

            graphics.Render( this.CreateGraphics() );
            graphics.Dispose();
        }

        private void Form1_MouseDown( object sender, MouseEventArgs e )
        {
            GameOfLife.MouseDown( e.Button, e.X, e.Y );
        }

        private void Form1_MouseUp( object sender, MouseEventArgs e )
        {
            GameOfLife.MouseUp( e.Button, e.X, e.Y );
        }

        private void Form1_MouseMove( object sender, MouseEventArgs e )
        {
            GameOfLife.MouseMove( e.X, e.Y );
        }

        private void timerThink_Tick( object sender, EventArgs e )
        {
            GameOfLife.Think();
        }

        private void Form1_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ( e.KeyChar == ' ' )
                timerThink.Enabled = !timerThink.Enabled;
        }
    }
}
