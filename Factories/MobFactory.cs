using Infrastructure.Living;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Living;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Factories
{
	public class MobFactory
	{
		private ContentManager _contentManager;

		public MobFactory(ContentManager contentManager)
		{
			_contentManager = contentManager;
		}
		public IMob CreatePlayer(string image,Rectangle bounds, float speed, float jumpStrength)
		{
			Player player = new Player(_contentManager.Load<Texture2D>(image), bounds, speed, jumpStrength);
			return player;
		}
	}
}
