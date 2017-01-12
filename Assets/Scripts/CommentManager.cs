using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CommentElement {
    public bool isTopComment;
    public string commentText;
}

public class CommentManager : MonoBehaviour {

    public GameObject leftComment;
    public GameObject topComment;

    List<CommentElement> _commentsList;

	// Use this for initialization
	void Start () {
        InitializeCommentsList();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void InitializeCommentsList()
    {

    }
}
