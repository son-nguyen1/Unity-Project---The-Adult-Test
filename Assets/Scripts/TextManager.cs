using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class TextManager : MonoBehaviour
{
    // UI Elements
    [SerializeField] private GameObject sarcasticBox;
    [SerializeField] private TextMeshProUGUI sarcasticText;

    // List
    [SerializeField] private List<string> sarcasticList;

    private float textSpeed = 0.03f;

    private void Start()
    {
        sarcasticList.AddRange(new List<string>
        {
            "Welcome to The Adult Test. A highly advanced, totally serious evaluation designed to test your ability to be... an adult.",
            "It's very simple. You just need to... smile... through constant barrage of annoyances - small, big, or soul-crushing.",
            "Shouldn't be too hard for you right? After all, you're an expert at suppressing your emotions for the comfort of others. That's what adults do.",
            "You're a strong, independent, and mature person. You are not a whiny bitch who can't handle the real world, right?",
            "Now hold that smile together. Everything is fine. It always is. Be positive. There's absolutely no inner rage boiling just below the surface.",
            "Moving on... ah, the eyebrows. Such small, insignificant muscles - yet, apparently crucial to maintaining your strong facade of adult composure.",
            "In adulthood, the eyebrows must be neutral. No frowning, no raising them in surprise, and certainly no furrowing them in frustration.",
            "Now, let’s take a look at those eyes. Ah yes, the delightful, uncontrollable flicker of stress that lets everyone know you're cracking inside.",
            "We will be triggering them now. But don’t worry, I’m sure you’ll be fine. You handled life’s endless frustrations for years. Eye twitches shouldn't be a problem.",
            "Now... the smile. That reassuring expression that says: Everything's great!. It lets everyone around you feel comfortable.",
            "No matter what life—or I throw at you, your job is to keep smiling. Yes, even through all the micro-annoyances and utter nonsense that make up your daily life. ",
            "And finally, we come to the real hallmark of adulthood: emotional suppression. You must make sure your face remains perfectly neutral at all time.",
            "Don't show any sign of redness. No flushing with frustration. You are not gonna get emotional with everything. You're fine!",
            "Congrats. You’ve passed the Adult Test... kinda. You’ve proven your ability to smile through endless frustration. Well done. You are now officially fit for society.",
            "Look at that smile. Keep spreading that positivity. Make everything and everyone around you comfortable. Society thanks you for your service.",
            "Oh, and don’t worry. There’s definitely not gonna be any long-term problems at all. Just keep smiling. You are doing great!"
        });

        // Clear and disable the text
        sarcasticText.text = string.Empty;
        sarcasticBox.gameObject.SetActive(false);
    }

    public IEnumerator StartType(int sarcasticIndex)
    {
        // Clear and enable the text
        sarcasticText.text = string.Empty;
        sarcasticBox.gameObject.SetActive(true);

        foreach (char c in sarcasticList[sarcasticIndex].ToCharArray())
        {
            sarcasticText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        yield return new WaitForSeconds(1.5f);
    }
}