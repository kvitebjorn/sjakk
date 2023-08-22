module board_tests.bitboard.BitBoard

open NUnit.Framework
open board.bitboard.BitBoard

[<SetUp>]
let Setup () =
    ()

[<Test>]
let CreateEmptyBitBoard () =
    let emptyBitBoard = new BitBoard()
    Assert.NotNull(emptyBitBoard)

[<Test>]
let SetPawnOnE2 () =
    let bitBoard = new BitBoard()

    // TODO: figure out a better indexing strat, probably move to member function
    bitBoard.bitboards[LanguagePrimitives.EnumToValue(Pieces.P)] <-
     bitBoard.bitboards[LanguagePrimitives.EnumToValue(Pieces.P)].set(
        LanguagePrimitives.EnumToValue(BoardSquares.e2))
    Assert.NotZero(bitBoard.bitboards[LanguagePrimitives.EnumToValue(Pieces.P)])