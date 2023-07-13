using System;
using System.Collections.Generic;
using UnityEngine;
using ThinkEngine.Mappers;
using static ThinkEngine.Mappers.OperationContainer;

namespace ThinkEngine
{
    class GameObjectSensor0 : Sensor
    {
		private int counter;
        private object specificValue;
        private Operation operation;
		private BasicTypeMapper mapper;
		private List<int> values = new List<int>();

		/*
		//Singleton
        protected static Sensor instance = null;

        internal static Sensor Instance
        {
            get
            {
                if (instance == null)
                {
					instance = new GameObjectSensor0();
                }
                return instance;
            }
        }*/

		internal override void Initialize(SensorConfiguration sensorConfiguration)
		{
            // Debug.Log("Initialize method called!");
			this.gameObject = sensorConfiguration.gameObject;
			ready = true;
			mapper = (BasicTypeMapper)MapperManager.GetMapper(typeof(int));
			operation = mapper.OperationList()[0];
			counter = 0;
			mappingTemplate = "GameObject_Example2__x(gameObject,objectIndex(1),{0})." + Environment.NewLine;

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
				GameObject _example21 = Example0._example2;
				if(_example21 == null) return;
				Example2 Example22 = _example21.GetComponent<Example2>();
				if(Example22 == null) return;
				int _x3 = Example22._x;

				if (values.Count == 200)
				{
					values.RemoveAt(0);
				}
				values.Add(_x3);
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
