using UnityEngine;
using UnityEngine.Events;

namespace myUIEvents
{

    public class MobileHandler : MonoBehaviour
    {
        public static UnityEvent goLeftEvent = new UnityEvent();
        public static UnityEvent goRightEvent = new UnityEvent();
        public static UnityEvent stopMovingEvent = new UnityEvent();
        public static UnityEvent goUpEvent = new UnityEvent();

        public void goLeft()
        {
            goLeftEvent.Invoke();
            Debug.Log("Left event triggered");
        }

        public void goRight()
        {
            goRightEvent.Invoke();
        }

        public void stopMoving()
        {
            stopMovingEvent.Invoke();
        }

        public void jump()
        {
            goUpEvent.Invoke();
        }

    }
}