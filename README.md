# P_DBBA_WFNET

Programa para la asignatura de Bases de datos avanzadas impartida por el profesor Ing. José Guevara.

Consiste en la lectura e interpretación de una sucesión de tuplas almacenadas en eun archivo CSV con datos de diferentes libros.
Los datos deben ser introducidos en una BDD postgress en el store Heroku. Para esto, se cuenta con dos tablas que determinan a la 
composición de autor y libros. 

Se hace uso de QUERIES SQL postgress, además de funciones PL/pgSQL en el manejador PGAdmin. 

![Pgadmin](https://user-images.githubusercontent.com/48733708/112758636-5c982d80-8fbd-11eb-91b2-155e5e4d1356.png)


Como nota: debido a limitaciones de conexión la primera carga de las tuplas puede demorar unos cuantos minutos. 


El programa cargará los valores en su momento de ejecución. No obstante, los botones "Insert from CSV" y "Load data into Grid Table" cargarán los valores del archivo CSV a la BDD y traerán las tuplas hasta las tablas de la interfaz, respectivamente. 

El resultado del programa muestra dos tablas con los valores almacenados. 

![Prueba](https://user-images.githubusercontent.com/48733708/112758822-3c1ca300-8fbe-11eb-8206-da7035155ce2.png)
