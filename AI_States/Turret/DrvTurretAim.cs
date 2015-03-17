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
		bool IsGunTurning = false;
		public DrvTurretAim() : base("Aim")
		{

		}

		public override string ProcessState()
		{
			// Do calculations
			if (!IsGunTurning)
			{
				Robot.SetTurnGunRight(MathHelpers.normalizeBearing(Robot.Heading - Robot.GunHeading + Robot.Enemy.BearingDegrees));
				IsGunTurning = true;
			}
			else if (Robot.GunTurnRemaining == 0.0)
				IsGunTurning = false;
			
			if (Robot.HasLock && Robot.GunHeat == 0.0 && !IsGunTurning) // and if the barrel is angeled correctly
				return "Fire";
			else if (Robot.HasLock)
				return "Aim";
			else
				return "Idle";
		}
	}
}
