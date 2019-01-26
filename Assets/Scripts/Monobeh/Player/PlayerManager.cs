using UnityEngine;

namespace Monobeh.Player
{
    public class PlayerManager : MonoBehaviour
    {
        private Rigidbody2D CharacterController;
        private void Start()
        {
            CharacterController = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Movement();
        }
    
        private void Movement()
        {
            var xAxis = Input.GetAxis("Horizontal");
            var yAxis = Input.GetAxis("Vertical");
        
            var moveVector = new Vector2(xAxis, yAxis);

            Debug.Log(moveVector);

            CharacterController.velocity = moveVector;
        }
    }
}
