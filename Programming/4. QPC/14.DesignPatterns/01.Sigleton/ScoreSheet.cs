namespace _01.Sigleton
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public sealed class ScoreSheet
    {
        private const int MaxCount = 5;

        private List<Score> topScores;

        static ScoreSheet()
        {
            Instance = new ScoreSheet();
        }

        private ScoreSheet()
        {
            this.topScores = new List<Score>();
            this.topScores.Capacity = ScoreSheet.MaxCount;
        }

        public static ScoreSheet Instance { get; private set; }

        public override string ToString()
        {
            var output = new List<string>();
            for (int i = 0; i < this.topScores.Count; i++)
            {
                output.Add((i + 1) + ". " + this.topScores[i].ToString());
            }

            return string.Join(Environment.NewLine, output);
        }

        internal void Add(Score score)
        {
            if (this.topScores.Count == this.topScores.Capacity && this.topScores[this.topScores.Count - 1].Points < score.Points)
            {
                this.topScores[this.topScores.Count - 1] = score;
            }
            else
            {
                this.topScores.Add(score);
            }

            this.topScores.Sort();
            this.topScores.Reverse();
        }
    }
}
