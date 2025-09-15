﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskDay04EF.models
{
	public enum AppointmentStatus
	{
		Scheduled = 1,
		Confirmed = 2,
		InProgress = 3,
		Completed = 4,
		Cancelled = 5,
		NoShow = 6
	}
}
