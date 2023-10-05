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
let GetLeastSignificantBitIndex () =
    let blockers : BitBoardType = 0UL.set(int BoardSquare.d7).set(int BoardSquare.d2).set(int BoardSquare.d1).set(int BoardSquare.b4).set(int BoardSquare.g4)
    let lsbIndex = blockers.getLeastSignificantBitIndex
    Assert.AreEqual(BoardSquare.d7, BitBoard.indexToCoordinate(lsbIndex))

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

[<Test>]
let GenerateAllPawnAttacksWhite () =
    let bitBoard = new BitBoard()
    Assert.AreEqual(70368744177664UL, bitBoard.pawnAttacks[int PlayerColor.white, int BoardSquare.h2])

[<Test>]
let GenerateAllPawnAttacksBlack () =
    let bitBoard = new BitBoard()
    Assert.AreEqual(4194304UL, bitBoard.pawnAttacks[int PlayerColor.black, int BoardSquare.h7])

[<Test>]
let GenerateMidBoardKnightAttacks () =
    let knightAttacks = BitBoard.maskKnightAttacks(BoardSquare.f3)
    Assert.AreEqual(5802888705324613632UL, knightAttacks)

[<Test>]
let GenerateEdgeBoardKnightAttacks () =
    let knightAttacks = BitBoard.maskKnightAttacks(BoardSquare.h6)
    Assert.AreEqual(275414786112L, knightAttacks)

[<Test>]
let GenerateCornerBoardKnightAttacks () =
    let knightAttacks = BitBoard.maskKnightAttacks(BoardSquare.a1)
    Assert.AreEqual(1128098930098176L, knightAttacks)

[<Test>]
let GenerateCornerA1BoardKingAttacks () =
    let kingAttacks = BitBoard.maskKingAttacks(BoardSquare.a1)
    Assert.AreEqual(144959613005987840L, kingAttacks)

[<Test>]
let GenerateCornerA8BoardKingAttacks () =
    let kingAttacks = BitBoard.maskKingAttacks(BoardSquare.a8)
    Assert.AreEqual(770L, kingAttacks)

[<Test>]
let GenerateCornerH1BoardKingAttacks () =
    let kingAttacks = BitBoard.maskKingAttacks(BoardSquare.h1)
    Assert.AreEqual(4665729213955833856L, kingAttacks)

[<Test>]
let GenerateCornerH8BoardKingAttacks () =
    let kingAttacks = BitBoard.maskKingAttacks(BoardSquare.h8)
    Assert.AreEqual(49216L, kingAttacks)

[<Test>]
let GenerateMidBoardKingAttacks () =
    let kingAttacks = BitBoard.maskKingAttacks(BoardSquare.d5)
    Assert.AreEqual(120596463616L, kingAttacks)

[<Test>]
let GenerateMidBoardBishopAttacks () =
    let bishopAttacks = BitBoard.maskBishopAttacks(BoardSquare.d4)
    Assert.AreEqual(9592139778506752L, bishopAttacks)

[<Test>]
let GenerateCornerA1BoardBishopAttacks () =
    let bishopAttacks = BitBoard.maskBishopAttacks(BoardSquare.a1)
    Assert.AreEqual(567382630219776L, bishopAttacks)

[<Test>]
let GenerateCornerA8BoardBishopAttacks () =
    let bishopAttacks = BitBoard.maskBishopAttacks(BoardSquare.a8)
    Assert.AreEqual(18049651735527936L, bishopAttacks)

[<Test>]
let GenerateCornerH1BoardBishopAttacks () =
    let bishopAttacks = BitBoard.maskBishopAttacks(BoardSquare.h1)
    Assert.AreEqual(18049651735527936L, bishopAttacks)

[<Test>]
let GenerateCornerH8BoardBishopAttacks () =
    let bishopAttacks = BitBoard.maskBishopAttacks(BoardSquare.h8)
    Assert.AreEqual(567382630219776L, bishopAttacks)

[<Test>]
let GenerateEdgeA5BoardBishopAttacks () =
    let bishopAttacks = BitBoard.maskBishopAttacks(BoardSquare.a5)
    Assert.AreEqual(2256206450263040L, bishopAttacks)

[<Test>]
let GenerateEdgeC1BoardBishopAttacks () =
    let bishopAttacks = BitBoard.maskBishopAttacks(BoardSquare.c1)
    Assert.AreEqual(2832480465846272L, bishopAttacks)

[<Test>]
let GenerateEdgeE8BoardBishopAttacks () =
    let bishopAttacks = BitBoard.maskBishopAttacks(BoardSquare.e8)
    Assert.AreEqual(38021120L, bishopAttacks)

[<Test>]
let GenerateEdgeH3BoardBishopAttacks () =
    let bishopAttacks = BitBoard.maskBishopAttacks(BoardSquare.h3)
    Assert.AreEqual(18014673925310464L, bishopAttacks)

[<Test>]
let GenerateMidBoardRookAttacks () =
    let rookAttacks = BitBoard.maskRookAttacks(BoardSquare.d5)
    Assert.AreEqual(2260632246683648L, rookAttacks)

[<Test>]
let GenerateCornerA1BoardRookAttacks () =
    let rookAttacks = BitBoard.maskRookAttacks(BoardSquare.a1)
    Assert.AreEqual(9079539427579068672L, rookAttacks)

[<Test>]
let GenerateCornerA8BoardRookAttacks () =
    let rookAttacks = BitBoard.maskRookAttacks(BoardSquare.a8)
    Assert.AreEqual(282578800148862L, rookAttacks)

[<Test>]
let GenerateCornerH1BoardRookAttacks () =
    let rookAttacks = BitBoard.maskRookAttacks(BoardSquare.h1)
    Assert.AreEqual(9115426935197958144L, rookAttacks)

[<Test>]
let GenerateCornerH8BoardRookAttacks () =
    let rookAttacks = BitBoard.maskRookAttacks(BoardSquare.h8)
    Assert.AreEqual(36170086419038334L, rookAttacks)

[<Test>]
let GenerateEdgeA4BoardRookAttacks () =
    let rookAttacks = BitBoard.maskRookAttacks(BoardSquare.a4)
    Assert.AreEqual(283115671060736L, rookAttacks)

[<Test>]
let GenerateEdgeF1BoardRookAttacks () =
    let rookAttacks = BitBoard.maskRookAttacks(BoardSquare.f1)
    Assert.AreEqual(6782456361169985536L, rookAttacks)

[<Test>]
let GenerateEdgeG8BoardRookAttacks () =
    let rookAttacks = BitBoard.maskRookAttacks(BoardSquare.g8)
    Assert.AreEqual(18085043209519166L, rookAttacks)

[<Test>]
let GenerateEdgeH2BoardRookAttacks () =
    let rookAttacks = BitBoard.maskRookAttacks(BoardSquare.h2)
    Assert.AreEqual(35607136465616896L, rookAttacks)

[<Test>]
let GenerateBishopAttacksOnTheFly () =
    let blockers : BitBoardType = 0UL.set(int BoardSquare.b6).set(int BoardSquare.g7).set(int BoardSquare.e3).set(int BoardSquare.b2)
    let bishopAttacks = BitBoard.bishopAttacksOnTheFly(BoardSquare.d4, blockers)
    Assert.AreEqual(584940523765760L, bishopAttacks)

[<Test>]
let GenerateRookAttacksOnTheFly () =
    let blockers : BitBoardType = 0UL.set(int BoardSquare.b4).set(int BoardSquare.h4).set(int BoardSquare.d2).set(int BoardSquare.d7)
    let rookAttacks = BitBoard.rookAttacksOnTheFly(BoardSquare.d4, blockers)
    Assert.AreEqual(2261652603406336L, rookAttacks)

// TODO: need tests for empty blockers for on-the-fly functions