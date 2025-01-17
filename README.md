# HomePulse API

HomePulse API presentation ! This API allows you to manage buildings, rooms within those buildings with their types, all the furnitures you might place in those rooms, and sensors installed in each room. It's designed to support a variety of sensors for environmental monitoring. This API is designed to be hosted on Azure, and work with a specific Blazor Client, but its repository is not public yet.

## Features

- **Building Management**: Create, update, and delete buildings.
- **Room Management**: Manage rooms within buildings, including adding, updating, and removing rooms and their types.
- **Furniture Management**: Manage objects like doors, windows and tables to fill your rooms.
- **Sensor Integration**: Add sensors to rooms, manage their placement, and retrieve sensor data (WIP)

---

## Getting Started

### Prerequisites

To use the API, ensure you have:

- .NET 8.0 or higher installed on your machine. (Current packages list and their versions are listed at the end)
- A supported database (We're using PostgreSQL with Npgsql, but you can use whatever suits you with the appropriate packages).
- Entity Framework in the same version as the packages if you want to make a code-first database

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/AlixLejeune/SAE501_Blazor_API.git
   cd SAE501_Blazor_API
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Configure your database connection in `Program.cs`:
   ```cs
   //DataContext
    builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql($"Server={builder.Configuration["Server"]};port={builder.Configuration["Port"]};Database={builder.Configuration["Db"]};uid={builder.Configuration["uid"]};password={builder.Configuration["Password"]};"));

    //Local DataContext
    //builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql("Server=localhost;port=5432;Database=SAE_DB;uid=postgres;password=postgres;"));
   ```
   The **DataContext** configuration is used with Azure deployment and environment variables, while the **Local DataContext** is a a basic local PostgreSQL database. <br>
   If no DbContext is set up through injection, it will run the default connection string from the `DataContext.cs`:
   ```cs 
   if (!optionsBuilder.IsConfigured)
    {
        optionsBuilder.UseNpgsql("SAE_DB_Local");
    }
    ```
    The string itself is stored into `appsettings.json`: 
    ```json
      "ConnectionStrings": 
      {
        "SAE_DB_Local": "Server=localhost;port=5432;Database=SAE_DB;uid=postgres;password=postgres;"
      }
    ```
  


4. Run migrations to set up the database schema:
   ```bash
   dotnet-ef database update
   ```

5. Start the API:
   ```bash
   dotnet run
   ```

The API will be available at `http://localhost:5000` or `http://localhost:5256`.<br>
If you enabled Swagger, it will run at `http://localhost:7053`.

---

## API Endpoints

### Buildings

The class representing the building in which the rooms are located. They have no 3D model in the client, so the class is pretty simple.

### Get the buildings 

**GET** `/api/building`
- Retrieves a list of all buildings.

**GET** `/api/building/dto`
- Retrieves a list of all buildings' dto's.

**GET** `/api/building/getbyid/{id}`
- Retrieves the building of corresponding id if it exists.

#### Create a Building
**POST** `/api/building`
- **Request Body**:
  ```json
  {
  "name": "string"
  }
  ```
  The building's id is a sequencial number. The list of rooms inside it don't need to be posted, it will be resolved by Entity Framework when you get a specific building.

#### Update a Building
**PUT** `/api/building/{id}`
- **Request Body**:
  ```json
  {
    "name": "Updated Building Name"
  }
  ```

#### Delete a Building
**DELETE** `/api/building/{id}`

---

### RoomType
### Get the room types 

Same as building, pretty basic class we use to tell what the rooms are used for.

**GET** `/api/roomtype`
- Retrieves a list of all room types.

**GET** `/api/roomtype/dto`
- Retrieves a list of all room types' dto's.

**GET** `/api/roomtype/getbyid/{id}`
- Retrieves the room type of corresponding id if it exists.

#### Create a room type
**POST** `/api/roomtype`
- **Request Body**:
  ```json
  {
  "name": "string"
  }
  ```

#### Update a room type
**PUT** `/api/roomtype/{id}`
- **Request Body**:
  ```json
  {
    "name": "Updated RoomType Name"
  }
  ```

#### Delete a room type
**DELETE** `/api/roomtype/{id}`

---

### Rooms

One of the main class of the client. Have a north orientation in degree, telling how much the room model is turned. Height is in meters. Base is a list of vertices' corrdinates, you need at least 3 point to draw the base of your room, multiplied by your height to get a 3D solid in the client.<br>
IdBuilding and IdRoomType are the foreign keys of the building the room is in, and the type of room this is.

#### Get the rooms

**GET** `/api/room`
- Retrieves a list of all rooms.

**GET** `/api/room/{id}`
- Retrieves the room of corresponding id if it exists.

#### Create a Room
**POST** `/api/room`
- **Request Body**:
  ```json
  {
  "name": "string",
  "northOrientation": 0,
  "height": 0,
  "base": [
    {
      "x": 0,
      "y": 0
    },
    {
      "x": 0,
      "y": 0
    },
    {
      "x": 0,
      "y": 0
    }
  ],
  "idBuilding": 0,
  "idRoomType": 0
  }
  ```

#### Update a Room
**PUT** `/api/room/{id}`

#### Delete a Room
**DELETE** `/api/room/{id}`

---

### RoomObjects

This class is an abstract class describing all the furnitures and sensors. You can't push a pure RoomObject into the database, as it will generate an error. Instead, the name of the concrete class is told in the Json (case sensitive).<br>
Classes currently mapped: 
- Door
- Heater
- Table 
- Window
- Lamp
- Plug
- Sensor6in1
- Sensor9in1
- SensorCO2
- Siren
- CustomObject

Each of these classes implements diffrent interfaces depending on how they're allowed to be manipulated by the client (IPosition, IRotation, IOrientation, ISize), differenciating their properties.

#### Get room objects
**GET** `/api/roomobjects`
- Retrieves a list of all the room objects.

**GET** `/api/roomobjects/dto`
- Retrieves a list of all the room objects' dto's.

**GET** `/api/roomobjects/getbyid/{id}`
- Retrieves the room object withthe corresponding id if it exists.

#### Add an object to a Room
**POST** `/api/roomobjects`
- **Request Body**:
  ```json
  {
  "customName": "myDoor",
  "idRoom": 1,
  "RoomObjectType": "Door",

  "PosX": 1,
  "PosY": 1,
  "PosZ": 1,
  "Orientation": 1,
  "SizeX": 1,
  "SizeY": 1,
  "SizeZ": 1
  }
  ```
The example above is a post for a door with all its properties. Only the 3 first are required, all the interface's specific properties will depends of what object you're posting. If not specified, they're set at 0 by default.

#### Update a room object details
**PUT** `/api/roomobjects/{id}`

Same as post, the Json body will depends of which object you're updating.

#### Delete a room object
**DELETE** `/api/roomobjects/{id}`

---

## Error Handling

The API uses standard HTTP status codes to indicate success or failure:

- `200 OK`: Successful operation.
- `201 Created`: Resource successfully created.
- `400 Bad Request`: Invalid input provided.
- '401 Unauthorized': You don't have the authorization to access the ressource
- `404 Not Found`: Resource not found.
- `500 Internal Server Error`: Unexpected error on the server.

---

## Packages

- AutoMapper v13.0.1
    - Author(s): Jimmy Bogard
    - MIT License, https://automapper.org/

- Microsoft.EntityFrameworkCore v8.0.4
    - Author(s): Microsoft
    - MIT License, https://docs.microsoft.com/ef/core

- Microsoft.EntityFrameworkCore.Tools v8.0.4
    - Author(s): Microsoft
    - MIT License, https://docs.microsoft.com/ef/core

- Microsoft.VisualStudio.Web.CodeGeneration.Design v8.0.4
    - Author(s): Microsoft
    - MIT License, https://github.com/dotnet/Scaffolding

- Moq v4.20.72
    - Author(s): Daniel Cazzulino, kzu
    - BSD 3-Clause License, https://github.com/moq/moq

- MSTest v3.6.4
    - Author(s): Microsoft
    - MIT License, https://github.com/microsoft/testfx

- Npgsql.EntityFrameworkCore.PostgreSQL v8.0.4
    - Author(s): Shay Rojansky,Austin Drenski,Yoh Deadfall
    - PostgreSQL License, https://github.com/npgsql/efcore.pg

- Npgsql.EntityFrameworkCore.PostgreSQL.Design v1.1.0
    - Author(s): Npgsql.EntityFrameworkCore.PostgreSQL.Design
    - unfound license, registered in NuGet package manager as https://raw.githubusercontent.com/npgsql/Npgsql.EntityFrameworkCore.PostgreSQL/dev/LICENSE.txt leading to a 404 error

- Swashbuckle.AspNetCore v6.4.0
    - Author(s): Swashbuckle.AspNetCore
    - MIT License, https://github.com/domaindrivendev/Swashbuckle.AspNetCore

### Licenses disclaimer

- MIT License 
    - Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

        The above copyright notice and this permission notice (including the next paragraph) shall be included in all copies or substantial portions of the Software.

        THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

- BSD-3-Clause License
    - Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

    1. Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
    2. Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
    3. Neither the name of the copyright holder nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.

        THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

- PostgreSQL License

     - Portions Copyright (c) 1996-2010, The PostgreSQL Global Development Group

        Portions Copyright (c) 1994, The Regents of the University of California

        Permission to use, copy, modify, and distribute this software and its documentation for any purpose, without fee, and without a written agreement is hereby granted, provided that the above copyright notice and this paragraph and the following two paragraphs appear in all copies.

        IN NO EVENT SHALL THE UNIVERSITY OF CALIFORNIA BE LIABLE TO ANY PARTY FOR DIRECT, INDIRECT, SPECIAL, INCIDENTAL, OR CONSEQUENTIAL DAMAGES, INCLUDING LOST PROFITS, ARISING OUT OF THE USE OF THIS SOFTWARE AND ITS DOCUMENTATION, EVEN IF THE UNIVERSITY OF CALIFORNIA HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

        THE UNIVERSITY OF CALIFORNIA SPECIFICALLY DISCLAIMS ANY WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE. THE SOFTWARE PROVIDED HEREUNDER IS ON AN "AS IS" BASIS, AND THE UNIVERSITY OF CALIFORNIA HAS NO OBLIGATIONS TO PROVIDE MAINTENANCE, SUPPORT, UPDATES, ENHANCEMENTS, OR MODIFICATIONS.
