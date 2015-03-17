using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleSetup.Robocode;

namespace ExampleSetup.AI_States
{
	class DrvRadarLock : State
	{
		public DrvRadarLock() : base("Lock")
		{

		}

		public override string ProcessState()
		{
			return "Search";
		}
	}
}
