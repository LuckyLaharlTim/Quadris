#pragma warning disable 1591
using System;

namespace Quadris {
  public enum CellState {
    EMPTY,
    OCCUPIED_PREVIOUSLY,
    OCCUPIED_ACTIVE_PIECE,
    COLLISION
  }

  public enum MoveDir {
    LEFT,
    RIGHT,
    DOWN
  }

  public class GridCellInfo {
    public PieceColor Color { get; set; }
    public CellState State { get; set; }

    public GridCellInfo() {
      Reset();
    }

    public void Reset() {
      Color = PieceColor.NONE;
      State = CellState.EMPTY;
    }

    public void SetToActivePiece(Piece activePiece) {
      State = CellState.OCCUPIED_ACTIVE_PIECE;
      Color = activePiece.Color;
    }
  }

  public class Board {
    public GridCellInfo[,] Grid { get; private set; }
    public Piece ActivePiece { get; set; }

    public int score = 0;
    public int rows_cleared = 0;
    public int LV = 0;
    public int cryo_stall = 3;
    public int lncounter = 0;

    public Board() {
      Grid = new GridCellInfo[24, 10];
      for (int i = 0; i < Grid.GetLength(0); i++) {
        for (int j = 0; j < Grid.GetLength(1); j++) {
          Grid[i, j] = new GridCellInfo();
        }
      }
    }

    /// <summary>
    /// This method updates the grid and moves the active piece down
    /// </summary>
    public void Update() {
      if (ActivePieceCanMove(MoveDir.DOWN)) {
        ActivePiece.MoveDown();
        RefreshGridWithActivePiece();
      }
      else {
        SettlePiece();
        CheckForLine();
      }
    }

    public void RefreshGridWithActivePiece() {
      for (int r = 0; r < Grid.GetLength(0); r++) {
        for (int c = 0; c < Grid.GetLength(1); c++) {
          GridCellInfo cellInfo = Grid[r, c];
          if (cellInfo.State == CellState.OCCUPIED_ACTIVE_PIECE) {
            cellInfo.Reset();
          }
        }
      }
      for (int r = 0; r < ActivePiece.Layout.GetLength(0); r++) {
        for (int c = 0; c < ActivePiece.Layout.GetLength(1); c++) {
          if (ActivePiece.Layout[r, c]) {
            GridCellInfo cellInfo = GetCellInfo(r + ActivePiece.GridRow, c + ActivePiece.GridCol);
            cellInfo?.SetToActivePiece(ActivePiece);
          }
        }
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="row">the row</param>
    /// <param name="col">the column</param>
    /// <returns>A GridCellInfo object</returns>
    public GridCellInfo GetCellInfo(int row, int col) {
      if (row < 0 || row >= Grid.GetLength(0) || col < 0 || col >= Grid.GetLength(1))
        return null;
      else
        return Grid[row, col];
    }

    public void MoveActivePieceLeft() {
      if (ActivePieceCanMove(MoveDir.LEFT)) {
        ActivePiece.MoveLeft();
        RefreshGridWithActivePiece();
      }
    }

    public void MoveActivePieceRight() {
      if (ActivePieceCanMove(MoveDir.RIGHT)) {
        ActivePiece.MoveRight();
        RefreshGridWithActivePiece();
      }
    }

    public void RotateActivePieceRight() {
      ActivePiece.RotateRight();
      if (CheckForOutOfBounds()) {
        ActivePiece.RotateLeft();
      }
    }

    public void RotateActivePieceLeft() {
      ActivePiece.RotateLeft();
      if (CheckForOutOfBounds()) {
        ActivePiece.RotateRight();
      }
    }

    public bool ActivePieceCanMove(MoveDir moveDir) {
      bool canMove = true;
      switch (moveDir) {
        case MoveDir.DOWN:
          for (int c = 0; c < ActivePiece.Layout.GetLength(1); c++) {
            int lastRow = -1;
            for (int r = 0; r < ActivePiece.Layout.GetLength(0); r++) {
              if (ActivePiece.Layout[r, c]) {
                lastRow = r;
              }
            }
            if (lastRow == -1) {
              continue;
            }
            GridCellInfo cellInfo = GetCellInfo(ActivePiece.GridRow + lastRow + 1, ActivePiece.GridCol + c);
            if (cellInfo == null || cellInfo.State == CellState.OCCUPIED_PREVIOUSLY) {
              canMove = false;
              break;
            }
          }
          break;

        case MoveDir.LEFT:
          for (int r = 0; r < ActivePiece.Layout.GetLength(0); r++) {
            int firstCol = -1;
            for (int c = 0; c < ActivePiece.Layout.GetLength(1); c++) {
              if (ActivePiece.Layout[r, c]) {
                firstCol = c;
                break;
              }
            }
            if (firstCol == -1) {
              continue;
            }
            GridCellInfo cellInfo = GetCellInfo(ActivePiece.GridRow + r, ActivePiece.GridCol + firstCol - 1);
            if (cellInfo == null || cellInfo.State == CellState.OCCUPIED_PREVIOUSLY) {
              canMove = false;
              break;
            }
          }
          break;

        case MoveDir.RIGHT:
          for (int r = 0; r < ActivePiece.Layout.GetLength(0); r++) {
            int lastCol = -1;
            for (int c = 0; c < ActivePiece.Layout.GetLength(1); c++) {
              if (ActivePiece.Layout[r, c]) {
                lastCol = c;
              }
            }
            if (lastCol == -1) {
              continue;
            }
            GridCellInfo cellInfo = GetCellInfo(ActivePiece.GridRow + r, ActivePiece.GridCol + lastCol + 1);
            if (cellInfo == null || cellInfo.State == CellState.OCCUPIED_PREVIOUSLY) {
              canMove = false;
              break;
            }
          }
          break;
      }
      return canMove;
    }

    private bool CheckForOutOfBounds() {
      for (int r = 0; r < ActivePiece.Layout.GetLength(0); r++) {
        for (int c = 0; c < ActivePiece.Layout.GetLength(1); c++) {
          if (ActivePiece.Layout[r, c]) {
            GridCellInfo cellInfo = GetCellInfo(r + ActivePiece.GridRow, c + ActivePiece.GridCol);
            if (cellInfo == null) {
              return true;
            }
          }
        }
      }
      return false;
    }

    public void SettlePiece() {
      for (int r = 0; r < Grid.GetLength(0); r++) {
        for (int c = 0; c < Grid.GetLength(1); c++) {
          GridCellInfo cellInfo = Grid[r, c];
          if (cellInfo.State == CellState.OCCUPIED_ACTIVE_PIECE) {
            cellInfo.State = CellState.OCCUPIED_PREVIOUSLY;
          }
        }
      }
      ActivePiece = Piece.GetRandPiece();
    }

    public void CheckForLine() {
      int cleared = 0;
      for (int curRow = 0; curRow < Grid.GetLength(0); curRow++) {
        bool allFilled = true;
        for (int col = 0; col < Grid.GetLength(1); col++) {
          if (GetCellInfo(curRow, col)?.State == CellState.EMPTY) {
            allFilled = false;
            break;
          }

        }
        if (allFilled) {
          cleared++;
          for (int col = 0; col < Grid.GetLength(1); col++) {
            for (int dropRow = curRow; dropRow > 0; dropRow--) {
              Grid[dropRow, col] = Grid[dropRow - 1, col];
            }
          }
          curRow--;
        }
      }
      rows_cleared += cleared;
      if (cleared > 0)
       {
        Scoreing(cleared);
       }
      CryoAdd(cleared);
    }

        private void CryoAdd(int cleared)
        {
            lncounter += cleared;
            if(lncounter >= 10)
            {
                cryo_stall++;
                lncounter = 0;
            } 
        }

        private void Scoreing(int cleared)
        {
            switch (cleared)
            {
                case 1:
                    score += 40 * (LV + 1);
                    break;
                case 2:
                    score += 100 * (LV + 1);
                    break;
                case 3:
                    score += 300 * (LV + 1);
                    break;
                default:
                    score += 1200 * (LV + 1);
                    break;

            }
        }

        public bool LevelUp()
        {
            if((LV + 1) * 10 < rows_cleared)
            {
                LV++;
                return true;
            }
            return false;
        }
    }
}
