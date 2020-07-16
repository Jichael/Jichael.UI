using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

namespace Silicom.UI
{
    public class ServerBayUI : UIBase
    {

        [SerializeField] private Transform anchorPoint;
        [SerializeField] private Transform canvas;

        [SerializeField] private TMP_Text bayRef;
        [SerializeField] private TMP_Text builder;
        [SerializeField] private TMP_Text model;
        [SerializeField] private TMP_Text dimension;
        [SerializeField] private TMP_Text capacity;
        [SerializeField] private TMP_Text occupationRate;
        [SerializeField] private TMP_Text uMax;

        private static List<ServerBayUIData> _uiDataList = new List<ServerBayUIData>();

        private ServerBayUIData _uiData;
        
        
        private void Awake()
        {
            if (!FetchedData)
            {
                string data = FetchData("ServerBay");

                _uiDataList = JsonConvert.DeserializeObject<List<ServerBayUIData>>(data);
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
            bayRef.text = _uiData.bayRef;
            builder.text = _uiData.builder;
            model.text = _uiData.model;
            dimension.text = _uiData.dimension;
            capacity.text = _uiData.capacity;
            occupationRate.text = _uiData.occupationRate;
            uMax.text = _uiData.uMax;
            canvas.SetPositionAndRotation(anchorPoint.position, anchorPoint.rotation);
            canvas.gameObject.SetActive(true);
        }
    }
    
    
    [Serializable]
    public class ServerBayUIData
    {
        public string bayRef;
        public string builder;
        public string model;
        public string dimension;
        public string capacity;
        public string occupationRate;
        public string uMax;
    }

}