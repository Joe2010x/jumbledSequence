
using System;

namespace JumbledSequence
{
    internal class Program
    {
        public static string PrintOut<T> (T[] input) {
                return "[ " + String.Join(" ,", input) + " ]";
            }
        public static int CountNeg (string[] input) {
            var count = 0;
            foreach (var item in input)
            {
                if (item.Trim() == "-") count ++;
            }
            return count;
        }
        
        public static int[] NatureSeq (int length) {
            var result = new int[length];
            for (var i=0; i<length;i++){
                result[i]=i;
            }
            return result;
        }

        public static int NextPosition (string sign, int prevPosition, int[] natureSeq) {
            var position = prevPosition;
            if (sign == "+" )// go up 
            {
                do {
                    position ++;
                    if (natureSeq[position] >= 0) return position;
                } while (position < natureSeq.Length);
            }
            else // go down
            {
                 do {
                    position --;
                    if (natureSeq[position] >= 0) return position;
                } while (position > 0);
            }
            return -1;
        }
        public static int[] ProducedSeq (int[] natureSeq, string[] sequence, int startPosition){
            var result = new List<int>();
            var position = -1;
            foreach (var sign in sequence)
            {
                if (sign.Trim() == "none") position = startPosition;
                else position = NextPosition(sign, position, natureSeq);
                result.Add(natureSeq[position]);
                natureSeq[position] = -1;
            }
            return result.ToArray();
        }

        static void Main(string[] args)
        {        
            var sequence = new string [] {"none","+","+","-","+","-"};
            var length = sequence.Length;
            var countNeg = CountNeg(sequence);
            var natureSeq = NatureSeq(length);
            Console.WriteLine(PrintOut<int>(ProducedSeq(natureSeq, sequence, countNeg)));
        }
    }
}