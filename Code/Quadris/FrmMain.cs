# pragma warning disable 1591
using Quadris.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using System.Threading;

namespace Quadris {
  public partial class FrmMain : Form {
    private const int BOARD_COLS = 10;
    private const int BOARD_ROWS = 20;

    private const int CELL_WIDTH = 20;
    private const int CELL_HEIGHT = 20;

    private Label[,] gridControls;
    private Board board;

    private SoundPlayer sndPlayer;

    public bool freeze = false;
    public bool Unfreeze = false;


        private static readonly Dictionary<PieceColor, Image> pieceColorToImgMap = new Dictionary<PieceColor, Image> {
      {PieceColor.BLUE, Resources.cell_blue},
      {PieceColor.CYAN, Resources.cell_cyan},
      {PieceColor.GREEN, Resources.cell_green},
      {PieceColor.MAGENTA, Resources.cell_magenta},
      {PieceColor.ORANGE, Resources.cell_orange},
      {PieceColor.PURPLE, Resources.cell_purple},
      {PieceColor.RED, Resources.cell_red},
      {PieceColor.WHITE, Resources.cell_white},
      {PieceColor.YELLOW, Resources.cell_yellow},
      {PieceColor.FIRE, Resources.cell_fire},
      {PieceColor.ICE, Resources.cell_ice},
      {PieceColor.GROUND, Resources.cell_ground},
      {PieceColor.DARK, Resources.cell_dark},
    };


    public FrmMain() {
      InitializeComponent();
    }

    private void FrmMain_Load(object sender, EventArgs e) {
      board = new Board();
      Piece piece = Piece.GetRandPiece();
      board.ActivePiece = piece;
      Piece piece2 = Piece.GetRandPiece();
      board.NextPiece = piece2;
      CreateGrid();
      sndPlayer = new SoundPlayer(Resources.bg_music);
      //sndPlayer.PlayLooping();
    }

    private void CreateGrid() {
      panBoard.Width = CELL_WIDTH * BOARD_COLS + 4;
      panBoard.Height = CELL_HEIGHT * BOARD_ROWS + 4;
      gridControls = new Label[BOARD_ROWS, BOARD_COLS];
      panBoard.Controls.Clear();
      for (int col = 0; col < BOARD_COLS; col++) {
        for (int row = 0; row < BOARD_ROWS; row++) {
          Label lblCell = MakeGridCell(row, col);
          panBoard.Controls.Add(lblCell);
          gridControls[row, col] = lblCell;
        }
      }
    }

    private void UpdateGrid() {
      for (int col = 0; col < BOARD_COLS; col++) {
        for (int row = 0; row < BOARD_ROWS; row++) {
          GridCellInfo cellInfo = board.Grid[row + 4, col];
          if (cellInfo.State == CellState.OCCUPIED_ACTIVE_PIECE || cellInfo.State == CellState.OCCUPIED_PREVIOUSLY) {
            gridControls[row, col].Image = pieceColorToImgMap[cellInfo.Color];
          }
          else {
            gridControls[row, col].Image = null;
          }
        }
      }
    }

    private Label MakeGridCell(int row, int col) {
      return new Label() {
        Text = "",
        Width = CELL_WIDTH,
        Height = CELL_HEIGHT,
        FlatStyle = FlatStyle.Flat,
        Top = row * CELL_HEIGHT,
        Left = col * CELL_WIDTH
      };
    }
    /// <summary>
    /// timer responce for falling peace
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void tmrFps_Tick(object sender, EventArgs e) {
      board.Update();
      UpdateGrid();
    }

        /// <summary>
        /// timer for over all game. refreshes board, advances level, displays game info.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
   DateTime time;
   bool flock = true;
   private void BoardRF_Tick(object sender, EventArgs e)
    {
        board.RefreshGridWithActivePiece();
        UpdateGrid();

            // Main driver for the CryoStall
            if (freeze && flock)
            {
                flock = false;
                freeze = false;
                time = DateTime.Now;
                tmrFps.Interval *= 2;
                Unfreeze = true;

                // Visual feed back
                panBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(255)))));
                Console.WriteLine($"froze : {tmrFps.Interval}");
            }
            else if (!freeze && DateTime.Now - time >= new TimeSpan(200000000) && Unfreeze)
            {
                tmrFps.Interval /= 2;
                flock = true;
                Unfreeze = false;
                panBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
                Console.WriteLine($"unfroze : {tmrFps.Interval}");
            }

            // check for level up, if so speed up game
            if (board.LevelUp())
            {
                if (tmrFps.Interval - 10 > 10)
                {
                    if (freeze)
                    {
                        tmrFps.Interval -= 5;
                    }
                    else
                    {
                        tmrFps.Interval -= 10;
                    }
                    
                }
                else if (tmrFps.Interval - 10 <= 0)
                {
                    if (freeze)
                    {
                        tmrFps.Interval = 2;
                    }
                    else
                    {
                        tmrFps.Interval = 1;
                    }
                }
               }


        // display info
        labelscore.Text = $"{board.score}";
        labellines.Text = $"{board.rows_cleared}";
        labellevel.Text = $"{board.LV}";
        CryoStall_disp.Text = $"{board.cryo_stall}";
    }


        private void FrmMain_KeyDown(object sender, KeyEventArgs e) {
      switch (e.KeyCode) {
        case Keys.X:
          board.RotateActivePieceRight();
          break;
        case Keys.Z:
          board.RotateActivePieceLeft();
          break;
        case Keys.Right:
          board.MoveActivePieceRight();
          break;
        case Keys.Left:
          board.MoveActivePieceLeft();
          break;

        // this is for testing higher levels
        case Keys.L:
           board.LV++;
                    if (tmrFps.Interval - 10 > 10)
                    {
                        tmrFps.Interval -= 10;
                    }
                    else if (tmrFps.Interval - 10 <= 0)
                    {
                        tmrFps.Interval = 1;
                    }
           break;

        // Activate CryoStall
        case Keys.Space:
                    if(board.cryo_stall > 0 && flock)
                    {
                        freeze = true;
                        board.cryo_stall--;
                    }
           break;

        // this is for holding a piece
        /*
        case Keys.H:
            if (board.HeldPiece != null)
                        board.ReleasePiece;
            else
                        board.HoldPiece;
        /**/

        // this is for the soft drop
        case Keys.Down:
            //board.SoftDrop();
            break;

        // this is for the hard drop
        case Keys.Up:
                    //board.HardDrop();
                    break;

            }
    }


    }
}
