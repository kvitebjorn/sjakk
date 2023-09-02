namespace board.bitboard

// TODO obviously can use some functional refactoring
//      just want to get everything working naievely first according to the wiki

(*
            Chess board

                            WHITE PIECES


        Pawns                  Knights              Bishops
        
  8  0 0 0 0 0 0 0 0    8  0 0 0 0 0 0 0 0    8  0 0 0 0 0 0 0 0
  7  0 0 0 0 0 0 0 0    7  0 0 0 0 0 0 0 0    7  0 0 0 0 0 0 0 0
  6  0 0 0 0 0 0 0 0    6  0 0 0 0 0 0 0 0    6  0 0 0 0 0 0 0 0
  5  0 0 0 0 0 0 0 0    5  0 0 0 0 0 0 0 0    5  0 0 0 0 0 0 0 0
  4  0 0 0 0 0 0 0 0    4  0 0 0 0 0 0 0 0    4  0 0 0 0 0 0 0 0
  3  0 0 0 0 0 0 0 0    3  0 0 0 0 0 0 0 0    3  0 0 0 0 0 0 0 0
  2  1 1 1 1 1 1 1 1    2  0 0 0 0 0 0 0 0    2  0 0 0 0 0 0 0 0
  1  0 0 0 0 0 0 0 0    1  0 1 0 0 0 0 1 0    1  0 0 1 0 0 1 0 0

     a b c d e f g h       a b c d e f g h       a b c d e f g h


         Rooks                 Queens                 King

  8  0 0 0 0 0 0 0 0    8  0 0 0 0 0 0 0 0    8  0 0 0 0 0 0 0 0
  7  0 0 0 0 0 0 0 0    7  0 0 0 0 0 0 0 0    7  0 0 0 0 0 0 0 0
  6  0 0 0 0 0 0 0 0    6  0 0 0 0 0 0 0 0    6  0 0 0 0 0 0 0 0
  5  0 0 0 0 0 0 0 0    5  0 0 0 0 0 0 0 0    5  0 0 0 0 0 0 0 0
  4  0 0 0 0 0 0 0 0    4  0 0 0 0 0 0 0 0    4  0 0 0 0 0 0 0 0
  3  0 0 0 0 0 0 0 0    3  0 0 0 0 0 0 0 0    3  0 0 0 0 0 0 0 0
  2  0 0 0 0 0 0 0 0    2  0 0 0 0 0 0 0 0    2  0 0 0 0 0 0 0 0
  1  1 0 0 0 0 0 0 1    1  0 0 0 1 0 0 0 0    1  0 0 0 0 1 0 0 0

     a b c d e f g h       a b c d e f g h       a b c d e f g h


                            BLACK PIECES


        Pawns                  Knights              Bishops
        
  8  0 0 0 0 0 0 0 0    8  0 1 0 0 0 0 1 0    8  0 0 1 0 0 1 0 0
  7  1 1 1 1 1 1 1 1    7  0 0 0 0 0 0 0 0    7  0 0 0 0 0 0 0 0
  6  0 0 0 0 0 0 0 0    6  0 0 0 0 0 0 0 0    6  0 0 0 0 0 0 0 0
  5  0 0 0 0 0 0 0 0    5  0 0 0 0 0 0 0 0    5  0 0 0 0 0 0 0 0
  4  0 0 0 0 0 0 0 0    4  0 0 0 0 0 0 0 0    4  0 0 0 0 0 0 0 0
  3  0 0 0 0 0 0 0 0    3  0 0 0 0 0 0 0 0    3  0 0 0 0 0 0 0 0
  2  0 0 0 0 0 0 0 0    2  0 0 0 0 0 0 0 0    2  0 0 0 0 0 0 0 0
  1  0 0 0 0 0 0 0 0    1  0 0 0 0 0 0 0 0    1  0 0 0 0 0 0 0 0

     a b c d e f g h       a b c d e f g h       a b c d e f g h


         Rooks                 Queens                 King

  8  1 0 0 0 0 0 0 1    8  0 0 0 1 0 0 0 0    8  0 0 0 0 1 0 0 0
  7  0 0 0 0 0 0 0 0    7  0 0 0 0 0 0 0 0    7  0 0 0 0 0 0 0 0
  6  0 0 0 0 0 0 0 0    6  0 0 0 0 0 0 0 0    6  0 0 0 0 0 0 0 0
  5  0 0 0 0 0 0 0 0    5  0 0 0 0 0 0 0 0    5  0 0 0 0 0 0 0 0
  4  0 0 0 0 0 0 0 0    4  0 0 0 0 0 0 0 0    4  0 0 0 0 0 0 0 0
  3  0 0 0 0 0 0 0 0    3  0 0 0 0 0 0 0 0    3  0 0 0 0 0 0 0 0
  2  0 0 0 0 0 0 0 0    2  0 0 0 0 0 0 0 0    2  0 0 0 0 0 0 0 0
  1  0 0 0 0 0 0 0 0    1  0 0 0 0 0 0 0 0    1  0 0 0 0 0 0 0 0

     a b c d e f g h       a b c d e f g h       a b c d e f g h



                             OCCUPANCIES


     White occupancy       Black occupancy       All occupancies

  8  0 0 0 0 0 0 0 0    8  1 1 1 1 1 1 1 1    8  1 1 1 1 1 1 1 1
  7  0 0 0 0 0 0 0 0    7  1 1 1 1 1 1 1 1    7  1 1 1 1 1 1 1 1
  6  0 0 0 0 0 0 0 0    6  0 0 0 0 0 0 0 0    6  0 0 0 0 0 0 0 0
  5  0 0 0 0 0 0 0 0    5  0 0 0 0 0 0 0 0    5  0 0 0 0 0 0 0 0
  4  0 0 0 0 0 0 0 0    4  0 0 0 0 0 0 0 0    4  0 0 0 0 0 0 0 0
  3  0 0 0 0 0 0 0 0    3  0 0 0 0 0 0 0 0    3  0 0 0 0 0 0 0 0
  2  1 1 1 1 1 1 1 1    2  0 0 0 0 0 0 0 0    2  1 1 1 1 1 1 1 1
  1  1 1 1 1 1 1 1 1    1  0 0 0 0 0 0 0 0    1  1 1 1 1 1 1 1 1
*)

// https://www.chessprogramming.org/Bitboard_Board-Definition
module BitBoard =
   type System.UInt64 with
      // get bit at idx i
      member x.get i = x &&& (1UL <<< i) <> 0UL
 
      // from 0 to 1 at idx i
      member x.set i = x ||| (1UL <<< i)

      // from 1 to 0 at idx i
      member x.pop i = x &&& ~~~(1UL <<< i)

      // count bits set to 1
      member x.count =
         let rec go b acc = if b = 0UL then acc else go (b &&& (b-1UL)) (acc+1UL)
         go x 0UL

   type BitBoardType = System.UInt64

   type PlayerColor =
   | white = 0
   | black = 1
   | both  = 2

   type BoardSquare = 
      | a8 = 0  | b8 = 1  | c8 = 2  | d8 = 3  | e8 = 4  | f8 = 5  | g8 = 6  | h8 = 7
      | a7 = 8  | b7 = 9  | c7 = 10 | d7 = 11 | e7 = 12 | f7 = 13 | g7 = 14 | h7 = 15
      | a6 = 16 | b6 = 17 | c6 = 18 | d6 = 19 | e6 = 20 | f6 = 21 | g6 = 22 | h6 = 23
      | a5 = 24 | b5 = 25 | c5 = 26 | d5 = 27 | e5 = 28 | f5 = 29 | g5 = 30 | h5 = 31
      | a4 = 32 | b4 = 33 | c4 = 34 | d4 = 35 | e4 = 36 | f4 = 37 | g4 = 38 | h4 = 39
      | a3 = 40 | b3 = 41 | c3 = 42 | d3 = 43 | e3 = 44 | f3 = 45 | g3 = 46 | h3 = 47
      | a2 = 48 | b2 = 49 | c2 = 50 | d2 = 51 | e2 = 52 | f2 = 53 | g2 = 54 | h2 = 55
      | a1 = 56 | b1 = 57 | c1 = 58 | d1 = 59 | e1 = 60 | f1 = 61 | g1 = 62 | h1 = 63 
      | no_sq = 64

   (* castling rights binary encoding

      bin  dec
      
      0001    1  white king can castle to the kingside
      0010    2  white king can castle to the queenside
      0100    4  black king can castle to the kingside
      1000    8  black king can castle to the queen ide

      examples

      1111       both sides an castle both directions
      1001       black king => queenside
                 white king => kingside
   *)
   type CastlingRights =
      | whiteKingside  = 1
      | whiteQueenside = 2
      | blackKingside  = 4
      | blackQueenside = 8

   // capitalized = White
   // lowercase = Black
   type Pieces =
      | P = 0
      | N = 1
      | B = 2
      | R = 3
      | Q = 4
      | K = 5
      | p = 6
      | n = 7
      | b = 8
      | r = 9
      | q = 10
      | k = 11

   let AsciiPieces =
      [|
         'P'
         'N'
         'B'
         'R'
         'Q'
         'K'
         'p'
         'n'
         'b'
         'r'
         'q'
         'k'
      |]

   let UnicodePieces =
      [|
         "♙"
         "♘"
         "♗"
         "♖"
         "♕"
         "♔"
         "♟︎"
         "♞"
         "♝"
         "♜"
         "♛"
         "♚"
      |]

   let AsciiToEncodedPieces =
      [
         'P', Pieces.P
         'N', Pieces.N
         'B', Pieces.B
         'R', Pieces.R
         'Q', Pieces.Q
         'K', Pieces.K
         'p', Pieces.p
         'n', Pieces.n
         'b', Pieces.b
         'r', Pieces.r
         'q', Pieces.q
         'k', Pieces.k
      ]
      |> Map.ofList

   type Sliders =
      | rook    = 0
      | bishop  = 1

   let NOT_A_FILE : BitBoardType = 18374403900871474942UL
   let NOT_H_FILE : BitBoardType = 9187201950435737471UL;
   let NOT_H_OR_G_FILE : BitBoardType = 4557430888798830399UL
   let NOT_A_OR_B_FILE : BitBoardType = 18229723555195321596UL

   // Board with capital B, referring to the whole of the chess Board,
   // which is the aggregate of 12 bitboard slices as shown above
   type BitBoard() =
      member val bitboards   : BitBoardType array = Array.zeroCreate 12
      member val occupancies : BitBoardType array = Array.zeroCreate 3
      member val playerToMove = -1
      member val enpassant = BoardSquare.no_sq
      member val castle = 0

      static member printBitboard(bitboard : BitBoardType) =
         for rank = 0 to 7 do
            for file = 0 to 7 do
               let squareIndex = rank * 8 + file

               // print ranks
               if file = 0 then
                  printf "  %i " (8 - rank)

               // print the bit state
               printf " %i" (if bitboard.get(squareIndex) then 1 else 0)
            printf "\n"

         // print board files
         printf "\n     a b c d e f g h\n\n"
         
         // print bitboard as unsigned decimal number
         printf "     Bitboard: %i\n\n" bitboard

      // generate pawn attacks
      static member maskPawnAttacks(player : PlayerColor, square : BoardSquare) : BitBoardType =
         // result attacks bitboard
         let mutable attacks : BitBoardType = 0UL

         // set piece on the bitboard
         let bitboard : BitBoardType = 0UL.set(int square)

         if (player = PlayerColor.white) then
            if ((bitboard >>> 7) &&& NOT_A_FILE) <> 0UL then 
               attacks <- attacks ||| (bitboard >>> 7)
            if ((bitboard >>> 9) &&& NOT_H_FILE) <> 0UL then 
               attacks <- attacks ||| (bitboard >>> 9)
         else
            if ((bitboard <<< 7) &&& NOT_H_FILE) <> 0UL then
               attacks <- attacks ||| (bitboard <<< 7)
            if ((bitboard <<< 9) &&& NOT_A_FILE) <> 0UL then
               attacks <- attacks ||| (bitboard <<< 9)

         attacks

      // TODO: move all these piece init into one init function under one for loop
      // pawn attacks table [player color][square]
      member x.pawnAttacks : BitBoardType[,] = 
         let mutable pawnAttacks = Array2D.zeroCreate 2 64
         for square = 0 to 63 do
            pawnAttacks[int PlayerColor.white, square] <- BitBoard.maskPawnAttacks(PlayerColor.white, enum<BoardSquare> square)
            pawnAttacks[int PlayerColor.black, square] <- BitBoard.maskPawnAttacks(PlayerColor.black, enum<BoardSquare> square)
         pawnAttacks

      // generate knight attacks
      static member maskKnightAttacks(player : PlayerColor, square : BoardSquare) : BitBoardType =
         // result attacks bitboard
         let mutable attacks : BitBoardType = 0UL

         // set piece on the bitboard
         let bitboard : BitBoardType = 0UL.set(int square)

         if ((bitboard >>> 17) &&& NOT_H_FILE) <> 0UL then 
            attacks <- attacks ||| (bitboard >>> 17)
         if ((bitboard >>> 15) &&& NOT_A_FILE) <> 0UL then 
            attacks <- attacks ||| (bitboard >>> 15)
         if ((bitboard >>> 10) &&& NOT_H_OR_G_FILE) <> 0UL then 
            attacks <- attacks ||| (bitboard >>> 10)
         if ((bitboard >>> 6) &&& NOT_A_OR_B_FILE) <> 0UL then 
            attacks <- attacks ||| (bitboard >>> 6)
         if ((bitboard <<< 17) &&& NOT_A_FILE) <> 0UL then 
            attacks <- attacks ||| (bitboard <<< 17)
         if ((bitboard <<< 15) &&& NOT_H_FILE) <> 0UL then 
            attacks <- attacks ||| (bitboard <<< 15)
         if ((bitboard <<< 10) &&& NOT_A_OR_B_FILE) <> 0UL then 
            attacks <- attacks ||| (bitboard <<< 10)
         if ((bitboard <<< 6) &&& NOT_H_OR_G_FILE) <> 0UL then 
            attacks <- attacks ||| (bitboard <<< 6)
         attacks

      // knight attacks table [player color][square]
      member x.knightAttacks : BitBoardType[,] = 
         let mutable knightAttacks = Array2D.zeroCreate 2 64
         for square = 0 to 63 do
            knightAttacks[int PlayerColor.white, square] <- BitBoard.maskKnightAttacks(PlayerColor.white, enum<BoardSquare> square)
            knightAttacks[int PlayerColor.black, square] <- BitBoard.maskKnightAttacks(PlayerColor.black, enum<BoardSquare> square)
         knightAttacks