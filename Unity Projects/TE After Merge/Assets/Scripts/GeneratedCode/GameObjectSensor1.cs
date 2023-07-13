using System;
using System.Collections.Generic;
using UnityEngine;
using ThinkEngine.Mappers;
using static ThinkEngine.Mappers.OperationContainer;

namespace ThinkEngine
{
    class GameObjectSensor1 : Sensor
    {
		private int counter;
        private object specificValue;
        private Operation operation;
		private BasicTypeMapper mapper;
		private List<float> values = new List<float>();

		/*
		//Singleton
        protected static Sensor instance = null;

        internal static Sensor Instance
        {
            get
            {
                if (instance == null)
                {
					instance = new GameObjectSensor1();
                }
                return instance;
            }
        }*/

		internal override void Initialize(SensorConfiguration sensorConfiguration)
		{
            // Debug.Log("Initialize method called!");
			this.gameObject = sensorConfiguration.gameObject;
			ready = true;
			mapper = (BasicTypeMapper)MapperManager.GetMapper(typeof(float));
			operation = mapper.OperationList()[0];
			counter = 0;
			mappingTemplate = "GameObject_d(gameObject,objectIndex(1),{0})." + Environment.NewLine;

		}

		internal override void Destroy()
		{
            // Debug.Log("Destroy method called!");
			//instance = null;
		}

		internal override void Update()
		{
            // Debug.Log("Update method called!");
			if(!ready)
			{
				return;
			}
			if(!invariant || first)
			{
				Example Example0 = gameObject.GetComponent<Example>();
				if(Example0 == null) return;
				float d1 = Example0.d;

				if (values.Count == 200)
				{
					values.RemoveAt(0);
				}
				values.Add(d1);
			}
		}

		internal override string Map()
		{
            // Debug.Log("Map method called!");
			object operationResult = operation(values, specificValue, counter);
			return string.Format(mappingTemplate, BasicTypeMapper.GetMapper(operationResult.GetType()).BasicMap(operationResult));
		}
    }
}
