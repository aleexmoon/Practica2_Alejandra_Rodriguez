using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraPointerManager : MonoBehaviour
{
    [SerializeField] private GameObject pointer;
    [SerializeField] private float maxPointerDistance = 4.5f;
    [SerializeField] private float defaultPointerDistance = 5f;

    private const string interactableTag = "Interactable";
    private GameObject _gazedAtObject = null;

    private void Start()
    {
        GazeManager.Instance.OnGazeSelection += GazeSelection;
    }
    private void GazeSelection()
    {
        if (_gazedAtObject != null)
        {
            if (_gazedAtObject.CompareTag(interactableTag))
            {
                _gazedAtObject.SendMessage("OnPointerClickXR", null, SendMessageOptions.DontRequireReceiver);
            }
            else if (_gazedAtObject.GetComponent<Button>() != null)
            {
                _gazedAtObject.GetComponent<Button>().onClick.Invoke();
            }
        }
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxPointerDistance))
        {
            if (_gazedAtObject != hit.transform.gameObject)
            {
                _gazedAtObject?.SendMessage("OnPointerExitXR", null, SendMessageOptions.DontRequireReceiver);
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnterXR", null, SendMessageOptions.DontRequireReceiver);
                GazeManager.Instance.StartGazeSelection();
            }
        }
        else
        {
            _gazedAtObject?.SendMessage("OnPointerExitXR", null, SendMessageOptions.DontRequireReceiver);
            _gazedAtObject = null;
        }
        if (pointer != null)
        {
            if (_gazedAtObject != null)
            {
                pointer.transform.position = hit.point;
                pointer.transform.LookAt(transform.position);
                pointer.SetActive(true);
            }
            else
            {
                pointer.transform.position = transform.position + transform.forward * defaultPointerDistance;
                pointer.transform.rotation = transform.rotation;
                pointer.SetActive(true);
            }
        }
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            GazeSelection();
        }
        if (_gazedAtObject == null)
        {
            GazeManager.Instance.CancelGazeSelection();
        }
    }
}