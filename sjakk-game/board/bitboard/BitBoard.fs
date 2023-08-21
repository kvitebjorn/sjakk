namespace board.bitboard

// https://www.chessprogramming.org/Bitboard_Board-Definition
module BitBoard =
    type BitBoard() =
        let empty : int64 = 0L
        let all   : int64 = -1L

        let firstRank : int64 = 0xffL
        let lastRank  : int64 = 0xffL <<< 56
        let lightSquares : int64 = 0x55aa55aa55aa55aaL
        let darkSquares  : int64 = 0xaa55aa55aa55aa55L

