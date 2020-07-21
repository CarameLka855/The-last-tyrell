using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_replic : MonoBehaviour
{
    void OnGUI()
    {
        // Make a group on the center of the screen
        GUI.BeginGroup(new Rect(-6.06f, -3.6f,100,100));
        // All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.

        // We'll make a box so you can see where the group is on-screen.
        GUI.Box(new Rect(0, 0, 100, 100), "Group is here");

        // End the group we started above. This is very important to remember!
        GUI.EndGroup();
    }
}
