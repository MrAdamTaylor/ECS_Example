using UnityEngine;

namespace GameSystem
{
    public class FireInput : MonoBehaviour
    {
        public bool IsFirePressDown()
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
    }
}