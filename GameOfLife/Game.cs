using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    class Game
    {
        private Rectangle ViewPort;
        private Int32 GridUnitSize = 8;
        private Int32 ScreenWidth;
        private Int32 ScreenHeight;
        private Boolean[,] Cells;
        private float ZoomFactor = 1.0f;

        public Game(Int32 viewWidth, Int32 viewHeight)
        {
            ViewPort.X = 0;
            ViewPort.Y = 0;
            ViewPort.Width = ScreenWidth = viewWidth;
            ViewPort.Height = ScreenHeight = viewHeight;

            InitCells();
        }

        private void InitCells()
        {
            Cells = new Boolean[ ScreenWidth / GridUnitSize, ScreenHeight / GridUnitSize ];
        }

        public void Render(Graphics screen)
        {
            screen.Clear( Color.White );
            RenderGrid( screen );
            RenderCells( screen );
        }

        private void RenderGrid( Graphics screen )
        {
            for ( Int32 x = ViewPort.X - 1; x + GridUnitSize <= ViewPort.Width; x += GridUnitSize )
                screen.DrawLine( Pens.Black, new Point( x, 0 ), new Point( x, ScreenHeight ) );

            for ( Int32 y = ViewPort.Y - 1; y + GridUnitSize <= ViewPort.Height; y += GridUnitSize )
                screen.DrawLine( Pens.Black, new Point( 0, y ), new Point( ScreenWidth, y ) );
        }

        private void RenderCells( Graphics screen )
        {
            for ( Int32 x = 0; x < Cells.GetLength( 0 ); x++ )
            {
                for ( Int32 y = 0; y < Cells.GetLength( 1 ); y++ )
                {
                    if ( Cells[ x, y ] )
                        screen.FillRectangle( Brushes.Black, new Rectangle( x * GridUnitSize, y * GridUnitSize, GridUnitSize, GridUnitSize ) );
                }
            }
        }

        public void Think()
        {
            Boolean[,] newCells = new Boolean[ ScreenWidth / GridUnitSize, ScreenHeight / GridUnitSize ];
            Array.Copy( Cells, newCells, ( ScreenWidth / GridUnitSize ) * ( ScreenHeight / GridUnitSize ) );
            for ( Int32 x = 0; x < Cells.GetLength( 0 ); x++ )
            {
                for ( Int32 y = 0; y < Cells.GetLength( 1 ); y++ )
                {
                    Int32 livingNeighbours = GetAliveNeighbours(x, y);
                    if ( !Cells[ x, y ] && livingNeighbours == 3 )
                        newCells[ x, y ] = true;

                    if ( Cells[ x, y ] && livingNeighbours < 2 )
                        newCells[ x, y ] = false;

                    if ( Cells[ x, y ] && livingNeighbours > 3 )
                        newCells[ x, y ] = false;
                }
            }

            Cells = newCells;
        }

        private Int32 GetAliveNeighbours( Int32 x, Int32 y )
        {
            Int32 livingNeighbours = 0;

            for( Int32 otherX = x - 1; otherX <= x + 1; otherX++ )
            {
                for( Int32 otherY = y - 1; otherY <= y + 1; otherY++ )
                {
                    if( otherX != x || otherY != y )
                    {
                        if ( HasLivingNeighbour( otherX, otherY ) )
                            livingNeighbours++;
                    }
                }
            }

            return livingNeighbours;
        }

        private Boolean HasLivingNeighbour( Int32 x, Int32 y )
        {
            if ( x >= 0 && y >= 0 && x < (ScreenWidth / GridUnitSize) && y < (ScreenHeight / GridUnitSize) )
            {
                return Cells[ x, y ];
            }

            return false;
        }

        public void MouseDown( MouseButtons button, Int32 x, Int32 y )
        {
            if ( button == MouseButtons.Left )
            {
                Int32 xpos = ( x - ( x % GridUnitSize ) );
                Int32 ypos = ( y - ( y % GridUnitSize ) );

                if ( xpos >= 0 && ypos >= 0 )
                    Cells[ xpos / GridUnitSize, ypos / GridUnitSize ] = true;
            }

            if ( button == MouseButtons.Right )
            {
                Int32 xpos = ( x - ( x % GridUnitSize ) );
                Int32 ypos = ( y - ( y % GridUnitSize ) );

                if ( xpos >= 0 && ypos >= 0 )
                    Cells[ xpos / GridUnitSize, ypos / GridUnitSize ] = false;
            }
        }

        public void MouseUp( MouseButtons button, Int32 x, Int32 y )
        {
        }

        public void MouseMove( Int32 x, Int32 y )
        {
        }

        public void ZoomIn()
        {
            ViewPort.X += GridUnitSize;
            ViewPort.Y += GridUnitSize;
            ViewPort.Width -= GridUnitSize * 2;
            ViewPort.Height -= GridUnitSize * 2;

            ZoomFactor *= 2.0f;
        }

        public void ZoomOut()
        {
            ViewPort.X -= GridUnitSize;
            ViewPort.Y -= GridUnitSize;
            ViewPort.Width += GridUnitSize * 2;
            ViewPort.Height += GridUnitSize * 2;

            ZoomFactor /= 2.0f;
        }
    }
}
