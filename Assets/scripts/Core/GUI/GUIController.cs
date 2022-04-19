using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GUI
{
    public class GUIController : MonoBehaviour
    {
        public GameObject GameLostPanel;
        private void Start()
        {
            InformationPanel.MainPanel = GameObject.FindGameObjectWithTag("InfPanel").transform;
        }
    }
}
