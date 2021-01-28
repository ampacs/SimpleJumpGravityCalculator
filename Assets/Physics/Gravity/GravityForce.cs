namespace Physics.Gravity
{
    public readonly struct GravityForce
    {
        public readonly float Upwards;
        public readonly float Downwards;

        public GravityForce(float upwards, float downwards)
        {
            Upwards   = upwards;
            Downwards = downwards;
        }
    }
}
