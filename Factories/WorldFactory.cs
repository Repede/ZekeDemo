using Domain.World;
using Infrastructure.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Factories
{
	public class WorldFactory
	{
		public IWorld CreateWorld()
		{
			FirstMap map = new FirstMap();
			return map;
		}
	}
}
