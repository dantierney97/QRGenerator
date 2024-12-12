using System.Drawing;
using System;

namespace QRGenerator.Services;

public class QrEncoder
{
    private const int moduleSize = 10; // Size of each square in the QR Code

    public Bitmap GenerateQRCode(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
        {
            throw new ArgumentException("Input cannot be null or whitespace", nameof(content));
        }

        int matrixSize = 177; // Sets the size of the QR Code. This uses Ver.44 of the Qr Standard
        
        bool[,] matrix = new bool[matrixSize, matrixSize]; // Initialise the matrix
        
        // Adding Finder Patterns
        AddFinderPattern(matrix, 0, 0);
        AddFinderPattern(matrix, matrixSize - 7, 0);
        AddFinderPattern(matrix, 0, matrixSize - 7);
        
        // Add timing patters
        AddTimingPatterns(matrix, matrixSize);
        
        // Encode the data into binary
        string binaryData = StringToBinary(content);
    }
    
    // Method for adding finder patters to the matrix
    private void AddFinderPattern(bool[,] matrix, int startX, int startY)
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                matrix[startX + i, startY + j] = (i == 0 || i == 6 || j == 0 || j == 6 || (i >= 2 && i <= 4 && j >= 2 && j <= 4));
            }
        }
    }
    
    private void AddTimingPatterns(bool[,] matrix, int size)
    {
        for (int i = 8; i < size - 8; i++)
        {
            // Horizontal line
            matrix[6, i] = i % 2 == 0;
            // Vertical line
            matrix[i, 6] = i % 2 == 0;
        }
    }
    
    private string StringToBinary(string input)
    {
        byte[] bytes = System.Text.Encoding.ASCII.GetBytes(input);
        return string.Join(string.Empty, Array.ConvertAll(bytes, b => Convert.ToString(b, 2).PadLeft(8, '0')));
    }
}