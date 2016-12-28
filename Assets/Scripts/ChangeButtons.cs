using UnityEngine;
using UnityEngine.UI;

// Place this script on a GameObject with those named children :
// - Large Panel
// -- PinClose Comment Button
// - Mini Panel
public class ChangeButtons : TwoSizesPanel {

    Button nextButton;
    Button previousButton;

///////////////////////////////////////////////////////////////
/// GENERAL FUNCTIONS /////////////////////////////////////////
///////////////////////////////////////////////////////////////
    void Start () {
        Init();

        if (_isInitCompleted) {
            ShowLargePanel(false);
            ShowMiniPanel();
        }
    }
    /*********************************************************/
    
    void Update () {
        if (_isInitCompleted)
            CheckPanels();
    }
    /*********************************************************/

///////////////////////////////////////////////////////////////
/// PRIVATE FUNCTIONS /////////////////////////////////////////
///////////////////////////////////////////////////////////////
    protected override void Init() {
        base.Init();
        nextButton = largePanel.transform.Find("Next Button").GetComponent<Button>();
        previousButton = largePanel.transform.Find("Previous Button").GetComponent<Button>();

        Debug.Log(this.name + " : Init is completed.");
        _isInitCompleted = true;
    }
    /*********************************************************/
}
