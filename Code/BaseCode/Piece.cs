# pragma warning disable 1591
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace Quadris {
  public enum PieceType {
    L,
    J,
    Z,
    S,
    I,
    T,
    O,
  }

  public enum PieceColor {
    NONE,
    BLUE,
    RED,
    WHITE,
    CYAN,
    GREEN,
    MAGENTA,
    ORANGE,
    PURPLE,
    YELLOW,
    FIRE,
    ICE,
    GROUND,
    DARK
  }

  public class Piece {
    private const int LAYOUT_ROWS = 4;
    private const int LAYOUT_COLS = 4;

    private static readonly Random rand;
    

    public bool[,] Layout { get; private set; }
    public int GridRow { get; set; }
    public int GridCol { get; set; }
    public PieceType Type { get; private set; }
    public PieceColor Color { get; private set; }

    static Piece() 
    {
            rand = new Random();
            
    }

    public Piece(string strLayout, PieceColor color, PieceType type) 
    {
            GridRow = 0;
            GridCol = 3;
            Color = color;
            Type = type;
            
            Layout = new bool[LAYOUT_ROWS, LAYOUT_COLS];
            for (int c = 0; c < LAYOUT_COLS; c++) 
            {
                for (int r = 0; r < LAYOUT_ROWS; r++) 
                {
                    Layout[r, c] = (strLayout[r * LAYOUT_COLS + c] == '1');

                }
            }
        }

    public static Piece GetRandPiece() {
      int pieceNum = rand.Next(7);//Enum.GetValues(typeof(PieceType)).Length);
      if (GrabBag(pieceNum))
                return MakePiece((PieceType)pieceNum);
      else
                return GetRandPiece();
      //Piece newPiece = MakePiece((PieceType)pieceNum);
      //return MakePiece((PieceType)pieceNum);
        /*if (GrabBag(newPiece))
                return newPiece;
        else
                return GetRandPiece();
        */
        //return MakePiece((PieceType)pieceNum);
      }

      /**/
        // checks if current pieceNum is in the list of available PieceTypes (by int value)
        //   currently updates numbers correctly, but still allows already grabbed pieces to be made
        //   --know numbers update correctly due to breakpoint--
        public static bool GrabBag(int pieceNum)
        {
            //Console.WriteLine(Board.gBag.Count);
            bool goodPiece = true;
            if (Board.gBag.Count > 0)
            {
                if (Board.gBag.Contains(pieceNum))
                {
                    Board.gBag.Remove(pieceNum);
                }

                if (!(Board.gBag.Contains(pieceNum)))
                {
                    goodPiece = false;
                    System.Diagnostics.Debug.WriteLine($"Can't make piece number {pieceNum}");

                }
            }
            else
            {
                
                Board.gBag = Board.PieceArr.ToList();
                Board.gBag.Remove(pieceNum);
            }
            return goodPiece;
        }
    /*
        // uses array implementation
        public static Boolean GrabBag(Piece newPiece)
    {
      goodPiece = true;
      for (int i = 0; i < currBag.length; i++)
      {
        if newPiece == currBag[i]
          {
            goodPiece = false;
            break;
          }
        if currBag[i] == null
        {
          if (i != 6)
          {
          currbag[i] = newPiece;
          }
          else 
          {
            Array.Clear(currbag, 0, currbag.length)
          }

        }

        
      }
      return goodPiece;
    }
   /* */

    public static Piece MakePiece(PieceType type) {
      Piece piece = null;
      switch (type) {
        case PieceType.L: piece = new Piece("0000010001000110", PieceColor.ORANGE, PieceType.L); break;
        case PieceType.J: piece = new Piece("0000001000100110", PieceColor.BLUE, PieceType.J); break;
        case PieceType.Z: piece = new Piece("0000011000110000", PieceColor.RED, PieceType.Z); break;
        case PieceType.S: piece = new Piece("0000011011000000", PieceColor.GREEN, PieceType.S); break;
        case PieceType.I: piece = new Piece("0010001000100010", PieceColor.CYAN, PieceType.I); break;
        case PieceType.T: piece = new Piece("0000001001110000", PieceColor.PURPLE, PieceType.T); break;
        case PieceType.O: piece = new Piece("0000011001100000", PieceColor.YELLOW, PieceType.O); break;
      }
      return piece;
    }

    public void RotateRight() {
      bool[] read = Layout.Cast<bool>().ToArray();
      bool[] write = new bool[read.Length];

      write[0] = read[12];
      write[1] = read[8];
      write[2] = read[4];
      write[3] = read[0];
      write[4] = read[13];
      write[5] = read[9];
      write[6] = read[5];
      write[7] = read[1];
      write[8] = read[14];
      write[9] = read[10];
      write[10] = read[6];
      write[11] = read[2];
      write[12] = read[15];
      write[13] = read[11];
      write[14] = read[7];
      write[15] = read[3];

      for (int r = 0; r < Layout.GetLength(0); r++) {
        for (int c = 0; c < Layout.GetLength(1); c++) {
          Layout[r, c] = write[r * Layout.GetLength(1) + c];
        }
      }
    }

    public void RotateLeft() {
      bool[] read = Layout.Cast<bool>().ToArray();
      bool[] write = new bool[read.Length];

      write[0] = read[3];
      write[1] = read[7];
      write[2] = read[11];
      write[3] = read[15];
      write[4] = read[2];
      write[5] = read[6];
      write[6] = read[10];
      write[7] = read[14];
      write[8] = read[1];
      write[9] = read[5];
      write[10] = read[9];
      write[11] = read[13];
      write[12] = read[0];
      write[13] = read[4];
      write[14] = read[8];
      write[15] = read[12];

      for (int r = 0; r < Layout.GetLength(0); r++) {
        for (int c = 0; c < Layout.GetLength(1); c++) {
          Layout[r, c] = write[r * Layout.GetLength(1) + c];
        }
      }
    }

    public void MoveDown() {
      GridRow++;
    }

    public void MoveLeft() {
      GridCol--;
    }
    
    public void MoveRight() {
      GridCol++;
    }
  }
}
