using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    private Vector2 onScreenMousePosition;
    public Vector2 onWorldMousePosition;
    public void FixedUpdate()
    {
        onScreenMousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        onWorldMousePosition = Camera.main.ScreenToWorldPoint(onScreenMousePosition);
    }
}