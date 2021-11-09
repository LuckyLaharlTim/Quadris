#pragma warning disable 1591
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Quadris {
  public enum CellState {
    EMPTY,
    OCCUPIED_PREVIOUSLY,
    OCCUPIED_NEXT_PIECE,
    OCCUPIED_ACTIVE_PIECE,
    OCCUPIED_HELD_PIECE,
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

    public void SetToNextPiece(Piece nextPiece) {
      State = CellState.OCCUPIED_NEXT_PIECE;
      Color = nextPiece.Color;
    }

    public void SetToHeldPiece(Piece heldPiece) {
      State = CellState.OCCUPIED_HELD_PIECE;
      Color = heldPiece.Color;
    }
  }

  public class Board {
    public GridCellInfo[,] Grid { get; private set; }
    public Piece ActivePiece { get; set; }
    public Piece NextPiece { get; set; }
    public Piece HeldPiece { get; set; }

    public int score = 0;
    public int rows_cleared = 0;
    public int LV = 0;
    public static int[] PieceArr;
    public static List<int> gBag;
    public int cryo_stall = 3;
    public int lncounter = 0;

    public Board() {
      Grid = new GridCellInfo[24, 10];
      for (int i = 0; i < Grid.GetLength(0); i++) {
        for (int j = 0; j < Grid.GetLength(1); j++) {
          Grid[i, j] = new GridCellInfo();
        }
      }
      /*
      PieceArr = new PieceType[7];
            foreach (int let in Enum.GetValues(typeof(PieceType)))
            {
                PieceArr[let] = (PieceType)let;
            }
      /**/
        PieceArr = new int[] {0,1,2,3,4,5,6};
        gBag = PieceArr.ToList();
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
    // for every cell in the grid . . .
      for (int r = 0; r < Grid.GetLength(0); r++) {
        for (int c = 0; c < Grid.GetLength(1); c++) {
        // the value of the cell's row and column is saved
          GridCellInfo cellInfo = Grid[r, c];
          // if the current cell is the active piece, change it back to empty (visually and by state)
          if (cellInfo.State == CellState.OCCUPIED_ACTIVE_PIECE) {
            cellInfo.Reset();
          }
        }
      }
      // then recreate the active piece so many cells in the relevant direction
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

    public void SoftDrop()
    {
            
    }

    public void HardDrop()
    {

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
      ActivePiece = NextPiece;
      NextPiece = Piece.GetRandPiece();
    }

    public void HoldPiece() {
      for (int r = 0; r < Grid.GetLength(0); r++) {
        for (int c = 0; c < Grid.GetLength(1); c++) {
          GridCellInfo cellInfo = Grid[r, c];
          if (cellInfo.State == CellState.OCCUPIED_ACTIVE_PIECE) {
            cellInfo.State = CellState.EMPTY;
          }
        }
      }
      //also check for changing held & nextPiece grid appropriately

      ActivePiece = NextPiece;
      NextPiece = Piece.GetRandPiece();
    }

    public void ReleasePiece() {
      for (int r = 0; r < Grid.GetLength(0); r++) {
        for (int c = 0; c < Grid.GetLength(1); c++) {
          GridCellInfo cellInfo = Grid[r, c];
          if (cellInfo.State == CellState.OCCUPIED_ACTIVE_PIECE) {
            cellInfo.State = CellState.EMPTY;
          }
        }
      }
      //also check for changing heldPiece grid appropriately

      Piece interPiece = ActivePiece;
      ActivePiece = HeldPiece;
      HeldPiece = interPiece;
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
      // tracks number of rows cleared
      rows_cleared += cleared;

      // starts scoreing
      if (cleared > 0)
       {
        Scoring(cleared);
       }

      // checks to add a use of CryoStall
      CryoAdd(cleared);
    }
        /// <summary>
        /// the function to add a use of CryoStall
        /// </summary>
        /// <param name="cleared"></param>
        private void CryoAdd(int cleared)
        {
            lncounter += cleared;
            if(lncounter >= 10)
            {
                cryo_stall++;
                lncounter = 0;
            } 
        }

        /// <summary>
        /// function used to add points to the score
        /// </summary>
        /// <param name="cleared"></param>
        private void Scoring(int cleared)
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

        /// <summary>
        /// function to level up the game
        /// </summary>
        /// <returns></returns>
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
