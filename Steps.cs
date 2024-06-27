using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10263992_PROG_WPF
{
    public class Steps
    {
        public int StepCount { get; set; }
        public string StepDescription { get; set; }
        /// <summary>
        /// Constructor for steps class
        /// </summary>
        /// <param name="stepCount"></param>
        /// <param name="stepDescription"></param>
        public Steps(int stepCount, string stepDescription)
        {
            StepCount = stepCount;
            StepDescription = stepDescription;
        }
    }
}
//=========================================================== EndOfProgram ===========================================================//
