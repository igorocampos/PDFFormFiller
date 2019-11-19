# VanHackathon - PDF Form Filler
This project was part of a VanHackathon 2019's challenge where one must fill the fields of a given PDF file and return it to the user.
I chose to implement it as a REST API so it could be easily integrated into whatever system that holds the actual data. The main idea here is to send a JSON with the data that needs to be filled in the file and receive back a filled PDF.

## Tech stack
This project was made using a .NET Core 3.0 Web API dockerized with a PostgreSQL database.
The Database was only needed in order to not hard-code the PDF field names, so if any of them change, the only need is to send a `PUT` request with the new name. The same goes for a new PDF field, just use the API's `POST`. 
API's documentation was done with Swashbuckle's Swagger and can be reached by the webserver initial page (e.g. `http://localhost:8080`).

For last, PDF reading and editing was done using [iText 7](https://www.nuget.org/packages/itext7/). This 3rd party tool was used because of the following reasons:
- Most popular PDF tool for Java and C#, which means wide community support.
- Easy integration and update via Nuget.
- [Double license](https://itextpdf.com/en/how-buy) which allows you to either have it for free under AGPL and not commercialize your solution, or buy a license (there are many license purchase models) and do whatever you want.

## Set up
You will need [docker](https://www.docker.com/products/docker-desktop) installed to run this project. This ensures that we get an identical result.

After installing docker, download this repository in a folder (or just clone it), be sure to be in the folder where the `docker-compose.yml` file is and run the following command:
```ps
docker-compose up
```

If you don't already have the containers' image, docker will download it, then it will compile this project, run all unit and integration tests and start the webserver for you.

You can access it in `http://localhost:8080`.
Please, make sure port `8080` is not already in use. If you wish to change this port, that can be altered in the `docker-compose.yml` file.

## Unit and Integration Tests
As a part of this project, you will find some Unit and Integration tests. They both use a [in memory database](https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/in-memory), so no harm will be caused in the actual database.

Unit Tests will test the operation methods calling it directly with a controller instance and then verify the resulting context.

Integration Tests will test the web requests and verify its results, simulating a client doing an HTTP request on the API.

## Usage
The API comes with the first 2 pages field names already inserted in the database, to retrieve a filled PDF file send a `POST` method at `http://localhost:8080/api/ApplicationForm` with a JSON body with all data you wish to be filled in the file.
For example, if you send the following in the request's body:
```json
{
    "ReferralOrganizationName": "Some organization name"
}
```

A PDF File will be downloaded and you can check that the `ReferralOrganizationName` field is now filled.
A list of all field names can be checked at the Swagger documentation.

Below a table with the API's methods:

### Field Naming
Use this one to save or alter field relations between PDF and JSON naming. 

| Name   | Method      | URL                            | Notes                                             |
| ---    | ---         | ---                            | ---                                               |
| List   | `GET`       | `/api/FieldNamings?page=1`     | `page` parameter is optional                      |
| Create | `POST`      | `/api/FieldNamings`            | `page` must be between 1 and 13                   |
| Get    | `GET`       | `/api/FieldNamings/{fieldName}`| Example of `fieldName`: `ReferralOrganizationName`|
| Update | `PUT`       | `/api/FieldNamings/{fieldName}`|  |
| Delete | `DELETE`    | `/api/FieldNamings/{fieldName}`|  |

### Application Form
Use this one to send the data you wish to be filled in the PDF file

| Name   | Method      | URL                            | Notes                                             |
| ---    | ---         | ---                            | ---                                               |
| Get PDF| `POST`      | `/api/ApplicationForm`         | A JSON of ApplicationForm data must be sent in the body of the request. All fields are optional. A PDF file will be downloaded as a result of the request. |

## Future Implementations
### Business Rules Validation
Right now, this API is accepting as much as the PDF file handles. This means that there are no business rules implemented, for example, some checkboxes seem to be mutually exclusive even though the PDF file accepts checking both/all of them. Also, some sections depend on another field's data to be filled or not.

Most of these rules should be defined by the Product Owner and can be implemented in the Application Form `POST` method.

### CI/CD Integration
Although the test projects run when the docker container is composed, it would be much better to integrate the tests and delivery with some CI/CD tool, like `TeamCity` or `Azure DevOps`. This depends on the repository owner.