using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.World
{
	public interface IWorld
	{
		Vector4 Boundaries { get; set; } //-x,+x,-y,+y
	}
}
