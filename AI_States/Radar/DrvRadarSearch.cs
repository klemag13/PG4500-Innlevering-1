using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleSetup.Robocode;

namespace ExampleSetup.AI_States
{
	class DrvRadarSearch : State
	{
		public DrvRadarSearch() : base("Search")
		{

		}

		public override string ProcessState()
		{
			// TODO: Students, make better code for turning radar, right?
			Robot.SetTurnRadarRight(10);
			return null;
		}
	}
}
