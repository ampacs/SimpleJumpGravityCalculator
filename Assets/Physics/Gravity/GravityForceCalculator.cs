using UnityEngine;

namespace Physics.Gravity
{
    public static class GravityForceCalculator
    {
        private const float MinimumDeviation = 1e-5f;

        public static GravityForce GetGravityForce (float jumpHeight, float jumpTime, float jumpApexFraction = .5f)
        {
            jumpHeight = Mathf.Max(jumpHeight, 0);
            jumpApexFraction = Mathf.Clamp(jumpApexFraction, MinimumDeviation, 1f - MinimumDeviation);

            float upwards   = GetForce(jumpHeight, jumpTime, jumpApexFraction);
            float downwards = GetForce(jumpHeight, jumpTime, 1 - jumpApexFraction);

            return new GravityForce(upwards, downwards);
        }

        private static float GetForce(float jumpHeight, float jumpTime, float jumpApexFraction)
        {
            return 2 * jumpHeight / (jumpTime * jumpTime * jumpApexFraction * jumpApexFraction);
        }
    }
}
