using UnityEngine;

namespace Player.Data
{
    [CreateAssetMenu(fileName = "JumpValues", menuName = "JumpValues", order = 0)]
    public class JumpValues : ScriptableObject
    {
        public float height;
        public float time;

        [Range(0, 1)] public float jumpApexOverTime;

        private void OnValidate()
        {
            if (height < 0) height = 0;
            if (time < 0) time = 0;
        }
    }
}
