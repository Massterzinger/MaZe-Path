using System;

namespace MaZe_Path
{
    [Flags]
    enum MazeTileType
    {
        None = 0,
        North = 0b0001,
        East  = 0b0010,
        South = 0b0100,
        West  = 0b1000,
        All = North | East | South | East
    }
}
