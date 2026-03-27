using UnityEngine;

public class ToggleGameObjectBehaviour : MonoBehaviour
{
    public void ToggleGameObjectActive()
    {
        bool currentState = gameObject.activeSelf;
        gameObject.SetActive(!currentState);
    }
}
