using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG4500_2015_Innlevering1.Robocode;
using Robocode;
using Santom;


namespace PG4500_2015_Innlevering1.AI_States
{
	class DrvTurretAim : State
	{
		bool IsGunTurning = false;
		public DrvTurretAim() : base("Aim")
		{

		}

		private Vector2D constrain(Vector2D v)
		{
			v.X = MathHelpers.Clamp(v.X, 0, Robot.BattleFieldWidth);
			v.Y = MathHelpers.Clamp(v.Y, 0, Robot.BattleFieldHeight);
			return v;
		}

		private double calculateBearing(EnemyData e, int t, double fireThreshold)
		{
			int n;
			double bVelocity = 20 - 3 * Rules.MAX_BULLET_POWER;
			double eDistance = 0, bDistance = 0;
			Vector2D target = new Vector2D(e.Position.X, e.Position.Y);
			for (n = 0; n <= t; n++)
			{
				target.X += e.Velocity*Math.Sin(e.HeadingRadians + e.TurnRateRadians * n);
				target.Y += e.Velocity*Math.Cos(e.HeadingRadians + e.TurnRateRadians * n);
				constrain(target);
				eDistance = new Vector2D(Robot.X, Robot.Y).Distance(target);
				bDistance = bVelocity * n;
				if (bDistance > eDistance)
					break;
			}
			Robot.DrawLineAndTarget(Color.Gold, new Point2D(target - 1), new Point2D(target + 1));
			double targetRotation = Math.Atan2(target.X - Robot.X, target.Y - Robot.Y) * (180 / Math.PI);
			
			if (targetRotation > 0)
				Robot.SetTurnGunRight(MathHelpers.normalizeBearing(targetRotation - Robot.GunHeading));
			else
				Robot.SetTurnGunRight(MathHelpers.normalizeBearing(targetRotation - Robot.GunHeading + 360));
			if (n == t || eDistance > fireThreshold)
				return -1;
			else
				return (eDistance/bDistance)*Rules.MAX_BULLET_POWER;
		}
		double bulletPower = 0;
		long fireTime = 0;
		public override string ProcessState()
		{
			
			if (fireTime == Robot.Time && 
				MathHelpers.IsCloseToZero(Robot.GunTurnRemaining) && 
				bulletPower > 0 &&
				Robot.GunHeat == 0)
			{
				Robot.SetFire(bulletPower);
				Robot.Out.WriteLine("Firing with bullet power " + Math.Round(bulletPower*1000)/1000);
			}
			bulletPower = calculateBearing(Robot.Enemy, 100, Robot.FireThreshold);
			fireTime = Robot.Time + 1;
			return null;
			/*if (!IsGunTurning)
			{
				Robot.SetTurnGunRight(MathHelpers.normalizeBearing(calculateBearing(Robot.Enemy, 40)));
				IsGunTurning = true;
			}
			else if (Robot.GunTurnRemaining == 0.0)
				IsGunTurning = false;
			
			if (Robot.HasLock && Robot.GunHeat == 0.0 && !IsGunTurning) // and if the barrel is angeled correctly
				return "Fire";
			else if (Robot.HasLock)
				return "Aim";
			else
				return "Idle";*/
		}
	}
}
