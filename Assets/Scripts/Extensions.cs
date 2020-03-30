using UnityEngine;

namespace Behaviors
{
    public static class Extensions
    {
        public static Vector2 ToVector2XY(this Vector3 v)
        {
            return new Vector2(v.x, v.y);
        }
    }
}