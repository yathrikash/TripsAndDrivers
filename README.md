# TripsAndDrivers

you can register drivers and add trips for the registered drivers.
Once you are done with the registration and trips added, you can see the report.

Commands:
Driver
Trip
Done

Driver:
	Command Format:
	
		Driver <driver name>
	 desc:
		This will register driver
	Example:
		Driver Dan
Trip:
	Command Format:
		Trip <registered driver name> <start time> <end time> <total kms>
	desc:	
		This will add a trip to the registered driver. Note if driver driven average speed < 5kmph or speed > 100 kmph, it will not be considered as trip.
	Example:
		ip Dan 7.15 7.45 21.5
Done:
	Command format:
		Done
	Desc:
		This will stop getting commands and show your report.
	Example: 
		Done

Report format:
		<DriverName> : <total no of miles> mils @ <avg speed> kmph.
	Example:
		Dan : 45 milles @ 55 kmph