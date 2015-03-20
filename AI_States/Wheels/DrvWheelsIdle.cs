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
	public class DrvWheelsIdle : State
	{
		private Point2D _targetPosition;
		public DrvWheelsIdle() : base("Idle")
		{
			// Intentionally left blank.
		}


		public override string ProcessState()
		{

			return null;
		}
	}
}
