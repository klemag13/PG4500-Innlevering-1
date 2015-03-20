using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG4500_2015_Innlevering1.Robocode;
using Robocode;
using Santom;
using System.Drawing;

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

			// Approach until it's close enough then line up next to it
			if (Robot.Enemy.Distance > 200)
			{
				Robot.SetTurnRight(MathHelpers.normalizeBearing(Robot.Enemy.BearingDegrees));
				Robot.SetAhead(Robot.Enemy.Distance - 200);
			}
			else
			{
				Robot.SetTurnRight(MathHelpers.normalizeBearing(-Robot.Heading + Robot.Enemy.HeadingDegrees));
				Robot.SetAhead(20);
			}
			
		}


		public override string ProcessState()
		{
			_targetPosition = Robot.Enemy.Position;

			// Approach until it's close enough then line up next to it
			if (Robot.Enemy.Distance > 200)
			{
				Robot.SetTurnRight(MathHelpers.normalizeBearing(Robot.Enemy.BearingDegrees));
				Robot.SetAhead(Robot.Enemy.Distance - 200);
			}
			else
			{
				Robot.SetTurnRight(MathHelpers.normalizeBearing(-Robot.Heading + Robot.Enemy.HeadingDegrees));
				Robot.SetAhead(20);
			}
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
