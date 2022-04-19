using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GUI
{
    public static class InformationPanel
    {
        public static Transform MainPanel;
        public static void UpdateInformationalPanel(PlayerControls controls)
        {
            MainPanel.Find("X-cord").Find("Text").GetComponent<Text>().text = ((int)controls.gameObject.transform.position.x).ToString();
            MainPanel.Find("Y-cord").Find("Text").GetComponent<Text>().text = ((int)controls.gameObject.transform.position.y).ToString();
            MainPanel.Find("Angle").Find("Text").GetComponent<Text>().text = ((int)controls.gameObject.transform.eulerAngles.z).ToString();
            MainPanel.Find("Speed").Find("Text").GetComponent<Text>().text = ((int)controls.CurrentSpeed).ToString();
            MainPanel.Find("LaserChargesAviable").Find("Text").GetComponent<Text>().text = ((int)controls.LaserShotsAviable).ToString();
            MainPanel.Find("LaserRechargeTimer").Find("Text").GetComponent<Text>().text = ((int)controls.timer_LaserReplenish).ToString() + " / " +
                ((int)controls.LasterShotsReplenishTime).ToString();
        }
    }
}
