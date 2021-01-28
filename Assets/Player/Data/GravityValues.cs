using UnityEngine;

namespace Player.Data
{
    [CreateAssetMenu(fileName = "GravityValues", menuName = "GravityValues", order = 0)]
    public class GravityValues : ScriptableObject
    {
        public Vector2 upwards;
        public Vector2 downwards;
    }
}
