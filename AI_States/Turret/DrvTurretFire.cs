using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG4500_2015_Innlevering1.Robocode;

namespace PG4500_2015_Innlevering1.AI_States
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
