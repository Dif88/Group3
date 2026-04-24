using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
      public int NumberOfStars {get; private set;}

      public void StarsCollected()
      {
        NumberOfStars++;
      }

}
