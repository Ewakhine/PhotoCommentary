using UnityEngine;
using UnityEngine.UI;

// Place this script on a GameObject with those named children :
// - Large Panel
// -- PinClose Comment Button
// - Mini Panel
public class Comment : TwoSizesPanel {
    
    Button pinCloseButton;
    
    bool _isCommentPined;

///////////////////////////////////////////////////////////////
/// GENERAL FUNCTIONS /////////////////////////////////////////
///////////////////////////////////////////////////////////////
    void Start () {
        Init();

        if(_isInitCompleted){
            ShowLargePanel(false);
            ShowMiniPanel();
            Btn_PinComment();
        }
    }
    /*********************************************************/

    void Update () {
        if(_isInitCompleted)
            CheckPanels();
    }
    /*********************************************************/

///////////////////////////////////////////////////////////////
/// PRIVATE FUNCTIONS /////////////////////////////////////////
///////////////////////////////////////////////////////////////
    protected override void Init() {
        base.Init();
        pinCloseButton = largePanel.transform.Find("PinClose Comment Button").GetComponent<Button>();

        Debug.Log(this.name + " : Init is completed");
        _isInitCompleted = true;
    }
    /*********************************************************/

    protected override void CheckPanels()
    {
        bool mouseOnMiniPanel = RectTransformUtility.RectangleContainsScreenPoint(miniPanel.GetComponent<RectTransform>(), Input.mousePosition);
        bool mouseOnLargePanel = RectTransformUtility.RectangleContainsScreenPoint(largePanel.GetComponent<RectTransform>(), Input.mousePosition);

        if (!_isLargePanelShowed && mouseOnMiniPanel)
        {
            // Debug.Log("OPEN LARGE");
            ShowLargePanel();
            ShowMiniPanel(false);
        }
        else if (!_isMiniPanelShowed && !mouseOnLargePanel && !_isCommentPined)
        {
            // Debug.Log("QUIT LARGE");
            ShowLargePanel(false);
            ShowMiniPanel();
        }
    }
    /*********************************************************/

    void Btn_PinComment() {
        pinCloseButton.GetComponent<Button>().onClick.RemoveAllListeners();
        pinCloseButton.GetComponent<Button>().onClick.AddListener(() => Btn_CloseComment());
        pinCloseButton.transform.GetChild(0).GetComponent<Text>().text = "PIN";
        _isCommentPined = false;
    }
    /*********************************************************/
    void Btn_CloseComment() {
        pinCloseButton.GetComponent<Button>().onClick.RemoveAllListeners();
        pinCloseButton.GetComponent<Button>().onClick.AddListener(() => Btn_PinComment());
        pinCloseButton.transform.GetChild(0).GetComponent<Text>().text = "X";
        _isCommentPined = true;
    }
    /*********************************************************/
}
