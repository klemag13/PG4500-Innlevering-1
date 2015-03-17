using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG4500_2015_Innlevering1.Robocode;

namespace PG4500_2015_Innlevering1.AI_States
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
