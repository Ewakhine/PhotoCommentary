using UnityEngine;
using UnityEngine.UI;

public class ChangeButtons : MonoBehaviour {

    GameObject largePanel;
    GameObject miniPanel;

    Button nextButton;
    Button previousButton;

    bool _isInitCompleted = false;
    bool _isMiniPanelShowed;
    bool _isLargePanelShowed;

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
    void Init() {
        largePanel = transform.Find("Buttons Panel").gameObject;
        miniPanel = transform.Find("Mini Panel").gameObject;
        nextButton = largePanel.transform.Find("Next Button").GetComponent<Button>();
        previousButton = largePanel.transform.Find("Previous Button").GetComponent<Button>();

        Debug.Log(this.name + " : Init is completed.");
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
        else if (!_isMiniPanelShowed && !mouseOnLargePanel) {
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
}
