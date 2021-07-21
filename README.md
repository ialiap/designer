# designer

this source code is only a test project

## Installation

Using Manual build requires a raven database connection for tests to pass and for services to function. database connection can be change in application settings.

```bash
dotnet restore
dotnet test
dotnet Designer.Service.API.dll
```
Since the service is docker enabled another option is to use docker-compose.

```bash
docker-compose up
```
for rebuild images in case of changes
```bash
docker-compose build
```

## Contributing
Pull requests are welcome. feel free to add comments and improvement request and I will change them ASAP.



## License
[MIT](https://choosealicense.com/licenses/mit/)
