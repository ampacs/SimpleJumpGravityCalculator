using Physics.Gravity;
using Player.Data;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementController : MonoBehaviour
    {
        private const float ZeroThreshold = 1e-3f;
        private const string HorizontalAxis = "Horizontal";

        [SerializeField] private RealtimeTester realtime;
        [SerializeField] private JumpValues     jumpValues;
        [SerializeField] private GravityValues  gravityValues;

        [SerializeField] private AnimationCurve accelerationOverSpeed;

        private float _currentTime;
        private Vector2 _previousVelocity;
        private float _currentSpeed;

        private GravityForce _gravityForce;
        private Rigidbody2D  _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            CalculateGravityForce();
        }

        private void FixedUpdate()
        {
            Vector2 velocity     = _rigidbody.velocity;

            float   direction    = GetCurrentLocalTargetMovementDirection();
            float   evaluated    = accelerationOverSpeed.Evaluate(direction * Mathf.Abs(velocity.x));
            Vector2 acceleration = direction * evaluated * Mathf.Sign(velocity.x) * Vector2.right;

            if (realtime.test) CalculateGravityForce();
            Vector2 gravity = velocity.y < -ZeroThreshold ? gravityValues.downwards : gravityValues.upwards;

            _rigidbody.AddForce(gravity + acceleration );
        }

        private float GetCurrentLocalTargetMovementDirection()
        {
            float direction = Input.GetAxisRaw(HorizontalAxis),
                  currentHorizontalSpeed = _rigidbody.velocity.x;
            bool isMoving = currentHorizontalSpeed * currentHorizontalSpeed > ZeroThreshold * ZeroThreshold,
                 noInput = direction * direction < ZeroThreshold * ZeroThreshold;

            // if we're standing still, we need to nudge the player's rigidbody in the intended direction
            if (!isMoving) return direction;
            // if we're moving and there's no input
            if (noInput) direction = -1; // let's assume we want to brake
            else direction = Mathf.Abs(direction) * Mathf.Sign(currentHorizontalSpeed * direction);

            return direction;
        }

        private void CalculateGravityForce()
        {
            GravityForce force = GravityForceCalculator.GetGravityForce(
                jumpValues.height, jumpValues.time, jumpValues.jumpApexOverTime
            );

            gravityValues.upwards = Vector2.down * force.Upwards;
            gravityValues.downwards = Vector2.down * force.Downwards;
        }
    }
}
