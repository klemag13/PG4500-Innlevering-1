using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleSetup.Robocode;

namespace ExampleSetup.AI_States
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
			return null;
		}

	}
}
