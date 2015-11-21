using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.World
{
	public interface IWorld : IDisposable
	{
		Texture2D Sprite { get; set; }
		Vector4 Boundaries { get; set; } //-x,+x,-y,+y
		Rectangle Bounds { get; set; }

	}
}
