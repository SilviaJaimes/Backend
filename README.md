# Prueba Backend 🔧

Este proyecto proporciona una API que permite integrar diferentes aplicaciones creadas por una empresa consultora de software.

## Características 🌟

- Registro de usuarios.
- Autenticación con usuario y contraseña.
- Generación y utilización del token.
- CRUD completo para cada entidad.
- Vista de las consultas requeridas.

## Uso 🕹

Una vez que el proyecto esté en marcha, puedes acceder a los diferentes endpoints disponibles:

 En el archivo CSV se encuentra registrado el administrador con:   
 **Usuario**: `Admini`  
 **Contraseña**: `pass1234`       
Necesitaremos de este usuario para obtener el token que se utilizará para el registro de usuarios, ya que solo el administrador podra hacer todo con respecto al CRUD de los usuarios.

## 1. Generación del token 🔑:

**Endpoint**: `http://localhost:5258/api/prueba/usuario/token`

**Método**: `POST`

**Payload**:

    {
        "Nombre": "Admini",
        "Contraseña": "pass1234"
    }

Al obtener el token del administrador, se podrá realizar el registro de usuarios.

## 2. Registro de Usuarios 📝:

**Endpoint**: `http://localhost:5258/api/prueba/usuario/register`

**Método**: `POST`

**Payload**:

Json

    {
        "Nombre": "<nombre_de_usuario>",
        "Contraseña": "<contraseña>",
        "CorreoElectronico": "<correo_electronico>"
    }

Este endpoint permite a los usuarios registrarse en el sistema.

Una vez registrado el usuario tendrá que ingresar para recibir un token, este será ingresado al siguiente Endpoint que es el de Refresh Token.

## 3. Refresh Token 🔄:

**Endpoint**: `http://localhost:5258/api/prueba/usuario/refresh-token`

**Método**: `POST`

**Payload**:

    {
        "Nombre": "<nombre_de_usuario>",
        "Contraseña": "<contraseña>"
    }

Se dejan los mismos datos en el Body y luego se ingresa al "Auth", "Bearer", allí se ingresa el token obtenido en el anterior Endpoint.

## Otros Endpoints

Obtener Todos los Usuarios: **GET** `http://localhost:5258/api/prueba/usuario`

Obtener Usuario por ID: **GET** `http://localhost:5258/api/prueba/usuario/{id}`

Actualizar Usuario: **PUT** `http://localhost:5258/api/prueba/usuario/{id}`

Eliminar Usuario: **DELETE** `http://localhost:5258/api/prueba/usuario/{id}`


## Desarrollo de los Endpoints requeridos⌨️

Cada Endpoint tiene la versión 1.0 y la 1.1, estos también cuentan con paginación, que se encuentra en cada Endpoint en la versión 1.1.  

Para consultar la versión 1.0 de todos se ingresa únicamente el Endpoint; para consultar la versión 1.1 se deben seguir los siguientes pasos: 

En el Thunder Client se va al apartado de "Headers" y se ingresa lo siguiente:

![image](https://github.com/SilviaJaimes/Proyecto-Veterinaria/assets/132016483/8044ee3d-76d9-4437-9f08-da8e5d7cff9a)

Para realizar la paginación se va al apartado de "Query" y se ingresa lo siguiente:

![image](https://github.com/SilviaJaimes/Proyecto-Veterinaria/assets/132016483/22683e46-037e-4f30-96b8-161df8622b40)      

#### 1. Listar todos los empleados de la empresa de seguridad:  

Endpoint: `http://localhost:5258/api/prueba/persona/consulta-1`  

Método: `GET`  

#### 2. Listar todos los empleados que son vigilantes:  

Endpoint: `http://localhost:5258/api/prueba/persona/consulta-2`  

Método: `GET`  

#### 3. Listar dos números de contacto de un empleado que sea vigilante:  

Endpoint: `http://localhost:5258/api/prueba/persona/consulta-3`  

Método: `GET`  

#### 4. Listar todos los clientes que vivan en la ciudad de Bucaramanga:  

Endpoint: `http://localhost:5258/api/prueba/persona/consulta-4`  

Método: `GET`  

#### 5. Listar todos los clientes que vivan en Girón y Piedecuesta:  

Endpoint: `http://localhost:5258/api/prueba/persona/consulta-5`  

Método: `GET`  

#### 6. Listar todos los clientes que tengan más de 5 años de antigüedad:  

Endpoint: `http://localhost:5258/api/prueba/persona/consulta-6`  

Método: `GET`  

#### 7. Listar todos los contratos cuyo estado es `Activo`:  

Muestra: el número de contrato, el nombre del cliente y el empleado que registro el contrato.

Endpoint: `http://localhost:5258/api/prueba/contrato/consulta-7`  

Método: `GET`  

## Desarrollo ⌨️
Este proyecto utiliza varias tecnologías y patrones, incluidos:

Patrón Repository y Unit of Work para la gestión de datos.

AutoMapper para el mapeo entre entidades y DTOs.

## Agradecimientos 🎁

A todas las librerías y herramientas utilizadas en este proyecto.

A ti, por considerar el uso de este sistema.

⌨️ con ❤️ por Silvia.
