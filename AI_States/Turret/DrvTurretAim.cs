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
		private double calculateBearing(EnemyData e)
		{
			Vector2D target = new Vector2D(
				e.Position.X + e.Velocity * Math.Sin(e.HeadingRadians + e.TurnRateRadians),
				e.Position.Y + e.Velocity * Math.Cos(e.HeadingRadians + e.TurnRateRadians)
			);
			double targetRotation = Math.Atan2(target.X - Robot.X, target.Y - Robot.Y) * (180 / Math.PI);

			if (targetRotation > 0)
				return targetRotation - Robot.GunHeading;
			else
				return targetRotation - Robot.GunHeading + 360;
		}
		public override string ProcessState()
		{
			if (!IsGunTurning)
			{
				Robot.SetTurnGunRight(MathHelpers.normalizeBearing(calculateBearing(Robot.Enemy)));
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
