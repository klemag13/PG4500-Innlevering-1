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

		public override void EnterState()
		{
			base.EnterState();
		}

		public override string ProcessState()
		{
			// Do calculations
			if (!IsGunTurning)
			{
				EnemyData e = Robot.Enemy;
				Vector2D aim;
				aim = new Vector2D(
					e.Position.X + e.Velocity * Math.Cos(e.HeadingRadians),
					e.Position.Y + e.Velocity * Math.Sin(e.HeadingRadians));
				//Robot.SetTurnGunRightRadians(Math.Atan2(aim.Y - Robot.X, aim.X - Robot.Y) - Robot.HeadingRadians);
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
		/*
		 * EnemyData e = Robot.Enemy;
			Vector2D aim;
			aim = new Vector2D(
				e.Position.X + e.Velocity * Math.Cos(e.HeadingDegrees), 
				e.Position.Y + e.Velocity * Math.Sin(e.HeadingDegrees));
			Robot.SetTurnGunRight(Math.Atan2(aim.X, aim.Y) - Robot.Heading);
		 */
	}
}
