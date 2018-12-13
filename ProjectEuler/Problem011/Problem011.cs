using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectEuler
{
    class Problem011
    {
        public readonly string Path = "Problem011/";
        private readonly int MinimumGridSize = 4;
        private enum Orientation
        {
            DIAGONAL,
            DOWN,
            LEFT,
            RIGHT,
            UP
        }

        public int LargestProductInSquareGrid(int gridSize, int adjacentLength)
        {
            checkArguments(gridSize, adjacentLength);

            var fileName = string.Format("grid_{0}x{0}.txt", gridSize);
            var filePath = Path + fileName;
            if (!File.Exists(filePath))
            {
                var error = string.Format("Unable to find grid of size {0} ({1})", gridSize, filePath);
                throw new FileNotFoundException(error);
            }

            List<int> grid;
            using (var r = new StreamReader(filePath))
            {
                grid = ReadAllLines(r, gridSize);
            }

            if (grid == null)
            {
                var error = string.Format("{0} is improperly formatted", fileName);
                throw new Exception(error);
            }

            var partialApplication = Bridge(gridSize, adjacentLength);
            int largestProduct = FindLargestProduct(grid, partialApplication);

            return largestProduct;
        }

        private void checkArguments(int gridSize, int adjacentLength)
        {
            if (gridSize < MinimumGridSize)
            {
                var error = string.Format("Grid size must be at least {0} (provided {1})", MinimumGridSize, gridSize);
                throw new ArgumentOutOfRangeException(error);
            }

            if (adjacentLength <= 1)
            {
                var error = string.Format("By definition, the minimum number of adjacent numbers is 2");
                throw new ArgumentOutOfRangeException(error);
            }

            if (adjacentLength > gridSize)
            {
                var error = string.Format("{0} adjacent numbers is the maximum number possible for a {0}x{0} grid", gridSize);
                throw new ArgumentOutOfRangeException(error);
            }
        }

        private Func<List<int>, Orientation, int> Bridge(int gridSize, int adjacentLegnth)
        {
            return (grid, orientation) => ScanGrid(grid, gridSize, adjacentLegnth, orientation);
        }

        private List<int> ReadAllLines(StreamReader r, int size)
        {
            var grid = new List<int>();
            List<int> currentSeries;
            while (r.Peek() != -1)
            {
                currentSeries = ReadLine(r);
                if (currentSeries == null || currentSeries.Count != size)
                {
                    // Returning null lets the caller know that
                    // the grid is incorrectly formatted.
                    return null;
                }

                grid.AddRange(currentSeries);
            }

            return grid;
        }

        private List<int> ReadLine(StreamReader r)
        {
            string line = r.ReadLine();
            if (string.IsNullOrWhiteSpace(line))
            {
                return null;
            }

            // Split at arbitrary amount of whitespace
            var splitLine = line.Split(new string[0], StringSplitOptions.RemoveEmptyEntries);
            var series    = splitLine.Select(n => int.Parse(n)).ToList();
            return series;
        }

        private int ScanGrid(List<int> grid, int gridSize, int adjacentLength, Orientation orientation)
        {
            switch (orientation)
            {
                case Orientation.DIAGONAL:
                    return LargestGridDiagonally(grid, gridSize, adjacentLength);
                case Orientation.UP:
                case Orientation.DOWN:
                    return LargestGridUpOrDown(grid, gridSize, adjacentLength);
                case Orientation.LEFT:
                case Orientation.RIGHT:
                    return LargestGridLeftOrRight(grid, gridSize, adjacentLength);
                default:
                    break;
            }

            return -1;
        }

        private int LargestGridDiagonally(List<int> grid, int gridSize, int adjacentLength)
        {
            int additionalNumbers = adjacentLength - 1;
            // We are looking for n numbers diagonally up the grid,
            // so we skip to the beginning of the nth row.
            int outerIndex = gridSize * additionalNumbers;

            // Iterate through the grid and find the largest product
            int largestProduct = 0;
            bool toTheLeft  = false;
            bool toTheRight = true;
            while (outerIndex < grid.Count)
            {
                if ((outerIndex - additionalNumbers) % gridSize == 0)
                {
                    toTheLeft = true;
                }
                // Skip the last additionalNumbers numbers of the grid,
                // as there can be no valid combination of adjacent numbers.
                if ((outerIndex + additionalNumbers) % gridSize == 0)
                {
                    //outerIndex += additionalNumbers;
                    //continue;
                    toTheRight = false;
                }

                int innerIndex = outerIndex;
                List<int> diagonalLeft = new List<int>(adjacentLength);
                List<int> diagonalRight = new List<int>(adjacentLength);
                int tempInt = 0;
                while (innerIndex >= 0)
                {
                    if (diagonalRight.Count == adjacentLength || diagonalLeft.Count == adjacentLength)
                    {
                        break;
                    }

                    if (toTheLeft)
                    {
                        diagonalLeft.Add(grid[innerIndex - tempInt]);
                    }

                    if (toTheRight)
                    {
                        diagonalRight.Add(grid[innerIndex + tempInt]);
                    }

                    if (toTheLeft || toTheRight)
                    {
                        tempInt++;
                    }

                    // Move up one row
                    innerIndex -= gridSize;
                }

                int leftProduct = Product(diagonalLeft);
                int rightProduct = Product(diagonalRight);
                int biggestDiagonal = leftProduct > rightProduct ? leftProduct : rightProduct;
                if (biggestDiagonal > largestProduct)
                {
                    largestProduct = biggestDiagonal;
                }

                toTheLeft  = false;
                toTheRight = true;
                outerIndex++;
            }

            return largestProduct;
        }
        private int LargestGridUpOrDown(List<int> listOfSeries, int gridSize, int adjacentLength)
        {
            // Since we are looking for n numbers UP the grid,
            // we skip to the beginning of the nth row.
            int outerIndex = gridSize * (adjacentLength - 1);
            if (outerIndex >= Math.Pow(gridSize, 2))
            {
                var error = string.Format("{0} adjacent up or down numbers is not possible for a {1}x{1} grid", adjacentLength, gridSize);
                throw new Exception(error);
            }

            // Iterate through the grid and find the largest product
            int largestProduct = 0;
            while (outerIndex < listOfSeries.Count)
            {
                int innerIndex = outerIndex;
                List<int> column = new List<int>(adjacentLength);
                while (innerIndex >= 0)
                {
                    if (column.Count == adjacentLength)
                    {
                        break;
                    }

                    column.Add(listOfSeries[innerIndex]);

                    // Move up one row
                    innerIndex -= (gridSize);
                }

                int columnProduct = Product(column);
                if (columnProduct > largestProduct)
                {
                    largestProduct = columnProduct;
                }

                outerIndex++;
            }

            return largestProduct;
        }

        private int LargestGridLeftOrRight(List<int> listOfSeries, int gridSize, int adjacentLength)
        {
            int outerIndex = adjacentLength - 1;
            // Check to see if the number of adjacent numbers the caller
            // is asking for exceeds the length of a row.
            if (outerIndex > gridSize)
            {
                var error = string.Format("{0} adjacent left or right numbers is not possible for a {1}x{1} grid", adjacentLength, gridSize);
                throw new Exception(error);
            }

            // Iterate through the grid and find the largest product
            int largestProduct = 0;
            while (outerIndex < listOfSeries.Count)
            {
                int innerIndex = outerIndex;
                List<int> row = new List<int>(adjacentLength);
                while (innerIndex >= 0)
                {
                    if (row.Count == adjacentLength)
                    {
                        break;
                    }

                    row.Add(listOfSeries[innerIndex]);

                    // Move up one column
                    innerIndex--;
                }

                int rowProduct = Product(row);
                if (rowProduct > largestProduct)
                {
                    largestProduct = rowProduct;
                }

                outerIndex++;
                // If at the beginning of a new row, increase outerIndex to
                // ensure there are adjacentLength numbers in a row.
                if (outerIndex % gridSize == 0)
                {
                    outerIndex += adjacentLength - 1;
                }
            }

            return largestProduct;
        }

        private int FindLargestProduct(List<int> grid, Func<List<int>, Orientation, int> Scan)
        {
            var reversedGrid = new List<int>(grid);
            reversedGrid.Reverse();
            
            int diagonalFromTop    = Scan(grid, Orientation.DIAGONAL);
            int diagonalFromBottom = Scan(reversedGrid, Orientation.DIAGONAL);
            int diagonalProduct    = diagonalFromTop > diagonalFromBottom ? diagonalFromTop : diagonalFromBottom;
            int upProduct          = Scan(grid, Orientation.UP);
            int downProduct        = Scan(reversedGrid, Orientation.DOWN);
            int leftProduct        = Scan(grid, Orientation.LEFT);
            int rightProduct       = Scan(reversedGrid, Orientation.RIGHT);
            var listOfProducts = new List<int>(5)
            {
                diagonalProduct,
                upProduct,
                downProduct,
                leftProduct,
                rightProduct
            };

            int largestProduct = 0;
            foreach (var product in listOfProducts)
            {
                if (product > largestProduct)
                {
                    largestProduct = product;
                }
            };
            
            return largestProduct;
        }

        private int Product(List<int> list)
        {
            int product = 1;
            foreach (var num in list)
            {
                product *= num;
            }

            return product;
        }
    }
}
