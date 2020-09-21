using System.Collections;

namespace MaZe_Path
{
    class MazeTileRow
    {
        private BitArray _wallData;
        private BitArray _pathData;
        public int TileSize { get; } = 3;

        public MazeTileRow(int tilesCount)
        {
            TilesInRow = tilesCount;
            Width = tilesCount * (TileSize - 1) + 1;
            _wallData = new BitArray(Width * TileSize);
            _pathData = new BitArray(Width * TileSize);
        }

        public void FillWallData(MazeTileType[] mazeTileTypes)
        {
            FillFromTileTypes(_wallData, mazeTileTypes);
        }

        public void FillPathData(MazeTileType[] mazeTileTypes)
         {
            FillFromTileTypes(_pathData, mazeTileTypes, true);
            _pathData = _pathData.Not();
        }

        private void FillFromTileTypes(BitArray data, MazeTileType[] mazeTileTypes, bool includeCenter = false)
        {
            for (int i = 0; i < TilesInRow; i++)
            {
                var tileData = MazeTileDataGenerator.GenerateMazeTile(mazeTileTypes[i], includeCenter);
                for (int x = 0; x < tileData.GetLength(0); x++)
                {
                    for (int y = 0; y < tileData.GetLength(1); y++)
                    {
                        var xIndex = x + (i * (TileSize - 1));
                        data[y * Width + xIndex] = tileData[x, y];
                    }
                }
            }
        }

        public bool IsWallAt(int x, int y)
        {
            return _wallData[y * Width + x];
        }

        public bool IsPathAt(int x, int y)
        {
            return _pathData[y * Width + x];
        }

        private int TilesInRow { get; }
        public int Width { get; }
        public int Height => TileSize;
    }
}
