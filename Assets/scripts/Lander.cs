using UnityEngine;
using UnityEngine.InputSystem;

public class Lander : MonoBehaviour
{
 private Rigidbody2D landerRigidbody2D;
  private void Awake()
  {
    landerRigidbody2D = GetComponent <Rigidbody2D>();
  }

  private void FixedUpdate()
  {
        if (Keyboard.current.upArrowKey.isPressed)
        {
            
        }
         if (Keyboard.current.downArrowKey.isPressed)
        {
           
        }
         if (Keyboard.current.rightArrowKey.isPressed)
        {
          
        }
         if (Keyboard.current.leftArrowKey.isPressed)
        {
            
        }
  }
 
}
