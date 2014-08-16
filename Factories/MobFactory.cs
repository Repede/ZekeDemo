using Infrastructure.Living;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Living;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Factories
{
	public class MobFactory
	{
		public IMob CreatePlayer(Texture2D image,Rectangle bounds, float speed, float jumpStrength)
		{
			Player player = new Player(image, bounds, speed, jumpStrength);
			return player;
		}
	}
}
