using UnityEngine;

namespace Rocket
{
    public class Rocket
    {
        public readonly Sprite[] Parts;

        public Rocket(Sprite[] parts)
        {
            Parts = parts;
        }
    }
}