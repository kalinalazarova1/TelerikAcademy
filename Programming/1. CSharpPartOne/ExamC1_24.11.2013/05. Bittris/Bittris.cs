using System;

class Bittris
{
    static uint GetScorePiece(byte finalLine)
    {
        byte points = 0;
        for (int i = 0; i < 32; i++)
        {
            if (((fullPiece >> i) & 1) == 1)            //counts the bits equal to 1 in the input int
            {
                points++;
            }
        }
        if (field[finalLine] == 255)                //checks if the line is full with bits equal to 1
        {
            points = (byte)(points * 10);
            for (byte i = finalLine; i >= 1; i--)   //moves the lines down when the full line is deleted
            {
                field[i] = field[i - 1];
            }
            field[0] = 0;
        }
        return points;
    }

    static void MovePiece(byte piece)
    {
        byte line = 0;
        bool isFinal = false;
        for (byte i = 0; i < 3; i++)
        {
            char com = char.Parse(Console.ReadLine());      //always reads the commands from the console
            if (field[0] != 0 || line >= 3 || isFinal)      //executes the command only if: the piece
            {                                               //is not on the last line, or in its final position
                continue;                                   //or the first line is full
            }
            if (com == 'L')
            {
                if (((piece >> 7) & 1) != 1 && (field[line] & (piece << 1)) == 0)
                {
                    piece = (byte)(piece << 1);
                }
            }
            else if (com == 'R')
            {
                if ((piece & 1) != 1 && (field[line] & (piece << 1)) == 0)
                {
                    piece = (byte)(piece >> 1);
                }
            }
            if ((field[line + 1] & piece) == 0)
            {
                line++;
            }
            else
            {
                isFinal = true;
            }
        }       
        field[line] = (byte)(field[line] | piece);          //when the piece is in final position it is put in the field
        score += GetScorePiece(line);
        return;
    }

    static uint score = 0;
    static byte[] field;
    static int fullPiece;

    static void Main()
    {   
        field = new byte[4];
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n / 4; i++)
        {
            fullPiece = int.Parse(Console.ReadLine());
            MovePiece((byte)fullPiece);
        }
        Console.WriteLine(score);
    }
}