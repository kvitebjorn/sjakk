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
let GetBit () =
    // 0000
    let zero : System.UInt64 = 0UL
    Assert.IsFalse(zero.get(0))
    Assert.IsFalse(zero.get(1))
    Assert.IsFalse(zero.get(2))
    Assert.IsFalse(zero.get(3))

    // 0001
    let one : System.UInt64 = 1UL
    Assert.IsTrue(one.get(0))
    Assert.IsFalse(one.get(1))
    Assert.IsFalse(one.get(2))
    Assert.IsFalse(one.get(3))

    // 0010
    let two : System.UInt64 = 2UL
    Assert.IsFalse(two.get(0))
    Assert.IsTrue(two.get(1))
    Assert.IsFalse(two.get(2))
    Assert.IsFalse(two.get(3))

    // 0100
    let four : System.UInt64 = 4UL
    Assert.IsFalse(four.get(0))
    Assert.IsFalse(four.get(1))
    Assert.IsTrue(four.get(2))
    Assert.IsFalse(four.get(3))

    // 1000
    let eight : System.UInt64 = 8UL
    Assert.IsFalse(eight.get(0))
    Assert.IsFalse(eight.get(1))
    Assert.IsFalse(eight.get(2))
    Assert.IsTrue(eight.get(3))

[<Test>]
let SetBit () =
    // 0001
    let one : System.UInt64 = 0UL.set(0)
    Assert.IsTrue(one.get(0))
    Assert.IsFalse(one.get(1))
    Assert.IsFalse(one.get(2))
    Assert.IsFalse(one.get(3))

    // 0010
    let two : System.UInt64 = 0UL.set(1)
    Assert.IsFalse(two.get(0))
    Assert.IsTrue(two.get(1))
    Assert.IsFalse(two.get(2))
    Assert.IsFalse(two.get(3))

    // 0100
    let four : System.UInt64 = 0UL.set(2)
    Assert.IsFalse(four.get(0))
    Assert.IsFalse(four.get(1))
    Assert.IsTrue(four.get(2))
    Assert.IsFalse(four.get(3))

    // 1000
    let eight : System.UInt64 = 0UL.set(3)
    Assert.IsFalse(eight.get(0))
    Assert.IsFalse(eight.get(1))
    Assert.IsFalse(eight.get(2))
    Assert.IsTrue(eight.get(3))

[<Test>]
let PopBit () =
    // 0000
    let zero : System.UInt64 = 0UL.pop(0)
    Assert.IsFalse(zero.get(0))
    Assert.IsFalse(zero.get(1))
    Assert.IsFalse(zero.get(2))
    Assert.IsFalse(zero.get(3))

    // 0001
    let one : System.UInt64 = 1UL.pop(0)
    Assert.IsFalse(one.get(0))
    Assert.IsFalse(one.get(1))
    Assert.IsFalse(one.get(2))
    Assert.IsFalse(one.get(3))

    // 0010
    let two : System.UInt64 = 2UL.pop(1)
    Assert.IsFalse(two.get(0))
    Assert.IsFalse(two.get(1))
    Assert.IsFalse(two.get(2))
    Assert.IsFalse(two.get(3))

    // 0100
    let four : System.UInt64 = 4UL.pop(2)
    Assert.IsFalse(four.get(0))
    Assert.IsFalse(four.get(1))
    Assert.IsFalse(four.get(2))
    Assert.IsFalse(four.get(3))

    // 1000
    let eight : System.UInt64 = 8UL.pop(3)
    Assert.IsFalse(eight.get(0))
    Assert.IsFalse(eight.get(1))
    Assert.IsFalse(eight.get(2))
    Assert.IsFalse(eight.get(3))

[<Test>]
let CountBits () =
    // 0000
    let zero : System.UInt64 = 0UL
    Assert.AreEqual(0, zero.count)

    // 0001
    let one : System.UInt64 = 1UL
    Assert.AreEqual(1, one.count)

    // 0010
    let two : System.UInt64 = 2UL
    Assert.AreEqual(1, two.count)

    // 0100
    let four : System.UInt64 = 4UL
    Assert.AreEqual(1, four.count)

    // 1000
    let eight : System.UInt64 = 8UL
    Assert.AreEqual(1, eight.count)

    // 1111
    let fifteen : System.UInt64 = 15UL
    Assert.AreEqual(4, fifteen.count)

[<Test>]
let PrintEmptyBitboard() =
    let bitBoard = new BitBoard()
    Assert.AreEqual(0UL, bitBoard.bitboards[int Pieces.P])

[<Test>]
let SetPawnOnE2 () =
    let bitBoard = new BitBoard()
    bitBoard.bitboards[int Pieces.P] <-
     bitBoard.bitboards[int Pieces.P].set(int BoardSquare.e2)
    Assert.AreEqual(4503599627370496UL, bitBoard.bitboards[int Pieces.P])

[<Test>]
let GenerateMidBoardPawnAttacksWhite () =
    let pawnAttacks = BitBoard.maskPawnAttacks(PlayerColor.white, BoardSquare.e4)
    Assert.AreEqual(671088640UL, pawnAttacks)

[<Test>]
let GenerateMidBoardPawnAttacksBlack () =
    let pawnAttacks = BitBoard.maskPawnAttacks(PlayerColor.black, BoardSquare.e5)
    Assert.AreEqual(171798691840UL, pawnAttacks)

[<Test>]
let GenerateAFilePawnAttacksWhite () =
    let pawnAttacks = BitBoard.maskPawnAttacks(PlayerColor.white, BoardSquare.a2)
    Assert.AreEqual(2199023255552UL, pawnAttacks)

[<Test>]
let GenerateAFilePawnAttacksBlack () =
    let pawnAttacks = BitBoard.maskPawnAttacks(PlayerColor.black, BoardSquare.a7)
    Assert.AreEqual(131072UL, pawnAttacks)

[<Test>]
let GenerateHFilePawnAttacksWhite () =
    let pawnAttacks = BitBoard.maskPawnAttacks(PlayerColor.white, BoardSquare.h2)
    Assert.AreEqual(70368744177664UL, pawnAttacks)

[<Test>]
let GenerateHFilePawnAttacksBlack () =
    let pawnAttacks = BitBoard.maskPawnAttacks(PlayerColor.black, BoardSquare.h7)
    Assert.AreEqual(4194304UL, pawnAttacks)