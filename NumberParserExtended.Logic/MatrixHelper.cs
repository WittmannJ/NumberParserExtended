namespace NumberParserExtended.Logic
{
    public static class MatrixHelper
    {
        public static char[,] ExtractSubArray(char[,] mainArray, int startColumnIndex, int startRowIndex, int numberOfColumns, int numberOfRows)
        {
            char[,] subArray = new char[numberOfColumns, numberOfRows];

            int runnerSubArrayColumnIndex = startColumnIndex;
            int runnerSubArrayRowIndex = startRowIndex;

            for (int i = 0; i < numberOfColumns; i++)
            {
                for (int j = 0; j < numberOfRows; j++)
                {
                    subArray[i, j] = mainArray[runnerSubArrayColumnIndex, runnerSubArrayRowIndex];
                    runnerSubArrayRowIndex++;
                }
                runnerSubArrayColumnIndex++;
            }
            return subArray;
        }

        public static List<char[,]> ExtractNumbersAsSubArrays(char[,] mainArray)
        {
            List<char[,]> listOfNumberArrays = new List<char[,]>();

            // idea: use a [1,4] mask to get a sub-array from the first column and four rows of the main array
            // check if the subarray contains at least one char that is not a whitespace
            // if yes then concat it with an empty array of shape [1,4] or something like that
            // repeat the step for the next subarray

            // first we only consider the first four columns of our mainArray
            char[,] numberArray = null;
            for (int logicalRow = 0; logicalRow < mainArray.GetLength(1); logicalRow += 4)
            {
                for (int i = 0; i < mainArray.GetLength(0); i++) // iterate over all columns
                {
                    var subArray = ExtractSubArray(mainArray, i, logicalRow, 1, 4);
                    if (CheckIfCharArrayContainsNonWhitespaces(subArray.Cast<char>().ToArray()))
                    {
                        if (numberArray == null)
                        {
                            numberArray = subArray;
                        }

                        else
                        {
                            numberArray = ConcatenateTwo2DCharArraysHorizontally(numberArray, subArray);
                        }
                    }
                    else if (numberArray != null)
                    {
                        listOfNumberArrays.Add(numberArray);
                        numberArray = null;
                    }
                }
                // when we switch the "logical" row e.g. move with our mask down then we have to add
                // the last number from previous "logical" row to the storage and prepare for the new row
                if(numberArray != null)
                    listOfNumberArrays.Add(numberArray);
                numberArray = null;

            }

            return listOfNumberArrays;
        }

        public static char[,] ConcatenateTwo2DCharArraysHorizontally(char[,] array1, char[,] array2)
        {
            // what is important? => The two arrays should have the same number of rows


            if (array1.GetLength(1) != array2.GetLength(1))
                throw new ArgumentException("The two arrays do not have matching dimensions!");

            // the result array should have the same number of rows e.g. 4
            // the rsult array should have the sum of the number of columns of both arrays e.g. 2
            int newNumberOfColums = array1.GetLength(0) + array2.GetLength(0);
            char[,] resultCharArray = new char[newNumberOfColums, array1.GetLength(1)];

            int runnerColumnsSecondArray = 0;
            int runnerRowsSecondArray = 0;
            for (int i = 0; i < newNumberOfColums; i++)
            {
                for (int j = 0; j < array1.GetLength(1); j++)
                {
                    if (i < array1.GetLength(0))
                    {
                        resultCharArray[i, j] = array1[i, j];
                    }

                    else
                    {
                        resultCharArray[i, j] = array2[runnerColumnsSecondArray, runnerRowsSecondArray];
                        runnerRowsSecondArray++;
                    }

                }

            }

            return resultCharArray;
        }

        public static char[,] ConcatenateTwo2DCharArraysVertically(char[,] array1, char[,] array2)
        {
            // what is important? => The two arrays should have the same number of rows


            if (array1.GetLength(0) != array2.GetLength(0)) // same number of rows
                throw new ArgumentException("The two arrays do not have matching dimensions!");

            // the result array should have the same number of rows e.g. 4
            // the rsult array should have the sum of the number of columns of both arrays e.g. 2
            int newNumberOfColums = array1.GetLength(1) + array2.GetLength(1);
            char[,] resultCharArray = new char[array1.GetLength(0), newNumberOfColums];

            int runnerColumnsSecondArray = 0;
            int runnerRowsSecondArray = 0;
            for (int column = 0; column < newNumberOfColums; column++)
            {
                for (int row = 0; row < array1.GetLength(0); row++)
                {
                    if (column < array1.GetLength(1))
                        resultCharArray[row, column] = array1[row, column];
                    else
                    {
                        resultCharArray[row, column] = array2[runnerRowsSecondArray, runnerColumnsSecondArray];
                        runnerRowsSecondArray++;
                    }
                }
            }

            return resultCharArray;
        }

        // returns true if at least one character is found that is not a whitespace
        public static bool CheckIfCharArrayContainsNonWhitespaces(char[] arrayToCheck)
        {
            bool nonWhitespaceFound = false;
            for (int i = 0; i < arrayToCheck.Length; i++)
            {
                if (arrayToCheck[i] != ' ')
                {
                    nonWhitespaceFound = true;
                    break;
                }
            }
            return nonWhitespaceFound;
        }
    }
}
