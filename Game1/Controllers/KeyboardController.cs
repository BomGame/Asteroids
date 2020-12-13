using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game1.Controllers
{
    public class KeyboardController : BaseController
    {
        private bool _flag=false;
        public KeyboardController(Game game) : base(game)
        {

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            KeyboardState keyboard = Keyboard.GetState();
            Keys[] pressedKeys = keyboard.GetPressedKeys();
            Vector2 delta = new Vector2(0, 0);

            foreach(var key in pressedKeys)
            {
                if(key==Keys.Right || key==Keys.D)
                {
                    delta.X = _subject.Speed;
                }
                if (key == Keys.Left || key == Keys.A)
                {
                    delta.X = _subject.Speed*-1;
                }
                if (key == Keys.Up || key == Keys.W)
                {
                    delta.Y = _subject.Speed*-1;
                }
                if (key == Keys.Down || key == Keys.S)
                {
                    delta.Y = _subject.Speed;
                }
                if(key==Keys.Space)
                {
                    _flag = true;
                }
            }
            if (_flag && keyboard.IsKeyUp(Keys.Space)) 
            {
                _subject.Shoot();
                _flag = false;
            }
            _subject.Move(delta);
        }
    }
}
