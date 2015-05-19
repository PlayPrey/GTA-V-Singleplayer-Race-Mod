# SPraceMod
Single player mod for GTA V; Provides RACING outside of Online.

Basic information about how I make the mod;

I create a new TaskSequence(remember to define this in a method). 
And then I add tasks to the sequence (DriveTo).
Finally after adding all the checkpoints in DriveTo tasks, do a 'taskSequence.Close();'.

When youre done making the Task Sequence, you can do 'pedName.Task.PerformSequence(taskSequence);'.
(Note: This has to be done after the ped has spawned, and after the vehicle have spawned) 
(Note2: To make stuff a little easier, I usually start the taskSequence with *.AddTask.WarpIntoVehicle(veh, DriverSeat);)

Now; I don't know what is wanted in the readme so this was a complete guess.
