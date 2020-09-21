namespace MaZe_Path
{
    class MazeTileDataGenerator
    {
        public static bool[,] GenerateMazeTile(MazeTileType tileType, bool includeCenter)
        {
            var tile = new bool[3, 3];

            // Corners
            tile[0, 0] = true;
            tile[0, 2] = true;
            tile[2, 0] = true;
            tile[2, 2] = true;

            if (includeCenter && tileType == MazeTileType.None)
            {
                tile[1, 1] = true;
            }

            if (!tileType.HasFlag(MazeTileType.North))
            {
                tile[1, 0] = true;
            }
            if (!tileType.HasFlag(MazeTileType.East))
            {
                tile[2, 1] = true;
            }
            if (!tileType.HasFlag(MazeTileType.South))
            {
                tile[1, 2] = true;
            }
            if (!tileType.HasFlag(MazeTileType.West))
            {
                tile[0, 1] = true;
            }

            return tile;
        }
    }
}
