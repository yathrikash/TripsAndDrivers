# TripsAndDrivers

you can register drivers and add trips for the registered drivers.
Once you are done with the registration and trips added, you can see the report.

Commands:
Driver
Trip
Done

Driver:
	Command Format:
	
		Driver DRIVERNAME
	 desc:
		This will register driver
	Example:
		Driver Dan
		
		
Trip:  
	Command Format:  
		Trip REGISTERED_DRIVER_NAME     START_TIME     END_TIME     TOTAL_KMS  
	desc:	  
		This will add a trip to the registered driver. Note if driver driven average speed < 5kmph or speed > 100 kmph, it will not be considered as trip.  
	Example:  
		Trip Dan 7.15 7.45 21.5  
	
	
Done:  
	Command format:  
		Done  
	Desc:  
		This will stop getting commands and show your report.  
	Example:   
		Done  

Report format:  
		DRIVER_NAME : TOTAL_NO_OF_MILES   mils @    AVERAGE_SPEED   kmph.  
	Example:  
		Dan : 45 milles @ 55 kmph  
