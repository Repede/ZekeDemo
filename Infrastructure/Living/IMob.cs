using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Living
{
	public interface IMob
	{
		Texture2D Sprite { get; set; }
		Rectangle Bounds { get; set; }
		Single FoV { get; set; }
		Single Speed { get; set; }
		Single JumpStrength { get; set; }
	}
}