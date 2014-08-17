using Infrastructure.World;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.World
{
	public class FirstMap: IWorld
	{
		public Vector4 Boundaries
		{
			get { return _boundaries; }
			set { _boundaries = value; }
		}

		private Vector4 _boundaries;

		public FirstMap()
		{
			_boundaries = new Vector4(0, 1080, 670, 0);
		}
	}
}
