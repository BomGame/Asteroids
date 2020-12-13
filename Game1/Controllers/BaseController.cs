using Microsoft.Xna.Framework;
using Game1.Abstracts;

namespace Game1.Controllers
{
    public abstract class BaseController : GameComponent
    {
        protected IPlayer _subject;

        public void Attach(IPlayer unit)
        {
            _subject = unit;
        }

        protected BaseController(Game game) : base(game)
        {
            game.Components.Add(this);
        }
    }
}
