using UnityEngine;
using System.Collections;

public class CursorControler : MonoBehaviour
{
    public bool hideCursor = false;
    public Texture2D defaultCursor;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public void OnMouseEnter()
    {
        
    }

    void Start(){
        if(!hideCursor) Show();
        else Hide();
    }

    public void Show(){
        Cursor.visible = true;
        Cursor.SetCursor(defaultCursor, hotSpot, cursorMode);
    }

    public void Hide(){
        Cursor.visible = false;
    }

    public void OnMouseExit()
    {
    
    }
}