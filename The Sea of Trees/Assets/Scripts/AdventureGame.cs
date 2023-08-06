using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;
    [SerializeField] Image backgroundImage;
    [SerializeField] AudioSource audioSource;

    public State currentState;       // Variable to store current state
    public float delay = 0.01f;      // Variable to store delay value (for typewriter effect)
    public string fullText;          // Variable to store full text for specific state
    private string currentText = ""; // Variable to store current text (for typewriter effect)
    public int i = 0;                // For loop variable
    Coroutine currentRoutine = null; // Variable to store the current coroutine

    // Start is called before the first frame update
    void Start()
    {
        currentState = startingState; // Set the starting state
        fullText = currentState.GetStateStory(); // Get the text from the state
        currentRoutine = StartCoroutine(ShowText()); // Start the typewriter effect
        backgroundImage.sprite = currentState.GetStateImage(); // Get the image for the starting state
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }
    
    // Method to manage each state
    private void ManageState()
    {
        var nextStates = currentState.GetNextStates(); // Variable to store next states
        
        if (Input.GetKeyDown(KeyCode.Alpha1)) // If the user pressed the "1" key
        {
            currentState = nextStates[0]; // Switch to the corresponding state
            i = 0; // Reset i
            if (currentRoutine != null) { // If the current coroutine isn't null: 
                StopCoroutine(currentRoutine); // Stop it
            }
            currentRoutine = StartCoroutine(ShowText()); // Restart the coroutine

            if (audioSource.isPlaying) // If audio is playing, stop it.
                audioSource.Stop();
            
            if (currentState.GetSoundEffect() != null)
                audioSource.PlayOneShot(currentState.GetSoundEffect()); // Play the sound effect
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // If the user pressed the "2" key
        {
            currentState = nextStates[1]; // Switch to the corresponding state
            i = 0; // Reset i
            if (currentRoutine != null) { // If the current coroutine isn't null: 
                StopCoroutine(currentRoutine); // Stop it
            }
            currentRoutine = StartCoroutine(ShowText()); // Restart the coroutine
            if (audioSource.isPlaying) // If audio is playing, stop it.
                audioSource.Stop();
            
            if (currentState.GetSoundEffect() != null)
                audioSource.PlayOneShot(currentState.GetSoundEffect()); // Play the sound effect
        }
        else if (Input.GetKeyDown(KeyCode.Return)) // If the user pressed the "Enter" key
        {
            i = fullText.Length; // Set i to be the length of the text to stop the for loop
            textComponent.text = currentState.GetStateStory(); // Fill the textbox with the entire text
        }
        else if (Input.GetKeyDown(KeyCode.Q)) // If the user pressed the "Q/q" key
        {
            currentState = startingState; // Return to the starting state
            i = 0; // Reset i
            if (currentRoutine != null) { // If the current coroutine isn't null: 
                StopCoroutine(currentRoutine); // Stop it
            }
            currentRoutine = StartCoroutine(ShowText()); // Restart the coroutine
            if (audioSource.isPlaying) // If audio is playing, stop it.
                audioSource.Stop();
        }
        else if (Input.GetKeyDown(KeyCode.C) && currentState == startingState) // If the user pressed the "C/c" key while on the Introduction state
        {
            currentState = nextStates[2]; // Go to the credits state
            i = 0; // Reset i
            if (currentRoutine != null) { // If the current coroutine isn't null: 
                StopCoroutine(currentRoutine); // Stop it
            }
            currentRoutine = StartCoroutine(ShowText()); // Restart the coroutine
            if (audioSource.isPlaying) // If audio is playing, stop it.
                audioSource.Stop();
        }
        
        fullText = currentState.GetStateStory(); // Get the text from the xurrent state
        backgroundImage.sprite = currentState.GetStateImage(); //Get the image for the starting state
    }

    // Coroutine: Produce a typewriter effect
    IEnumerator ShowText() {
        for (i = 0; i <= fullText.Length; i++) { // Iterate through the state text
            currentText = fullText.Substring(0, i); // Set currentText to be a substring of the full text
            textComponent.text = currentText; // Display currentText
            yield return new WaitForSeconds(delay * 0.3f); // Wait for a short delay before running again (to produce effect)
        }
    }
}

/* Code References and Resources:
   - Modified the typewriter effect code from this tutorial: https://www.youtube.com/watch?v=1qbjmb_1hV4&feature=emb_title
   - Learned to restart coroutines from here: https://answers.unity.com/questions/934490/stopcoroutine-is-not-stopping-my-coroutines.html
   
   - "Forestry" font provided free for personal use by Josiah Werning on the website: https://www.dafont.com/forestry.font
   - "Mom's Typewriter" font provided 100% free to use by Christoph Mueller on the website: https://www.dafont.com/moms-typewriter.font
   - Royalty free images provided by: https://www.pexels.com/ and https://snappygoat.com/
   - The "Violin Scare" sound effect was provided by SirBedlam on https://freesound.org/people/SirBedlam/sounds/393824/ through an Attribution License (no edits were made).
   - The "DoorCreaking10.flac" sound effect was provided by Zabuhailo on https://freesound.org/people/Zabuhailo/sounds/214081/ through an Attribution License (no edits were made).
   - The "Wind blowing through trees.mp3" sound effect was provided by CGEffex on https://freesound.org/people/CGEffex/sounds/92654/ through an Attribution License (no edits were made).
   - The "remix of 203231__raspberrytickle__ -laugh.flac" sound effect was provided by Timbre on https://freesound.org/people/Timbre/sounds/215134/ through an Attribution Noncommercial License. The audio was trimmed slightly for use in this project.
   - The "Giggle" sound effect was provided by biawinter on https://freesound.org/people/biawinter/sounds/408083/ through an Attribution Noncommercial License. The audio was trimmed slightly for this project.
   - The "Gasp_fright_female_byMondfisch89.ogg" sound effect was provided by Yudena on https://freesound.org/people/Yudena/sounds/377562/ through an Attribution Noncommercial License (no edits were made).
   - The "Kagome Kagome" sound effect was provided by laiskvorst on https://freesound.org/people/laiskvorst/sounds/487601/ through an Attribution License. The volume was adjusted for use in this project.
   - The "male scream.aif" sound effect was provided by MAJ061785 on https://freesound.org/people/MAJ061785/sounds/85554/ through an Attribution License. The volume was adjusted for use in this project.
   - The "Running Over Dead Leaves" sound effect was provided by Nagwense on https://freesound.org/people/Nagwense/sounds/407654/ through an Attribution Noncommercial License (no edits were made).
   - All other sound effects were provided by: https://freesound.org/ under the Creative Commons 0 License.
*/