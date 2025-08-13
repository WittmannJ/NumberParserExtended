// See https://aka.ms/new-console-template for more information

using static StringNormalizer.StringNormalizer;

var filename = "NumberParserExtended.txt";

string contents = File.ReadAllText(filename);
Console.WriteLine(contents);

// find line with the longest line length aka the most characters
// -> use this line to replace the tabstops correctly => does not work anymore if there are more
// than one tabstop in a line

string[] lines = File.ReadAllLines(filename);

string[] newLines = new string[lines.Length];

for (int i = 0; i < lines.Length; i++)
{
    newLines[i] = ReplaceTabstopsInStringWithWhitespaces(lines[i]);
}

foreach(var line in newLines)
{
    Console.WriteLine(line);
}


