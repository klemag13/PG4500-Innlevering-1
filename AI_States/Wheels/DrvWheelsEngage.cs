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

			// Check 8 points around the tank for a suitable position.
			if(Robot.Enemy.HeadingDegrees < 90 || Robot.Enemy.HeadingDegrees > 270) // Pick points on the north side, because the tank is facing north.
			{
				// Check which side is closest to a wall, and pick the opposite
				if (Robot.Enemy.Position.X <= 400) // He's closest to the left wall
				{
					Robot.Seek(new Point2D(Robot.Enemy.Position.X + 100, Robot.Enemy.Position.Y + 100));
				}
				else // right wall;
				{
					Robot.Seek(new Point2D(Robot.Enemy.Position.X - 100, Robot.Enemy.Position.Y + 100));

				}
			}
			else // Pick points on the south side.
			{
				// Check which side is closest to a wall, and pick the opposite
				if (Robot.Enemy.Position.X <= 400) // He's closest to the left wall
				{
					Robot.Seek(new Point2D(Robot.Enemy.Position.X + 100, Robot.Enemy.Position.Y - 100));
				}
				else // right wall;
				{
					Robot.Seek(new Point2D(Robot.Enemy.Position.X - 100, Robot.Enemy.Position.Y - 100));
				}
			}			
		}


		public override string ProcessState()
		{
			_targetPosition = Robot.Enemy.Position;

			// Add the points in a list
			Waypoint[] waypoints = { new Waypoint(Robot, new Point2D(Robot.Enemy.Position.X + 100, Robot.Enemy.Position.Y + 100)),
									 new Waypoint(Robot, new Point2D(Robot.Enemy.Position.X + 100, Robot.Enemy.Position.Y + 100)),
									 new Waypoint(Robot, new Point2D(Robot.Enemy.Position.X + 100, Robot.Enemy.Position.Y + 100)),
									 new Waypoint(Robot, new Point2D(Robot.Enemy.Position.X + 100, Robot.Enemy.Position.Y + 100))
								   };
			// Keep track of the best waypoint
			int waypointIndex = 0;

			for (int i = 0; i < 4; i++ )
			{
				// Is the point on the map?
				if (waypoints[i].Destination.X > 0 && waypoints[i].Destination.X < 800 &&
					waypoints[i].Destination.Y > 0 && waypoints[i].Destination.Y < 800)
				{
					if((Robot.Enemy.BearingDegrees <= 90 || Robot.Enemy.BearingDegrees >= 270) && waypoints[i].Destination.Y > Robot.Enemy.Position.Y)
					{
						//if(Robot.Enemy.Position.X )
					}
				}

			}
			// Approach until it's close enough then line up next to it
			if ((Robot.Enemy.HeadingDegrees <= 90 || Robot.Enemy.HeadingDegrees >= 270) && Robot.Enemy.Position.Y + 100 < 600 ) // Pick points on the north side, because the tank is facing north.
			{
				// Check which side is closest to a wall, and pick the opposite
				if (Robot.Enemy.Position.X <= 400) // He's closest to the left wall
				{
					Robot.Seek(new Point2D(Robot.Enemy.Position.X + 100, Robot.Enemy.Position.Y + 100));
				}
				else // right wall;
				{
					Robot.Seek(new Point2D(Robot.Enemy.Position.X - 100, Robot.Enemy.Position.Y + 100));

				}
			}
			else // Pick points on the south side.
			{
				// Check which side is closest to a wall, and pick the opposite
				if (Robot.Enemy.Position.X <= 400) // He's closest to the left wall
				{
					Robot.Seek(new Point2D(Robot.Enemy.Position.X + 100, Robot.Enemy.Position.Y - 100));
				}
				else // right wall;
				{
					Robot.Seek(new Point2D(Robot.Enemy.Position.X - 100, Robot.Enemy.Position.Y - 100));
				}
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
