using PG4500_2015_Innlevering1.Robocode;
using Santom;

namespace PG4500_2015_Innlevering1.AI_States
{
	class DrvTurrentIdle : State
	{
		public DrvTurrentIdle() : base("Idle")
		{

		}

		public override void EnterState()
		{
			base.EnterState();
		}
		public override string ProcessState()
		{
			Robot.SetTurnGunRight(MathHelpers.normalizeBearing(Robot.RadarHeading - Robot.GunHeading));
			return null;
		}

	}
}
