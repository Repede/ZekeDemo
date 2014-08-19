using Infrastructure.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.World
{
	public class FirstMap: IWorld
	{
		private Rectangle _bounds;
		private Vector4 _boundaries;
		private Texture2D _sprite;
		public Vector4 Boundaries
		{
			get { return _boundaries; }
			set 
			{
				_boundaries = value;
				_bounds = new Rectangle(0, 0, (int)Math.Round(_boundaries.Y - _boundaries.X), (int)Math.Round(_boundaries.Z - Boundaries.W));
			}
		}

		public Texture2D Sprite
		{
			get { return _sprite; }
			set { _sprite = value; }
		}

		public Rectangle Bounds
		{
			get { return _bounds; }
			set { _bounds = value; }
		}

		public FirstMap(Texture2D texture)
		{
			_boundaries = new Vector4(0, 1080, 670, 0);
			_bounds = new Rectangle(0, 0, (int)Math.Round(_boundaries.Y - _boundaries.X), (int)Math.Round(_boundaries.Z - Boundaries.W));
			_sprite = texture;
		}
	}
}
