using System;
using System.Drawing;
using ExampleSetup.AI_States;
using ExampleSetup.Robocode;
using Robocode;
using Robocode.Util;
using Santom;

// ReSharper disable once CheckNamespace
namespace PG4500_2015_Innlevering1
{
	// ReSharper disable once InconsistentNaming
	public class klemag_DumBot : AdvancedRobotEx
	{
		// P R I V A T E / P R O T E C T E D   V A R S
		// -------------------------------------------

		private readonly FiniteStateMachine _radarFSM;
		private readonly FiniteStateMachine _turretFSM;
		private readonly FiniteStateMachine _wheelsFSM;


		// P U B L I C   M E T H O D S 
		// ---------------------------

		public klemag_DumBot()
		{
			// Defining the possible states for this fsm. (Also, the 1st one listed becomes the default state.)
			_radarFSM = new FiniteStateMachine(new State[] { new DrvRadarSearch(), new DrvRadarLock() });
			_turretFSM = new FiniteStateMachine(new State[] { new DrvTurrentIdle(), new DrvTurretAim(), new DrvTurretFire() });
			_wheelsFSM = new FiniteStateMachine(new State[] { new DrvWheelsIdle(), new DrvWheelsDodge(), new DrvWheelsEngage() });
		}


		public override void Run()
		{
			InitBot();
			int a = 1;
			// Loop forever. (Exiting run means no more robot fun for us!)
			while (true) {

				// The state machine doing its "magic".
				_radarFSM.Update();
				_turretFSM.Update();
				_wheelsFSM.Update();

				// Execute any current actions. NOTE: This sometimes triggers a blocking call internally, so this should be the last thing we do in a turn!
				Execute();
			}
			// ReSharper disable once FunctionNeverReturns
		}


		public override void OnScannedRobot(ScannedRobotEvent scanData)
		{
			// Storing data about scan time and Enemy for later use.
			Vector2D offset = CalculateTargetVector(HeadingRadians, scanData.BearingRadians, scanData.Distance);
			Point2D position = new Point2D(offset.X + X, offset.Y + Y);
			Enemy.SetEnemyData(scanData, position);

			// If we're out of energy, don't bother swapping states, as that will just make runtime bugs.
			if (!Energy.IsCloseToZero()) {
				_wheelsFSM.Queue("Engage", false);
				_turretFSM.Queue("Aim", false);
				_radarFSM.Queue("Lock", false);
			}
		}


		// P R I V A T E   M E T H O D S
		// -----------------------------

		// Inits robot stuff (color and such).
		private void InitBot()
		{
			// Init the FSM.
			_radarFSM.Init(this);
			_turretFSM.Init(this);
			_wheelsFSM.Init(this);

			// Set some colors on our robot. (Body, gun, radar, bullet, and scan arc.)
			SetColors(Color.LightSlateGray, Color.DimGray, Color.Gray, Color.White, Color.LightPink);

			// NOTE: Total distance each element can move remains the same, whether these ones are true or false. 
			//       Example: Gun swivels a maximum of 20 degrees in addition to what the body swivels (if anything) 
			//       each turn, no matter what IsAdjustGunForRobotTurn is set to.
			IsAdjustGunForRobotTurn = true;
			IsAdjustRadarForGunTurn = true;
		}


		/// <summary>
		/// Method to find Vector2D from Robot to Target, according to the battlefield coordinate system.
		/// </summary>
		private Vector2D CalculateTargetVector(double ownHeadingRadians, double bearingToTargetRadians, double distance)
		{
			double battlefieldRelativeTargetAngleRadians = Utils.NormalRelativeAngle(ownHeadingRadians + bearingToTargetRadians);
			Vector2D targetVector = new Vector2D(Math.Sin(battlefieldRelativeTargetAngleRadians) * distance,
												 Math.Cos(battlefieldRelativeTargetAngleRadians) * distance);
			return targetVector;
		}


	}
}
