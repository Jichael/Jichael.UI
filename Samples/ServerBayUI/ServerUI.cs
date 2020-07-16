using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

namespace Silicom.UI
{
    public class ServerUI : UIBase
    {
        
        [SerializeField] private Transform anchorPoint;
        [SerializeField] private Transform canvas;

        [SerializeField] private TMP_Text serverName;
        [SerializeField] private TMP_Text bayRef;
        [SerializeField] private TMP_Text location;
        [SerializeField] private TMP_Text builder;
        [SerializeField] private TMP_Text model;
        [SerializeField] private TMP_Text serialNumber;
        [SerializeField] private TMP_Text installationDate;
        [SerializeField] private TMP_Text warrantyDate;
        [SerializeField] private TMP_Text ipAddress;
        [SerializeField] private TMP_Text operatingSystem;
        [SerializeField] private TMP_Text ram;
        [SerializeField] private TMP_Text cpu;
        [SerializeField] private TMP_Text power;
        [SerializeField] private TMP_Text eth;

        private static bool _fetchedData;

        private static List<ServerUIData> _uiDataList = new List<ServerUIData>();

        private ServerUIData _uiData;
        
        private void Awake()
        {
            if (!FetchedData)
            {
                string data = FetchData("ServerBay");

                _uiDataList = JsonConvert.DeserializeObject<List<ServerUIData>>(data);
                FetchedData = true;
            }

            for (int i = 0; i < _uiDataList.Count; i++)
            {
                if (_uiDataList[i].bayRef == name)
                {
                    _uiData = _uiDataList[i];
                }
            }
        }


        public override void OpenUI()
        {
            serverName.text = _uiData.serverName;
            bayRef.text = _uiData.bayRef;
            location.text = _uiData.location;
            builder.text = _uiData.builder;
            model.text = _uiData.model;
            serialNumber.text = _uiData.serialNumber;
            installationDate.text = _uiData.installationDate;
            warrantyDate.text = _uiData.warrantyDate;
            ipAddress.text = _uiData.ipAddress;
            operatingSystem.text = _uiData.operatingSystem;
            ram.text = _uiData.ram;
            cpu.text = _uiData.cpu;
            power.text = _uiData.power;
            eth.text = _uiData.eth;
            
            
            canvas.SetPositionAndRotation(anchorPoint.position, anchorPoint.rotation);
            canvas.gameObject.SetActive(true);
        }
    }
    
    


    [Serializable]
    public class ServerUIData
    {
        public string serverName;
        public string bayRef;
        public string location;
        public string builder;
        public string model;
        public string serialNumber;
        public string installationDate;
        public string warrantyDate;
        public string ipAddress;
        public string operatingSystem;
        public string ram;
        public string cpu;
        public string power;
        public string eth;
    }
}