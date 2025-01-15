# HomePulse API

HomePulse API presentation ! This API allows you to manage buildings, rooms within those buildings with their types, all the furnitures you might place in those rooms, and sensors installed in each room. It's designed to support a variety of sensors for environmental monitoring.

## Features

- **Building Management**: Create, update, and delete buildings.
- **Room Management**: Manage rooms within buildings, including adding, updating, and removing rooms.
- **Sensor Integration**: Add sensors to rooms, manage their placement, and retrieve sensor data (WIP)

---

## Getting Started

### Prerequisites

To use the API, ensure you have:

- .NET 8.0 or higher installed on your machine. (Current packages list and their versions are listed at the end)
- A supported database (We're using PostgreSQL with Npgsql, but you can use whatever suits you).
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

3. Configure your database connection in `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "YourConnectionStringHere"
     }
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

The API will be available at `http://localhost:5000`.

---

## API Endpoints

### Buildings

#### Get All Buildings
**GET** `/api/buildings`
- Retrieves a list of all buildings.

#### Create a Building
**POST** `/api/buildings`
- **Request Body**:
  ```json
  {
    "name": "Building Name",
    "address": "123 Main Street",
    "description": "Optional description"
  }
  ```

#### Update a Building
**PUT** `/api/buildings/{id}`
- **Request Body**:
  ```json
  {
    "name": "Updated Building Name",
    "address": "Updated Address",
    "description": "Updated description"
  }
  ```

#### Delete a Building
**DELETE** `/api/buildings/{id}`

---

### Rooms

#### Get Rooms in a Building
**GET** `/api/buildings/{buildingId}/rooms`

#### Create a Room
**POST** `/api/buildings/{buildingId}/rooms`
- **Request Body**:
  ```json
  {
    "name": "Conference Room A",
    "floor": 3,
    "description": "Optional room description"
  }
  ```

#### Update a Room
**PUT** `/api/rooms/{id}`

#### Delete a Room
**DELETE** `/api/rooms/{id}`

---

### Sensors

#### Get Sensors in a Room
**GET** `/api/rooms/{roomId}/sensors`

#### Add a Sensor to a Room
**POST** `/api/rooms/{roomId}/sensors`
- **Request Body**:
  ```json
  {
    "type": "Temperature",
    "model": "TS-100",
    "status": "Active"
  }
  ```

#### Update Sensor Details
**PUT** `/api/sensors/{id}`

#### Delete a Sensor
**DELETE** `/api/sensors/{id}`

---

## Error Handling

The API uses standard HTTP status codes to indicate success or failure:

- `200 OK`: Successful operation.
- `201 Created`: Resource successfully created.
- `400 Bad Request`: Invalid input provided.
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