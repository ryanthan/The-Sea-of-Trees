using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]

public class State : ScriptableObject
{
    [TextArea(13, 14)] [SerializeField] string storyText; //Information within the scriptable object
    [SerializeField] State[] nextStates; //Serialize an array of states to store the next states
    [SerializeField] Sprite image;
    [SerializeField] AudioClip soundEffect;

    // Method to get the text from the scriptable object
    public string GetStateStory()
    {
        return storyText;
    }

    // Method to get the text from the scriptable object
    public State[] GetNextStates()
    {
        return nextStates;
    }

    // Method to get the image linked to the scriptable object
    public Sprite GetStateImage()
    {
        return image;
    }

    // Method to get the sound effect linked to the scriptable object
    public AudioClip GetSoundEffect()
    {
        return soundEffect;
    }
}
