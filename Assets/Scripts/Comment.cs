using UnityEngine;
using UnityEngine.UI;

// Place this script on a GameObject with those named children :
// - Comment Panel
// -- PinClose Comment Button
// - Mini Panel
public class Comment : MonoBehaviour {

    GameObject largePanel;
    GameObject miniPanel;
    Button pinCloseButton;

    bool _isInitCompleted = false;

    bool _isMiniPanelShowed;
    bool _isLargePanelShowed;
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
    void Init() {
        largePanel = transform.Find("Comment Panel").gameObject;
        miniPanel = transform.Find("Mini Panel").gameObject;
        pinCloseButton = largePanel.transform.Find("PinClose Comment Button").GetComponent<Button>();

        Debug.Log(this.name + " : Init is complete");
        _isInitCompleted = true;
    }
    /*********************************************************/

    void CheckPanels() {
        bool mouseOnMiniPanel = RectTransformUtility.RectangleContainsScreenPoint(miniPanel.GetComponent<RectTransform>(), Input.mousePosition);
        bool mouseOnLargePanel = RectTransformUtility.RectangleContainsScreenPoint(largePanel.GetComponent<RectTransform>(), Input.mousePosition);

        if (!_isLargePanelShowed && mouseOnMiniPanel) {
            // Debug.Log("OPEN LARGE");
            ShowLargePanel();
            ShowMiniPanel(false);
        }
        else if (!_isMiniPanelShowed && !mouseOnLargePanel && !_isCommentPined) {
            // Debug.Log("QUIT LARGE");
            ShowLargePanel(false);
            ShowMiniPanel();
        }
    }
    /*********************************************************/

    void ShowLargePanel(bool a_showLargePanel = true) {
        _isLargePanelShowed = a_showLargePanel;
        largePanel.GetComponent<CanvasGroup>().alpha = a_showLargePanel ? 1 : 0;
        largePanel.GetComponent<CanvasGroup>().blocksRaycasts = a_showLargePanel;
    }
    /*********************************************************/

    void ShowMiniPanel(bool a_showMiniPanel = true) {
        _isMiniPanelShowed = a_showMiniPanel;
        miniPanel.GetComponent<CanvasGroup>().alpha = a_showMiniPanel ? 1 : 0;
        miniPanel.GetComponent<CanvasGroup>().blocksRaycasts = a_showMiniPanel;

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
