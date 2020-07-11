using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Radical.Management
{
    public class ResultsConduit
    {
        public static ResultsConduit PreviousState { get; set; } = new ResultsConduit(9_999_999);

        public int Score { get; set; }

        public ResultsConduit(int score)
        {
            Score = score;
        }
    }
}
