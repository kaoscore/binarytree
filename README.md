# API REST - ARBOL BINARIO Y ANCESTRO MAS CERCANO

Api Rest que permite crear  un arbol binario agregando cada uno de los nodos. Dado este arbol permite retornar el ancestro común mas cercano.

## Para empezar

Puede utilizar esta API REST desde el endpoint público:

https://webapitree.azurewebsites.net


### [GET] CREACION DEL ARBOL

Permite crear un arbol binario agregando valores a cada uno de los nodos

https://webapitree.azurewebsites.net/tree/{VALOR DEL NODO: TIPO NUMERICO}

```
https://webapitree.azurewebsites.net/tree/83
```

### [GET] ANCESTRO MAS CERCANO

Luego de agregar los nodos al árbol, puede consultar el ancestro mas cercano entre dos nodos

https://webapitree.azurewebsites.net/tree/{VALOR DEL NODO 1: TIPO NUMERICO}/{VALOR DEL NODO 2: TIPO NUMERICO}

```
https://webapitree.azurewebsites.net/tree/29/44
```

### [GET] LIMPIAR EL ARBOL

A medida que ingresa valores al árbol estos se grabarán en memoria. Para limpiar el árbol y volver a empezar se invoca este método

https://webapitree.azurewebsites.net/tree/

```
https://webapitree.azurewebsites.net/tree
```

### SOLUCION PLANTEADA

Para desarrollar el API se utilizo el lenguaje de programación C# con ASP.NET WEB API.

La solución esta implementada en la nube de Azure para efectos de pruebas y con el propósito de que sea escalable utilizando
el servicio de Paas App Service https://azure.microsoft.com/es-es/services/app-service/

### Carpetas de la solución

WebApiTree
```
Proyecto WebApi c# con .Net Framework 4.7
```
libLogic
```
Lógica de programación que permite crear cada uno de los nodos del arbol, y calcula el ancestro comun entre dos nodos
```
libModel
```
Entidad que referencia cada uno de los nodos del arbol. Tiene un valor y ramas izquierda y derecha.
```

## Ejecución de las pruebas

1. Realice el llamado al método que permite agregar un nodo tantas veces como valores se quieran ingresar al arbol
```
https://webapitree.azurewebsites.net/tree/67
https://webapitree.azurewebsites.net/tree/39
https://webapitree.azurewebsites.net/tree/76
https://webapitree.azurewebsites.net/tree/28
https://webapitree.azurewebsites.net/tree/29
https://webapitree.azurewebsites.net/tree/44
https://webapitree.azurewebsites.net/tree/74
https://webapitree.azurewebsites.net/tree/85
https://webapitree.azurewebsites.net/tree/83
https://webapitree.azurewebsites.net/tree/87
```

2. Realice el llamado al método que permite consultar el ancestro común mas cercano entre dos nodos

```
https://webapitree.azurewebsites.net/tree/29/44

Retorna 39
```
```
https://webapitree.azurewebsites.net/tree/44/85

Retorna 67
```
```
https://webapitree.azurewebsites.net/tree/83/87

Retorna 85
```

## Constuido con

* [Visual Studio 2019](https://visualstudio.microsoft.com) - IDE de desarrollo
* [C#](https://docs.microsoft.com/es-es/dotnet/csharp/tour-of-csharp/) - Lenguaje de programación
* [Asp Net WebApi](https://dotnet.microsoft.com/apps/aspnet/apis) - Tecnología para construcción de Api Rest


## Autor

* **Guillermo Valenzuela** - *Desarrollador .NET Senior* - (https://github.com/kaoscore)


## Licencia

MIT License 

## Acknowledgments

* Masivian, por plantearme tan interesante reto


