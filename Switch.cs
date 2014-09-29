using System;


namespace ITI.Light
{
	class Switch
	{
		int _maxLamps;
		int _lamps;
		Lamp [] _asignedLamps;
		bool _open;

		public Lamp [] Lamps
		{
			get { return _asignedLamps; }
		}

		/// <summary>
		/// Create a switch to manage lamps from class Lamp.
		/// </summary>
		/// <param name="maxLamps">Expect positive value</param>
		public Switch (int maxLamps)
		{
			if (maxLamps < 0)
				maxLamps = 0;
			_maxLamps = maxLamps;
			_asignedLamps = new Lamp [_maxLamps];
			_open = true;
		}

		#region Manage Lamps
		/// <summary>
		/// This method add a lamp in the first free space from the switch. If the switch is full, the lamp can't be added.
		/// </summary>
		/// <param name="lamp">Expect a valid lamp</param>
		/// <returns>If true, lamp is assigned. If false, nothing appened because the switch is full</returns>
		public bool AssignLamp (Lamp lamp)
		{
			if (_maxLamps < (_lamps + 1))
				return false;
			else
			{
				// Try all slots from _asignedLamps until reach _maxLamps.
				for (int i = 0; i < _maxLamps ; i++ )
				{
					// The lamp is added in the first null value
					if ( _asignedLamps[i] == null )
					{
						// The switch can be close, if yes, turn on the lamp
						if (_open == false)
							lamp.On();
						_asignedLamps[i] = lamp;
						_lamps++;
						break;
					}
				}
				return true;

			}
		}

		/// <summary>
		/// Remove a lamp from the switch
		/// </summary>
		/// <param name="lamp">Expect a valid lamp</param>
		/// <returns>If true, the lamp is succesfully removed. If false, nothing appened because the switch don't contain this lamp</returns>
		public bool UnassignLamp (Lamp lamp)
		{
			int j = 0;
			foreach (Lamp i in _asignedLamps)
			{
				if (i == lamp)
				{
					// To remove a lamp, the value is set to null. AssignLamp method will place the new lamp in a free space.
					_asignedLamps[j] = null;
					_lamps--;
					return true;
				}
				j++;
			}
			return false;
		}
		#endregion
		#region Switch the Switch
		/// <summary>
		/// Turn off all lamps
		/// </summary>
		public void Open ()
		{
			for (int i = 0 ; i < _maxLamps ; i++)
			{
				if (_asignedLamps[i] != null)
				_asignedLamps[i].Off();
				}
			_open = true;
		}

		/// <summary>
		/// Turn on all lamps
		/// </summary>
		public void Close ()
		{
			for (int i = 0; i < _maxLamps; i++)
			{
				if (_asignedLamps[i] != null)
				_asignedLamps[i].On();
			}
			_open = false;
		}
		#endregion
	}
}
