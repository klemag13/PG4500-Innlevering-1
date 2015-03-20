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
		}


		public override string ProcessState()
		{
			// Add the points in a list
			Waypoint[] waypoints = { new Waypoint(Robot, new Point2D(Robot.Enemy.Position.X + 150, Robot.Enemy.Position.Y + 150)),
									 new Waypoint(Robot, new Point2D(Robot.Enemy.Position.X - 150, Robot.Enemy.Position.Y + 150)),
									 new Waypoint(Robot, new Point2D(Robot.Enemy.Position.X + 150, Robot.Enemy.Position.Y - 150)),
									 new Waypoint(Robot, new Point2D(Robot.Enemy.Position.X - 150, Robot.Enemy.Position.Y - 150)) };
			// Keep track of the best waypoint
			int waypointIndex = 0;

			for (int i = 1; i < 4; i++ )
			{
				Vector2D waypointToCenter = new Vector2D(waypoints[i].Destination.X - 400, waypoints[i].Destination.Y - 400);
				Vector2D bestWaypointToCenter = new Vector2D(waypoints[waypointIndex].Destination.X - 400, waypoints[waypointIndex].Destination.Y - 400);
				
				if (waypointToCenter.Length() < bestWaypointToCenter.Length())
					waypointIndex = i;
			}

			Robot.Seek(waypoints[waypointIndex].Destination);
			return "Idle";
		}
	}
}
