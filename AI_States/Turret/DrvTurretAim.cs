using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG4500_2015_Innlevering1.Robocode;
using Santom;


namespace PG4500_2015_Innlevering1.AI_States
{
	class DrvTurretAim : State
	{
		
		public DrvTurretAim() : base("Aim")
		{

		}

		public override string ProcessState()
		{
			Robot.SetTurnGunRight(MathHelpers.normalizeBearing(Robot.Heading - Robot.GunHeading + Robot.Enemy.BearingDegrees));

			// Do calculations
			if(Robot.GunHeat == 0 && Robot.GunTurnRemaining == 0) // and if the barrel is angeled correctly
				return "Fire";
			return "Idle";
		}
	}
}
