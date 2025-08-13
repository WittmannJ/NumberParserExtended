namespace StringNormalizer
{
    public static class StringNormalizer
    {
        public static string ReplaceTabstopsInStringWithWhitespaces(string stringWithTabstops)
        {
            while (stringWithTabstops.Contains('\t'))
            {
                int positionOfTabstop = stringWithTabstops.IndexOf('\t');
                int numberOfWhitespacesPerRule = GetTabstopAsSpaces(positionOfTabstop);
                stringWithTabstops = ReplaceTabstopWithWhitespacesInString(stringWithTabstops, positionOfTabstop, numberOfWhitespacesPerRule);
            }
            var stringWithoutTabstops = stringWithTabstops;
            return stringWithoutTabstops;
        }

        private static string ReplaceTabstopWithWhitespacesInString(string stringWithTabstop, int positionOfTabstop, int numberOfWhitespacesToReplaceTabstop)
        {

            // convert string to char array
            char[] charArrayWithTabstop = stringWithTabstop.ToCharArray();

            // split char array at the position of the tabstop
            char[] leftPartOfCharArray = new char[positionOfTabstop + 1];

            char[] rightPartOfCharArray = new char[charArrayWithTabstop.Length - positionOfTabstop - 1];

            // fill the two splits of the array -> we need two runner variables for the two new arrays
            int runnerLeftArray = 0;
            int runnerRightArray = 0;
            for (int i = 0; i < charArrayWithTabstop.Length; i++)
            {
                if (i <= positionOfTabstop)
                {
                    leftPartOfCharArray[runnerLeftArray] = charArrayWithTabstop[i];
                    runnerLeftArray++;
                }

                else
                {
                    rightPartOfCharArray[runnerRightArray] = charArrayWithTabstop[i];
                    runnerRightArray++;
                }
            }

            // create a third array which is used for the replacement of the tabs with whitespaces
            // its size is the length of the leftarray -1 (replacement of tab) + numberOfWhitespaces
            char[] leftPartOfCharArrayWithTabstopReplaced = new char[leftPartOfCharArray.Length - 1 + numberOfWhitespacesToReplaceTabstop];
            // fill array first
            for (int i = 0; i < leftPartOfCharArray.Length; i++)
            {
                leftPartOfCharArrayWithTabstopReplaced[i] = leftPartOfCharArray[i];
            }

            for (int i = positionOfTabstop; i < leftPartOfCharArrayWithTabstopReplaced.Length; i++)
            {
                leftPartOfCharArrayWithTabstopReplaced[i] = ' ';
            }

            // combine the left and right parts of the original array again
            char[] combinedArrayWithTabstopsReplaced = new char[leftPartOfCharArrayWithTabstopReplaced.Length + rightPartOfCharArray.Length];
            runnerLeftArray = 0;
            runnerRightArray = 0;

            for (int i = 0; i < combinedArrayWithTabstopsReplaced.Length; i++)
            {
                if (i < leftPartOfCharArrayWithTabstopReplaced.Length)
                {
                    combinedArrayWithTabstopsReplaced[i] = leftPartOfCharArrayWithTabstopReplaced[runnerLeftArray];
                    runnerLeftArray++;
                }
                else
                {
                    combinedArrayWithTabstopsReplaced[i] = rightPartOfCharArray[runnerRightArray];
                    runnerRightArray++;
                }

            }

            // Ersetze diese Zeile:
            // string StringWithTabstopsReplacedWithWhitespaces = combinedArrayWithTabstopsReplaced.ToString();
            // durch:
            string StringWithTabstopsReplacedWithWhitespaces = new string(combinedArrayWithTabstopsReplaced);

            return StringWithTabstopsReplacedWithWhitespaces;
        }

        private static int GetTabstopAsSpaces(int posOfTabstop)
        {
            var numberOfWhitespaces = 8 - (posOfTabstop % 8);
            return numberOfWhitespaces;
        }



    }
}
