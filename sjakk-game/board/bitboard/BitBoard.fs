namespace board.bitboard

// https://www.chessprogramming.org/Bitboard_Board-Definition
module BitBoard =
    type BitBoard() =
        let whitePawns   : uint64 = 0UL
        let whiteKnights : uint64 = 0UL
        let whiteBishops : uint64 = 0UL
        let whiteRooks   : uint64 = 0UL
        let whiteQueens  : uint64 = 0UL
        let whiteKing    : uint64 = 0UL

        let blackPawns   : uint64 = 0UL
        let blackKnights : uint64 = 0UL
        let blackBishops : uint64 = 0UL
        let blackRooks   : uint64 = 0UL
        let blackQueens  : uint64 = 0UL
        let blackKing    : uint64 = 0UL

