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
