using Microsoft.Xna.Framework;

namespace Game1.Abstracts
{
    public interface IHavePositionDirection
    {
        float Direction { get; set; }

        float Speed { get; set; }

        void Move(Vector2 delta);

        void SetPosition(int x, int y);
    }
}
