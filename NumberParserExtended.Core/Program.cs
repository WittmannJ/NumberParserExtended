// See https://aka.ms/new-console-template for more information

using static StringNormalizer.StringNormalizer;
using static NumberParserExtended.Logic.MatrixHelper;

var filename = "NumberParserExtended.txt";

string contents = File.ReadAllText(filename);


// find line with the longest line length aka the most characters
// -> use this line to replace the tabstops correctly => does not work anymore if there are more
// than one tabstop in a line

string[] lines = File.ReadAllLines(filename);

string[] newLines = new string[lines.Length];

for (int i = 0; i < lines.Length; i++)
{
    newLines[i] = ReplaceTabstopsInStringWithWhitespaces(lines[i]);
}


// next step: make all lines have the same length via padding => easier to work with when using 2d arrays

// 1st: find the longest string

int longestNumberOfChars = 0;

foreach (var line in newLines)
{
    if (line.Length > longestNumberOfChars)
        longestNumberOfChars = line.Length;
}

// 2nd: pad all lines to a total length of 29
for (int i = 0; i < newLines.Length; i++)
{
    newLines[i] = newLines[i].PadRight(longestNumberOfChars);
}

// 3rd: Store new Numbers into new textfile
File.WriteAllLines(@"d:\projects\normalized.txt", newLines);

// Ersetze diese Zeile:
// int[][] numbers2d = new int[longestNumberOfChars][newLines.Length];



char[,] newLinesChar = new char[longestNumberOfChars, newLines.Length];
// convert strings in string array to character arrays

for(int i = 0; i < longestNumberOfChars; i++)
{
    for(int j = 0; j < newLines.Length; j++)
    {
        newLinesChar[i, j] = newLines[j].ElementAtOrDefault(i);
    }    
}

// use a [1+x, 4] Mask to isolate numbers where x depends on the subarray right of mask -> if there are chars != 0 then expand mask by one column to right

var listOfNumberArrays = ExtractNumbersAsSubArrays(newLinesChar);

// classify each subArray into a number

var results = classifySubArraysIntoNumbers(listOfNumberArrays);

for(int i = 0; i < results.Length; i++)
{
    Console.WriteLine(results[i]);
}