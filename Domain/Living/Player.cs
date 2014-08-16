using Infrastructure.Living;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Living
{
	public class Player: IMob
	{

		public Texture2D Sprite
		{
			get
			{
				return _sprite;
			}
			set
			{
				_sprite = value;
			}
		}

		public Rectangle Bounds
		{
			get
			{
				return _bounds;
			}
			set
			{
				_bounds = value;
			}
		}

		public float FoV
		{
			get
			{
				return _fov;
			}
			set
			{
				_fov = value;
			}
		}

		public float Speed
		{
			get
			{
				return _speed;
			}
			set
			{
				_speed = value;
			}
		}

		public float JumpStrength
		{
			get
			{
				return _jumpStrength;
			}
			set
			{
				_jumpStrength = value;
			}
		}

		private Texture2D _sprite;
		private Rectangle _bounds;
		private float _fov;
		private float _speed;
		private float _jumpStrength;

		public Player(Texture2D sprite, Rectangle bounds, float speed, float jumpStrength)
		{
			_sprite = sprite;
			_bounds = bounds;
			_speed = speed;
			_jumpStrength = jumpStrength;
		}

		public void Move(GameTime gameTime)
		{
			Keyboard.GetState();
		}
	}
}
