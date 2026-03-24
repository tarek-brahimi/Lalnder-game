using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class Lander : MonoBehaviour
{
    private Rigidbody2D landerRigidbody2D;
    private void Awake()
    {
        landerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Keyboard.current.upArrowKey.isPressed)
        {
            float force = 700f;
            landerRigidbody2D.AddForce(force * transform.up * Time.deltaTime);
        }

        if (Keyboard.current.rightArrowKey.isPressed)
        {
            float turnSpeeed = -100f;
            landerRigidbody2D.AddTorque(turnSpeeed * Time.deltaTime);
        }
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            float turnSpeeed = +100f;
            landerRigidbody2D.AddTorque(turnSpeeed * Time.deltaTime);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (!collision2D.gameObject.TryGetComponent(out LandingPad landingPad))
        {
            Debug.Log("crash on terrain");
            return;
        }

        float softLanding = 4f;
        float relativeVelocityMagnitude =collision2D.relativeVelocity.magnitude;
        if (softLanding < relativeVelocityMagnitude )
        {
            Debug.Log("land too hard");
            return;
        }
        float dotVector = Vector2.Dot(Vector2.up, transform.up);
        float mindotvector = 0.90f;
        if ( dotVector<mindotvector)
        {
            Debug.Log("land on too steap angele ");
            return;
        }
        Debug.Log("sucss");
        float maxScoreAmountlandingAngel = 100;
        float scoreDotvectorMultipliar = 10f ;
        float ScorelandingAngel = maxScoreAmountlandingAngel - Mathf.Abs(dotVector-1f) * scoreDotvectorMultipliar*maxScoreAmountlandingAngel;        
         float maxScoreAmountlandingSpeed = 100;
        float landigSpeedScore = (softLanding - relativeVelocityMagnitude )*maxScoreAmountlandingSpeed;
         Debug.Log( "landing angel :"+ScorelandingAngel);
         Debug.Log("speed:"+landigSpeedScore);

         int Score = Mathf.RoundToInt((landigSpeedScore+ScorelandingAngel)*landingPad.GetScoreMultpilare());
         Debug.Log("score:"+Score);
      
    }
}
