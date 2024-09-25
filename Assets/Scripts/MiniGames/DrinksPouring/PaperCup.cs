using UnityEngine;

namespace MiniGames.DrinksPouring
{
    public class PaperCup : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;

        [SerializeField] private Rigidbody2D rigidbody2D;

        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                PaperCupMovement();
            }
        }

        private void PaperCupMovement()
        {
            Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), 0);
            rigidbody2D.MovePosition(rigidbody2D.position + movement * speed * Time.fixedDeltaTime);
        }
    }
}