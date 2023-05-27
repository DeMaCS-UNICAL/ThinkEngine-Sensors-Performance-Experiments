using System;
using System.Collections.Generic;
using UnityEngine;
using ThinkEngine.Mappers;
using static ThinkEngine.Mappers.OperationContainer;

namespace ThinkEngine
{
    class Sensor0 : Sensor
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
					instance = new Sensor0();
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
			mappingTemplate = "Chaser__q(chaser,objectIndex(1),{0})." + Environment.NewLine;

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
				PositionSensor PositionSensor0 = gameObject.GetComponent<PositionSensor>();
				if(PositionSensor0 == null) return;
				int _q1 = PositionSensor0._q;

				if (values.Count == 200)
				{
					values.RemoveAt(0);
				}
				values.Add(_q1);
			}
		}

		internal override string Map()
		{
            // Debug.Log("Map method called!");
			object operationResult = operation(values, specificValue, counter);
			return string.Format(mappingTemplate, mapper.BasicMap(operationResult));
		}
    }
}
