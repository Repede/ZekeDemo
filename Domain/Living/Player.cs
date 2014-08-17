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

		public Vector2 Velocity
		{
			get { return _velocity; }
			set { _velocity = value; }
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
		private Vector2 _velocity;
		private float _fov;
		private float _speed;
		private float _accel;
		private float _jumpStrength;
		private bool _onGround;

		private bool _keySpace = false;
		private bool _keyDown = false;
		private bool _keyRight = false;
		private bool _keyLeft = false;

		public Player(Texture2D sprite, Rectangle bounds, float speed, float jumpStrength)
		{
			_sprite = sprite;
			_bounds = bounds;
			_speed = 10;
			_accel = (float)0.5;
			_jumpStrength = 20;
			_velocity = new Vector2(0, 0);
			_onGround = true;
		}

		public void Move(GameTime gameTime, Vector4 worldBoundaries)
		{
			getKeys();
			if(_keyLeft)
			{
				_velocity.X -= _accel;
				if(_velocity.X < -_speed)
				{
					_velocity.X = -_speed;
				}
				Console.WriteLine(_velocity.X);
			}
			else if(_keyRight)
			{
				_velocity.X += _accel;
				if (_velocity.X > _speed)
				{
					_velocity.X = _speed;
				}
				Console.WriteLine(_velocity.X);
			}
			else
			{
				if(_velocity.X > 0)
				{
					_velocity.X -= 1;
					if(_velocity.X < 0)
					{
						_velocity.X = 0;
					}
				}
				else if(_velocity.X < 0)
				{
					_velocity.X += 1;
					if (_velocity.X > 0)
					{
						_velocity.X = 0;
					}
				}
			}
			
			if(_keySpace)
			{
				Jump();
			}
			CalculateGravity();
			_bounds.X = _bounds.X + (int)Math.Round(_velocity.X, MidpointRounding.AwayFromZero);
			_bounds.Y = _bounds.Y + (int)Math.Round(_velocity.Y, MidpointRounding.AwayFromZero);
			CheckBounds(worldBoundaries);
		}

		private void CheckBounds(Vector4 worldBoundaries)
		{
			if (_bounds.X < worldBoundaries.X)
			{
				_velocity.X = 0;
				_bounds.X = (int)Math.Round(worldBoundaries.X, MidpointRounding.AwayFromZero);
			}
			if (_bounds.X > worldBoundaries.Y)
			{
				_velocity.X = 0;
				_bounds.X = (int)Math.Round(worldBoundaries.Y, MidpointRounding.AwayFromZero);
			}
			if (_bounds.Y > worldBoundaries.Z)
			{
				_velocity.Y = 0;
				_bounds.Y = (int)Math.Round(worldBoundaries.Z, MidpointRounding.AwayFromZero);
				_onGround = true;
			}
			if (_bounds.Y < worldBoundaries.W)
			{
				_velocity.Y = 0;
				_bounds.Y = (int)Math.Round(worldBoundaries.W, MidpointRounding.AwayFromZero);
			}
		}

		private void CalculateGravity()
		{
			_velocity.Y = _velocity.Y + (float)0.50;
			if(_velocity.Y >= 10)
			{
				_velocity.Y = 10;
			}
		}

		private void getKeys()
		{
			KeyboardState key = Keyboard.GetState();
			if (key.IsKeyDown(Keys.Space) || key.IsKeyDown(Keys.W))
			{
				_keySpace = true;
			}
			else
			{
				_keySpace = false;
			}
			if (key.IsKeyDown(Keys.D) || key.IsKeyDown(Keys.D))
			{
				_keyRight = true;
			}
			else
			{
				_keyRight = false;
			}
			if (key.IsKeyDown(Keys.A) || key.IsKeyDown(Keys.A))
			{
				_keyLeft = true;
			}
			else
			{
				_keyLeft = false;
			}
		}

		private void Jump()
		{
			if(_velocity.Y == 0 && _onGround)
			{
				_velocity.Y = -_jumpStrength;
				_onGround = false;
			}
		}
	}
}
