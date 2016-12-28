using UnityEngine;

public class TwoSizesPanel : MonoBehaviour {

    protected GameObject largePanel;
    protected GameObject miniPanel;

    protected bool _isInitCompleted = false;
    protected bool _isMiniPanelShowed;
    protected bool _isLargePanelShowed;

///////////////////////////////////////////////////////////////
/// PROTECTED FUNCTIONS ///////////////////////////////////////
///////////////////////////////////////////////////////////////
    protected virtual void Init() {
        largePanel = transform.Find("Large Panel").gameObject;
        miniPanel = transform.Find("Mini Panel").gameObject;
    }
    /*********************************************************/

    protected virtual void CheckPanels() {
        bool mouseOnMiniPanel = RectTransformUtility.RectangleContainsScreenPoint(miniPanel.GetComponent<RectTransform>(), Input.mousePosition);
        bool mouseOnLargePanel = RectTransformUtility.RectangleContainsScreenPoint(largePanel.GetComponent<RectTransform>(), Input.mousePosition);

        if (!_isLargePanelShowed && mouseOnMiniPanel)
        {
            // Debug.Log("OPEN LARGE");
            ShowLargePanel();
            ShowMiniPanel(false);
        }
        else if (!_isMiniPanelShowed && !mouseOnLargePanel)
        {
            // Debug.Log("QUIT LARGE");
            ShowLargePanel(false);
            ShowMiniPanel();
        }
    }
    /*********************************************************/

    protected virtual void ShowLargePanel(bool a_showLargePanel = true) {
        _isLargePanelShowed = a_showLargePanel;
        largePanel.GetComponent<CanvasGroup>().alpha = a_showLargePanel ? 1 : 0;
        largePanel.GetComponent<CanvasGroup>().blocksRaycasts = a_showLargePanel;
    }
    /*********************************************************/
    protected virtual void ShowMiniPanel(bool a_showMiniPanel = true) {
        _isMiniPanelShowed = a_showMiniPanel;
        miniPanel.GetComponent<CanvasGroup>().alpha = a_showMiniPanel ? 1 : 0;
        miniPanel.GetComponent<CanvasGroup>().blocksRaycasts = a_showMiniPanel;
    }
    /*********************************************************/
}
