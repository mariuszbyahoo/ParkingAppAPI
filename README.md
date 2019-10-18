# ParkingAppAPI
* At the beggining the app consists only 5 parking slots, where this amount may be extended and widened by using HTTP Requests, and adjusted as needed
* HTTP requests supported:
  - HTTP GET (List all parking slots)
  - HTTP POST (Create a new parking slot)
  - HTTP PATCH (Occupy / Unoccupy a specific parking slot) ; generates a PDF ticket in the project's root folder if specified slot is free, if occupied wishes you a good day.
  - HTTP DELETE (Delete the slot from parking)
* Project includes "ParkingAppAPI.postman_collection.json" file in the project's root folder.
