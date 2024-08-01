using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
   //1.Detect collisions
   //2.Identify objects colliding with this
   //3.Destroy this if the colliding object is the player
   //4.Every frame, update the rotation of this to attract the player

   public int pointValue = 1; // a var to store how many points this pickup is worth 

   //This function is called whenever this collider collides with another marked as a trigger(this object can be the trigger)
   private void OnTriggerEnter (Collider other)
   {
    if(other.gameObject.CompareTag("Player")) // if the collider this pickup just hit has the tag "player"
    {
        Destroy(this.gameObject); //destroy this pickup
        GameManager.Instance.UpdateScore(pointValue);
        GameManager.Instance.totalPickups -= 1;
    }
   }

   private void Update()
   {
    transform.Rotate(new Vector3(15,30,45)* Time.deltaTime);

   }
}
