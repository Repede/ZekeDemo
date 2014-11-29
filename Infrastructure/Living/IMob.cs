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
		SpriteEffects SpriteEffects { get; set; }
		Rectangle Bounds { get; set; }
		Rectangle SourceBounds { get; set; }
		Vector2 Velocity { get; set; } // <LEFT/RIGHT, UP/DOWN>
		Single FoV { get; set; }
		Single Speed { get; set; }
		Single JumpStrength { get; set; }

		void Move(GameTime gameTime, Vector4 worldBoundaries);
	}
}