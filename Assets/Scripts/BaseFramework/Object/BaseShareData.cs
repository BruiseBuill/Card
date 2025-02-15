using UnityEngine;
using UnityEngine.Events;

namespace BF
{
	public class BaseShareData : MonoBehaviour
	{
        public DataWithEvent<bool> isAlive;

		public virtual void Awake()
		{
			isAlive = new DataWithEvent<bool>();
		}
		public virtual void Open()
		{
			isAlive.Value = true;
		}
		public virtual void Close()
		{

		}
        public class DataWithEvent<T> where T:struct
		{
			public UnityAction<T> onValueChange = delegate { };
            //Sometimes onValueChange.Invoke(data) will change value again, then you should instead change data
            public T data;
			public T Value 
            {
				get => data;
				set
				{
                    data = value;
					onValueChange.Invoke(data);
				}
			}
			public DataWithEvent()
			{
				onValueChange = delegate { };
			}
        }

	}
}