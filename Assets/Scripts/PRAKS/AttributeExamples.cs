using UnityEngine;

/*
 * SelectionBase controls the object selection within the scene view of the editor.
 * GameObject with SelectionBase is selected instead of a child object that received the click.
 *
 * Useful when the graphics of an entity are added as a child and the logic is located in the parent.
 * https://docs.unity3d.com/ScriptReference/SelectionBaseAttribute.html
*/
[SelectionBase]

/*
 * ExecuteInEditMode causes MonoBehaviour messages to be sent to this script in the edit mode.
 * The monobehaviour functions do not work exactly the same as in play mode. See documentation for details. 
 *
 * Useful for making tools for the editor.
 * https://docs.unity3d.com/ScriptReference/ExecuteInEditMode.html
 */
[ExecuteInEditMode]

/*
 * RequireComponent can be used to avoid missing components tyour logic classes depend on.
 *
 * Note: The check is only made when the component is added.
 * Works with manual adding in editor or by calling AddComponent in code.
 * https://docs.unity3d.com/ScriptReference/RequireComponent.html
 */
[RequireComponent(typeof(Animator))]

/*
 * Limits the number of allowed components on the same gameobject to 1
 * https://docs.unity3d.com/ScriptReference/DisallowMultipleComponent.html
 */
[DisallowMultipleComponent]

/*
 * Used to add a documentation link in the inspector.
 * Opened when clicking on the questionmark book icon.
 */
[HelpURL("https://courses.cs.ut.ee/2018/gamedev/fall/Main/Lab13")]
public class AttributeExamples : MonoBehaviour
{

    /*
     * Header can be used to add titles in the inspector panel.
     *
     * Useful for keeping both the inspector and variables in code organized.
     * It is recommended to always organize all your variables into groups under headers.
     * This guarantees a minimum level of comments as well.
     * https://docs.unity3d.com/ScriptReference/HeaderAttribute.html
     */
    [Header("String Modifiers")]
    
    /*
     * Space can be used to add some empty space between properties in the inspector
     * Has an optional float value for the amount of space.
     *
     * https://docs.unity3d.com/ScriptReference/SpaceAttribute.html
     */
    [Space]

    /*
     * Tooltip can be used to add mouse over tooltips to better explain what a variable is for in the editor.
     *
     * https://docs.unity3d.com/ScriptReference/TooltipAttribute.html
     */
    [Tooltip("A string with the default property drawer")]
    public string normalString;

    /*
     * Multiline gives more space for writing strings
     *
     * https://docs.unity3d.com/ScriptReference/MultilineAttribute.html
     */
    [Multiline]
    public string multiLineString;

    /*
     * TextArea gives even more space for writing messages along with a scrollbar.
     *
     * https://docs.unity3d.com/ScriptReference/TextAreaAttribute.html
     */
    [TextArea]
    public string defaultTextArea;

    
    /*
     * TextArea also allows setting min and max lines for the size of the box.
     * The box will always have at least the size of min lines and grow up to max lines if there is enough text.
     */
    [TextArea(minLines:5,maxLines:10)]

    /*
     * ContextMenuItem can be used to create a right click menu on a property.
     *
     */
    [Tooltip("Right click on me!")]
    [ContextMenuItem(name:"Add Lorem Ipsum", function:"FillTextArea")]
    public string resizedTextArea;

    [Header("Sliders")]
    [Space]
    /*
     * Range can be used to add sliders for the variables.
     *
     * Useful for limiting editor values to a limited range.
     * https://docs.unity3d.com/ScriptReference/RangeAttribute.html
     */
    [Range(-1, 1)]
    public float floatSlider;

    [Range(0, 10)]
    public int intSlider;

    /*
     * Delayed will require enter to be pressed for the value to be modified.
     * Useful for editor tools that depend on inspector variables.
     */
    [Delayed]
    public int delayedValueEntry;

    /*
     * SerializeField can be used to also serialize private fields.
     *
     * Unity serializes objects and shows the values in the inspector window.
     * As default behavior Unity serializes and shows only public fields.
     */
    [SerializeField]
    private int privateInt;
    
    /*
     * Opposite of SerializeField to hide public values in editor
     */
    [HideInInspector]
    public int publicInt;

    /*
     * Colorusage can be used to configure the color picker
     */
    [ColorUsage(showAlpha: false, hdr: !false)]
    public Color Color;

    //this method is called by right clicking on the name of the resizedTextArea
    private void FillTextArea()
    {
        resizedTextArea = resizedTextArea +
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit, " +
            "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
            "Ut enim ad minim veniam," +
            " quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.";
    }

    /*
     * Methods can also be added to the context menu available from the gear icon. 
     */
    [ContextMenu("Hello")]
    private void Hello()
    {
        print("hello");
    }

}
