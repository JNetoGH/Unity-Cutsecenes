using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;


public class VirtualCamTransition : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera _activate;
    private static List<CinemachineVirtualCamera> _allCams;
    
    void Start()
    {
        if (_allCams != null)
            return;
        _allCams = FindObjectsOfType<CinemachineVirtualCamera>().ToList();
        Debug.Log("Virtual cameras list updated");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_activate is null)
            return;
        
        if (_allCams is null)
            return;

        if (!other.tag.ToUpper().Equals("PLAYER"))
            return;
        
        _allCams.ForEach(cam => cam.gameObject.SetActive(cam == _activate));
    }

    private void OnDestroy()
    {
        _allCams = null;
    }
    
}
