\# Programación 3 – TP Integrador: Web API de Productos



Alumna: Celis Belén Micaela


Web API desarrollada con \*\*ASP.NET Core (C#, .NET 8)\*\* que permite consultar productos almacenados en \*\*SQL Server\*\* mediante \*\*ADO.NET\*\*.



\## Arquitectura



```

Cliente (HTTP)

&#x20;  ↓

ProductosController   → recibe la solicitud y devuelve la respuesta HTTP

&#x20;  ↓

IProductoService / ProductoService   → lógica de la aplicación

&#x20;  ↓

IProductoRepository / ProductoRepository   → acceso a datos con ADO.NET

&#x20;  ↓

SQL Server (base Programacion3, tabla Productos)

```



Se usa Inyección de Dependencias (`AddScoped`) para conectar las capas.



\## Estructura del proyecto



```

Programacion3.API

├── Controllers   → ProductosController.cs

├── Models        → Producto.cs

├── Services      → IProductoService.cs, ProductoService.cs

├── Data          → IProductoRepository.cs, ProductoRepository.cs, AccesoDatosException.cs

├── appsettings.json

└── Program.cs

sql/              → scripts de la base de datos

```



\## Requisitos



\- .NET 8 SDK

\- SQL Server accesible (local o remoto)

\- Visual Studio 2022 (opcional; también se puede ejecutar con `dotnet run`)



\## 1. Crear la base de datos



Ejecutar en SQL Server, en este orden, los scripts de la carpeta `sql/`:



1\. `01\_crear\_base\_de\_datos.sql`

2\. `02\_crear\_tabla\_productos.sql`

3\. `03\_datos\_de\_prueba.sql` (carga 5 productos y hace un SELECT de verificación)



\## 2. Configurar la cadena de conexión



`appsettings.json` contiene una cadena de \*\*ejemplo\*\*. Para ejecutar el proyecto:



1\. Crear un archivo `appsettings.Development.json` dentro de la carpeta `Programacion3.API` del proyecto (junto a `appsettings.json`).

2\. Completarlo con la cadena de conexión propia:



```json

{

&#x20; "ConnectionStrings": {

&#x20;   "Programacion3": "Data Source=SERVIDOR,PUERTO;Initial Catalog=Programacion3;User ID=USUARIO;Password=CLAVE;Encrypt=False;TrustServerCertificate=True"

&#x20; }

}

```



`appsettings.Development.json` está en el `.gitignore`: \*\*no se sube al repositorio\*\* para no exponer credenciales.



\## 3. Ejecutar



Con Visual Studio: abrir `Programacion3.API.sln` y ejecutar con \*\*F5\*\*.



Con la terminal:



```

cd Programacion3.API

dotnet run

```



Abrir Swagger en la URL que indica la consola (por ejemplo `https://localhost:7076/swagger`).



\## Endpoints



| Método | Ruta | Descripción | Respuestas |

|---|---|---|---|

| GET | `/api/productos` | Devuelve todos los productos | 200 OK, 500 si falla la base de datos |

| GET | `/api/productos/{id}` | Devuelve un producto por Id | 200 OK, 404 Not Found, 500 si falla la base de datos |



\## Pruebas realizadas



| Prueba | Solicitud | Resultado esperado |

|---|---|---|

| 1 | `GET /api/productos` | 200 OK con la lista de productos |

| 2 | `GET /api/productos/1` | 200 OK con el producto |

| 3 | `GET /api/productos/9999` | 404 Not Found |

| 4 | Consulta con SQL Server no disponible | 500 con mensaje genérico, sin datos internos |



Las capturas de las pruebas se encuentran en la entrega.



\## Manejo de errores



\- Un producto inexistente devuelve \*\*404\*\*.

\- Si falla el acceso a SQL Server, el Repository registra el detalle técnico en el log y lanza `AccesoDatosException`; el Controller responde \*\*500\*\* con un mensaje genérico, sin exponer la cadena de conexión ni detalles internos.

\- Las consultas usan \*\*parámetros SQL\*\* (`@Id`) y los objetos de ADO.NET se liberan con `using`.

