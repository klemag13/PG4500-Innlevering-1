using System.Drawing;
using PG4500_2015_Innlevering1.Robocode;
using Santom;

namespace PG4500_2015_Innlevering1.AI_States
{
	public class DrvWheelsEngage : State
	{
		private Point2D _targetPosition;


		public DrvWheelsEngage() : base("Engage")
		{
			// Intentionally left blank.
		}


		// Called once when we transition into this state.
		public override void EnterState()
		{
			base.EnterState();

			_targetPosition = Robot.Enemy.Position;

	
			Robot.SetTurnRight(MathHelpers.normalizeBearing(Robot.Enemy.BearingDegrees));
			Robot.SetTurnGunRight(MathHelpers.normalizeBearing(Robot.Heading - Robot.GunHeading + Robot.Enemy.BearingDegrees));
			Robot.SetAhead(200);
			
		}


		public override string ProcessState()
		{
			string retState = null;
			if (Robot.DistanceCompleted()) {
				retState = "Idle";
			} else {
				Robot.DrawLineAndTarget(Color.LightGreen, new Point2D(Robot.X, Robot.Y), _targetPosition);
			}

			return retState;
		}
	}
}
