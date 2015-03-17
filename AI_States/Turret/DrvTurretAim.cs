using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleSetup.Robocode;

namespace ExampleSetup.AI_States
{
	class DrvTurretAim : State
	{
		public DrvTurretAim() : base("Aim")
		{

		}

		public override string ProcessState()
		{
			// Do calculations
			if(Robot.GunHeat == 0)
				return "Fire";
			return "Idle";
		}
	}
}
