using System;

namespace MaZe_Path
{
    class MazeGenerator
    {
        private MazeTileType[] LastRowTiles { get; set; }
        private int LastTilePassIndex { get; set; }
        private int TilesInRow { get; }
        private Random Random { get; }

        public MazeGenerator(int tilesCount)
        {
            TilesInRow = tilesCount;
            LastRowTiles = new MazeTileType[TilesInRow]; 
            Random = new Random();
        }

        public MazeTileRow Next()
        {
            MazeTileType[] rowTiles = GenerateTilesRow(out var pathTiles);
            LastRowTiles = rowTiles;

            var mazeRow = new MazeTileRow(TilesInRow);
            mazeRow.FillWallData(rowTiles);

            mazeRow.FillPathData(pathTiles);
            
            return mazeRow;
        }


        private MazeTileType[] GenerateTilesRow(out MazeTileType[] path)
        {
            var rowTiles = new MazeTileType[TilesInRow];

            rowTiles[LastTilePassIndex] |= MazeTileType.North;
            var direction = GenerateRandomDirection();
            var length = Random.Next(1, TilesInRow);
            var newTilePassIndex = Math.Abs((LastTilePassIndex + direction * length) % (TilesInRow));

            rowTiles[newTilePassIndex] |= MazeTileType.South;

            var fromIndex = Math.Min(LastTilePassIndex, newTilePassIndex);
            var toIndex = Math.Max(LastTilePassIndex, newTilePassIndex);
            for (int i = fromIndex; i < toIndex; i++)
            {
                rowTiles[i] |= MazeTileType.East;
                rowTiles[i+1] |= MazeTileType.West;
            }

            path = new MazeTileType[TilesInRow];
            rowTiles.CopyTo(path, 0);

            LastTilePassIndex = newTilePassIndex;
            for (int i = 0; i < rowTiles.Length; i++)
            {
                var top = LastRowTiles[i].HasFlag(MazeTileType.South) ? MazeTileType.North : default;
                MazeTileType left = default;
                if (i > 0)
                {
                    left = LastRowTiles[i - 1].HasFlag(MazeTileType.East) ? MazeTileType.West : default;
                }
                rowTiles[i] = GenerateCompatibleTileType(rowTiles[i] | top | left);
            }

            return rowTiles;
        }

        private int GenerateRandomDirection()
        {
            var random = Random.NextDouble();
            if (random < 0.4)
                return -1;
            else if (random < 0.6)
                return 0;
            else
                return 1;
        }

        private MazeTileType GenerateCompatibleTileType(MazeTileType tileType)
        {
            var resultTile = tileType;
            if (Random.NextDouble() > 0.7)
            {
                resultTile |= MazeTileType.East;
            }
            if (Random.NextDouble() > 0.7)
            {
                resultTile |= MazeTileType.South;
            }
            return resultTile;
        }

    }
}
