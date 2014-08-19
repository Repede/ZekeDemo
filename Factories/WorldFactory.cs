using Domain.World;
using Infrastructure.World;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Factories
{
	public class WorldFactory
	{
		private ContentManager _contentManager;
		public WorldFactory(ContentManager contentManager)
		{
			_contentManager = contentManager;
		}
		public IWorld CreateWorld(string image)
		{
			FirstMap map = new FirstMap(_contentManager.Load<Texture2D>(image));
			return map;
		}
	}
}
