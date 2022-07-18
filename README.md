# netcore-api-sample
This is a simple task/assignment about NET Core API., with proper structure.

The goal
Converting this object: 
[
	["Ford", "Fiesta", "Manual", "Rp. 120,000,000"],
	["Ford", "Fiesta", "Manual", "Rp. 134,000,000"],
	["Ford", "Fiesta", "Automatic", "Rp. 140,000,000"],
	["Ford", "Fiesta", "Automatic", "Rp. 150,000,000"],
	["Ford", "Focus", "Manual", "Rp. 330,000,000"],
	["Ford", "Focus", "Manual", "Rp. 335,000,000"],
	["Ford", "Focus", "Manual", "Rp. 350,000,000"],
	["Ford", "Focus", "Automatic", "Rp. 360,000,000"],
	["VW", "Golf", "Manual", "Rp. 350,000,000"],
	["VW", "Golf", "Automatic", "Rp. 370,000,000"]
];

Into this response
[
	["Ford", "Fiesta", "Manual", "Rp. 120,000,000"],
	["", "", "", "Rp. 134,000,000"],
	["", "", "Automatic", "Rp. 140,000,000"],
	["", "", "", "Rp. 150,000,000"],
	["", "Focus", "Manual", "Rp. 330,000,000"],
	["", "", "", "Rp. 335,000,000"],
	["", "", "", "Rp. 350,000,000"],
	["", "", "Automatic", "Rp. 360,000,000"],
	["VW", "Golf", "Manual", "Rp. 350,000,000"],
	["", "", "Automatic", "Rp. 370,000,000"]
];

Using the GET method.
