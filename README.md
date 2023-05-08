## Demo: https://shopping-cart-caf01.vercel.app/

# Carrito de compras básico
Administra diferente sucursales, catálogo de productos, clientes y proporciona un carrito de compra.

## Crea tu cuenta!
Para acceder al sitio es necesario que crees tu cuenta e ingresa tus credenciales para acceder al panel de operaciones.
![registro](https://user-images.githubusercontent.com/68396707/236649011-1cf07271-7802-4712-aef2-9a538a6da7bd.png)

![login](https://user-images.githubusercontent.com/68396707/236649059-6858c09f-b7b9-456b-8a7c-0fd3763c1fca.png)

## Sucursales!
Selecciona entre las diferentes sucursales/tiendas disponibles. O crea una nueva.
![image](https://user-images.githubusercontent.com/68396707/236650308-55b4e9de-8fe3-459f-946b-c9af92755c8e.png)


## Lista de productos por sucursal
Cada sucursal tiene un catálogo de productos. 
![image](https://user-images.githubusercontent.com/68396707/236650408-4fe2d4ef-a079-47e0-b436-34304fbbba7f.png)



## Registro de productos
Añade nuevos productos al catálogo de cada sucursal
![image](https://user-images.githubusercontent.com/68396707/236650398-0e86a789-dc27-424c-a6d7-ed53a6f11aef.png)

## Ventas
### Carrito de compra
Añade todos los productos que necesites, al finalizar tienes disponible el carrito de compra para efectuar el cobro.
![image](https://user-images.githubusercontent.com/68396707/236650558-948f9c01-f8ef-4c3f-8eb7-b3fde1a784e9.png)


Configuración necesaria para appsettings.json
Para configurar la aplicación se necesita la siguiente información en appsettings.json:

{
  "ConnectionStrings": {
    "ShoppingCartDB": "Data Source=Sunpop.ddns.net;Initial Catalog=ShoppingCartDB;user=sa;password=Abcd1234;TrustServerCertificate=true;"
  },
  "JWT": "C3y*LSGoOnS3OviEI078vbk0O00hv3B%FJi8WlqEN^j@UZ9Q9m",
  "Cloudinary": {
    "Cloud": "dn8vyctpa",
    "ApiKey": "384447785565489",
    "Secret": "ssYE3dzbv99ta3qzR4RC4ux8jm8"
  }
}

## ----------------------------------------------------------------------------------------------------

### Project

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 15.1.
