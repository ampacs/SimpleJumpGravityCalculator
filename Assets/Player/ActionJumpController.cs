using Physics.Jump;
using Player.Data;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ActionJumpController : MonoBehaviour
    {
        private const string JumpButton = "Jump";

        [SerializeField] private RealtimeTester realtime;
        [SerializeField] private JumpValues     jumpValues;
        [SerializeField] private GravityValues  gravityValues;

        private Vector2     _jumpForce;
        private Rigidbody2D _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _jumpForce = GetJumpForce();
        }

        private void Update()
        {
            if (!Input.GetButtonDown(JumpButton)) return;

            if (realtime.test) _jumpForce = GetJumpForce();
            _rigidbody.velocity += _jumpForce;
        }

        private Vector2 GetJumpForce()
        {
            float jumpForce = JumpForceCalculator.GetJumpForce(
                gravityValues.upwards.magnitude, jumpValues.height, _rigidbody.mass
            );
            if (Mathf.Approximately(jumpForce, 0)) {
                Debug.LogWarning("calculated jump force is zero; check gravity, jump height or rigidbody mass for improper values");
            }

            return jumpForce * -gravityValues.upwards.normalized;
        }
    }
}
