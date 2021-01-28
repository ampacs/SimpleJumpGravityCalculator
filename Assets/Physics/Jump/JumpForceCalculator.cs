using UnityEngine;

namespace Physics.Jump
{
    public static class JumpForceCalculator
    {
        public static float GetJumpForce(float gravity, float jumpHeight, float mass = 1f)
        {
            gravity    = Mathf.Max(gravity,    0);
            jumpHeight = Mathf.Max(jumpHeight, 0);
            mass       = Mathf.Max(mass,       0);

            return Mathf.Sqrt(2 * gravity * jumpHeight) * mass;
        }
    }
}
