using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

// Place this script on a GameObject with those named children :
// - Large Panel
// -- PinClose Comment Button
// - Mini Panel
public class ChangeButtons : TwoSizesPanel {

    public RawImage currentPhoto;
    int _currentIndex;

    Button nextButton;
    Button previousButton;

    Texture[] photos;

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

        photos = Resources.LoadAll<Texture>("");
        /*Debug.Log(photos.Length);
        for (int i = 0; i < photos.Length; i++)
            Debug.Log(photos[i].name);*/
        if (photos.Length > 0)
        {
            _currentIndex = 0;
            currentPhoto.texture = photos[_currentIndex];
        }

        Debug.Log(this.name + " : Init is completed.");
        _isInitCompleted = true;
    }
    /*********************************************************/

    public void Btn_NextImage() {
        if (_currentIndex < photos.Length -1)
            _currentIndex++;
        currentPhoto.texture = photos[_currentIndex];
    }
    /*********************************************************/
    public void Btn_PreviousImage() {
        if (_currentIndex > 0 )
            _currentIndex--;
        currentPhoto.texture = photos[_currentIndex];
    }
    /*********************************************************/
}
