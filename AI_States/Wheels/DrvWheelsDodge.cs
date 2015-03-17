using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG4500_2015_Innlevering1.Robocode;
using Santom;


namespace PG4500_2015_Innlevering1.AI_States
{
	class DrvWheelsDodge : State
	{
		public DrvWheelsDodge() : base("Dodge")
		{

		}

		public override string ProcessState()
		{
			return "Idle";
		}
	}
}
