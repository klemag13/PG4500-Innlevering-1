using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG4500_2015_Innlevering1.Robocode;
using Santom;

namespace PG4500_2015_Innlevering1.AI_States
{
	class DrvRadarSearch : State
	{
		public DrvRadarSearch() : base("Search")
		{

		}

		public override string ProcessState()
		{
			if (Robot.Enemy.Name == null) // We haven't seen the enemy yet
				Robot.SetTurnRadarRight(10);
			else // We lost the enemy, search in the direction of the last known position
			{
				// Get the angle between the radarheading and the robot.
				double angle = MathHelpers.normalizeBearing( -Robot.RadarHeading) + // X and Y are swappen in atan2 because of robocode's weird coordinate system.
						(Math.Atan2(Robot.Enemy.Position.X - Robot.X, Robot.Enemy.Position.Y - Robot.Y) * (180 / 3.1415));
				Robot.SetTurnRadarRight(angle);
			}
		
				//(Robot.Heading - Robot.GunHeading + Robot.Enemy.BearingDegrees)
			return null;
		}
	}
}
