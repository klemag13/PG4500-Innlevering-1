using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleSetup.Robocode;

namespace ExampleSetup.AI_States
{
	class DrvTurretFire : State
	{
		public DrvTurretFire() : base("Fire")
		{

		}

		public override void EnterState()
		{
			base.EnterState();
			Robot.SetFireBullet(3);
		}

		public override string ProcessState()
		{
			return "Aim";
		}
	}
}
