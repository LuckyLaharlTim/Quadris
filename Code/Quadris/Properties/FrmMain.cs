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
    
    // constants for size of next piece and held piece boards
    private const int MINIBOARD_COLS = 6;
    private const int MINIBOARD_ROWS = 6;

  
    private const int CELL_WIDTH = 20;
    private const int CELL_HEIGHT = 20;

    private Label[,] gridControls;
    private Label[,] gridControls2;
    private Label[,] gridControls3;
    private Board board;

    private SoundPlayer sndPlayer;

    public bool freeze = false;
    public bool Unfreeze = false;

    //[DllImport("user32.dll")]
    //public static extern short GetAsyncKeyState(int key);


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
      panel1.BackgroundImage = getImage(board.NextPiece.Type);
      //board.RefreshGridWithNextPiece();
      CreateGrid();
      sndPlayer = new SoundPlayer(Resources.Quadris_loop);
      sndPlayer.PlayLooping();
    }

    private Image getImage(PieceType title)
    {       

            Image image;
                switch (title)
                {
                    case PieceType.O:
                            image = Resources.O_block;
                            break;
                    case PieceType.L:
                            image = Resources.L_block;
                            break;
                    case PieceType.J:
                            image = Resources.J_block;
                            break;
                    case PieceType.I:
                            image = Resources.I_block;
                            break;
                    case PieceType.T:
                            image = Resources.T_block;
                            break;
                    case PieceType.S:
                            image = Resources.S_block;
                            break;
                    case PieceType.Z:
                            image = Resources.Z_block;
                            break;

                }
            return image;
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

      panel1.Width = CELL_WIDTH * MINIBOARD_COLS + 4;
      panel1.Height = CELL_HEIGHT * MINIBOARD_ROWS + 4;
      gridControls2 = new Label[MINIBOARD_ROWS, MINIBOARD_COLS];
      panel1.Controls.Clear();
      for (int col = 0; col < MINIBOARD_COLS; col++) {
        for (int row = 0; row < MINIBOARD_ROWS; row++) {
          Label lblCell = MakeGridCell(row, col);
          panel1.Controls.Add(lblCell);
          gridControls2[row, col] = lblCell;
        }
      }

      panel2.Width = CELL_WIDTH * MINIBOARD_COLS + 4;
      panel2.Height = CELL_HEIGHT * MINIBOARD_ROWS + 4;
      gridControls3 = new Label[MINIBOARD_ROWS, MINIBOARD_COLS];
      panel2.Controls.Clear();
      for (int col = 0; col < MINIBOARD_COLS; col++) {
        for (int row = 0; row < MINIBOARD_ROWS; row++) {
          Label lblCell = MakeGridCell(row, col);
          panel2.Controls.Add(lblCell);
          gridControls3[row, col] = lblCell;
        }
      }
    }

    private void UpdateGrids()
    {
            UpdateGrid();
            UpdateMiniGrid();
            UpdateHGrid();
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

    private void UpdateMiniGrid() {
      for (int col = 0; col < MINIBOARD_COLS; col++) {
        for (int row = 0; row < MINIBOARD_ROWS; row++) {
          GridCellInfo cellInfo = board.MiniGrid[row + 4, col];
          if (cellInfo.State == CellState.OCCUPIED_NEXT_PIECE || cellInfo.State == CellState.OCCUPIED_PREVIOUSLY) {
            gridControls2[row, col].Image = pieceColorToImgMap[cellInfo.Color];
          }
          else {
            gridControls2[row, col].Image = null;
          }
        }
      }

      //panel1.BackgroundImage = gridControls2.Image;
    }

    private void UpdateHGrid() {
      for (int col = 0; col < MINIBOARD_COLS; col++) {
        for (int row = 0; row < MINIBOARD_ROWS; row++) {
          GridCellInfo cellInfo = board.MiniGridH[row + 4, col];
          if (cellInfo.State == CellState.OCCUPIED_HELD_PIECE || cellInfo.State == CellState.OCCUPIED_PREVIOUSLY) {
            gridControls3[row, col].Image = pieceColorToImgMap[cellInfo.Color];
          }
          else {
            gridControls3[row, col].Image = null;
          }
        }
      }
      //found recommendations to set the panel's background image to an external one & tried to do so
      //panel2.BackgroundImage = gridControls3.Image;
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
    /// timer response for falling piece
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void tmrFps_Tick(object sender, EventArgs e) {
      board.Update();
      panel1.BackgroundImage = Image.FromFile($"{board.NextPiece.Type}-block");
      UpdateGrids();
      //if (board.CheckForEnd())
      //          tmrFps.Enabled = false;
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
        board.RefreshGridWithNextPiece();
        //board.RefreshGridWithHeldPiece();
        UpdateGrids();

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
        
        case Keys.S:
            if (board.HeldPiece != null)
                    { 
                        board.ReleasePiece();
                        panel2.BackgroundImage = getImage(board.HeldPiece.Type);
                    }
            else
                    {
                        board.HoldPiece();
                        panel2.BackgroundImage = getImage(board.HeldPiece.Type);
                        panel1.BackgroundImage = getImage(board.NextPiece.Type);
                    }
            break;
        /**/

        // this is for the soft drop
        case Keys.Down:
                 /*   
            while (e.KeyCode == Keys.Down)
                tmrFps.Interval = 400;           
            tmrFps.Interval = 200; 
                    /**/
            break;
        // code for down in 0x28

        // this is for the hard drop
        case Keys.Up:
                    board.HardDrop();
                    break;

            }
    }
        /*
        private void FrmMain_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                tmrFps.Interval /= 2;
        }
        /**/

    }
}
