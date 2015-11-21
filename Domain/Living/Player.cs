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
	public class Player : IMob
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

		public SpriteEffects SpriteEffects
		{
			get
			{
				return _spriteEffects;
			}
			set
			{
				_spriteEffects = value;
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

		public Rectangle SourceBounds
		{
			get
			{
				return _sourceBounds;
			}
			set
			{
				_sourceBounds = value;
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

		private const int LEFT = 0;
		private const int RIGHT = 1;

		private Texture2D _sprite;
		private SpriteEffects _spriteEffects;
		private Rectangle _bounds;
		private Rectangle _sourceBounds;
		private int _widthFrames = 2;
		private int _heightFrames = 3;
		private int _curMovFrame = 0;
		private int _shittyTimer = 0;
		private int _lastDirection = LEFT;
		private Vector2 _velocity;
		private float _fov;
		private float _speed;
		private float _accel;
		private float _jumpStrength;
		private bool _onGround;

		private bool _keySpace = false;
		//private bool _keyDown = false;
		private bool _keyRight = false;
		private bool _keyLeft = false;

		public Player(Texture2D sprite, Rectangle bounds, float speed, float jumpStrength)
		{
			_sprite = sprite;
			_bounds = bounds;
			_sourceBounds = new Rectangle(0, 0, sprite.Width / _widthFrames, sprite.Height / _heightFrames);
			_speed = 10;
			_accel = (float)0.95;
			_jumpStrength = 20;
			_velocity = new Vector2(0, 0);
			_onGround = true;
			_spriteEffects = SpriteEffects.None;
		}

		public void Dispose()
		{
			_sprite.Dispose();
		}

		public void Move(GameTime gameTime, Vector4 worldBoundaries)
		{
			getKeys();
			if (_keyLeft)
			{
				_lastDirection = LEFT;
				_velocity.X -= _accel;
				if (_velocity.X < -_speed)
				{
					_velocity.X = -_speed;
				}
				Console.WriteLine(_velocity.X);
			}
			else if (_keyRight)
			{
				_lastDirection = RIGHT;
				_velocity.X += _accel;
				if (_velocity.X > _speed)
				{
					_velocity.X = _speed;
				}
				Console.WriteLine(_velocity.X);
			}
			else
			{
				if (_velocity.X > 0)
				{
					_velocity.X -= 1;
					if (_velocity.X < 0)
					{
						_velocity.X = 0;
					}
				}
				else if (_velocity.X < 0)
				{
					_velocity.X += 1;
					if (_velocity.X > 0)
					{
						_velocity.X = 0;
					}
				}
			}

			if (_keySpace)
			{
				Jump();
			}
			CalculateGravity();
			_bounds.X = _bounds.X + (int)Math.Round(_velocity.X, MidpointRounding.AwayFromZero);
			_bounds.Y = _bounds.Y + (int)Math.Round(_velocity.Y, MidpointRounding.AwayFromZero);
			CheckBounds(worldBoundaries);
			updateAnimation();
		}

		private void updateAnimation()
		{
			if (_lastDirection == LEFT)
			{
				_spriteEffects = SpriteEffects.FlipHorizontally;
			}
			else
			{
				_spriteEffects = SpriteEffects.None;
			}

			if (_velocity.Y < 0) //Going up
			{
				_sourceBounds = new Rectangle(_sourceBounds.Width * 0, _sourceBounds.Height * 1, _sourceBounds.Width, _sourceBounds.Height);
			}
			else if (_velocity.Y > 0) //Going down
			{
				_sourceBounds = new Rectangle(_sourceBounds.Width * 1, _sourceBounds.Height * 1, _sourceBounds.Width, _sourceBounds.Height);
			}
			else
			{
				if (_velocity.X > 0)
				{
					_sourceBounds = new Rectangle(_sourceBounds.Width * _curMovFrame, _sourceBounds.Height * 2, _sourceBounds.Width, _sourceBounds.Height);
				}
				else if (_velocity.X < 0)
				{
					_sourceBounds = new Rectangle(_sourceBounds.Width * _curMovFrame, _sourceBounds.Height * 2, _sourceBounds.Width, _sourceBounds.Height);
				}
				else if (_velocity.X == 0)
				{
					_sourceBounds = new Rectangle(0, 0, _sourceBounds.Width, _sourceBounds.Height);
					_curMovFrame = 0;
				}
				_shittyTimer++;
				if (_shittyTimer > 10)
				{
					_curMovFrame++;
					if (_curMovFrame > 1)
					{
						_curMovFrame = 0;
					}
					_shittyTimer = 0;
				}
			}
		}

		private void CheckBounds(Vector4 worldBoundaries)
		{
			if (_bounds.X < worldBoundaries.X)
			{
				_velocity.X = 0;
				_bounds.X = (int)Math.Round(worldBoundaries.X, MidpointRounding.AwayFromZero);
			}
			if (_bounds.X + _bounds.Width > worldBoundaries.Y)
			{
				_velocity.X = 0;
				_bounds.X = (int)Math.Round(worldBoundaries.Y, MidpointRounding.AwayFromZero) - _bounds.Width;
			}
			if (_bounds.Y + _bounds.Height > worldBoundaries.Z)
			{
				_velocity.Y = 0;
				_bounds.Y = (int)Math.Round(worldBoundaries.Z, MidpointRounding.AwayFromZero) - _bounds.Height;
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
			_velocity.Y = _velocity.Y + 1f;
			if (_velocity.Y >= 15)
			{
				_velocity.Y = 15;
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
			if (_velocity.Y == 0 && _onGround)
			{
				_velocity.Y = -_jumpStrength;
				_onGround = false;
			}
		}
	}
}
