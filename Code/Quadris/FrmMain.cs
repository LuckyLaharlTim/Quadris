using Quadris.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Quadris {
  public partial class FrmMain : Form {
    private const int BOARD_COLS = 10;
    private const int BOARD_ROWS = 20;

    private const int CELL_WIDTH = 20;
    private const int CELL_HEIGHT = 20;

    private Label[,] gridControls;
    private Board board;

    private SoundPlayer sndPlayer;

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
      CreateGrid();
      sndPlayer = new SoundPlayer(Resources.bg_music);
      sndPlayer.PlayLooping();
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

    private void tmrFps_Tick(object sender, EventArgs e) {
      board.Update();
      UpdateGrid();
    }

    private void BoardRF_Tick(object sender, EventArgs e)
    {
        board.RefreshGridWithActivePiece();
        UpdateGrid();
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
            }
    }
  }
}
