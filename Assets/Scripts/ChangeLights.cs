using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeLights : MonoBehaviour
{
    // create camera list that can be updated in the inspector
    public Light lights;

    // create frame and button variables 
    private VisualElement frame;
    private Button button;
    private bool dim = false;

    // This function is called when the object becomes enabled and active.
    void OnEnable()
    {
        // get the UIDocument component (make sure this name matches!)
        var uiDocument = GetComponent<UIDocument>();
        // get the rootVisualElement (the frame component)
        var rootVisualElement = uiDocument.rootVisualElement;
        frame = rootVisualElement.Q<VisualElement>("Frame");
        // get the button, which is nested in the frame
        button = frame.Q<Button>("Button");
        // create event listener that calls ChangeCamera() when pressed
        button.RegisterCallback<ClickEvent>(ev => ChangeLight());
    }

    // initialize click count
    private void ChangeLight()
    {
        if (dim)
        {
            dim = false;
            lights.intensity = 3;
        }
        else {
            dim = true;
            lights.intensity = 0;
        }
    }
  
}